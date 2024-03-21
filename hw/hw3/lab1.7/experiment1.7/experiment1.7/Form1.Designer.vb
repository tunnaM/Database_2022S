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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.随机产生10个数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.删除最小值ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.删除最大值ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.添加数据ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.统计ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.结束ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.数据ToolStripMenuItem, Me.统计ToolStripMenuItem, Me.结束ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(532, 32)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '数据ToolStripMenuItem
        '
        Me.数据ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.随机产生10个数据ToolStripMenuItem, Me.删除最小值ToolStripMenuItem, Me.删除最大值ToolStripMenuItem, Me.添加数据ToolStripMenuItem})
        Me.数据ToolStripMenuItem.Name = "数据ToolStripMenuItem"
        Me.数据ToolStripMenuItem.Size = New System.Drawing.Size(62, 28)
        Me.数据ToolStripMenuItem.Text = "数据"
        '
        '随机产生10个数据ToolStripMenuItem
        '
        Me.随机产生10个数据ToolStripMenuItem.Name = "随机产生10个数据ToolStripMenuItem"
        Me.随机产生10个数据ToolStripMenuItem.Size = New System.Drawing.Size(258, 34)
        Me.随机产生10个数据ToolStripMenuItem.Text = "随机产生10个数据"
        '
        '删除最小值ToolStripMenuItem
        '
        Me.删除最小值ToolStripMenuItem.Name = "删除最小值ToolStripMenuItem"
        Me.删除最小值ToolStripMenuItem.Size = New System.Drawing.Size(258, 34)
        Me.删除最小值ToolStripMenuItem.Text = "删除最小值"
        '
        '删除最大值ToolStripMenuItem
        '
        Me.删除最大值ToolStripMenuItem.Name = "删除最大值ToolStripMenuItem"
        Me.删除最大值ToolStripMenuItem.Size = New System.Drawing.Size(258, 34)
        Me.删除最大值ToolStripMenuItem.Text = "删除最大值"
        '
        '添加数据ToolStripMenuItem
        '
        Me.添加数据ToolStripMenuItem.Name = "添加数据ToolStripMenuItem"
        Me.添加数据ToolStripMenuItem.Size = New System.Drawing.Size(258, 34)
        Me.添加数据ToolStripMenuItem.Text = "添加数据"
        '
        '统计ToolStripMenuItem
        '
        Me.统计ToolStripMenuItem.Name = "统计ToolStripMenuItem"
        Me.统计ToolStripMenuItem.Size = New System.Drawing.Size(62, 28)
        Me.统计ToolStripMenuItem.Text = "统计"
        '
        '结束ToolStripMenuItem
        '
        Me.结束ToolStripMenuItem.Name = "结束ToolStripMenuItem"
        Me.结束ToolStripMenuItem.Size = New System.Drawing.Size(62, 28)
        Me.结束ToolStripMenuItem.Text = "结束"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(323, 49)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(150, 312)
        Me.TextBox1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 397)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 数据ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 随机产生10个数据ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 删除最小值ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 删除最大值ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 添加数据ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 统计ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 结束ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBox1 As TextBox
End Class
