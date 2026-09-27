' Day 7. The collection the rest of the book posts into.
'
' A ledger is two collections that have to agree: the accounts, reached by code, and the
' postings, kept in the order they arrived. The accounts are a Dictionary because the question
' asked of them is always "which account is AC-1001", and the postings are a List because the
' question asked of them is always "what happened, in order".
'
' Opening an account with a code already in use throws. That is deliberate: a ledger with two
' accounts called AC-1001 cannot be reported on, and the failure should happen at the moment
' the mistake is made rather than in a report nobody can explain.

Imports System
Imports System.Collections
Imports System.Collections.Generic

Namespace Global.Tally

    ' --8<-- Ledger
    Public NotInheritable Class Ledger
        Implements IEnumerable(Of Account)

        Private ReadOnly _accounts As New Dictionary(Of String, Account)(
            StringComparer.OrdinalIgnoreCase)
        Private ReadOnly _order As New List(Of String)()
        Private ReadOnly _postings As New List(Of Posting)()

        ''' <summary>Raised after a posting has been applied. Day 13. The ledger knows
        ''' nothing about who is listening, and works with nobody listening at
        ''' all.</summary>
        Public Event Posted As EventHandler(Of PostingEventArgs)

        ''' <summary>How many accounts are open.</summary>
        Public ReadOnly Property Count As Integer
            Get
                Return _accounts.Count
            End Get
        End Property

        ''' <summary>Every posting applied so far, in the order it was applied.</summary>
        Public ReadOnly Property Postings As IReadOnlyList(Of Posting)
            Get
                Return _postings
            End Get
        End Property

        ''' <summary>Open an account. The code must not already be in use.</summary>
        Public Function Open(code As String, name As String,
                             Optional opening As Decimal = 0D) As Account
            Dim account As New Account(code, name, opening)
            _accounts.Add(account.Code, account)
            _order.Add(account.Code)
            Return account
        End Function

        ''' <summary>The account with this code, or Nothing when there is none.</summary>
        Public Function Find(code As String) As Account
            Dim found As Account = Nothing
            _accounts.TryGetValue(If(code, ""), found)
            Return found
        End Function

        ''' <summary>Apply a posting to the account it names.</summary>
        Public Sub Apply(posting As Posting)
            Dim target = Find(posting.Account)
            If target Is Nothing Then
                Throw New KeyNotFoundException($"no account {posting.Account}")
            End If
            posting.ApplyTo(target)
            _postings.Add(posting)
            RaiseEvent Posted(Me, New PostingEventArgs(posting, target.Balance))
        End Sub

        ''' <summary>Apply several postings together, or none of them.
        ''' Day 8. An entry is a set of postings that must add to zero and must name accounts
        ''' that exist. Both conditions are checked before anything is applied, so a refused
        ''' entry leaves the books exactly as they were.</summary>
        Public Sub PostEntry(ParamArray entry As Posting())
            If entry Is Nothing OrElse entry.Length = 0 Then
                Throw New LedgerError("an entry needs at least one posting")
            End If
            Dim net As Decimal = 0D
            For Each posting In entry
                If Find(posting.Account) Is Nothing Then
                    Throw New LedgerError($"account {posting.Account} is not open",
                                          posting.Account)
                End If
                net += posting.Signed
            Next
            If net <> 0D Then
                Throw New LedgerError($"the entry is out by {net:N2}")
            End If
            For Each posting In entry
                Apply(posting)
            Next
        End Sub

        ''' <summary>Every balance added together. A ledger in balance reports zero.</summary>
        Public ReadOnly Property Balance As Decimal
            Get
                Dim total As Decimal = 0D
                For Each account In Me
                    total += account.Balance
                Next
                Return total
            End Get
        End Property

        ''' <summary>The accounts, in the order they were opened.</summary>
        Public Iterator Function GetEnumerator() As IEnumerator(Of Account) _
                Implements IEnumerable(Of Account).GetEnumerator
            For Each code In _order
                Yield _accounts(code)
            Next
        End Function

        Private Function GetUntypedEnumerator() As IEnumerator _
                Implements IEnumerable.GetEnumerator
            Return GetEnumerator()
        End Function

    End Class
    ' --8<--

End Namespace
