' A file has no encoding of its own. The reader decides, and this reader decides
' wrongly.
Imports System
Imports System.IO
Imports System.Text

Module Program
    Sub Main()
        Console.OutputEncoding = Encoding.UTF8

        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d10-encoding")
        Directory.CreateDirectory(folder)
        Dim ledger = Path.Combine(folder, "ledger.txt")

        Dim written = "Rent £1,200.00 paid to Ceilidh Müller"
        File.WriteAllText(ledger, written, New UTF8Encoding(False))
        Console.WriteLine($"written  : {written}")
        Console.WriteLine($"bytes    : {New FileInfo(ledger).Length}")
        Console.WriteLine($"characters written : {written.Length}")

        Dim asUtf8 = File.ReadAllText(ledger, Encoding.UTF8)
        Dim asLatin1 = File.ReadAllText(ledger, Encoding.Latin1)
        Console.WriteLine($"as UTF-8   : {asUtf8}")
        Console.WriteLine($"as Latin-1 : {asLatin1}")
        Console.WriteLine($"same text  : {asUtf8 = asLatin1}")
        Console.WriteLine($"characters : {asUtf8.Length} and {asLatin1.Length}")

        Directory.Delete(folder, True)
    End Sub
End Module
