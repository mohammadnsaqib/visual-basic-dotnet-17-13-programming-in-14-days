' Day 6. An amount of money, as a value rather than an object.
'
' Money is a Structure and not a Class, and the reason is copy semantics: an amount handed to a
' method must not be something the method can change under the caller. It carries a Decimal
' because Day 1 measured what a Double does to a tenth.

Imports System

Namespace Global.Tally

    ' --8<-- Money
    Public Structure Money
        Implements IEquatable(Of Money), IComparable(Of Money)

        Public ReadOnly Property Amount As Decimal

        Public Sub New(amount As Decimal)
            _Amount = Decimal.Round(amount, 2, MidpointRounding.ToEven)
        End Sub

        Public Shared ReadOnly Property Zero As Money
            Get
                Return New Money(0D)
            End Get
        End Property

        Public Shared Operator +(left As Money, right As Money) As Money
            Return New Money(left.Amount + right.Amount)
        End Operator

        Public Shared Operator -(left As Money, right As Money) As Money
            Return New Money(left.Amount - right.Amount)
        End Operator

        Public Shared Operator -(value As Money) As Money
            Return New Money(-value.Amount)
        End Operator

        Public Shared Operator =(left As Money, right As Money) As Boolean
            Return left.Amount = right.Amount
        End Operator

        Public Shared Operator <>(left As Money, right As Money) As Boolean
            Return Not (left = right)
        End Operator

        Public Shared Operator <(left As Money, right As Money) As Boolean
            Return left.Amount < right.Amount
        End Operator

        Public Shared Operator >(left As Money, right As Money) As Boolean
            Return left.Amount > right.Amount
        End Operator

        Public Overloads Function Equals(other As Money) As Boolean _
                Implements IEquatable(Of Money).Equals
            Return Amount = other.Amount
        End Function

        Public Overrides Function Equals(other As Object) As Boolean
            Return TypeOf other Is Money AndAlso Equals(DirectCast(other, Money))
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return Amount.GetHashCode()
        End Function

        Public Function CompareTo(other As Money) As Integer _
                Implements IComparable(Of Money).CompareTo
            Return Amount.CompareTo(other.Amount)
        End Function

        Public Overrides Function ToString() As String
            Return Amount.ToString("N2")
        End Function

    End Structure
    ' --8<--

    ' --8<-- AccountKind
    ''' <summary>Which side of the ledger an account sits on.</summary>
    Public Enum AccountKind
        Asset = 1
        Liability = 2
        Income = 3
        Expense = 4
    End Enum

    ''' <summary>What a report may include. One value can carry several of these at once.</summary>
    <Flags>
    Public Enum ReportParts
        None = 0
        Header = 1
        Body = 2
        Totals = 4
        Footer = 8
        Everything = Header Or Body Or Totals Or Footer
    End Enum
    ' --8<--

End Namespace
