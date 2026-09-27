' Join puts a separator between the parts, and only between them.
Imports System

Module Program
    Sub Main()
        Dim parts = {"2026-09-10", "rent", "1200.00"}
        Console.WriteLine($"comma  : {String.Join(",", parts)}")
        Console.WriteLine($"pipe   : {String.Join(" | ", parts)}")
        Console.WriteLine($"one    : {String.Join(",", New String() {"only"})}")
        Console.WriteLine($"none   : [{String.Join(",", New String() {})}]")
        Console.WriteLine($"a round trip : " &
                          $"{String.Join(",", parts).Split(","c).Length} fields")
    End Sub
End Module
