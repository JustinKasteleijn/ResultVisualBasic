Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class ApplyResultTest
    <TestMethod>
    Public Sub ApplyRetunsAppliedIdenticalValues()
        Dim expected As Integer = 5
        Dim sut = Result(Of Integer, String).Ok(expected)

        Assert.AreEqual(expected, sut.Apply(Sub(x) Math.Sqrt(x)).Unwrap())
    End Sub

    <TestMethod>
    Public Sub ApplyResultInvokesMethod()
        Dim testvalue As String = "works!"
        Dim _global As String = "test "
        Dim expected As String = _global & testvalue
        Dim sut = Result(Of String, String).Ok(testvalue)

        sut.Apply(Sub(x)
                      _global &= x
                  End Sub)

        Assert.AreEqual(expected, _global)
    End Sub

    <TestMethod>
    Public Sub ApplyResultIgnoresErr()
        Dim expected As Integer = 5
        Dim testvalue As String = "works!"
        Dim _global As String = "test "
        Dim sut = Result(Of String, String).Err(testvalue)

        sut.Apply(Sub(x) _global.Append(x))

        Assert.AreNotEqual(expected, _global)
    End Sub
End Class
