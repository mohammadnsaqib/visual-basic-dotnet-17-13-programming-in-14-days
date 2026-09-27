' Private means the class keeps it, and the compiler enforces that.
Imports System

Public Class Ledger
    Private _entries As Integer

    Public ReadOnly Property Entries As Integer
        Get
            Return _entries
        End Get
    End Property
End Class

Module Program
    Sub Main()
        Dim book As New Ledger()
        Console.WriteLine(book.Entries)
        book._entries = 99
    End Sub
End Module
