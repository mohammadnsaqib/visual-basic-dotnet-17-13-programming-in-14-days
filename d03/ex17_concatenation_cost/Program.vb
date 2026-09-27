' Building a string by concatenation copies everything built so far, every time.
Imports System
Imports System.Diagnostics

Module Program
    Sub Main()
        Const rounds As Integer = 20000
        Dim watch = Stopwatch.StartNew()
        Dim text As String = ""
        For i = 1 To rounds
            text &= "x"
        Next
        watch.Stop()
        Console.WriteLine($"rounds      : {rounds}")
        Console.WriteLine($"length      : {text.Length}")
        Console.WriteLine($"elapsed     : {watch.ElapsedMilliseconds} ms")
        Console.WriteLine($"characters copied: about {CLng(rounds) * rounds \ 2L}")
    End Sub
End Module
