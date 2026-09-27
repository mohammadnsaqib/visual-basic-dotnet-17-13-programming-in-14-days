' Aggregate is the general reduction, and the seed decides where it starts.
Imports System
Imports System.Collections.Generic
Imports System.Linq

Module Program
    Sub Main()
        Dim amounts As New List(Of Decimal)() From {1200D, 87.5D, 450D}

        Dim total = amounts.Aggregate(0D, Function(running, amount) running + amount)
        Console.WriteLine($"total from a seed of 0 : {total:N2}")

        Dim fromOpening = amounts.Aggregate(5000D,
                                            Function(running, amount) running - amount)
        Console.WriteLine($"5000 less each of them : {fromOpening:N2}")

        Dim codes As New List(Of String)() From {"AC-1000", "AC-1001-SUB", "AC-4000"}
        Dim joined = codes.Aggregate(Function(running, code) running & " | " & code)
        Console.WriteLine($"with no seed : {joined}")

        Dim widest = codes.Aggregate("", Function(running, code) _
            If(code.Length > running.Length, code, running))
        Console.WriteLine($"longest code : {widest}")

        Dim empty As New List(Of Decimal)()
        Console.WriteLine($"seeded aggregate of nothing : " &
            $"{empty.Aggregate(99D, Function(running, amount) running + amount):N2}")
    End Sub
End Module
