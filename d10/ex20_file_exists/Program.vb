' Asking before opening, and what the answer can and cannot promise.
Imports System
Imports System.IO

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d10-exists")
        Directory.CreateDirectory(folder)
        Dim there = Path.Combine(folder, "there.txt")
        Dim absent = Path.Combine(folder, "absent.txt")
        File.WriteAllText(there, "AC-1000")

        Console.WriteLine($"there.txt  : {File.Exists(there)}")
        Console.WriteLine($"absent.txt : {File.Exists(absent)}")
        Console.WriteLine($"a folder   : {File.Exists(folder)}")
        Console.WriteLine($"folder as a folder : {Directory.Exists(folder)}")

        Dim contents As String = Nothing
        If File.Exists(absent) Then
            contents = File.ReadAllText(absent)
        End If
        Console.WriteLine($"read anyway : {If(contents, "nothing read")}")

        Try
            Console.WriteLine(File.ReadAllText(absent))
        Catch ex As FileNotFoundException
            Console.WriteLine($"opened anyway : {ex.GetType().Name}")
        End Try

        Directory.Delete(folder, True)
    End Sub
End Module
