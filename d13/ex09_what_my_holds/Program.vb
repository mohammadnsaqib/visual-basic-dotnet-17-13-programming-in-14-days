' What the My namespace contains in a console project on .NET, which is less than its
' reputation suggests.
Imports System
Imports System.Linq
Imports System.Xml.Linq

Module Program
    Sub Main()
        Dim any = <note code="AC-1000">a literal, read through an axis</note>

        Dim mine = From t In GetType(Program).Assembly.GetTypes()
                   Where t.FullName.Contains(".My.")
                   Order By t.FullName
                   Select t.FullName

        Console.WriteLine($"types under My : {mine.Count()}")
        For Each name In mine
            Console.WriteLine($"  {name.Substring(name.IndexOf(".My.") + 1)}")
        Next
        Console.WriteLine($"the axis gives   : {any.@code}")
        Console.WriteLine("My.Computer and My.Settings are generated for other " &
                          "project types")
    End Sub
End Module
