' A constraint that names an interface lets the generic code call that interface's
' members.
Imports System
Imports System.Collections.Generic

Module Program
    Function Largest(Of T As IComparable(Of T))(items As IEnumerable(Of T)) As T
        Dim best As T = Nothing
        Dim seen As Boolean = False
        For Each item In items
            If Not seen OrElse item.CompareTo(best) > 0 Then
                best = item
                seen = True
            End If
        Next
        If Not seen Then
            Throw New ArgumentException("nothing to compare", NameOf(items))
        End If
        Return best
    End Function

    Sub Main()
        Dim numbers As New List(Of Integer)() From {3, 17, 5}
        Dim words As New List(Of String)() From {"rent", "cash", "sales"}
        Dim amounts As New List(Of Decimal)() From {12.5D, 87.5D, 30D}

        Console.WriteLine($"largest number : {Largest(numbers)}")
        Console.WriteLine($"largest word   : {Largest(words)}")
        Console.WriteLine($"largest amount : {Largest(amounts):N2}")
        Console.WriteLine("one procedure, three types, and the comparison is the " &
                          "type's own")
    End Sub
End Module
