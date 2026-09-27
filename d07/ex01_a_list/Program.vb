' A list built, added to, read by index and walked. An array that grows.
Imports System
Imports System.Collections.Generic

Module Program
    Sub Main()
        Dim codes As New List(Of String)()
        codes.Add("AC-1000")
        codes.Add("AC-1001")
        codes.Add("AC-2000")
        codes.Insert(1, "AC-1000A")

        Console.WriteLine($"count    : {codes.Count}")
        Console.WriteLine($"first    : {codes(0)}")
        Console.WriteLine($"last     : {codes(codes.Count - 1)}")
        Console.WriteLine($"index of : {codes.IndexOf("AC-2000")}")
        Console.WriteLine($"contains : {codes.Contains("AC-9999")}")

        codes.Remove("AC-1000A")
        Console.WriteLine($"after Remove : {String.Join(", ", codes)}")

        codes.Sort()
        Console.WriteLine($"sorted       : {String.Join(", ", codes)}")

        For Each code In codes
            Console.WriteLine($"  {code}")
        Next
    End Sub
End Module
