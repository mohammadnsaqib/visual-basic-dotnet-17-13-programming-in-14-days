' Select Case takes the first branch that matches, so order decides the answer.
Imports System

Module Program
    Sub Main()
        Console.WriteLine($"7 in the first order  : {FirstOrder(7)}")
        Console.WriteLine($"7 in the second order : {SecondOrder(7)}")
    End Sub

    Function FirstOrder(code As Integer) As String
        Select Case code
            Case 1 To 10
                Return "one to ten"
            Case 7
                Return "seven"
            Case Else
                Return "other"
        End Select
    End Function

    Function SecondOrder(code As Integer) As String
        Select Case code
            Case 7
                Return "seven"
            Case 1 To 10
                Return "one to ten"
            Case Else
                Return "other"
        End Select
    End Function
End Module
