' A constructor takes what the object needs to exist.
Imports System

Public Class Entry
    Public ReadOnly Property Account As String
    Public ReadOnly Property Amount As Decimal

    Public Sub New(account As String, amount As Decimal)
        _Account = account
        _Amount = amount
    End Sub
End Class

Module Program
    Sub Main()
        Dim rent As New Entry("AC-1001", 1200D)
        Console.WriteLine($"account : {rent.Account}")
        Console.WriteLine($"amount  : {rent.Amount:N2}")
        Console.WriteLine("both were set before any other code could see the object")
    End Sub
End Module
