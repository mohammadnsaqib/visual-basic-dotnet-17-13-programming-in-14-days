' A Catch that decides whether it wants the exception before it takes it.
Imports System
Imports System.IO

Module Program
    Sub Attempt(code As String)
        Try
            If code = "AC-9999" Then
                Throw New IOException("the file is locked")
            End If
            Throw New IOException("the disk is full")
        Catch ex As IOException When ex.Message.Contains("locked")
            Console.WriteLine($"  {code} : retrying, because it is only locked")
        Catch ex As IOException
            Console.WriteLine($"  {code} : giving up on {ex.Message}")
        End Try
    End Sub

    Sub Main()
        Attempt("AC-9999")
        Attempt("AC-1000")
        Console.WriteLine("one type of exception, two decisions")
    End Sub
End Module
