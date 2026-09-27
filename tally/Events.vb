' Day 13. What the ledger says when something is posted, and one thing that listens.
'
' An event is how a type tells anybody who is interested, without knowing who that is. The
' ledger does not reference AuditLog and would work with none, one or twenty listeners; that is
' the whole point of the arrangement.

Imports System
Imports System.Collections.Generic

Namespace Global.Tally

    ' --8<-- PostingEventArgs
    ''' <summary>What the ledger says when a posting is applied.</summary>
    Public NotInheritable Class PostingEventArgs
        Inherits EventArgs

        Public ReadOnly Property Posting As Posting
        Public ReadOnly Property Balance As Decimal

        Public Sub New(posting As Posting, balance As Decimal)
            _Posting = posting
            _Balance = balance
        End Sub

    End Class
    ' --8<--

    ' --8<-- AuditLog
    ''' <summary>A record of every posting a ledger applied, in the order it applied them.</summary>
    Public NotInheritable Class AuditLog
        Implements IDisposable

        Private ReadOnly _books As Ledger
        Private ReadOnly _lines As New List(Of String)()
        Private _listening As Boolean

        Public Sub New(books As Ledger)
            If books Is Nothing Then
                Throw New ArgumentNullException(NameOf(books))
            End If
            _books = books
            AddHandler _books.Posted, AddressOf Record
            _listening = True
        End Sub

        Public ReadOnly Property Lines As IReadOnlyList(Of String)
            Get
                Return _lines
            End Get
        End Property

        Private Sub Record(sender As Object, e As PostingEventArgs)
            _lines.Add($"{e.Posting} leaving {e.Balance,10:N2}")
        End Sub

        ''' <summary>Stop listening. A handler that outlives its purpose keeps its target
        ''' alive, and that is how a listener becomes a leak.</summary>
        Public Sub Dispose() Implements IDisposable.Dispose
            If _listening Then
                RemoveHandler _books.Posted, AddressOf Record
                _listening = False
            End If
        End Sub

    End Class
    ' --8<--

End Namespace
