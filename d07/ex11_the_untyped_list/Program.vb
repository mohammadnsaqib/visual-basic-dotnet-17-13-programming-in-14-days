' The collection that holds anything, and what that costs at the point of reading.
Imports System
Imports System.Collections
Imports System.Collections.Generic

Module Program
    Sub Main()
        Dim anything As New ArrayList()
        anything.Add(10)
        anything.Add(20)
        anything.Add("thirty")

        Console.WriteLine($"count : {anything.Count}")
        Console.WriteLine($"item 0 arrives as : {anything(0).GetType().Name}")

        Dim total As Integer = 0
        Try
            For i = 0 To anything.Count - 1
                total += CInt(anything(i))
            Next
        Catch ex As InvalidCastException
            Console.WriteLine($"reading item 2 threw : {ex.GetType().Name}")
        End Try
        Console.WriteLine($"total reached : {total}")

        Dim numbers As New List(Of Integer)()
        numbers.Add(10)
        numbers.Add(20)
        Console.WriteLine($"the typed list would not have compiled the third Add")
        Console.WriteLine($"typed total : {numbers(0) + numbers(1)}")
    End Sub
End Module
