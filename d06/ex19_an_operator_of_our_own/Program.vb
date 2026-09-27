' Money defines the operators, so money can be added, compared and sorted like a number.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim rent As New Money(1200D)
        Dim tax As New Money(87.5D)

        Console.WriteLine($"rent       : {rent}")
        Console.WriteLine($"tax        : {tax}")
        Console.WriteLine($"rent + tax : {rent + tax}")
        Console.WriteLine($"rent - tax : {rent - tax}")
        Console.WriteLine($"negated    : {-tax}")
        Console.WriteLine($"rent = tax : {rent = tax}")
        Console.WriteLine($"rent > tax : {rent > tax}")
        Console.WriteLine($"rent = 1200: {rent = New Money(1200D)}")

        Dim amounts = New Money() {New Money(30D), New Money(-5D), New Money(12.5D)}
        Array.Sort(amounts)
        Console.WriteLine($"sorted     : {String.Join(", ", amounts)}")

        Dim total = Money.Zero
        For Each amount In amounts
            total = total + amount
        Next
        Console.WriteLine($"total      : {total}")
        Console.WriteLine($"rounding   : {New Money(0.125D)} and {New Money(0.135D)}")
    End Sub
End Module
