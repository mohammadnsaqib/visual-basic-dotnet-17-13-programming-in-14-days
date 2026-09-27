' Path.Combine has rules, and the rules need knowing before a path is built from
' user text.
Imports System
Imports System.IO

Module Program
    Sub Show(caption As String, parts As String())
        Console.WriteLine($"{caption,-24}: {Path.Combine(parts)}")
    End Sub

    Sub Main()
        Show("plain", New String() {"C:\books", "day10", "ledger.csv"})
        Show("trailing separator", New String() {"C:\books\", "day10", "ledger.csv"})
        Show("empty part", New String() {"C:\books", "", "ledger.csv"})
        Show("second part is rooted", New String() {"C:\books", "D:\other\ledger.csv"})
        Show("second part is root-relative", New String() {"C:\books", "\ledger.csv"})

        Console.WriteLine($"is it rooted : {Path.IsPathRooted("\ledger.csv")}")
        Console.WriteLine($"separator    : [{Path.DirectorySeparatorChar}]")
    End Sub
End Module
