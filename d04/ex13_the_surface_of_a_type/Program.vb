' What a type offers to the outside, listed by the type itself.
Imports System
Imports System.Reflection

Public Class Ledger
    Private _entries As Integer
    Friend Opened As Boolean
    Public Property Name As String
    Public ReadOnly Property Entries As Integer
        Get
            Return _entries
        End Get
    End Property
    Public Sub Add()
        _entries += 1
    End Sub
    Private Sub Renumber()
        _entries = 0
    End Sub
End Class

Module Program
    Sub Main()
        Dim t = GetType(Ledger)
        Console.WriteLine("public surface:")
        For Each p In t.GetProperties()
            Console.WriteLine($"  property {p.Name}")
        Next
        For Each m In t.GetMethods(BindingFlags.Public Or BindingFlags.Instance Or
                                   BindingFlags.DeclaredOnly)
            If Not m.IsSpecialName Then Console.WriteLine($"  method   {m.Name}")
        Next
        Console.WriteLine("kept inside:")
        For Each m In t.GetMethods(BindingFlags.NonPublic Or BindingFlags.Instance Or
                                   BindingFlags.DeclaredOnly)
            Console.WriteLine($"  method   {m.Name}")
        Next
    End Sub
End Module
