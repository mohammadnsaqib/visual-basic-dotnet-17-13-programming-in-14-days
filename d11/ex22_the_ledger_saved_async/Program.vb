' The library's save and load, without holding a thread while the disk works.
Imports System
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Imports Tally

Module Program
    Async Function RunAsync() As Task
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d11-store")
        Directory.CreateDirectory(folder)
        Dim ledger = Path.Combine(folder, "books.json")

        Dim books As New Ledger()
        books.Open("AC-1000", "Cash")
        books.Open("AC-4000", "Sales")
        books.PostEntry(New Debit("AC-1000", 5000D), New Credit("AC-4000", 5000D))
        books.PostEntry(New Credit("AC-1000", 1200D), New Debit("AC-4000", 1200D))

        Await AsyncStore.SaveAsync(books, ledger)
        Console.WriteLine($"saved : {New FileInfo(ledger).Length} bytes")

        Dim back = Await AsyncStore.LoadAsync(ledger)
        Console.WriteLine($"accounts : {books.Count} out, {back.Count} in")
        Console.WriteLine($"postings : {books.Postings.Count} out, " &
                          $"{back.Postings.Count} in")
        Console.WriteLine($"balance  : {back.Balance:N2}")
        For Each account In back
            Console.WriteLine($"  {account}")
        Next

        Using source As New CancellationTokenSource()
            source.Cancel()
            Try
                Await AsyncStore.SaveAsync(books, ledger, source.Token)
            Catch ex As OperationCanceledException
                Console.WriteLine($"cancelled before writing : {ex.GetType().Name}")
            End Try
        End Using

        Directory.Delete(folder, True)
    End Function

    Sub Main()
        RunAsync().GetAwaiter().GetResult()
    End Sub
End Module
