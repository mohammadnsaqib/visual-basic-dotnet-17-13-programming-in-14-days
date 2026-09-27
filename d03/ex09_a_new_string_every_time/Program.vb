' Every String method that seems to change a string returns a different one.
Imports System

Module Program
    Sub Main()
        Dim original As String = "  ledger  "
        Dim trimmed = original.Trim()
        Dim upper = original.ToUpperInvariant()
        Dim replaced = original.Replace("ledger", "journal")

        Console.WriteLine($"original : [{original}]")
        Console.WriteLine($"trimmed  : [{trimmed}]")
        Console.WriteLine($"upper    : [{upper}]")
        Console.WriteLine($"replaced : [{replaced}]")
        Console.WriteLine($"original is unchanged: [{original}]")
        Console.WriteLine($"same object as trimmed: {original Is trimmed}")
    End Sub
End Module
