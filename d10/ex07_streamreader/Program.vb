' A reader, held open for as long as the reading takes and no longer.
Imports System
Imports System.IO
Imports System.Text

Module Program
    Sub Main()
        Dim folder = Path.Combine(Path.GetTempPath(), "vb14-d10-reader")
        Directory.CreateDirectory(folder)
        Dim ledger = Path.Combine(folder, "ledger.csv")
        File.WriteAllLines(ledger, New String() {"code,name,balance",
                                                 "AC-1000,Cash,3800.00",
                                                 "AC-1001,Rent,1200.00"})

        Using reader As New StreamReader(ledger, Encoding.UTF8)
            Dim header = reader.ReadLine()
            Console.WriteLine($"header  : {header}")
            Dim seen As Integer = 0
            Dim line = reader.ReadLine()
            While line IsNot Nothing
                seen += 1
                Console.WriteLine($"  row {seen} : {line}")
                line = reader.ReadLine()
            End While
            Console.WriteLine($"rows    : {seen}")
            Console.WriteLine($"at the end : {reader.EndOfStream}")
        End Using

        Console.WriteLine($"the file can be deleted now, because the reader was closed")
        File.Delete(ledger)
        Console.WriteLine($"still there : {File.Exists(ledger)}")
        Directory.Delete(folder, True)
    End Sub
End Module
