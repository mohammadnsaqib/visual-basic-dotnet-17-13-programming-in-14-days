' Day 5. What can be posted to an account, and the two kinds there are.
'
' A posting is an amount aimed at an account. The two kinds differ in one thing only -- the
' direction they move the balance -- so that difference is the single MustOverride member and
' everything else is written once in the base class.

Imports System

Namespace Global.Tally

    ' --8<-- Posting
    Public MustInherit Class Posting

        Public ReadOnly Property Account As String
        Public ReadOnly Property Amount As Decimal

        Protected Sub New(account As String, amount As Decimal)
            If String.IsNullOrWhiteSpace(account) Then
                Throw New ArgumentException("a posting needs an account", NameOf(account))
            End If
            If amount <= 0D Then
                Throw New ArgumentOutOfRangeException(NameOf(amount),
                                                      "a posting is a positive amount")
            End If
            _Account = account.Trim()
            _Amount = amount
        End Sub

        ''' <summary>What this kind of posting is called: Debit or Credit.</summary>
        Public MustOverride ReadOnly Property Kind As String

        ''' <summary>What this posting adds to a balance. The sign is the whole
        ''' difference.</summary>
        Public MustOverride ReadOnly Property Signed As Decimal

        Public Sub ApplyTo(target As Account)
            target.Post(Signed)
        End Sub

        Public Overrides Function ToString() As String
            Return $"{Kind,-6} {Account,-10} {Amount,10:N2}"
        End Function

    End Class

    Public NotInheritable Class Debit
        Inherits Posting

        Public Sub New(account As String, amount As Decimal)
            MyBase.New(account, amount)
        End Sub

        Public Overrides ReadOnly Property Kind As String
            Get
                Return "Debit"
            End Get
        End Property

        Public Overrides ReadOnly Property Signed As Decimal
            Get
                Return Amount
            End Get
        End Property
    End Class

    Public NotInheritable Class Credit
        Inherits Posting

        Public Sub New(account As String, amount As Decimal)
            MyBase.New(account, amount)
        End Sub

        Public Overrides ReadOnly Property Kind As String
            Get
                Return "Credit"
            End Get
        End Property

        Public Overrides ReadOnly Property Signed As Decimal
            Get
                Return -Amount
            End Get
        End Property
    End Class
    ' --8<--

End Namespace
