' A type that holds something to release, and the two ways it can be released.
Imports System
Imports System.Collections.Generic

Public NotInheritable Class Journal
    Implements IDisposable

    Private ReadOnly _lines As New List(Of String)()
    Private _open As Boolean = True

    Public ReadOnly Property Count As Integer
        Get
            Return _lines.Count
        End Get
    End Property

    Public Sub Write(line As String)
        If Not _open Then
            Throw New ObjectDisposedException(NameOf(Journal))
        End If
        _lines.Add(line)
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If _open Then
            Console.WriteLine($"  closing after {_lines.Count} line(s)")
            _open = False
        End If
    End Sub
End Class

Module Program
    Sub Main()
        Using book As New Journal()
            book.Write("AC-1000 opened")
            book.Write("1200.00 posted")
            Console.WriteLine($"  held {book.Count} line(s)")
        End Using

        Dim second As New Journal()
        second.Write("one line")
        second.Dispose()
        second.Dispose()
        Try
            second.Write("after closing")
        Catch ex As ObjectDisposedException
            Console.WriteLine($"writing after Dispose : {ex.GetType().Name}")
        End Try
    End Sub
End Module
