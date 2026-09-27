' Ten measurements of one piece of work, and the spread between them.
Imports System
Imports System.Diagnostics
Imports System.Linq

Module Program
    Function Total(upTo As Integer) As Long
        Dim sum As Long = 0
        For i = 1 To upTo
            sum += i
        Next
        Return sum
    End Function

    Sub Main()
        Const many As Integer = 2000000
        Total(many)

        Dim times(9) As Double
        For run = 0 To 9
            Dim clock = Stopwatch.StartNew()
            Total(many)
            clock.Stop()
            times(run) = clock.Elapsed.TotalMilliseconds
        Next

        Console.WriteLine($"runs    : {times.Length}")
        Console.WriteLine($"fastest : {times.Min():F2} ms")
        Console.WriteLine($"slowest : {times.Max():F2} ms")
        Console.WriteLine($"mean    : {times.Average():F2} ms")
        Console.WriteLine($"spread  : {times.Max() - times.Min():F2} ms")
        Console.WriteLine("the work did not change; the machine did")
    End Sub
End Module
