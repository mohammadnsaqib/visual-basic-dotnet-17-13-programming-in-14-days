' One procedure, written once, working on any type and checked at every call.
Imports System

Module Program
    Sub Swap(Of T)(ByRef left As T, ByRef right As T)
        Dim held As T = left
        left = right
        right = held
    End Sub

    Sub Main()
        Dim a As Integer = 1
        Dim b As Integer = 2
        Swap(a, b)
        Console.WriteLine($"integers : {a}, {b}")

        Dim first As String = "Cash"
        Dim second As String = "Rent"
        Swap(first, second)
        Console.WriteLine($"strings  : {first}, {second}")

        Dim one As Decimal = 12.5D
        Dim two As Decimal = 87.5D
        Swap(Of Decimal)(one, two)
        Console.WriteLine($"decimals : {one}, {two}")
        Console.WriteLine("the type argument was written once and inferred twice")
    End Sub
End Module
