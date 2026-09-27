' Overriding ToString changes what every printing of the object says.
Imports System

Public Class Ledger
    Public Property Name As String
    Public Property Entries As Integer

    Public Overrides Function ToString() As String
        Return $"{Name} ({Entries} entries)"
    End Function
End Class

Module Program
    Sub Main()
        Dim book As New Ledger() With {.Name = "general", .Entries = 3}
        Console.WriteLine($"ToString  : {book.ToString()}")
        Console.WriteLine($"in a hole : {book}")
        Dim pair = New Ledger() {book, book}
        Console.WriteLine($"in a Join : {String.Join(" and ", CType(pair, Object()))}")
    End Sub
End Module
