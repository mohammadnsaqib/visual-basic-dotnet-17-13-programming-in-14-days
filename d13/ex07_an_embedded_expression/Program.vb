' Values from the program, put into the XML where they belong.
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Linq
Imports Tally

Module Program
    Sub Main()
        Dim books As New Ledger()
        books.Open("AC-1000", "Cash")
        books.Open("AC-4000", "Sales")
        books.PostEntry(New Debit("AC-1000", 3800D), New Credit("AC-4000", 3800D))

        Dim report = <ledger accounts=<%= books.Count %>>
                         <%= From account In books
                             Select <account code=<%= account.Code %>>
                                        <name><%= account.Name %></name>
                                        <balance>
                                            <%= account.Balance.ToString("N2") %>
                                        </balance>
                                    </account> %>
                     </ledger>

        Console.WriteLine(report.ToString())
        Console.WriteLine($"accounts attribute : {report.@accounts}")
        Console.WriteLine($"names              : " &
            String.Join(", ", report.<account>.<name>.Select(Function(n) n.Value)))
    End Sub
End Module
