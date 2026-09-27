' If, ElseIf and Else: exactly one of them runs.
Imports System

Module Program
    Sub Main()
        For Each balance In {-250D, 0D, 1200D}
            If balance < 0D Then
                Console.WriteLine($"{balance,8} overdrawn")
            ElseIf balance = 0D Then
                Console.WriteLine($"{balance,8} empty")
            Else
                Console.WriteLine($"{balance,8} in credit")
            End If
        Next
    End Sub
End Module
