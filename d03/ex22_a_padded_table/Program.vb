' Padding and alignment make a table, and the widths are decided once.
Imports System

Module Program
    Sub Main()
        Dim rows = {("rent", 1200D), ("electricity", 84.5D), ("tea", 3.75D)}
        Dim width As Integer = 0
        For Each row In rows
            If row.Item1.Length > width Then width = row.Item1.Length
        Next

        Console.WriteLine($"{"account".PadRight(width)}  {"amount",10}")
        Console.WriteLine(New String("-"c, width + 12))
        For Each row In rows
            Console.WriteLine($"{row.Item1.PadRight(width)}  {row.Item2,10:N2}")
        Next
        Console.WriteLine($"the widest account name is {width} characters")
    End Sub
End Module
