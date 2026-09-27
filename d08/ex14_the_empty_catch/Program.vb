' A Catch that does nothing, and the defect it keeps out of sight.
Imports System
Imports System.Collections.Generic

Module Program
    Function TotalQuietly(texts As IEnumerable(Of String)) As Decimal
        Dim total As Decimal = 0D
        For Each reading In texts
            Try
                total += Decimal.Parse(reading)
            Catch
            End Try
        Next
        Return total
    End Function

    Function TotalHonestly(texts As IEnumerable(Of String)) As Decimal
        Dim total As Decimal = 0D
        Dim refused As Integer = 0
        For Each reading In texts
            Dim amount As Decimal
            If Decimal.TryParse(reading, amount) Then
                total += amount
            Else
                refused += 1
            End If
        Next
        Console.WriteLine($"  {refused} of " &
                          $"{TryCast(texts, ICollection(Of String)).Count} refused")
        Return total
    End Function

    Sub Main()
        Dim readings As New List(Of String)() From {"100.00", "2O0.00", "300.00"}
        Console.WriteLine($"quiet total   : {TotalQuietly(readings):N2}")
        Console.WriteLine("honest total:")
        Console.WriteLine($"  came to      {TotalHonestly(readings):N2}")
        Console.WriteLine("the second reading has a letter O in it, and both totals " &
                          "are 400.00")
    End Sub
End Module
