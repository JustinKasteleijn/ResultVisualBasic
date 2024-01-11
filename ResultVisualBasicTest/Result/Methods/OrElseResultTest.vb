Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class OrElseResultTest
    <TestMethod>
    Public Sub OrElseResultIgnoresOk()
        Dim expected As Integer = 1
        Assert.AreEqual(
            expected,
            Result(Of Integer, String).
                Ok(1).
                [OrElse](Function(x) Result(Of Integer, String).Ok(-1)).
                Unwrap()
        )
    End Sub

    <TestMethod>
    Public Sub OrElseResultCallsErr()
        Dim expected As Integer = 1
        Assert.AreEqual(
            expected,
            Result(Of Integer, Integer).
                Err(1).
                [OrElse](Function(x) Result(Of Integer, Integer).Ok(x.Err() * x.Err())).
                [OrElse](Function(x) Result(Of Integer, Integer).Ok(x.Err() * x.Err())).
                Unwrap()
        )
    End Sub
End Class
