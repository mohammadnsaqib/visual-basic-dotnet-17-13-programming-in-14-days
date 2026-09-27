' Failure is behaviour. This asserts that the right failure happens, and reads what it
' said.
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Tally

Module Program
    Sub Main()
        Dim books As New Ledger()
        books.Open("AC-1000", "Cash")
        books.Open("AC-4000", "Sales")

        Dim failure = Assert.ThrowsExactly(Of LedgerError)(
            Sub() books.PostEntry(New Debit("AC-1000", 1200D),
                                  New Credit("AC-4000", 1100D)))
        Console.WriteLine($"type    : {failure.GetType().Name}")
        Console.WriteLine($"message : {failure.Message}")
        Console.WriteLine($"postings: {books.Postings.Count}")

        Dim second = Assert.ThrowsExactly(Of ArgumentException)(
            Sub() books.Open("AC-1000", "Cash again"))
        Console.WriteLine($"and     : {second.GetType().Name}")
        Console.WriteLine($"accounts: {books.Count}")
    End Sub
End Module
