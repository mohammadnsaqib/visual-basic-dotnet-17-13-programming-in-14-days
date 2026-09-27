' A stack removes the same choice and answers it the other way round.
Imports System
Imports System.Collections.Generic

Module Program
    Sub Main()
        Dim undo As New Stack(Of String)()
        undo.Push("open AC-1000")
        undo.Push("post 1200")
        undo.Push("post 87.50")

        Console.WriteLine($"held    : {undo.Count}")
        Console.WriteLine($"on top  : {undo.Peek()}")

        While undo.Count > 0
            Console.WriteLine($"  undoing {undo.Pop()}")
        End While

        Console.WriteLine($"empty   : {undo.Count}")
        Console.WriteLine("a queue gives back the oldest, a stack the newest")
    End Sub
End Module
