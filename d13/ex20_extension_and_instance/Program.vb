' When a type has the member already, the type wins. An extension can never shadow one.
Imports System
Imports System.Runtime.CompilerServices
Imports Tally

Public Module AccountExtensions

    ''' <summary>The same name the type already has.</summary>
    <Extension>
    Public Function ToString(account As Account, ignored As Integer) As String
        Return "from the extension"
    End Function

    <Extension>
    Public Function Describe(account As Account) As String
        Return $"{account.Code} holds {account.Balance:N2}"
    End Function
End Module

Module Program
    Sub Main()
        Dim cash As New Account("AC-1000", "Cash", 3800D)

        Console.WriteLine($"the type's own : {cash.ToString()}")
        Console.WriteLine($"the extension  : {cash.ToString(0)}")
        Console.WriteLine($"no clash       : {cash.Describe()}")
        Console.WriteLine("the extension was reachable only because its signature " &
                          "differs")
    End Sub
End Module
