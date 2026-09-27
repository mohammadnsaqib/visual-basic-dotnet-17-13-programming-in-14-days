' ByRef hands over the variable itself.
Imports System
Imports System.Collections.Generic

Module Program
    Sub Main()
        Dim number As Integer = 1
        Bump(number)
        Console.WriteLine($"the Integer is now {number}")

        Dim names As New List(Of String) From {"a"}
        Replace(names)
        Console.WriteLine($"the List now holds {names.Count} item(s)")

        Dim parsed As Integer
        Dim ok = Integer.TryParse("512", parsed)
        Console.WriteLine($"TryParse returned {ok} and set its ByRef argument to " &
                          $"{parsed}")
    End Sub

    Sub Bump(ByRef n As Integer)
        n += 1
    End Sub

    Sub Replace(ByRef items As List(Of String))
        items = New List(Of String) From {"x", "y", "z"}
    End Sub
End Module
