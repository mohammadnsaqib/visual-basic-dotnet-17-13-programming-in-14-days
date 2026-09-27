' A property need not store anything; it can work the answer out each time.
Imports System

Public Class Ledger
    Public Property Debits As Decimal
    Public Property Credits As Decimal

    Public ReadOnly Property Balance As Decimal
        Get
            Return Debits - Credits
        End Get
    End Property

    Public ReadOnly Property IsBalanced As Boolean
        Get
            Return Balance = 0D
        End Get
    End Property
End Class

Module Program
    Sub Main()
        Dim book As New Ledger() With {.Debits = 1200D, .Credits = 1200D}
        Console.WriteLine($"debits {book.Debits}, credits {book.Credits}")
        Console.WriteLine($"balance    : {book.Balance}")
        Console.WriteLine($"is balanced: {book.IsBalanced}")
        book.Credits = 900D
        Console.WriteLine($"after changing credits to 900:")
        Console.WriteLine($"balance    : {book.Balance}")
        Console.WriteLine($"is balanced: {book.IsBalanced}")
    End Sub
End Module
