' A lambda is a function with no name, and it can read the variables around it.
Imports System
Imports System.Collections.Generic
Imports System.Linq

Module Program
    Sub Main()
        Dim amounts As New List(Of Decimal)() From {120D, 1200D, 87.5D, 900D}
        Dim floor As Decimal = 500D

        Dim over = amounts.Where(Function(amount) amount >= floor)
        Console.WriteLine($"floor {floor:N2} : {String.Join(", ", over)}")

        Dim doubled = amounts.Select(Function(amount) amount * 2D)
        Console.WriteLine($"doubled  : {String.Join(", ", doubled)}")

        Dim describe As Func(Of Decimal, String) =
            Function(amount) If(amount >= floor, "large", "small")
        Console.WriteLine($"120 is   : {describe(120D)}")
        Console.WriteLine($"1200 is  : {describe(1200D)}")

        Dim counted As Integer = 0
        Dim tally As Action(Of Decimal) = Sub(amount) counted += 1
        For Each amount In amounts
            tally(amount)
        Next
        Console.WriteLine($"the Sub lambda counted : {counted}")
    End Sub
End Module
