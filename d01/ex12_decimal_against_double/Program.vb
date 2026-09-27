' Double is binary and Decimal is not, and money is decimal.
Imports System

Module Program
    Sub Main()
        Dim asDouble As Double = 0.1 + 0.2
        Dim asDecimal As Decimal = 0.1D + 0.2D

        Console.WriteLine($"Double  0.1 + 0.2 = {asDouble:R}")
        Console.WriteLine($"Decimal 0.1 + 0.2 = {asDecimal}")
        Console.WriteLine($"Double  equals 0.3 : {asDouble = 0.3}")
        Console.WriteLine($"Decimal equals 0.3 : {asDecimal = 0.3D}")

        Dim cents As Double = 0.0
        For i = 1 To 10
            cents += 0.1
        Next
        Console.WriteLine($"ten tenths as Double : {cents:R}")
    End Sub
End Module
