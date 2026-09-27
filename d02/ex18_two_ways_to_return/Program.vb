' A Function can Return, or assign its own name, and both are the same thing.
Imports System

Module Program
    Sub Main()
        Console.WriteLine($"WithReturn(9)   = {WithReturn(9)}")
        Console.WriteLine($"WithTheName(9)  = {WithTheName(9)}")
        Console.WriteLine($"NeverAssigned() = {NeverAssigned()}")
    End Sub

    Function WithReturn(n As Integer) As Integer
        Return n * n
    End Function

    Function WithTheName(n As Integer) As Integer
        WithTheName = n * n
    End Function

    Function NeverAssigned() As Integer
    End Function
End Module
