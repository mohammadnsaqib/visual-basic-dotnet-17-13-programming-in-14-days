' Putting a value into an Object. What arrives there is a copy in a box of its own.
Imports System

Module Program
    Sub Main()
        Dim n As Integer = 41
        Dim boxed As Object = n
        n = 99

        Console.WriteLine($"n     : {n}")
        Console.WriteLine($"boxed : {boxed}")
        Console.WriteLine($"the box holds a : {boxed.GetType().Name}")
        Console.WriteLine($"which is a value type : {boxed.GetType().IsValueType}")

        Dim back As Integer = CInt(boxed)
        back = 7
        Console.WriteLine($"unboxed then changed : {back}")
        Console.WriteLine($"the box still holds  : {boxed}")

        Dim second As Object = CInt(boxed)
        Console.WriteLine($"two boxes of the same number are one object : " &
                          $"{ReferenceEquals(boxed, second)}")
        Console.WriteLine($"but they are equal : {boxed.Equals(second)}")
    End Sub
End Module
