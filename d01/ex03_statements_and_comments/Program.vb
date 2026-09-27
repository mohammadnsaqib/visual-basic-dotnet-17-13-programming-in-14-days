' A statement ends at the end of the line, unless it is continued.
Imports System

Module Program
    Sub Main()
        Dim first As Integer = 2 : Dim second As Integer = 3  ' two statements, one line
        Dim total As Integer =
            first +
            second  ' one statement, three lines
        Console.WriteLine($"{first} + {second} = {total}")
        REM REM is a comment too, and this book uses the apostrophe.
        Console.WriteLine("a comment runs to the end of its line")
    End Sub
End Module
