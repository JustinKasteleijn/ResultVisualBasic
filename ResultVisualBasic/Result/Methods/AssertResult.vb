Imports System.Runtime.CompilerServices

Namespace Result
    Public Module AssertResult
        <Extension()>
        Public Function Assert(Of T, E)(res As Result(Of T, E), predicate As Func(Of T, Boolean), errorHandler As Func(Of T, E)) As Result(Of T, E)
            If res.IsErr() Then
                Return res
            End If

            If Not predicate(res.Unwrap()) Then
                Return Result(Of T, E).Err(errorHandler(res.Unwrap()))
            End If

            Return res
        End Function
    End Module
End Namespace