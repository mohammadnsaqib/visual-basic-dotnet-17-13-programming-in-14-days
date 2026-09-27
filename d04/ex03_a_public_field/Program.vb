' A public field can be set to anything by anyone, at any time.
Imports System

Public Class Ledger
    Public Entries As Integer
End Class

Module Program
    Sub Main()
        Dim book As New Ledger()
        Console.WriteLine($"start   : {book.Entries}")
        book.Entries = 5
        Console.WriteLine($"set to 5: {book.Entries}")
        book.Entries = -20
        Console.WriteLine($"set to -20: {book.Entries}")
        Console.WriteLine("nothing in the class had a chance to object")
    End Sub
End Module
