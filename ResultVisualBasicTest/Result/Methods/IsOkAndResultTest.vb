Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class IsOkAndResultTest
    <TestMethod>
    Public Sub IsOkAndReturnsOk()
        Assert.IsTrue(
            Result(Of Integer, String).Ok(1).
                IsOkayAnd(Function() True)
        )
    End Sub

    <TestMethod>
    Public Sub IsOkAndReturnsFalseOnPredicate()
        Assert.IsFalse(
            Result(Of Integer, String).Ok(1).
                IsOkayAnd(Function() False)
        )
    End Sub

    <TestMethod>
    Public Sub IsOkAndReturnsFalseOnErr()
        Assert.IsFalse(
            Result(Of Integer, String).Err("").
                IsOkayAnd(Function() False)
        )
    End Sub
End Class
