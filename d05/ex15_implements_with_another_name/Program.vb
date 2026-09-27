' Visual Basic names the member being implemented, so the two can differ.
Imports System

Public Interface IDescribable
    Function Describe() As String
End Interface

Public Class Invoice
    Implements IDescribable

    ' The class calls it Summary; the interface calls it Describe.
    Public Function Summary() As String Implements IDescribable.Describe
        Return "invoice: September rent"
    End Function
End Class

Module Program
    Sub Main()
        Dim bill As New Invoice()
        Console.WriteLine($"through the class     : {bill.Summary()}")
        Dim item As IDescribable = bill
        Console.WriteLine($"through the interface : {item.Describe()}")
        Console.WriteLine("one method, reached by two names")
    End Sub
End Module
