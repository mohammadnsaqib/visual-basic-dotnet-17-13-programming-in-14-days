' Several constructors, and one of them doing the work for the others.
Imports System

Public Class Entry
    Public ReadOnly Property Account As String
    Public ReadOnly Property Amount As Decimal
    Public ReadOnly Property Note As String

    Public Sub New(account As String, amount As Decimal)
        Me.New(account, amount, "")
    End Sub

    Public Sub New(account As String, amount As Decimal, note As String)
        _Account = account
        _Amount = amount
        _Note = note
    End Sub
End Class

Module Program
    Sub Main()
        Dim plain As New Entry("AC-1001", 1200D)
        Dim noted As New Entry("AC-1001", 1200D, "September")
        Console.WriteLine($"plain note : [{plain.Note}]")
        Console.WriteLine($"noted note : [{noted.Note}]")
        Console.WriteLine("the two-argument constructor called the three-argument one")
    End Sub
End Module
