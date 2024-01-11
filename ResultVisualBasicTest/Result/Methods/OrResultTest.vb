Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class OrResultTest
    <TestMethod>
    Public Sub OrReturnsOtherOnErr()
        Dim res = Result(Of Integer, String).Err("what!")
        Dim other = Result(Of Integer, String).Ok(5)
        Dim expected = other

        Assert.AreEqual(
            expected,
            res.Or(other)
        )
    End Sub

    <TestMethod>
    Public Sub OrReturnsSelf()
        Dim res = Result(Of Integer, String).Ok(1)
        Dim other = Result(Of Integer, String).Ok(5)
        Dim expected = res

        Assert.AreEqual(
            expected,
            res.Or(other)
        )
    End Sub

    <TestMethod>
    Public Sub OrReturnsSelfOnErr()
        Dim res = Result(Of Integer, String).Ok(1)
        Dim other = Result(Of Integer, String).Err("What!")
        Dim expected = res

        Assert.AreEqual(
            expected,
            res.Or(other)
        )
    End Sub
End Class
