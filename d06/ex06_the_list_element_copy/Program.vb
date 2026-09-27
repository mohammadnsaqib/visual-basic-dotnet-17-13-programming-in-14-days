' An array element is storage. A list element is a copy, and the compiler refuses to
' pretend otherwise.
Imports System
Imports System.Collections.Generic

Structure Counter
    Public Count As Integer
End Structure

Module Program
    Sub Main()
        Dim rows As New List(Of Counter)()
        Dim first As New Counter()
        first.Count = 10
        rows.Add(first)

        rows(0).Count = 99
        Console.WriteLine($"never printed : {rows(0).Count}")
    End Sub
End Module
