' The same two fields, once as a structure and once as a class. One assignment tells
' them apart.
Imports System

Structure PairValue
    Public First As Integer
    Public Second As Integer
End Structure

Class PairObject
    Public First As Integer
    Public Second As Integer
End Class

Module Program
    Sub Main()
        Dim v1 As New PairValue()
        v1.First = 1
        v1.Second = 2
        Dim v2 = v1
        v2.First = 99

        Dim o1 As New PairObject()
        o1.First = 1
        o1.Second = 2
        Dim o2 = o1
        o2.First = 99

        Console.WriteLine($"structure v1.First : {v1.First}")
        Console.WriteLine($"structure v2.First : {v2.First}")
        Console.WriteLine($"class     o1.First : {o1.First}")
        Console.WriteLine($"class     o2.First : {o2.First}")
        Console.WriteLine($"the two structures differ : {v1.First <> v2.First}")
        Console.WriteLine($"the two objects are one   : {ReferenceEquals(o1, o2)}")
    End Sub
End Module
