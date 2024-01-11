Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class MapResultTest
    <TestMethod>
    Public Sub MapReturnsMappedValueOnOk()
        Dim value As Integer = 4
        Dim expected As Double = Math.Sqrt(value)

        Assert.AreEqual(
            expected,
            Result(Of Double, String).
                Ok(value).
                Map(Function(x) Math.Sqrt(x)).
                Unwrap()
        )
    End Sub

    <TestMethod>
    Public Sub MapReturnsMappedValueChainOnOk()
        Dim value As Integer = 4
        Dim expected As Double = Math.Sqrt(Math.Sqrt(value))

        Assert.AreEqual(
            expected,
            Result(Of Double, String).
                Ok(value).
                Map(Function(x) Math.Sqrt(x)).
                Map(Function(x) Math.Sqrt(x)).
                Unwrap()
        )
    End Sub

    <TestMethod>
    Public Sub MapReturnsFirstErrOnChainErr()
        Dim expected As String = "This is the earliest error"

        Assert.AreEqual(
            expected,
            Result(Of Double, String).
                Err(expected).
                Map(Function(x) Math.Sqrt(x)).
                Map(Function(x) Math.Sqrt(x)).
                Err()
        )
    End Sub
End Class
