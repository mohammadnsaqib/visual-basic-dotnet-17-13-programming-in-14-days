' A structure variable holds a value before anything is assigned to it. A class variable
' does not.
Imports System

Structure Reading
    Public Value As Double
    Public Label As String
End Structure

Class Sample
    Public Value As Double
End Class

Module Program
    Sub Main()
        Dim r As Reading
        Dim s As Sample = Nothing

        Console.WriteLine($"structure number field : {r.Value}")
        Console.WriteLine($"structure text field   : [{If(r.Label, "empty")}]")
        Console.WriteLine($"class variable         : " &
                          $"{If(s Is Nothing, "Nothing", "an object")}")

        Dim t As New Reading()
        t.Value = 7.5
        t.Label = "before"
        t = Nothing
        Console.WriteLine($"after assigning Nothing to a structure:")
        Console.WriteLine($"  number field : {t.Value}")
        Console.WriteLine($"  text field   : [{If(t.Label, "empty")}]")
    End Sub
End Module
