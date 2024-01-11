Imports System.Runtime.CompilerServices

Namespace Result
    Public Module OrElseResult
        <Extension()>
        Public Function [OrElse](Of T, E)(res As Result(Of T, E), op As Func(Of Result(Of T, E), Result(Of T, E))) As Result(Of T, E)
            If res.IsErr() Then
                Return op(res)
            End If

            Return res
        End Function
    End Module
End Namespace