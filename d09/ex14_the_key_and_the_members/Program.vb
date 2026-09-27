' Visual Basic can aggregate inside the Into clause, and name each answer.
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
            New Movement("AC-1000", 87.5D),
            New Movement("AC-4000", 450D),
            New Movement("AC-1001", 1200D),
            New Movement("AC-4000", 900D)}

        Dim summary = From movement In movements
                      Group movement By Code = movement.Code
                      Into Made = Count(), Total = Sum(movement.Amount),
                           Largest = Max(movement.Amount)
                      Order By Code
                      Select Code, Made, Total, Largest

        For Each row In summary
            Console.WriteLine($"  {row.Code} {row.Made,3} {row.Total,10:N2} " &
                              $"largest {row.Largest,9:N2}")
        Next
        Console.WriteLine($"total of the totals : " &
                          $"{summary.Sum(Function(r) r.Total):N2}")
    End Sub
End Module
