' The last program in the book. Everything it prints was counted by the machine.
Imports System
Imports System.IO
Imports System.Linq
Imports System.Reflection
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
        Dim library = New DirectoryInfo(Path.Combine(code.FullName, "tally"))
        Dim tests = New DirectoryInfo(Path.Combine(code.FullName, "tally.tests"))

        Dim libraryLines = library.GetFiles("*.vb").
            Sum(Function(f) File.ReadAllLines(f.FullName).Length)
        Dim testLines = tests.GetFiles("*.vb").
            Sum(Function(f) File.ReadAllLines(f.FullName).Length)
        Dim testMethods = tests.GetFiles("*.vb").
            Sum(Function(f) File.ReadAllText(f.FullName).Split(
                    New String() {"<TestMethod>"}, StringSplitOptions.None).Length - 1)

        Dim types = GetType(Ledger).Assembly.GetTypes().
            Count(Function(t) t.IsPublic AndAlso Not t.Name.StartsWith("<"))

        Dim books As New Ledger()
        Dim shell As New Shell(books)
        shell.Run("open AC-1000 Cash")
        shell.Run("open AC-4000 Sales")
        shell.Run("post opening; debit AC-1000 5000; credit AC-4000 5000")

        Console.WriteLine($"library files   : {library.GetFiles("*.vb").Length}")
        Console.WriteLine($"library lines   : {libraryLines}")
        Console.WriteLine($"public types    : {types}")
        Console.WriteLine($"test files      : {tests.GetFiles("*.vb").Length}")
        Console.WriteLine($"test lines      : {testLines}")
        Console.WriteLine($"test methods    : {testMethods}")
        Console.WriteLine($"the books still balance : {books.Balance = 0D}")
        Console.WriteLine($"and the shell still answers : " &
                          $"{shell.Run("balance").Length > 0}")
    End Sub
End Module
