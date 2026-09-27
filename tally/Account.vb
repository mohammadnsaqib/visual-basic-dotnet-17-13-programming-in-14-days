' Day 4. The first type of the ledger.
'
' An account has a code, a name and a running balance. The balance is the only part that
' changes, and it changes in exactly one way: something is posted to it. Everything else about
' the account is fixed when it is made, which is why those are read-only properties and the
' constructor refuses to build one that is not usable.

Imports System

Namespace Global.Tally

    ' --8<-- Account
    Public Class Account

        Private _balance As Decimal

        ''' <summary>The short code the ledger refers to this account by, such as
        ''' AC-1001.</summary>
        Public ReadOnly Property Code As String

        ''' <summary>What a person calls this account.</summary>
        Public ReadOnly Property Name As String

        ''' <summary>What is in the account now. Changed only by Post.</summary>
        Public ReadOnly Property Balance As Decimal
            Get
                Return _balance
            End Get
        End Property

        Public Sub New(code As String, name As String, Optional opening As Decimal = 0D)
            ' A constructor's job is to leave the object usable, and to refuse to build one
            ' that is not. An account with no code cannot be posted to or reported on, so it
            ' is not an account and this will not make one.
            If String.IsNullOrWhiteSpace(code) Then
                Throw New ArgumentException("an account needs a code", NameOf(code))
            End If
            If String.IsNullOrWhiteSpace(name) Then
                Throw New ArgumentException("an account needs a name", NameOf(name))
            End If
            _Code = code.Trim()
            _Name = name.Trim()
            _balance = opening
        End Sub

        ''' <summary>Add an amount to the balance. A negative amount takes money
        ''' out.</summary>
        Public Sub Post(amount As Decimal)
            _balance += amount
        End Sub

        Public Overrides Function ToString() As String
            Return $"{Code} {Name} {Balance:N2}"
        End Function

    End Class
    ' --8<--

End Namespace
