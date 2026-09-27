' What a class means by equal, when nobody has told it, and what a structure that was
' told means.
Imports System
Imports Tally

Class Tagged
    Public Code As String
End Class

Module Program
    Sub Main()
        Dim p As New Tagged() With {.Code = "AC"}
        Dim q As New Tagged() With {.Code = "AC"}
        Dim r = p

        Console.WriteLine($"p Equals q : {p.Equals(q)}")
        Console.WriteLine($"p Is q     : {p Is q}")
        Console.WriteLine($"p Equals r : {p.Equals(r)}")
        Console.WriteLine($"p Is r     : {p Is r}")

        Dim one As New Money(12.5D)
        Dim other As New Money(12.5D)
        Console.WriteLine($"Money Equals Money : {one.Equals(other)}")
        Console.WriteLine($"Money hashes match : " &
                          $"{one.GetHashCode() = other.GetHashCode()}")
    End Sub
End Module
