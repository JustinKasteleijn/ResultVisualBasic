Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class FlattenResultTest

    <TestMethod>
    Public Sub FlattensSingleLayerOk()
        Dim expected = Result(Of Result(Of Integer, String), String).
            Ok(Result(Of Integer, String).
            Ok(1))
        Dim sut = Result(Of Result(Of Result(Of Integer, String), String), String).
            Ok(Result(Of Result(Of Integer, String), String).
            Ok(Result(Of Integer, String).
            Ok(1)))
        Assert.AreEqual(
            expected,
            sut.Flatten()
        )
    End Sub

    <TestMethod>
    Public Sub FlattensDoubleLayerOk()
        Dim expected = Result(Of Integer, String).Ok(1)
        Dim sut = Result(Of Result(Of Result(Of Integer, String), String), String).
            Ok(Result(Of Result(Of Integer, String), String).
            Ok(Result(Of Integer, String).
            Ok(1)))
        Assert.AreEqual(
            expected,
            sut.Flatten().Flatten()
        )
    End Sub

    <TestMethod>
    Public Sub FlattensSingleLayerErr()
        Dim expected As Result(Of Result(Of Integer, String), String) =
            Result(Of Result(Of Integer, String), String).
                Ok(Result(Of Integer, String).
                    Err("Err"))
        Dim sut = Result(Of Result(Of Result(Of Integer, String), String), String).
            Ok(Result(Of Result(Of Integer, String), String).
            Ok(Result(Of Integer, String).
            Err("Err")))
        Assert.AreEqual(
            expected,
            sut.Flatten()
        )
    End Sub

    <TestMethod>
    Public Sub FlattensDoubleLayerErr()
        Dim expected = Result(Of Integer, String).Err("Err")
        Dim sut = Result(Of Result(Of Result(Of Integer, String), String), String).
            Ok(Result(Of Result(Of Integer, String), String).
            Ok(Result(Of Integer, String).
            Err("Err")))
        Assert.AreEqual(
            expected,
            sut.Flatten().Flatten()
        )
    End Sub
End Class
