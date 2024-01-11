Imports System.Runtime.CompilerServices

Namespace Result
    Public Module InspectResult
        <Extension()>
        Public Function Inspect(Of T, E)(res As Result(Of T, E), printer As Action(Of String)) As Result(Of T, E)
            If res.IsErr() Then
                printer.Invoke($"Result holds error of {res.Err()}")
            Else
                printer.Invoke($"Result holds value of {res.Unwrap()}")
            End If

            Return res
        End Function
    End Module
End Namespace