' The two kinds of posting, and the one line that differs between them.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim postings As Posting() = {New Debit("AC-1001", 1200D),
                                     New Credit("AC-1000", 1200D)}
        For Each posting In postings
            Console.WriteLine($"  {posting}")
            Console.WriteLine($"    Signed : {posting.Signed:N2}")
        Next
        Console.WriteLine($"total signed : {postings(0).Signed + postings(1).Signed:N2}")
        Console.WriteLine($"both are Posting: {TypeOf postings(0) Is Posting}, " &
                          $"{TypeOf postings(1) Is Posting}")
    End Sub
End Module
