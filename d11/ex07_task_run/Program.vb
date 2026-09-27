' Task.Run is for work that keeps a processor busy. Await is for work that keeps nothing
' busy.
Imports System
Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks

Module Program
    Function Total(upTo As Integer) As Long
        Dim sum As Long = 0
        For i = 1 To upTo
            sum += i
        Next
        Return sum
    End Function

    Async Function RunAsync() As Task
        Console.WriteLine($"Main's thread     : {Environment.CurrentManagedThreadId}")

        Dim work = Task.Run(Function()
                                Console.WriteLine($"the work's thread : " &
                                    $"{Environment.CurrentManagedThreadId}")
                                Return Total(1000000)
                            End Function)
        Dim answer = Await work
        Console.WriteLine($"the total         : {answer}")
        Console.WriteLine($"finished cleanly  : {work.IsCompletedSuccessfully}")
        Console.WriteLine("Task.Run moves work to another thread; Await does not")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
