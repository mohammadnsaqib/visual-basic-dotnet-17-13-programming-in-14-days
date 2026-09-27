' Day 9. Two reports over the ledger, each written as a query.
'
' A report is a title and a sequence of lines, and nothing else. Both of these are queries, so
' neither builds a collection of its own: the lines are produced as the caller reads them, and
' a report that is never printed does no work at all.

Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace Global.Tally

    ' --8<-- TrialBalance
    ''' <summary>Every account with a balance, and the total those balances come to.</summary>
    Public NotInheritable Class TrialBalance
        Implements IReport

        Private ReadOnly _books As Ledger

        Public Sub New(books As Ledger)
            If books Is Nothing Then
                Throw New ArgumentNullException(NameOf(books))
            End If
            _books = books
        End Sub

        Public ReadOnly Property Title As String Implements IReport.Title
            Get
                Return "Trial balance"
            End Get
        End Property

        Public Function Lines() As IEnumerable(Of String) Implements IReport.Lines
            Dim rows = From account In _books
                       Where account.Balance <> 0D
                       Order By account.Code
                       Select $"{account.Code}  {account.Name,-10} {account.Balance,12:N2}"
            Return rows.Concat({$"{"total",-20} {_books.Balance,12:N2}"})
        End Function

    End Class
    ' --8<--

    ' --8<-- ByAccount
    ''' <summary>What was posted, gathered by account rather than by the order it arrived.</summary>
    Public NotInheritable Class ByAccount
        Implements IReport

        Private ReadOnly _books As Ledger

        Public Sub New(books As Ledger)
            If books Is Nothing Then
                Throw New ArgumentNullException(NameOf(books))
            End If
            _books = books
        End Sub

        Public ReadOnly Property Title As String Implements IReport.Title
            Get
                Return "Postings by account"
            End Get
        End Property

        Public Function Lines() As IEnumerable(Of String) Implements IReport.Lines
            Return From posting In _books.Postings
                   Group posting By Code = posting.Account
                   Into Made = Count(), Moved = Sum(posting.Signed)
                   Order By Code
                   Select $"{Code}  {Made,3} posting(s) {Moved,12:N2}"
        End Function

    End Class
    ' --8<--

End Namespace
