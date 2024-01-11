Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class InspectResultTest

    <TestMethod>
    Public Sub InspectsOkResult()
        Dim glo As String = ""
        Dim value As Integer = 10000
        Dim expected As String = $"Result holds value of {value}"

        Dim sut = Result(Of Integer, String).Ok(value)

        sut.Inspect(Sub(x)
                        glo = x
                    End Sub)

        Assert.AreEqual(expected, glo)
    End Sub

    <TestMethod>
    Public Sub InspectsErrResult()
        Dim glo As String = ""
        Dim errMessage As String = "Scary"
        Dim expected As String = $"Result holds error of {errMessage}"

        Dim sut = Result(Of Integer, String).Err(errMessage)

        sut.Inspect(Sub(x)
                        glo = x
                    End Sub)

        Assert.AreEqual(expected, glo)
    End Sub
End Class
