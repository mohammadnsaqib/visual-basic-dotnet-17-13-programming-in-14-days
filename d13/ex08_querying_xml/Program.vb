' The axes are one syntax, and LINQ is the other. They meet in the middle.
Imports System
Imports System.Linq
Imports System.Xml.Linq

Module Program
    Sub Main()
        Dim books = <ledger>
                        <account code="AC-1000" kind="asset">
                            <balance>3800.00</balance>
                        </account>
                        <account code="AC-1001" kind="expense">
                            <balance>1200.00</balance>
                        </account>
                        <account code="AC-4000" kind="income">
                            <balance>-5000.00</balance>
                        </account>
                    </ledger>

        Dim negative = From account In books.<account>
                       Where CDec(account.<balance>.Value) < 0D
                       Select account.@code

        Console.WriteLine($"accounts  : {books.<account>.Count()}")
        Console.WriteLine($"negative  : {String.Join(", ", negative)}")

        Dim total = books.<account>.Sum(Function(a) CDec(a.<balance>.Value))
        Console.WriteLine($"total     : {total:N2}")

        Dim kinds = From account In books.<account>
                    Group account By Kind = account.@kind Into Made = Count()
                    Order By Kind
                    Select $"{Kind}={Made}"
        Console.WriteLine($"by kind   : {String.Join(", ", kinds)}")
    End Sub
End Module
