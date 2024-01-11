Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class MatchResultTest
    <TestMethod>
    Public Sub MatchReturnsValueOnOk()
        Dim expected As Integer = 1002
        Assert.AreEqual(
            expected,
            Result(Of Integer, String).
                Ok(expected).
                Match(
                    Function(x) x,
                    Function(err) -1
                )
        )
    End Sub

    <TestMethod>
    Public Sub MatchReturnsValueOnErr()
        Dim expected As Integer = 1002
        Assert.AreEqual(
            expected,
            Result(Of Integer, String).
                Err("Some error").
                Match(
                    Function(x) x,
                    Function(err) expected
                )
        )
    End Sub

    <TestMethod>
    Public Sub MatchReturnsValueOnErrInChain()
        Dim expected As Integer = 1002
        Assert.AreEqual(
            expected,
            Result(Of Integer, String).
                Ok(-1).
                Assert(Function(x) expected < 0, Function(err) err).
                Match(
                    Function(x) x,
                    Function(err) expected
                )
        )
    End Sub

    <TestMethod>
    Public Sub MatchExecutesActionOnOk()
        Dim expected As Integer = 1002
        Dim _global As Integer = 0

        Result(Of Integer, String).
                Ok(expected).
                Match(
                    Sub(x) _global = x,
                    Sub(err) _global = -1
                )

        Assert.AreEqual(
            expected,
            _global
        )
    End Sub

    <TestMethod>
    Public Sub MatchExecutesActionOnErr()
        Dim expected As Integer = -1
        Dim _global As Integer = 0

        Result(Of Integer, String).
                Err("").
                Match(
                    Sub(x) _global = x,
                    Sub(err) _global = -1
                )

        Assert.AreEqual(
            expected,
            _global
        )
    End Sub

    <TestMethod>
    Public Sub MatchExecutesActionOnErrChain()
        Dim expected As Integer = -1
        Dim _global As Integer = 0

        Result(Of Integer, String).
                Ok(expected).
                Assert(Function(x) x < 0, Function(err) err).
                Match(
                    Sub(x) _global = x,
                    Sub(err) _global = -1
                )

        Assert.AreEqual(
            expected,
            _global
        )
    End Sub
End Class
