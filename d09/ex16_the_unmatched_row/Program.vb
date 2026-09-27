' A join keeps only what matches. What does not match is not reported; it is absent.
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
            New Movement("AC-9999", 500D),
            New Movement("AC-4000", 900D)}
        Dim names As New List(Of AccountName)() From {
            New AccountName("AC-1000", "Cash"),
            New AccountName("AC-4000", "Sales")}

        Dim described = From movement In movements
                        Join account In names
                        On movement.Code Equals account.Code
                        Select account.Name, movement.Amount

        Console.WriteLine($"movements : {movements.Count}")
        Console.WriteLine($"rows out  : {described.Count()}")
        Console.WriteLine($"total in  : {movements.Sum(Function(m) m.Amount):N2}")
        Console.WriteLine($"total out : {described.Sum(Function(r) r.Amount):N2}")

        Dim missing = From movement In movements
                      Where Not names.Any(Function(a) a.Code = movement.Code)
                      Select movement.Code
        Console.WriteLine($"dropped   : {String.Join(", ", missing)}")
    End Sub
End Module
