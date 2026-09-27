' Is asks about identity; = asks the type what equality means.
Imports System

Module Program
    Sub Main()
        Dim empty As String = ""
        Dim missing As String = Nothing

        Console.WriteLine($"empty Is Nothing    : {empty Is Nothing}")
        Console.WriteLine($"empty = Nothing     : {empty = Nothing}")
        Console.WriteLine($"missing Is Nothing  : {missing Is Nothing}")
        Console.WriteLine($"missing = Nothing   : {missing = Nothing}")
        Console.WriteLine($"empty = missing     : {empty = missing}")
        Console.WriteLine($"String.Equals       : {String.Equals(empty, missing)}")
        Console.WriteLine("= treats Nothing as an empty String; Is does not")
    End Sub
End Module
