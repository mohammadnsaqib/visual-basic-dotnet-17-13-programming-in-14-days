' WhenAll says the same thing more plainly, and gives back the answers in order.
Imports System
Imports System.Diagnostics
Imports System.Linq
Imports System.Threading.Tasks

Module Program
    Async Function FetchAsync(code As String, takes As Integer) As Task(Of String)
        Await Task.Delay(takes)
        Return $"{code} after {takes} ms"
    End Function

    Async Function RunAsync() As Task
        Dim work = New Task(Of String)() {FetchAsync("AC-1000", 120),
                                          FetchAsync("AC-1001", 60),
                                          FetchAsync("AC-4000", 90)}
        Dim answers = Await Task.WhenAll(work)

        Console.WriteLine($"answers : {answers.Length}")
        For Each answer In answers
            Console.WriteLine($"  {answer}")
        Next
        Console.WriteLine("the order is the order of the tasks, not the order they " &
                          "finished")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
