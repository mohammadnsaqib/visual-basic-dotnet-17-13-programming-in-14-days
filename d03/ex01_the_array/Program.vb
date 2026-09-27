' An array's declaration gives its LAST index, not its length.
Imports System

Module Program
    Sub Main()
        Dim scores(4) As Integer
        For i = 0 To scores.Length - 1
            scores(i) = (i + 1) * 10
        Next

        Console.WriteLine($"declared as scores(4)")
        Console.WriteLine($"Length      : {scores.Length}")
        Console.WriteLine($"first index : {scores.GetLowerBound(0)}")
        Console.WriteLine($"last index  : {scores.GetUpperBound(0)}")
        Console.WriteLine($"contents    : {String.Join(", ", scores)}")

        Dim named = {3, 1, 2}
        Console.WriteLine($"a literal of 3 has Length {named.Length}")
    End Sub
End Module
