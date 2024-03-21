Module Module1
    Public arr() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Public N%, i%, j%, imin%, xmin%, imax%, xmax%, x%, isum%, iavg%
    Public Function min(ByVal arr, ByVal N, ByRef i, ByRef x)
        Dim k%
        i = arr(0)
        For k = 1 To N - 1
            If arr(k) < i Then
                i = arr(k)
                x = k
            End If
        Next
    End Function

    Public Function max(ByVal arr, ByVal N, ByRef i, ByRef x)
        Dim m%
        i = arr(0)
        For m = 1 To N - 1
            If arr(m) > i Then
                i = arr(m)
                x = m
            End If
        Next
    End Function

    Public Function sum(ByVal arr, ByVal N, ByRef isum)
        For j = 0 To N - 1
            isum += arr(j)
        Next
    End Function
End Module
