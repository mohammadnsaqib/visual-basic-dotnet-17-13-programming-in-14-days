' Two resources in one Using, and the order they are released in.
Imports System

Public NotInheritable Class Named
    Implements IDisposable

    Private ReadOnly _name As String

    Public Sub New(name As String)
        _name = name
        Console.WriteLine($"  {_name} opened")
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Console.WriteLine($"  {_name} closed")
    End Sub
End Class

Module Program
    Sub Main()
        Console.WriteLine("one Using with two resources:")
        Using first As New Named("first"), second As New Named("second")
            Console.WriteLine("  the block ran")
        End Using

        Console.WriteLine("and with a failure inside:")
        Try
            Using third As New Named("third"), fourth As New Named("fourth")
                Throw New InvalidOperationException("inside the block")
            End Using
        Catch ex As InvalidOperationException
            Console.WriteLine($"  caught : {ex.Message}")
        End Try
        Console.WriteLine("the last opened is the first closed, failure or not")
    End Sub
End Module
