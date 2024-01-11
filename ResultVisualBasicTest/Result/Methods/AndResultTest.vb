Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class AndResultTest

    <TestMethod>
    Public Sub AndReturnsEarlyError()
        Dim expected As String = "Early error"
        Dim x = Result(Of Integer, String).Err(expected)
        Dim y = Result(Of Integer, String).Ok(10)

        Assert.AreEqual(expected, x.And(y).Err())
    End Sub

    <TestMethod>
    Public Sub AndReturnsLateError()
        Dim expected As String = "Late error"
        Dim x = Result(Of Integer, String).Err(expected)
        Dim y = Result(Of Integer, String).Ok(10)

        Assert.AreEqual(expected, y.And(x).Err())
    End Sub

    <TestMethod>
    Public Sub AndReturnsLateErrorForDoubleErr()
        Dim expected As String = "Late error"
        Dim x = Result(Of Integer, String).Err("Early error")
        Dim y = Result(Of Integer, String).Err(expected)

        Assert.IsTrue(y.IsErr)
        Assert.AreEqual(expected, x.And(y).Err())
    End Sub

    <TestMethod>
    Public Sub AndReturnsLateValueForDoubleOk()
        Dim expected As Integer = 1
        Dim x = Result(Of Integer, String).Ok(100)
        Dim y = Result(Of Integer, String).Ok(expected)

        Assert.AreEqual(expected, x.And(y).Unwrap())
    End Sub
End Class
