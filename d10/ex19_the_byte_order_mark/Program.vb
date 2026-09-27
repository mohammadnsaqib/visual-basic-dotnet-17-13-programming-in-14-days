' Three bytes at the front of a file, and what reads them.
Imports System
Imports System.IO
Imports System.Linq
Imports System.Text

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d10-bom")
        Directory.CreateDirectory(folder)
        Dim withBom = Path.Combine(folder, "with-bom.txt")
        Dim without = Path.Combine(folder, "without-bom.txt")

        File.WriteAllText(withBom, "AC-1000", New UTF8Encoding(True))
        File.WriteAllText(without, "AC-1000", New UTF8Encoding(False))

        Console.WriteLine($"with a mark : {New FileInfo(withBom).Length} bytes")
        Console.WriteLine($"without one : {New FileInfo(without).Length} bytes")
        Console.WriteLine($"first bytes : " &
                          String.Join(" ", File.ReadAllBytes(withBom).Take(3)))

        Console.WriteLine($"read normally  : [{File.ReadAllText(withBom)}]")
        Using reader As New StreamReader(withBom, New UTF8Encoding(False), False)
            Console.WriteLine($"mark not sought: [{reader.ReadToEnd()}]")
        End Using

        Dim kept = File.ReadAllText(withBom)
        Console.WriteLine($"length as read : {kept.Length}")
        Directory.Delete(folder, True)
    End Sub
End Module
