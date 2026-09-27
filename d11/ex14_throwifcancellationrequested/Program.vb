' Where to put the check, and what the two ways of reporting it look like.
Imports System
Imports System.Threading
Imports System.Threading.Tasks

Module Program
    Async Function ByThrowingAsync(token As CancellationToken) As Task(Of Integer)
        For i = 1 To 10
            token.ThrowIfCancellationRequested()
            Await Task.Delay(20)
        Next
        Return 10
    End Function

    Async Function ByReturningAsync(token As CancellationToken) As Task(Of Integer)
        Dim done As Integer = 0
        For i = 1 To 10
            If token.IsCancellationRequested Then
                Return done
            End If
            Await Task.Delay(20)
            done += 1
        Next
        Return done
    End Function

    Async Function RunAsync() As Task
        Using source As New CancellationTokenSource(70)
            Try
                Console.WriteLine(Await ByThrowingAsync(source.Token))
            Catch ex As OperationCanceledException
                Console.WriteLine($"throwing  : {ex.GetType().Name}")
            End Try
        End Using

        Using source As New CancellationTokenSource(70)
            Dim done = Await ByReturningAsync(source.Token)
            Console.WriteLine($"returning : {done} step(s) done, and no exception")
        End Using

        Console.WriteLine("throwing says it did not finish; returning does not")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
