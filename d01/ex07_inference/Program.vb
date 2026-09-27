' Inference reads the initialiser, and nothing else.
Imports System

Module Program
    Sub Main()
        Dim a = 3
        Dim b = 3.0
        Dim c = 3.0D
        Dim d = "3"
        Dim e = 3UL
        Dim f = {1, 2, 3}

        For Each pair In New (Name As String, Value As Object)() _
                {("3", a), ("3.0", b), ("3.0D", c), ("""3""", d), ("3UL", e),
                 ("{1, 2, 3}", f)}
            Console.WriteLine($"{pair.Name,-10} -> {pair.Value.GetType().Name}")
        Next
    End Sub
End Module
