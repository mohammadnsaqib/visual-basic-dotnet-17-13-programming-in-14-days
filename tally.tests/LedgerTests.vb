' Day 12. The tests for the ledger.

Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Tally

Namespace Tests

    ' --8<-- shape
    <TestClass>
    Public Class LedgerTests

        <TestMethod>
        Public Sub Open_gives_an_account_with_the_code_and_name()
            Dim books As New Ledger()
            Dim account = books.Open("AC-1000", "Cash")

            Assert.AreEqual("AC-1000", account.Code)
            Assert.AreEqual("Cash", account.Name)
            Assert.AreEqual(0D, account.Balance)
            Assert.AreEqual(1, books.Count)
        End Sub
        ' --8<--

        <TestMethod>
        Public Sub Open_refuses_a_code_already_in_use()
            Dim books As New Ledger()
            books.Open("AC-1000", "Cash")

            Assert.ThrowsExactly(Of ArgumentException)(
                Sub() books.Open("AC-1000", "Cash again"))
            Assert.AreEqual(1, books.Count)
        End Sub

        <TestMethod>
        Public Sub Find_gives_Nothing_for_a_code_that_is_not_open()
            Dim books As New Ledger()
            books.Open("AC-1000", "Cash")

            Assert.IsNotNull(books.Find("ac-1000"))
            Assert.IsNull(books.Find("AC-9999"))
        End Sub

        ' --8<-- balance
        <TestMethod>
        Public Sub A_balanced_entry_leaves_the_books_at_zero()
            Dim books As New Ledger()
            books.Open("AC-1000", "Cash")
            books.Open("AC-4000", "Sales")

            books.PostEntry(New Debit("AC-1000", 1200D), New Credit("AC-4000", 1200D))

            Assert.AreEqual(0D, books.Balance)
            Assert.AreEqual(1200D, books.Find("AC-1000").Balance)
            Assert.AreEqual(-1200D, books.Find("AC-4000").Balance)
            Assert.HasCount(2, books.Postings)
        End Sub

        <TestMethod>
        Public Sub An_unbalanced_entry_is_refused_and_changes_nothing()
            Dim books As New Ledger()
            books.Open("AC-1000", "Cash")
            books.Open("AC-4000", "Sales")

            Dim failure = Assert.ThrowsExactly(Of LedgerError)(
                Sub() books.PostEntry(New Debit("AC-1000", 1200D),
                                      New Credit("AC-4000", 1100D)))

            StringAssert.Contains(failure.Message, "out by")
            Assert.IsEmpty(books.Postings)
            Assert.AreEqual(0D, books.Find("AC-1000").Balance)
        End Sub
        ' --8<--

        <TestMethod>
        Public Sub An_entry_naming_an_account_that_is_not_open_is_refused()
            Dim books As New Ledger()
            books.Open("AC-1000", "Cash")

            Dim failure = Assert.ThrowsExactly(Of LedgerError)(
                Sub() books.PostEntry(New Debit("AC-1000", 10D),
                                      New Credit("AC-9999", 10D)))

            Assert.AreEqual("AC-9999", failure.Account)
            Assert.IsEmpty(books.Postings)
        End Sub

        ' --8<-- rows
        <TestMethod>
        <DataRow(1200.0R, 1200.0R, 0.0R)>
        <DataRow(500.0R, 500.0R, 0.0R)>
        <DataRow(0.5R, 0.5R, 0.0R)>
        <DataRow(87.5R, 87.5R, 0.0R)>
        Public Sub A_debit_and_a_matching_credit_leave_the_books_at_zero(
                debit As Double, credit As Double, expected As Double)
            Dim books As New Ledger()
            books.Open("AC-1000", "Cash")
            books.Open("AC-4000", "Sales")

            books.PostEntry(New Debit("AC-1000", CDec(debit)),
                            New Credit("AC-4000", CDec(credit)))

            Assert.AreEqual(CDec(expected), books.Balance)
        End Sub
        ' --8<--

    End Class

End Namespace
