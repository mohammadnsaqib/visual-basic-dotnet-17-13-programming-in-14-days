' ReDim makes a new array, and the old contents do not come with it.
Imports System

Module Program
    Sub Main()
        Dim values() As Integer = {1, 2, 3}
        Console.WriteLine($"before      : {String.Join(", ", values)}")
        ReDim values(4)
        Console.WriteLine($"after ReDim : {String.Join(", ", values)}")
        Console.WriteLine($"Length is now {values.Length}, and every element is 0")
    End Sub
End Module
