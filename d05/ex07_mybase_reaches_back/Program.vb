' MyBase calls the version that was replaced.
Imports System

Public Class Document
    Public Overridable Function Describe() As String
        Return "a document"
    End Function
End Class

Public Class Invoice
    Inherits Document
    Public Overrides Function Describe() As String
        Return MyBase.Describe() & ", and an invoice"
    End Function
End Class

Module Program
    Sub Main()
        Console.WriteLine(New Invoice().Describe())
        Console.WriteLine("the base version ran first and its answer was extended")
    End Sub
End Module
