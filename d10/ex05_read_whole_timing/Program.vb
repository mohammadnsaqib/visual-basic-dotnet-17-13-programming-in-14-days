' A large file read in one call. The time is one thing and the memory is another.
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Text

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d10-large")
        Directory.CreateDirectory(folder)
        Dim big = Path.Combine(folder, "movements.csv")

        Const rows As Integer = 200000
        Using writer As New StreamWriter(big, False, New UTF8Encoding(False))
            For i = 1 To rows
                writer.WriteLine($"AC-{i Mod 50:D4},{i},{(i Mod 97) + 0.5:F2}")
            Next
        End Using
        Console.WriteLine($"{rows} rows, {New FileInfo(big).Length} bytes")

        Dim before = GC.GetAllocatedBytesForCurrentThread()
        Dim clock = Stopwatch.StartNew()
        Dim whole = File.ReadAllText(big)
        clock.Stop()
        Dim allocated = GC.GetAllocatedBytesForCurrentThread() - before

        Console.WriteLine($"ReadAllText   : {clock.Elapsed.TotalMilliseconds:F1} ms")
        Console.WriteLine($"characters    : {whole.Length}")
        Console.WriteLine($"allocated     : {allocated \ 1024} KB")
        Console.WriteLine($"alive at once : {GC.GetTotalMemory(True) \ 1024} KB")
        GC.KeepAlive(whole)

        Directory.Delete(folder, True)
    End Sub
End Module
