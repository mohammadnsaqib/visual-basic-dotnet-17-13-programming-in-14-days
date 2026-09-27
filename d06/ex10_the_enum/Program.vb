' An enum is a named set of numbers, and both halves of that are usable.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim kind As AccountKind = AccountKind.Expense
        Console.WriteLine($"name       : {kind}")
        Console.WriteLine($"number     : {CInt(kind)}")
        Console.WriteLine($"type       : {kind.GetType().Name}")
        Console.WriteLine($"underlying : " &
                          $"{[Enum].GetUnderlyingType(GetType(AccountKind)).Name}")
        Console.WriteLine($"a value type : {kind.GetType().IsValueType}")
        Console.WriteLine("every member:")
        For Each label In [Enum].GetNames(GetType(AccountKind))
            Dim member = CType([Enum].Parse(GetType(AccountKind), label), AccountKind)
            Console.WriteLine($"  {label,-9} = {CInt(member)}")
        Next
    End Sub
End Module
