' A method that changes what it was given. Whether the caller sees it depends on the
' kind of type.
Imports System

Structure Counter
    Public Count As Integer
End Structure

Class Tin
    Public Count As Integer
End Class

Module Program
    Sub Bump(c As Counter)
        c.Count += 1
        Console.WriteLine($"  inside Bump, the structure now reads {c.Count}")
    End Sub

    Sub Bump(t As Tin)
        t.Count += 1
        Console.WriteLine($"  inside Bump, the object now reads    {t.Count}")
    End Sub

    Sub Main()
        Dim c As New Counter()
        c.Count = 10
        Console.WriteLine($"structure before : {c.Count}")
        Bump(c)
        Console.WriteLine($"structure after  : {c.Count}")

        Dim t As New Tin()
        t.Count = 10
        Console.WriteLine($"object before    : {t.Count}")
        Bump(t)
        Console.WriteLine($"object after     : {t.Count}")
    End Sub
End Module
