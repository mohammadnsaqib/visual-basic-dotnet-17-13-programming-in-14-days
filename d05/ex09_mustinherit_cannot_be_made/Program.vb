' A MustInherit class describes something incomplete, so New will not build one.
Imports System

Public MustInherit Class Posting
    Public MustOverride ReadOnly Property Kind As String
End Class

Module Program
    Sub Main()
        Dim p As New Posting()
        Console.WriteLine(p.Kind)
    End Sub
End Module
