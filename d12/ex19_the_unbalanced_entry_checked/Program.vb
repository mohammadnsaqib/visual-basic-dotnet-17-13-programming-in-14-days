' The refusal, and the three things that have to be true after it.
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

        StringAssert.Contains(failure.Message, "out by")
        Assert.IsEmpty(books.Postings)
        Assert.AreEqual(0D, books.Find("AC-1000").Balance)

        Console.WriteLine($"message   : {failure.Message}")
        Console.WriteLine($"postings  : {books.Postings.Count}")
        Console.WriteLine($"cash      : {books.Find("AC-1000").Balance:N2}")
        Console.WriteLine("the refusal is not enough; nothing may have been applied " &
                          "either")
    End Sub
End Module
