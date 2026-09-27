' Four sets of data through one piece of code, each reported on its own.
Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Tally

Module Program
    Function Balanced(debit As Decimal, credit As Decimal) As Decimal
        Dim books As New Ledger()
        books.Open("AC-1000", "Cash")
        books.Open("AC-4000", "Sales")
        books.PostEntry(New Debit("AC-1000", debit), New Credit("AC-4000", credit))
        Return books.Balance
    End Function

    Sub Row(debit As Decimal, credit As Decimal, expected As Decimal)
        Try
            Assert.AreEqual(expected, Balanced(debit, credit))
            Console.WriteLine($"  {debit,9:N2} {credit,9:N2} : passed")
        Catch ex As AssertFailedException
            Console.WriteLine($"  {debit,9:N2} {credit,9:N2} : FAILED")
        Catch ex As LedgerError
            Console.WriteLine($"  {debit,9:N2} {credit,9:N2} : refused, {ex.Message}")
        End Try
    End Sub

    Sub Main()
        Row(1200D, 1200D, 0D)
        Row(500D, 500D, 0D)
        Row(0.5D, 0.5D, 0D)
        Row(87.5D, 87.5D, 0D)
        Console.WriteLine("four rows, four results, and one piece of code")
    End Sub
End Module
