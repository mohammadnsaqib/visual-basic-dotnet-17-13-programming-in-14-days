' ToList reads the query once and keeps the answer.
Imports System
Imports System.Collections.Generic
Imports System.Linq

Module Program
    Sub Main()
        Dim amounts As New List(Of Decimal)() From {120D, 1200D}
        Dim live = From amount In amounts Where amount >= 100D Select amount
        Dim frozen = live.ToList()

        Console.WriteLine($"live   : {String.Join(", ", live)}")
        Console.WriteLine($"frozen : {String.Join(", ", frozen)}")

        amounts.Add(450D)
        Console.WriteLine($"live   : {String.Join(", ", live)}")
        Console.WriteLine($"frozen : {String.Join(", ", frozen)}")
        Console.WriteLine($"frozen is a {frozen.GetType().Name}, and live is still a " &
                          $"query")
    End Sub
End Module
