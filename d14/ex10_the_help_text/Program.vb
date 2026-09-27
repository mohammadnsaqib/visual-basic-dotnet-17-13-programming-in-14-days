' The list of what the program understands, which is also its documentation.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim shell As New Shell(New Ledger())
        Console.WriteLine("> help")
        Console.WriteLine(shell.Run("help"))
        Console.WriteLine($"commands : {Shell.Help.Split(vbLf).Length}")
        Console.WriteLine($"the same text from the property : " &
                          $"{Shell.Help = shell.Run("help")}")
    End Sub
End Module
