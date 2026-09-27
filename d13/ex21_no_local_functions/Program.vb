' One of the gaps, stated by the compiler rather than by this book.
Imports System

Module Program
    Sub Main()
        Dim amounts = New Decimal() {1200D, 87.5D}

        Function Double_(amount As Decimal) As Decimal
            Return amount * 2D
        End Function

        Console.WriteLine(Double_(amounts(0)))
    End Sub
End Module
