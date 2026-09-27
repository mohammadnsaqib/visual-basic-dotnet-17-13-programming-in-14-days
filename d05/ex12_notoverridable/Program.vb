' NotOverridable stops one member from being replaced any further down.
Imports System

Public Class Document
    Public Overridable Function Kind() As String
        Return "document"
    End Function
End Class

Public Class Invoice
    Inherits Document
    Public NotOverridable Overrides Function Kind() As String
        Return "invoice"
    End Function
End Class

Public Class CreditNote
    Inherits Invoice
    Public Shadows Function Kind() As String
        Return "credit note"
    End Function
End Class

Module Program
    Sub Main()
        Dim note As New CreditNote()
        Dim asDocument As Document = note
        Console.WriteLine($"as a CreditNote : {note.Kind()}")
        Console.WriteLine($"as a Document   : {asDocument.Kind()}")
        Console.WriteLine("Overrides was closed off, so only Shadows was left")
    End Sub
End Module
