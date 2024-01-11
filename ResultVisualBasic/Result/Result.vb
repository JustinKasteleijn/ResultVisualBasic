Namespace Result
    Partial Public Structure Result(Of T, E)
        Private ReadOnly _value As T
        Private ReadOnly _errorValue As E
        Private ReadOnly _isSuccess As Boolean

        Public Sub New(value As T, errorValue As E, isSuccess As Boolean)
            _value = value
            _errorValue = errorValue
            _isSuccess = isSuccess
        End Sub

        Public Function IsErr() As Boolean
            Return Not _isSuccess
        End Function

        Public Function IsOk() As Boolean
            Return _isSuccess
        End Function

        Public Function Unwrap() As T
            If _isSuccess Then
                Return _value
            End If
            Throw New Panic("Result panicked at unwrap. Consider using 'result.Match' to also act upon the error if required")
        End Function

        Public Function Err() As E
            If Not IsOk() Then
                Return _errorValue
            End If
            Throw New Panic("Err panicked at err. Consider using 'result.match' to handle both succes and error case")
        End Function

        Public Shared Function Ok(value As T) As Result(Of T, E)
            Return New Result(Of T, E)(value, Nothing, True)
        End Function

        Public Shared Function Err(errorValue As E) As Result(Of T, E)
            Return New Result(Of T, E)(Nothing, errorValue, False)
        End Function
    End Structure
End Namespace