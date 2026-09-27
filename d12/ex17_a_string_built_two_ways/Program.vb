' Joining text in a loop, measured two ways, on the same 2,000 pieces.
Imports System
Imports System.Text

Module Program
    Sub Main()
        Const many As Integer = 2000

        Dim before = GC.GetAllocatedBytesForCurrentThread()
        Dim byAdding As String = ""
        For i = 1 To many
            byAdding &= "AC-1000,"
        Next
        Dim addingBytes = GC.GetAllocatedBytesForCurrentThread() - before

        before = GC.GetAllocatedBytesForCurrentThread()
        Dim held As New StringBuilder()
        For i = 1 To many
            held.Append("AC-1000,")
        Next
        Dim byBuilder = held.ToString()
        Dim builderBytes = GC.GetAllocatedBytesForCurrentThread() - before

        Console.WriteLine($"same text     : {byAdding = byBuilder}")
        Console.WriteLine($"characters    : {byAdding.Length}")
        Console.WriteLine($"by adding     : {addingBytes \ 1024} KB")
        Console.WriteLine($"by a builder  : {builderBytes \ 1024} KB")
        Console.WriteLine($"adding made {many} strings and threw {many - 1} of them " &
                          $"away")
    End Sub
End Module
