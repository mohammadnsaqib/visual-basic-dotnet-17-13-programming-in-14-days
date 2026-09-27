' The failure the check was there to prevent, with no check in front of it.
Imports System
Imports System.IO

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d10-missing")
        Directory.CreateDirectory(folder)
        Dim absent = Path.Combine(folder, "absent.txt")

        Console.WriteLine($"about to read {Path.GetFileName(absent)}")
        Console.WriteLine($"it exists : {File.Exists(absent)}")
        Console.WriteLine(File.ReadAllText(absent))
        Console.WriteLine("never printed")
    End Sub
End Module
