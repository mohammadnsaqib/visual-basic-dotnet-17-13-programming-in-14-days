' A Sub performs; a Function answers.
Imports System

Module Program
    Sub Main()
        Report(1200D, 0.05D)
        Dim earned = Interest(1200D, 0.05D)
        Console.WriteLine($"the Function handed back {earned}")
    End Sub

    Sub Report(amount As Decimal, rate As Decimal)
        Console.WriteLine($"the Sub printed {amount * rate}")
    End Sub

    Function Interest(amount As Decimal, rate As Decimal) As Decimal
        Return amount * rate
    End Function
End Module
