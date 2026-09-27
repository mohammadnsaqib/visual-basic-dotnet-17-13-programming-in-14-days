' The query names the list, not the items that were in it.
Imports System
Imports System.Collections.Generic
Imports System.Linq

Module Program
    Sub Main()
        Dim amounts As New List(Of Decimal)() From {120D, 1200D}
        Dim large = From amount In amounts Where amount >= 100D Select amount

        Console.WriteLine($"before : {String.Join(", ", large)}")
        amounts.Add(450D)
        amounts.Add(5D)
        Console.WriteLine($"after  : {String.Join(", ", large)}")
        Console.WriteLine($"the list now holds {amounts.Count} amounts")
        Console.WriteLine("the query was not re-written, and its answer changed")
    End Sub
End Module
