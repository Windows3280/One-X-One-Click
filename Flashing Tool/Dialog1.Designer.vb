<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog1
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
        Me.GhostTheme1 = New One_Clik.GhostTheme()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GhostButton4 = New One_Clik.GhostButton()
        Me.GhostButton3 = New One_Clik.GhostButton()
        Me.GhostTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GhostTheme1
        '
        Me.GhostTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.GhostTheme1.Colors = New One_Clik.Bloom(-1) {}
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
        Me.GhostTheme1.Size = New System.Drawing.Size(180, 130)
        Me.GhostTheme1.SmartBounds = True
        Me.GhostTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.GhostTheme1.TabIndex = 1
        Me.GhostTheme1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.GhostTheme1.Transparent = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 40)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.GhostButton4.Location = New System.Drawing.Point(93, 95)
        Me.GhostButton4.Name = "GhostButton4"
        Me.GhostButton4.NoRounding = False
        Me.GhostButton4.Size = New System.Drawing.Size(75, 23)
        Me.GhostButton4.TabIndex = 1
        Me.GhostButton4.Text = "No"
        Me.GhostButton4.Transparent = False
        '
        'GhostButton3
        '
        Me.GhostButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GhostButton3.Color = System.Drawing.Color.Empty
        Me.GhostButton3.Colors = New One_Clik.Bloom(-1) {}
        Me.GhostButton3.Customization = ""
        Me.GhostButton3.EnableGlass = True
        Me.GhostButton3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GhostButton3.Image = Nothing
        Me.GhostButton3.Location = New System.Drawing.Point(15, 95)
        Me.GhostButton3.Name = "GhostButton3"
        Me.GhostButton3.NoRounding = False
        Me.GhostButton3.Size = New System.Drawing.Size(75, 23)
        Me.GhostButton3.TabIndex = 0
        Me.GhostButton3.Text = "Yes"
        Me.GhostButton3.Transparent = False
        '
        'Dialog1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(180, 130)
        Me.Controls.Add(Me.GhostTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog1"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.GhostTheme1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GhostTheme1 As One_Clik.GhostTheme
    Friend WithEvents GhostButton4 As One_Clik.GhostButton
    Friend WithEvents GhostButton3 As One_Clik.GhostButton
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
