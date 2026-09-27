' RemoveEmptyEntries drops the empty fields, which is not always what is wanted.
Imports System

Module Program
    Sub Main()
        Dim row As String = "2026-09-10,,rent,,1200.00"
        Dim kept = row.Split(","c, StringSplitOptions.RemoveEmptyEntries)
        Console.WriteLine($"fields kept : {kept.Length}")
        Console.WriteLine($"  {String.Join(" | ", kept)}")
        Console.WriteLine("the amount is now field 2, and in the full split it was " &
                          "field 4")
        Dim all = row.Split(","c)
        Console.WriteLine($"  full split field 4 : [{all(4)}]")
        Console.WriteLine($"  kept split field 2 : [{kept(2)}]")
    End Sub
End Module
