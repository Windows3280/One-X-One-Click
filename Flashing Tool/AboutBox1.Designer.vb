<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox1))
        Me.GhostTheme1 = New One_Clik.GhostTheme()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.OKButton = New One_Clik.GhostButton()
        Me.GhostTheme1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GhostTheme1
        '
        Me.GhostTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.GhostTheme1.Colors = New One_Clik.Bloom(-1) {}
        Me.GhostTheme1.Controls.Add(Me.PictureBox1)
        Me.GhostTheme1.Controls.Add(Me.Label1)
        Me.GhostTheme1.Controls.Add(Me.LabelProductName)
        Me.GhostTheme1.Controls.Add(Me.OKButton)
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
        Me.GhostTheme1.Size = New System.Drawing.Size(501, 169)
        Me.GhostTheme1.SmartBounds = True
        Me.GhostTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.GhostTheme1.TabIndex = 2
        Me.GhostTheme1.Text = "About"
        Me.GhostTheme1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.GhostTheme1.Transparent = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.One_Clik.My.Resources.Resources.btn_donateCC_LG
        Me.PictureBox1.Location = New System.Drawing.Point(12, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 132)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(172, 42)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(289, 92)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelProductName
        '
        Me.LabelProductName.BackColor = System.Drawing.Color.Transparent
        Me.LabelProductName.ForeColor = System.Drawing.Color.White
        Me.LabelProductName.Location = New System.Drawing.Point(175, 25)
        Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(286, 17)
        Me.LabelProductName.TabIndex = 1
        Me.LabelProductName.Text = "Product Name"
        Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Color = System.Drawing.Color.Empty
        Me.OKButton.Colors = New One_Clik.Bloom(-1) {}
        Me.OKButton.Customization = ""
        Me.OKButton.EnableGlass = True
        Me.OKButton.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.OKButton.Image = Nothing
        Me.OKButton.Location = New System.Drawing.Point(414, 134)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.NoRounding = False
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 4
        Me.OKButton.Text = "OK"
        Me.OKButton.Transparent = False
        '
        'AboutBox1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 169)
        Me.Controls.Add(Me.GhostTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutBox1"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AboutBox1"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.GhostTheme1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GhostTheme1 As One_Clik.GhostTheme
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents OKButton As One_Clik.GhostButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
