' Two strings can be equal by one comparison and different by another.
Imports System
Imports System.Globalization

Module Program
    Sub Main()
        Dim a As String = "ledger"
        Dim b As String = "LEDGER"

        Console.WriteLine($"Ordinal          : " &
                          $"{String.Equals(a, b, StringComparison.Ordinal)}")
        Console.WriteLine($"OrdinalIgnoreCase: " &
                          $"{String.Equals(a, b, StringComparison.OrdinalIgnoreCase)}")
        Console.WriteLine($"the = operator   : {a = b}")

        Dim one As String = "co-op"
        Dim two As String = "coop"
        Console.WriteLine($"Compare ordinal  : " &
                          $"{String.Compare(one, two, StringComparison.Ordinal)}")
        Console.WriteLine($"Compare culture  : " &
            $"{String.Compare(one, two, StringComparison.InvariantCulture)}")
    End Sub
End Module
