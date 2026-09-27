' The same query written as the method calls it compiles into.
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
            New Movement("AC-1001", 87.5D),
            New Movement("AC-4000", 900D)}

        Dim asQuery = From movement In movements
                      Where movement.Amount >= 500D
                      Order By movement.Amount Descending
                      Select movement.Code, movement.Amount

        Dim asMethods = movements _
            .Where(Function(movement) movement.Amount >= 500D) _
            .OrderByDescending(Function(movement) movement.Amount) _
            .Select(Function(movement) New With {movement.Code, movement.Amount})

        Console.WriteLine("query syntax:")
        For Each row In asQuery
            Console.WriteLine($"  {row.Code} {row.Amount,10:N2}")
        Next
        Console.WriteLine("method syntax:")
        For Each row In asMethods
            Console.WriteLine($"  {row.Code} {row.Amount,10:N2}")
        Next
        Console.WriteLine($"same shape of result : " &
                          $"{asQuery.First().Code = asMethods.First().Code}")
    End Sub
End Module
