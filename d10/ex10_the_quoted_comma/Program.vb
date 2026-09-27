' One row with a comma inside a field. The same code now reports four fields.
Imports System
Imports System.IO

Module Program
    Sub Main()
        Dim rows = New String() {"AC-1000,Cash,3800.00",
                                 "AC-1001,""Rent, rates and water"",1200.00",
                                 "AC-4000,Sales,-5000.00"}

        Dim wrong As Integer = 0
        For Each row In rows
            Dim fields = row.Split(","c)
            If fields.Length <> 3 Then
                wrong += 1
            End If
            Console.WriteLine($"  {fields.Length} field(s) : " &
                              $"[{String.Join("] [", fields)}]")
        Next
        Console.WriteLine($"rows with the wrong field count : {wrong}")
        Console.WriteLine("the name arrived in two pieces and the balance moved one " &
                          "place right")
    End Sub
End Module
