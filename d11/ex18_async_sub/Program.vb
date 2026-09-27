' An Async Sub returns nothing, so there is nothing to await and nowhere for a failure
' to go.
Imports System
Imports System.Threading.Tasks

Module Program
    Async Sub FireAndForget(caption As String)
        Await Task.Delay(20)
        Console.WriteLine($"  {caption} finished")
    End Sub

    Async Function AwaitableAsync(caption As String) As Task
        Await Task.Delay(20)
        Console.WriteLine($"  {caption} finished")
    End Function

    Async Function RunAsync() As Task
        Console.WriteLine("calling the Sub:")
        FireAndForget("the Sub")
        Console.WriteLine("  the caller carried on, with nothing to wait for")
        Await Task.Delay(80)

        Console.WriteLine("calling the Function:")
        Await AwaitableAsync("the Function")
        Console.WriteLine("  the caller waited, because there was something to wait " &
                          "for")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
