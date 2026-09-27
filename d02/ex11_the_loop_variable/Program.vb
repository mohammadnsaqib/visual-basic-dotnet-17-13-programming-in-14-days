' A loop variable declared in the For belongs to the loop.
Imports System

Module Program
    Sub Main()
        For i = 1 To 3
            Console.WriteLine($"inside, i is {i}")
        Next

        Dim j As Integer
        For j = 1 To 3
        Next
        Console.WriteLine($"j was declared outside, and after the loop it is {j}")
    End Sub
End Module
