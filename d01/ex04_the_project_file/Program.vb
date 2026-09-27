' What the project decided, read back from inside the program that it built.
Imports System
Imports System.Reflection
Imports System.Runtime.Versioning

Module Program
    Sub Main()
        Dim asm = Assembly.GetExecutingAssembly()
        Dim target = asm.GetCustomAttribute(Of TargetFrameworkAttribute)()
        Console.WriteLine($"assembly    : {asm.GetName().Name}")
        Console.WriteLine($"target      : {target.FrameworkName}")
        Console.WriteLine($"runtime     : {Environment.Version}")
        Console.WriteLine($"the source said none of that")
    End Sub
End Module
