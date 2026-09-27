' The library's reports, both written as queries, and the same answer by hand.
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports Tally

Module Program
    Sub Print(report As IReport)
        Console.WriteLine(report.Title)
        For Each line In report.Lines()
            Console.WriteLine($"  {line}")
        Next
    End Sub

    Sub Main()
        Dim books As New Ledger()
        books.Open("AC-1000", "Cash")
        books.Open("AC-1001", "Rent")
        books.Open("AC-4000", "Sales")
        books.Open("AC-5000", "Wages")

        books.PostEntry(New Debit("AC-1000", 5000D), New Credit("AC-4000", 5000D))
        books.PostEntry(New Credit("AC-1000", 1200D), New Debit("AC-1001", 1200D))
        books.PostEntry(New Credit("AC-1000", 87.5D), New Debit("AC-1001", 87.5D))

        Print(New TrialBalance(books))
        Print(New ByAccount(books))

        Dim byHand = From account In books
                     Where account.Balance <> 0D
                     Select account.Balance
        Console.WriteLine($"accounts with a balance : {byHand.Count()}")
        Console.WriteLine($"they add to             : {byHand.Sum():N2}")
        Console.WriteLine($"Wages was never posted to and is not in the trial balance")
    End Sub
End Module
