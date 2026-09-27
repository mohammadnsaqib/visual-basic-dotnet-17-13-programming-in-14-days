' Three operators do all the work: Or adds, And Not removes, Xor turns over.
Imports System
Imports Tally

Module Program
    Sub Show(caption As String, parts As ReportParts)
        Console.WriteLine($"{caption,-18}: {CInt(parts),2}  {parts}")
    End Sub

    Sub Main()
        Dim parts As ReportParts = ReportParts.None
        Show("nothing", parts)

        parts = parts Or ReportParts.Header
        Show("add Header", parts)

        parts = parts Or ReportParts.Body Or ReportParts.Totals
        Show("add Body, Totals", parts)

        parts = parts And Not ReportParts.Body
        Show("remove Body", parts)

        parts = parts Xor ReportParts.Footer
        Show("turn over Footer", parts)

        parts = parts Xor ReportParts.Footer
        Show("and back again", parts)

        Show("everything", ReportParts.Everything)
        Show("all but Footer", ReportParts.Everything And Not ReportParts.Footer)
    End Sub
End Module
