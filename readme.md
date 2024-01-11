# VisualBasicFunctionalExtensions

**Package ID:** VisualBasicFunctionalExtensions  
**Version:** 1.0.0
**Owner:** Justi  
**License:** MIT

## Overview

Welcome to the ResultVisualBasic project! This project introduces a fully tested Result Monad for Visual Basic (VB), providing developers with a robust and functional way to handle the outcomes of operations. Whether you are a VB developer looking to improve error handling or a contributor interested in functional programming.

## Installation

Install via NuGet Package Manager Console:

```bash
TODO
```

## Features
    * Generic Type: The Result Monad is implemented as a generic type in VB, ensuring flexibility and compatibility with various data types.
    * Immutable: Instances of the Result Monad are immutable, promoting a consistent and predictable flow of data through functional transformations.
    * Success and Failure Handling: Easily check whether an operation was successful or resulted in an error, providing explicit handling for success and failure scenarios.
    * Error Details: In case of failure, the Result Monad includes information about the error, aiding in effective error diagnosis.
    * Map and Bind Operations: Support for map and bind operations, allowing developers to apply functions to encapsulated values without unwrapping explicitly.
    * Composability: Result Monads can be composed, simplifying error handling and promoting modular and expressive code structures.

## Examples 
Introduction to all the methods and function the library has to offer. 

### Result

#### Try
*[Try](Of T, E)(func As Func(Of T), onError As Func(Of Exception, E)) As Result(Of T, E)*

```vbnet
    Private Const expectedMessage = "Can not sqrt negative integers"

    Public Function CustomSqrt(x As Integer) As Double
        If x < 0 Then
            Throw New Exception(expectedMessage)
        Else
            Return Math.Sqrt(x)
        End If
    End Function

    Public Sub ExampleNoException()
        Dim value = 15
        Dim expected = Result(Of Double, String).Ok(CustomSqrt(value))
        Dim res = Result(Of Double, String).
            Try(
                Function() CustomSqrt(value),
                Function(exception) exception.Message
            )

        Assert.AreEqual(expected, res)
    End Sub

    Public Sub ExampleCatchException()
        Dim value = -1
        Dim expected  = Result(Of Double, String).Err(errorValue:=expectedMessage)
        Dim res = Result(Of Double, String).
            Try(
                Function() CustomSqrt(value),
                Function(exception) exception.Message
            )

        Assert.AreEqual(expected, res)
    End Sub
```

## Authors
Justin Kasteleijn
Nadia Alrayes

## License
MIT License

## Copyright
(c) Justin Kasteleijn 2024

## Bug Reporting
For bug reports, visit the GitHub repository.