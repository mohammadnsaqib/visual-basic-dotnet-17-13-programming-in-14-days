' Equals answered the question. The equals sign is a different question, and it has no
' answer yet.
Imports System

Structure Tag
    Public Code As String
End Structure

Module Program
    Sub Main()
        Dim a As New Tag()
        a.Code = "AC"
        Dim b As New Tag()
        b.Code = "AC"

        Console.WriteLine($"a Equals b : {a.Equals(b)}")
        If a = b Then
            Console.WriteLine("never printed")
        End If
    End Sub
End Module
