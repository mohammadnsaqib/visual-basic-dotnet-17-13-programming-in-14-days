' A queue removes the choice of which item comes next. The first one in is the first one
' out.
Imports System
Imports System.Collections.Generic

Module Program
    Sub Main()
        Dim waiting As New Queue(Of String)()
        waiting.Enqueue("rent")
        waiting.Enqueue("wages")
        waiting.Enqueue("power")

        Console.WriteLine($"waiting : {waiting.Count}")
        Console.WriteLine($"next up : {waiting.Peek()}")
        Console.WriteLine($"still   : {waiting.Count}")

        While waiting.Count > 0
            Console.WriteLine($"  handling {waiting.Dequeue()}")
        End While

        Console.WriteLine($"empty   : {waiting.Count}")
        Dim taken As String = Nothing
        Console.WriteLine($"TryDequeue on an empty queue : {waiting.TryDequeue(taken)}")
    End Sub
End Module
