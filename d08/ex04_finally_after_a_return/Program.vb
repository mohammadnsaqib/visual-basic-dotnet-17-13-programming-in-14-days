' Finally runs on the way out, including the way out through Return.
Imports System

Module Program
    Function Reading(text As String) As Integer
        Try
            Console.WriteLine($"  Try began for {text}")
            Return Integer.Parse(text)
        Catch ex As FormatException
            Console.WriteLine("  Catch ran")
            Return -1
        Finally
            Console.WriteLine("  Finally ran")
        End Try
    End Function

    Sub Main()
        Console.WriteLine($"good input gave {Reading("42")}")
        Console.WriteLine($"bad input gave  {Reading("forty")}")
    End Sub
End Module
