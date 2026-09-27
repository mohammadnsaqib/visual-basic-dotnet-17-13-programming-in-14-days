' Every operator has to say what it does with the value that is not there. Arithmetic
' and comparison give no value back.
Imports System

Module Program
    Sub Main()
        Dim ten As Integer? = 10
        Dim none As Integer? = Nothing

        Console.WriteLine($"ten + 1  : [{ten + 1}]")
        Console.WriteLine($"none + 1 : [{none + 1}]")
        Console.WriteLine($"ten + none : [{ten + none}]")
        Console.WriteLine($"ten > 5  : [{ten > 5}]")
        Console.WriteLine($"none > 5 : [{none > 5}]")
        Console.WriteLine($"none = none : [{none = none}]")
        Console.WriteLine($"none Is Nothing : {none Is Nothing}")

        If none > 5 Then
            Console.WriteLine("the branch for 'none > 5' was taken")
        Else
            Console.WriteLine("the branch for 'none > 5' was not taken")
        End If

        If Not (none > 5) Then
            Console.WriteLine("the branch for 'Not (none > 5)' was taken")
        Else
            Console.WriteLine("the branch for 'Not (none > 5)' was not taken")
        End If

        Console.WriteLine($"If(none, -1) : {If(none, -1)}")
        Console.WriteLine($"If(ten, -1)  : {If(ten, -1)}")
    End Sub
End Module
