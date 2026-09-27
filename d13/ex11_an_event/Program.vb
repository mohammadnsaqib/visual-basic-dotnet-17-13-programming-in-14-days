' An event declared, a handler added, and the call that reaches it.
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
    Sub Main()
        Dim counter As New Counter()

        Console.WriteLine("with nobody listening:")
        counter.CountTo(3)
        Console.WriteLine("  nothing was printed, and nothing failed")

        AddHandler counter.Reached,
            Sub(sender, value) Console.WriteLine($"  reached {value}")
        Console.WriteLine("with one listener:")
        counter.CountTo(3)
    End Sub
End Module
