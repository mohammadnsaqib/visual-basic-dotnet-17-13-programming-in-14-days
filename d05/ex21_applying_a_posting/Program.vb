' ApplyTo is written once, in the class that cannot be made.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim cash As New Account("AC-1000", "Cash", 0D)
        Dim rent As New Account("AC-1001", "Rent", 0D)

        Dim postings As Posting() = {New Credit("AC-1000", 1200D),
                                     New Debit("AC-1001", 1200D)}
        postings(0).ApplyTo(cash)
        postings(1).ApplyTo(rent)

        Console.WriteLine($"  {cash}")
        Console.WriteLine($"  {rent}")
        Console.WriteLine($"the two balances add to {cash.Balance + rent.Balance:N2}")
        Console.WriteLine("ApplyTo asked the posting for its sign and did nothing else")
    End Sub
End Module
