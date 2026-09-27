' The books written to a target through the shell, which is how a person would do it.
Imports System
Imports System.IO
Imports Tally

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d14-save")
        Directory.CreateDirectory(folder)
        Dim target = Path.Combine(folder, "books.json")

        Dim shell As New Shell(New Ledger())
        Console.WriteLine(shell.Run("open AC-1000 Cash 250"))
        Console.WriteLine(shell.Run("open AC-4000 Sales"))
        Console.WriteLine(shell.Run("post opening; debit AC-1000 5000; credit " &
                                    "AC-4000 5000"))
        Console.WriteLine(shell.Run($"save {target}"))

        Console.WriteLine($"bytes on disk : {New FileInfo(target).Length}")
        Console.WriteLine($"lines in it   : {File.ReadAllLines(target).Length}")
        Directory.Delete(folder, True)
    End Sub
End Module
