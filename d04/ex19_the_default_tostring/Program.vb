' Every type has a ToString, and the one it starts with says only what it is.
Imports System

Public Class Ledger
    Public Property Name As String
End Class

Module Program
    Sub Main()
        Dim book As New Ledger() With {.Name = "general"}
        Console.WriteLine($"ToString  : {book.ToString()}")
        Console.WriteLine($"in a hole : {book}")
        Console.WriteLine($"the name is nowhere in either of those")
        Console.WriteLine($"an Integer's ToString is more useful: {42.ToString()}")
    End Sub
End Module
