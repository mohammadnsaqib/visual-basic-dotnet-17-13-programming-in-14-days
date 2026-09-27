' One class, two objects, and nothing shared between them.
Imports System

Public Class Ledger
    Public Name As String
    Public Entries As Integer
End Class

Module Program
    Sub Main()
        Dim first As New Ledger() With {.Name = "general", .Entries = 3}
        Dim second As New Ledger() With {.Name = "petty cash", .Entries = 11}

        Console.WriteLine($"first  : {first.Name}, {first.Entries}")
        Console.WriteLine($"second : {second.Name}, {second.Entries}")
        first.Entries += 1
        Console.WriteLine($"after changing the first:")
        Console.WriteLine($"first  : {first.Entries}")
        Console.WriteLine($"second : {second.Entries}")
        Console.WriteLine($"same object: {first Is second}")
    End Sub
End Module
