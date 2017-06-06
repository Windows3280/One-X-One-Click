<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.OXOC = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RestoreTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StartupTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.PhoneDetection = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GhostTheme1 = New One_Clik.GhostTheme()
        Me.About = New System.Windows.Forms.Label()
        Me.Help = New System.Windows.Forms.Label()
        Me.Mini = New System.Windows.Forms.Label()
        Me.XClose = New System.Windows.Forms.Label()
        Me.GroupBox2 = New One_Clik.GhostGroupBox()
        Me.Button3 = New One_Clik.GhostButton()
        Me.Button2 = New One_Clik.GhostButton()
        Me.TextBox1 = New One_Clik.GhostTextBox()
        Me.GroupBox1 = New One_Clik.GhostGroupBox()
        Me.Button1 = New One_Clik.GhostButton()
        Me.ListBox1 = New One_Clik.Listbox()
        Me.GroupBox4 = New One_Clik.GhostGroupBox()
        Me.Batt = New System.Windows.Forms.Label()
        Me.Active = New System.Windows.Forms.Label()
        Me.PhoneM = New System.Windows.Forms.Label()
        Me.GroupBox3 = New One_Clik.GhostGroupBox()
        Me.Stat = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GhostTheme1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'OXOC
        '
        Me.OXOC.ContextMenuStrip = Me.ContextMenuStrip1
        Me.OXOC.Icon = CType(resources.GetObject("OXOC.Icon"), System.Drawing.Icon)
        Me.OXOC.Text = "One Click"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestoreTSMI, Me.ToolStripSeparator1, Me.StartupTSMI, Me.ToolStripSeparator2, Me.ExitTSMI})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(155, 82)
        '
        'RestoreTSMI
        '
        Me.RestoreTSMI.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RestoreTSMI.Name = "RestoreTSMI"
        Me.RestoreTSMI.Size = New System.Drawing.Size(154, 22)
        Me.RestoreTSMI.Text = "Restore/Hide"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(151, 6)
        '
        'StartupTSMI
        '
        Me.StartupTSMI.Name = "StartupTSMI"
        Me.StartupTSMI.Size = New System.Drawing.Size(154, 22)
        Me.StartupTSMI.Text = "Add To Startup"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(151, 6)
        '
        'ExitTSMI
        '
        Me.ExitTSMI.Name = "ExitTSMI"
        Me.ExitTSMI.Size = New System.Drawing.Size(154, 22)
        Me.ExitTSMI.Text = "Exit"
        '
        'PhoneDetection
        '
        Me.PhoneDetection.Interval = 60000
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GhostTheme1
        '
        Me.GhostTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.GhostTheme1.Colors = New One_Clik.Bloom(-1) {}
        Me.GhostTheme1.Controls.Add(Me.About)
        Me.GhostTheme1.Controls.Add(Me.Help)
        Me.GhostTheme1.Controls.Add(Me.Mini)
        Me.GhostTheme1.Controls.Add(Me.XClose)
        Me.GhostTheme1.Controls.Add(Me.GroupBox2)
        Me.GhostTheme1.Controls.Add(Me.GroupBox1)
        Me.GhostTheme1.Controls.Add(Me.GroupBox4)
        Me.GhostTheme1.Controls.Add(Me.GroupBox3)
        Me.GhostTheme1.Customization = ""
        Me.GhostTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GhostTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GhostTheme1.Image = Nothing
        Me.GhostTheme1.Location = New System.Drawing.Point(0, 0)
        Me.GhostTheme1.Movable = True
        Me.GhostTheme1.Name = "GhostTheme1"
        Me.GhostTheme1.NoRounding = False
        Me.GhostTheme1.ShowIcon = True
        Me.GhostTheme1.Sizable = False
        Me.GhostTheme1.Size = New System.Drawing.Size(662, 540)
        Me.GhostTheme1.SmartBounds = True
        Me.GhostTheme1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.GhostTheme1.TabIndex = 8
        Me.GhostTheme1.Text = "One X One Click V2.3B"
        Me.GhostTheme1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.GhostTheme1.Transparent = False
        '
        'About
        '
        Me.About.AutoSize = True
        Me.About.BackColor = System.Drawing.Color.Transparent
        Me.About.Font = New System.Drawing.Font("Verdana", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.About.ForeColor = System.Drawing.Color.White
        Me.About.Location = New System.Drawing.Point(537, 9)
        Me.About.Name = "About"
        Me.About.Size = New System.Drawing.Size(46, 14)
        Me.About.TabIndex = 11
        Me.About.Text = "About"
        '
        'Help
        '
        Me.Help.AutoSize = True
        Me.Help.BackColor = System.Drawing.Color.Transparent
        Me.Help.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Help.ForeColor = System.Drawing.Color.White
        Me.Help.Location = New System.Drawing.Point(589, 8)
        Me.Help.Name = "Help"
        Me.Help.Size = New System.Drawing.Size(14, 14)
        Me.Help.TabIndex = 10
        Me.Help.Text = "?"
        '
        'Mini
        '
        Me.Mini.AutoSize = True
        Me.Mini.BackColor = System.Drawing.Color.Transparent
        Me.Mini.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.999999!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mini.ForeColor = System.Drawing.Color.White
        Me.Mini.Location = New System.Drawing.Point(609, 5)
        Me.Mini.Name = "Mini"
        Me.Mini.Size = New System.Drawing.Size(21, 15)
        Me.Mini.TabIndex = 9
        Me.Mini.Text = "__"
        Me.Mini.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'XClose
        '
        Me.XClose.AutoSize = True
        Me.XClose.BackColor = System.Drawing.Color.Transparent
        Me.XClose.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XClose.ForeColor = System.Drawing.Color.White
        Me.XClose.Location = New System.Drawing.Point(635, 8)
        Me.XClose.Name = "XClose"
        Me.XClose.Size = New System.Drawing.Size(16, 14)
        Me.XClose.TabIndex = 8
        Me.XClose.Text = "X"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Colors = New One_Clik.Bloom(-1) {}
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Customization = ""
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GroupBox2.Image = Nothing
        Me.GroupBox2.Location = New System.Drawing.Point(223, 158)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.NoRounding = False
        Me.GroupBox2.Size = New System.Drawing.Size(425, 370)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Logger"
        Me.GroupBox2.Transparent = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Color = System.Drawing.Color.Empty
        Me.Button3.Colors = New One_Clik.Bloom(-1) {}
        Me.Button3.Customization = ""
        Me.Button3.EnableGlass = True
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Button3.Image = Nothing
        Me.Button3.Location = New System.Drawing.Point(272, 337)
        Me.Button3.Name = "Button3"
        Me.Button3.NoRounding = False
        Me.Button3.Size = New System.Drawing.Size(147, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Clear Log"
        Me.Button3.Transparent = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.Color = System.Drawing.Color.Empty
        Me.Button2.Colors = New One_Clik.Bloom(-1) {}
        Me.Button2.Customization = ""
        Me.Button2.EnableGlass = True
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Button2.Image = Nothing
        Me.Button2.Location = New System.Drawing.Point(11, 337)
        Me.Button2.Name = "Button2"
        Me.Button2.NoRounding = False
        Me.Button2.Size = New System.Drawing.Size(147, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Save Log"
        Me.Button2.Transparent = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.Transparent
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(8, 26)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(411, 305)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        Me.TextBox1.WordWrap = False
        '
        'GroupBox1
        '
        Me.GroupBox1.AllowDrop = True
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Colors = New One_Clik.Bloom(-1) {}
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Customization = ""
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GroupBox1.Image = Nothing
        Me.GroupBox1.Location = New System.Drawing.Point(12, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.NoRounding = False
        Me.GroupBox1.Size = New System.Drawing.Size(205, 416)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Actions"
        Me.GroupBox1.Transparent = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Color = System.Drawing.Color.Empty
        Me.Button1.Colors = New One_Clik.Bloom(-1) {}
        Me.Button1.Customization = ""
        Me.Button1.EnableGlass = True
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Button1.Image = Nothing
        Me.Button1.Location = New System.Drawing.Point(6, 387)
        Me.Button1.Name = "Button1"
        Me.Button1.NoRounding = False
        Me.Button1.Size = New System.Drawing.Size(193, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Perform Action"
        Me.Button1.Transparent = False
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ListBox1.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Items.AddRange(New Object() {"Flash Kernel", "Flash Recovery", "Kernel Repack", "MultiKernel Repack", "RUU - Advance", "Logger", "DragNDrop", "Lock/Unlock", "Root", "ScreenShot", "Reboot Into...", "Erase Cache", "Options", "Help"})
        Me.ListBox1.Location = New System.Drawing.Point(6, 19)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(193, 95)
        Me.ListBox1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Colors = New One_Clik.Bloom(-1) {}
        Me.GroupBox4.Controls.Add(Me.Batt)
        Me.GroupBox4.Controls.Add(Me.Active)
        Me.GroupBox4.Controls.Add(Me.PhoneM)
        Me.GroupBox4.Customization = ""
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GroupBox4.Image = Nothing
        Me.GroupBox4.Location = New System.Drawing.Point(12, 34)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.NoRounding = False
        Me.GroupBox4.Size = New System.Drawing.Size(205, 70)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Phone"
        Me.GroupBox4.Transparent = False
        '
        'Batt
        '
        Me.Batt.BackColor = System.Drawing.Color.Transparent
        Me.Batt.ForeColor = System.Drawing.Color.White
        Me.Batt.Location = New System.Drawing.Point(108, 0)
        Me.Batt.Name = "Batt"
        Me.Batt.Size = New System.Drawing.Size(91, 22)
        Me.Batt.TabIndex = 2
        Me.Batt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Active
        '
        Me.Active.BackColor = System.Drawing.Color.Transparent
        Me.Active.ForeColor = System.Drawing.Color.ForestGreen
        Me.Active.Location = New System.Drawing.Point(3, 44)
        Me.Active.Name = "Active"
        Me.Active.Size = New System.Drawing.Size(193, 22)
        Me.Active.TabIndex = 1
        Me.Active.Text = "Phone Is Safe To Unplug"
        Me.Active.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PhoneM
        '
        Me.PhoneM.BackColor = System.Drawing.Color.Transparent
        Me.PhoneM.ForeColor = System.Drawing.Color.White
        Me.PhoneM.Location = New System.Drawing.Point(6, 22)
        Me.PhoneM.Name = "PhoneM"
        Me.PhoneM.Size = New System.Drawing.Size(190, 22)
        Me.PhoneM.TabIndex = 0
        Me.PhoneM.Text = "Not Connected"
        Me.PhoneM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Colors = New One_Clik.Bloom(-1) {}
        Me.GroupBox3.Controls.Add(Me.Stat)
        Me.GroupBox3.Customization = ""
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GroupBox3.Image = Nothing
        Me.GroupBox3.Location = New System.Drawing.Point(223, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.NoRounding = False
        Me.GroupBox3.Size = New System.Drawing.Size(425, 118)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Instructions"
        Me.GroupBox3.Transparent = False
        '
        'Stat
        '
        Me.Stat.BackColor = System.Drawing.Color.Transparent
        Me.Stat.ForeColor = System.Drawing.Color.White
        Me.Stat.Location = New System.Drawing.Point(8, 22)
        Me.Stat.Name = "Stat"
        Me.Stat.Size = New System.Drawing.Size(411, 89)
        Me.Stat.TabIndex = 0
        Me.Stat.Text = "Modules Extracted" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Booting Into Recovery" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pushing Modules" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Installing Modules" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bo" & _
    "oting Into Bootloader" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Flashing Kernel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Clearing Cache"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 540)
        Me.Controls.Add(Me.GhostTheme1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "One X One Click"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GhostTheme1.ResumeLayout(False)
        Me.GhostTheme1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PhoneStat As System.Windows.Forms.Timer
    Friend WithEvents GroupBox3 As One_Clik.GhostGroupBox
    Friend WithEvents Stat As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As One_Clik.GhostGroupBox
    Friend WithEvents Active As System.Windows.Forms.Label
    Friend WithEvents PhoneM As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As One_Clik.GhostGroupBox
    Friend WithEvents Button1 As One_Clik.GhostButton
    Friend WithEvents ListBox1 As One_Clik.Listbox
    Friend WithEvents GroupBox2 As One_Clik.GhostGroupBox
    Friend WithEvents Button3 As One_Clik.GhostButton
    Friend WithEvents Button2 As One_Clik.GhostButton
    Friend WithEvents TextBox1 As One_Clik.GhostTextBox
    Friend WithEvents XClose As System.Windows.Forms.Label
    Friend WithEvents Mini As System.Windows.Forms.Label
    Friend WithEvents GhostTheme1 As One_Clik.GhostTheme
    Friend WithEvents About As System.Windows.Forms.Label
    Friend WithEvents Help As System.Windows.Forms.Label
    Friend WithEvents OXOC As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RestoreTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StartupTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PhoneDetection As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Batt As System.Windows.Forms.Label



End Class
