' The requirement, and the type that carries each line of it. Every name is checked.
Imports System
Imports System.Linq
Imports Tally

Module Program
    Sub Main()
        Dim rules = New String(,) {
            {"an account has a code, a name and a balance", "Account"},
            {"an amount is exact to the penny", "Money"},
            {"a posting is a debit or a credit", "Posting"},
            {"an entry is a set of postings adding to zero", "Entry"},
            {"a ledger holds accounts and the postings applied", "Ledger"},
            {"the books can be saved and loaded", "Store"},
            {"a report is a title and its lines", "IReport"},
            {"a failure in the books is not a failure in the program", "LedgerError"}}

        Dim built = GetType(Ledger).Assembly.GetTypes()
        Dim types = built.Select(Function(t) t.Name).ToHashSet()
        Dim missing As Integer = 0

        For row = 0 To rules.GetLength(0) - 1
            Dim found = types.Contains(rules(row, 1))
            If Not found Then
                missing += 1
            End If
            Console.WriteLine($"  {rules(row, 1),-12} " &
                              $"{If(found, "present", "MISSING")}  " &
                              $"{rules(row, 0)}")
        Next

        Console.WriteLine($"rules   : {rules.GetLength(0)}")
        Console.WriteLine($"missing : {missing}")
    End Sub
End Module
