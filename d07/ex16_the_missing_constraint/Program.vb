' The same procedure without the constraint. Nothing about T promises a CompareTo.
Imports System
Imports System.Collections.Generic

Module Program
    Function Largest(Of T)(items As IEnumerable(Of T)) As T
        Dim best As T = Nothing
        For Each item In items
            If item.CompareTo(best) > 0 Then
                best = item
            End If
        Next
        Return best
    End Function

    Sub Main()
        Dim numbers As New List(Of Integer)() From {3, 17, 5}
        Console.WriteLine($"never printed : {Largest(numbers)}")
    End Sub
End Module
