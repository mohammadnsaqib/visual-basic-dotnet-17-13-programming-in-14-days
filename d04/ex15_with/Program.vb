' With names an object once and then talks to it.
Imports System

Public Class Ledger
    Public Property Name As String
    Public Property Entries As Integer
    Public Sub Add()
        Entries += 1
    End Sub
End Class

Module Program
    Sub Main()
        Dim book As New Ledger()
        With book
            .Name = "general"
            .Add()
            .Add()
            .Add()
        End With
        Console.WriteLine($"{book.Name} has {book.Entries} entries")
        Console.WriteLine("four statements, and the object was named once")
    End Sub
End Module
