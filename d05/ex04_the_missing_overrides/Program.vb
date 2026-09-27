' Replacing a method without saying Overrides is warned about, and then allowed.
Imports System

Public Class Document
    Public Overridable Function Describe() As String
        Return "a document"
    End Function
End Class

Public Class Invoice
    Inherits Document
    Public Function Describe() As String
        Return "an invoice"
    End Function
End Class

Module Program
    Sub Main()
        Console.WriteLine(New Invoice().Describe())
    End Sub
End Module
