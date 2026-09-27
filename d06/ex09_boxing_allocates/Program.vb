' What a box costs, in bytes, measured rather than asserted.
Imports System
Imports System.Collections.Generic

Module Program
    Sub Main()
        Const many As Integer = 10000
        Dim asObjects As New List(Of Object)(many)
        Dim asIntegers As New List(Of Integer)(many)

        Dim start As Long = GC.GetAllocatedBytesForCurrentThread()
        For i = 1 To many
            asObjects.Add(i)
        Next
        Dim afterBoxing As Long = GC.GetAllocatedBytesForCurrentThread()
        For i = 1 To many
            asIntegers.Add(i)
        Next
        Dim afterStoring As Long = GC.GetAllocatedBytesForCurrentThread()

        Console.WriteLine($"{many} integers into a List(Of Object)  : " &
                          $"{afterBoxing - start} bytes")
        Console.WriteLine($"{many} integers into a List(Of Integer) : " &
                          $"{afterStoring - afterBoxing} bytes")
        Console.WriteLine($"per boxed integer : {(afterBoxing - start) \ many} bytes")
        Console.WriteLine($"both lists hold {asObjects.Count} and {asIntegers.Count} " &
                          $"items")
    End Sub
End Module
