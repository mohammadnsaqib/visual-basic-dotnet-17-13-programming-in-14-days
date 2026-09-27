' For reads its bounds once, before the first pass.
Imports System

Module Program
    Sub Main()
        Dim last As Integer = 3
        Console.Write("counted:")
        For i = 1 To last
            Console.Write($" {i}")
            last = 10
        Next
        Console.WriteLine()
        Console.WriteLine($"last is now {last}, and the loop still ran 3 times")
    End Sub
End Module
