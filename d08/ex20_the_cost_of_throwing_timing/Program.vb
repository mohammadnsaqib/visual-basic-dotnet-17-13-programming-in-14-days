' The same work done twice: once by failing, once by testing first.
Imports System
Imports System.Diagnostics

Module Program
    Sub Main()
        Const many As Integer = 20000
        Dim inputs(many - 1) As String
        For i = 0 To many - 1
            inputs(i) = If(i Mod 2 = 0, i.ToString(), "not a number")
        Next

        Dim parsed As Integer = 0
        Dim clock = Stopwatch.StartNew()
        For Each entry In inputs
            Try
                Dim value = Integer.Parse(entry)
                parsed += 1
            Catch ex As FormatException
            End Try
        Next
        clock.Stop()
        Dim throwingMs = clock.Elapsed.TotalMilliseconds

        Dim tested As Integer = 0
        clock.Restart()
        For Each entry In inputs
            Dim value As Integer
            If Integer.TryParse(entry, value) Then
                tested += 1
            End If
        Next
        clock.Stop()
        Dim testingMs = clock.Elapsed.TotalMilliseconds

        Console.WriteLine($"Parse with a Catch : {throwingMs:F1} ms, {parsed} parsed")
        Console.WriteLine($"TryParse           : {testingMs:F1} ms, {tested} parsed")
        Console.WriteLine($"throwing cost {throwingMs / testingMs:F0} times as much")
        Console.WriteLine($"{many \ 2} of the {many} inputs were meant to fail")
    End Sub
End Module
