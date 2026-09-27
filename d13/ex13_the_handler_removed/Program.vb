' RemoveHandler needs a delegate equal to the one added. AddressOf on the same
' procedure gives one, and a lambda written out twice does not.
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
    Dim Seen As Integer = 0

    Sub Count(sender As Object, value As Integer)
        Seen += 1
    End Sub

    Sub Main()
        Dim counter As New Counter()

        AddHandler counter.Reached, AddressOf Count
        counter.CountTo(3)
        Console.WriteLine($"after three raises : {Seen}")

        RemoveHandler counter.Reached, AddressOf Count
        counter.CountTo(3)
        Console.WriteLine($"after removing it  : {Seen}")

        Dim once As EventHandler(Of Integer) = Sub(sender, value) Seen += 10
        AddHandler counter.Reached, once
        counter.CountTo(1)
        RemoveHandler counter.Reached, once
        counter.CountTo(1)
        Console.WriteLine($"a lambda held in a variable : {Seen}")
        Console.WriteLine("a lambda written twice is two different handlers")
    End Sub
End Module
