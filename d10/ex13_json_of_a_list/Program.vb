' A list of objects. The shape of the text follows the shape of the value.
Imports System
Imports System.Collections.Generic
Imports System.Text.Json

Public Class AccountRow
    Public Property Code As String
    Public Property Balance As Decimal
End Class

Module Program
    Sub Main()
        Dim rows As New List(Of AccountRow)() From {
            New AccountRow With {.Code = "AC-1000", .Balance = 3800D},
            New AccountRow With {.Code = "AC-1001", .Balance = 1200D}}

        Dim text = JsonSerializer.Serialize(rows)
        Console.WriteLine($"json  : {text}")

        Dim back = JsonSerializer.Deserialize(Of List(Of AccountRow))(text)
        Console.WriteLine($"count : {back.Count}")
        For Each row In back
            Console.WriteLine($"  {row.Code} {row.Balance:N2}")
        Next

        Dim empty = JsonSerializer.Serialize(New List(Of AccountRow)())
        Console.WriteLine($"empty : {empty}")
    End Sub
End Module
