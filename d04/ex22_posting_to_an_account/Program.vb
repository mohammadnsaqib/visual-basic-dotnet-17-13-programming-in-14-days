' The balance moves in one way only, and the class is the one that moves it.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim cash As New Account("AC-1000", "Cash", 500D)
        Console.WriteLine($"opening : {cash.Balance:N2}")
        cash.Post(1200D)
        Console.WriteLine($"after +1200 : {cash.Balance:N2}")
        cash.Post(-84.5D)
        Console.WriteLine($"after -84.50: {cash.Balance:N2}")
        Console.WriteLine($"the account prints as: {cash}")
        Console.WriteLine("Balance has no setter, so nothing outside the class " &
                          "assigned it")
    End Sub
End Module
