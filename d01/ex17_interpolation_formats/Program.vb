' An interpolation hole takes an alignment and a format, and both are optional.
Imports System
Imports System.Globalization
Imports System.Text

Module Program
    Sub Main()
        ' A pound sign is not ASCII. Without this line the console writes it in whatever
        ' code page the machine happens to use, and the reader sees a different
        ' character.
        Console.OutputEncoding = Encoding.UTF8

        Dim amount As Decimal = 1234.5D
        Dim uk = New CultureInfo("en-GB")

        Console.WriteLine($"plain      |{amount}|")
        Console.WriteLine($"two places |{amount:F2}|")
        Console.WriteLine($"grouped    |{amount:N2}|")
        Console.WriteLine($"right 14   |{amount,14:N2}|")
        Console.WriteLine($"left 14    |{amount,-14:N2}|")
        Console.WriteLine("as money   |" & amount.ToString("C2", uk) & "|")
        Console.WriteLine($"an escape  |{{not a hole}}|")
    End Sub
End Module
