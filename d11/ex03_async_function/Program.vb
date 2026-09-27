' What an Async Function returns, and what the caller gets from it.
Imports System
Imports System.Threading.Tasks

Module Program
    Async Function BalanceAsync(code As String) As Task(Of Decimal)
        Await Task.Delay(20)
        Return If(code = "AC-1000", 3800D, 0D)
    End Function

    Async Function RunAsync() As Task
        Dim pending = BalanceAsync("AC-1000")
        Console.WriteLine($"the call gave a Task(Of Decimal) : " &
                          $"{TypeOf pending Is Task(Of Decimal)}")
        Console.WriteLine($"finished yet    : {pending.IsCompleted}")

        Dim balance = Await pending
        Console.WriteLine($"after the Await : {balance:N2}")
        Console.WriteLine($"finished now    : {pending.IsCompleted}")
        Console.WriteLine($"status          : {pending.Status}")

        Console.WriteLine($"a second one    : {Await BalanceAsync("AC-9999"):N2}")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
