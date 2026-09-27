' Three inputs, one of which fails. The loop keeps going because the failure is dealt
' with.
Imports System

Module Program
    Sub Main()
        Dim inputs = New String() {"120", "twelve", "-4"}
        For Each reading In inputs
            Try
                Dim amount = Integer.Parse(reading)
                Console.WriteLine($"{reading,-8} parsed as {amount}")
            Catch ex As FormatException
                Console.WriteLine($"{reading,-8} refused : {ex.GetType().Name}")
            End Try
        Next
        Console.WriteLine("all three were attempted")
    End Sub
End Module
