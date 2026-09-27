' Custom Event: the three operations written out, so the list of handlers can be
' counted.
Imports System
Imports System.Collections.Generic

Public Class Counter

    Private ReadOnly _handlers As New List(Of EventHandler(Of Integer))()

    Public ReadOnly Property Listeners As Integer
        Get
            Return _handlers.Count
        End Get
    End Property

    Public Custom Event Reached As EventHandler(Of Integer)
        AddHandler(value As EventHandler(Of Integer))
            _handlers.Add(value)
            Console.WriteLine($"  a handler was added, making {_handlers.Count}")
        End AddHandler

        RemoveHandler(value As EventHandler(Of Integer))
            _handlers.Remove(value)
            Console.WriteLine($"  a handler was removed, leaving {_handlers.Count}")
        End RemoveHandler

        RaiseEvent(sender As Object, value As Integer)
            For Each handler In _handlers
                handler(sender, value)
            Next
        End RaiseEvent
    End Event

    Public Sub CountTo(target As Integer)
        For i = 1 To target
            RaiseEvent Reached(Me, i)
        Next
    End Sub
End Class

Module Program
    Sub Main()
        Dim counter As New Counter()
        Dim first As EventHandler(Of Integer) = Sub(sender,
            value) Console.WriteLine($"    A {value}")
        Dim second As EventHandler(Of Integer) = Sub(sender,
            value) Console.WriteLine($"    B {value}")

        AddHandler counter.Reached, first
        AddHandler counter.Reached, second
        counter.CountTo(1)
        RemoveHandler counter.Reached, first
        counter.CountTo(1)
        Console.WriteLine($"listeners : {counter.Listeners}")
    End Sub
End Module
