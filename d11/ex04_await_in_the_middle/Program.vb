' Await is not the end of a method. It is a place the method can be put down and picked
' up.
Imports System
Imports System.Threading.Tasks

Module Program
    Async Function ReportAsync() As Task(Of String)
        Console.WriteLine("  before the Await")
        Dim opening As Decimal = 250D
        Await Task.Delay(20)
        Console.WriteLine("  after the Await")
        Dim closing = opening + 3550D
        Await Task.Delay(20)
        Console.WriteLine("  after the second Await")
        Return $"{opening:N2} became {closing:N2}"
    End Function

    Async Function RunAsync() As Task
        Console.WriteLine("calling")
        Dim pending = ReportAsync()
        Console.WriteLine("the caller carried on")
        Console.WriteLine($"result : {Await pending}")
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
