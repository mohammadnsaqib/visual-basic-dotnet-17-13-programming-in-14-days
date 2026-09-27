' Two ways to ask for a key that may not be there, and one way that is not.
Imports System
Imports System.Collections.Generic

Module Program
    Sub Main()
        Dim names As New Dictionary(Of String, String)()
        names.Add("AC-1000", "Cash")

        Dim found As String = Nothing
        If names.TryGetValue("AC-1000", found) Then
            Console.WriteLine($"TryGetValue found  : {found}")
        End If
        If Not names.TryGetValue("AC-9999", found) Then
            Console.WriteLine($"TryGetValue missing: [{If(found, "Nothing")}]")
        End If

        If names.ContainsKey("AC-9999") Then
            Console.WriteLine("never printed")
        Else
            Console.WriteLine("ContainsKey missing: False")
        End If

        Try
            Console.WriteLine(names("AC-9999"))
        Catch ex As KeyNotFoundException
            Console.WriteLine($"the indexer threw  : {ex.GetType().Name}")
        End Try

        Dim byCode As New Dictionary(Of String,
                                     String)(StringComparer.OrdinalIgnoreCase)
        byCode.Add("AC-1000", "Cash")
        Console.WriteLine($"ignoring case, ac-1000 : {byCode("ac-1000")}")
    End Sub
End Module
