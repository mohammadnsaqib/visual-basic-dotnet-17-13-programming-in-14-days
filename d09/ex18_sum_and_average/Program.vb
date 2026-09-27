' The reductions: one sequence in, one value out.
Imports System
Imports System.Collections.Generic
Imports System.Linq

Module Program
    Sub Main()
        Dim amounts As New List(Of Decimal)() From {1200D, 87.5D, 450D, 900D, 1200D}

        Console.WriteLine($"count   : {amounts.Count}")
        Console.WriteLine($"sum     : {amounts.Sum():N2}")
        Console.WriteLine($"average : {amounts.Average():N2}")
        Console.WriteLine($"largest : {amounts.Max():N2}")
        Console.WriteLine($"smallest: {amounts.Min():N2}")

        ' A List(Of T) has its own Count PROPERTY, and it hides LINQ's Count method on
        ' this receiver. Where first, then Count, asks the same question and compiles.
        Dim over500 = amounts.Where(Function(amount) amount >= 500D).Count()
        Console.WriteLine($"at least 500 : {over500}")

        Dim asQuery = Aggregate amount In amounts Into Sum(amount), Average(amount)
        Console.WriteLine($"the Aggregate query gives {asQuery.Sum:N2} and " &
                          $"{asQuery.Average:N2}")

        Dim empty As New List(Of Decimal)()
        Console.WriteLine($"sum of nothing : {empty.Sum():N2}")
        Try
            Console.WriteLine(empty.Average())
        Catch ex As InvalidOperationException
            Console.WriteLine($"average of nothing : {ex.GetType().Name}")
        End Try
    End Sub
End Module
