' When decides before the stack unwinds. This program prints the order to prove it.
Imports System

Module Program
    Function Wanted(ex As Exception) As Boolean
        Console.WriteLine("    the filter was asked")
        Return False
    End Function

    Sub Inner()
        Try
            Throw New InvalidOperationException("from Inner")
        Finally
            Console.WriteLine("    Inner's Finally ran")
        End Try
    End Sub

    Sub Main()
        Try
            Console.WriteLine("  Main's Try began")
            Inner()
        Catch ex As InvalidOperationException When Wanted(ex)
            Console.WriteLine("  the filtered Catch took it")
        Catch ex As InvalidOperationException
            Console.WriteLine("  the second Catch took it")
        End Try
        Console.WriteLine("the filter ran BEFORE Inner's Finally")
    End Sub
End Module
