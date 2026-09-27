' What a structure means by equal, when nobody has told it.
Imports System

Structure Tag
    Public Code As String
    Public Number As Integer
End Structure

Module Program
    Sub Main()
        Dim a As New Tag()
        a.Code = "AC"
        a.Number = 1000
        Dim b As New Tag()
        b.Code = "AC"
        b.Number = 1000
        Dim c As New Tag()
        c.Code = "AC"
        c.Number = 1001

        Console.WriteLine($"a Equals b : {a.Equals(b)}")
        Console.WriteLine($"a Equals c : {a.Equals(c)}")
        Console.WriteLine($"hash a = hash b : {a.GetHashCode() = b.GetHashCode()}")
        Dim answers = GetType(Tag).GetMethod("Equals", New Type() {GetType(Object)})
        Console.WriteLine($"the method that answers : {answers.DeclaringType.Name}")
        Console.WriteLine($"a Equals the number 1000 : {a.Equals(1000)}")
    End Sub
End Module
