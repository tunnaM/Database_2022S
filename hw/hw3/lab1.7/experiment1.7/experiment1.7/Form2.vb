Public Class Form2
    Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBox1.Text = imin
        TextBox2.Text = imax
        TextBox3.Text = iavg
    End Sub
End Class