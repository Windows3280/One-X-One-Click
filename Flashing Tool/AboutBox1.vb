Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        Me.LabelProductName.Text = Form1.Text
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub
    Private Sub GhostButton1_KeyPress(sender As Object, e As KeyEventArgs) Handles OKButton.KeyDown, GhostTheme1.KeyDown, Me.KeyDown
       
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Escape Then
            Me.Close()
        End If

    End Sub
  
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Process.Start("http://forum.xda-developers.com/donatetome.php?u=618483")
    End Sub
End Class
