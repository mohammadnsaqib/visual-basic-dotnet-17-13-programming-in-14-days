' An exception raised inside a task waits there until somebody awaits it.
Imports System
Imports System.Threading.Tasks

Module Program
    Async Function FailingAsync() As Task(Of Decimal)
        Await Task.Delay(20)
        Throw New InvalidOperationException("the ledger is out of balance")
    End Function

    Async Function RunAsync() As Task
        Dim pending = FailingAsync()
        Console.WriteLine($"called, and nothing has been thrown yet")
        Console.WriteLine($"faulted yet : {pending.IsFaulted}")

        Try
            Console.WriteLine(Await pending)
        Catch ex As InvalidOperationException
            Console.WriteLine($"the Await threw : {ex.Message}")
        End Try

        Console.WriteLine($"faulted now : {pending.IsFaulted}")
        Console.WriteLine($"status      : {pending.Status}")
        Console.WriteLine($"held inside : " &
                          $"{pending.Exception.InnerException.GetType().Name}")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
