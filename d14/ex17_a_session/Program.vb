' A whole session, typed at the shell, with every answer as the program gave it.
Imports System
Imports System.IO
Imports Tally

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d14-session")
        Directory.CreateDirectory(folder)
        Dim target = Path.Combine(folder, "books.json")

        Dim shell As New Shell(New Ledger())
        Dim session = New String() {
            "open AC-1000 Cash",
            "open AC-1001 Rent",
            "open AC-4000 Sales",
            "post opening; debit AC-1000 5000; credit AC-4000 5000",
            "post rent; credit AC-1000 1200; debit AC-1001 1200",
            "balance",
            "statement AC-1001",
            $"save {target}",
            "dance"}

        For Each line In session
            Dim shown = If(line.StartsWith("save"), "save books.json", line)
            Console.WriteLine($"> {shown}")
            Dim said = shell.Run(line)
            If said.Length > 0 Then
                Console.WriteLine(said)
            End If
        Next

        Console.WriteLine($"lines typed : {session.Length}")
        Directory.Delete(folder, True)
    End Sub
End Module
