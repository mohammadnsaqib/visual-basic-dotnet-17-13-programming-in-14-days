' The same books read back, and the two compared without trusting either.
Imports System
Imports System.IO
Imports System.Linq
Imports Tally

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d14-load")
        Directory.CreateDirectory(folder)
        Dim target = Path.Combine(folder, "books.json")

        Dim books As New Ledger()
        Dim shell As New Shell(books)
        shell.Run("open AC-1000 Cash 250")
        shell.Run("open AC-1001 Rent")
        shell.Run("open AC-4000 Sales")
        shell.Run("post opening; debit AC-1000 5000; credit AC-4000 5000")
        shell.Run("post rent; credit AC-1000 1200; debit AC-1001 1200")
        Store.Save(books, target)

        Dim back = Store.Load(target)
        Dim before = books.Select(Function(a) $"{a.Code}|{a.Balance}").ToArray()
        Dim after = back.Select(Function(a) $"{a.Code}|{a.Balance}").ToArray()

        Console.WriteLine($"accounts : {books.Count} and {back.Count}")
        Console.WriteLine($"postings : {books.Postings.Count} and " &
                          $"{back.Postings.Count}")
        Console.WriteLine($"balances : {before.SequenceEqual(after)}")
        Console.WriteLine($"total    : {books.Balance:N2} and {back.Balance:N2}")
        For Each row In after
            Console.WriteLine($"  {row}")
        Next
        Directory.Delete(folder, True)
    End Sub
End Module
