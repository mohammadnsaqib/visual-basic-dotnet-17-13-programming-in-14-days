' With Option Strict Off the compiler converts for you, and does not say so.
Imports System

Module Program
    Sub Main()
        Dim up As Double = 19.99
        Dim down As Double = 19.49
        Dim roundedUp As Integer = up            ' no error, no warning
        Dim roundedDown As Integer = down
        Dim text As String = roundedUp
        Dim back As Integer = "42"

        Console.WriteLine($"{up} became {roundedUp}")
        Console.WriteLine($"{down} became {roundedDown}")
        Console.WriteLine($"the String ""{text}"" came from an Integer")
        Console.WriteLine($"the Integer {back} came from a String")
        Console.WriteLine("the conversion rounded to nearest; it did not cut the " &
                          "fraction off")
    End Sub
End Module
