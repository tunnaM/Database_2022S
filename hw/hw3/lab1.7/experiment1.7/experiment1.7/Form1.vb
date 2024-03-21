Public Class Form1
    Dim F2 As New Form2


    Sub 随机产生10个数据ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 随机产生10个数据ToolStripMenuItem.Click
        N = 10
        For i = 0 To N - 1
            arr(i) = Int(100 * Rnd())
            TextBox1.Text &= arr(i) & vbCrLf
            TextBox1.Font = New Font("", 12)
        Next i
    End Sub

    Sub 删除最小值ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除最小值ToolStripMenuItem.Click
        TextBox1.Clear()
        imin = arr(0)
        min(arr, N, imin, xmin)
        N = N - 1
        For j = xmin To N - 1
            arr(j) = arr(j + 1)
        Next
        For i = 0 To N - 1
            TextBox1.Text &= arr(i) & vbCrLf
            TextBox1.Font = New Font("", 12)
        Next i
    End Sub

    Sub 删除最大值ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除最大值ToolStripMenuItem.Click
        TextBox1.Clear()
        imax = arr(0)
        max(arr, N, imax, xmax)
        N = N - 1
        For j = xmax To N - 1
            arr(j) = arr(j + 1)
        Next
        For i = 0 To N - 1
            TextBox1.Text &= arr(i) & vbCrLf
            TextBox1.Font = New Font("", 12)
        Next i
    End Sub

    Sub 添加数据ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 添加数据ToolStripMenuItem.Click
        N = N + 1
        arr(N - 1) = Int(100 * Rnd())
        TextBox1.Text &= arr(N - 1) & vbCrLf
    End Sub

    Sub 统计ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 统计ToolStripMenuItem.Click
        min(arr, N, imin, xmin)
        max(arr, N, imax, xmax)
        isum = 0
        sum(arr, N, isum)
        iavg = isum / N
        F2.ShowDialog()
    End Sub

    Sub 结束ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 结束ToolStripMenuItem.Click
        End
    End Sub
End Class
