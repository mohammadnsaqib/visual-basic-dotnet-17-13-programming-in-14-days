' Four files read one after another, and the same four read together.
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Module Program
    Async Function RunAsync() As Task
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d11-files")
        Directory.CreateDirectory(folder)
        Dim names(3) As String
        For i = 0 To 3
            names(i) = Path.Combine(folder, $"part{i}.txt")
            Await File.WriteAllTextAsync(names(i), New String("x"c, 400000),
                                         New UTF8Encoding(False))
        Next

        For Each name In names
            Await File.ReadAllTextAsync(name)
        Next

        Dim clock = Stopwatch.StartNew()
        Dim oneByOne As Integer = 0
        For Each name In names
            oneByOne += (Await File.ReadAllTextAsync(name)).Length
        Next
        clock.Stop()
        Dim sequential = clock.Elapsed.TotalMilliseconds

        clock.Restart()
        Dim reads = names.Select(Function(name) File.ReadAllTextAsync(name)).ToArray()
        Dim together = (Await Task.WhenAll(reads)).Sum(Function(text) text.Length)
        clock.Stop()

        Console.WriteLine($"one after another : {sequential:F0} ms, {oneByOne} " &
                          $"characters")
        Console.WriteLine($"all at once       : {clock.Elapsed.TotalMilliseconds:F0} " &
                          $"ms, " &
                          $"{together} characters")
        Console.WriteLine($"same total        : {oneByOne = together}")

        Directory.Delete(folder, True)
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
