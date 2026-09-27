' Substring is measured in characters, and it will not read past the last one.
Imports System

Module Program
    Sub Main()
        Dim word As String = "ledger"
        Console.WriteLine($"Substring(2)    : {word.Substring(2)}")
        Console.WriteLine($"Substring(2, 3) : {word.Substring(2, 3)}")
        Console.WriteLine("Substring(2, 9) :")
        Console.WriteLine(word.Substring(2, 9))
    End Sub
End Module
