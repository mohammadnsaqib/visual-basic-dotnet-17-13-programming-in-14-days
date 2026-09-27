' An object initialiser runs after the constructor, not instead of it.
Imports System

Public Class Ledger
    Public Property Name As String
    Public Property Entries As Integer

    Public Sub New()
        Name = "unnamed"
        Entries = -1
        Console.WriteLine("  the constructor ran first")
    End Sub
End Class

Module Program
    Sub Main()
        Console.WriteLine("making one with an initialiser:")
        Dim book As New Ledger() With {.Name = "general", .Entries = 3}
        Console.WriteLine($"  Name    : {book.Name}")
        Console.WriteLine($"  Entries : {book.Entries}")
        Console.WriteLine("the initialiser overwrote what the constructor set")
    End Sub
End Module
