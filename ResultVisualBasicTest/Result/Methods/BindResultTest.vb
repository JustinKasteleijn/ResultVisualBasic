Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class BindResultTest

    <TestMethod>
    Public Sub BindReturnErrOnErr()
        Dim expected As String = "Scary"
        Dim sut = Result(Of Integer, String).Err(expected)

        Assert.AreEqual(expected, sut.Bind(
            Function(x) Result(Of Integer, String).Ok(x)
        ).Err())
    End Sub

    <TestMethod>
    Public Sub BindReturnMappedResOnOk()
        Dim value As Integer = 3
        Dim expected = value * value
        Dim sut = Result(Of Integer, String).Ok(value)

        Assert.AreEqual(expected, sut.Bind(
            Function(x) Result(Of Integer, String).Ok(x * x)
        ).Unwrap())
    End Sub
End Class
