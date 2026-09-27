' One more value than the type has. HasValue asks whether this is that value.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim known As Integer? = 42
        Dim missing As Integer? = Nothing

        Console.WriteLine($"known.HasValue   : {known.HasValue}")
        Console.WriteLine($"known.Value      : {known.Value}")
        Console.WriteLine($"missing.HasValue : {missing.HasValue}")
        Console.WriteLine($"missing default  : {missing.GetValueOrDefault()}")
        Console.WriteLine($"missing as text  : [{missing}]")
        Console.WriteLine($"missing Is Nothing : {missing Is Nothing}")

        Console.WriteLine($"declared type    : {GetType(Nullable(Of Integer)).Name}")
        Console.WriteLine($"underlying type  : " &
                          $"{Nullable.GetUnderlyingType(GetType(Integer?)).Name}")

        Dim boxedKnown As Object = known
        Dim boxedMissing As Object = missing
        Console.WriteLine($"boxed known   : {boxedKnown.GetType().Name}")
        Console.WriteLine($"boxed missing : " &
                          $"{If(boxedMissing Is Nothing, "Nothing", "an object")}")

        Dim owed As Money? = New Money(9.99D)
        Console.WriteLine($"a Money? : {owed.Value} of type " &
                          $"{owed.Value.GetType().Name}")
    End Sub
End Module
