' What an enum is for: a decision with one branch per member, each named rather
' than numbered.
Imports System
Imports Tally

Module Program
    Function SignOf(kind As AccountKind) As Integer
        Select Case kind
            Case AccountKind.Asset, AccountKind.Expense
                Return 1
            Case AccountKind.Liability, AccountKind.Income
                Return -1
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(kind), kind,
                                                      "not a declared kind")
        End Select
    End Function

    Sub Main()
        Dim kinds = New AccountKind() {AccountKind.Asset, AccountKind.Liability,
                                       AccountKind.Income, AccountKind.Expense}
        For Each kind In kinds
            Console.WriteLine($"{kind,-9} increases with " &
                              $"{If(SignOf(kind) = 1, "debits", "credits")}")
        Next

        Try
            Console.WriteLine(SignOf(CType(99, AccountKind)))
        Catch ex As ArgumentOutOfRangeException
            Console.WriteLine($"kind 99 : {ex.GetType().Name}")
        End Try
    End Sub
End Module
