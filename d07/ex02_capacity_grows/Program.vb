' A list is an array underneath. Watching Capacity shows when a new array is made.
Imports System
Imports System.Collections.Generic

Module Program
    Sub Main()
        Dim numbers As New List(Of Integer)()
        Dim capacity As Integer = numbers.Capacity
        Console.WriteLine($"count 0 : capacity {capacity}")

        For i = 1 To 40
            numbers.Add(i)
            If numbers.Capacity <> capacity Then
                capacity = numbers.Capacity
                Console.WriteLine($"count {numbers.Count,2} : capacity grew to " &
                                  $"{capacity}")
            End If
        Next

        Dim asked As New List(Of Integer)(40)
        Console.WriteLine($"asked for 40 in advance : capacity {asked.Capacity}")
        For i = 1 To 40
            asked.Add(i)
        Next
        Console.WriteLine($"after 40 adds           : capacity {asked.Capacity}")
    End Sub
End Module
