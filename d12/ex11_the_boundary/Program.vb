' The interesting values are the ones on either side of a decision.
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Module Program
    Function Fee(amount As Decimal) As Decimal
        If amount > 1000D Then
            Return amount * 0.02D
        End If
        Return 0D
    End Function

    Sub Row(amount As Decimal, expected As Decimal)
        Try
            Assert.AreEqual(expected, Fee(amount))
            Console.WriteLine($"  {amount,9:N2} -> {Fee(amount),8:N2}  as expected")
        Catch ex As AssertFailedException
            Console.WriteLine($"  {amount,9:N2} -> {Fee(amount),8:N2}  FAILED")
        End Try
    End Sub

    Sub Main()
        Row(999.99D, 0D)
        Row(1000D, 0D)
        Row(1000.01D, 20.0002D)
        Row(2000D, 40D)
        Console.WriteLine("1000.00 pays nothing and 1000.01 pays, which is what > " &
                          "means")
    End Sub
End Module
