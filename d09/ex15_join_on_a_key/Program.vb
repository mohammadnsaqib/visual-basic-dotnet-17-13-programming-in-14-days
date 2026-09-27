' A join matches two sequences on a key and produces one row per match.
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

Public Class AccountName
    Public ReadOnly Property Code As String
    Public ReadOnly Property Name As String

    Public Sub New(code As String, name As String)
        _Code = code
        _Name = name
    End Sub
End Class

Module Program
    Sub Main()
        Dim movements As New List(Of Movement)() From {
            New Movement("AC-1000", 1200D),
            New Movement("AC-1001", 87.5D),
            New Movement("AC-4000", 900D)}
        Dim names As New List(Of AccountName)() From {
            New AccountName("AC-1000", "Cash"),
            New AccountName("AC-1001", "Rent"),
            New AccountName("AC-4000", "Sales")}

        Dim described = From movement In movements
                        Join account In names
                        On movement.Code Equals account.Code
                        Order By movement.Amount Descending
                        Select account.Name, movement.Amount

        For Each row In described
            Console.WriteLine($"  {row.Name,-8} {row.Amount,9:N2}")
        Next
        Console.WriteLine($"rows : {described.Count()}")
    End Sub
End Module
