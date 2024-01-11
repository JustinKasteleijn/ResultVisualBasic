Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class AndThenResultTest

    <TestMethod>
    Public Sub AndThenCallsMethodOnOk()
        Dim value = 200
        Dim expected As Double = Math.Sqrt(value)
        Dim sut = Result(Of Double, String).Ok(value)

        Assert.AreEqual(expected, sut.
                        AndThen(Function(x) Result(Of Double, String).Ok(Math.Sqrt(x))).
                        Unwrap()
       )
    End Sub

    <TestMethod>
    Public Sub AndThenDoesNotCallMethodOnErr()
        Dim value = 200
        Dim expected As String = "Scary"
        Dim sut = Result(Of Double, String).Err(expected)

        Assert.AreEqual(expected, sut.
                        AndThen(Function(x) Result(Of Double, String).Err(Math.Sqrt(x))).
                        Err()
        )
    End Sub

    <TestMethod>
    Public Sub AndThenReturnsErrWhenFunctionPanics()
        Dim expected As String = "Scary"
        Dim sut = Result(Of Double, String).Ok(2000)

        Assert.AreEqual(expected, sut.
                        AndThen(Function(x) Result(Of Double, String).Err(expected)).
                        Err()
        )
    End Sub
End Class
