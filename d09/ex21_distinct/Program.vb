' Distinct removes repeats, and what counts as a repeat is the type's own equality.
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
            New Movement("AC-1000", 450D),
            New Movement("AC-1000", 1200D)}

        Dim codes = (From movement In movements Select movement.Code).Distinct()
        Console.WriteLine($"movements : {movements.Count}")
        Console.WriteLine($"codes     : {String.Join(", ", codes)}")

        Dim objects = movements.Distinct().Count()
        Console.WriteLine($"Distinct on the objects : {objects}")

        Dim pairs = (From movement In movements
                     Select movement.Code, movement.Amount).Distinct()
        Console.WriteLine($"Distinct on code and amount : {pairs.Count()}")
        For Each pair In pairs
            Console.WriteLine($"  {pair.Code} {pair.Amount,9:N2}")
        Next
    End Sub
End Module
