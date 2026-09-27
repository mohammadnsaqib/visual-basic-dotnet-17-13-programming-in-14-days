' One line of typing, taken apart and carried out.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim shell As New Shell(New Ledger())

        For Each line In New String() {"open AC-1000 Cash 250",
                                       "open AC-1001 Rent",
            "post rent; credit AC-1000 1200; debit AC-1001 1200",
                                       "statement AC-1000"}
            Console.WriteLine($"> {line}")
            Console.WriteLine(shell.Run(line))
        Next
        Console.WriteLine($"accounts : {shell.Books.Count}")
        Console.WriteLine($"postings : {shell.Books.Postings.Count}")
    End Sub
End Module
