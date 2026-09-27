' A value saved and loaded is only the same value if something checks.
Imports System
Imports System.Collections.Generic
Imports System.Text.Json

Public Class AccountRow
    Implements IEquatable(Of AccountRow)

    Public Property Code As String
    Public Property Name As String
    Public Property Balance As Decimal

    Public Overloads Function Equals(other As AccountRow) As Boolean _
            Implements IEquatable(Of AccountRow).Equals
        Return other IsNot Nothing AndAlso Code = other.Code AndAlso
               Name = other.Name AndAlso Balance = other.Balance
    End Function
End Class

Module Program
    Sub Main()
        Dim rows As New List(Of AccountRow)() From {
            New AccountRow With {.Code = "AC-1000", .Name = "Cash", .Balance = 3800D},
            New AccountRow With {.Code = "AC-1001", .Name = "Rent",
                                 .Balance = 1200.505D},
            New AccountRow With {.Code = "AC-4000", .Name = Nothing, .Balance = -5000D}}

        Dim text = JsonSerializer.Serialize(rows)
        Dim back = JsonSerializer.Deserialize(Of List(Of AccountRow))(text)

        Console.WriteLine($"out : {rows.Count} row(s)")
        Console.WriteLine($"in  : {back.Count} row(s)")
        Dim same As Integer = 0
        For i = 0 To rows.Count - 1
            If rows(i).Equals(back(i)) Then
                same += 1
            Else
                Console.WriteLine($"  row {i} differs")
            End If
        Next
        Console.WriteLine($"equal rows : {same} of {rows.Count}")
        Console.WriteLine($"a decimal with three places survived : {back(1).Balance}")
        Console.WriteLine($"and Nothing came back as Nothing : " &
                          $"{back(2).Name Is Nothing}")
    End Sub
End Module
