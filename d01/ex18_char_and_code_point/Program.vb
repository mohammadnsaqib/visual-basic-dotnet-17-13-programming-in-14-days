' A String is a sequence of Char, and a Char is a number.
Imports System
Imports System.Runtime.CompilerServices

Module Program
    Sub Main()
        Dim word As String = "Basic"
        Console.WriteLine($"{word} has {word.Length} characters")
        For i = 0 To word.Length - 1
            Dim c As Char = word(i)
            Console.WriteLine($"  index {i}: {c} is code point {AscW(c)}")
        Next
        Console.WriteLine($"ChrW(66) is {ChrW(66)}")
        Console.WriteLine($"a Char occupies {Unsafe.SizeOf(Of Char)()} bytes, not 1")
    End Sub
End Module
