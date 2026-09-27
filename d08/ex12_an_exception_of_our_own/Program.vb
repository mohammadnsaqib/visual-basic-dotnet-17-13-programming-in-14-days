' The library's own failure type, and the entry it refuses.
Imports System
Imports Tally

Module Program
    Sub Try_(caption As String, books As Ledger, entry As Posting())
        Console.WriteLine(caption)
        Try
            books.PostEntry(entry)
            Console.WriteLine($"  applied, balance {books.Balance:N2}")
        Catch ex As LedgerError
            Console.WriteLine($"  refused : {ex.Message}")
            Console.WriteLine($"  account : {If(ex.Account, "the entry itself")}")
        End Try
    End Sub

    Sub Main()
        Dim books As New Ledger()
        books.Open("AC-1000", "Cash")
        books.Open("AC-1001", "Rent")

        Try_("balanced:", books, New Posting() {New Credit("AC-1000", 1200D),
                                                New Debit("AC-1001", 1200D)})
        Try_("out by 100:", books, New Posting() {New Credit("AC-1000", 1200D),
                                                  New Debit("AC-1001", 1100D)})
        Try_("account not open:", books, New Posting() {New Credit("AC-9999", 10D),
                                                        New Debit("AC-1001", 10D)})

        Console.WriteLine($"postings recorded : {books.Postings.Count}")
        Console.WriteLine($"balance           : {books.Balance:N2}")
        Console.WriteLine($"a LedgerError is an : {GetType(LedgerError).BaseType.Name}")
    End Sub
End Module
