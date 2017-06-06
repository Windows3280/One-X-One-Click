Imports System.Windows.Forms

Public Class Install2
    Public Shared hello As String
    Sub New(ByVal Title As String, ByVal MSG As String, Optional ByVal YES As String = "Yes", Optional ByVal No As String = "No")
        ' This call is required by the designer.
        InitializeComponent()
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.SizeGripStyle = Windows.Forms.SizeGripStyle.Hide
        Label1.Text &= MSG
        GhostTheme1.Text = Title
        Me.Text = Title
        GhostButton3.Text = YES
        GhostButton4.Text = No

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GhostButton3.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GhostButton4.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog2_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        GhostButton3.Select()
    End Sub

    Private Sub GhostButton1_KeyPress(sender As Object, e As KeyEventArgs) Handles GhostButton3.KeyDown


        If e.KeyData = Keys.Enter Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        ElseIf e.KeyData = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        If RadioButton1.Checked Then
            TextBox1.Visible = True
            Label2.Visible = True
            ' 304, 200
            Me.Size = New System.Drawing.Size(304, 200)
        Else
            TextBox1.Visible = False
            Label2.Visible = False
            Me.Size = New System.Drawing.Size(304, 157)
            TextBox1.Text = Nothing
        End If
        GhostButton3.Enabled = True
    End Sub




 
    
    

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        Dim file As OpenFileDialog
        file = Form1.OpenFileDialog1
        file.DefaultExt = ".zip"
        file.Filter = "Zip Module files (*.zip)|*.zip"
        Me.Visible = False

        Try
            Dim thread As Threading.Thread = New Threading.Thread(AddressOf dd)
            thread.SetApartmentState(Threading.ApartmentState.STA)
            thread.Start(file)
            thread.Join()
        Catch ex As Exception
            MsgBox(ex)
        End Try

        If file.FileName <> "OpenFileDialog1" Then
            TextBox1.Text = file.FileName
            Modules = file.FileName
        End If
        Me.Visible = True
    End Sub
    Private Sub dd(ByVal ff As OpenFileDialog)

        ff.ShowDialog()
    End Sub
End Class
