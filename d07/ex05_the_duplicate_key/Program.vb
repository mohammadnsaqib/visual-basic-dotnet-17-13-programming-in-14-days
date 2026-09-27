' Add refuses a key that is already there. The assignment form does not.
Imports System
Imports System.Collections.Generic

Module Program
    Sub Main()
        Dim names As New Dictionary(Of String, String)()
        names.Add("AC-1000", "Cash")
        names("AC-1000") = "Cash at bank"
        Console.WriteLine($"after an assignment over the same key : {names("AC-1000")}")
        Console.WriteLine($"count : {names.Count}")

        Console.WriteLine("Add with the same key again:")
        names.Add("AC-1000", "Petty cash")
        Console.WriteLine($"never printed : {names.Count}")
    End Sub
End Module
