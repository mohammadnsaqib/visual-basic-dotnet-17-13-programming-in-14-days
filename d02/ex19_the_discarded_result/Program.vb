' A Function whose answer is thrown away did the work anyway.
Imports System

Module Program
    Private calls As Integer = 0

    Function Doubled(n As Integer) As Integer
        calls += 1
        Return n * 2
    End Function

    Sub Main()
        Dim kept = Doubled(21)
        Doubled(21)
        Console.WriteLine($"kept  : {kept}")
        Console.WriteLine($"calls : {calls}")
        Console.WriteLine("the second call ran and its answer went nowhere")
    End Sub
End Module
