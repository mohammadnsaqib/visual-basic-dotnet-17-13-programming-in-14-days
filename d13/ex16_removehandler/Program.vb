' A listener that stops listening, and what happens to one that does not.
Imports System

Public Class Counter

    Public Event Reached As EventHandler(Of Integer)

    Public Sub CountTo(target As Integer)
        For i = 1 To target
            RaiseEvent Reached(Me, i)
        Next
    End Sub
End Class

Public Class Listener
    Implements IDisposable

    Private ReadOnly _source As Counter
    Private ReadOnly _name As String
    Private _listening As Boolean

    Public Property Seen As Integer

    Public Sub New(name As String, source As Counter)
        _name = name
        _source = source
        AddHandler _source.Reached, AddressOf OnReached
        _listening = True
    End Sub

    Private Sub OnReached(sender As Object, value As Integer)
        Seen += 1
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If _listening Then
            RemoveHandler _source.Reached, AddressOf OnReached
            _listening = False
            Console.WriteLine($"  {_name} stopped listening after {Seen}")
        End If
    End Sub
End Class

Module Program
    Sub Main()
        Dim counter As New Counter()
        Dim staying As New Listener("staying", counter)
        Dim leaving As New Listener("leaving", counter)

        counter.CountTo(2)
        leaving.Dispose()
        counter.CountTo(2)

        Console.WriteLine($"staying saw : {staying.Seen}")
        Console.WriteLine($"leaving saw : {leaving.Seen}")
        Console.WriteLine("a handler nobody removes keeps its object alive for as " &
                          "long as the source lives")
    End Sub
End Module
