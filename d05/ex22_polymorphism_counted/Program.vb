' One loop, one method call, and two different methods reached.
Imports System
Imports System.Collections.Generic
Imports Tally

Module Program
    Sub Main()
        Dim postings As New List(Of Posting)
        For i = 1 To 6
            If i Mod 2 = 0 Then
                postings.Add(New Debit($"AC-100{i}", i * 100D))
            Else
                postings.Add(New Credit($"AC-100{i}", i * 100D))
            End If
        Next

        Dim debits As Integer = 0
        Dim credits As Integer = 0
        Dim net As Decimal = 0D
        For Each posting In postings
            If posting.Kind = "Debit" Then debits += 1 Else credits += 1
            net += posting.Signed
        Next

        Console.WriteLine($"postings : {postings.Count}")
        Console.WriteLine($"debits   : {debits}")
        Console.WriteLine($"credits  : {credits}")
        Console.WriteLine($"net      : {net:N2}")
        Console.WriteLine("the counting loop reads Kind and Signed and names neither " &
                          "class")
    End Sub
End Module
