' Which thread runs the code, before an Await and after it.
Imports System
Imports System.Threading
Imports System.Threading.Tasks

Module Program
    Function Now() As String
        Return $"thread {Environment.CurrentManagedThreadId}, " &
               $"pool {Thread.CurrentThread.IsThreadPoolThread}"
    End Function

    Async Function RunAsync() As Task
        Console.WriteLine($"before the Await : {Now()}")
        Await Task.Delay(20)
        Console.WriteLine($"after the Await  : {Now()}")
        Await Task.Delay(20)
        Console.WriteLine($"after the second : {Now()}")
    End Function

    Sub Main()
        Console.WriteLine($"in Main          : {Now()}")
        RunAsync().GetAwaiter().GetResult()
        Console.WriteLine("a console program has no context to come back to, so the " &
                          "pool "&
                          "resumes it")
    End Sub
End Module
