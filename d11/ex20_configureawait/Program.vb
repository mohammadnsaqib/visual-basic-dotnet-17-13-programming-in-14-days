' ConfigureAwait says whether the method wants its context back.
Imports System
Imports System.Threading
Imports System.Threading.Tasks

Module Program
    Async Function WithContextAsync() As Task(Of Boolean)
        Await Task.Delay(20)
        Return Thread.CurrentThread.IsThreadPoolThread
    End Function

    Async Function WithoutContextAsync() As Task(Of Boolean)
        Await Task.Delay(20).ConfigureAwait(False)
        Return Thread.CurrentThread.IsThreadPoolThread
    End Function

    Async Function RunAsync() As Task
        Console.WriteLine($"context here : " &
            $"{If(SynchronizationContext.Current Is Nothing, "none", "one")}")
        Console.WriteLine($"with    : resumed on a pool thread : " &
                          $"{Await WithContextAsync()}")
        Console.WriteLine($"without : resumed on a pool thread : " &
                          $"{Await WithoutContextAsync()}")
        Console.WriteLine("with no context to return to, the two behave alike here")
        Console.WriteLine("in a library, ConfigureAwait(False) is the safe default")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
