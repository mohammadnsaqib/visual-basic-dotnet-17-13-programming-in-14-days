' Replace, Insert, Remove, PadLeft and PadRight all hand back new strings.
Imports System

Module Program
    Sub Main()
        Dim code As String = "AC-1001"
        Console.WriteLine($"Replace   : {code.Replace("-", "/")}")
        Console.WriteLine($"Insert    : {code.Insert(3, "X")}")
        Console.WriteLine($"Remove    : {code.Remove(2, 1)}")
        Console.WriteLine($"PadLeft   : [{code.PadLeft(10)}]")
        Console.WriteLine($"PadRight  : [{code.PadRight(10, "."c)}]")
        Console.WriteLine($"the original is still {code}")
    End Sub
End Module
