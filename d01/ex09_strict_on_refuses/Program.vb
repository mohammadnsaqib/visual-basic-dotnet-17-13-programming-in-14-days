' Four Dim statements, each narrowing a type, with Option Strict On.
Imports System

Module Program
    Sub Main()
        Dim price As Double = 19.99
        Dim whole As Integer = price
        Dim text As String = whole
        Dim back As Integer = "42"
        Console.WriteLine(whole & text & back)
    End Sub
End Module
