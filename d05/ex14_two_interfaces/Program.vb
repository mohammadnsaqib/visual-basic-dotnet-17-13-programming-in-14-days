' A class can implement as many interfaces as it likes, and inherit one class.
Imports System

Public Interface IDescribable
    Function Describe() As String
End Interface

Public Interface IStorable
    Function ToLine() As String
End Interface

Public Class Invoice
    Implements IDescribable, IStorable

    Public Property Title As String
    Public Property Amount As Decimal

    Public Function Describe() As String Implements IDescribable.Describe
        Return $"invoice: {Title}"
    End Function

    Public Function ToLine() As String Implements IStorable.ToLine
        Return $"{Title},{Amount:F2}"
    End Function
End Class

Module Program
    Sub Main()
        Dim bill As New Invoice() With {.Title = "rent", .Amount = 1200D}
        Dim described As IDescribable = bill
        Dim stored As IStorable = bill

        Console.WriteLine($"as IDescribable : {described.Describe()}")
        Console.WriteLine($"as IStorable    : {stored.ToLine()}")
        Console.WriteLine($"same object     : {described Is stored}")
    End Sub
End Module
