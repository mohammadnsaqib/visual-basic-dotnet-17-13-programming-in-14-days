' Grouping turns a flat sequence into a sequence of sequences.
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

        Dim byCode = From movement In movements
                     Group movement By Code = movement.Code Into Members = Group
                     Order By Code
                     Select Code, Members

        Console.WriteLine($"movements : {movements.Count}")
        Console.WriteLine($"groups    : {byCode.Count()}")
        For Each item In byCode
            Console.WriteLine($"  {item.Code} : {item.Members.Count()} movement(s)")
        Next
    End Sub
End Module
