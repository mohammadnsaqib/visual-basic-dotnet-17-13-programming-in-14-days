' Copying a variable that refers to an object copies neither the object nor its
' contents.
Imports System
Imports System.Collections.Generic

Public Class Ledger
    Public Property Name As String
    Public ReadOnly Property Lines As New List(Of String)
End Class

Module Program
    Sub Main()
        Dim original As New Ledger() With {.Name = "general"}
        original.Lines.Add("rent")

        Dim copy = original
        copy.Name = "changed"
        copy.Lines.Add("electricity")

        Console.WriteLine($"original.Name  : {original.Name}")
        Console.WriteLine($"original.Lines : {original.Lines.Count}")
        Console.WriteLine($"copy.Name      : {copy.Name}")
        Console.WriteLine($"copy.Lines     : {copy.Lines.Count}")
        Console.WriteLine("there was never a second object to change")
    End Sub
End Module
