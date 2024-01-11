Imports System.Runtime.CompilerServices

Namespace Result
    Public Module MapResult
        <Extension()>
        Public Function Map(Of T, K, E)(res As Result(Of T, E), _map As Func(Of T, K)) As Result(Of K, E)
            If res.IsErr() Then
                Return Result(Of K, E).Err(res.Err())
            End If

            Return Result(Of K, E).Ok(_map(res.Unwrap()))
        End Function
    End Module
End Namespace