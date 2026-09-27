' The same work measured twice in one run. The first measurement includes the warming
' up.
Imports System
Imports System.Diagnostics

Module Program
    Function Total(upTo As Integer) As Long
        Dim sum As Long = 0
        For i = 1 To upTo
            sum += i
        Next
        Return sum
    End Function

    Sub Main()
        Const many As Integer = 1000

        Dim clock = Stopwatch.StartNew()
        Dim first = Total(many)
        clock.Stop()
        Dim firstMs = clock.Elapsed.TotalMilliseconds

        clock.Restart()
        Dim second = Total(many)
        clock.Stop()

        Console.WriteLine($"first  : {firstMs:F4} ms")
        Console.WriteLine($"second : {clock.Elapsed.TotalMilliseconds:F4} ms")
        Console.WriteLine($"same answer : {first = second}")
        Console.WriteLine("the first run pays for the just-in-time compilation of " &
                          "the method")
    End Sub
End Module
