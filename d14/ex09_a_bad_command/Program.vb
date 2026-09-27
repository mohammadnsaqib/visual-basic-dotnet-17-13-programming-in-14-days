' Six lines that are not commands, and what each of them is told.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim shell As New Shell(New Ledger())
        shell.Run("open AC-1000 Cash")

        For Each line In New String() {"opne AC-1001 Rent",
                                       "open AC-1001",
                                       "open AC-1001 Rent lots",
                                       "post rent; credit AC-1000 1200",
            "post rent; sideways AC-1000 10; debit AC-1000 10",
                                       "statement AC-9999"}
            Console.WriteLine($"> {line}")
            Console.WriteLine($"  {shell.Run(line)}")
        Next
        Console.WriteLine($"accounts after all that : {shell.Books.Count}")
    End Sub
End Module
