' A set holds each value once. Adding a value it already holds reports False and changes
' nothing.
Imports System
Imports System.Collections.Generic

Module Program
    Sub Main()
        Dim seen As New HashSet(Of String)()
        Dim arriving = New String() {"AC-1000", "AC-1001", "AC-1000", "AC-2000",
                                     "AC-1001"}

        For Each code In arriving
            Console.WriteLine($"  Add {code} : {seen.Add(code)}")
        Next
        Console.WriteLine($"arrived : {arriving.Length}")
        Console.WriteLine($"held    : {seen.Count}")
        Console.WriteLine($"contains AC-2000 : {seen.Contains("AC-2000")}")

        Dim other As New HashSet(Of String)(New String() {"AC-2000", "AC-3000"})
        Dim both As New HashSet(Of String)(seen)
        both.IntersectWith(other)
        Console.WriteLine($"in both : {String.Join(", ", both)}")
    End Sub
End Module
