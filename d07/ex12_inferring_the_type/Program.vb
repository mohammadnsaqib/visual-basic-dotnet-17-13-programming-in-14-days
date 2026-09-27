' What the compiler works out at the call, and what it refuses to work out.
Imports System
Imports System.Collections.Generic

Module Program
    Function FirstOr(Of T)(items As IEnumerable(Of T), fallback As T) As T
        For Each item In items
            Return item
        Next
        Return fallback
    End Function

    Function CountOf(Of T)(items As IEnumerable(Of T)) As Integer
        Dim seen As Integer = 0
        For Each item In items
            seen += 1
        Next
        Return seen
    End Function

    Sub Main()
        Dim codes As New List(Of String)() From {"AC-1000", "AC-1001"}
        Dim empty As New List(Of Decimal)()

        Console.WriteLine($"first code   : {FirstOr(codes, "none")}")
        Console.WriteLine($"first amount : {FirstOr(empty, -1D)}")
        Console.WriteLine($"count codes  : {CountOf(codes)}")
        Console.WriteLine($"count empty  : {CountOf(empty)}")
        Console.WriteLine($"written out  : {FirstOr(Of String)(codes, "none")}")
    End Sub
End Module
