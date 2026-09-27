' Is asks whether two names refer to one object; Equals asks the type.
Imports System

Public Class Ledger
    Public Property Entries As Integer
End Class

Module Program
    Sub Main()
        Dim a As New Ledger() With {.Entries = 3}
        Dim b As New Ledger() With {.Entries = 3}
        Dim c = a

        Console.WriteLine($"a Is b        : {a Is b}")
        Console.WriteLine($"a Is c        : {a Is c}")
        Console.WriteLine($"a.Equals(b)   : {a.Equals(b)}")
        Console.WriteLine($"same contents : {a.Entries = b.Entries}")
        Console.WriteLine("two objects holding the same number are still two objects")
    End Sub
End Module
