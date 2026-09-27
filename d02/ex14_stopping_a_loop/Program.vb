' A loop with no way out is stopped by giving it one.
Imports System

Module Program
    Sub Main()
        Dim guard As Integer = 0
        Dim value As Integer = 27
        Do
            value = If(value Mod 2 = 0, value \ 2, 3 * value + 1)
            guard += 1
            If guard > 200 Then
                Console.WriteLine("the guard stopped it")
                Exit Do
            End If
        Loop Until value = 1
        Console.WriteLine($"reached 1 after {guard} steps")
    End Sub
End Module
