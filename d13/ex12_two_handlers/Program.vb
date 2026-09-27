' Two handlers on one event. Raising it calls them in the order they were added.
Imports System

Public Class Counter

    Public Event Reached As EventHandler(Of Integer)

    Public Sub CountTo(target As Integer)
        For i = 1 To target
            RaiseEvent Reached(Me, i)
        Next
    End Sub
End Class

Module Program
    Dim Total As Integer = 0

    Sub Report(sender As Object, value As Integer)
        Console.WriteLine($"  first handler  : {value}")
    End Sub

    Sub Add(sender As Object, value As Integer)
        Total += value
        Console.WriteLine($"  second handler : running total {Total}")
    End Sub

    Sub Main()
        Dim counter As New Counter()
        AddHandler counter.Reached, AddressOf Report
        AddHandler counter.Reached, AddressOf Add

        counter.CountTo(3)
        Console.WriteLine($"total : {Total}")
        Console.WriteLine("both ran for every raise, in the order they were added")
    End Sub
End Module
