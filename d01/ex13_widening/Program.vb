' A widening conversion cannot lose anything, so it needs no permission.
Imports System

Module Program
    Sub Main()
        Dim small As Integer = 2147483647
        Dim wider As Long = small
        Dim floating As Double = small
        Dim exact As Decimal = small

        Console.WriteLine($"Integer  {small}")
        Console.WriteLine($"Long     {wider}")
        Console.WriteLine($"Double   {floating:R}")
        Console.WriteLine($"Decimal  {exact}")
        Console.WriteLine($"Double kept every digit: {floating = small}")
    End Sub
End Module
