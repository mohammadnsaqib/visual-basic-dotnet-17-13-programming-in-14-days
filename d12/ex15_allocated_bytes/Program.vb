' A steadier number than a duration: what the thread allocated while it worked.
Imports System
Imports System.Collections.Generic

Module Program
    Sub Main()
        Dim before = GC.GetAllocatedBytesForCurrentThread()
        Dim held As New List(Of String)()
        For i = 1 To 1000
            held.Add(i.ToString())
        Next
        Dim after = GC.GetAllocatedBytesForCurrentThread()

        Console.WriteLine($"strings made : {held.Count}")
        Console.WriteLine($"allocated    : {after - before} bytes")
        Console.WriteLine($"per string   : {(after - before) \ held.Count} bytes")

        Dim again = GC.GetAllocatedBytesForCurrentThread()
        Dim total As Long = 0
        For i = 1 To 1000
            total += i
        Next
        Console.WriteLine($"adding 1000 numbers allocated : " &
                          $"{GC.GetAllocatedBytesForCurrentThread() - again} bytes")
        Console.WriteLine($"and the total is {total}")
    End Sub
End Module
