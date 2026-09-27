' DirectCast to an interface asserts the object already implements it.
Imports System

Public Interface IDescribable
    Function Describe() As String
End Interface

Public Class Invoice
    Implements IDescribable
    Public Function Describe() As String Implements IDescribable.Describe
        Return "an invoice"
    End Function
End Class

Module Program
    Sub Main()
        Dim boxed As Object = New Invoice()
        Dim item = DirectCast(boxed, IDescribable)
        Console.WriteLine($"DirectCast worked : {item.Describe()}")

        Dim maybe = TryCast(boxed, IDescribable)
        Console.WriteLine($"TryCast worked    : {maybe IsNot Nothing}")
        Console.WriteLine($"and it says       : {maybe.Describe()}")
    End Sub
End Module
