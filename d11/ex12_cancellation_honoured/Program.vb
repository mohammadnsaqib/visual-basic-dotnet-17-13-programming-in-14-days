' A token is a request. This work reads it and agrees.
Imports System
Imports System.Threading
Imports System.Threading.Tasks

Module Program
    Async Function CountAsync(upTo As Integer,
                              token As CancellationToken) As Task(Of Integer)
        Dim done As Integer = 0
        For i = 1 To upTo
            token.ThrowIfCancellationRequested()
            Await Task.Delay(20, token)
            done += 1
        Next
        Return done
    End Function

    Async Function RunAsync() As Task
        Using source As New CancellationTokenSource(90)
            Try
                Dim done = Await CountAsync(10, source.Token)
                Console.WriteLine($"finished all {done}")
            Catch ex As OperationCanceledException
                Console.WriteLine($"stopped : {ex.GetType().Name}")
                Console.WriteLine($"asked to stop : {source.IsCancellationRequested}")
            End Try
        End Using
        Console.WriteLine("the work stopped because it was looking at the token")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
