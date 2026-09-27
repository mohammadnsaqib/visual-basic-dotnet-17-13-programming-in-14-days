' One setting in the project file, and the same comparison gives a different answer.
Imports System

Module Program
    Sub Main()
        Dim held = "Cash"
        Dim asked = "CASH"

        Console.WriteLine($"held = asked          : {held = asked}")
        Console.WriteLine($"held < asked          : {held < asked}")
        Console.WriteLine($"String.Equals ordinal : " &
                          $"{String.Equals(held, asked, StringComparison.Ordinal)}")
        Console.WriteLine($"String.Equals ignoring: " &
            $"{String.Equals(held, asked, StringComparison.OrdinalIgnoreCase)}")
        Console.WriteLine($"CompareTo             : {held.CompareTo(asked)}")
        Console.WriteLine("this project sets Option Compare Text, and = is the line " &
                          "that moved")
    End Sub
End Module
