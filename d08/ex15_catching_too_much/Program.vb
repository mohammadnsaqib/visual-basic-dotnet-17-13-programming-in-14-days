' Catch Exception takes everything, including the failure that was not expected.
Imports System

Public Class Reading
    Public Property Text As String
End Class

Module Program
    Function LengthOf(item As Reading) As Integer
        Try
            Return Integer.Parse(item.Text).ToString().Length
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Function LengthOfNarrowly(item As Reading) As Integer
        Try
            Return Integer.Parse(item.Text).ToString().Length
        Catch ex As FormatException
            Return 0
        End Try
    End Function

    Sub Main()
        Console.WriteLine($"a number   : " &
                          $"{LengthOf(New Reading() With {.Text = "1234"})}")
        Console.WriteLine($"not a number: {LengthOf(New Reading() With {.Text = "x"})}")
        Console.WriteLine($"no item     : {LengthOf(Nothing)}")

        Try
            Console.WriteLine(LengthOfNarrowly(Nothing))
        Catch ex As NullReferenceException
            Console.WriteLine($"the narrow version let it through : " &
                              $"{ex.GetType().Name}")
        End Try
        Console.WriteLine("the wide Catch reported 0 for a defect, not for a bad " &
                          "reading")
    End Sub
End Module
