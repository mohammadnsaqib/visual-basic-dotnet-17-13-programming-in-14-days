' A constructor that cannot leave the object usable should not return one.
Imports System

Public Class Entry
    Public ReadOnly Property Account As String
    Public ReadOnly Property Amount As Decimal

    Public Sub New(account As String, amount As Decimal)
        If String.IsNullOrWhiteSpace(account) Then
            Throw New ArgumentException("an entry needs an account", NameOf(account))
        End If
        _Account = account
        _Amount = amount
    End Sub
End Class

Module Program
    Sub Main()
        Dim good As New Entry("AC-1001", 1200D)
        Console.WriteLine($"the good one : {good.Account}")
        Try
            Dim bad As New Entry("   ", 1200D)
            Console.WriteLine($"this line never runs: {bad.Amount}")
        Catch ex As ArgumentException
            Console.WriteLine($"refused      : {ex.GetType().Name}")
            Console.WriteLine($"the parameter: {ex.ParamName}")
        End Try
    End Sub
End Module
