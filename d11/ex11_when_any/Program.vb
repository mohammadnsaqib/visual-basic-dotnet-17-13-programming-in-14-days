' WhenAny returns the first task to finish, and the others carry on.
Imports System
Imports System.Threading.Tasks

Module Program
    Async Function FetchAsync(code As String, takes As Integer) As Task(Of String)
        Await Task.Delay(takes)
        Return $"{code} after {takes} ms"
    End Function

    Async Function RunAsync() As Task
        Dim slow = FetchAsync("AC-1000", 200)
        Dim quick = FetchAsync("AC-1001", 40)

        Dim firstDone = Await Task.WhenAny(slow, quick)
        Console.WriteLine($"first back  : {Await firstDone}")
        Console.WriteLine($"slow done   : {slow.IsCompleted}")
        Console.WriteLine($"quick done  : {quick.IsCompleted}")

        Await Task.WhenAll(slow, quick)
        Console.WriteLine($"now both    : {slow.IsCompleted} and {quick.IsCompleted}")
        Console.WriteLine("WhenAny does not stop the others; it only stops waiting")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
