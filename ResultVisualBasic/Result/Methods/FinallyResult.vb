Imports System.Runtime.CompilerServices

Namespace Result
    Public Module FinallyResult
        <Extension()>
        Public Function Finallly(Of T, E)(res As Result(Of T, E), _func As Func(Of Result(Of T, E), T)) As T
            Return _func(res)
        End Function
    End Module
End Namespace