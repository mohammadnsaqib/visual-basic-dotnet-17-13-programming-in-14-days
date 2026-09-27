' Four attempts to build an entry, three of which are not entries.
Imports System
Imports Tally

Module Program
    Sub Attempt(caption As String, make As Func(Of Entry))
        Try
            Dim made = make()
            Console.WriteLine($"{caption,-22}: {made}")
        Catch ex As LedgerError
            Console.WriteLine($"{caption,-22}: refused, {ex.Message}")
        End Try
    End Sub

    Sub Main()
        Attempt("balanced", Function() New Entry("rent",
                                                 New Credit("AC-1000", 1200D),
                                                 New Debit("AC-1001", 1200D)))
        Attempt("out by 100", Function() New Entry("rent",
                                                   New Credit("AC-1000", 1200D),
                                                   New Debit("AC-1001", 1100D)))
        Attempt("one posting", Function() New Entry("rent", New Credit("AC-1000", 10D)))
        Attempt("no memo", Function() New Entry("  ",
                                                New Credit("AC-1000", 10D),
                                                New Debit("AC-1001", 10D)))
        Console.WriteLine("an unbalanced entry cannot exist, so no caller has to " &
                          "check for one")
    End Sub
End Module
