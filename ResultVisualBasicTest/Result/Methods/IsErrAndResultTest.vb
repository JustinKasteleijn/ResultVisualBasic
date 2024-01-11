Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class IsErrAndResultTest
    <TestMethod>
    Public Sub IsErrAndReturnTrue()
        Assert.IsTrue(
            Result(Of Integer, String).Err("").
                IsErrAnd(Function() True)
        )
    End Sub

    <TestMethod>
    Public Sub IsErrAndReturnFalseOnPredicate()
        Assert.IsFalse(
            Result(Of Integer, String).Err("").
                IsErrAnd(Function() False)
        )
    End Sub

    <TestMethod>
    Public Sub IsErrAndReturnFalseOnOk()
        Assert.IsFalse(
            Result(Of Integer, String).Ok(1).
                IsErrAnd(Function() True)
        )
    End Sub
End Class
