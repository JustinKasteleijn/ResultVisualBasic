Imports ResultVisualBasic.Result
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class TryResultTest

    Private Const expectedMessage As String = "Can not sqrt negative integers"

    Public Function CustomSqrt(x As Integer) As Double
        If x < 0 Then
            Throw New Exception(expectedMessage)
        Else
            Return Math.Sqrt(x)
        End If
    End Function

    <TestMethod>
    Public Sub ExampleNoException()
        Dim value As Integer = 15
        Dim expected As Result(Of Double, String) =
            Result(Of Double, String).Ok(value:=CustomSqrt(value))
        Dim res As Result(Of Double, String) =
            Result(Of Double, String).
                Try(
                    func:=Function() CustomSqrt(value),
                    onError:=Function(exception) exception.Message
                )

        Assert.AreEqual(expected, res)
    End Sub

    <TestMethod>
    Public Sub ExampleCatchException()
        Dim value As Integer = -1
        Dim expected As Result(Of Double, String) =
            Result(Of Double, String).Err(errorValue:=expectedMessage)

        Dim res As Result(Of Double, String) =
            Result(Of Double, String).
                Try(
                    func:=Function() CustomSqrt(value),
                    onError:=Function(exception) exception.Message
                )

        Assert.AreEqual(expected, res)
    End Sub
End Class
