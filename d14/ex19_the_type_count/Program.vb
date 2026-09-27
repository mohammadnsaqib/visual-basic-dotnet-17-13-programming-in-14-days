' The same library counted from the other end: what the compiler made of it.
Imports System
Imports System.Linq
Imports System.Reflection
Imports Tally

Module Program
    Sub Main()
        Dim assembly = GetType(Ledger).Assembly
        Dim all = assembly.GetTypes()
        Dim types = all.Where(Function(t) Not t.Name.StartsWith("<")).ToArray()
        Dim public_ = types.Where(Function(t) t.IsPublic).ToArray()

        Console.WriteLine($"types        : {types.Length}")
        Console.WriteLine($"public types : {public_.Length}")
        Console.WriteLine($"classes      : {public_.Count(Function(t) t.IsClass)}")
        Dim structures = public_.Count(Function(t) t.IsValueType AndAlso Not t.IsEnum)
        Console.WriteLine($"structures   : {structures}")
        Console.WriteLine($"enums        : {public_.Count(Function(t) t.IsEnum)}")
        Console.WriteLine($"interfaces   : {public_.Count(Function(t) t.IsInterface)}")

        Dim members = public_.Sum(Function(t) t.GetMembers(BindingFlags.Public Or
                                                           BindingFlags.Instance Or
                                                           BindingFlags.Static Or
            BindingFlags.DeclaredOnly).Length)
        Console.WriteLine($"public members : {members}")
        Console.WriteLine($"the largest    : " &
                          public_.OrderByDescending(
                              Function(t) t.GetMembers(BindingFlags.Public Or
                                                       BindingFlags.Instance Or
                                                       BindingFlags.Static Or
            BindingFlags.DeclaredOnly).Length).
                              First().Name)
    End Sub
End Module
