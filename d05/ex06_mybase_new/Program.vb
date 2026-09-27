' A derived constructor runs the base one first, whether or not it says so.
Imports System

Public Class Document
    Public ReadOnly Property Title As String
    Public Sub New(title As String)
        Console.WriteLine("  Document's constructor ran")
        _Title = title
    End Sub
End Class

Public Class Invoice
    Inherits Document

    Public ReadOnly Property Amount As Decimal
    Public Sub New(title As String, amount As Decimal)
        MyBase.New(title)
        Console.WriteLine("  Invoice's constructor ran")
        _Amount = amount
    End Sub
End Class

Module Program
    Sub Main()
        Console.WriteLine("making an Invoice:")
        Dim bill As New Invoice("September rent", 1200D)
        Console.WriteLine($"Title  : {bill.Title}")
        Console.WriteLine($"Amount : {bill.Amount:N2}")
    End Sub
End Module
