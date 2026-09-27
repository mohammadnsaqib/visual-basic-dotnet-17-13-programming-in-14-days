' Upper case is a question about a language, not about a character.
Imports System
Imports System.Globalization
Imports System.Text

Module Program
    Sub Main()
        Console.OutputEncoding = Encoding.UTF8
        Dim word As String = "invoice"
        Dim tr = New CultureInfo("tr-TR")
        Dim en = New CultureInfo("en-US")

        Console.WriteLine($"en-US ToUpper : {word.ToUpper(en)}")
        Console.WriteLine($"tr-TR ToUpper : {word.ToUpper(tr)}")
        Console.WriteLine($"Invariant     : {word.ToUpperInvariant()}")
        Console.WriteLine($"the two agree : {word.ToUpper(en) = word.ToUpper(tr)}")
        Console.WriteLine("Turkish has a dotted capital I, so the i does not fold " &
                          "the same way")
    End Sub
End Module
