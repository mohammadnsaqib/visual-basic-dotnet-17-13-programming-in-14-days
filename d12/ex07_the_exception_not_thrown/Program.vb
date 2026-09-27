' The same assertion where nothing goes wrong. Not failing is a failure here.
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Tally

Module Program
    Sub Main()
        Dim books As New Ledger()
        books.Open("AC-1000", "Cash")
        books.Open("AC-4000", "Sales")

        Try
            Assert.ThrowsExactly(Of LedgerError)(
                Sub() books.PostEntry(New Debit("AC-1000", 1200D),
                                      New Credit("AC-4000", 1200D)))
            Console.WriteLine("never printed")
        Catch ex As AssertFailedException
            Console.WriteLine($"failed  : {ex.Message}")
        End Try

        Try
            Assert.ThrowsExactly(Of InvalidOperationException)(
                Sub() books.Open("AC-1000", "Cash again"))
        Catch ex As AssertFailedException
            Console.WriteLine($"and also: {ex.Message}")
        End Try
        Console.WriteLine($"postings applied : {books.Postings.Count}")
    End Sub
End Module
