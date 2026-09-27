' Day 5. What every report of this ledger can do, and nothing about how.
'
' An interface is a list of members with no code behind them. This one says a report has a
' title and can produce its lines; it says nothing about where the lines come from, which is
' why a report over accounts and a report over postings can both be one.

Imports System.Collections.Generic

Namespace Global.Tally

    ' --8<-- IReport
    Public Interface IReport

        ''' <summary>The heading this report prints above its lines.</summary>
        ReadOnly Property Title As String

        ''' <summary>The body of the report, one entry per line, already formatted.</summary>
        Function Lines() As IEnumerable(Of String)

    End Interface
    ' --8<--

End Namespace
