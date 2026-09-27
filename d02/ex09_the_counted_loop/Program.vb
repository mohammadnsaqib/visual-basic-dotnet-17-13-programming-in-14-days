' For counts from a start to an end, by a step, and the step may be negative.
Imports System

Module Program
    Sub Main()
        Console.Write("1 To 5        :")
        For i = 1 To 5
            Console.Write($" {i}")
        Next
        Console.WriteLine()

        Console.Write("1 To 10 Step 3:")
        For i = 1 To 10 Step 3
            Console.Write($" {i}")
        Next
        Console.WriteLine()

        Console.Write("5 To 1 Step -1:")
        For i = 5 To 1 Step -1
            Console.Write($" {i}")
        Next
        Console.WriteLine()

        Console.Write("5 To 1        :")
        For i = 5 To 1
            Console.Write($" {i}")
        Next
        Console.WriteLine(" (the body never ran)")
    End Sub
End Module
