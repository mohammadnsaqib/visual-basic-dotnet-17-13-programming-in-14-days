' The same 12 numbers, in one object and in four.
Imports System

Module Program
    Sub Main()
        Dim rectangular(2, 3) As Integer
        Dim jagged(2)() As Integer
        For r = 0 To 2
            jagged(r) = New Integer(3) {}
        Next

        Console.WriteLine($"rectangular Length : {rectangular.Length}")
        Console.WriteLine($"rectangular Rank   : {rectangular.Rank}")
        Console.WriteLine($"jagged Length      : {jagged.Length}")
        Console.WriteLine($"jagged Rank        : {jagged.Rank}")
        Console.WriteLine($"objects allocated  : 1 against {1 + jagged.Length}")
        Console.WriteLine($"rows 0 and 1 have the same length: " &
                          $"{jagged(0).Length = jagged(1).Length}")
    End Sub
End Module
