' Every type this chapter used, with what it is and what it holds by default.
Imports System
Imports System.Runtime.CompilerServices

Module Program
    Sub Main()
        Console.WriteLine($"{"type",-9}{"kind",-11}{"bytes",6}  default")
        Show(Of Byte)("Byte")
        Show(Of Short)("Short")
        Show(Of Integer)("Integer")
        Show(Of Long)("Long")
        Show(Of Single)("Single")
        Show(Of Double)("Double")
        Show(Of Decimal)("Decimal")
        Show(Of Boolean)("Boolean")
        Show(Of Char)("Char")
        Show(Of Date)("Date")
        Console.WriteLine($"{"String",-9}{"reference",-11}{"",6}  (Nothing)")
    End Sub

    ' Unsafe.SizeOf answers "how much memory does one of these take", which is the
    ' question. Marshal.SizeOf answers "how wide is it when handed to unmanaged code",
    ' which is a different number for Boolean and Char, and no number at all for Date. A
    ' Char's default is the code unit 0, and printing it puts a byte into the output
    ' that no reader can see and no typesetter will accept. What is worth printing is
    ' the fact, so a value with no printable form is described rather than shown.
    Sub Show(Of T As Structure)(name As String)
        Dim value = New T().ToString()
        Dim printable = value.Length > 0 AndAlso
                        Not Char.IsControl(value(0))
        Console.WriteLine($"{name,-9}{"value",-11}{Unsafe.SizeOf(Of T)(),6}  " &
                          $"{If(printable, value, "(code unit 0)")}")
    End Sub
End Module
