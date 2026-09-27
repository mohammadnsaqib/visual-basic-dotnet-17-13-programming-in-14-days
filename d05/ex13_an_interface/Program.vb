' An interface is a list of members with no code at all.
Imports System

Public Interface IDescribable
    ReadOnly Property Title As String
    Function Describe() As String
End Interface

Public Class Invoice
    Implements IDescribable

    Public ReadOnly Property Title As String Implements IDescribable.Title
    Public Sub New(title As String)
        _Title = title
    End Sub

    Public Function Describe() As String Implements IDescribable.Describe
        Return $"invoice: {Title}"
    End Function
End Class

Module Program
    Sub Main()
        Dim item As IDescribable = New Invoice("September rent")
        Console.WriteLine($"Title    : {item.Title}")
        Console.WriteLine($"Describe : {item.Describe()}")
        Console.WriteLine($"the variable's type is {GetType(IDescribable).Name}")
        Console.WriteLine($"the object's type is {item.GetType().Name}")
    End Sub
End Module
