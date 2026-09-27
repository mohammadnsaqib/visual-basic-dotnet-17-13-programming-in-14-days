' Building a path. One of these ways knows what a separator is, and the other does not.
Imports System
Imports System.IO

Module Program
    Sub Main()
        Dim root = "C:\books"
        Dim folder = "day10"
        Dim leaf = "ledger.csv"

        Console.WriteLine($"combined      : {Path.Combine(root, folder, leaf)}")
        Console.WriteLine($"concatenated  : {root & folder & leaf}")
        Console.WriteLine($"and with one  : {root & "\" & folder & "\" & leaf}")

        Console.WriteLine($"file name     : " &
                          $"{Path.GetFileName("C:\books\day10\ledger.csv")}")
        Console.WriteLine($"without suffix: " &
                          $"{Path.GetFileNameWithoutExtension("ledger.csv")}")
        Console.WriteLine($"extension     : {Path.GetExtension("ledger.csv")}")
        Console.WriteLine($"folder        : " &
                          $"{Path.GetDirectoryName("C:\books\day10\ledger.csv")}")
        Console.WriteLine($"changed       : " &
                          $"{Path.ChangeExtension("ledger.csv", ".json")}")
    End Sub
End Module
