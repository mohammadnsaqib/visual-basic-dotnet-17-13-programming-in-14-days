' Nothing in a value type is that type's zero, not an absent value.
Imports System

Module Program
    Sub Main()
        Dim count As Integer = Nothing
        Dim rate As Double = Nothing
        Dim flag As Boolean = Nothing
        Dim moment As Date = Nothing

        Console.WriteLine($"Integer  {count}")
        Console.WriteLine($"Double   {rate}")
        Console.WriteLine($"Boolean  {flag}")
        Console.WriteLine($"Date     {moment:yyyy-MM-dd}")
        Console.WriteLine($"the Integer is zero, not missing: {count = 0}")
    End Sub
End Module
