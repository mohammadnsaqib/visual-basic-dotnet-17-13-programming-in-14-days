' Using closes the thing at the end of the block, whichever way the block is left.
Imports System
Imports System.IO
Imports System.Text

Module Program
    Sub Main()
        Dim held As New MemoryStream()
        Using writer As New StreamWriter(held, New UTF8Encoding(False), 1024, True)
            writer.WriteLine("AC-1000 Cash")
            writer.WriteLine("AC-1001 Rent")
        End Using
        Console.WriteLine($"bytes written : {held.Length}")

        held.Position = 0
        Using reader As New StreamReader(held, Encoding.UTF8, False, 1024, True)
            Dim line = reader.ReadLine()
            While line IsNot Nothing
                Console.WriteLine($"  {line}")
                line = reader.ReadLine()
            End While
        End Using

        Console.WriteLine("the writer and the reader were each closed by their own " &
                          "End Using")
        held.Dispose()
    End Sub
End Module
