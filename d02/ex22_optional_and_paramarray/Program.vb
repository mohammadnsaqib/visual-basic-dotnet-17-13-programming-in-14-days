' Optional supplies a default; ParamArray collects whatever is left.
Imports System

Module Program
    Sub Main()
        Console.WriteLine(Line("total"))
        Console.WriteLine(Line("total", 20))
        Console.WriteLine(Line("total", 20, "."c))
        Console.WriteLine($"Sum()        = {Sum()}")
        Console.WriteLine($"Sum(1, 2, 3) = {Sum(1, 2, 3)}")
        Console.WriteLine($"Sum(array)   = {Sum(New Integer() {4, 5})}")
    End Sub

    Function Line(text As String, Optional width As Integer = 12,
                  Optional pad As Char = "-"c) As String
        Return text.PadRight(width, pad)
    End Function

    Function Sum(ParamArray values As Integer()) As Integer
        Dim total As Integer = 0
        For Each v In values
            total += v
        Next
        Return total
    End Function
End Module
