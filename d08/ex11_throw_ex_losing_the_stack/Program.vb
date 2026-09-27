' The same program with Throw ex. One word, and the origin is gone.
Imports System

Module Program
    Sub Deepest()
        Throw New InvalidOperationException("thrown in Deepest")
    End Sub

    Sub Middle()
        Try
            Deepest()
        Catch ex As InvalidOperationException
            Console.WriteLine("  Middle saw it and threw it again")
            Throw ex
        End Try
    End Sub

    Sub Main()
        Try
            Middle()
        Catch ex As InvalidOperationException
            Console.WriteLine($"caught : {ex.Message}")
            For Each line In ex.StackTrace.Split(vbLf)
                If line.Trim().Length > 0 Then
                    Console.WriteLine($"  {line.Trim()}")
                End If
            Next
        End Try
    End Sub
End Module
