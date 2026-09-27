' Every failure this program can have, and the sentence it answers with.
Imports System
Imports System.IO
Imports Tally

Module Program
    Sub Main()
        Dim shell As New Shell(New Ledger())
        shell.Run("open AC-1000 Cash")
        shell.Run("open AC-4000 Sales")

        Dim lines = New String() {"dance",
                                  "open AC-1000 Cash",
                                  "open",
                                  "post rent; credit AC-1000 1200; debit AC-4000 1100",
                                  "post rent; credit AC-9999 10; debit AC-1000 10",
                                  "post rent; credit AC-1000 lots; debit AC-4000 10",
                                  "statement AC-9999",
                                  "load nowhere.json"}

        Dim refused As Integer = 0
        For Each line In lines
            Dim said = shell.Run(line)
            If said.StartsWith("error:") Then
                refused += 1
            End If
            Console.WriteLine($"  {line,-52} {said}")
        Next
        Console.WriteLine($"lines refused : {refused} of {lines.Length}")
        Console.WriteLine($"books unchanged : {shell.Books.Postings.Count} posting(s)")
    End Sub
End Module
