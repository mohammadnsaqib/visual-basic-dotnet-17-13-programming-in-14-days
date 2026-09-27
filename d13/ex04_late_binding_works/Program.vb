' With Option Strict Off, the member is looked up while the program runs.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim account As Object = New Account("AC-1000", "Cash", 3800D)

        Console.WriteLine($"code    : {account.Code}")
        Console.WriteLine($"name    : {account.Name}")
        Console.WriteLine($"balance : {account.Balance:N2}")
        account.Post(200D)
        Console.WriteLine($"after   : {account.Balance:N2}")
        Console.WriteLine($"and     : {account.ToString()}")
        Console.WriteLine("none of these were checked when the program was built")
    End Sub
End Module
