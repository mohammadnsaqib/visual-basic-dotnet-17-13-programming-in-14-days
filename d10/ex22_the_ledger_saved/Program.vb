' The library's ledger written to a file and read back, and the two compared.
Imports System
Imports System.IO
Imports System.Linq
Imports Tally

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d10-store")
        Directory.CreateDirectory(folder)
        Dim ledger = Path.Combine(folder, "books.json")

        Dim books As New Ledger()
        books.Open("AC-1000", "Cash", 250D)
        books.Open("AC-1001", "Rent")
        books.Open("AC-4000", "Sales")
        books.PostEntry(New Debit("AC-1000", 5000D), New Credit("AC-4000", 5000D))
        books.PostEntry(New Credit("AC-1000", 1200D), New Debit("AC-1001", 1200D))

        Store.Save(books, ledger)
        Console.WriteLine($"saved {Path.GetFileName(ledger)}, " &
                          $"{New FileInfo(ledger).Length} bytes")
        Dim lines = File.ReadAllLines(ledger)
        Console.WriteLine($"lines : {lines.Length}")
        For Each line In lines.Take(7)
            Console.WriteLine($"  {line}")
        Next

        Dim back = Store.Load(ledger)
        Console.WriteLine($"accounts : {books.Count} out, {back.Count} in")
        Console.WriteLine($"postings : {books.Postings.Count} out, " &
                          $"{back.Postings.Count} in")
        Console.WriteLine($"balance  : {books.Balance:N2} out, {back.Balance:N2} in")
        For Each account In back
            Console.WriteLine($"  {account}")
        Next

        Directory.Delete(folder, True)
    End Sub
End Module
