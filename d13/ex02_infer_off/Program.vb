' Without inference, a Dim with no As is an Object, whatever is assigned to it.
Imports System

Module Program
    Sub Main()
        Dim counted = 3
        Console.WriteLine($"counted holds a : {counted.GetType().Name}")

        counted = "now some text"
        Console.WriteLine($"counted holds a : {counted.GetType().Name}")

        Dim named As String = "Cash"
        Console.WriteLine($"named holds a   : {named.GetType().Name}")

        Console.WriteLine("the second assignment compiles only because counted is an " &
                          "Object")
        Console.WriteLine("with Option Infer On it would be an Integer, and would " &
                          "not compile")
    End Sub
End Module
