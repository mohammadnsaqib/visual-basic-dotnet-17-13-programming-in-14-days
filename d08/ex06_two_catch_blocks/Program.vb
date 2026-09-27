' Catch blocks are tried in the order written, and the first that fits wins.
Imports System

Module Program
    Sub Attempt(text As String)
        Try
            Console.WriteLine($"  {text} -> {Integer.Parse(text)}")
        Catch ex As FormatException
            Console.WriteLine($"  {text} -> FormatException")
        Catch ex As OverflowException
            Console.WriteLine($"  {text} -> OverflowException")
        Catch ex As Exception
            Console.WriteLine($"  {text} -> {ex.GetType().Name}")
        End Try
    End Sub

    Sub Main()
        Attempt("42")
        Attempt("forty")
        Attempt("99999999999999999999")
        Attempt(Nothing)
    End Sub
End Module
