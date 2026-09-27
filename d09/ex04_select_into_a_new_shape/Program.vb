' Select decides what comes out. It need not be what went in.
Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Class Movement
    Public ReadOnly Property Code As String
    Public ReadOnly Property Amount As Decimal

    Public Sub New(code As String, amount As Decimal)
        _Code = code
        _Amount = amount
    End Sub
End Class

Module Program
    Sub Main()
        Dim movements As New List(Of Movement)() From {
            New Movement("AC-1000", 1200D),
            New Movement("AC-1001", 87.5D)}

        Dim codes = From movement In movements Select movement.Code
        Dim halves = From movement In movements
                     Select Code = movement.Code, Half = movement.Amount / 2D
        Dim lines = From movement In movements
                    Select $"{movement.Code} carries {movement.Amount:N2}"

        Console.WriteLine($"codes  : {String.Join(", ", codes)}")
        Console.WriteLine($"type   : {codes.First().GetType().Name}")
        For Each row In halves
            Console.WriteLine($"  {row.Code} half {row.Half:N2}")
        Next
        Console.WriteLine($"shape  : {halves.First()}")
        For Each line In lines
            Console.WriteLine($"  {line}")
        Next
    End Sub
End Module
