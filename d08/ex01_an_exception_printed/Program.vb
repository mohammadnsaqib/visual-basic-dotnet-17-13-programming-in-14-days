' What a program does when nobody deals with a failure. The runtime prints and stops.
Imports System

Module Program
    Function Divide(top As Integer, bottom As Integer) As Integer
        Return top \ bottom
    End Function

    Sub Main()
        Console.WriteLine("about to divide 10 by 2")
        Console.WriteLine($"  {Divide(10, 2)}")
        Console.WriteLine("about to divide 10 by 0")
        Console.WriteLine($"  {Divide(10, 0)}")
        Console.WriteLine("never printed")
    End Sub
End Module
