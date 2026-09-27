' A derived class starts with everything the base class has.
Imports System

Public Class Document
    Public Property Title As String
    Public Function Describe() As String
        Return $"document: {Title}"
    End Function
End Class

Public Class Invoice
    Inherits Document

    Public Property Amount As Decimal
End Class

Module Program
    Sub Main()
        Dim bill As New Invoice() With {.Title = "September rent", .Amount = 1200D}
        Console.WriteLine($"Title    : {bill.Title}")
        Console.WriteLine($"Amount   : {bill.Amount:N2}")
        Console.WriteLine($"Describe : {bill.Describe()}")
        Console.WriteLine($"Title and Describe were not written in Invoice")
    End Sub
End Module
