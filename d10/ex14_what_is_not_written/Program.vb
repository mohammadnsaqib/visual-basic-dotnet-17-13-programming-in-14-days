' Three members that do not appear in the text, for three different reasons.
Imports System
Imports System.Text.Json
Imports System.Text.Json.Serialization

Public Class AccountRow
    Public Property Code As String

    <JsonIgnore>
    Public Property Working As String = "not for the file"

    Private Property Secret As String = "never seen"

    Public Field As String = "a field, not a property"

    Public ReadOnly Property Described As String
        Get
            Return $"{Code} is derived"
        End Get
    End Property
End Class

Module Program
    Sub Main()
        Dim row As New AccountRow With {.Code = "AC-1000"}
        Console.WriteLine($"json : {JsonSerializer.Serialize(row)}")

        Dim withFields As New JsonSerializerOptions With {.IncludeFields = True}
        Console.WriteLine($"with fields : {JsonSerializer.Serialize(row, withFields)}")

        Dim back = JsonSerializer.Deserialize(Of AccountRow)("{""Code"":""AC-2000""," &
            """Described"":""ignored""}")
        Console.WriteLine($"code      : {back.Code}")
        Console.WriteLine($"described : {back.Described}")
        Console.WriteLine($"working   : {back.Working}")
    End Sub
End Module
