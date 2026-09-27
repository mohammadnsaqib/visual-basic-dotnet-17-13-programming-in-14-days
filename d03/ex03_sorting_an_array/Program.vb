' Array.Sort rearranges the array it is given; it hands nothing back.
Imports System

Module Program
    Sub Main()
        Dim values = {5, 3, 9, 1, 7}
        Console.WriteLine($"before  : {String.Join(", ", values)}")
        Array.Sort(values)
        Console.WriteLine($"sorted  : {String.Join(", ", values)}")
        Array.Reverse(values)
        Console.WriteLine($"reversed: {String.Join(", ", values)}")
        Console.WriteLine($"IndexOf 7 : {Array.IndexOf(values, 7)}")
        Console.WriteLine($"IndexOf 4 : {Array.IndexOf(values, 4)}")
    End Sub
End Module
