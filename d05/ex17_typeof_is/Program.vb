' TypeOf ... Is asks whether an object can be used as a type.
Imports System

Public Interface IDescribable
    Function Describe() As String
End Interface

Public Class Document
End Class

Public Class Invoice
    Inherits Document
    Implements IDescribable
    Public Function Describe() As String Implements IDescribable.Describe
        Return "an invoice"
    End Function
End Class

Module Program
    Sub Main()
        Dim bill As Object = New Invoice()
        Console.WriteLine($"TypeOf bill Is Invoice      : {TypeOf bill Is Invoice}")
        Console.WriteLine($"TypeOf bill Is Document     : {TypeOf bill Is Document}")
        Console.WriteLine($"TypeOf bill Is IDescribable : " &
                          $"{TypeOf bill Is IDescribable}")
        Console.WriteLine($"TypeOf bill Is String       : {TypeOf bill Is String}")

        Dim plain As Object = New Document()
        Console.WriteLine($"a plain Document Is IDescribable : " &
                          $"{TypeOf plain Is IDescribable}")
    End Sub
End Module
