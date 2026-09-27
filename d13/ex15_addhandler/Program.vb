' The same wiring done while the program runs, which Handles cannot do.
Imports System
Imports System.Collections.Generic

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
        Dim seen As New List(Of String)()

        Dim names = New String() {"audit", "report", "alarm"}
        For Each name In names
            AddHandler counter.Reached, Sub(sender, value) seen.Add($"{name}:{value}")
        Next

        counter.CountTo(2)
        Console.WriteLine($"handlers : {names.Length}")
        Console.WriteLine($"lines    : {seen.Count}")
        For Each line In seen
            Console.WriteLine($"  {line}")
        Next
        Console.WriteLine("the three listeners were not known when the program was " &
                          "written")
    End Sub
End Module
