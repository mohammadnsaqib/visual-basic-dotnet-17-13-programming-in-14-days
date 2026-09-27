' One integer holding several answers at once, and the two ways to read them back.
Imports System
Imports Tally

Module Program
    Sub Main()
        Dim wanted As ReportParts = ReportParts.Header Or ReportParts.Totals
        Console.WriteLine($"wanted     : {wanted}")
        Console.WriteLine($"as a number: {CInt(wanted)}")
        Console.WriteLine($"has Header : {wanted.HasFlag(ReportParts.Header)}")
        Console.WriteLine($"has Body   : {wanted.HasFlag(ReportParts.Body)}")
        Console.WriteLine($"has Totals : " &
                          $"{(wanted And ReportParts.Totals) = ReportParts.Totals}")
        Console.WriteLine($"has Footer : " &
                          $"{(wanted And ReportParts.Footer) = ReportParts.Footer}")
        Console.WriteLine($"Everything : {ReportParts.Everything} = " &
                          $"{CInt(ReportParts.Everything)}")
        Console.WriteLine($"None       : {ReportParts.None} = {CInt(ReportParts.None)}")
    End Sub
End Module
