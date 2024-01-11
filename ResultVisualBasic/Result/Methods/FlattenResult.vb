Imports System.Runtime.CompilerServices

Namespace Result
    Public Module FlattenResult
        <Extension()>
        Public Function Flatten(Of T, E)(res As Result(Of Result(Of T, E), E)) As Result(Of T, E)
            If res.IsErr() Then
                Return Result(Of T, E).Err(res.Err())
            End If

            Return res.Unwrap()
        End Function
    End Module
End Namespace