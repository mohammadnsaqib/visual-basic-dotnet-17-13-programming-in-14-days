' A task nobody awaits keeps its failure to itself.
Imports System
Imports System.Threading.Tasks

Module Program
    Async Function FailingAsync() As Task
        Await Task.Delay(20)
        Throw New InvalidOperationException("nobody will hear this")
    End Function

    Async Function RunAsync() As Task
        Dim ignored = FailingAsync()
        Await Task.Delay(80)

        Console.WriteLine($"the program is still running")
        Console.WriteLine($"the task faulted : {ignored.IsFaulted}")
        Console.WriteLine($"and it holds     : " &
                          $"{ignored.Exception.InnerException.Message}")
        Console.WriteLine("nothing was printed by the failure itself, and nothing " &
                          "stopped")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
        Console.WriteLine("Main finished normally, with a failure never reported")
    End Sub
End Module
