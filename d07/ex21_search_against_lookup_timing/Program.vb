' The same question asked of two collections. The collection decides what the question
' costs.
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics

Module Program
    Sub Main()
        Const many As Integer = 200000
        Const asked As Integer = 200

        Dim asList As New List(Of String)(many)
        Dim asDictionary As New Dictionary(Of String, Integer)(many)
        For i = 1 To many
            Dim code = $"AC-{i:D6}"
            asList.Add(code)
            asDictionary.Add(code, i)
        Next

        Dim wanted As New List(Of String)()
        For i = 1 To asked
            wanted.Add($"AC-{many - i:D6}")
        Next

        Dim clock = Stopwatch.StartNew()
        Dim listFound As Integer = 0
        For Each code In wanted
            If asList.Contains(code) Then
                listFound += 1
            End If
        Next
        clock.Stop()
        Dim listMs = clock.Elapsed.TotalMilliseconds

        clock.Restart()
        Dim dictionaryFound As Integer = 0
        For Each code In wanted
            If asDictionary.ContainsKey(code) Then
                dictionaryFound += 1
            End If
        Next
        clock.Stop()
        Dim dictionaryMs = clock.Elapsed.TotalMilliseconds

        Console.WriteLine($"{asked} searches of a list of {many}       : {listMs:F1} " &
                          $"ms")
        Console.WriteLine($"{asked} lookups in a dictionary of {many}  : " &
                          $"{dictionaryMs:F2} ms")
        Console.WriteLine($"both found {listFound} and {dictionaryFound}")
        Console.WriteLine("the list read up to each match; the dictionary read one " &
                          "bucket")
    End Sub
End Module
