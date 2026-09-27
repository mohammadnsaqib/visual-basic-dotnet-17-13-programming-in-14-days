' The wiring written once, at the declaration, and checked by the compiler.
Imports System

Public Class Counter

    Public Event Reached As EventHandler(Of Integer)

    Public Sub CountTo(target As Integer)
        For i = 1 To target
            RaiseEvent Reached(Me, i)
        Next
    End Sub
End Class

Public Class Watcher

    Private WithEvents Source As Counter

    Public Property Seen As Integer

    Public Sub New(source As Counter)
        Me.Source = source
    End Sub

    Private Sub OnReached(sender As Object, value As Integer) Handles Source.Reached
        Seen += 1
        Console.WriteLine($"  Handles saw {value}")
    End Sub
End Class

Module Program
    Sub Main()
        Dim counter As New Counter()
        Dim watcher As New Watcher(counter)

        counter.CountTo(3)
        Console.WriteLine($"seen : {watcher.Seen}")
        Console.WriteLine("no AddHandler appears anywhere; the Handles clause is the " &
                          "wiring")
    End Sub
End Module
