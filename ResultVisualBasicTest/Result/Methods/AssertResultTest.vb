Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class AssertResultTest


    <TestMethod>
    Public Sub AssertReturnErrorOnErr()
        Dim expected As String = "Scary"
        Dim sut = Result(Of Integer, String).Err(expected)

        Assert.AreEqual(expected, sut.Assert(
                    Function() True,
                    Function(err) err
            ).Err()
        )
    End Sub

    <TestMethod>
    Public Sub AssertReturnValueOnTruePredicate()
        Dim expected As Integer = 7
        Dim sut = Result(Of Integer, String).Ok(expected)
        Dim pred = Function(x) x > 0

        Assert.AreEqual(expected, sut.Assert(
                    pred,
                    Function(err) err
            ).Unwrap()
        )
    End Sub

    <TestMethod>
    Public Sub AssertReturnErrOnFalsePredicate()
        Dim expected As String = "Scary"
        Dim sut = Result(Of Integer, String).Ok(-1)
        Dim pred = Function(x) x > 0

        Assert.AreEqual(expected, sut.Assert(
                    pred,
                    Function() expected
            ).Err()
        )
    End Sub
End Class
