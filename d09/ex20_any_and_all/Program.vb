' The questions that stop as soon as they are answered.
Imports System
Imports System.Collections.Generic
Imports System.Linq

Module Program
    Sub Main()
        Dim amounts As New List(Of Decimal)() From {1200D, 87.5D, 450D}
        Dim tested As Integer = 0

        Dim isLarge = Function(amount As Decimal) As Boolean
                          tested += 1
                          Return amount >= 500D
                      End Function

        Console.WriteLine($"any large  : {amounts.Any(isLarge)}, after {tested} " &
                          $"test(s)")
        tested = 0
        Console.WriteLine($"all large  : {amounts.All(isLarge)}, after {tested} " &
                          $"test(s)")
        Console.WriteLine($"any at all : {amounts.Any()}")

        Dim empty As New List(Of Decimal)()
        Console.WriteLine($"any of nothing : {empty.Any()}")
        Console.WriteLine($"all of nothing : {empty.All(Function(amount) amount > 0D)}")

        Try
            Console.WriteLine(empty.First())
        Catch ex As InvalidOperationException
            Console.WriteLine($"First of nothing : {ex.GetType().Name}")
        End Try
        Console.WriteLine($"FirstOrDefault   : {empty.FirstOrDefault():N2}")
    End Sub
End Module
