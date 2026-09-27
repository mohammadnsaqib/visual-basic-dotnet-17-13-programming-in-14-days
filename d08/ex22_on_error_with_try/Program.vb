' The two mechanisms in one procedure. Visual Basic allows exactly one of them per
' method.
Imports System

Module Program
    Sub Main()
        On Error Resume Next

        Try
            Console.WriteLine(Integer.Parse("twenty"))
        Catch ex As FormatException
            Console.WriteLine("never printed")
        End Try
    End Sub
End Module
