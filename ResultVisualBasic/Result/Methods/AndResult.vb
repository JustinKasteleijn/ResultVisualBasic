Imports System.Runtime.CompilerServices

Namespace Result
    Public Module AndResult
        <Extension()>
        Public Function [And](Of T, K, E)(res As Result(Of T, E), other As Result(Of K, E)) As Result(Of K, E)
            If res.IsErr() And other.IsErr() Or res.IsOk() And other.IsOk() Then
                Return other
            End If

            If res.IsErr() Then
                Return Result(Of K, E).Err(res.Err())
            End If

            Return other
        End Function
    End Module
End Namespace