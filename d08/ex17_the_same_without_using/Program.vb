' What Using is short for. The Finally is the whole point of it.
Imports System
Imports System.IO
Imports System.Text

Module Program
    Sub Main()
        Dim held As New MemoryStream()
        Dim writer As StreamWriter = Nothing
        Try
            writer = New StreamWriter(held, New UTF8Encoding(False), 1024, True)
            writer.WriteLine("AC-1000 Cash")
            Throw New InvalidOperationException("something failed mid-write")
        Catch ex As InvalidOperationException
            Console.WriteLine($"caught : {ex.Message}")
        Finally
            If writer IsNot Nothing Then
                writer.Dispose()
                Console.WriteLine("the Finally disposed the writer")
            End If
        End Try

        Console.WriteLine($"bytes written before the failure : {held.Length}")
        Console.WriteLine("Using writes that Try and that Finally, and cannot forget " &
                          "either")
        held.Dispose()
    End Sub
End Module
