' The older mechanism, shown once so that it can be recognised and left alone.
Imports System

Module Program
    Sub Main()
        On Error Resume Next

        Dim inputs = New String() {"10", "twenty", "30"}
        Dim total As Integer = 0
        For Each entry In inputs
            total += Integer.Parse(entry)
            Console.WriteLine($"{entry,-8} total now {total}, Err.Number {Err.Number}")
            Err.Clear()
        Next

        Console.WriteLine($"total : {total}")
        Console.WriteLine("the failing line was skipped and the loop carried on")
    End Sub
End Module
