' The same failure, caught. An exception is an object, and these are its parts.
Imports System

Module Program
    Function Divide(top As Integer, bottom As Integer) As Integer
        Return top \ bottom
    End Function

    Sub Main()
        Try
            Console.WriteLine(Divide(10, 0))
        Catch ex As DivideByZeroException
            Console.WriteLine($"type    : {ex.GetType().Name}")
            Console.WriteLine($"message : {ex.Message}")
            Console.WriteLine($"thrown in : {ex.TargetSite.Name}")
            Console.WriteLine($"inherits  : {ex.GetType().BaseType.Name}")
            Console.WriteLine($"first stack line : " &
                              $"{ex.StackTrace.Split(vbLf)(0).Trim()}")
        End Try
        Console.WriteLine("the program continues")
    End Sub
End Module
