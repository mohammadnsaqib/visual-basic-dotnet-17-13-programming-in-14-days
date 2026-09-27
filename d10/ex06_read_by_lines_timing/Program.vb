' The same file, one line at a time. Only one line is held at once.
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Text

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d10-lines")
        Directory.CreateDirectory(folder)
        Dim big = Path.Combine(folder, "movements.csv")

        Const rows As Integer = 200000
        Using writer As New StreamWriter(big, False, New UTF8Encoding(False))
            For i = 1 To rows
                writer.WriteLine($"AC-{i Mod 50:D4},{i},{(i Mod 97) + 0.5:F2}")
            Next
        End Using

        Dim before = GC.GetAllocatedBytesForCurrentThread()
        Dim clock = Stopwatch.StartNew()
        Dim counted As Integer = 0
        Dim widest As Integer = 0
        For Each line In File.ReadLines(big)
            counted += 1
            If line.Length > widest Then
                widest = line.Length
            End If
        Next
        clock.Stop()
        Dim allocated = GC.GetAllocatedBytesForCurrentThread() - before

        Console.WriteLine($"ReadLines     : {clock.Elapsed.TotalMilliseconds:F1} ms")
        Console.WriteLine($"lines         : {counted}")
        Console.WriteLine($"widest line   : {widest} characters")
        Console.WriteLine($"allocated     : {allocated \ 1024} KB")
        Console.WriteLine($"alive at once : {GC.GetTotalMemory(True) \ 1024} KB")

        Directory.Delete(folder, True)
    End Sub
End Module
