' Exit For leaves the loop; a flag only pretends to.
Imports System

Module Program
    Sub Main()
        Dim codes = {4, 9, 16, 25, 36}
        Dim checked As Integer = 0
        For Each code In codes
            checked += 1
            If code > 15 Then Exit For
        Next
        Console.WriteLine($"Exit For looked at {checked} of {codes.Length}")

        Dim found As Boolean = False
        checked = 0
        For Each code In codes
            If Not found Then
                checked += 1
                If code > 15 Then found = True
            End If
        Next
        Console.WriteLine($"the flag looked at {checked}, and the loop still ran " &
                          $"{codes.Length} times")
    End Sub
End Module
