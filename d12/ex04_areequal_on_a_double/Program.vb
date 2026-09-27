' The same assertion on a type that does not hold what it was given.
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Module Program
    Sub Report(caption As String, act As Action)
        Try
            act()
            Console.WriteLine($"{caption,-12}: passed")
        Catch ex As AssertFailedException
            Console.WriteLine($"{caption,-12}: {ex.Message}")
        End Try
    End Sub

    Sub Main()
        Dim total As Double = 0.1 + 0.2
        Console.WriteLine($"0.1 + 0.2 as a Double : {total:R}")
        Report("Double", Sub() Assert.AreEqual(0.3, total))

        Dim exact As Decimal = 0.1D + 0.2D
        Console.WriteLine($"0.1 + 0.2 as a Decimal: {exact}")
        Report("Decimal", Sub() Assert.AreEqual(0.3D, exact))
    End Sub
End Module
