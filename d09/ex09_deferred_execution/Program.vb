' A query runs when it is read. This one says so as it goes.
Imports System
Imports System.Collections.Generic
Imports System.Linq

Module Program
    Sub Main()
        Dim amounts As New List(Of Decimal)() From {120D, 1200D, 87.5D}

        Console.WriteLine("building the query")
        Dim large = amounts.Where(Function(amount)
                                      Console.WriteLine($"    testing {amount:N2}")
                                      Return amount >= 100D
                                  End Function)
        Console.WriteLine("the query is built, and nothing has been tested")

        Console.WriteLine("reading the first item")
        Console.WriteLine($"  first : {large.First():N2}")

        Console.WriteLine("reading all of them")
        Console.WriteLine($"  count : {large.Count()}")
    End Sub
End Module
