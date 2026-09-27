' The attribute changes nothing about the arithmetic. It changes what the value can say
' about itself.
Imports System

<Flags>
Enum Marked
    None = 0
    Red = 1
    Green = 2
    Blue = 4
End Enum

Enum Unmarked
    None = 0
    Red = 1
    Green = 2
    Blue = 4
End Enum

Module Program
    Sub Main()
        Dim withAttribute As Marked = Marked.Red Or Marked.Blue
        Dim without As Unmarked = Unmarked.Red Or Unmarked.Blue

        Console.WriteLine($"marked   : {withAttribute}")
        Console.WriteLine($"unmarked : {without}")
        Console.WriteLine($"the numbers are the same : {CInt(withAttribute)} and " &
                          $"{CInt(without)}")
        Console.WriteLine($"single members still print : {Marked.Blue} and " &
                          $"{Unmarked.Blue}")
        Console.WriteLine($"HasFlag works on both : " &
                          $"{withAttribute.HasFlag(Marked.Blue)} and " &
                          $"{without.HasFlag(Unmarked.Blue)}")
    End Sub
End Module
