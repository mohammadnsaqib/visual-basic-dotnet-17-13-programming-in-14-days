' Visual Basic checks integer overflow, and says so rather than wrapping.
Imports System

Module Program
    Sub Main()
        Dim big As Integer = Integer.MaxValue
        Console.WriteLine($"the largest Integer is {big}")
        Console.WriteLine("adding one to it:")
        Dim wrapped As Integer = big + 1
        Console.WriteLine($"this line never runs, and {wrapped} is never printed")
    End Sub
End Module
