Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.LoadFile("E:\大二下\数据库\作业\作业3_2020111235_马靖淳\实验1.8\文本.txt", RichTextBoxStreamType.PlainText)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RichTextBox1.SaveFile("E:\大二下\数据库\作业\作业3_2020111235_马靖淳\实验1.8\修改.rtf")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim j%
        Static i% = 0
        j = InStr(i + 1, RichTextBox1.Text, ".NET")
        If j = 0 Then
            MsgBox("no Find")
        Else
            RichTextBox1.Focus()
            RichTextBox1.SelectionStart = j - 1
            RichTextBox1.SelectionLength = 4
            i = j
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub
End Class
