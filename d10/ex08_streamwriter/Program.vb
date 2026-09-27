' A writer buffers. Nothing reaches the disk until the buffer is emptied.
Imports System
Imports System.IO
Imports System.Text

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d10-writer")
        Directory.CreateDirectory(folder)
        Dim ledger = Path.Combine(folder, "ledger.csv")

        Dim writer As New StreamWriter(ledger, False, New UTF8Encoding(False))
        writer.WriteLine("code,name")
        writer.WriteLine("AC-1000,Cash")
        Console.WriteLine($"after two WriteLines : {New FileInfo(ledger).Length} bytes")
        writer.Flush()
        Console.WriteLine($"after Flush          : {New FileInfo(ledger).Length} bytes")
        writer.WriteLine("AC-1001,Rent")
        writer.Dispose()
        Console.WriteLine($"after Dispose        : {New FileInfo(ledger).Length} bytes")

        For Each line In File.ReadAllLines(ledger)
            Console.WriteLine($"  {line}")
        Next
        Directory.Delete(folder, True)
    End Sub
End Module
