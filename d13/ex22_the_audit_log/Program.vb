' The ledger raising an event on every posting, and the log that is built from it.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim books As New Ledger()
        books.Open("AC-1000", "Cash")
        books.Open("AC-1001", "Rent")
        books.Open("AC-4000", "Sales")

        books.PostEntry(New Debit("AC-1000", 5000D), New Credit("AC-4000", 5000D))
        Console.WriteLine("before the log existed, two postings were applied")

        Using log As New AuditLog(books)
            books.PostEntry(New Credit("AC-1000", 1200D), New Debit("AC-1001", 1200D))
            books.PostEntry(New Credit("AC-1000", 87.5D), New Debit("AC-1001", 87.5D))
            Console.WriteLine($"lines recorded : {log.Lines.Count}")
            For Each line In log.Lines
                Console.WriteLine($"  {line}")
            Next
        End Using

        books.PostEntry(New Credit("AC-1000", 10D), New Debit("AC-1001", 10D))
        Console.WriteLine($"postings in all : {books.Postings.Count}")
        Console.WriteLine($"balance         : {books.Balance:N2}")
        Console.WriteLine("the ledger names no listener, and works with none")
    End Sub
End Module
