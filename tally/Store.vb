' Day 10. Saving a ledger and loading it back.
'
' What is saved is the postings, plus each account's opening balance. The balances themselves
' are NOT saved, because they are derived: a balance is the opening plus everything posted. A
' file that stored both could hold two answers that disagree, and there would be no way to tell
' which one was right.
'
' The rows below are separate types from Account and Posting on purpose. The shape of a file
' outlives the shape of the program that wrote it, so it is written down here rather than left
' to whatever the classes happen to look like this month.

Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Text.Json

Namespace Global.Tally

    ' --8<-- Store
    Public NotInheritable Class Store

        Public NotInheritable Class AccountRow
            Public Property Code As String
            Public Property Name As String
            Public Property Opening As Decimal
        End Class

        Public NotInheritable Class PostingRow
            Public Property Kind As String
            Public Property Account As String
            Public Property Amount As Decimal
        End Class

        Public NotInheritable Class LedgerFile
            Public Property Accounts As New List(Of AccountRow)
            Public Property Postings As New List(Of PostingRow)
        End Class

        Private Shared ReadOnly Layout As New JsonSerializerOptions With {.WriteIndented = True}

        ''' <summary>What a ledger looks like as rows. Day 11 saves the same rows without
        ''' waiting, so the shape is worked out here and both ways of writing it use this.</summary>
        Public Shared Function Capture(books As Ledger) As LedgerFile
            If books Is Nothing Then
                Throw New ArgumentNullException(NameOf(books))
            End If
            Dim moved = books.Postings.
                GroupBy(Function(posting) posting.Account).
                ToDictionary(Function(g) g.Key, Function(g) g.Sum(Function(p) p.Signed))

            Dim saved As New LedgerFile()
            For Each account In books
                Dim already As Decimal = 0D
                moved.TryGetValue(account.Code, already)
                saved.Accounts.Add(New AccountRow With {.Code = account.Code,
                                                        .Name = account.Name,
                                                        .Opening = account.Balance - already})
            Next
            For Each posting In books.Postings
                saved.Postings.Add(New PostingRow With {.Kind = posting.Kind,
                                                        .Account = posting.Account,
                                                        .Amount = posting.Amount})
            Next
            Return saved
        End Function

        ''' <summary>The text of a ledger file, laid out for a person to read.</summary>
        Public Shared Function AsText(books As Ledger) As String
            Return JsonSerializer.Serialize(Capture(books), Layout)
        End Function

        ''' <summary>Write the ledger to a file, as UTF-8 with no byte order mark.</summary>
        Public Shared Sub Save(books As Ledger, target As String)
            File.WriteAllText(target, AsText(books), New UTF8Encoding(False))
        End Sub

        ''' <summary>Read a ledger back. The postings are replayed, so the balances are earned
        ''' rather than trusted.</summary>
        Public Shared Function Load(source As String) As Ledger
            Dim saved = JsonSerializer.Deserialize(Of LedgerFile)(
                File.ReadAllText(source, Encoding.UTF8))
            If saved Is Nothing Then
                Throw New LedgerError($"{Path.GetFileName(source)} holds no ledger")
            End If

            Return Rebuild(saved)
        End Function

        ''' <summary>Turn saved rows back into a ledger, replaying every posting.</summary>
        Public Shared Function Rebuild(saved As LedgerFile) As Ledger
            Dim books As New Ledger()
            For Each row In saved.Accounts
                books.Open(row.Code, row.Name, row.Opening)
            Next
            For Each row In saved.Postings
                Select Case row.Kind
                    Case "Debit"
                        books.Apply(New Debit(row.Account, row.Amount))
                    Case "Credit"
                        books.Apply(New Credit(row.Account, row.Amount))
                    Case Else
                        Throw New LedgerError($"{row.Kind} is not a kind of posting",
                                              row.Account)
                End Select
            Next
            Return books
        End Function

    End Class
    ' --8<--

End Namespace
