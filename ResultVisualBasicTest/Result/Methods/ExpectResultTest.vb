Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class ExpectResultTest
    <TestMethod>
    Public Sub ExpectReturnsValOnOkResult()
        Dim expected As Integer = 32
        Dim sut = Result(Of Integer, String).Ok(expected)

        Assert.AreEqual(expected, sut.Expect("Must contain a value"))
    End Sub

    <TestMethod>
    Public Sub ExpectThrowsOnErrResult()
        Dim sut = Result(Of Integer, String).Err("Err")
        Dim message As String = "Does not contain a value"
        Dim getMessage As Func(Of String) = Function()
                                                Try
                                                    sut.Expect(message)
                                                Catch ex As Exception
                                                    Return message
                                                End Try
                                                Return ""
                                            End Function

        Assert.ThrowsException(Of ExpectException)(Function() sut.Expect(message))
        Assert.AreEqual(message, getMessage())
    End Sub
End Class
