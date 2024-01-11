Imports System.Runtime.CompilerServices

Namespace Result
    Public Module IsErrAndResult
        <Extension()>
        Public Function IsErrAnd(Of T, E)(res As Result(Of T, E), predicate As Func(Of E, Boolean)) As Boolean
            If res.IsOk() Then
                Return False
            End If

            If Not predicate(res.Err()) Then
                Return False
            End If

            Return True
        End Function
    End Module
End Namespace