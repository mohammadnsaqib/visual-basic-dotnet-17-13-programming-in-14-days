' A Shared member belongs to the type, so every instance sees the same one.
Imports System

Public Class Entry
    Public Shared Created As Integer
    Public ReadOnly Property Account As String

    Public Sub New(account As String)
        _Account = account
        Created += 1
    End Sub
End Class

Module Program
    Sub Main()
        Console.WriteLine($"before : {Entry.Created}")
        Dim a As New Entry("AC-1001")
        Dim b As New Entry("AC-1002")
        Dim c As New Entry("AC-1003")
        Console.WriteLine($"after  : {Entry.Created}")
        Console.WriteLine($"reached through the type, not an instance")
        Console.WriteLine($"a Is b : {a Is b}   b Is c : {b Is c}   (three objects)")
    End Sub
End Module
