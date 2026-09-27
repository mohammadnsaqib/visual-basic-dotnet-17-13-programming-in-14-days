' Result waits, and waiting is the thing async was for. Where it is safe and where it is
' not.
Imports System
Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks

Module Program
    Async Function BalanceAsync() As Task(Of Decimal)
        Await Task.Delay(60)
        Return 3800D
    End Function

    Sub Main()
        Console.WriteLine($"synchronisation context : " &
            $"{If(SynchronizationContext.Current Is Nothing, "none", "one")}")

        Dim clock = Stopwatch.StartNew()
        Dim blocking = BalanceAsync().Result
        clock.Stop()
        Console.WriteLine($"Result gave  : {blocking:N2} after " &
                          $"{clock.Elapsed.TotalMilliseconds:F0} ms")
        Console.WriteLine($"the thread was held for all of it")

        Dim awaited = BalanceAsync().GetAwaiter().GetResult()
        Console.WriteLine($"and so did GetResult : {awaited:N2}")
        Console.WriteLine("a console program has no context, so this waits rather " &
                          "than " &
                          "deadlocking")
        Console.WriteLine("under a context that runs one thing at a time, it would " &
                          "deadlock")
    End Sub
End Module
