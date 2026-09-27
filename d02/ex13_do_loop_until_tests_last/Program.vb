' Do ... Loop Until tests after the body, so the body always runs once.
Imports System

Module Program
    Sub Main()
        Dim items = New Integer() {}
        Dim index As Integer = 0
        Dim passes As Integer = 0

        Do
            passes += 1
            index += 1
        Loop Until index >= items.Length
        Console.WriteLine($"Do Loop Until on an empty list: {passes} pass(es)")
        Console.WriteLine($"index is {index}, which is past the end of a list of " &
                          $"{items.Length}")
    End Sub
End Module
