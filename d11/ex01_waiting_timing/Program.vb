' Three pieces of work that wait. The thread waits with them, and does nothing else.
Imports System
Imports System.Diagnostics
Imports System.Threading

Module Program
    Function Fetch(name As String, takes As Integer) As Integer
        Thread.Sleep(takes)
        Return takes
    End Function

    Sub Main()
        Dim clock = Stopwatch.StartNew()
        Dim first = Fetch("rent", 150)
        Dim second = Fetch("wages", 150)
        Dim third = Fetch("power", 150)
        clock.Stop()

        Console.WriteLine($"waited for  : {first + second + third} ms of work")
        Console.WriteLine($"took        : {clock.Elapsed.TotalMilliseconds:F0} ms")
        Console.WriteLine($"threads used: 1")
        Console.WriteLine("the thread was asleep for almost all of it")
    End Sub
End Module
