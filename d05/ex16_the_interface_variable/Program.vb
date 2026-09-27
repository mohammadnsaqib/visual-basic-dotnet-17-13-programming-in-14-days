' A variable of an interface type can hold any type that implements it.
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

Public Class Receipt
    Implements IDescribable
    Public Function Describe() As String Implements IDescribable.Describe
        Return "a receipt"
    End Function
    Public Function OnlyOnReceipt() As String
        Return "not reachable through the interface"
    End Function
End Class

Module Program
    Sub Main()
        Dim items As IDescribable() = {New Invoice(), New Receipt()}
        For Each item In items
            Console.WriteLine($"  {item.GetType().Name,-8} {item.Describe()}")
        Next
        Console.WriteLine("the two classes share no base class other than Object")
    End Sub
End Module
