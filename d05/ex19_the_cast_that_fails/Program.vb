' The same two casts on an object that does not implement the interface.
Imports System

Public Interface IDescribable
    Function Describe() As String
End Interface

Public Class Document
End Class

Module Program
    Sub Main()
        Dim boxed As Object = New Document()

        Dim maybe = TryCast(boxed, IDescribable)
        Console.WriteLine($"TryCast gave Nothing : {maybe Is Nothing}")

        Try
            Dim item = DirectCast(boxed, IDescribable)
            Console.WriteLine(item.Describe())
        Catch ex As InvalidCastException
            Console.WriteLine($"DirectCast threw     : {ex.GetType().Name}")
        End Try
        Console.WriteLine("TryCast asks; DirectCast insists")
    End Sub
End Module
