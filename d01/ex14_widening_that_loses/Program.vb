' Widening promises no error, not no loss.
Imports System

Module Program
    Sub Main()
        Dim exactLong As Long = 9007199254740993L
        Dim asDouble As Double = exactLong
        Dim andBack As Long = CLng(asDouble)

        Console.WriteLine($"the Long        {exactLong}")
        Console.WriteLine($"widened to Double and back {andBack}")
        Console.WriteLine($"same value      {exactLong = andBack}")
        Console.WriteLine($"difference      {exactLong - andBack}")
        Console.WriteLine("Long to Double is a widening conversion, and it lost a " &
                          "digit")
    End Sub
End Module
