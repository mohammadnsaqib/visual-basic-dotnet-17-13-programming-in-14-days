' What For Each actually needs, written out in full.
Imports System
Imports System.Collections
Imports System.Collections.Generic

Public Class Countdown
    Implements IEnumerable(Of Integer)

    Private ReadOnly _from As Integer

    Public Sub New(from As Integer)
        _from = from
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of Integer) _
            Implements IEnumerable(Of Integer).GetEnumerator
        Return New CountdownEnumerator(_from)
    End Function

    Private Function GetUntypedEnumerator() As IEnumerator _
            Implements IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function

    Private NotInheritable Class CountdownEnumerator
        Implements IEnumerator(Of Integer)

        Private ReadOnly _from As Integer
        Private _now As Integer

        Public Sub New(from As Integer)
            _from = from
            _now = from + 1
        End Sub

        Public ReadOnly Property Current As Integer _
                Implements IEnumerator(Of Integer).Current
            Get
                Return _now
            End Get
        End Property

        Private ReadOnly Property UntypedCurrent As Object _
                Implements IEnumerator.Current
            Get
                Return _now
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            _now -= 1
            Return _now >= 1
        End Function

        Public Sub Reset() Implements IEnumerator.Reset
            _now = _from + 1
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
        End Sub
    End Class
End Class

Module Program
    Sub Main()
        Dim counting As New Countdown(5)
        For Each n In counting
            Console.Write($"{n} ")
        Next
        Console.WriteLine()
        Console.WriteLine("four members and a nested class, for five numbers")
    End Sub
End Module
