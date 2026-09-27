' Day 14. The part of tally that a person types at.
'
' Run takes one line and gives back the text to print. It prints nothing itself, which is the
' only reason the whole of it can be tested: a method that writes to the console can be watched
' only by a program that captures the console, and a method that returns text can be compared.
'
' Every failure a person is expected to make comes back as a line beginning "error: ". A file
' that is not JSON, or an amount too large for a Decimal, still throws.

Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Linq

Namespace Global.Tally

    ' --8<-- Shell
    Public NotInheritable Class Shell

        Private ReadOnly _books As Ledger

        Public Sub New(books As Ledger)
            If books Is Nothing Then
                Throw New ArgumentNullException(NameOf(books))
            End If
            _books = books
        End Sub

        Public ReadOnly Property Books As Ledger
            Get
                Return _books
            End Get
        End Property

        ''' <summary>What the program understands, one line per command.</summary>
        Public Shared ReadOnly Property Help As String
            Get
                Return String.Join(Environment.NewLine, New String() {
                    "open <code> <name> [opening]     open an account",
                    "post <memo>; <kind> <code> <amount>; ...   post an entry",
                    "balance                          the trial balance",
                    "statement <code>                 one account's postings",
                    "save <file>                      write the ledger",
                    "load <file>                      read it back",
                    "help                             this text"})
            End Get
        End Property

        ''' <summary>Carry out one line, and give back what to print.</summary>
        Public Function Run(line As String) As String
            If line Is Nothing OrElse line.Trim().Length = 0 Then
                Return ""
            End If
            Dim trimmed = line.Trim()
            Dim verb = trimmed.Split(" "c)(0).ToLowerInvariant()
            Dim rest = trimmed.Substring(verb.Length).Trim()

            Try
                Select Case verb
                    Case "help"
                        Return Help
                    Case "open"
                        Return Open(rest)
                    Case "post"
                        Return Post(rest)
                    Case "balance"
                        Return Report(New TrialBalance(_books))
                    Case "statement"
                        Return Statement(rest)
                    Case "save"
                        Return Save(rest)
                    Case "load"
                        Return Load(rest)
                    Case Else
                        Return $"error: {verb} is not a command; try help"
                End Select
            Catch ex As LedgerError
                Return $"error: {ex.Message}"
            Catch ex As ArgumentException
                Return $"error: {ex.Message}"
            Catch ex As IOException
                Return $"error: {ex.Message}"
            End Try
        End Function

        Private Function Open(rest As String) As String
            Dim parts = rest.Split(" "c).Where(Function(p) p.Length > 0).ToArray()
            If parts.Length < 2 Then
                Return "error: open needs a code and a name"
            End If
            Dim opening As Decimal = 0D
            If parts.Length > 2 AndAlso
               Not Decimal.TryParse(parts(2), NumberStyles.Number,
                                    CultureInfo.InvariantCulture, opening) Then
                Return $"error: {parts(2)} is not an amount"
            End If
            If _books.Find(parts(0)) IsNot Nothing Then
                Return $"error: {parts(0)} is already open"
            End If
            Dim account = _books.Open(parts(0), parts(1), opening)
            Return $"opened {account}"
        End Function

        Private Function Post(rest As String) As String
            Dim parts = rest.Split(";"c).Select(Function(p) p.Trim()).
                             Where(Function(p) p.Length > 0).ToArray()
            If parts.Length < 3 Then
                Return "error: post needs a memo and at least two postings"
            End If

            Dim postings As New List(Of Posting)()
            For Each part In parts.Skip(1)
                Dim words = part.Split(" "c).Where(Function(w) w.Length > 0).ToArray()
                If words.Length <> 3 Then
                    Return $"error: [{part}] is not a posting"
                End If
                Dim amount As Decimal
                If Not Decimal.TryParse(words(2), NumberStyles.Number,
                                        CultureInfo.InvariantCulture, amount) Then
                    Return $"error: {words(2)} is not an amount"
                End If
                Select Case words(0).ToLowerInvariant()
                    Case "debit"
                        postings.Add(New Debit(words(1), amount))
                    Case "credit"
                        postings.Add(New Credit(words(1), amount))
                    Case Else
                        Return $"error: {words(0)} is not debit or credit"
                End Select
            Next

            Dim entry As New Entry(parts(0), postings.ToArray())
            _books.PostEntry(entry.Postings.ToArray())
            Return $"posted {entry}"
        End Function

        Private Function Statement(code As String) As String
            Dim account = _books.Find(code)
            If account Is Nothing Then
                Return $"error: {code} is not open"
            End If
            Dim lines = From posting In _books.Postings
                        Where String.Equals(posting.Account, account.Code,
                                            StringComparison.OrdinalIgnoreCase)
                        Select $"  {posting}"
            Return String.Join(Environment.NewLine,
                               {$"{account.Code} {account.Name}"}.
                               Concat(lines).
                               Concat({$"  {"balance",-17}{account.Balance,10:N2}"}))
        End Function

        Private Shared Function Report(what As IReport) As String
            Return String.Join(Environment.NewLine,
                               {what.Title}.Concat(what.Lines().Select(
                                   Function(line) "  " & line)))
        End Function

        Private Function Save(target As String) As String
            If target.Length = 0 Then
                Return "error: save needs a file name"
            End If
            Store.Save(_books, target)
            Return $"saved {Path.GetFileName(target)}, " &
                   $"{_books.Count} account(s), {_books.Postings.Count} posting(s)"
        End Function

        Private Function Load(source As String) As String
            If source.Length = 0 Then
                Return "error: load needs a file name"
            End If
            If Not File.Exists(source) Then
                Return $"error: {Path.GetFileName(source)} is not there"
            End If
            Dim loaded = Store.Load(source)
            Return $"loaded {Path.GetFileName(source)}, " &
                   $"{loaded.Count} account(s), {loaded.Postings.Count} posting(s)"
        End Function

    End Class
    ' --8<--

End Namespace
