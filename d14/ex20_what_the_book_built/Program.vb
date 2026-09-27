' Every type the fourteen days added, and the day it arrived.
Imports System
Imports System.Linq
Imports Tally

Module Program
    Sub Main()
        Dim arrivals = New String(,) {
            {"4", "Account"}, {"5", "Posting"}, {"5", "Debit"}, {"5", "Credit"},
            {"5", "IReport"}, {"6", "Money"}, {"6", "AccountKind"},
                {"6", "ReportParts"},
            {"7", "Ledger"}, {"8", "LedgerError"}, {"9", "TrialBalance"},
                {"9", "ByAccount"},
            {"10", "Store"}, {"11", "AsyncStore"}, {"13", "PostingEventArgs"},
            {"13", "AuditLog"}, {"14", "Entry"}, {"14", "Shell"}}

        Dim built = GetType(Ledger).Assembly.GetTypes()
        Dim present = built.Select(Function(t) t.Name).ToHashSet()
        Dim missing As Integer = 0
        Dim day As String = ""

        For row = 0 To arrivals.GetLength(0) - 1
            If arrivals(row, 0) <> day Then
                day = arrivals(row, 0)
                Console.WriteLine($"  day {day}")
            End If
            Dim there = present.Contains(arrivals(row, 1))
            If Not there Then
                missing += 1
            End If
            Console.WriteLine($"    {arrivals(row, 1),-18} " &
                              $"{If(there, "present", "MISSING")}")
        Next

        Console.WriteLine($"types listed : {arrivals.GetLength(0)}")
        Console.WriteLine($"missing      : {missing}")
    End Sub
End Module
