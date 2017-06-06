Imports System.Windows.Forms

Public Class Dialog2
    Sub New(ByVal MSG As String)
        ' This call is required by the designer.
        InitializeComponent()

        Dim gr As Graphics = Me.CreateGraphics()
           Me.Size = New System.Drawing.Size(Me.Size.Width, gr.MeasureString(MSG, Me.Font).Height + 36 + 32 + 32 + 5)
            Label1.Size = New Drawing.Size(Label1.Size.Width, gr.MeasureString(MSG, Me.Font).Height + 36)

        Label1.Text = MSG
        'Me.AcceptButton = GhostButton1
        ' Add any initialization after the InitializeComponent() call.
     End Sub



    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GhostButton1.Click
        Me.Close()
    End Sub

    Private Sub Dialog2_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        GhostButton1.Select()
    End Sub

    Private Sub GhostButton1_KeyPress(sender As Object, e As KeyEventArgs) Handles GhostButton1.KeyDown, GhostTheme1.KeyDown, Me.KeyDown

        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Escape Then
            Me.Close()
        End If

    End Sub
End Class
