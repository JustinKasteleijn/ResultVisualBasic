Imports System.Runtime.CompilerServices

Namespace Result
    Partial Public Structure Result(Of T, E)
        Public Shared Function [Try](Of Val, Err)(func As Func(Of Val), onError As Func(Of Exception, Err)) As Result(Of Val, Err)
            Try
                Return Result(Of Val, Err).Ok(func())
            Catch ex As Exception
                Return Result(Of Val, Err).Err(onError(ex))
            End Try
        End Function
    End Structure
End Namespace