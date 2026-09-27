' The index after the last one is not there, and asking for it says so.
Imports System

Module Program
    Sub Main()
        Dim scores(4) As Integer
        Console.WriteLine($"scores(4) is {scores(4)}, the last element")
        Console.WriteLine("asking for scores(5):")
        Console.WriteLine(scores(5))
    End Sub
End Module
