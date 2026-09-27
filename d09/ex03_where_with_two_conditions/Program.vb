' Two conditions, written three ways, giving one answer.
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
    Sub Main()
        Dim movements As New List(Of Movement)() From {
            New Movement("AC-1000", 1200D, 1),
            New Movement("AC-1001", 1200D, 1),
            New Movement("AC-1000", 87.5D, 2),
            New Movement("AC-4000", 450D, 2),
            New Movement("AC-1001", 1200D, 2),
            New Movement("AC-4000", 900D, 3)}

        Dim joined = From movement In movements
                     Where movement.Amount >= 500D AndAlso movement.Period >= 2
                     Select movement

        Dim twice = From movement In movements
                    Where movement.Amount >= 500D
                    Where movement.Period >= 2
                    Select movement

        Dim chained = movements _
            .Where(Function(movement) movement.Amount >= 500D) _
            .Where(Function(movement) movement.Period >= 2)

        Console.WriteLine($"one Where with AndAlso : {joined.Count()}")
        Console.WriteLine($"two Where clauses      : {twice.Count()}")
        Console.WriteLine($"two chained calls      : {chained.Count()}")
        For Each movement In joined
            Console.WriteLine($"  {movement.Code} period {movement.Period} " &
                              $"{movement.Amount,9:N2}")
        Next
    End Sub
End Module
