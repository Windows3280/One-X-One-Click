<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Install2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GhostTheme1 = New One_Clik.GhostTheme()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GhostButton4 = New One_Clik.GhostButton()
        Me.GhostButton3 = New One_Clik.GhostButton()
        Me.GhostTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GhostTheme1
        '
        Me.GhostTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.GhostTheme1.Colors = New One_Clik.Bloom(-1) {}
        Me.GhostTheme1.Controls.Add(Me.TextBox1)
        Me.GhostTheme1.Controls.Add(Me.Label1)
        Me.GhostTheme1.Controls.Add(Me.RadioButton1)
        Me.GhostTheme1.Controls.Add(Me.RadioButton2)
        Me.GhostTheme1.Controls.Add(Me.Label2)
        Me.GhostTheme1.Controls.Add(Me.GhostButton4)
        Me.GhostTheme1.Controls.Add(Me.GhostButton3)
        Me.GhostTheme1.Customization = ""
        Me.GhostTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GhostTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GhostTheme1.Image = Nothing
        Me.GhostTheme1.Location = New System.Drawing.Point(0, 0)
        Me.GhostTheme1.Movable = True
        Me.GhostTheme1.Name = "GhostTheme1"
        Me.GhostTheme1.NoRounding = False
        Me.GhostTheme1.ShowIcon = False
        Me.GhostTheme1.Sizable = False
        Me.GhostTheme1.Size = New System.Drawing.Size(304, 204)
        Me.GhostTheme1.SmartBounds = True
        Me.GhostTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.GhostTheme1.TabIndex = 1
        Me.GhostTheme1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.GhostTheme1.Transparent = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 134)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(280, 20)
        Me.TextBox1.TabIndex = 10
        Me.TextBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(283, 40)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "FileName:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1.ForeColor = System.Drawing.Color.White
        Me.RadioButton1.Location = New System.Drawing.Point(15, 75)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(62, 17)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Kernel"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton2.ForeColor = System.Drawing.Color.White
        Me.RadioButton2.Location = New System.Drawing.Point(15, 98)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(79, 17)
        Me.RadioButton2.TabIndex = 2
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Recovery"
        Me.RadioButton2.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Modules:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label2.Visible = False
        '
        'GhostButton4
        '
        Me.GhostButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GhostButton4.Color = System.Drawing.Color.Empty
        Me.GhostButton4.Colors = New One_Clik.Bloom(-1) {}
        Me.GhostButton4.Customization = ""
        Me.GhostButton4.EnableGlass = True
        Me.GhostButton4.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GhostButton4.Image = Nothing
        Me.GhostButton4.Location = New System.Drawing.Point(217, 169)
        Me.GhostButton4.Name = "GhostButton4"
        Me.GhostButton4.NoRounding = False
        Me.GhostButton4.Size = New System.Drawing.Size(75, 23)
        Me.GhostButton4.TabIndex = 4
        Me.GhostButton4.Text = "No"
        Me.GhostButton4.Transparent = False
        '
        'GhostButton3
        '
        Me.GhostButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GhostButton3.Color = System.Drawing.Color.Empty
        Me.GhostButton3.Colors = New One_Clik.Bloom(-1) {}
        Me.GhostButton3.Customization = ""
        Me.GhostButton3.Enabled = False
        Me.GhostButton3.EnableGlass = True
        Me.GhostButton3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GhostButton3.Image = Nothing
        Me.GhostButton3.Location = New System.Drawing.Point(12, 169)
        Me.GhostButton3.Name = "GhostButton3"
        Me.GhostButton3.NoRounding = False
        Me.GhostButton3.Size = New System.Drawing.Size(75, 23)
        Me.GhostButton3.TabIndex = 3
        Me.GhostButton3.Text = "Yes"
        Me.GhostButton3.Transparent = False
        '
        'Install2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 204)
        Me.Controls.Add(Me.GhostTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Install2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Install"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.GhostTheme1.ResumeLayout(False)
        Me.GhostTheme1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GhostTheme1 As One_Clik.GhostTheme
    Friend WithEvents GhostButton4 As One_Clik.GhostButton
    Friend WithEvents GhostButton3 As One_Clik.GhostButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

    Public Modules As String

End Class
