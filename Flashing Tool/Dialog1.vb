Imports System.Windows.Forms

Public Class Dialog1

    Sub New(ByVal Title As String, ByVal MSG As String, Optional ByVal YES As String = "Yes", Optional ByVal No As String = "No")
        ' This call is required by the designer.
        InitializeComponent()
        Dim gr As Graphics = Me.CreateGraphics()
        Dim wth As Integer = gr.MeasureString(MSG, Me.Label2.Font).Width

        If wth < (75 * 2) + 50 Then
            Me.Size = New System.Drawing.Size((75 * 2) + 50 + 12 + 12, gr.MeasureString(MSG, Me.Font).Height + 36 + 32 + 32 + 5)
            Label2.Size = New Drawing.Size((75 * 2) + 50, gr.MeasureString(MSG, Me.Font).Height + 36)
        Else
            Me.Size = New System.Drawing.Size(wth + 12 + 12, gr.MeasureString(MSG, Me.Font).Height + 36 + 32 + 32 + 5)
            Label2.Size = New Drawing.Size(wth, gr.MeasureString(MSG, Me.Font).Height + 36)
        End If

        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.SizeGripStyle = Windows.Forms.SizeGripStyle.Hide
        Label2.Text = MSG
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


       If e.KeyData = Keys.Escape Then
            Me.DialogResult = 3
            Me.Close()
        End If

    End Sub

End Class
