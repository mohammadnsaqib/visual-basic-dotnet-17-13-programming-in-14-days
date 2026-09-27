' AndAlso stops as soon as the answer is known.
Imports System

Module Program
    Private calls As Integer = 0

    Function Costly(value As Boolean) As Boolean
        calls += 1
        Return value
    End Function

    Sub Main()
        calls = 0
        Dim a = False AndAlso Costly(True)
        Console.WriteLine($"False AndAlso Costly(True) -> {a}, Costly ran {calls} " &
                          $"time(s)")

        calls = 0
        Dim b = True OrElse Costly(True)
        Console.WriteLine($"True OrElse Costly(True)   -> {b}, Costly ran {calls} " &
                          $"time(s)")

        calls = 0
        Dim c = True AndAlso Costly(False)
        Console.WriteLine($"True AndAlso Costly(False) -> {c}, Costly ran {calls} " &
                          $"time(s)")
    End Sub
End Module
