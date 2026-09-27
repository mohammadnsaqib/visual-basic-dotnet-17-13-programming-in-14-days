' Every numeric type is a range and a size, and both are fixed.
Imports System

Module Program
    Sub Main()
        Console.WriteLine($"{"type",-8}{"bytes",6}  {"lowest",-31}{"highest",-31}")
        Report("SByte", 1, SByte.MinValue, SByte.MaxValue)
        Report("Byte", 1, Byte.MinValue, Byte.MaxValue)
        Report("Short", 2, Short.MinValue, Short.MaxValue)
        Report("Integer", 4, Integer.MinValue, Integer.MaxValue)
        Report("Long", 8, Long.MinValue, Long.MaxValue)
        Report("Single", 4, Single.MinValue, Single.MaxValue)
        Report("Double", 8, Double.MinValue, Double.MaxValue)
        Report("Decimal", 16, Decimal.MinValue, Decimal.MaxValue)
    End Sub

    Sub Report(name As String, bytes As Integer, low As Object, high As Object)
        Console.WriteLine($"{name,-8}{bytes,6}  {low,-31}{high,-31}")
    End Sub
End Module
