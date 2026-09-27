' A method can only be replaced if its author allowed it, and both sides say so.
Imports System

Public Class Document
    Public Overridable Function Describe() As String
        Return "a document"
    End Function
    Public Function Fixed() As String
        Return "not overridable"
    End Function
End Class

Public Class Invoice
    Inherits Document
    Public Overrides Function Describe() As String
        Return "an invoice"
    End Function
End Class

Module Program
    Sub Main()
        Dim asBase As Document = New Invoice()
        Console.WriteLine($"Describe through the base variable : {asBase.Describe()}")
        Console.WriteLine($"Fixed through the base variable    : {asBase.Fixed()}")
        Console.WriteLine("the call went to the object's own version, not the " &
                          "variable's type")
    End Sub
End Module
