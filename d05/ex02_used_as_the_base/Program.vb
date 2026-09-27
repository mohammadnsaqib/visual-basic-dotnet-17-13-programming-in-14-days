' A derived object can be used anywhere the base type is expected.
Imports System

Public Class Document
    Public Property Title As String
    Public Overridable Function Describe() As String
        Return $"document: {Title}"
    End Function
End Class

Public Class Invoice
    Inherits Document
    Public Overrides Function Describe() As String
        Return $"invoice: {Title}"
    End Function
End Class

Module Program
    Sub Main()
        Dim items As Document() = {New Document() With {.Title = "notes"},
                                   New Invoice() With {.Title = "rent"}}
        For Each item In items
            Console.WriteLine($"  {item.Describe()}")
        Next
        Console.WriteLine($"the array's type is {items.GetType().Name}")
        Console.WriteLine($"the second item is really a {items(1).GetType().Name}")
    End Sub
End Module
