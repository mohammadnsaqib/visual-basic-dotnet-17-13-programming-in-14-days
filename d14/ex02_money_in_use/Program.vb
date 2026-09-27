' The amount type, doing the one job it exists for.
Imports System
Imports System.Linq
Imports Tally

Module Program
    Sub Main()
        Dim amounts = New Money() {New Money(1200D), New Money(87.5D),
                                   New Money(0.125D)}

        Console.WriteLine($"amounts : {String.Join(", ", amounts)}")
        Console.WriteLine($"total   : " &
                          $"{amounts.Aggregate(Money.Zero, Function(a, b) a + b)}")
        Console.WriteLine($"largest : {amounts.Max()}")
        Console.WriteLine($"equal   : {New Money(87.5D) = amounts(1)}")
        Console.WriteLine($"rounded : {New Money(0.125D)} and {New Money(0.135D)}")
        Console.WriteLine($"a value : {GetType(Money).IsValueType}")
    End Sub
End Module
