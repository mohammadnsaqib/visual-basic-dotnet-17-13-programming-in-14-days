' Writing a file and reading it back, in one call each.
Imports System
Imports System.IO
Imports System.Text

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d10-whole")
        Directory.CreateDirectory(folder)
        Dim ledger = Path.Combine(folder, "ledger.txt")

        File.WriteAllText(ledger, "AC-1000 Cash" & vbCrLf & "AC-1001 Rent" & vbCrLf)
        Console.WriteLine($"wrote {Path.GetFileName(ledger)}")
        Console.WriteLine($"bytes on disk : {New FileInfo(ledger).Length}")

        Dim whole = File.ReadAllText(ledger)
        Console.WriteLine($"characters    : {whole.Length}")
        Console.WriteLine($"first line    : {whole.Split(vbCrLf)(0)}")

        Dim lines = File.ReadAllLines(ledger)
        Console.WriteLine($"lines         : {lines.Length}")
        For Each line In lines
            Console.WriteLine($"  {line}")
        Next

        Directory.Delete(folder, True)
        Console.WriteLine($"folder still there : {Directory.Exists(folder)}")
    End Sub
End Module
