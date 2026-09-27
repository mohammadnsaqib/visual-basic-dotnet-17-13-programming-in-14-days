' Day 12. How the runner may schedule these tests.
'
' MSTest warns when a test project does not say. These tests each build their own Ledger and
' share nothing, so they can run at once; a suite that touched one file or one database would
' have to say otherwise, and saying so is cheaper than finding out.

Imports Microsoft.VisualStudio.TestTools.UnitTesting

<Assembly: Parallelize(Workers:=0, Scope:=ExecutionScope.MethodLevel)>
