' Appending, and the difference between adding to a file and replacing it.
Imports System
Imports System.IO

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d10-append")
        Directory.CreateDirectory(folder)
        Dim journal = Path.Combine(folder, "journal.txt")

        File.WriteAllText(journal, "opened" & vbLf)
        File.AppendAllText(journal, "posted 1200.00" & vbLf)
        File.AppendAllText(journal, "posted 87.50" & vbLf)
        Console.WriteLine($"after two appends : {File.ReadAllLines(journal).Length} " &
                          $"line(s)")

        File.WriteAllText(journal, "replaced" & vbLf)
        Console.WriteLine($"after WriteAllText: {File.ReadAllLines(journal).Length} " &
                          $"line(s)")
        Console.WriteLine($"and it now says   : {File.ReadAllText(journal).Trim()}")

        File.AppendAllText(Path.Combine(folder, "new.txt"), "made by appending" & vbLf)
        Console.WriteLine($"append made a file: " &
                          $"{File.Exists(Path.Combine(folder, "new.txt"))}")

        Directory.Delete(folder, True)
    End Sub
End Module
