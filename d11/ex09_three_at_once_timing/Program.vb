' The same three waits, all started before any of them is awaited.
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
        Dim first = FetchAsync(150)
        Dim second = FetchAsync(150)
        Dim third = FetchAsync(150)
        Dim work = Await first
        work += Await second
        work += Await third
        clock.Stop()

        Console.WriteLine($"work    : {work} ms")
        Console.WriteLine($"elapsed : {clock.Elapsed.TotalMilliseconds:F0} ms")
        Console.WriteLine("the calls started the work; the Awaits only collected it")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
