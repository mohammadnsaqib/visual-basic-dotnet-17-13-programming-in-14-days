' The same request, to work that never reads it.
Imports System
Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks

Module Program
    Async Function CountAsync(upTo As Integer,
                              token As CancellationToken) As Task(Of Integer)
        Dim done As Integer = 0
        For i = 1 To upTo
            Await Task.Delay(20)
            done += 1
        Next
        Return done
    End Function

    Async Function RunAsync() As Task
        Dim clock = Stopwatch.StartNew()
        Using source As New CancellationTokenSource(60)
            Dim done = Await CountAsync(8, source.Token)
            clock.Stop()
            Console.WriteLine($"asked to stop after : 60 ms")
            Console.WriteLine($"steps completed     : {done} of 8")
            Console.WriteLine($"cancellation asked  : {source.IsCancellationRequested}")
        End Using
        Console.WriteLine("nothing stopped, because nothing was listening")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
