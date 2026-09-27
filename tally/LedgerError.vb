' Day 8. What the ledger throws, and why it is a type of its own.
'
' A caller that catches Exception cannot tell a mistake in the books from a mistake in the
' program. LedgerError names the first kind, so a caller can catch that and leave the second
' kind alone. It carries the account it is about, because a message that has to be read to
' find out which account failed is a message a program cannot act on.

Imports System

Namespace Global.Tally

    ' --8<-- LedgerError
    Public Class LedgerError
        Inherits Exception

        ''' <summary>The account this failure is about, or Nothing when it is about the
        ''' entry.</summary>
        Public ReadOnly Property Account As String

        Public Sub New(message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(message As String, account As String)
            MyBase.New(message)
            _Account = account
        End Sub

        Public Sub New(message As String, inner As Exception)
            MyBase.New(message, inner)
        End Sub

    End Class
    ' --8<--

End Namespace
