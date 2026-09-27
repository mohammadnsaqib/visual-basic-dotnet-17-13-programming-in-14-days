' A read-only property lets the class decide when the value changes.
Imports System

Public Class Ledger
    Private _entries As Integer

    Public ReadOnly Property Entries As Integer
        Get
            Return _entries
        End Get
    End Property

    Public Sub Add()
        _entries += 1
    End Sub
End Class

Module Program
    Sub Main()
        Dim book As New Ledger()
        Console.WriteLine($"start : {book.Entries}")
        book.Add()
        book.Add()
        Console.WriteLine($"after two calls to Add : {book.Entries}")
        Console.WriteLine("the only way the count moves is through Add")
    End Sub
End Module
