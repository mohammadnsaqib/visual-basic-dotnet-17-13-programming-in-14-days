' CInt, CType and DirectCast do three different things.
Imports System

Module Program
    Sub Main()
        Dim text As String = "42"
        Console.WriteLine($"CInt on text        : {CInt(text)}")
        Console.WriteLine($"CType on text       : {CType(text, Integer)}")

        Dim boxed As Object = 42
        Console.WriteLine($"DirectCast on boxed : {DirectCast(boxed, Integer)}")
        Console.WriteLine($"CInt on boxed       : {CInt(boxed)}")

        Dim wrongType As Object = "42"
        Try
            Console.WriteLine(DirectCast(wrongType, Integer))
        Catch ex As InvalidCastException
            Console.WriteLine($"DirectCast on a String Object: {ex.GetType().Name}")
        End Try
        Console.WriteLine($"CInt on the same Object: {CInt(wrongType)}")
    End Sub
End Module
