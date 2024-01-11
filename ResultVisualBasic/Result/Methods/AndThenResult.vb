Imports System.Runtime.CompilerServices

Namespace Result
    Public Module AndThenResult
        <Extension()>
        Public Function AndThen(Of T, K, E)(res As Result(Of T, E), func As Func(Of T, Result(Of K, E))) As Result(Of K, E)
            If res.IsErr() Then
                Return Result(Of K, E).Err(res.Err())
            End If

            Return func(res.Unwrap())
        End Function
    End Module
End Namespace
