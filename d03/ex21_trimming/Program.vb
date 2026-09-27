' Trim removes white space from both ends, and nothing from the middle.
Imports System

Module Program
    Sub Main()
        Dim messy As String = vbTab & "  rent  paid " & vbCrLf
        Console.WriteLine($"raw       : " &
            $"[{messy.Replace(vbTab, "<tab>").Replace(vbCrLf, "<crlf>")}]")
        Console.WriteLine($"Trim      : [{messy.Trim()}]")
        Console.WriteLine($"TrimStart : " &
                          $"[{messy.TrimStart().Replace(vbCrLf, "<crlf>")}]")
        Console.WriteLine($"TrimEnd   : [{messy.TrimEnd().Replace(vbTab, "<tab>")}]")
        Console.WriteLine($"the two spaces between rent and paid are still there: " &
                          $"{messy.Trim().Contains("  ")}")
    End Sub
End Module
