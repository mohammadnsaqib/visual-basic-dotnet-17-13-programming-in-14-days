' The same blocks in the other order. One of them can never be reached.
Imports System

Module Program
    Sub Main()
        Try
            Console.WriteLine(Integer.Parse("forty"))
        Catch ex As Exception
            Console.WriteLine($"general : {ex.GetType().Name}")
        Catch ex As FormatException
            Console.WriteLine("never reached")
        End Try
    End Sub
End Module
