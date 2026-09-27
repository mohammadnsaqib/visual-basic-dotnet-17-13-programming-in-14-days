' Preserve copies the old array into the new one, as far as it fits.
Imports System

Module Program
    Sub Main()
        Dim values() As Integer = {1, 2, 3}
        ReDim Preserve values(4)
        Console.WriteLine($"grown  : {String.Join(", ", values)}")
        ReDim Preserve values(1)
        Console.WriteLine($"shrunk : {String.Join(", ", values)}")
        Console.WriteLine("growing keeps everything; shrinking keeps what still fits")
    End Sub
End Module
