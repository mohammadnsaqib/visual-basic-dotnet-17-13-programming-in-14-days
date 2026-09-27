' XML written as itself, in the middle of a program, checked by the compiler.
Imports System
Imports System.Linq
Imports System.Xml.Linq

Module Program
    Sub Main()
        Dim books = <ledger>
                        <account code="AC-1000">
                            <name>Cash</name>
                            <balance>3800.00</balance>
                        </account>
                        <account code="AC-1001">
                            <name>Rent</name>
                            <balance>1200.00</balance>
                        </account>
                    </ledger>

        Console.WriteLine($"type      : {books.GetType().Name}")
        Console.WriteLine($"root      : {books.Name}")
        Console.WriteLine($"accounts  : {books.<account>.Count()}")
        Console.WriteLine($"first code: {books.<account>.First().@code}")
        Console.WriteLine($"first name: {books.<account>.<name>.First().Value}")
        Console.WriteLine("no quotes, no escaping, and no string to get wrong")
    End Sub
End Module
