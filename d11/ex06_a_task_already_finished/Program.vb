' A Task is not always work in progress. Some of them are answers.
Imports System
Imports System.Threading.Tasks

Module Program
    Function CachedAsync(code As String) As Task(Of Decimal)
        If code = "AC-1000" Then
            Return Task.FromResult(3800D)
        End If
        Return SlowAsync(code)
    End Function

    Async Function SlowAsync(code As String) As Task(Of Decimal)
        Await Task.Delay(20)
        Return 0D
    End Function

    Async Function RunAsync() As Task
        Dim cached = CachedAsync("AC-1000")
        Dim fetched = CachedAsync("AC-9999")

        Console.WriteLine($"cached finished  : {cached.IsCompleted}")
        Console.WriteLine($"fetched finished : {fetched.IsCompleted}")
        Console.WriteLine($"cached value     : {Await cached:N2}")
        Console.WriteLine($"fetched value    : {Await fetched:N2}")
        Console.WriteLine($"both finished    : {cached.IsCompleted} and " &
                          $"{fetched.IsCompleted}")
        Console.WriteLine($"awaiting a finished task costs nothing extra")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
