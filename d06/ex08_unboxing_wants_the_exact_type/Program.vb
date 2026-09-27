' Unboxing is not a conversion. It reads the box, and it demands the type the box was
' filled with.
Imports System

Module Program
    Sub Main()
        Dim boxed As Object = 42
        Console.WriteLine($"the box holds a {boxed.GetType().Name}")

        Console.WriteLine("CLng converts whatever it finds, and that works:")
        Console.WriteLine($"  {CLng(boxed)}")

        Console.WriteLine("DirectCast unboxes, and it wants an Integer:")
        Console.WriteLine($"  {DirectCast(boxed, Integer)}")

        Console.WriteLine("The same box read as a Long:")
        Dim wrong As Long = DirectCast(boxed, Long)
        Console.WriteLine($"  never printed : {wrong}")
    End Sub
End Module
