' Assert is an ordinary class. A test runner is what usually catches what it throws.
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Tally

Module Program
    Sub Check(caption As String, act As Action)
        Try
            act()
            Console.WriteLine($"{caption,-22}: passed")
        Catch ex As AssertFailedException
            Console.WriteLine($"{caption,-22}: FAILED")
            Console.WriteLine($"  {ex.Message}")
        End Try
    End Sub

    Sub Main()
        Dim books As New Ledger()
        Dim account = books.Open("AC-1000", "Cash")

        Check("the code", Sub() Assert.AreEqual("AC-1000", account.Code))
        Check("the name", Sub() Assert.AreEqual("Cash", account.Name))
        Check("the balance", Sub() Assert.AreEqual(0D, account.Balance))
        Check("a wrong name", Sub() Assert.AreEqual("Petty cash", account.Name))
        Console.WriteLine("a test project has a runner that does what Check does here")
    End Sub
End Module
