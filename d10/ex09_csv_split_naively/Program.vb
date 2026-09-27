' Splitting on commas. It works, for as long as the data lets it.
Imports System
Imports System.IO

Module Program
    Sub Main()
        Dim rows = New String() {"AC-1000,Cash,3800.00",
                                 "AC-1001,Rent,1200.00",
                                 "AC-4000,Sales,-5000.00"}

        For Each row In rows
            Dim fields = row.Split(","c)
            Console.WriteLine($"  {fields.Length} field(s) : " &
                              $"[{String.Join("] [", fields)}]")
        Next
        Console.WriteLine("three fields every time, and every one of them is right")
    End Sub
End Module
