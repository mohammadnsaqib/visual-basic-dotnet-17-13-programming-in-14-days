' What a failed assertion says, and how much of it was written by the author.
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Module Program
    Sub Report(act As Action)
        Try
            act()
            Console.WriteLine("passed")
        Catch ex As AssertFailedException
            Console.WriteLine($"failed : {ex.Message}")
        End Try
    End Sub

    Sub Main()
        Report(Sub() Assert.AreEqual(1200D, 1200D))
        Report(Sub() Assert.AreEqual(1200D, 1100D))
        Report(Sub() Assert.AreEqual("Cash", "Petty cash"))
        Report(Sub() Assert.AreEqual(1200D, 1100D, "the rent posting is wrong"))
        Report(Sub() Assert.IsTrue(1100D >= 1200D))
        Report(Sub() Assert.IsTrue(1100D >= 1200D, "the balance is below the floor"))
    End Sub
End Module
