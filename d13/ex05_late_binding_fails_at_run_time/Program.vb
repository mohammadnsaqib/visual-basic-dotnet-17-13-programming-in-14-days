' The same lookup for a member that is not there. Nothing said so until now.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim account As Object = New Account("AC-1000", "Cash", 3800D)

        Console.WriteLine($"balance : {account.Balance:N2}")
        Console.WriteLine("about to ask for a member that does not exist")
        Console.WriteLine($"overdraft : {account.Overdraft}")
        Console.WriteLine("never printed")
    End Sub
End Module
