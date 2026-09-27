' MyClass calls this class's version even when a derived class replaced it.
Imports System

Public Class Document
    Public Overridable Function Kind() As String
        Return "document"
    End Function

    Public Function ThroughMe() As String
        Return $"Me.Kind is {Me.Kind()}"
    End Function

    Public Function ThroughMyClass() As String
        Return $"MyClass.Kind is {MyClass.Kind()}"
    End Function
End Class

Public Class Invoice
    Inherits Document
    Public Overrides Function Kind() As String
        Return "invoice"
    End Function
End Class

Module Program
    Sub Main()
        Dim bill As New Invoice()
        Console.WriteLine(bill.ThroughMe())
        Console.WriteLine(bill.ThroughMyClass())
        Console.WriteLine("both lines are in Document and the object is an Invoice")
    End Sub
End Module
