' A ledger with one line changed, and the assertion that notices.
Imports System
Imports System.Collections.Generic
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

    ''' <summary>Applies as it checks, which is the bug.</summary>
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

        Dim failure = Assert.ThrowsExactly(Of LedgerError)(
            Sub() hasty.PostEntry(New Debit("AC-1000", 1200D),
                                  New Credit("AC-4000", 1100D)))
        Console.WriteLine($"it still refuses : {failure.Message}")

        Try
            Assert.AreEqual(0, hasty.Postings)
            Console.WriteLine("never printed")
        Catch ex As AssertFailedException
            Console.WriteLine($"the second assertion : {ex.Message}")
        End Try
        Console.WriteLine($"postings left behind : {hasty.Postings}")
        Console.WriteLine($"balance left behind  : {hasty.Balance:N2}")
    End Sub
End Module
