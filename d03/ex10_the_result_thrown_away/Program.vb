' Calling a String method and ignoring its result changes nothing at all.
Imports System

Module Program
    Sub Main()
        Dim text As String = "  ledger  "
        text.Trim()
        Console.WriteLine($"after calling Trim and keeping nothing: [{text}]")
        text = text.Trim()
        Console.WriteLine($"after assigning the result            : [{text}]")
    End Sub
End Module
