' A tolerance says how close is close enough, and choosing it is part of the test.
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Module Program
    Sub Report(caption As String, act As Action)
        Try
            act()
            Console.WriteLine($"{caption,-24}: passed")
        Catch ex As AssertFailedException
            Console.WriteLine($"{caption,-24}: failed")
        End Try
    End Sub

    Sub Main()
        Dim total As Double = 0.1 + 0.2
        Console.WriteLine($"the difference : {Math.Abs(total - 0.3):E2}")

        Report("no tolerance", Sub() Assert.AreEqual(0.3, total))
        Report("delta 0.000000000000001",
               Sub() Assert.AreEqual(0.3, total, 0.000000000000001))
        Report("delta 0.0000001", Sub() Assert.AreEqual(0.3, total, 0.0000001))
        Report("delta 1.0", Sub() Assert.AreEqual(0.3, total, 1.0))
        Console.WriteLine("the last one passes for 1.29 as well, and proves nothing")
    End Sub
End Module
