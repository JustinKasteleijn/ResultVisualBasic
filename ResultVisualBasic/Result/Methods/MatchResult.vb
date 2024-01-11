Imports System.Runtime.CompilerServices

Namespace Result
    Public Module MatchResult
        <Extension()>
        Public Function Match(Of T, E, R)(result As Result(Of T, E), OnSucces As Func(Of T, R), onError As Func(Of E, R)) As R
            If result.IsOk() Then
                Return OnSucces(result.Unwrap())
            End If
            Return onError(result.Err())
        End Function

        <Extension()>
        Public Sub Match(Of T, E)(result As Result(Of T, E), OnSucces As Action(Of T), onError As Action(Of E))
            If result.IsOk() Then
                OnSucces(result.Unwrap())
            Else
                onError(result.Err())
            End If
        End Sub
    End Module
End Namespace