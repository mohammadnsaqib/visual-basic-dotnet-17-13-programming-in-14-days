' A jagged array is an array of arrays, and the rows need not match.
Imports System

Module Program
    Sub Main()
        Dim rows()() As Integer = {
            New Integer() {1},
            New Integer() {2, 3, 4},
            New Integer() {5, 6}
        }
        Console.WriteLine($"rows          : {rows.Length}")
        For i = 0 To rows.Length - 1
            Console.WriteLine($"  row {i} holds {rows(i).Length}: " &
                              $"{String.Join(" ", rows(i))}")
        Next
        Console.WriteLine($"rows(1)(2)    : {rows(1)(2)}")
    End Sub
End Module
