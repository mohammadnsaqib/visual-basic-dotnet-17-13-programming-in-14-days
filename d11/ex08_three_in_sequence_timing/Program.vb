' Three waits, each started only after the one before it finished.
Imports System
Imports System.Diagnostics
Imports System.Threading.Tasks

Module Program
    Async Function FetchAsync(takes As Integer) As Task(Of Integer)
        Await Task.Delay(takes)
        Return takes
    End Function

    Async Function RunAsync() As Task
        Dim clock = Stopwatch.StartNew()
        Dim first = Await FetchAsync(150)
        Dim second = Await FetchAsync(150)
        Dim third = Await FetchAsync(150)
        clock.Stop()

        Console.WriteLine($"work    : {first + second + third} ms")
        Console.WriteLine($"elapsed : {clock.Elapsed.TotalMilliseconds:F0} ms")
        Console.WriteLine("each Await finished before the next call was made")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
