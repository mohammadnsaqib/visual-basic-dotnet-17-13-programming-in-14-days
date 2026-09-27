' An iterator that never ends, and a loop that stops. Only what is asked for is made.
Imports System
Imports System.Collections.Generic

Module Program
    Iterator Function Naturals() As IEnumerable(Of Integer)
        Dim n As Integer = 1
        Do
            Yield n
            n += 1
        Loop
    End Function

    Iterator Function Squares(
            source As IEnumerable(Of Integer)) As IEnumerable(Of Integer)
        For Each n In source
            Yield n * n
        Next
    End Function

    Sub Main()
        Dim taken As Integer = 0
        For Each square In Squares(Naturals())
            Console.Write($"{square} ")
            taken += 1
            If taken = 8 Then
                Exit For
            End If
        Next
        Console.WriteLine()
        Console.WriteLine($"took {taken} from a sequence with no end")
        Console.WriteLine("neither function held a collection, and neither ran to " &
                          "completion")
    End Sub
End Module
