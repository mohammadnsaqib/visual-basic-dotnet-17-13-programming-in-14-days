' Two ways to answer one question, and the difference is not in the answer.
Imports System
Imports System.Collections.Generic
Imports System.Linq

Module Program
    Function LargestByQuery(amounts As List(Of Decimal)) As Decimal
        Return (From amount In amounts Order By amount Descending Select amount).First()
    End Function

    Function LargestBySorting(amounts As List(Of Decimal)) As Decimal
        Dim sorted = amounts.OrderByDescending(Function(amount) amount).ToList()
        Return sorted(0)
    End Function

    Function LargestByLoop(amounts As List(Of Decimal)) As Decimal
        Dim best As Decimal = Decimal.MinValue
        For Each amount In amounts
            If amount > best Then
                best = amount
            End If
        Next
        Return best
    End Function

    Sub Main()
        Dim amounts As New List(Of Decimal)(10000)
        For i = 1 To 10000
            amounts.Add(CDec(i Mod 977) + 0.5D)
        Next

        LargestByQuery(amounts)
        LargestBySorting(amounts)
        LargestByLoop(amounts)

        Dim before = GC.GetAllocatedBytesForCurrentThread()
        Dim byQuery = LargestByQuery(amounts)
        Dim afterQuery = GC.GetAllocatedBytesForCurrentThread()
        Dim byLoop = LargestByLoop(amounts)
        Dim afterLoop = GC.GetAllocatedBytesForCurrentThread()
        Dim bySorting = LargestBySorting(amounts)
        Dim afterSorting = GC.GetAllocatedBytesForCurrentThread()

        Console.WriteLine($"three answers   : {byQuery}, {byLoop} and {bySorting}")
        Console.WriteLine($"query allocated : {afterQuery - before} bytes")
        Console.WriteLine($"loop allocated  : {afterLoop - afterQuery} bytes")
        Console.WriteLine($"sorting allocated : {afterSorting - afterLoop} bytes")
        Console.WriteLine("the first query never sorted anything, and the " &
                          "measurement says so")
    End Sub
End Module
