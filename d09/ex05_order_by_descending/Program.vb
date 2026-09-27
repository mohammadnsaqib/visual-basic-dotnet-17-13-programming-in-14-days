' Order By reorders without changing the source, and equal keys keep their original
' order.
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
            New Movement("AC-1001", 1200D),
            New Movement("AC-4000", 450D),
            New Movement("AC-2000", 900D)}

        Console.WriteLine("largest first:")
        For Each movement In From m In movements Order By m.Amount Descending Select m
            Console.WriteLine($"  {movement.Code} {movement.Amount,9:N2}")
        Next

        Console.WriteLine("the source is unchanged:")
        For Each movement In movements
            Console.WriteLine($"  {movement.Code} {movement.Amount,9:N2}")
        Next
    End Sub
End Module
