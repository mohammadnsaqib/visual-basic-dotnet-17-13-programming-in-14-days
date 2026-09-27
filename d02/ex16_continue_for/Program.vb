' Continue For skips the rest of one pass and starts the next.
Imports System

Module Program
    Sub Main()
        Dim total As Integer = 0
        Dim skipped As Integer = 0
        For i = 1 To 10
            If i Mod 3 = 0 Then
                skipped += 1
                Continue For
            End If
            total += i
        Next
        Console.WriteLine($"skipped {skipped} of 10")
        Console.WriteLine($"total of the rest is {total}")
    End Sub
End Module
