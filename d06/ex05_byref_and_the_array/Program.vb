' Two ways to reach the caller's own storage: ask for it by reference, or index into an
' array.
Imports System

Structure Counter
    Public Count As Integer

    Public Overrides Function ToString() As String
        Return Count.ToString()
    End Function
End Structure

Module Program
    Sub BumpByValue(c As Counter)
        c.Count += 1
    End Sub

    Sub BumpByRef(ByRef c As Counter)
        c.Count += 1
    End Sub

    Sub Main()
        Dim one As New Counter()
        one.Count = 5
        BumpByValue(one)
        Console.WriteLine($"after BumpByValue : {one}")
        BumpByRef(one)
        Console.WriteLine($"after BumpByRef   : {one}")

        Dim many(2) As Counter
        many(0).Count = 100
        many(1).Count = 200
        many(2).Count = 300
        many(1).Count += 1
        BumpByRef(many(2))
        Console.WriteLine($"array : {many(0)}, {many(1)}, {many(2)}")
    End Sub
End Module
