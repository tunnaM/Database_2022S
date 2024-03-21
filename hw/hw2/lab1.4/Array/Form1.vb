Public Class Form1
    Dim arr() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Dim N%, i%, j%, imin%, imax%, sum%, avg%
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Randomize() ' 随机化随机数，如果不使用此方法，每次产生的随机数相同
        N = UBound(arr)
        For Me.i = 0 To N
            arr(i) = Int(70 * Rnd() + 30)
            TextBox1.Text &= arr(i) & "  "
            TextBox1.Font = New Font("", 12)
        Next i
        imin = arr(0)
        imax = arr(0)
        sum = arr(0)
        For j = 1 To N
            If arr(j) > imax Then
                imax = arr(j)
            End If
            If arr(j) < imin Then
                imin = arr(j)
            End If
            sum += arr(j)
        Next
        avg = sum / N
        TextBox1.Text &= vbCrLf & "Min=" & imin & " Max=" & imax & " Avg=" & avg
    End Sub
End Class
