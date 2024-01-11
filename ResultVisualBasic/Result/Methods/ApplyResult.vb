Imports System.Runtime.CompilerServices

Namespace Result
    Public Module ApplyResult
        <Extension()>
        Public Function Apply(Of T, E)(res As Result(Of T, E), func As Action(Of T)) As Result(Of T, E)
            If res.IsErr() Then
                Return res
            Else
                func.Invoke(res.Unwrap())
            End If

            Return res
        End Function
    End Module
End Namespace