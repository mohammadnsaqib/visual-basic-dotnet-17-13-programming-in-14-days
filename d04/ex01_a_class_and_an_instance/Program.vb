' A class is a description; New makes one thing that matches it.
Imports System

Public Class Ledger
    Public Name As String
    Public Entries As Integer
End Class

Module Program
    Sub Main()
        Dim book As New Ledger()
        book.Name = "general"
        book.Entries = 3

        Console.WriteLine($"the class    : {NameOf(Ledger)}")
        Console.WriteLine($"the instance : {book.Name} with {book.Entries} entries")
        Console.WriteLine($"its type     : {book.GetType().Name}")
        Console.WriteLine($"is it a value type: {book.GetType().IsValueType}")
    End Sub
End Module
