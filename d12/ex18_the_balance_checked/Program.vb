' The assertions the test project makes about a balanced entry, run here so they can be
' seen.
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Tally

Module Program
    Sub Main()
        Dim books As New Ledger()
        books.Open("AC-1000", "Cash")
        books.Open("AC-4000", "Sales")

        books.PostEntry(New Debit("AC-1000", 1200D), New Credit("AC-4000", 1200D))

        Assert.AreEqual(0D, books.Balance)
        Assert.AreEqual(1200D, books.Find("AC-1000").Balance)
        Assert.AreEqual(-1200D, books.Find("AC-4000").Balance)
        Assert.HasCount(2, books.Postings)

        Console.WriteLine("four assertions, none of which failed")
        Console.WriteLine($"balance   : {books.Balance:N2}")
        Console.WriteLine($"cash      : {books.Find("AC-1000").Balance:N2}")
        Console.WriteLine($"sales     : {books.Find("AC-4000").Balance:N2}")
        Console.WriteLine($"postings  : {books.Postings.Count}")
    End Sub
End Module
