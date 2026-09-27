' Nothing in a reference type is a reference to no object.
Imports System

Module Program
    Sub Main()
        Dim name As String = Nothing
        Console.WriteLine($"name Is Nothing            : {name Is Nothing}")
        Console.WriteLine($"name = an empty String     : {name = String.Empty}")
        Console.WriteLine("asking it for its Length   :")
        Console.WriteLine(name.Length)
    End Sub
End Module
