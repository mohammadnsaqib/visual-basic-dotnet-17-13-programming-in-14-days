' Reading a query twice runs it twice. The count says how many times.
Imports System
Imports System.Collections.Generic
Imports System.Linq

Module Program
    Sub Main()
        Dim amounts As New List(Of Decimal)() From {120D, 1200D, 87.5D, 900D}
        Dim tested As Integer = 0

        Dim large = amounts.Where(Function(amount)
                                      tested += 1
                                      Return amount >= 100D
                                  End Function)

        Console.WriteLine($"after building        : {tested} test(s)")
        Console.WriteLine($"count is {large.Count()}, and tests are now {tested}")
        Console.WriteLine($"sum is {large.Sum():N2}, and tests are now {tested}")

        tested = 0
        Dim once = large.ToList()
        Console.WriteLine($"ToList then count and sum:")
        Console.WriteLine($"  count {once.Count}, sum {once.Sum():N2}, tests {tested}")
    End Sub
End Module
