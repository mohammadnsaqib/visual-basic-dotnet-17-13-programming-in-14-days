' The lambda holds the variable, not a copy of its value at the time it was written.
Imports System
Imports System.Collections.Generic
Imports System.Linq

Module Program
    Sub Main()
        Dim amounts As New List(Of Decimal)() From {120D, 1200D, 87.5D, 900D}
        Dim floor As Decimal = 500D

        Dim over = amounts.Where(Function(amount) amount >= floor)
        Console.WriteLine($"with floor {floor:N2} : {String.Join(", ", over)}")

        floor = 1000D
        Console.WriteLine($"with floor {floor:N2} : {String.Join(", ", over)}")

        floor = 0D
        Console.WriteLine($"with floor {floor:N2} : {String.Join(", ", over)}")
        Console.WriteLine("one query, three answers, and the query was written once")
    End Sub
End Module
