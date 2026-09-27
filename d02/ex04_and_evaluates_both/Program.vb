' And and Or evaluate both sides, whatever the first one said.
Imports System

Module Program
    Private calls As Integer = 0

    Function Costly(value As Boolean) As Boolean
        calls += 1
        Return value
    End Function

    Sub Main()
        calls = 0
        Dim a = False And Costly(True)
        Console.WriteLine($"False And Costly(True) -> {a}, Costly ran {calls} time(s)")

        calls = 0
        Dim b = True Or Costly(True)
        Console.WriteLine($"True Or Costly(True)   -> {b}, Costly ran {calls} time(s)")

        Console.WriteLine("the answer is the same; the work is not")
    End Sub
End Module
