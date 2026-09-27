' An object turned into text. What is written is what is public.
Imports System
Imports System.Text.Json

Public Class AccountRow
    Public Property Code As String
    Public Property Name As String
    Public Property Balance As Decimal
End Class

Module Program
    Sub Main()
        Dim row As New AccountRow With {.Code = "AC-1000", .Name = "Cash",
                                        .Balance = 3800D}

        Dim text = JsonSerializer.Serialize(row)
        Console.WriteLine($"json    : {text}")
        Console.WriteLine($"length  : {text.Length}")

        Dim back = JsonSerializer.Deserialize(Of AccountRow)(text)
        Console.WriteLine($"code    : {back.Code}")
        Console.WriteLine($"name    : {back.Name}")
        Console.WriteLine($"balance : {back.Balance:N2}")
    End Sub
End Module
