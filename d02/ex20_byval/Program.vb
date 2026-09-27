' ByVal copies the argument. For a reference type, the copy is the reference.
Imports System
Imports System.Collections.Generic

Module Program
    Sub Main()
        Dim number As Integer = 1
        Bump(number)
        Console.WriteLine($"the Integer is still {number}")

        Dim names As New List(Of String) From {"a"}
        AddOne(names)
        Console.WriteLine($"the List now holds {names.Count} item(s)")

        Replace(names)
        Console.WriteLine($"after Replace it still holds {names.Count} item(s)")
    End Sub

    Sub Bump(ByVal n As Integer)
        n += 1
    End Sub

    Sub AddOne(ByVal items As List(Of String))
        items.Add("b")
    End Sub

    Sub Replace(ByVal items As List(Of String))
        items = New List(Of String) From {"x", "y", "z"}
    End Sub
End Module
