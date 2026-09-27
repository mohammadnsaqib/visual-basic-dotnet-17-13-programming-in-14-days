' An operator is a promise, and Visual Basic will not let half of one be made.
Imports System

Structure Ratio
    Public Top As Integer

    Public Shared Operator =(left As Ratio, right As Ratio) As Boolean
        Return left.Top = right.Top
    End Operator
End Structure

Module Program
    Sub Main()
        Dim a As New Ratio()
        Dim b As New Ratio()
        Console.WriteLine($"never printed : {a = b}")
    End Sub
End Module
