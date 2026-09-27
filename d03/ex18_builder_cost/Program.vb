' A StringBuilder appends into a buffer it keeps, and only grows it when it must.
Imports System
Imports System.Diagnostics
Imports System.Text

Module Program
    Sub Main()
        Const rounds As Integer = 20000
        Dim watch = Stopwatch.StartNew()
        Dim builder As New StringBuilder()
        For i = 1 To rounds
            builder.Append("x"c)
        Next
        Dim text = builder.ToString()
        watch.Stop()
        Console.WriteLine($"rounds      : {rounds}")
        Console.WriteLine($"length      : {text.Length}")
        Console.WriteLine($"elapsed     : {watch.ElapsedMilliseconds} ms")
        Console.WriteLine($"capacity    : {builder.Capacity}")
    End Sub
End Module
