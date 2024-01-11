Imports System.Runtime.CompilerServices

Namespace Result
    Public Module ExpectResult
        <Extension()>
        Public Function Expect(Of T, E)(res As Result(Of T, E), message As String) As T
            If res.IsErr() Then
                Throw New ExpectException(message)
            End If

            Return res.Unwrap()
        End Function
    End Module
End Namespace
