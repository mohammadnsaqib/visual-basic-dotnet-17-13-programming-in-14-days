' A New constraint lets a generic type make its own T. Without it, New T() does not
' compile.
Imports System
Imports System.Collections.Generic

Public Class Register(Of T As {Class, New})

    Private ReadOnly _made As New List(Of T)()

    Public Function Make() As T
        Dim item As New T()
        _made.Add(item)
        Return item
    End Function

    Public ReadOnly Property Count As Integer
        Get
            Return _made.Count
        End Get
    End Property
End Class

Public Class Note
    Public Property Text As String = "blank"
End Class

Module Program
    Sub Main()
        Dim notes As New Register(Of Note)()
        Dim first = notes.Make()
        Dim second = notes.Make()
        second.Text = "second"

        Console.WriteLine($"made      : {notes.Count}")
        Console.WriteLine($"first     : {first.Text}")
        Console.WriteLine($"second    : {second.Text}")
        Console.WriteLine($"same one  : {ReferenceEquals(first, second)}")
        Console.WriteLine("New T() compiles only because the constraint promises a " &
                          "constructor")
    End Sub
End Module
