' Split gives back what is between the separators, including nothing.
Imports System

Module Program
    Sub Main()
        Dim row As String = "2026-09-10,,rent,,1200.00"
        Dim parts = row.Split(","c)
        Console.WriteLine($"fields : {parts.Length}")
        For i = 0 To parts.Length - 1
            Console.WriteLine($"  {i}: [{parts(i)}]")
        Next
    End Sub
End Module
