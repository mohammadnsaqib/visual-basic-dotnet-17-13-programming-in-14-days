' The same postings, asked a narrower question. The filter is a query and nothing else.
Imports System
Imports System.Linq
Imports Tally

Module Program
    Sub Main()
        Dim shell As New Shell(New Ledger())
        shell.Run("open AC-1000 Cash")
        shell.Run("open AC-1001 Rent")
        shell.Run("open AC-4000 Sales")
        shell.Run("post opening; debit AC-1000 5000; credit AC-4000 5000")
        shell.Run("post rent; credit AC-1000 1200; debit AC-1001 1200")
        shell.Run("post small; credit AC-1000 12.50; debit AC-1001 12.50")

        Dim large = From posting In shell.Books.Postings
                    Where posting.Amount >= 1000D
                    Order By posting.Amount Descending
                    Select posting

        Console.WriteLine($"postings in all : {shell.Books.Postings.Count}")
        Console.WriteLine($"at least 1000   : {large.Count()}")
        For Each posting In large
            Console.WriteLine($"  {posting}")
        Next
        Console.WriteLine($"they move       : {large.Sum(Function(p) p.Amount):N2}")
    End Sub
End Module
