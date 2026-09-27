' Where an item goes in decides what the list has to do. The two ends are not alike.
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics

Module Program
    Sub Main()
        Const many As Integer = 40000

        Dim atTheEnd As New List(Of Integer)()
        Dim clock = Stopwatch.StartNew()
        For i = 1 To many
            atTheEnd.Add(i)
        Next
        clock.Stop()
        Dim addMs = clock.Elapsed.TotalMilliseconds

        Dim atTheFront As New List(Of Integer)()
        clock.Restart()
        For i = 1 To many
            atTheFront.Insert(0, i)
        Next
        clock.Stop()
        Dim insertMs = clock.Elapsed.TotalMilliseconds

        Console.WriteLine($"{many} at the end   : {addMs:F1} ms")
        Console.WriteLine($"{many} at the front : {insertMs:F1} ms")
        Console.WriteLine($"the front cost {insertMs / addMs:F0} times as much")
        Console.WriteLine($"both lists hold {atTheEnd.Count} and {atTheFront.Count} " &
                          $"items")
        Console.WriteLine($"and the front one starts {atTheFront(0)}, {atTheFront(1)}")
    End Sub
End Module
