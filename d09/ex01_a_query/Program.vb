' A query written as a query. It is an expression, and it names no loop and no list.
Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Class Movement
    Public ReadOnly Property Code As String
    Public ReadOnly Property Amount As Decimal
    Public ReadOnly Property Period As Integer

    Public Sub New(code As String, amount As Decimal, period As Integer)
        _Code = code
        _Amount = amount
        _Period = period
    End Sub
End Class

Module Program
    Function Sample() As List(Of Movement)
        Return New List(Of Movement)() From {
            New Movement("AC-1000", 1200D, 1),
            New Movement("AC-1001", 1200D, 1),
            New Movement("AC-1000", 87.5D, 2),
            New Movement("AC-4000", 450D, 2),
            New Movement("AC-1001", 1200D, 2),
            New Movement("AC-4000", 900D, 3)}
    End Function

    Sub Main()
        Dim movements = Sample()

        Dim big = From movement In movements
                  Where movement.Amount >= 500D
                  Order By movement.Amount Descending
                  Select movement.Code, movement.Amount

        Console.WriteLine($"movements : {movements.Count}")
        For Each row In big
            Console.WriteLine($"  {row.Code} {row.Amount,10:N2}")
        Next
        Console.WriteLine($"the query is a sequence : " &
                          $"{TypeOf big Is System.Collections.IEnumerable}")
        Console.WriteLine($"and the source still holds : {movements.Count}")
    End Sub
End Module
