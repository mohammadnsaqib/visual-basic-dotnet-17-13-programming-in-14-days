' Four ways to make the same line of text.
Imports System

Module Program
    Sub Main()
        Dim who As String = "ledger"
        Dim count As Integer = 3

        Dim byAmpersand As String = "the " & who & " has " & count.ToString() &
            " entries"
        Dim byConcat As String = String.Concat("the ", who, " has ", count.ToString(),
                                               " entries")
        Dim byFormat As String = String.Format("the {0} has {1} entries", who, count)
        Dim byInterpolation As String = $"the {who} has {count} entries"

        Console.WriteLine(byAmpersand)
        Console.WriteLine(byConcat)
        Console.WriteLine(byFormat)
        Console.WriteLine(byInterpolation)
        Console.WriteLine($"all four equal: " &
            (byAmpersand = byConcat AndAlso byConcat = byFormat AndAlso
             byFormat = byInterpolation).ToString())
    End Sub
End Module
