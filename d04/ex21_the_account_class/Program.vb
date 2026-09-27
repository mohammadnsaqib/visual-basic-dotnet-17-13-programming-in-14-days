' The first type of the ledger this book builds.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim rent As New Account("AC-1001", "  Rent  ", 0D)
        Console.WriteLine($"Code    : [{rent.Code}]")
        Console.WriteLine($"Name    : [{rent.Name}]")
        Console.WriteLine($"Balance : {rent.Balance:N2}")
        Console.WriteLine($"ToString: {rent}")

        Try
            Dim broken As New Account("", "Rent")
            Console.WriteLine(broken)
        Catch ex As ArgumentException
            Console.WriteLine($"refused : {ex.ParamName} -- {ex.Message.Split(vbLf)(0)}")
        End Try
    End Sub
End Module
