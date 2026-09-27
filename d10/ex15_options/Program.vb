' The same value, written three ways. The options change the text and not the meaning.
Imports System
Imports System.Text.Json
Imports System.Text.Json.Serialization

Public Class AccountRow
    Public Property Code As String
    Public Property Name As String
    Public Property Balance As Decimal
End Class

Module Program
    Sub Main()
        Dim row As New AccountRow With {.Code = "AC-1000", .Name = Nothing,
                                        .Balance = 3800D}

        Console.WriteLine("plain:")
        Console.WriteLine($"  {JsonSerializer.Serialize(row)}")

        Dim indented As New JsonSerializerOptions With {.WriteIndented = True}
        Console.WriteLine("indented:")
        For Each line In JsonSerializer.Serialize(row, indented).Split(vbLf)
            Console.WriteLine($"  {line.TrimEnd()}")
        Next

        Dim tidy As New JsonSerializerOptions With {
            .WriteIndented = False,
            .DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull}
        Console.WriteLine("nulls left out:")
        Console.WriteLine($"  {JsonSerializer.Serialize(row, tidy)}")
    End Sub
End Module
