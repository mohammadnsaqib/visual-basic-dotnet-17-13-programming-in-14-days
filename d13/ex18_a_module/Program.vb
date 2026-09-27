' A module's members need no instance, and its name need not be written.
Imports System

Public Module Rounding

    Public ReadOnly Places As Integer = 2

    Public Function ToPennies(amount As Decimal) As Decimal
        Return Decimal.Round(amount, Places, MidpointRounding.ToEven)
    End Function

    Public Function Describe(amount As Decimal) As String
        Return $"{ToPennies(amount):N2}"
    End Function
End Module

Module Program
    Sub Main()
        Console.WriteLine($"places        : {Places}")
        Console.WriteLine($"0.125         : {ToPennies(0.125D)}")
        Console.WriteLine($"0.135         : {Rounding.ToPennies(0.135D)}")
        Console.WriteLine($"described     : {Describe(1234.567D)}")
        Console.WriteLine($"the type is   : {GetType(Rounding).Name}")
        Console.WriteLine($"is it sealed  : {GetType(Rounding).IsSealed}")
        Console.WriteLine($"is it abstract: {GetType(Rounding).IsAbstract}")
    End Sub
End Module
