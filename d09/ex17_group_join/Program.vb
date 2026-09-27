' Group Join keeps every row on the left, with its matches gathered beside it.
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
        Dim names As New List(Of AccountName)() From {
            New AccountName("AC-1000", "Cash"),
            New AccountName("AC-1001", "Rent"),
            New AccountName("AC-4000", "Sales")}
        Dim movements As New List(Of Movement)() From {
            New Movement("AC-1000", 1200D),
            New Movement("AC-1000", 87.5D),
            New Movement("AC-4000", 900D)}

        Dim withTheirs = From account In names
                         Group Join movement In movements
                         On account.Code Equals movement.Code
                         Into Theirs = Group, Made = Count()
                         Select account.Code, account.Name, Theirs, Made

        For Each row In withTheirs
            Console.WriteLine($"  {row.Code} {row.Name,-8} {row.Made} movement(s)")
            For Each movement In row.Theirs
                Console.WriteLine($"      {movement.Amount,9:N2}")
            Next
        Next
        Console.WriteLine("Rent has none, and it is still in the report")
    End Sub
End Module
