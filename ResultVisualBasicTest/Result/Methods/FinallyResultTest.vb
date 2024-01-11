Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class FinallyResultTest

    <TestMethod>
    Public Sub FinallyGetsCalledOnOkResult()
        Dim sut = Result(Of Integer, String).Ok(1)

        Assert.AreEqual(0, sut.Finallly(Function(x) x.Unwrap() - 1))
    End Sub

    <TestMethod>
    Public Sub FinallyGetsCalledOnOkResultOnChain()
        Dim testValue As Integer = 30
        Dim sut = Result(Of Integer, String).Ok(testValue)

        Assert.AreEqual(testValue * 2 - 1, sut.
                        Map(Function() testValue * 2).
                        Finallly(Function(x) x.Unwrap() - 1))
    End Sub

    <TestMethod>
    Public Sub FinallyGetsCalledOnErrResultOnChain()
        Dim testValue As Integer = 30
        Dim sut = Result(Of Integer, String).Err("Scary")

        Assert.AreEqual("Scary".Length, sut.
                        Map(Function() 1 - 1).
                        Finallly(Function(x) x.Err().Length))
    End Sub
End Class
