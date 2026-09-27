' For Each does not need an interface. It needs a GetEnumerator, and it looks for one
' first.
Imports System
Imports System.Collections.Generic

Public Class Pair
    Public ReadOnly Property Left As String
    Public ReadOnly Property Right As String

    Public Sub New(left As String, right As String)
        _Left = left
        _Right = right
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of String)
        Dim both As New List(Of String)() From {Left, Right}
        Return both.GetEnumerator()
    End Function
End Class

Module Program
    Sub Main()
        Dim accounts As New Pair("Cash", "Rent")
        For Each name In accounts
            Console.WriteLine($"  {name}")
        Next
        Console.WriteLine($"implements IEnumerable : " &
                          $"{TypeOf accounts Is IEnumerable(Of String)}")
        Console.WriteLine("For Each asked the type for GetEnumerator and got one")
    End Sub
End Module
