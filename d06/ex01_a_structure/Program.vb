' A structure declared, built and printed. So far it behaves like any other type.
Imports System

Structure Coord
    Public ReadOnly X As Integer
    Public ReadOnly Y As Integer

    Public Sub New(across As Integer, up As Integer)
        X = across
        Y = up
    End Sub

    Public Overrides Function ToString() As String
        Return $"({X}, {Y})"
    End Function
End Structure

Module Program
    Sub Main()
        Dim made As New Coord(3, 4)
        Dim blank As Coord
        Console.WriteLine($"made  : {made}")
        Console.WriteLine($"blank : {blank}")
        Console.WriteLine($"type            : {made.GetType().Name}")
        Console.WriteLine($"is a value type : {made.GetType().IsValueType}")
        Console.WriteLine($"inherits from   : {made.GetType().BaseType.Name}")
    End Sub
End Module
