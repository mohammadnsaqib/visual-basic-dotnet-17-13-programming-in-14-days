' A derived class supplies the part the base class could not.
Imports System

Public MustInherit Class Posting
    Public ReadOnly Property Amount As Decimal
    Protected Sub New(amount As Decimal)
        _Amount = amount
    End Sub
    Public MustOverride ReadOnly Property Signed As Decimal
    Public Function Describe() As String
        Return $"{Amount:N2} applied as {Signed:N2}"
    End Function
End Class

Public Class Debit
    Inherits Posting
    Public Sub New(amount As Decimal)
        MyBase.New(amount)
    End Sub
    Public Overrides ReadOnly Property Signed As Decimal
        Get
            Return Amount
        End Get
    End Property
End Class

Public Class Credit
    Inherits Posting
    Public Sub New(amount As Decimal)
        MyBase.New(amount)
    End Sub
    Public Overrides ReadOnly Property Signed As Decimal
        Get
            Return -Amount
        End Get
    End Property
End Class

Module Program
    Sub Main()
        Dim items As Posting() = {New Debit(1200D), New Credit(1200D)}
        For Each item In items
            Console.WriteLine($"  {item.GetType().Name,-7} {item.Describe()}")
        Next
        Console.WriteLine("Describe is written once, in the class that cannot be made")
    End Sub
End Module
