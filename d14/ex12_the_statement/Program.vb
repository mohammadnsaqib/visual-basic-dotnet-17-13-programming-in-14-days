' One account, and everything that happened to it.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim shell As New Shell(New Ledger())
        shell.Run("open AC-1000 Cash")
        shell.Run("open AC-1001 Rent")
        shell.Run("open AC-4000 Sales")
        shell.Run("post opening; debit AC-1000 5000; credit AC-4000 5000")
        shell.Run("post rent; credit AC-1000 1200; debit AC-1001 1200")
        shell.Run("post wages; credit AC-1000 900; debit AC-1001 900")

        Console.WriteLine("> statement AC-1000")
        Console.WriteLine(shell.Run("statement AC-1000"))
        Console.WriteLine("> statement ac-1001")
        Console.WriteLine(shell.Run("statement ac-1001"))
    End Sub
End Module
