' A dictionary is asked by key, and answers without looking at the other entries.
Imports System
Imports System.Collections.Generic

Module Program
    Sub Main()
        Dim names As New Dictionary(Of String, String)()
        names.Add("AC-1000", "Cash")
        names.Add("AC-1001", "Rent")
        names("AC-2000") = "Sales"

        Console.WriteLine($"count      : {names.Count}")
        Console.WriteLine($"AC-1001    : {names("AC-1001")}")
        Console.WriteLine($"has AC-2000: {names.ContainsKey("AC-2000")}")
        Console.WriteLine($"has AC-9999: {names.ContainsKey("AC-9999")}")

        names("AC-1001") = "Rent and rates"
        Console.WriteLine($"after assignment : {names("AC-1001")}")
        Console.WriteLine($"count is still   : {names.Count}")

        For Each pair In names
            Console.WriteLine($"  {pair.Key} {pair.Value}")
        Next
    End Sub
End Module
