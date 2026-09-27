' Wrapping a failure in one that means something to the caller, without discarding the
' first.
Imports System
Imports Tally

Module Program
    Function AmountFrom(text As String) As Decimal
        Try
            Return Decimal.Parse(text)
        Catch ex As FormatException
            Throw New LedgerError($"'{text}' is not an amount", ex)
        End Try
    End Function

    Sub Main()
        Console.WriteLine($"good : {AmountFrom("1200.50"):N2}")
        Try
            Console.WriteLine(AmountFrom("twelve"))
        Catch ex As LedgerError
            Console.WriteLine($"outer message : {ex.Message}")
            Console.WriteLine($"inner type    : {ex.InnerException.GetType().Name}")
            Console.WriteLine($"inner message : {ex.InnerException.Message}")
            Dim deeper = If(ex.InnerException.InnerException Is Nothing,
                            "none", "another")
            Console.WriteLine($"inner of inner: {deeper}")
        End Try
    End Sub
End Module
