' A variable has a type from the moment it is declared.
Imports System

Module Program
    Sub Main()
        Dim written As Integer = 41
        Dim inferred = 41
        Const fixedValue As Integer = 41

        Console.WriteLine($"written  : {written.GetType().Name}")
        Console.WriteLine($"inferred : {inferred.GetType().Name}")
        Console.WriteLine($"constant : {fixedValue.GetType().Name}")
        Console.WriteLine($"all three hold {written}")
    End Sub
End Module
