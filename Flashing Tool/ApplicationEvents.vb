Imports System.IO
Imports System.Text

Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

            MsgBox("An Error Has Occurred," & vbNewLine & "Please Read the log file and post it on the forum to recieve help", MsgBoxStyle.Critical)
            If My.Computer.FileSystem.FileExists(Application.Info.DirectoryPath + "\crash\") = False Then
                My.Computer.FileSystem.CreateDirectory(Application.Info.DirectoryPath + "\crash\")
            End If
            Dim strw2 As New StreamWriter(Application.Info.DirectoryPath + "\crash\crash." + Date.Now.Date.ToShortDateString.Replace("/", ".") + ".txt", True, Encoding.UTF8)
            strw2.WriteLine(e.Exception.ToString)
            strw2.WriteLine(e.Exception.StackTrace.ToString)
            strw2.Close()

        End Sub
    End Class


End Namespace

