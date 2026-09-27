' Day 14. A set of postings that belong together, and the rule that makes them an entry.
'
' Day 8 checked the rule inside Ledger.PostEntry, which meant an unbalanced set of postings
' could exist as long as nobody posted it. An Entry cannot: the constructor refuses to build
' one. That is the difference between a rule the program checks and a rule the type carries,
' and the second kind cannot be forgotten at a call site.

Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace Global.Tally

    ' --8<-- Entry
    Public NotInheritable Class Entry

        ''' <summary>What this entry was for, in a few words.</summary>
        Public ReadOnly Property Memo As String

        ''' <summary>The postings, in the order they were given.</summary>
        Public ReadOnly Property Postings As IReadOnlyList(Of Posting)

        Public Sub New(memo As String, ParamArray postings As Posting())
            If String.IsNullOrWhiteSpace(memo) Then
                Throw New LedgerError("an entry needs a memo")
            End If
            If postings Is Nothing OrElse postings.Length < 2 Then
                Throw New LedgerError("an entry needs at least two postings")
            End If
            Dim net = postings.Sum(Function(posting) posting.Signed)
            If net <> 0D Then
                Throw New LedgerError($"the entry is out by {net:N2}")
            End If
            _Memo = memo.Trim()
            _Postings = postings.ToList()
        End Sub

        ''' <summary>What this entry moves in total, which is always zero.</summary>
        Public ReadOnly Property Net As Decimal
            Get
                Return Postings.Sum(Function(posting) posting.Signed)
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return $"{Memo} ({Postings.Count} postings)"
        End Function

    End Class
    ' --8<--

End Namespace
