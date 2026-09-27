' Assigning an object copies the reference. Two names, one object.
Imports System

Public Class Ledger
    Public Property Entries As Integer
End Class

Module Program
    Sub Main()
        Dim first As New Ledger() With {.Entries = 3}
        Dim second = first
        second.Entries = 10

        Console.WriteLine($"first.Entries  : {first.Entries}")
        Console.WriteLine($"second.Entries : {second.Entries}")
        Console.WriteLine($"same object    : {first Is second}")
    End Sub
End Module
