' Without Option Explicit, a misspelt name is a new variable rather than a mistake.
Imports System

Module Program
    Sub Main()
        Dim balance = 1200.5
        balance = balance + 87.5

        Console.WriteLine($"balance : {balance}")
        Console.WriteLine($"blance  : [{blance}]")
        Console.WriteLine($"blance is : " &
                          $"{If(blance Is Nothing, "Nothing", "something")}")
        Console.WriteLine("the second name was never declared, and nothing said so")
    End Sub
End Module
