' Every logical operator, on every pair of inputs.
Imports System

Module Program
    Sub Main()
        Console.WriteLine($"{"a",-6}{"b",-6}{"And",-6}{"Or",-6}{"Xor",-6}{"Not a",-6}")
        For Each a In {False, True}
            For Each b In {False, True}
                Dim ops = $"{a And b,-6}{a Or b,-6}{a Xor b,-6}{Not a,-6}"
                Console.WriteLine($"{a,-6}{b,-6}" & ops)
            Next
        Next
    End Sub
End Module
