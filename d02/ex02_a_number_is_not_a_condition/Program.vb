' A condition is a Boolean, and Visual Basic will not take a number instead.
Imports System

Module Program
    Sub Main()
        Dim count As Integer = 3
        If count Then
            Console.WriteLine("this line cannot be reached")
        End If
    End Sub
End Module
