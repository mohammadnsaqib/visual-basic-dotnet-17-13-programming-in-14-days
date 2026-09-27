' Day 12. The tests for the value type, where the rounding rule lives.

Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Tally

Namespace Tests

    <TestClass>
    Public Class MoneyTests

        <TestMethod>
        Public Sub Money_adds_and_subtracts()
            Dim rent As New Money(1200D)
            Dim tax As New Money(87.5D)

            Assert.AreEqual(New Money(1287.5D), rent + tax)
            Assert.AreEqual(New Money(1112.5D), rent - tax)
            Assert.AreEqual(New Money(-87.5D), -tax)
        End Sub

        <TestMethod>
        <DataRow(0.125R, 0.12R)>
        <DataRow(0.135R, 0.14R)>
        <DataRow(0.145R, 0.14R)>
        <DataRow(1.005R, 1.0R)>
        Public Sub Money_rounds_to_the_nearest_even_penny(given As Double, expected As Double)
            Assert.AreEqual(CDec(expected), New Money(CDec(given)).Amount)
        End Sub

        <TestMethod>
        Public Sub Two_equal_amounts_are_equal_and_hash_alike()
            Dim one As New Money(12.5D)
            Dim other As New Money(12.5D)

            Assert.AreEqual(one, other)
            Assert.IsTrue(one = other)
            Assert.AreEqual(one.GetHashCode(), other.GetHashCode())
        End Sub

    End Class

End Namespace
