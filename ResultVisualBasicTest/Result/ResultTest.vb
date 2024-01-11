
Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class ResultTest

    <TestMethod>
    Public Sub CreateErrResult()
        Dim expected As Result(Of Integer, String) = Result(Of Integer, String).Err("Paniced!")

        Assert.AreEqual(expected, Result(Of Integer, String).Err("Paniced!"))
        Assert.AreNotEqual(expected, Result(Of Integer, String).Ok(1))
    End Sub

    <TestMethod>
    Public Sub CreateOkResult()
        Dim testValue As Integer = 1
        Dim sut As Result(Of Integer, String) = Result(Of Integer, String).Ok(testValue)

        Assert.AreEqual(Result(Of Integer, String).Ok(testValue), sut)
        Assert.AreNotEqual(Result(Of Integer, String).Err("Paniced!"), sut)
    End Sub

    <TestMethod>
    Public Sub IsErrReturnsTrueOnErr()
        Dim sut As Result(Of Integer, String) = Result(Of Integer, String).Err("Paniced!")

        Assert.IsTrue(sut.IsErr())
    End Sub

    <TestMethod>
    Public Sub IsErrReturnsFalseOnOk()
        Dim sut As Result(Of Integer, String) = Result(Of Integer, String).Ok(1)

        Assert.IsFalse(sut.IsErr())
    End Sub

    <TestMethod>
    Public Sub IsOkReturnsTrueOnOk()
        Dim sut As Result(Of Integer, String) = Result(Of Integer, String).Ok(1)

        Assert.IsTrue(sut.IsOk())
    End Sub

    <TestMethod>
    Public Sub IsOkReturnsFalseOnErr()
        Dim sut As Result(Of Integer, String) = Result(Of Integer, String).Err("Paniced!")

        Assert.IsFalse(sut.IsOk())
    End Sub

    <TestMethod>
    Public Sub ErrReturnsErrOnErr()
        Dim expected As String = "Paniced!"
        Dim sut As Result(Of Integer, String) = Result(Of Integer, String).Err(expected)

        Assert.AreEqual(expected, sut.Err())
    End Sub

    <TestMethod>
    Public Sub ErrPanicsOnOk()
        Dim sut As Result(Of Integer, String) = Result(Of Integer, String).Ok(1)

        Assert.ThrowsException(Of Panic)(Function() sut.Err())
    End Sub

    <TestMethod>
    Public Sub UnwrapReturnsOkOnOk()
        Dim expected As Integer = 1
        Dim sut As Result(Of Integer, String) = Result(Of Integer, String).Ok(expected)

        Assert.AreEqual(expected, sut.Unwrap())
    End Sub

    <TestMethod>
    Public Sub UnwrapPanicsOnErr()
        Dim expected As Integer = 1
        Dim sut As Result(Of Integer, String) = Result(Of Integer, String).Err("Panic!")

        Assert.ThrowsException(Of Panic)(Function() sut.Unwrap())
    End Sub
End Class
