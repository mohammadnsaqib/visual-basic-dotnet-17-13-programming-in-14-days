' Finally runs on the way out through a failure nobody here catches.
Imports System

Module Program
    Sub Inner()
        Try
            Console.WriteLine("  Inner began")
            Throw New InvalidOperationException("something went wrong inside")
        Finally
            Console.WriteLine("  Inner's Finally ran")
        End Try
    End Sub

    Sub Main()
        Try
            Inner()
        Catch ex As InvalidOperationException
            Console.WriteLine($"Main caught : {ex.Message}")
        End Try
        Console.WriteLine("Finally ran before the Catch, and before Main saw anything")
    End Sub
End Module
