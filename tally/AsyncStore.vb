' Day 11. The same save and load, without holding a thread while the disk works.
'
' Nothing here is faster than Store. A save of a small ledger takes the time it takes either
' way. What changes is what the calling thread does while it waits, which is nothing at all in
' Store's case and something else in this one.
'
' Every method takes a CancellationToken. A method that cannot be cancelled is a method that
' has decided on its caller's behalf, and the decision is usually wrong.

Imports System
Imports System.IO
Imports System.Text
Imports System.Text.Json
Imports System.Threading
Imports System.Threading.Tasks

Namespace Global.Tally

    ' --8<-- AsyncStore
    Public NotInheritable Class AsyncStore

        ''' <summary>Write the ledger, returning the thread while the disk works.</summary>
        Public Shared Async Function SaveAsync(books As Ledger, target As String,
                                               Optional token As CancellationToken = Nothing) _
                                               As Task
            Dim text = Store.AsText(books)
            Await File.WriteAllTextAsync(target, text, New UTF8Encoding(False), token)
        End Function

        ''' <summary>Read a ledger back, replaying its postings as Store.Load does.</summary>
        Public Shared Async Function LoadAsync(source As String,
                                               Optional token As CancellationToken = Nothing) _
                                               As Task(Of Ledger)
            Dim text = Await File.ReadAllTextAsync(source, Encoding.UTF8, token)
            Dim saved = JsonSerializer.Deserialize(Of Store.LedgerFile)(text)
            If saved Is Nothing Then
                Throw New LedgerError($"{Path.GetFileName(source)} holds no ledger")
            End If
            Return Store.Rebuild(saved)
        End Function

    End Class
    ' --8<--

End Namespace
