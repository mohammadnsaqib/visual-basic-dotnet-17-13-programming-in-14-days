' The rule the whole program exists to keep, refused at three different depths.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim books As New Ledger()
        books.Open("AC-1000", "Cash")
        books.Open("AC-4000", "Sales")

        Try
            Dim bad As New Entry("out", New Credit("AC-1000", 1200D),
                                 New Debit("AC-4000", 1100D))
            Console.WriteLine(bad)
        Catch ex As LedgerError
            Console.WriteLine($"the type refused  : {ex.Message}")
        End Try

        Try
            books.PostEntry(New Credit("AC-1000", 1200D), New Debit("AC-4000", 1100D))
        Catch ex As LedgerError
            Console.WriteLine($"the ledger refused: {ex.Message}")
        End Try

        Dim shell As New Shell(books)
        Console.WriteLine($"the shell refused : " &
            shell.Run("post out; credit AC-1000 1200; debit AC-4000 1100"))

        Console.WriteLine($"postings recorded : {books.Postings.Count}")
        Console.WriteLine($"balance           : {books.Balance:N2}")
    End Sub
End Module
