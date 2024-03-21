Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox2.Items.Add(ComboBox1.Text)
        If CheckBox1.Checked Then
            ListBox2.Items.Add(CheckBox1.Text)
        End If
        If CheckBox2.Checked Then
            ListBox2.Items.Add(CheckBox2.Text)
        End If
        If CheckBox3.Checked Then
            ListBox2.Items.Add(CheckBox3.Text)
        End If
        If RadioButton1.Checked Then
            ListBox2.Items.Add(RadioButton1.Text)
        End If
        If RadioButton2.Checked Then
            ListBox2.Items.Add(RadioButton2.Text)
        End If
        If RadioButton3.Checked Then
            ListBox2.Items.Add(RadioButton3.Text)
        End If
        If RadioButton4.Checked Then
            ListBox2.Items.Add(RadioButton4.Text)
        End If
        If RadioButton5.Checked Then
            ListBox2.Items.Add(RadioButton5.Text)
        End If
    End Sub
End Class
