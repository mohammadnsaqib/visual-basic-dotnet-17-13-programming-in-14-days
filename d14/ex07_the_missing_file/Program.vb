' Loading a target that is not there. The person typing gets a sentence, not a stack.
Imports System
Imports System.IO
Imports Tally

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d14-missing")
        Directory.CreateDirectory(folder)
        Dim absent = Path.Combine(folder, "absent.json")

        Dim shell As New Shell(New Ledger())
        Console.WriteLine(shell.Run($"load {absent}"))
        Console.WriteLine(shell.Run("load"))
        Console.WriteLine(shell.Run("save"))
        Console.WriteLine($"the shell is still usable : " &
                          $"{shell.Run("open AC-1000 Cash")}")
        Directory.Delete(folder, True)
    End Sub
End Module
