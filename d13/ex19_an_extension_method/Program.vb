' A method written outside a type that is called as though it were inside it.
Imports System
Imports System.Runtime.CompilerServices
Imports Tally

Public Module AccountExtensions

    <Extension>
    Public Function IsOverdrawn(account As Account) As Boolean
        Return account.Balance < 0D
    End Function

    <Extension>
    Public Function AsLine(account As Account, width As Integer) As String
        Return $"{account.Code} {account.Name.PadRight(width)} {account.Balance,10:N2}"
    End Function
End Module

Module Program
    Sub Main()
        Dim cash As New Account("AC-1000", "Cash", 3800D)
        Dim sales As New Account("AC-4000", "Sales", -5000D)

        Console.WriteLine($"cash overdrawn  : {cash.IsOverdrawn()}")
        Console.WriteLine($"sales overdrawn : {sales.IsOverdrawn()}")
        Console.WriteLine($"as a line       : {cash.AsLine(8)}")
        Console.WriteLine($"the same call   : {AccountExtensions.IsOverdrawn(sales)}")
        Console.WriteLine("Account was not changed, and it has no idea this exists")
    End Sub
End Module
