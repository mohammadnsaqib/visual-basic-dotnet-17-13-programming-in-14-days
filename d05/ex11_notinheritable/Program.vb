' NotInheritable ends the chain, and the compiler enforces it.
Imports System

Public NotInheritable Class Debit
    Public ReadOnly Property Amount As Decimal
End Class

Public Class SpecialDebit
    Inherits Debit
End Class

Module Program
    Sub Main()
        Console.WriteLine(New SpecialDebit().Amount)
    End Sub
End Module
