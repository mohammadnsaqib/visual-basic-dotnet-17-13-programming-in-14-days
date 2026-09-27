' Without a Case Else, a value that matches nothing falls straight through.
Imports System

Module Program
    Sub Main()
        Dim reached As String = "nothing ran"
        Select Case 42
            Case 1
                reached = "one"
            Case 2
                reached = "two"
        End Select
        Console.WriteLine($"with no Case Else : {reached}")

        Select Case 42
            Case 1
                reached = "one"
            Case Else
                reached = "the Case Else ran"
        End Select
        Console.WriteLine($"with a Case Else  : {reached}")
    End Sub
End Module
