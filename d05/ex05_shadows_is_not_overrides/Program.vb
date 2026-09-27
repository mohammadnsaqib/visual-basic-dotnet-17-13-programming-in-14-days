' Shadows hides a member; Overrides replaces it. The difference shows through a base
' variable.
Imports System

Public Class Document
    Public Overridable Function Describe() As String
        Return "a document"
    End Function
    Public Overridable Function Label() As String
        Return "a document label"
    End Function
End Class

Public Class Invoice
    Inherits Document
    Public Overrides Function Describe() As String
        Return "an invoice"
    End Function
    Public Shadows Function Label() As String
        Return "an invoice label"
    End Function
End Class

Module Program
    Sub Main()
        Dim asInvoice As New Invoice()
        Dim asDocument As Document = asInvoice

        Console.WriteLine($"Describe as Invoice  : {asInvoice.Describe()}")
        Console.WriteLine($"Describe as Document : {asDocument.Describe()}")
        Console.WriteLine($"Label    as Invoice  : {asInvoice.Label()}")
        Console.WriteLine($"Label    as Document : {asDocument.Label()}")
        Console.WriteLine("one object, and Label answered two different ways")
    End Sub
End Module
