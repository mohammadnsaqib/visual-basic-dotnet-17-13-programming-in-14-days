' Reading text back into objects, including text that does not fit.
Imports System
Imports System.Text.Json

Public Class AccountRow
    Public Property Code As String
    Public Property Balance As Decimal
End Class

Module Program
    Sub Try_(caption As String, text As String)
        Try
            Dim row = JsonSerializer.Deserialize(Of AccountRow)(text)
            Console.WriteLine($"{caption,-18}: {row.Code} {row.Balance:N2}")
        Catch ex As JsonException
            Console.WriteLine($"{caption,-18}: {ex.GetType().Name}")
        End Try
    End Sub

    Sub Main()
        Try_("complete", "{""Code"":""AC-1000"",""Balance"":3800.00}")
        Try_("field missing", "{""Code"":""AC-1000""}")
        Try_("extra field", "{""Code"":""AC-1000"",""Balance"":10,""Extra"":1}")
        Try_("wrong case", "{""code"":""AC-1000"",""balance"":25}")
        Try_("wrong type", "{""Code"":""AC-1000"",""Balance"":""lots""}")
        Try_("not json", "AC-1000")
    End Sub
End Module
