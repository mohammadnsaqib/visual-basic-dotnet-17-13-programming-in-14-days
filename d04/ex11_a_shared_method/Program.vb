' A Shared method has no instance, so it can only use what it is given.
Imports System

Public Class Money
    Public Shared Function Parse(text As String) As Decimal
        Return Decimal.Parse(text.Trim().Replace(",", ""),
                             Globalization.CultureInfo.InvariantCulture)
    End Function

    Public Shared ReadOnly Property Zero As Decimal
        Get
            Return 0D
        End Get
    End Property
End Class

Module Program
    Sub Main()
        Console.WriteLine($"Parse("" 1,200.50 "") : {Money.Parse(" 1,200.50 ")}")
        Console.WriteLine($"Parse(""-40"")        : {Money.Parse("-40")}")
        Console.WriteLine($"Zero                : {Money.Zero}")
        Console.WriteLine("no object was made to call either of those")
    End Sub
End Module
