' An auto-property is a field and two methods the compiler writes for you.
Imports System
Imports System.Reflection

Public Class Ledger
    Public Property Name As String
    Public ReadOnly Property Code As String = "GL"
End Class

Module Program
    Sub Main()
        Dim book As New Ledger() With {.Name = "general"}
        Console.WriteLine($"Name : {book.Name}")
        Console.WriteLine($"Code : {book.Code}")

        Dim t = GetType(Ledger)
        Console.WriteLine("what the compiler generated:")
        For Each m In t.GetMethods(BindingFlags.Public Or BindingFlags.Instance Or
                                   BindingFlags.DeclaredOnly)
            Console.WriteLine($"  method {m.Name}")
        Next
        For Each f In t.GetFields(BindingFlags.NonPublic Or BindingFlags.Instance)
            Console.WriteLine($"  field  {f.Name}")
        Next
    End Sub
End Module
