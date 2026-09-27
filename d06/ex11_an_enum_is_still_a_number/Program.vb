' The named set does not close. A number the enum never declared still fits inside it.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim rogue As AccountKind = CType(99, AccountKind)
        Console.WriteLine($"rogue as text   : {rogue}")
        Console.WriteLine($"rogue as number : {CInt(rogue)}")
        Console.WriteLine($"declared        : " &
                          $"{[Enum].IsDefined(GetType(AccountKind), rogue)}")
        Console.WriteLine($"Expense declared: " &
            $"{[Enum].IsDefined(GetType(AccountKind), AccountKind.Expense)}")

        Dim parsed As AccountKind
        Dim good = [Enum].TryParse(Of AccountKind)("Liability", parsed)
        Console.WriteLine($"parse 'Liability' : {good}, {parsed} = {CInt(parsed)}")
        Dim bad = [Enum].TryParse(Of AccountKind)("Rent", parsed)
        Console.WriteLine($"parse 'Rent'      : {bad}, and parsed now reads " &
                          $"{CInt(parsed)}")
    End Sub
End Module
