' A type with a type parameter. The parameter is fixed when the type is used, not when
' written.
Imports System
Imports System.Collections.Generic

Public Class Slot(Of T)

    Private _held As T
    Private _filled As Boolean

    Public ReadOnly Property IsFilled As Boolean
        Get
            Return _filled
        End Get
    End Property

    Public Sub Fill(value As T)
        _held = value
        _filled = True
    End Sub

    Public Function Take() As T
        If Not _filled Then
            Throw New InvalidOperationException("the slot is empty")
        End If
        _filled = False
        Return _held
    End Function
End Class

Module Program
    Sub Main()
        Dim text As New Slot(Of String)()
        Dim number As New Slot(Of Integer)()

        Console.WriteLine($"text filled   : {text.IsFilled}")
        text.Fill("AC-1000")
        number.Fill(42)
        Console.WriteLine($"text          : {text.Take()}")
        Console.WriteLine($"number        : {number.Take()}")
        Console.WriteLine($"text filled   : {text.IsFilled}")
        Console.WriteLine($"filled with   : " &
                          $"{text.GetType().GetGenericArguments()(0).Name} " &
                          $"and {number.GetType().GetGenericArguments()(0).Name}")
        Console.WriteLine($"one definition: " &
                          $"{text.GetType().GetGenericTypeDefinition().Name}")
    End Sub
End Module
