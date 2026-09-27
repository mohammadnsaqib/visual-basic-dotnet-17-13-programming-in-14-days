' The same three pieces of work, awaited. The waiting is the same and the thread is not
' held.
Imports System
Imports System.Diagnostics
Imports System.Threading.Tasks

Module Program
    Async Function FetchAsync(name As String, takes As Integer) As Task(Of Integer)
        Await Task.Delay(takes)
        Return takes
    End Function

    Async Function RunAsync() As Task
        Dim clock = Stopwatch.StartNew()
        Dim first = Await FetchAsync("rent", 150)
        Dim second = Await FetchAsync("wages", 150)
        Dim third = Await FetchAsync("power", 150)
        clock.Stop()

        Console.WriteLine($"waited for  : {first + second + third} ms of work")
        Console.WriteLine($"took        : {clock.Elapsed.TotalMilliseconds:F0} ms")
        Console.WriteLine("awaiting one after another is still one after another")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
