' A stopwatch on a small piece of work, measured once.
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
        Const many As Integer = 5000000

        Dim clock = Stopwatch.StartNew()
        Dim answer = Total(many)
        clock.Stop()

        Console.WriteLine($"answer   : {answer}")
        Console.WriteLine($"elapsed  : {clock.Elapsed.TotalMilliseconds:F2} ms")
        Console.WriteLine($"resolution: " &
                          $"{If(Stopwatch.IsHighResolution, "high", "low")}")
        Console.WriteLine($"ticks per second : {Stopwatch.Frequency}")
    End Sub
End Module
