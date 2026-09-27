' An assertion that cannot fail is a line of code, not a test.
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Tally

Module Program
    Function Fee(amount As Decimal) As Decimal
        If amount > 1000D Then
            Return amount * 0.02D
        End If
        Return 0D
    End Function

    Sub Report(caption As String, act As Action)
        Try
            act()
            Console.WriteLine($"{caption,-28}: passed")
        Catch ex As AssertFailedException
            Console.WriteLine($"{caption,-28}: FAILED")
        End Try
    End Sub

    Sub Main()
        Report("Fee(2000) is not negative", Sub() Assert.IsTrue(Fee(2000D) >= 0D))
        Report("Fee(2000) is a Decimal",
               Sub() Assert.IsInstanceOfType(Of Decimal)(Fee(2000D)))
        Report("Fee(2000) is 40.00", Sub() Assert.AreEqual(40D, Fee(2000D)))

        Console.WriteLine("the first two pass for a Fee that always returns 0:")
        Console.WriteLine($"  0 >= 0        : {0D >= 0D}")
        Console.WriteLine($"  0 is a Decimal: {TypeOf CObj(0D) Is Decimal}")
        Console.WriteLine($"  0 = 40.00     : {0D = 40D}")
    End Sub
End Module
