' An entry made, and what it knows about itself.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim rent As New Entry("September rent",
                              New Credit("AC-1000", 1200D),
                              New Debit("AC-1001", 1200D))

        Console.WriteLine($"memo     : {rent.Memo}")
        Console.WriteLine($"postings : {rent.Postings.Count}")
        For Each posting In rent.Postings
            Console.WriteLine($"  {posting}")
        Next
        Console.WriteLine($"net      : {rent.Net:N2}")
        Console.WriteLine($"as text  : {rent}")
    End Sub
End Module
