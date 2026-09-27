' A ledger with a thousand entries, and the cost of reporting on it.
Imports System
Imports System.Diagnostics
Imports System.Linq
Imports Tally

Module Program
    Sub Main()
        Const entries As Integer = 1000
        Dim books As New Ledger()
        For i = 1 To 20
            books.Open($"AC-{i:D4}", $"Account {i}")
        Next

        Dim building = Stopwatch.StartNew()
        For i = 1 To entries
            Dim from_ = $"AC-{(i Mod 20) + 1:D4}"
            Dim toward = $"AC-{((i + 7) Mod 20) + 1:D4}"
            Dim amount = 10D + (i Mod 13)
            books.PostEntry(New Credit(from_, amount), New Debit(toward, amount))
        Next
        building.Stop()

        ' One report before the measurement, so the timing is of the work rather than of
        ' the compiling. Day 12 measured how much that first run costs.
        Dim warming = New TrialBalance(books).Lines().ToList()

        Dim clock = Stopwatch.StartNew()
        Dim report = New TrialBalance(books)
        Dim lines = report.Lines().ToList()
        clock.Stop()

        Console.WriteLine($"accounts : {books.Count}")
        Console.WriteLine($"postings : {books.Postings.Count}")
        Console.WriteLine($"building : {building.Elapsed.TotalMilliseconds:F1} ms")
        Console.WriteLine($"report   : {clock.Elapsed.TotalMilliseconds:F1} ms, " &
                          $"{lines.Count} line(s)")
        Console.WriteLine($"balance  : {books.Balance:N2}")
        Console.WriteLine($"the warming run gave the same {warming.Count} line(s)")
    End Sub
End Module
