' Do While tests before the body, so an empty list runs it no times.
Imports System

Module Program
    Sub Main()
        Dim items = New Integer() {}
        Dim index As Integer = 0
        Dim passes As Integer = 0

        Do While index < items.Length
            passes += 1
            index += 1
        Loop
        Console.WriteLine($"Do While on an empty list: {passes} pass(es)")

        Dim three = {10, 20, 30}
        index = 0
        passes = 0
        Do While index < three.Length
            passes += 1
            index += 1
        Loop
        Console.WriteLine($"Do While on three items  : {passes} pass(es)")
    End Sub
End Module
