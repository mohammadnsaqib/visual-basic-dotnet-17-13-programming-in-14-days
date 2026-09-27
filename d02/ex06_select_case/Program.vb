' One expression, many patterns: a value, a range, a list, and a comparison.
Imports System

Module Program
    Sub Main()
        For Each code In {0, 3, 7, 12, 99}
            Console.WriteLine($"{code,3} -> {Describe(code)}")
        Next
    End Sub

    Function Describe(code As Integer) As String
        Select Case code
            Case 0
                Return "zero"
            Case 1 To 5
                Return "one to five"
            Case 6, 7, 8
                Return "six, seven or eight"
            Case Is > 50
                Return "over fifty"
            Case Else
                Return "something else"
        End Select
    End Function
End Module
