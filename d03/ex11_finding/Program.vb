' Every search hands back an index, and -1 is the answer for "not there".
Imports System

Module Program
    Sub Main()
        Dim line As String = "2026-09-10,rent,1200.00"
        Console.WriteLine($"IndexOf(""."")      : {line.IndexOf(".")}")
        Console.WriteLine($"IndexOf("","")      : {line.IndexOf(",")}")
        Console.WriteLine($"LastIndexOf("","")  : {line.LastIndexOf(",")}")
        Console.WriteLine($"IndexOf(""zzz"")    : {line.IndexOf("zzz")}")
        Console.WriteLine($"Contains(""rent"")  : {line.Contains("rent")}")
        Console.WriteLine($"StartsWith(""2026""): {line.StartsWith("2026")}")
        Dim first = line.IndexOf(",")
        Console.WriteLine($"Substring(0, first): {line.Substring(0, first)}")
    End Sub
End Module
