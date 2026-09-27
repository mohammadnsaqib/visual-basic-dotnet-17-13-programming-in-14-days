' What the library is, counted rather than estimated.
Imports System
Imports System.IO
Imports System.Linq

Module Program
    Function CodeFolder() As DirectoryInfo
        Dim here As New DirectoryInfo(AppContext.BaseDirectory)
        While here IsNot Nothing AndAlso here.Name <> "code"
            here = here.Parent
        End While
        Return here
    End Function

    Sub Main()
        Dim library = New DirectoryInfo(Path.Combine(CodeFolder().FullName, "tally"))
        Dim sources = library.GetFiles("*.vb").OrderBy(Function(f) f.Name).ToArray()

        Dim total As Integer = 0
        Dim written As Integer = 0
        For Each source In sources
            Dim lines = File.ReadAllLines(source.FullName)
            Dim real = lines.Count(Function(l) l.Trim().Length > 0 AndAlso
                                               Not l.Trim().StartsWith("'"))
            total += lines.Length
            written += real
            Console.WriteLine($"  {source.Name,-18} {lines.Length,4} lines, {real,4} " &
                              $"of them code")
        Next

        Console.WriteLine($"files : {sources.Length}")
        Console.WriteLine($"lines : {total}")
        Console.WriteLine($"code  : {written}")
        Console.WriteLine($"the rest is blank lines and comments : {total - written}")
    End Sub
End Module
