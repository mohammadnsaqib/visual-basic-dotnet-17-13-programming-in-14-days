' Two keys: the first decides, and the second breaks the ties.
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

        Dim ordered = From movement In movements
                      Order By movement.Period, movement.Amount Descending
                      Select movement

        For Each movement In ordered
            Console.WriteLine($"  period {movement.Period}  {movement.Code} " &
                              $"{movement.Amount,9:N2}")
        Next

        Dim asMethods = movements _
            .OrderBy(Function(m) m.Period) _
            .ThenByDescending(Function(m) m.Amount)
        Console.WriteLine($"the method form uses ThenByDescending : " &
                          $"{asMethods.Count()} rows")
    End Sub
End Module
