' Two of three fail. Await reports one of them, and the task holds both.
Imports System
Imports System.Linq
Imports System.Threading.Tasks

Module Program
    Async Function WorkAsync(code As String, fail As Boolean) As Task(Of String)
        Await Task.Delay(20)
        If fail Then
            Throw New InvalidOperationException($"{code} failed")
        End If
        Return $"{code} done"
    End Function

    Async Function RunAsync() As Task
        Dim all = Task.WhenAll(WorkAsync("AC-1000", False),
                               WorkAsync("AC-1001", True),
                               WorkAsync("AC-4000", True))
        Try
            Await all
        Catch ex As InvalidOperationException
            Console.WriteLine($"Await reported : {ex.Message}")
        End Try

        Console.WriteLine($"the task faulted : {all.IsFaulted}")
        Console.WriteLine($"failures held    : {all.Exception.InnerExceptions.Count}")
        For Each inner In all.Exception.InnerExceptions
            Console.WriteLine($"  {inner.Message}")
        Next
        Console.WriteLine("Await gives the first; the AggregateException gives all " &
                          "of them")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
