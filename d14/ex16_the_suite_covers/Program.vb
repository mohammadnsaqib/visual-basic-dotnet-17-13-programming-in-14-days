' What the tests name, and what they do not. A count of names is not coverage, and it is
' a start.
Imports System
Imports System.IO
Imports System.Linq
Imports Tally

Module Program
    Function CodeFolder() As DirectoryInfo
        Dim here As New DirectoryInfo(AppContext.BaseDirectory)
        While here IsNot Nothing AndAlso here.Name <> "code"
            here = here.Parent
        End While
        Return here
    End Function

    Sub Main()
        Dim code = CodeFolder()
        Dim tests = String.Join(Environment.NewLine,
            Directory.GetFiles(Path.Combine(code.FullName, "tally.tests"),
            "*.vb").Select(AddressOf File.ReadAllText))

        Dim types = GetType(Ledger).Assembly.GetTypes().
            Where(Function(t) t.IsPublic AndAlso Not t.Name.Contains("`")).
            OrderBy(Function(t) t.Name).ToArray()

        Dim named = 0
        For Each t In types
            Dim inTests = tests.Contains(t.Name)
            If inTests Then
                named += 1
            End If
            Console.WriteLine($"  {t.Name,-18} {If(inTests, "named", "not named")}")
        Next
        Console.WriteLine($"public types : {types.Length}")
        Console.WriteLine($"named by the tests : {named}")
    End Sub
End Module
