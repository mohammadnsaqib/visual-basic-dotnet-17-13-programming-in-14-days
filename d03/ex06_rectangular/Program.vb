' A rectangular array is one object with two indexes.
Imports System

Module Program
    Sub Main()
        Dim grid(2, 3) As Integer
        For r = 0 To grid.GetUpperBound(0)
            For c = 0 To grid.GetUpperBound(1)
                grid(r, c) = r * 10 + c
            Next
        Next

        Console.WriteLine($"Rank       : {grid.Rank}")
        Console.WriteLine($"Length     : {grid.Length}")
        Console.WriteLine($"rows       : {grid.GetLength(0)}")
        Console.WriteLine($"columns    : {grid.GetLength(1)}")
        For r = 0 To grid.GetUpperBound(0)
            Dim row(grid.GetUpperBound(1)) As Integer
            For c = 0 To grid.GetUpperBound(1)
                row(c) = grid(r, c)
            Next
            Console.WriteLine($"  row {r}    : {String.Join(" ", row)}")
        Next
    End Sub
End Module
