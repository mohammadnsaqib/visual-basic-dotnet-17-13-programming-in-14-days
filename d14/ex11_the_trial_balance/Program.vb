' The report a bookkeeper looks at first.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim shell As New Shell(New Ledger())
        shell.Run("open AC-1000 Cash")
        shell.Run("open AC-1001 Rent")
        shell.Run("open AC-4000 Sales")
        shell.Run("open AC-5000 Wages")
        shell.Run("post opening; debit AC-1000 5000; credit AC-4000 5000")
        shell.Run("post rent; credit AC-1000 1200; debit AC-1001 1200")
        shell.Run("post rent; credit AC-1000 87.50; debit AC-1001 87.50")

        Console.WriteLine("> balance")
        Console.WriteLine(shell.Run("balance"))
        Console.WriteLine($"accounts open : {shell.Books.Count}")
        Console.WriteLine("Wages was opened and never posted to, so it has no line")
    End Sub
End Module
