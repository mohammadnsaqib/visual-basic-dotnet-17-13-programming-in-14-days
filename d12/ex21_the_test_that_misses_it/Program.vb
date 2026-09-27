' The same bug, and a test that reports nothing at all.
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Tally

Public Class HastyLedger

    Private ReadOnly _books As New Ledger()

    Public ReadOnly Property Balance As Decimal
        Get
            Return _books.Balance
        End Get
    End Property

    Public ReadOnly Property Postings As Integer
        Get
            Return _books.Postings.Count
        End Get
    End Property

    Public Sub Open(code As String, name As String)
        _books.Open(code, name)
    End Sub

    Public Sub PostEntry(ParamArray entry As Posting())
        Dim net As Decimal = 0D
        For Each posting In entry
            _books.Apply(posting)
            net += posting.Signed
        Next
        If net <> 0D Then
            Throw New LedgerError($"the entry is out by {net:N2}")
        End If
    End Sub
End Class

Module Program
    Sub Main()
        Dim hasty As New HastyLedger()
        hasty.Open("AC-1000", "Cash")
        hasty.Open("AC-4000", "Sales")

        ' The whole of the weaker test: it checks that the refusal happened.
        Assert.ThrowsExactly(Of LedgerError)(
            Sub() hasty.PostEntry(New Debit("AC-1000", 1200D),
                                  New Credit("AC-4000", 1100D)))
        Console.WriteLine("the weaker test passed")

        Console.WriteLine($"and the books now hold {hasty.Postings} posting(s)")
        Console.WriteLine($"with a balance of {hasty.Balance:N2}")
        Console.WriteLine("a passing suite says the cases somebody thought of work")
    End Sub
End Module
