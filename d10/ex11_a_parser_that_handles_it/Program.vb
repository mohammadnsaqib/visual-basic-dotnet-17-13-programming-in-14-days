' A parser that reads the quotes. It is about thirty lines, and Split is one.
Imports System
Imports System.Collections.Generic
Imports System.Text

Module Program
    Function Fields(row As String) As List(Of String)
        Dim found As New List(Of String)()
        Dim held As New StringBuilder()
        Dim inQuotes As Boolean = False
        Dim at As Integer = 0

        While at < row.Length
            Dim c = row(at)
            If inQuotes Then
                If c = """"c Then
                    If at + 1 < row.Length AndAlso row(at + 1) = """"c Then
                        held.Append(""""c)
                        at += 1
                    Else
                        inQuotes = False
                    End If
                Else
                    held.Append(c)
                End If
            ElseIf c = """"c Then
                inQuotes = True
            ElseIf c = ","c Then
                found.Add(held.ToString())
                held.Clear()
            Else
                held.Append(c)
            End If
            at += 1
        End While

        found.Add(held.ToString())
        Return found
    End Function

    Sub Main()
        Dim rows = New String() {"AC-1000,Cash,3800.00",
                                 "AC-1001,""Rent, rates and water"",1200.00",
                                 "AC-4000,""Sales of """"goods"""""",-5000.00"}
        For Each row In rows
            Dim parts = Fields(row)
            Console.WriteLine($"  {parts.Count} field(s) : " &
                              $"[{String.Join("] [", parts)}]")
        Next
    End Sub
End Module
