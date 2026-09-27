' The entry point is found by name, and the name is Main.
Imports System

Module Program
    Sub Start()
        Console.WriteLine("this never runs")
    End Sub

    Sub Main()
        Console.WriteLine("Main ran; Start did not")
        Console.WriteLine($"the module is {NameOf(Program)}")
        Console.WriteLine($"the entry point is {NameOf(Main)}")
    End Sub
End Module
