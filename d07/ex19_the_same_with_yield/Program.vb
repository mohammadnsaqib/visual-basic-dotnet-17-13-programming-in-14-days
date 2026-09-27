' The same sequence, written as an iterator. The compiler supplies the enumerator.
Imports System
Imports System.Collections.Generic

Module Program
    Iterator Function Countdown(from As Integer) As IEnumerable(Of Integer)
        Dim now As Integer = from
        While now >= 1
            Yield now
            now -= 1
        End While
    End Function

    Iterator Function Announced(from As Integer) As IEnumerable(Of Integer)
        For n = from To 1 Step -1
            Console.WriteLine($"    the iterator is producing {n}")
            Yield n
        Next
    End Function

    Sub Main()
        For Each n In Countdown(5)
            Console.Write($"{n} ")
        Next
        Console.WriteLine()

        Console.WriteLine("asking for two of three:")
        Dim taken As Integer = 0
        For Each n In Announced(3)
            Console.WriteLine($"  the loop received {n}")
            taken += 1
            If taken = 2 Then
                Exit For
            End If
        Next
        Console.WriteLine($"received {taken}, and the third was never produced")
    End Sub
End Module
