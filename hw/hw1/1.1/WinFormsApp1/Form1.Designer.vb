<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Inputbox = New System.Windows.Forms.RichTextBox()
        Me.Copybox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "输入文本"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(510, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "复制效果"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(30, 350)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 60)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "隶书" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2 5 磅"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(190, 350)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 60)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "幼圆" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1 5 磅"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(340, 260)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 62)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "复制" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "= >"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Inputbox
        '
        Me.Inputbox.Location = New System.Drawing.Point(30, 100)
        Me.Inputbox.Name = "Inputbox"
        Me.Inputbox.Size = New System.Drawing.Size(280, 230)
        Me.Inputbox.TabIndex = 5
        Me.Inputbox.Text = ""
        '
        'Copybox
        '
        Me.Copybox.Location = New System.Drawing.Point(480, 100)
        Me.Copybox.Name = "Copybox"
        Me.Copybox.Size = New System.Drawing.Size(280, 230)
        Me.Copybox.TabIndex = 6
        Me.Copybox.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Copybox)
        Me.Controls.Add(Me.Inputbox)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Private WithEvents Inputbox As RichTextBox
    Friend WithEvents Copybox As RichTextBox

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Inputbox.Font = New Font("隶书", 25)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Inputbox.Font = New Font("幼圆", 15)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Copybox.Text = Inputbox.SelectedText
        Copybox.Font = Inputbox.Font
    End Sub
End Class
