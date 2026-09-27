' The library's ledger: a dictionary of accounts, a list of postings, and an iterator
' over the accounts.
Imports System
Imports System.Collections.Generic
Imports Tally

Module Program
    Sub Main()
        Dim books As New Ledger()
        books.Open("AC-1000", "Cash")
        books.Open("AC-1001", "Rent")
        books.Open("AC-3000", "Capital")

        books.Apply(New Debit("AC-1000", 5000D))
        books.Apply(New Credit("AC-3000", 5000D))
        books.Apply(New Credit("AC-1000", 1200D))
        books.Apply(New Debit("AC-1001", 1200D))

        Console.WriteLine($"accounts : {books.Count}")
        Console.WriteLine($"postings : {books.Postings.Count}")
        For Each account In books
            Console.WriteLine($"  {account}")
        Next
        Console.WriteLine($"balance  : {books.Balance:N2}")
        Console.WriteLine($"found    : {books.Find("ac-1001")}")
        Console.WriteLine($"missing  : " &
                          $"{If(books.Find("AC-9999") Is Nothing, "Nothing", "found")}")

        Try
            books.Open("AC-1000", "Cash again")
        Catch ex As ArgumentException
            Console.WriteLine($"a second AC-1000 : {ex.GetType().Name}")
        End Try
    End Sub
End Module
