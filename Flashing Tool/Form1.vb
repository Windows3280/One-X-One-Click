Imports System.IO
Imports System.Text
Imports ICSharpCode.SharpZipLib.Zip
Imports System.Threading
Imports System.Runtime.InteropServices

Public Class Form1
    Private CB(-1) As ComboBox
    Private LB(-1) As Label
    Private CheckB(-1) As Checkbox
    Private RD(-1) As Radiobutton
    Private NUD(-1) As NumericUpDown
    Private Found As Boolean = False
    Private hides As Boolean = False



    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
       installing()
        ClearTMP()
        Stat.Text = ""
        Me.Text = GhostTheme1.Text
        OXOC.Text = Text
        Me.Visible = False
        OXOC.Visible = True
        If My.Computer.FileSystem.FileExists(System.Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\OXOC.lnk") Then
            StartupTSMI.Checked = True
        End If

#If DEBUG Then
        DragNDropD()
#End If

    End Sub
    Private Sub installing()
        Dim Arg As String = Command().Replace("""", "")
        If Arg.ToLower.EndsWith(".apk") Then
            hides = True
            OXOC.Visible = True
            RemoveHandler OXOC.MouseDoubleClick, AddressOf OXOC_MouseClick
            OXOC.ContextMenuStrip = Nothing
            Dim diag As New Install("Install APK", "Do You Want To Install " & Arg.Split("\")(Arg.Split("\").Length - 1) & " To Your Phone??")
            diag.ShowDialog()
            If diag.DialogResult = Windows.Forms.DialogResult.OK Then
                InstallAPK(Arg)
            End If
            Try : diag.Dispose() : Catch ex As Exception : End Try
            GoTo killall
        ElseIf Arg.ToLower.EndsWith(".img") Then
            hides = True
            OXOC.Visible = True
            RemoveHandler OXOC.MouseDoubleClick, AddressOf OXOC_MouseClick
            OXOC.ContextMenuStrip = Nothing
            Dim diag As New Install2("Install IMG", "Do You Want To Flash " & Arg.Split("\")(Arg.Split("\").Length - 1) & " To Your Phone??")
            diag.ShowDialog()
            If diag.DialogResult = Windows.Forms.DialogResult.OK Then
                FlashKernelDialog(Arg, diag.Modules)
            End If
            Try : diag.Dispose() : Catch ex As Exception : End Try
            GoTo killall
        End If

        Exit Sub
killall:
        Try : Me.Dispose() : Catch ex As Exception : End Try
        Try : Close() : Catch ex As Exception : End Try
        Try : Application.Exit() : Catch ex As Exception : End Try
        Try : Process.GetCurrentProcess.Kill() : Catch ex As Exception : End Try
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Command.Contains("startup") Then
            Visible = False
        End If

    End Sub



    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

        For Each C In {RD, CheckB, LB, CB, NUD}
            For Each C2 In C
                Controls.Remove(C2)
                C2.Dispose()
            Next
        Next

skipafew:
        ReDim CB(-1) : ReDim LB(-1) : ReDim CheckB(-1) : ReDim RD(-1) : ReDim NUD(-1)

        If ListBox1.SelectedItem = "Flash Kernel" Then
            Kernel()
        ElseIf ListBox1.SelectedItem = "Flash Recovery" Then
            Recovery()
        ElseIf ListBox1.SelectedItem = "Help" Then
            HelpD()
        ElseIf ListBox1.SelectedItem = "Kernel Repack" Then
            KRepackD()
        ElseIf ListBox1.SelectedItem = "MultiKernel Repack" Then
            MultiKRepackD()
        ElseIf ListBox1.SelectedItem = "RUU - Advance" Then
            RUU()
        ElseIf ListBox1.SelectedItem = "Root" Then
            RootD()
        ElseIf ListBox1.SelectedItem = "Erase Cache" Then
            ECD()
        ElseIf ListBox1.SelectedItem = "Reboot Into..." Then
            RebootD()
        ElseIf ListBox1.SelectedItem = "Lock/Unlock" Then
            LockUnLockD()
        ElseIf ListBox1.SelectedItem = "Options" Then
            Options()
        ElseIf ListBox1.SelectedItem = "Logger" Then
            LoggerD()
        ElseIf ListBox1.SelectedItem = "ScreenShot" Then
            ScreenShotD()
        ElseIf ListBox1.SelectedItem = "DragNDrop" Then
            DragNDropD()
        End If
        For Each CoB As ComboBox In CB
            AddHandler CoB.DropDown, AddressOf ComboBox1_DropDown
        Next
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim ok As Date = Date.Now
        Active.Text = "Dont Unplug Your Phone"
        Active.ForeColor = Color.Red
        Button1.Enabled = False : ListBox1.Enabled = False
        For Each CS As ComboBox In CB
            CS.Enabled = False
        Next
        For Each CS As Radiobutton In RD
            If CS.Checked = False Then
                CS.Enabled = False
            End If
        Next
        Stat.Text = ""
        If ListBox1.SelectedItem = "Flash Kernel" Then : FlashKernel()
        ElseIf ListBox1.SelectedItem = "Flash Recovery" Then : FlashRecoveries()
        ElseIf ListBox1.SelectedItem = "Reboot Into..." Then : Completion(CB(0).SelectedItem)
        ElseIf ListBox1.SelectedItem = "Kernel Repack" Then : KRepack()
        ElseIf ListBox1.SelectedItem = "MultiKernel Repack" Then : MultiKRepack()
        ElseIf ListBox1.SelectedItem = "Help" Then : StartS("apps\adb.exe", {"devices"})
        ElseIf ListBox1.SelectedItem = "Root" Then : Root()
        ElseIf ListBox1.SelectedItem = "RUU - Advance" Then : FlashRUU()
        ElseIf ListBox1.SelectedItem = "Erase Cache" Then : EC()
        ElseIf ListBox1.SelectedItem = "Lock/Unlock" Then
            Dim Warr As Dialog1
            If RD(0).Checked Then
                Warr = New Dialog1("Warrning", "Locking Your Phone Would Cause You The Loss Of Your Custom ROM And Recovery." & vbNewLine & "Are You Sure You Want To Continue??", "Yes", "No")
                Warr.ShowDialog()
                If Warr.DialogResult = 1 Then Lock()
            Else
                Warr = New Dialog1("Warrning", "Unlocking Your Phone Would Cause You To Loss All Your Data." & vbNewLine & "Are You Sure You Want To Continue??", "Yes", "No")
                Warr.ShowDialog()
                If Warr.DialogResult = 1 Then Unlock()
            End If
        ElseIf ListBox1.SelectedItem = "Logger" Then : Logger()
        ElseIf ListBox1.SelectedItem = "ScreenShot" Then : ScreenShot()
        End If


        For Each CS As ComboBox In CB
            CS.Enabled = True
        Next
        For Each CS As Checkbox In CheckB
            CS.Enabled = True
        Next
        For Each CS As Radiobutton In RD
            CS.Enabled = True
        Next
        Button1.Enabled = True : ListBox1.Enabled = True
        Dim ok2 As TimeSpan = Date.Now.Subtract(ok)
        Active.Text = "Phone Is Safe To Unplug"
        Active.ForeColor = Color.ForestGreen
        TextBox1.Text &= "Process Took " & ok2.Minutes & " Minutes And " & ok2.Seconds & " Seconds" & vbNewLine
    End Sub

    Private Sub ExtractArchive1(ByVal zipFilename As String, ByVal ExtractDir As String)
        Dim Redo As Integer = 1
        Dim MyZipInputStream As ZipInputStream
        Dim MyFileStream As FileStream = Nothing
        MyZipInputStream = New ZipInputStream(New FileStream(zipFilename, FileMode.Open, FileAccess.Read))
        Dim MyZipEntry As ZipEntry = MyZipInputStream.GetNextEntry
        Dim asa As String = MyZipEntry.VersionMadeBy
        Directory.CreateDirectory(ExtractDir)
        While Not MyZipEntry Is Nothing
            If (MyZipEntry.IsDirectory) Then
                Directory.CreateDirectory(ExtractDir & "\" & MyZipEntry.Name)
            Else
                If Not Directory.Exists(ExtractDir & "\" & Path.GetDirectoryName(MyZipEntry.Name)) Then
                    Directory.CreateDirectory(ExtractDir & "\" & Path.GetDirectoryName(MyZipEntry.Name))
                End If
                If MyZipEntry.Name.ToLower.EndsWith(".DS_Store".ToLower) Then
                    GoTo CONT
                End If
                MyFileStream = New FileStream(ExtractDir & "\" & _
                  MyZipEntry.Name, FileMode.OpenOrCreate, FileAccess.Write)
                Dim count As Integer
                Dim buffer(4096) As Byte
                count = MyZipInputStream.Read(buffer, 0, 4096)
                While count > 0
                    MyFileStream.Write(buffer, 0, count)
                    count = MyZipInputStream.Read(buffer, 0, 4096)
                End While
                MyFileStream.Close()
            End If
CONT:
            Try

                MyZipEntry = MyZipInputStream.GetNextEntry
            Catch ex As Exception
                MyZipEntry = Nothing
            End Try
        End While
        If Not (MyZipInputStream Is Nothing) Then MyZipInputStream.Close()
        If Not (MyFileStream Is Nothing) Then MyFileStream.Close()
    End Sub
    Private Sub ExtractArchive(ByVal zipFilename As String, ByVal ExtractDir As String, ByVal name As String)
        Dim Redo As Integer = 1
        Dim MyZipInputStream As ZipInputStream
        Dim MyFileStream As FileStream = Nothing
        MyZipInputStream = New ZipInputStream(New FileStream(zipFilename, FileMode.Open, FileAccess.Read))
        Dim MyZipEntry As ZipEntry = MyZipInputStream.GetNextEntry
        Directory.CreateDirectory(ExtractDir)
        While Not MyZipEntry Is Nothing
            If (MyZipEntry.IsDirectory) Then
                Directory.CreateDirectory(ExtractDir & "\" & MyZipEntry.Name)
            Else
                If Not Directory.Exists(ExtractDir & "\" & Path.GetDirectoryName(MyZipEntry.Name)) Then
                    Directory.CreateDirectory(ExtractDir & "\" & Path.GetDirectoryName(MyZipEntry.Name))
                End If
                If MyZipEntry.Name.ToLower.EndsWith(".DS_Store".ToLower) Then
                    GoTo CONT
                End If
                If MyZipEntry.Name.ToLower.Contains(name) Then
                    MyFileStream = New FileStream(ExtractDir & "\" & _
                    MyZipEntry.Name.Split("/")(MyZipEntry.Name.Split("/").Length - 1), FileMode.OpenOrCreate, FileAccess.Write)
                Else
                    MyFileStream = New FileStream(ExtractDir & "\" & _
                    MyZipEntry.Name, FileMode.OpenOrCreate, FileAccess.Write)

                End If

                If MyZipEntry.Name.ToLower.Contains(name) Then

                    If MyZipEntry.Name.ToLower.Contains(name) Then
                    End If


                    Dim count As Integer
                    Dim buffer(4096) As Byte
                    count = MyZipInputStream.Read(buffer, 0, 4096)
                    While count > 0
                        MyFileStream.Write(buffer, 0, count)
                        count = MyZipInputStream.Read(buffer, 0, 4096)
                    End While
                End If

                MyFileStream.Close()
            End If
CONT:
            Try

                MyZipEntry = MyZipInputStream.GetNextEntry
            Catch ex As Exception
                MyZipEntry = Nothing
            End Try
        End While
        If Not (MyZipInputStream Is Nothing) Then MyZipInputStream.Close()
        If Not (MyFileStream Is Nothing) Then MyFileStream.Close()
    End Sub
    Private Function FindKernelImg(ByVal zipFilename As String) As Array
        Dim Redo As Integer = 1
        Dim MyZipInputStream As ZipInputStream
        Dim IMGs As ArrayList = New ArrayList
        MyZipInputStream = New ZipInputStream(New FileStream(Application.StartupPath + "\modules\" & zipFilename, FileMode.Open, FileAccess.Read))
        Dim MyZipEntry As ZipEntry = MyZipInputStream.GetNextEntry
        While Not MyZipEntry Is Nothing

            If MyZipEntry.Name.ToLower.Contains(".img") Then
                IMGs.Add("ZIP:" & zipFilename & ":" & MyZipEntry.Name)
            End If
            Try
                MyZipEntry = MyZipInputStream.GetNextEntry
            Catch ex As Exception
                MyZipEntry = Nothing
            End Try
        End While
        If Not (MyZipInputStream Is Nothing) Then MyZipInputStream.Close()
        Return IMGs.ToArray
    End Function
    Private Function ExtractKernelImg(ByVal data As String) As Boolean
        Dim zipFilename As String = data.Split(":")(1)
        Dim kernelFilename As String = data.Split(":")(2)
        Dim Redo As Integer = 1
        Dim MyZipInputStream As ZipInputStream
        Dim MyFileStream As FileStream
        MyZipInputStream = New ZipInputStream(New FileStream(Application.StartupPath + "\modules\" & zipFilename, FileMode.Open, FileAccess.Read))
        Dim MyZipEntry As ZipEntry = MyZipInputStream.GetNextEntry
        If (My.Computer.FileSystem.DirectoryExists(Application.StartupPath + "\TMP") = False) Then
            Dim dir As DirectoryInfo = Directory.CreateDirectory(Application.StartupPath + "\TMP")
            dir.Attributes = FileAttributes.Hidden
        End If
        While Not MyZipEntry Is Nothing

            If MyZipEntry.Name.ToLower = kernelFilename.ToLower Then
                MyFileStream = New FileStream(Application.StartupPath + "\TMP\" & _
                zipFilename.Replace(".zip", "") & "." & MyZipEntry.Name.Split("/")(MyZipEntry.Name.Split("/").Length - 1), FileMode.OpenOrCreate, FileAccess.Write)
                Dim count As Integer
                Dim buffer(4096) As Byte
                count = MyZipInputStream.Read(buffer, 0, 4096)
                While count > 0
                    MyFileStream.Write(buffer, 0, count)
                    count = MyZipInputStream.Read(buffer, 0, 4096)
                End While
                MyZipInputStream.Close()
                MyFileStream.Close()
                Return True
            End If
            Try
                MyZipEntry = MyZipInputStream.GetNextEntry
            Catch ex As Exception
                MyZipEntry = Nothing
            End Try
        End While
        If Not (MyZipInputStream Is Nothing) Then MyZipInputStream.Close()
        Return False
    End Function

#Region "Actions"

    Private Sub FlashKernel()
        Dim Combobox1 As ComboBox = CB(0)
        Dim Combobox2 As ComboBox = CB(1)
        Dim Combobox4 As ComboBox = CB(2)
        '  If Combobox1.SelectedIndex = -1 Then
        '       MSG("Invalid Kernel Choice!!")
        '       Exit Sub
        '  End If
        Dim modules As Boolean = True
        Dim tempPath As String = System.IO.Path.GetTempPath & "OneXTemp\tkernel\"
        tempPath = tempPath.ToLower
        If Combobox2.SelectedIndex <> -1 Then
            If Combobox2.SelectedItem.ToString <> "None" And Combobox2.SelectedItem.ToString <> Nothing Then
                Dim zipPath As String = Application.StartupPath & "\modules\" & Combobox2.SelectedItem.ToString ''''Combobox2.SelectedItem.ToString
                If (Not System.IO.Directory.Exists(tempPath)) Then
                    System.IO.Directory.CreateDirectory(tempPath)
                Else
                    System.IO.Directory.Delete(tempPath, True)
                    Delay(1)
                    System.IO.Directory.CreateDirectory(tempPath)
                End If
                ExtractArchive(zipPath, tempPath, "binary")
                Delay(1)
                If (System.IO.File.Exists(tempPath & "update-binary")) Then
                    modules = True
                    MSG("Modules Verified")
                Else
                    System.IO.Directory.Delete(tempPath, True)
                    MSG("Invalid Modules")
                    MSG("Operation Terminated")
                    Exit Sub
                End If
            End If
        End If
        ''ADB\Fastboot
        Dim ADF As String = AFI()

        Dim Fastboot As Boolean = False
        If ADF.Contains("ADB") Then ''''''''''''ADB\Recovery
            If Combobox2.SelectedIndex <> -1 Then
                If Combobox2.SelectedItem.ToString <> "None" And Combobox2.SelectedItem.ToString <> Nothing Then
                    If ADF = "ADB" Then
                        MSG("Booting Into Recovery")
                        StartR("apps\adb.exe", {"Reboot", "recovery"})
                    Else
                        GoTo pmodules
                    End If
                    ''Flash Modules
                    Do Until ADF = "ADB - Recovery"
                        ADF = AFI()
                    Loop
pmodules:
                    MSG("Pushing Modules")
                    StartS("apps\adb.exe", {"push", "modules\" & Combobox2.SelectedItem.ToString, "/cache/Modules/" & Combobox2.SelectedItem.ToString}, 150)
                    StartR("apps\adb.exe", {"push", tempPath & "update-binary", "/cache/Modules/UB"})
                    StartR("apps\adb.exe", {"shell", "chmod", "0755", "/cache/Modules/UB"}, 60, 0)
                    MSG("Installing Modules")
                    StartS("apps\adb.exe", {"shell", "/cache/Modules/UB", "3", "Thunder07", "/cache/Modules/" & Combobox2.SelectedItem.ToString}, 60, 0)
                    StartR("apps\adb.exe", {"shell", "rm", "-rf", "/cache/Modules/"}, 60, 0)
                    MSG("Flashing Modules Complete")
                End If
            End If
            If Combobox1.SelectedIndex <> -1 Then
                If Combobox1.SelectedItem.ToString <> "None" And Combobox1.SelectedItem.ToString <> Nothing Then
                    MSG("Booting Into Bootloader")
                    StartR("apps\adb.exe", {"Reboot-bootloader"})
                    GoTo FB
                End If
            End If



        ElseIf ADF = "Fastboot" Then ''''''''''''Fastboot
            Fastboot = True
FB:
            If Combobox1.SelectedIndex <> -1 Then
                If Combobox1.SelectedItem.ToString <> "None" And Combobox1.SelectedItem.ToString <> Nothing Then
                    Do Until AFI() = "Fastboot"
                    Loop
                    MSG("Flashing Kernel")
                    Dim KernelLoc As String = Combobox1.SelectedItem.ToString
                    If Combobox1.SelectedItem.StartsWith("ZIP:") Then
                        ExtractKernelImg(Combobox1.SelectedItem)
                        KernelLoc = "TMP\" & Combobox1.SelectedItem.ToString.Split(":")(1).Replace(".zip", "") & "." & Combobox1.SelectedItem.ToString.Split(":")(2)
                    End If
                    StartS("apps\fastboot.exe", {"flash", "boot", KernelLoc})
                    MSG("Clearing Cache")
                    StartS("apps\fastboot.exe", {"erase", "cache"})
                    MSG("Flashing Kernel Complete")
                End If
            End If





        Else ''''''''''''Not Connected
            MSG("The Phone is Not Connected!!!")

            Exit Sub
        End If
        Completion(Combobox4.SelectedItem)
        ClearTMP()
        If (System.IO.Directory.Exists(tempPath)) Then
            System.IO.Directory.Delete(tempPath, True)
        End If


    End Sub
    Private Sub InstallAPK(ByVal APK As String)
        MSG("Installing APK")
        StartS("apps\adb.exe", {"install", APK})
        MSG("APK Installed")
    End Sub
    Private Sub FlashKernelDialog(ByVal IMG As String, ByVal Modules As String)


        Dim tempPath As String = System.IO.Path.GetTempPath & "OneXTemp\tkernel\"
        tempPath = tempPath.ToLower
        If Modules <> "None" And Modules <> Nothing Then
            Dim zipPath As String = Modules ''''Combobox2.SelectedItem.ToString
            If (Not System.IO.Directory.Exists(tempPath)) Then
                System.IO.Directory.CreateDirectory(tempPath)
            Else
                System.IO.Directory.Delete(tempPath, True)
                Delay(1)
                System.IO.Directory.CreateDirectory(tempPath)
            End If
            ExtractArchive(Application.StartupPath + zipPath, tempPath, "binary")
            Delay(1)
            If (System.IO.File.Exists(tempPath & "update-binary")) Then
                Modules = True
                MSG("Modules Verified")
            Else
                System.IO.Directory.Delete(tempPath, True)
                MSG("Invalid Modules")
                MSG("Operation Terminated")
                Exit Sub
            End If
        Else
            Dim ADF2 As String = AFI()
            If ADF2.Contains("ADB") Then
                MSG("Booting into Bootloader")
                StartR("apps\adb.exe", {"Reboot-bootloader"})
            ElseIf ADF2 = "Fastboot" Then
                MSG("Booting into Bootloader")
                StartR("apps\fastboot.exe", {"Reboot-bootloader"})
            End If
            GoTo FB
        End If

        ''ADB\Fastboot
        Dim ADF As String = AFI()
        Dim Fastboot As Boolean = False
        If ADF.Contains("ADB") Then ''''''''''''ADB\Recovery
            If Modules <> "None" And Modules <> Nothing Then
                If ADF = "ADB" Then
                    MSG("Booting Into Recovery")
                    StartR("apps\adb.exe", {"Reboot", "recovery"})
                Else
                    GoTo pmodules
                End If
                ''Flash Modules
                Do Until ADF = "ADB - Recovery"
                    ADF = AFI()
                Loop
pmodules:
                MSG("Pushing Modules")
                StartS("apps\adb.exe", {"push", Modules, "/cache/Modules/" & Modules.Split("\")(Modules.Split("\").Length - 1)}, 150)
                StartR("apps\adb.exe", {"push", tempPath & "update-binary", "/cache/Modules/UB"})
                StartR("apps\adb.exe", {"shell", "chmod", "0755", "/cache/Modules/UB"}, 60, 0)
                MSG("Installing Modules")
                StartS("apps\adb.exe", {"shell", "/cache/Modules/UB", "3", "Thunder07", "/cache/Modules/" & Modules.Split("\")(Modules.Split("\").Length - 1)}, 60, 0)
                StartR("apps\adb.exe", {"shell", "rm", "-rf", "/cache/Modules/"}, 60, 0)

                MSG("Booting Into Bootloader")
                StartR("apps\adb.exe", {"Reboot-bootloader"})
                GoTo FB

            ElseIf ADF = "Fastboot" Then ''''''''''''Fastboot
                Fastboot = True
FB:
                Do Until AFI() = "Fastboot"
                Loop
                MSG("Flashing IMG")
                StartS("apps\fastboot.exe", {"flash", "boot", IMG})
                MSG("Clearing Cache")
                StartS("apps\fastboot.exe", {"erase", "cache"})


                Completion("Reboot")
                MSG("Flashing Complete")
            Else ''''''''''''Not Connected
                MSG("The Phone is Not Connected!!!")
            End If
        End If

        Try
            If (System.IO.Directory.Exists(tempPath)) Then
                System.IO.Directory.Delete(tempPath, True)
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub FlashRecoveries()
        Dim Combobox1 As ComboBox = CB(0)
        Dim Combobox4 As ComboBox = CB(1)
        If Combobox1.SelectedIndex = -1 Then
            MSG("Invalid Recovery Choice!!")
            Exit Sub
        End If
        Dim ADF As String = AFI()
        If ADF.Contains("ADB") Then ''''''''''''ADB

            MSG("Booting Into Bootloader")
            StartR("apps\adb.exe", {"Reboot-bootloader"})
            GoTo FB
        ElseIf ADF = "Fastboot" Then ''''''''''''Fastboot
FB:
            Do Until AFI() = "Fastboot"
                Delay(5)
            Loop
            Delay(5)
            MSG("Flashing Recovery")
            StartS("apps\fastboot.exe", {"flash", "recovery", "recoveries\" & Combobox1.SelectedItem.ToString})
            MSG("Clearing Cache")
            StartS("apps\fastboot.exe", {"erase", "cache"})

            Completion(Combobox4.SelectedItem)
            MSG("Flashing Complete")
        Else ''''''''''''Not Connected
            MSG("The Phone is Not Connected!!!")
            Exit Sub
        End If

    End Sub
    Private Sub KRepack()
        Dim CheckBox2 As Checkbox = CheckB(1)
        Dim CheckBox1 As Checkbox = CheckB(0)
        Dim ComboBox4 As ComboBox = CB(3)
        Dim ComboBox3 As ComboBox = CB(2)
        Dim ComboBox2 As ComboBox = CB(1)
        Dim ComboBox1 As ComboBox = CB(0)
        If ComboBox1.SelectedIndex = -1 Or ComboBox2.SelectedIndex = -1 Then
            If ComboBox1.SelectedItem = Nothing Or ComboBox2.SelectedItem = Nothing Then
                Stat.Text &= "Invalid Kernel Selection"
                Exit Sub
            End If
        End If
        Dim KernelLoc As String = "kernels\" & ComboBox1.SelectedItem.ToString
        Dim KernelLocOut As String = ComboBox1.SelectedItem.ToString
        If ComboBox1.SelectedItem.StartsWith("ZIP:") Then
            ExtractKernelImg(ComboBox1.SelectedItem)
            KernelLoc = "TMP\" & ComboBox1.SelectedItem.ToString.Split(":")(1).Replace(".zip", "") & "." & ComboBox1.SelectedItem.ToString.Split(":")(2)
            KernelLocOut = ComboBox1.SelectedItem.ToString.Split(":")(1).Replace(".zip", "") & ".img"

        End If
        Dim KernelLoc2 As String = "kernels\" & ComboBox2.SelectedItem.ToString
        Dim KernelLocOut2 As String = ComboBox2.SelectedItem.ToString
        If ComboBox2.SelectedItem.StartsWith("ZIP:") Then
            ExtractKernelImg(ComboBox2.SelectedItem)
            KernelLoc2 = "TMP\" & ComboBox2.SelectedItem.ToString.Split(":")(1).Replace(".zip", "") & "." & ComboBox2.SelectedItem.ToString.Split(":")(2)
            KernelLocOut2 = ComboBox2.SelectedItem.ToString.Split(":")(1).Replace(".zip", "") & ".img"
        End If
        If RD(0).Checked Then



            Dim modules As Boolean = True
            Dim ADF As String = AFI()
            Dim Fastboot As Boolean = False
            If ADF.Contains("ADB") Then ''''''''''''ADB\Recovery
                If ADF = "ADB - Recovery" Then
                    StartR("apps\adb.exe", {"shell", "mount", "/sdcard"})
                End If
                ''''Repack
                MSG("Repacking")
                StartS("apps\adb.exe", {"push", "apps\ramdisk", "/cache/tools/"})
                TextBox1.Text &= "[" & Date.Now & "] Pushing Kernel " & StartR("apps\adb.exe", {"push", KernelLoc, "/cache/tools/kernel_img/boot.img"})
                TextBox1.Text &= "[" & Date.Now & "] Pushing RamDisk" & StartR("apps\adb.exe", {"push", KernelLoc2, "/cache/tools/ramdisk_img/boot.img"})
                TextBox1.Text &= "[" & Date.Now & "] Executing Script " & StartR("apps\adb.exe", {"shell", "sh ./cache/tools/mkbootimg.sh"}, 60, 0)

                If CheckBox2.Checked Then
                    If ADF = "ADB - Recovery" Then
                        StartR("apps\adb.exe", {"shell", "mount", "/sdcard"})
                    End If
                    Stat.Text &= "Pulling Repacked Kernel" & vbNewLine
                    TextBox1.Text &= "[" & Date.Now & "]" & "Pulling Repacked Kernel " & _
                    StartR("apps\adb.exe", {"pull", "/sdcard/Repacked/Repackedboot.img", "Repacked/" & KernelLocOut.Replace(".img", "") & "." & KernelLocOut2}) & vbNewLine
                End If



ehe:
                ''''''modules
                If ComboBox3.SelectedIndex <> -1 Then
                    If ComboBox3.SelectedItem.ToString <> "None" And ComboBox3.SelectedItem.ToString <> Nothing Then
                        Dim tempPath As String = System.IO.Path.GetTempPath & "OneXTemp\tkernel\"
                        tempPath = tempPath.ToLower
                        Dim zipPath As String = Application.StartupPath & "\modules\" & ComboBox3.SelectedItem.ToString ''''Combobox2.SelectedItem.ToString
                        If (Not System.IO.Directory.Exists(tempPath)) Then
                            System.IO.Directory.CreateDirectory(tempPath)
                        Else
                            System.IO.Directory.Delete(tempPath, True)
                            Delay(3)
                            System.IO.Directory.CreateDirectory(tempPath)
                        End If
                        ExtractArchive(zipPath, tempPath, "binary")
                        Delay(3)
                        If (System.IO.File.Exists(tempPath & "update-binary")) Then
                            modules = True
                            MSG("Modules Verified")
                        Else
                            System.IO.Directory.Delete(tempPath, True)
                            MSG("Invalid Modules")
                            MSG("Operation Terminated")
                            Exit Sub
                        End If
                        ADF = AFI()
                        If ADF.Contains("ADB") Then
                            If ADF = "ADB" Then
                                StartR("apps\adb.exe", {"Reboot", "recovery"})
                            End If

                            ''Flash Modules
                            Do Until ADF = "ADB - Recovery"
                                ADF = AFI()
                            Loop
                            MSG("Pushing Modules")
                            StartS("apps\adb.exe", {"push", "modules\" & ComboBox3.SelectedItem.ToString, "/cache/Modules/" & ComboBox3.SelectedItem.ToString}, 150)
                            StartR("apps\adb.exe", {"push", tempPath & "update-binary", "/cache/Modules/UB"})
                            StartR("apps\adb.exe", {"shell", "chmod", "0755", "/cache/Modules/UB"})
                            MSG("Installing Modules")
                            StartS("apps\adb.exe", {"shell", "/cache/Modules/UB", "3", "Thunder07", "/cache/Modules/" & ComboBox3.SelectedItem.ToString})
                            StartR("apps\adb.exe", {"shell", "rm", "-rf", "/cache/Modules/"})
                            If (System.IO.Directory.Exists(tempPath)) Then
                                System.IO.Directory.Delete(tempPath, True)
                            End If
                        End If
                    End If
                End If
                '''''Checkboxes
                If CheckBox1.Checked Then
                    If ADF = "ADB - Recovery" Then
                        StartR("apps\adb.exe", {"shell", "mount", "/sdcard"})
                    End If
                    StartR("apps\adb.exe", {"pull", "/sdcard/Repacked/Repackedboot.img", "tmpkernel.img"})
                    StartR("apps\adb.exe", {"reboot-bootloader"})
                    Do Until AFI() = "Fastboot"
                    Loop
                    MSG("Flashing Repacked Kernel")
                    StartS("apps\fastboot.exe", {"flash", "boot", "tmpkernel.img"})
                    Try
                        My.Computer.FileSystem.DeleteFile("tmpkernel.img")
                    Catch ex As Exception
                    End Try
                End If

                Completion(ComboBox4.SelectedItem)

                MSG("Completed Proccess")
            Else ''''''''''''Not Connected
                MSG("The Phone is Not Connected!!!")
            End If

        Else
            MSG("Repacking")
            Dim ker As String = Application.StartupPath & "\" & KernelLoc
            Dim ramdi As String = Application.StartupPath & "\" & KernelLoc2
            Dim outp As String = Application.StartupPath & "\Repacked\" & KernelLocOut.Replace(".img", "") & "." & KernelLocOut2
            If langer.repack.Repack(ker, ramdi, outp, "thunder07") = False Then
                MSG("Repacking Failed Please Try Again!!")
                Exit Sub
            Else
                MSG("Completed Proccess")
            End If




            If CheckBox1.Checked Then

                Dim ADF As String = AFI()
                Dim Fastboot As Boolean = False
                If ADF.Contains("ADB") Then ''''''''''''ADB\Recovery
                    If ComboBox3.SelectedIndex <> -1 Then
                        If ComboBox3.SelectedItem.ToString <> "None" And ComboBox3.SelectedItem.ToString <> Nothing Then
                            If ADF = "ADB" Then
                                MSG("Booting Into Recovery")
                                StartR("apps\adb.exe", {"Reboot", "recovery"})
                            Else
                                GoTo pmodules
                            End If
                            ''Flash Modules
                            Do Until ADF = "ADB - Recovery"
                                ADF = AFI()
                            Loop
pmodules:
                            Dim tempPath As String = System.IO.Path.GetTempPath & "OneXTemp\tkernel\"
                            tempPath = tempPath.ToLower
                            MSG("Pushing Modules")
                            StartS("apps\adb.exe", {"push", "modules\" & ComboBox3.SelectedItem.ToString, "/cache/Modules/" & ComboBox3.SelectedItem.ToString}, 150)
                            StartR("apps\adb.exe", {"push", tempPath & "update-binary", "/cache/Modules/UB"})
                            StartR("apps\adb.exe", {"shell", "chmod", "0755", "/cache/Modules/UB"}, 60, 0)
                            MSG("Installing Modules")
                            StartS("apps\adb.exe", {"shell", "/cache/Modules/UB", "3", "Thunder07", "/cache/Modules/" & ComboBox3.SelectedItem.ToString}, 60, 0)
                            StartR("apps\adb.exe", {"shell", "rm", "-rf", "/cache/Modules/"}, 60, 0)
                            MSG("Flashing Modules Complete")
                        End If
                    End If
                    MSG("Booting Into Bootloader")
                    StartR("apps\adb.exe", {"Reboot-bootloader"})
                    GoTo FB

                ElseIf ADF = "Fastboot" Then ''''''''''''Fastboot
                    Fastboot = True
FB:
                    Do Until AFI() = "Fastboot"
                    Loop

                    MSG("Flashing Kernel")
                    StartS("apps\fastboot.exe", {"flash", "boot", outp})
                    MSG("Clearing Cache")
                    StartS("apps\fastboot.exe", {"erase", "cache"})

                    MSG("Flashing Kernel Complete")
                Else ''''''''''''Not Connected
                    MSG("The Phone is Not Connected!!!")
                    Exit Sub
                End If

            End If
            Completion(ComboBox4.SelectedItem)
            ClearTMP()
        End If

        'If (System.IO.Directory.Exists(tempPath)) Then

        '    System.IO.Directory.Delete(tempPath, True)
        'End If

    End Sub
    Private Sub MultiKRepack()
        Dim CheckBox1 As Checkbox = CheckB(0)
        Dim ComboBox4 As ComboBox = CB(2)
        Dim ComboBox2 As ComboBox = CB(1)
        Dim ComboBox1 As ComboBox = CB(0)
        If RD(0).Checked Then
            If ComboBox1.SelectedIndex = -1 Or ComboBox2.SelectedIndex = -1 Then
                If ComboBox1.SelectedItem = Nothing Or ComboBox2.SelectedItem = Nothing Then
                    Stat.Text &= "Invalid Kernel Selection"
                    Exit Sub
                End If
            End If
            Dim ADF As String = AFI()
            If ADF.Contains("ADB") Then
                If ADF = "ADB - Recovery" Then
                    StartR("apps\adb.exe", {"shell", "mount", "/sdcard"})
                End If
            ElseIf ADF = "fastboot" Then
                MSG("Please Boot Into Android OR Recovery And Try Again")
            Else
                MSG("Connect Your Phone And Try Again")
            End If


            Dim modules As Boolean = True
            Dim tempPath2 As String = System.IO.Path.GetTempPath & "OneXTemp\tools\"
            tempPath2 = tempPath2.ToLower
            Dim tempPath As String = Application.StartupPath & "\apps\RamDisk\"
            'Dim zipPath As String = Application.StartupPath & "\apps\RamDisk.zip" ''''Combobox2.SelectedItem.ToString
            If (Not System.IO.Directory.Exists(tempPath2)) Then
                System.IO.Directory.CreateDirectory(tempPath2)
            Else
                System.IO.Directory.Delete(tempPath2, True)
                Delay(3)
                System.IO.Directory.CreateDirectory(tempPath2)
            End If
            'ExtractArchive(zipPath, tempPath)
            'Delay(3)

            If (System.IO.Directory.Exists(tempPath)) Then
                modules = True
                MSG("Preparing RamDisk Tools Script")
                '''''Create Script
                Dim strw2 As New StreamWriter(tempPath2 + "mkbootimg2.sh", False, Encoding.UTF8)
                strw2.NewLine = vbLf
                strw2.WriteLine("#!/sbin/sh") : strw2.WriteLine("#!/sbin/sh") : strw2.WriteLine("cd /sdcard/") : strw2.WriteLine("mkdir Repacked") : strw2.WriteLine("cd /cache/tools/") : strw2.WriteLine("chmod 755 *")

                If ComboBox1.SelectedItem.ToString = "All" Then
                    If ComboBox2.SelectedItem.ToString = "All" Then
                        For Each Kernels In ComboBox1.Items
                            For Each RamDisk In ComboBox2.Items
                                RamDisk = RamDisk.ToString
                                Kernels = Kernels.ToString
                                If Kernels <> "All" And RamDisk <> "All" Then
                                    If RamDisk <> Kernels Then
                                        strw2.WriteLine("./unpackbootimg ./kernel_img/" & Kernels & " ./kernel_img/")
                                        strw2.WriteLine("./unpackbootimg ./ramdisk_img/" & RamDisk & " ./ramdisk_img/")
                                        strw2.WriteLine("rm -r /sdcard/repacked/" & Kernels.ToString.Replace(".img", ".") & RamDisk)
                                        strw2.WriteLine("echo echo Kernel:" & Kernels & " RamDisk:" & RamDisk & " >> ./" & Kernels.ToString.Replace(".img", ".") & RamDisk & ".sh")
                                        strw2.WriteLine("echo ./mkbootimg --kernel ./kernel_img/" & Kernels & "-zImage --ramdisk ./ramdisk_img/" & RamDisk & "-ramdisk.gz --cmdline \" & """" & "$(cat ./ramdisk_img/" & RamDisk & "-cmdline)\" & """" & " --base $(cat ./ramdisk_img/" & RamDisk & "-base) --output /sdcard/Repacked/" & Kernels.ToString.Replace(".img", ".") & RamDisk & " >> ./" & Kernels.ToString.Replace(".img", ".") & RamDisk & ".sh")
                                    End If
                                End If
                            Next
                        Next
                    Else
                        Dim RamDisk As String = ComboBox2.SelectedItem.ToString
                        For Each Kernels In ComboBox1.Items
                            Kernels = Kernels.ToString
                            If Kernels <> "All" Then
                                If RamDisk <> Kernels Then
                                    strw2.WriteLine("./unpackbootimg ./kernel_img/" & Kernels & " ./kernel_img/")
                                    strw2.WriteLine("./unpackbootimg ./ramdisk_img/" & RamDisk & " ./ramdisk_img/")
                                    strw2.WriteLine("rm -r /sdcard/repacked/" & Kernels.ToString.Replace(".img", ".") & RamDisk)
                                    strw2.WriteLine("echo echo Kernel:" & Kernels & " RamDisk:" & RamDisk & " >> ./" & Kernels.ToString.Replace(".img", ".") & RamDisk & ".sh")
                                    strw2.WriteLine("echo ./mkbootimg --kernel ./kernel_img/" & Kernels & "-zImage --ramdisk ./ramdisk_img/" & RamDisk & "-ramdisk.gz --cmdline \" & """" & "$(cat ./ramdisk_img/" & RamDisk & "-cmdline)\" & """" & " --base $(cat ./ramdisk_img/" & RamDisk & "-base) --output /sdcard/Repacked/" & Kernels.ToString.Replace(".img", ".") & RamDisk & " >> ./" & Kernels.ToString.Replace(".img", ".") & RamDisk & ".sh")
                                End If
                            End If
                        Next
                    End If
                Else
                    If ComboBox2.SelectedItem.ToString = "All" Then
                        Dim Kernels As String = ComboBox1.SelectedItem.ToString
                        For Each RamDisk In ComboBox2.Items
                            If RamDisk <> "All" Then
                                If RamDisk <> Kernels Then
                                    strw2.WriteLine("./unpackbootimg ./kernel_img/" & Kernels & " ./kernel_img/")
                                    strw2.WriteLine("./unpackbootimg ./ramdisk_img/" & RamDisk & " ./ramdisk_img/")
                                    strw2.WriteLine("rm -r /sdcard/repacked/" & Kernels.ToString.Replace(".img", ".") & RamDisk)
                                    strw2.WriteLine("echo echo Kernel:" & Kernels & " RamDisk:" & RamDisk & " >> ./" & Kernels.ToString.Replace(".img", ".") & RamDisk & ".sh")
                                    strw2.WriteLine("echo ./mkbootimg --kernel ./kernel_img/" & Kernels & "-zImage --ramdisk ./ramdisk_img/" & RamDisk & "-ramdisk.gz --cmdline \" & """" & "$(cat ./ramdisk_img/" & RamDisk & "-cmdline)\" & """" & " --base $(cat ./ramdisk_img/" & RamDisk & "-base) --output /sdcard/Repacked/" & Kernels.ToString.Replace(".img", ".") & RamDisk & " >> ./" & Kernels.ToString.Replace(".img", ".") & RamDisk & ".sh")
                                End If
                            End If
                        Next
                    Else
                        Dim Kernels As String = ComboBox1.SelectedItem.ToString
                        Dim RamDisk As String = ComboBox2.SelectedItem.ToString
                        If RamDisk <> Kernels Then
                            strw2.WriteLine("./unpackbootimg ./kernel_img/" & Kernels & " ./kernel_img/")
                            strw2.WriteLine("./unpackbootimg ./ramdisk_img/" & RamDisk & " ./ramdisk_img/")
                            strw2.WriteLine("rm -r /sdcard/repacked/" & Kernels.ToString.Replace(".img", ".") & RamDisk)
                            strw2.WriteLine("echo echo Kernel:" & Kernels & " RamDisk:" & RamDisk & " >> ./" & Kernels.ToString.Replace(".img", ".") & RamDisk & ".sh")
                            strw2.WriteLine("echo ./mkbootimg --kernel ./kernel_img/" & Kernels & "-zImage --ramdisk ./ramdisk_img/" & RamDisk & "-ramdisk.gz --cmdline \" & """" & "$(cat ./ramdisk_img/" & RamDisk & "-cmdline)\" & """" & " --base $(cat ./ramdisk_img/" & RamDisk & "-base) --output /sdcard/Repacked/" & Kernels.ToString.Replace(".img", ".") & RamDisk & " >> ./" & Kernels.ToString.Replace(".img", ".") & RamDisk & ".sh")
                        End If
                    End If
                End If
                strw2.WriteLine("chmod 755 *")
                If ComboBox1.SelectedItem.ToString = "All" Then
                    If ComboBox2.SelectedItem.ToString = "All" Then
                        For Each Kernels In ComboBox1.Items
                            For Each RamDisk In ComboBox2.Items
                                If Kernels <> "All" And RamDisk <> "All" Then
                                    If RamDisk <> Kernels Then
                                        strw2.WriteLine("./" & Kernels.ToString.Replace(".img", ".") & RamDisk & ".sh")
                                    End If
                                End If
                            Next
                        Next
                    Else
                        Dim RamDisk As String = ComboBox2.SelectedItem.ToString
                        For Each Kernels In ComboBox1.Items
                            Kernels = Kernels.ToString
                            If Kernels <> "All" Then
                                If RamDisk <> Kernels Then
                                    strw2.WriteLine("./" & Kernels.ToString.Replace(".img", ".") & RamDisk & ".sh")
                                End If
                            End If
                        Next
                    End If
                Else
                    If ComboBox2.SelectedItem.ToString = "All" Then
                        Dim Kernels As String = ComboBox1.SelectedItem.ToString
                        For Each RamDisk In ComboBox2.Items
                            If RamDisk <> "All" Then
                                If RamDisk <> Kernels Then
                                    strw2.WriteLine("./" & Kernels.ToString.Replace(".img", ".") & RamDisk & ".sh")
                                End If
                            End If
                        Next
                    Else
                        Dim Kernels As String = ComboBox1.SelectedItem.ToString
                        Dim RamDisk As String = ComboBox2.SelectedItem.ToString
                        If RamDisk <> Kernels Then
                            strw2.WriteLine("./" & Kernels.ToString.Replace(".img", ".") & RamDisk & ".sh")
                        End If
                    End If
                End If
                strw2.WriteLine("rm -r ../tools") : strw2.WriteLine("echo " & """" & "Complete" & """")
                strw2.Close()

            Else
                MSG("Invalid RamDisk")
                MSG("Operation Terminated")
                Exit Sub
            End If





            ''ADB\Fastboot
            ADF = AFI()
            Dim Fastboot As Boolean = False
            If ADF.Contains("ADB") Then ''''''''''''ADB\Recovery
                If ComboBox2.SelectedIndex <> -1 Then
                    If ComboBox2.SelectedItem.ToString <> "None" Or ComboBox2.SelectedItem.ToString <> Nothing Then
                        ''''Repack
                        MSG("Repacking")
                        StartS("apps\adb.exe", {"push", "apps\RamDisk", "/cache/tools/"})
                        StartR("apps\adb.exe", {"push", tempPath2 + "mkbootimg2.sh", "/cache/tools/mkbootimg.sh"})
                        If ComboBox1.SelectedItem.ToString = "All" Then
                            TextBox1.Text &= "[" & Date.Now & "] Pushing Kernels " & StartR("apps\adb.exe", {"push", "kernels", "/cache/tools/kernel_img/"}, 10 * 60)
                        Else
                            TextBox1.Text &= "[" & Date.Now & "] Pushing Kernels " & StartR("apps\adb.exe", {"push", "kernels/" & ComboBox1.SelectedItem.ToString, "/cache/tools/kernel_img/" & ComboBox1.SelectedItem.ToString}, 10 * 60)
                        End If
                        If ComboBox2.SelectedItem.ToString = "All" Then
                            TextBox1.Text &= "[" & Date.Now & "] Pushing RamDisk " & StartR("apps\adb.exe", {"push", "kernels", "/cache/tools/ramdisk_img/"}, 10 * 60)
                        Else
                            TextBox1.Text &= "[" & Date.Now & "] Pushing RamDisk " & StartR("apps\adb.exe", {"push", "kernels/" & ComboBox2.SelectedItem.ToString, "/cache/tools/ramdisk_img/" & ComboBox2.SelectedItem.ToString}, 10 * 60)
                        End If
                        StartR("apps\adb.exe", {"shell", "chmod 0775 /cache/tools/mkbootimg.sh"}, 60, 3)
                        TextBox1.Text &= "[" & Date.Now & "] Executing Script " & StartR("apps\adb.exe", {"shell", "sh ./cache/tools/mkbootimg.sh"}, 10 * 60)
                    End If
                    Try
                        Delay(1)
                        System.IO.File.Delete(tempPath2 + "mkbootimg2.sh")
                    Catch ex As Exception

                    End Try
                End If

                If CheckBox1.Checked Then
                    TextBox1.Text &= "[" & Date.Now & "] Pulling Kernels " & StartR("apps\adb.exe", {"pull", "/sdcard/Repacked/", "Repacked"}, 10 * 60)
                End If

                Completion(ComboBox4.SelectedItem)
                MSG("Repacking Completed")

            Else ''''''''''''Not Connected
                MSG("The Phone is Not Connected!!!")

            End If
        Else
langerrepack:
            If ComboBox1.SelectedItem.ToString = "All" Then
                If ComboBox2.SelectedItem.ToString = "All" Then
                    For Each Kernels In ComboBox1.Items
                        For Each RamDisk In ComboBox2.Items
                            If Kernels <> "All" And RamDisk <> "All" Then
                                If RamDisk <> Kernels Then
                                    If langer.repack.Repack(Application.StartupPath & "\kernels\" & Kernels, Application.StartupPath & "\kernels\" & RamDisk, Application.StartupPath & "\Repacked\" & Kernels.Replace(".img", "") & "." & RamDisk.ToString, "thunder07") Then
                                        TextBox1.Text &= "Repacking Kernel:" & Kernels & " RamDisk:" & RamDisk & " Succeed" & vbNewLine
                                    Else
                                        TextBox1.Text &= "Repacking Kernel:" & Kernels & " RamDisk:" & RamDisk & " Failed" & vbNewLine
                                    End If
                                End If
                            End If
                        Next
                    Next
                Else
                    Dim RamDisk As String = ComboBox2.SelectedItem.ToString
                    For Each Kernels In ComboBox1.Items
                        Kernels = Kernels.ToString
                        If Kernels <> "All" Then
                            If RamDisk <> Kernels Then
                                If langer.repack.Repack(Application.StartupPath & "\kernels\" & Kernels, Application.StartupPath & "\kernels\" & RamDisk, Application.StartupPath & "\Repacked\" & Kernels.Replace(".img", "") & "." & RamDisk.ToString, "thunder07") Then
                                    TextBox1.Text &= "Repacking Kernel:" & Kernels & " RamDisk:" & RamDisk & " Succeed" & vbNewLine
                                Else
                                    TextBox1.Text &= "Repacking Kernel:" & Kernels & " RamDisk:" & RamDisk & " Failed" & vbNewLine
                                End If
                            End If
                        End If
                    Next
                End If
            Else
                If ComboBox2.SelectedItem.ToString = "All" Then
                    Dim Kernels As String = ComboBox1.SelectedItem.ToString
                    For Each RamDisk In ComboBox2.Items
                        If RamDisk <> "All" Then
                            If RamDisk <> Kernels Then
                                If langer.repack.Repack(Application.StartupPath & "\kernels\" & Kernels, Application.StartupPath & "\kernels\" & RamDisk, Application.StartupPath & "\Repacked\" & Kernels.Replace(".img", "") & "." & RamDisk.ToString, "thunder07") Then
                                    TextBox1.Text &= "Repacking Kernel:" & Kernels & " RamDisk:" & RamDisk & " Succeed" & vbNewLine
                                Else
                                    TextBox1.Text &= "Repacking Kernel:" & Kernels & " RamDisk:" & RamDisk & " Failed" & vbNewLine
                                End If
                            End If
                        End If
                    Next
                Else
                    Dim Kernels As String = ComboBox1.SelectedItem.ToString
                    Dim RamDisk As String = ComboBox2.SelectedItem.ToString
                    If RamDisk <> Kernels Then
                        If langer.repack.Repack(Application.StartupPath & "\kernels\" & Kernels, Application.StartupPath & "\kernels\" & RamDisk, Application.StartupPath & "\Repacked\" & Kernels.Replace(".img", "") & "." & RamDisk.ToString, "thunder07") Then
                            TextBox1.Text &= "Repacking Kernel:" & Kernels & " RamDisk:" & RamDisk & " Succeed" & vbNewLine
                        Else
                            TextBox1.Text &= "Repacking Kernel:" & Kernels & " RamDisk:" & RamDisk & " Failed" & vbNewLine
                        End If
                    End If
                End If
            End If
            MSG("Repacking Completed")
        End If




        'If (System.IO.Directory.Exists(tempPath)) Then
        '    System.IO.Directory.Delete(tempPath, True)
        'End If
    End Sub
    Private Sub Root()
        Dim ComboBox1 As ComboBox = CB(0)
        Dim ComboBox4 As ComboBox = CB(1)

        Dim tempPath As String = System.IO.Path.GetTempPath & "OneXTemp\SU\"
        tempPath = tempPath.ToLower
        Dim zipPath As String = Application.StartupPath & "\apps\CWM-SuperSU-v0.92.zip" ''''Combobox2.SelectedItem.ToString
        'If (Not System.IO.Directory.Exists(tempPath)) Then
        '    System.IO.Directory.CreateDirectory(tempPath)
        'Else
        '    System.IO.Directory.Delete(tempPath, True)
        '    Delay(3)
        '    System.IO.Directory.CreateDirectory(tempPath)
        'End If
        ExtractArchive(zipPath, tempPath, "binary")


        If ComboBox1.SelectedIndex = -1 Or ComboBox1.SelectedItem = "None" Then
            GoTo rooting
        End If
        Dim ADF As String = AFI()
        If ADF.Contains("ADB") Then ''''''''''''ADB
            MSG("Booting Into Bootloader")
            StartR("apps\adb.exe", {"Reboot-bootloader"})
            GoTo FB
        ElseIf ADF = "Fastboot" Then ''''''''''''Fastboot
FB:
            Do Until AFI() = "Fastboot"

            Loop
            MSG("Flashing Recovery")
            StartS("apps\fastboot.exe", {"flash", "recovery", "recoveries\" & ComboBox1.SelectedItem.ToString})
            MSG("Clearing Cache")
            StartS("apps\fastboot.exe", {"erase", "cache"})


            If AFI.Contains("ADB") Then
                If AFI() = "ADB" Then
                    MSG("Booting into Recovery")
                    StartR("apps\adb.exe", {"Reboot", "recovery"})

                End If
            ElseIf AFI() = "Fastboot" Then
                StartR("apps\fastboot.exe", {"fastboot", "boot", "recoveries\recovery.img"})
                MSG("Booting Into Recovery")
                StartR("apps\adb.exe", {"Reboot", "recovery"})
            End If


        Else ''''''''''''Not Connected
            Stat.Text &= ("The Phone is Not Connected!!!")
            Exit Sub
        End If


        Delay(3)
rooting:
        If (System.IO.File.Exists(tempPath & "\update-binary")) Then
            MSG("Valid SuperSU.zip")
        Else
            '  System.IO.Directory.Delete(tempPath, True)
            MSG("Invalid SuperSU.zip")
            MSG("Operation SuperSU")
            Exit Sub
        End If
        ''ADB\Fastboot
        ADF = AFI()
        Dim Fastboot As Boolean = False
        If ADF.Contains("ADB") Then ''''''''''''ADB\Recovery
            If ADF = "ADB" Then
                Stat.Text &= "Booting Into Recovery" + vbNewLine
                TextBox1.Text &= "[" & Date.Now & "] " & "Booting Into Recovery" + vbNewLine
                StartR("apps\adb.exe", {"Reboot", "recovery"})
            Else
                GoTo rooting2
            End If
            ''Flash SuperSU

            Do Until AFI() = "ADB - Recovery"

            Loop
rooting2:
            TextBox1.Text &= "[" & Date.Now & "] " & "Flashing SuperSU" + vbNewLine
            Stat.Text &= "Flashing SuperSU" + vbNewLine
            StartS("apps\adb.exe", {"push", "apps\CWM-SuperSU-v0.92.zip", "/cache/SU/SU.zip"})
            StartR("apps\adb.exe", {"push", tempPath & "update-binary", "/cache/SU/SU"})
            StartR("apps\adb.exe", {"shell", "chmod", "755", "/cache/SU/SU"})
            StartS("apps\adb.exe", {"shell", "/cache/SU/SU", "3", "Thunder07", "/cache/SU/SU.zip"})
            StartR("apps\adb.exe", {"shell", "rm", "-rf", "/cache/SU/"})

            Completion(ComboBox4.SelectedItem)
        Else ''''''''''''Not Connected
            Stat.Text &= ("The Phone is Not Connected!!!")

        End If



        If (System.IO.Directory.Exists(tempPath)) Then
            System.IO.Directory.Delete(tempPath, True)
        End If
    End Sub
    Private Sub FlashRUU()
        Dim Combobox1 As ComboBox = CB(0)
        Dim Combobox4 As ComboBox = CB(1)
        If Combobox1.SelectedIndex = -1 Then
            MSG("Invalid Zip Choice!!")
            Exit Sub
        End If
        Dim tempPath As String = System.IO.Path.GetTempPath & "OneXTemp\RUU\"
        tempPath = tempPath.ToLower
        'ExtractArchive("zips\" & Combobox1.SelectedItem.ToString, tempPath, "android-info")
        ' If (System.IO.File.Exists(tempPath & "android-info.txt")) = False Then
        'System.IO.Directory.Delete(tempPath, True)
        '  MSG("Invalid Zip")
        '  MSG("Operation Terminated")
        '  Exit Sub
        '  End If

        ''ADB\Fastboot
        Dim ADF As String = AFI()
        Dim Fastboot As Boolean = False
        If ADF.Contains("ADB") Then ''''''''''''ADB\Recovery
            MSG("Booting Into RUU")
            StartR("apps\adb.exe", {"shell", "reboot", "oem-78"})

            GoTo FB

        ElseIf ADF = "Fastboot" Then ''''''''''''Fastboot

FB:
            Do Until ADF = "Fastboot"
                ADF = AFI()
            Loop

            If StartR("apps\fastboot.exe", {"getvar", "boot-mode"}, 60, 0).Contains("RUU") = False Then
                MSG("Booting Into RUU")
                StartR1("apps\fastboot.exe", {"oem", "rebootRUU"})
            End If
            Do Until StartR("apps\fastboot.exe", {"getvar", "boot-mode"}, 60, 0).Contains("RUU")

            Loop

            MSG("Flashing Zip")
            StartS("apps\fastboot.exe", {"flash", "zip", "zips\" & Combobox1.SelectedItem.ToString})
            MSG("Clearing Cache")
            StartS("apps\fastboot.exe", {"erase", "cache"})


            Completion(Combobox4.SelectedItem)
        Else ''''''''''''Not Connected
            Stat.Text &= "The Phone is Not Connected!!!"

        End If

    End Sub
    Private Sub EC()
        Dim ComboBox4 As ComboBox = CB(0)



        Dim ADF As String = AFI()
        If ADF.Contains("ADB") Then ''''''''''''ADB
            MSG("Booting Into Bootloader")
            StartR("apps\adb.exe", {"Reboot-bootloader"})
            GoTo FB
        ElseIf ADF = "Fastboot" Then ''''''''''''Fastboot
FB:
            Do Until AFI() = "Fastboot"

            Loop
            MSG("Clearing Cache")
            StartS("apps\fastboot.exe", {"erase", "cache"})




        Else ''''''''''''Not Connected
            Stat.Text &= ("The Phone is Not Connected!!!")
            Exit Sub
        End If


        Completion(ComboBox4.SelectedItem)




    End Sub
    Private Sub Unlock()
        Dim Combobox1 As ComboBox = CB(0)
        Dim Combobox4 As ComboBox = CB(1)
        If Combobox1.SelectedIndex = -1 Then
            MSG("Invalid Options!!")
            Exit Sub
        End If
        Dim ADF As String = AFI()
        If ADF.Contains("ADB") Then ''''''''''''ADB

            MSG("Booting Into Bootloader")
            StartR("apps\adb.exe", {"Reboot-bootloader"})
            GoTo FB
        ElseIf ADF = "Fastboot" Then ''''''''''''Fastboot
FB:
            Do Until AFI() = "Fastboot"
                Delay(5)
            Loop
            Delay(5)
            MSG("Unlocking")
            StartS("apps\fastboot.exe", {"flash", "unlocktoken", "unlock\" & Combobox1.SelectedItem.ToString})

            ' Completion(Combobox4.SelectedItem)
        Else ''''''''''''Not Connected
            Stat.Text &= ("The Phone is Not Connected!!!")
            Exit Sub
        End If

    End Sub
    Private Sub Lock()
        'Dim Combobox1 As ComboBox = CB(0)
        Dim Combobox4 As ComboBox = CB(1)
        '  If Combobox1.SelectedIndex = -1 Then
        'MSG("Invalid Options!!")
        'Exit Sub
        ' End If
        Dim ADF As String = AFI()
        If ADF.Contains("ADB") Then ''''''''''''ADB

            MSG("Booting Into Bootloader")
            StartR("apps\adb.exe", {"Reboot-bootloader"})
            GoTo FB
        ElseIf ADF = "Fastboot" Then ''''''''''''Fastboot
FB:
            Do Until AFI() = "Fastboot"
                Delay(5)
            Loop
            Delay(5)
            MSG("Locking")
            StartS("apps\fastboot.exe", {"oem", "lock"})

            Completion(Combobox4.SelectedItem)
        Else ''''''''''''Not Connected
            Stat.Text &= ("The Phone is Not Connected!!!")
            Exit Sub
        End If

    End Sub

    Private Sub MSG(ByVal MSG As String)
        Stat.Text &= MSG & vbNewLine
        TextBox1.Text &= "[" & Date.Now & "] " & MSG & vbNewLine
        If hides Then
            OXOC.ShowBalloonTip(5000, "Processing", MSG, ToolTipIcon.Info)
        End If
    End Sub
    Private Sub Logger()
        ListBox1.Enabled = False

        If RD(0).Checked Then
            StartCustom("apps\adb.exe", {"shell", "cat", "/proc/last_kmsg"})
        ElseIf RD(1).Checked Then
            StartCustom("apps\adb.exe", {"shell", "cat", "/proc/kmsg"})
        Else
            StartCustom("apps\adb.exe", {"logcat"})
        End If

        ListBox1.Enabled = True
    End Sub

    Private Sub ScreenShot()
       
        Dim ADF As String = AFI()
        If ADF.Contains("ADB") Then ''''''''''''ADB
            If (My.Computer.FileSystem.DirectoryExists("TMP") = False) Then
                Dim dir As DirectoryInfo = Directory.CreateDirectory("TMP")
                dir.Attributes = FileAttributes.Hidden
            End If
            If ADF = "ADB" Then
                Dim strw2 As New StreamWriter("TMP\SS.bat", False, Encoding.ASCII)
                strw2.WriteLine(String.Format(My.Resources.SS, "ADB"))
                strw2.Close()
            Else
                Dim strw2 As New StreamWriter("TMP\SS.bat", False, Encoding.ASCII)
                strw2.WriteLine(String.Format(My.Resources.SS, "ADB2"))
                strw2.Close()
            End If
            StartR("TMP\SS.bat", {""})
            MSG("ScreenShot Taken.")
            ClearTMP()
        Else ''''''''''''Not Connected
            Stat.Text &= ("The Phone is Not Connected!!!")
            Exit Sub
        End If

    End Sub
#End Region

#Region "Design"
    Private Sub Kernel()
        ''''Kernel
        Dim ComboBox1 As New ComboBox
        Dim ComboBox2 As New ComboBox
        Dim ComboBox4 As New ComboBox
        'If 1 = 2 Then

        'Else
        '    ComboBox1 = New Windows.Forms.ComboBox
        '    Combobox2 = New Windows.Forms.ComboBox
        '    ComboBox4 = New Windows.Forms.ComboBox
        '    'GhostTheme1.Visible = False
        '    For Each itm In GhostTheme1.Controls
        '        Me.Controls.Add(itm)
        '    Next

        'End If

        ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New System.Drawing.Point(6, 137 - 4)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New System.Drawing.Size(193, 21)
        ComboBox1.TabIndex = 4
        ComboBox1.DropDownWidth = 250


        ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New System.Drawing.Point(6, 177 - 4)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New System.Drawing.Size(193, 21)
        ComboBox2.TabIndex = 5
        ComboBox2.DropDownWidth = 250
        '
        'Label1
        '
        Dim Label1 As New Label
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.ForeColor = System.Drawing.Color.White
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(6, 123 - 4)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(40, 13)
        Label1.TabIndex = 6
        Label1.Text = "Kernel:"
        '
        'Label2
        '
        Dim label2 As New Label
        label2.BackColor = System.Drawing.Color.Transparent
        label2.ForeColor = System.Drawing.Color.White
        label2.AutoSize = True
        label2.Location = New System.Drawing.Point(6, 163 - 4)
        label2.Name = "Label2"
        label2.Size = New System.Drawing.Size(107, 13)
        label2.TabIndex = 7
        label2.Text = "Kernel Modules:"

        Dim label4 As New Label
        label4.BackColor = System.Drawing.Color.Transparent
        label4.ForeColor = System.Drawing.Color.White
        label4.AutoSize = True
        label4.Location = New System.Drawing.Point(6, 163 + 40 - 4)
        label4.Name = "label4"
        label4.Size = New System.Drawing.Size(76, 13)
        label4.TabIndex = 6
        label4.Text = "On Completion:"
        '
        'Label5
        '
        Dim label5 As New Label
        label5.BackColor = System.Drawing.Color.Transparent
        label5.ForeColor = System.Drawing.Color.White
        label5.AutoSize = False
        label5.Location = New System.Drawing.Point(9, 221 + 40)
        label5.Name = "label5"
        label5.Size = New System.Drawing.Size(176, 13 * 5)
        label5.TabIndex = 7
        label5.TextAlign = ContentAlignment.MiddleCenter
        label5.Text = "*On Completion Booting Into Recovery" & vbNewLine & "Doesnt Work On HBOOT-0.43.0000" & vbNewLine & _
    "Check Help For More Info"
        '
        'ComboBox4
        '

        ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox4.FormattingEnabled = True
        ComboBox4.Location = New System.Drawing.Point(6, 177 + 40 - 4)
        ComboBox4.Name = "ComboBox4"
        ComboBox4.Size = New System.Drawing.Size(193, 21)
        ComboBox4.TabIndex = 9
        LB = {Label1, label2, label4, label5}
        CB = {ComboBox1, ComboBox2, ComboBox4}


        Dim CS As Control() = {ComboBox1, ComboBox2, ComboBox4, Label1, label2, label4, label5}
        ComboBox1.Items.Add("None")
        ComboBox2.Items.Add("None")

        ComboBox4.Items.AddRange({"Nothing", "Reboot", "Recovery*", "Bootloader"})
        GroupBox1.Controls.AddRange(CS)


        Try
            Dim di As New IO.DirectoryInfo(Application.StartupPath + "\kernels\")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For x = 0 To diar1.Length() - 1
                If diar1(x).Name().ToLower.Contains(".img") Then
                    ComboBox1.Items.Add("kernels\" & diar1(x).Name())
                End If
            Next
        Catch ex As Exception
        End Try
        Try
            Dim di As New IO.DirectoryInfo(Application.StartupPath + "\repacked\")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For x = 0 To diar1.Length() - 1
                If diar1(x).Name().ToLower.Contains(".img") Then
                    ComboBox1.Items.Add("repacked\" & diar1(x).Name())
                End If
            Next
        Catch ex As Exception
        End Try
        Try
            Dim di As New IO.DirectoryInfo(Application.StartupPath + "\modules\")
            Dim diar1 As IO.FileInfo() = di.GetFiles()

            For x = 0 To diar1.Length() - 1
                If diar1(x).Name().ToLower.Contains(".zip") Then
                    ComboBox2.Items.Add(diar1(x).Name())
                    Dim ZipK As Array = FindKernelImg(diar1(x).Name())
                    ComboBox1.Items.AddRange(ZipK)
                End If
            Next
        Catch ex As Exception
        End Try
        '0  -- ComboBox1
        '1  -- Combobox2
        '2  -- Combobox3
        '3  -- Label1
        '4  -- label2
        '5  -- label3
        '6  -- label4
        '7  -- label5
        '8  -- RadioButton1
        '9  -- RadioButton2
        '10 -- RadioButton3

    End Sub
    Private Sub RUU()
        ''''Kernel
        Dim ComboBox1 As New ComboBox
        ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New System.Drawing.Point(6, 137 - 4)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New System.Drawing.Size(193, 21)
        ComboBox1.TabIndex = 4
        ComboBox1.DropDownWidth = 250
        '
        'Label1
        '
        Dim Label1 As New Label
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.ForeColor = System.Drawing.Color.White
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(6, 123 - 4)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(40, 13)
        Label1.TabIndex = 6
        Label1.Text = "Zips:"

        Dim label4 As New Label
        label4.BackColor = System.Drawing.Color.Transparent
        label4.ForeColor = System.Drawing.Color.White
        label4.AutoSize = True
        label4.Location = New System.Drawing.Point(6, 163 + 40 - 4)
        label4.Name = "label4"
        label4.Size = New System.Drawing.Size(76, 13)
        label4.TabIndex = 6
        label4.Text = "On Completion:"
        '
        'Label5
        '
        Dim label5 As New Label
        label5.BackColor = System.Drawing.Color.Transparent
        label5.ForeColor = System.Drawing.Color.White
        label5.AutoSize = False
        label5.Location = New System.Drawing.Point(9, 221 + 40)
        label5.Name = "label5"
        label5.Size = New System.Drawing.Size(176, 13 * 5)
        label5.TabIndex = 7
        label5.TextAlign = ContentAlignment.MiddleCenter
        label5.Text = "*On Completion Booting Into Recovery" & vbNewLine & "Doesnt Work On HBOOT-0.43.0000" & vbNewLine & _
    "Check Help For More Info"
        '
        'ComboBox4
        '
        Dim ComboBox4 As New ComboBox
        ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox4.FormattingEnabled = True
        ComboBox4.Location = New System.Drawing.Point(6, 177 + 40 - 4)
        ComboBox4.Name = "ComboBox4"
        ComboBox4.Size = New System.Drawing.Size(193, 21)
        ComboBox4.TabIndex = 9
        Dim CS As Control() = {ComboBox1, ComboBox4, Label1, label4, label5}
        LB = {Label1, label4, label5}
        CB = {ComboBox1, ComboBox4}

        ComboBox4.Items.AddRange({"Nothing", "Reboot", "Recovery*", "Bootloader"})
        GroupBox1.Controls.AddRange(CS)

        Try
            Dim di As New IO.DirectoryInfo(Application.StartupPath + "\zips\")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For x = 0 To diar1.Length() - 1
                If diar1(x).Name().ToLower.Contains(".zip") Then
                    ComboBox1.Items.Add(diar1(x).Name())
                End If
            Next
        Catch ex As Exception
        End Try


        
        '0  -- ComboBox1
        '1  -- Combobox2
        '2  -- Combobox3
        '3  -- Label1
        '4  -- label2
        '5  -- label3
        '6  -- label4
        '7  -- label5
        '8  -- RadioButton1
        '9  -- RadioButton2
        '10 -- RadioButton3

    End Sub
    Private Sub Recovery()
        ''''Kernel
        Dim ComboBox1 As New ComboBox
        ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New System.Drawing.Point(6, 137 - 4)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New System.Drawing.Size(193, 21)
        ComboBox1.TabIndex = 4
        ComboBox1.DropDownWidth = 250
        '
        'Label1
        '
        Dim Label7 As New Label
        Label7.BackColor = System.Drawing.Color.Transparent
        Label7.ForeColor = System.Drawing.Color.White
        Label7.AutoSize = True
        Label7.Location = New System.Drawing.Point(6, 123 - 4)
        Label7.Name = "Label1"
        Label7.Size = New System.Drawing.Size(40, 13)
        Label7.TabIndex = 6
        Label7.Text = "Recovery:"

        '
        'Label4
        '
        Dim label4 As New Label
        label4.BackColor = System.Drawing.Color.Transparent
        label4.ForeColor = System.Drawing.Color.White
        label4.AutoSize = True
        label4.Location = New System.Drawing.Point(6, 163 - 4)
        label4.Name = "label4"
        label4.Size = New System.Drawing.Size(76, 13)
        label4.TabIndex = 6
        label4.Text = "On Completion:"
        '
        'Label5
        '
        Dim label5 As New Label
        label5.BackColor = System.Drawing.Color.Transparent
        label5.ForeColor = System.Drawing.Color.White
        label5.AutoSize = False
        label5.Location = New System.Drawing.Point(9, 221 + 40)
        label5.Name = "label5"
        label5.Size = New System.Drawing.Size(176, 13 * 5)
        label5.TabIndex = 7
        label5.TextAlign = ContentAlignment.MiddleCenter
        label5.Text = "*On Completion Booting Into Recovery" & vbNewLine & "Doesnt Work On HBOOT-0.43.0000" & vbNewLine & _
    "Check Help For More Info"
        '
        'ComboBox4
        '
        Dim ComboBox4 As New ComboBox
        ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox4.FormattingEnabled = True
        ComboBox4.Location = New System.Drawing.Point(6, 177 - 4)
        ComboBox4.Name = "ComboBox4"
        ComboBox4.Size = New System.Drawing.Size(193, 21)
        ComboBox4.TabIndex = 9

        Dim CS As Control() = {ComboBox1, ComboBox4, Label7, label4, label5}

        LB = {Label7, label4, label5}
        CB = {ComboBox1, ComboBox4}

        ComboBox4.Items.AddRange({"Nothing", "Reboot", "Recovery*", "Bootloader"})
        GroupBox1.Controls.AddRange(CS)

        Try
            Dim di As New IO.DirectoryInfo(Application.StartupPath + "\recoveries\")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For x = 0 To diar1.Length() - 1
                If diar1(x).Name().ToLower.Contains(".img") Then
                    ComboBox1.Items.Add(diar1(x).Name())
                End If
            Next
        Catch ex As Exception
        End Try
        
    End Sub
    Private Sub KRepackD()
        Dim RadioButton2 As New Radiobutton
        Dim Label1 As New Label
        Dim RadioButton1 As New Radiobutton
        '
        'RadioButton1
        '
        RadioButton1.AutoSize = True
        RadioButton1.BackColor = System.Drawing.Color.Transparent
        RadioButton1.ForeColor = System.Drawing.Color.White
        RadioButton1.Location = New System.Drawing.Point(6, 136)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New System.Drawing.Size(112, 17)
        RadioButton1.TabIndex = 2
        RadioButton1.TabStop = True
        RadioButton1.Text = "Android Device"
        AddHandler RadioButton1.CheckedChanged, AddressOf CheckChanged
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.ForeColor = System.Drawing.Color.White
        Label1.Location = New System.Drawing.Point(6, 119)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(105, 13)
        Label1.TabIndex = 3
        Label1.Text = "Repack Through:"
        '
        'RadioButton2
        '
        RadioButton2.AutoSize = True
        RadioButton2.BackColor = System.Drawing.Color.Transparent
        RadioButton2.ForeColor = System.Drawing.Color.White
        RadioButton2.Location = New System.Drawing.Point(124, 136)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New System.Drawing.Size(41, 17)
        RadioButton2.TabIndex = 4
        RadioButton2.Checked = True
        RadioButton2.Text = "PC"

        Dim CheckBox2 As New Checkbox
        Dim CheckBox1 As New Checkbox
        Dim ComboBox4 As New ComboBox
        Dim Label5 As New Label
        Dim ComboBox3 As New ComboBox
        Dim Label4 As New Label
        Dim ComboBox2 As New ComboBox
        Dim Label3 As New Label
        Dim ComboBox1 As New ComboBox
        Dim Label2 As New Label
        '
        'Label2
        '
        Label2.BackColor = System.Drawing.Color.Transparent
        Label2.ForeColor = System.Drawing.Color.White
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(6, 119 + 33)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(40, 13)
        Label2.TabIndex = 2
        Label2.Text = "Kernel:"
        '
        'ComboBox1
        '
        ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New System.Drawing.Point(6, 133 + 33)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New System.Drawing.Size(193, 21)
        ComboBox1.TabIndex = 3
        ComboBox1.DropDownWidth = 250
        '
        'CombBox3
        '
        ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox3.FormattingEnabled = True
        ComboBox3.Location = New System.Drawing.Point(6, 173 + 40 + 33)
        ComboBox3.Name = "ComboBox3"
        ComboBox3.Size = New System.Drawing.Size(193, 21)
        ComboBox3.TabIndex = 5
        ComboBox3.DropDownWidth = 250
        '
        'Label3
        '
        Label3.BackColor = System.Drawing.Color.Transparent
        Label3.ForeColor = System.Drawing.Color.White
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(6, 159 + 33)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(50, 13)
        Label3.TabIndex = 4
        Label3.Text = "RamDisk:"
        '
        'ComboBox2
        '
        ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New System.Drawing.Point(6, 173 + 33)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New System.Drawing.Size(193, 21)
        ComboBox2.TabIndex = 5
        ComboBox2.DropDownWidth = 250
        '
        'Label4
        '
        Label4.BackColor = System.Drawing.Color.Transparent
        Label4.ForeColor = System.Drawing.Color.White
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(3, 199 + 33)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(98, 13)
        Label4.TabIndex = 6
        Label4.Text = "Modules:"
        '
        'Label5
        '
        Label5.BackColor = System.Drawing.Color.Transparent
        Label5.ForeColor = System.Drawing.Color.White
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(6, 300 + 43)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(79, 13)
        Label5.TabIndex = 8
        Label5.Text = "On Completion:"
        '
        'ComboBox4
        '
        ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox4.FormattingEnabled = True
        ComboBox4.Location = New System.Drawing.Point(6, 313 + 43)
        ComboBox4.Name = "ComboBox4"
        ComboBox4.Size = New System.Drawing.Size(193, 21)
        ComboBox4.TabIndex = 9
        '
        'CheckBox1
        '
        CheckBox1.AutoSize = True
        CheckBox1.Location = New System.Drawing.Point(6, 240 + 33)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New System.Drawing.Size(137, 17)
        CheckBox1.TabIndex = 10
        CheckBox1.Text = "Flash Repacked Kernel"
        'CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        CheckBox2.AutoSize = True
        CheckBox2.Location = New System.Drawing.Point(6, 263 + 33)
        CheckBox2.Name = "CheckBox2"
        CheckBox2.Size = New System.Drawing.Size(129, 17)
        CheckBox2.TabIndex = 11
        CheckBox2.Text = "Pull Repacked Kernel"

        ' CheckBox2.UseVisualStyleBackColor = True

        '
        'CheckBox2
        '
        Dim Label6 As New Label
        Label6.AutoSize = False
        Label6.BackColor = System.Drawing.Color.Transparent
        Label6.ForeColor = System.Drawing.Color.White
        Label6.TextAlign = ContentAlignment.MiddleCenter
        Label6.Location = New System.Drawing.Point(6, 263 + 30)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(190, 30 + 17)
        Label6.TabIndex = 11
        Label6.Visible = False
        Label6.Text = "PC Based Repack Brought To You By XDA Member" & vbNewLine & "langer hans"

        Dim CS As Control() = {ComboBox1, ComboBox2, ComboBox3, ComboBox4, CheckBox1, CheckBox2, RadioButton1, RadioButton2, Label1, Label2, Label3, Label4, Label5, Label6}

        LB = {Label1, Label2, Label3, Label4, Label5, Label6}
        CB = {ComboBox1, ComboBox2, ComboBox3, ComboBox4}
        CheckB = {CheckBox1, CheckBox2}
        RD = {RadioButton1, RadioButton2}
        ComboBox3.Items.Add("None")
        ComboBox4.Items.AddRange({"Nothing", "Reboot", "Recovery*", "Bootloader"})
        GroupBox1.Controls.AddRange(CS)
        Try
            Dim di As New IO.DirectoryInfo(Application.StartupPath + "\kernels\")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For x = 0 To diar1.Length() - 1
                If diar1(x).Name().ToLower.Contains(".img") Then
                    ComboBox1.Items.Add(diar1(x).Name())
                    ComboBox2.Items.Add(diar1(x).Name())
                End If
            Next
        Catch ex As Exception

        End Try

        Try
            Dim di As New IO.DirectoryInfo(Application.StartupPath + "\modules\")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For x = 0 To diar1.Length() - 1
                If diar1(x).Name().ToLower.Contains(".zip") Then
                    ComboBox3.Items.Add(diar1(x).Name())
                    Dim ZipK As Array = FindKernelImg(diar1(x).Name())
                    ComboBox1.Items.AddRange(ZipK)
                    ComboBox2.Items.AddRange(ZipK)
                End If
            Next
        Catch ex As Exception
        End Try

        

    End Sub
    Private Sub MultiKRepackD()
        Dim RadioButton2 As New Radiobutton
        Dim Label1 As New Label
        Dim RadioButton1 As New Radiobutton
        '
        'RadioButton1
        '
        RadioButton1.AutoSize = True
        RadioButton1.BackColor = System.Drawing.Color.Transparent
        RadioButton1.ForeColor = System.Drawing.Color.White
        RadioButton1.Location = New System.Drawing.Point(6, 136)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New System.Drawing.Size(112, 17)
        RadioButton1.TabIndex = 2
        RadioButton1.TabStop = True
        RadioButton1.Text = "Android Device"
        AddHandler RadioButton1.CheckedChanged, AddressOf CheckChanged
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.ForeColor = System.Drawing.Color.White
        Label1.Location = New System.Drawing.Point(6, 119)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(105, 13)
        Label1.TabIndex = 3
        Label1.Text = "Repack Through:"
        '
        'RadioButton2
        '
        RadioButton2.AutoSize = True
        RadioButton2.BackColor = System.Drawing.Color.Transparent
        RadioButton2.ForeColor = System.Drawing.Color.White
        RadioButton2.Location = New System.Drawing.Point(124, 136)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New System.Drawing.Size(41, 17)
        RadioButton2.TabIndex = 4
        RadioButton2.Checked = True
        RadioButton2.Text = "PC"

        Dim CheckBox1 As New Checkbox
        Dim ComboBox4 As New ComboBox
        Dim Label5 As New Label
       Dim ComboBox2 As New ComboBox
        Dim Label3 As New Label
        Dim ComboBox1 As New ComboBox
        Dim Label2 As New Label
        '
        'Label2
        '
        Label2.BackColor = System.Drawing.Color.Transparent
        Label2.ForeColor = System.Drawing.Color.White
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(6, 119 + 33)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(40, 13)
        Label2.TabIndex = 2
        Label2.Text = "Kernel:"
        '
        'ComboBox1
        '
        ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New System.Drawing.Point(6, 133 + 33)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New System.Drawing.Size(193, 21)
        ComboBox1.TabIndex = 3
        ComboBox1.DropDownWidth = 250
        '
        'Label3
        '
        Label3.BackColor = System.Drawing.Color.Transparent
        Label3.ForeColor = System.Drawing.Color.White
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(6, 159 + 33)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(50, 13)
        Label3.TabIndex = 4
        Label3.Text = "RamDisk:"
        '
        'ComboBox2
        '
        ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New System.Drawing.Point(6, 173 + 33)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New System.Drawing.Size(193, 21)
        ComboBox2.TabIndex = 5
        ComboBox2.DropDownWidth = 250
        '
        'Label5
        '
        Label5.BackColor = System.Drawing.Color.Transparent
        Label5.ForeColor = System.Drawing.Color.White
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(6, 199 + 33)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(79, 13)
        Label5.TabIndex = 8
        Label5.Text = "On Completion:"
        '
        'ComboBox4
        '
        ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox4.FormattingEnabled = True
        ComboBox4.Location = New System.Drawing.Point(6, 213 + 33)
        ComboBox4.Name = "ComboBox4"
        ComboBox4.Size = New System.Drawing.Size(193, 21)
        ComboBox4.TabIndex = 9
        '
        'CheckBox1
        '
        CheckBox1.AutoSize = True
        CheckBox1.Location = New System.Drawing.Point(6, 240 + 33)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New System.Drawing.Size(137, 17)
        CheckBox1.TabIndex = 10
        CheckBox1.Text = "Pull Repacked Kernel"
        'CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        Dim Label6 As New Label
        Label6.AutoSize = False
        Label6.BackColor = System.Drawing.Color.Transparent
        Label6.ForeColor = System.Drawing.Color.White
        Label6.TextAlign = ContentAlignment.MiddleCenter
        Label6.Location = New System.Drawing.Point(6, 263 + 30)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(190, 30 + 17)
        Label6.TabIndex = 11
        Label6.Visible = False
        Label6.Text = "PC Based Repack Brought To You By XDA Member" & vbNewLine & "langer hans"

        Dim CS As Control() = {ComboBox1, ComboBox2, ComboBox4, CheckBox1, RadioButton1, RadioButton2, Label1, Label2, Label3, Label5, Label6}

        LB = {Label2, Label3, Label5, Label1, Label6}
        CB = {ComboBox1, ComboBox2, ComboBox4}
        CheckB = {CheckBox1}
        RD = {RadioButton1, RadioButton2}
        ComboBox1.Items.Add("All")
        ComboBox2.Items.Add("All")
        ComboBox4.Items.AddRange({"Nothing", "Reboot", "Recovery", "Bootloader"})
        GroupBox1.Controls.AddRange(CS)

        Try
            
            Dim di As New IO.DirectoryInfo(Application.StartupPath + "\kernels\")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For x = 0 To diar1.Length() - 1
                If diar1(x).Name().ToLower.Contains(".img") Then
                    ComboBox1.Items.Add(diar1(x).Name())
                    ComboBox2.Items.Add(diar1(x).Name())
                End If
            Next
        Catch ex As Exception
        End Try
       
        
    End Sub
    Private Sub RootD()
        Dim ComboBox2 As New ComboBox
        Dim Label3 As New Label
        Dim ComboBox1 As New ComboBox
        Dim Label2 As New Label
        Dim Label1 As New Label
        '
        'Label2
        '
        Label2.BackColor = System.Drawing.Color.Transparent
        Label2.ForeColor = System.Drawing.Color.White
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(6, 119)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(40, 13)
        Label2.TabIndex = 2
        Label2.Text = "Recovery(Optional)*:"
        '
        'ComboBox1
        '
        ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New System.Drawing.Point(6, 133)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New System.Drawing.Size(193, 21)
        ComboBox1.TabIndex = 3
        ComboBox1.DropDownWidth = 250
        '
        'Label3
        '
        Label3.BackColor = System.Drawing.Color.Transparent
        Label3.ForeColor = System.Drawing.Color.White
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(6, 159)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(50, 13)
        Label3.TabIndex = 4
        Label3.Text = "On Completion:" '
        'Label1
        '
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.ForeColor = System.Drawing.Color.White
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(6, 173 + 26)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(193, 13 * 11)
        Label1.TabIndex = 4
        Label1.AutoSize = False
        Label1.Text = "Recovery Is Only Optional If You Have" & vbNewLine & " It Installed Already" & _
            " Else You Must Install One" & vbNewLine & _
            "*Will Be Problematic with HBoot 0.43" & vbNewLine & _
        "So I Recommand Using The 'Flash Recovery' Option" & vbNewLine & _
        "With Do Nothing On Completion, Manaully Booting Into Recovery Then Rooting Here"


        Label1.TextAlign = ContentAlignment.MiddleCenter
        '
        'ComboBox2
        '
        ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New System.Drawing.Point(6, 173)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New System.Drawing.Size(193, 21)
        ComboBox2.TabIndex = 5


        Dim CS As Control() = {ComboBox1, ComboBox2, Label1, Label2, Label3}

        LB = {Label1, Label2, Label3}
        CB = {ComboBox1, ComboBox2}

        Try
            ComboBox1.Items.Add("None")
            Dim di As New IO.DirectoryInfo(Application.StartupPath + "\recoveries\")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For x = 0 To diar1.Length() - 1
                If diar1(x).Name().ToLower.Contains(".img") Then
                    ComboBox1.Items.Add(diar1(x).Name())
                End If
            Next
        Catch ex As Exception
        End Try
        ComboBox2.Items.AddRange({"Nothing", "Reboot", "Recovery", "Bootloader"})
        GroupBox1.Controls.AddRange(CS)

    End Sub
    Private Sub ECD()
        Dim ComboBox2 As New ComboBox
        Dim Label3 As New Label

        '
        'Label3
        '
        Label3.BackColor = System.Drawing.Color.Transparent
        Label3.ForeColor = System.Drawing.Color.White
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(6, 119)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(50, 13)
        Label3.TabIndex = 4
        Label3.Text = "On Completion:" '
        '
        'ComboBox2
        '
        ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New System.Drawing.Point(6, 133)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New System.Drawing.Size(193, 21)
        ComboBox2.TabIndex = 5


        Dim CS As Control() = {ComboBox2, Label3}

        LB = {Label3}
        CB = {ComboBox2}

        ComboBox2.Items.AddRange({"Nothing", "Reboot", "Recovery*", "Bootloader"})
        GroupBox1.Controls.AddRange(CS)

    End Sub
    Private Sub HelpD()
        Dim Label1 As New Label
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.ForeColor = System.Drawing.Color.White
        Label1.AutoSize = False
        Label1.Location = New System.Drawing.Point(6, 121)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(193, 13 * 13)
        Label1.TextAlign = ContentAlignment.MiddleCenter
        Label1.TabIndex = 6
        Label1.Text = "In Some Cases " + vbNewLine + _
            "Booting into Recovery Requires" + vbNewLine + _
        "a Recovery Image in The Recovery Folder," + vbNewLine + _
      "Named Recovery.img" + vbNewLine + _
      "Also, Your HBoot must be" + vbNewLine + _
       "higher than 0.43000" + vbNewLine + _
       "Though Whenever I Can I try To Avoid This Method"
        GroupBox1.Controls.Add(Label1)
        LB = {Label1}

    End Sub
    Private Sub RebootD()
        Dim ComboBox2 As New ComboBox
        Dim Label2 As New Label
        '
        'Label2
        '
        Label2.BackColor = System.Drawing.Color.Transparent
        Label2.ForeColor = System.Drawing.Color.White
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(6, 119)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(40, 13)
        Label2.TabIndex = 2
        Label2.Text = "Options:"
        '
        'ComboBox2
        '
        ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New System.Drawing.Point(6, 133)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New System.Drawing.Size(193, 21)
        ComboBox2.TabIndex = 5


        Dim CS As Control() = {ComboBox2, Label2}

        LB = {Label2}
        CB = {ComboBox2}


        ComboBox2.Items.AddRange({"Reboot", "Recovery*", "Bootloader"})
        GroupBox1.Controls.AddRange(CS)

    End Sub
    Private Sub LockUnLockD()
        Dim ComboBox2 As New ComboBox
        Dim Label3 As New Label
        Dim ComboBox1 As New ComboBox
        Dim Label2 As New Label
        Dim RadioButton1, RadioButton2 As New Radiobutton
        '
        'Radiobutton1
        '
        RadioButton1.Checked = True
        RadioButton1.Colors = New One_Clik.Bloom(-1) {}
        RadioButton1.Customization = ""
        RadioButton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        RadioButton1.Image = Nothing
        RadioButton1.Location = New System.Drawing.Point(9, 120)
        RadioButton1.Name = "Radiobutton1"
        RadioButton1.NoRounding = False
        RadioButton1.Size = New System.Drawing.Size(49, 14)
        RadioButton1.TabIndex = 2
        RadioButton1.Text = "Lock"
        RadioButton1.Transparent = False
        AddHandler RadioButton1.CheckedChanged, AddressOf Radiobutton_CheckedChanged

        '
        'Radiobutton2
        '
        RadioButton2.Checked = False
        RadioButton2.Colors = New One_Clik.Bloom(-1) {}
        RadioButton2.Customization = ""
        RadioButton2.Font = New System.Drawing.Font("Verdana", 8.0!)
        RadioButton2.Image = Nothing
        RadioButton2.Location = New System.Drawing.Point(136, 120)
        RadioButton2.Name = "Radiobutton2"
        RadioButton2.NoRounding = False
        RadioButton2.Size = New System.Drawing.Size(60, 14)
        RadioButton2.TabIndex = 3
        RadioButton2.Text = "Unlock"
        RadioButton2.Transparent = False
        '
        'Label2
        '6, 137
        Label2.BackColor = System.Drawing.Color.Transparent
        Label2.ForeColor = System.Drawing.Color.White
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(6, 119 + 40 - 22)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(40, 13)
        Label2.TabIndex = 2
        Label2.Text = "Unlock Bin:"
        Label2.Visible = False
        '
        'ComboBox1
        '
        ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New System.Drawing.Point(6, 133 + 40 - 22)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New System.Drawing.Size(193, 21)
        ComboBox1.TabIndex = 3
        ComboBox1.Visible = False
        '
        'Label3
        '
        Label3.BackColor = System.Drawing.Color.Transparent
        Label3.ForeColor = System.Drawing.Color.White
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(6, 159 - 22)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(50, 13)
        Label3.TabIndex = 4
        Label3.Text = "On Completion:" '

        '
        'ComboBox2
        '
        ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New System.Drawing.Point(6, 173 - 22)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New System.Drawing.Size(193, 21)
        ComboBox2.TabIndex = 5


        Dim CS As Control() = {ComboBox1, ComboBox2, RadioButton1, RadioButton2, Label2, Label3}

        LB = {Label2, Label3}
        CB = {ComboBox1, ComboBox2}
        RD = {RadioButton1, RadioButton2}

        Try
            Dim di As New IO.DirectoryInfo(Application.StartupPath + "\unlock\")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For x = 0 To diar1.Length() - 1
                If diar1(x).Name().ToLower.Contains(".bin") Then
                    ComboBox1.Items.Add(diar1(x).Name())
                End If
            Next
        Catch ex As Exception
        End Try
        ComboBox2.Items.AddRange({"Nothing", "Reboot", "Recovery*", "Bootloader"})
        GroupBox1.Controls.AddRange(CS)

    End Sub
    Private Sub Options()
        Dim CheckBox1 As New Checkbox
        CheckBox1.BackColor = System.Drawing.Color.Transparent
        CheckBox1.ForeColor = System.Drawing.Color.White
        CheckBox1.Location = New System.Drawing.Point(6, 120)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New System.Drawing.Size(193, 31)
        CheckBox1.TabIndex = 2
        CheckBox1.Text = "Associate Kernel/Recovery" & vbNewLine & "(.IMG) With This Tool" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)


      
        Dim Add2Startup As New Checkbox
        Add2Startup.BackColor = System.Drawing.Color.Transparent
        Add2Startup.ForeColor = System.Drawing.Color.White
        Add2Startup.Location = New System.Drawing.Point(6, 120 + 31)
        Add2Startup.Name = "Add2Startup"
        Add2Startup.Size = New System.Drawing.Size(193, 31)
        Add2Startup.TabIndex = 2
        Add2Startup.Text = "Add To Startup"

        Add2Startup.Checked = My.Computer.FileSystem.FileExists(System.Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\OXOC.lnk")

      
        CheckB = {CheckBox1, Add2Startup}
        GroupBox1.Controls.AddRange(CheckB)
        AddHandler CheckBox1.Click, AddressOf Asso
        AddHandler Add2Startup.Click, AddressOf AtBoot

    End Sub

    Private Sub DragNDropD()
        Dim Drop As New Label
        '
        'Drop
        '
        Drop.AllowDrop = True
        Drop.BackColor = System.Drawing.Color.Transparent
        Drop.ForeColor = System.Drawing.Color.White
        Drop.Location = New System.Drawing.Point(6, 117)
        Drop.Name = "Drop"
        Drop.Size = New System.Drawing.Size(193, 260)
        Drop.TabIndex = 1
        Drop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Drop.Text = "DragNDrop" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Anywhere" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Here"

        LB = {Drop}

        AddHandler Drop.DragDrop, AddressOf GroupBox1_DragDrop
        AddHandler Drop.DragEnter, AddressOf GroupBox1_DragEnter
        GroupBox1.Controls.AddRange(LB)

    End Sub

    Private Sub LoggerD()
        Dim Radiobutton1 As New Radiobutton
        Dim Radiobutton2 As New Radiobutton
        Dim Radiobutton3 As New Radiobutton

        Radiobutton1.Checked = True
        Radiobutton1.Colors = New One_Clik.Bloom(-1) {}
        Radiobutton1.Customization = ""
        Radiobutton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Radiobutton1.Image = Nothing
        Radiobutton1.Location = New System.Drawing.Point(9, 137)
        Radiobutton1.Name = "Radiobutton1"
        Radiobutton1.NoRounding = False
        Radiobutton1.Size = New System.Drawing.Size(84, 14)
        Radiobutton1.TabIndex = 2
        Radiobutton1.Text = "Last_Kmsg"
        Radiobutton1.Transparent = False
        '
        'Radiobutton2
        '
        Radiobutton2.Checked = False
        Radiobutton2.Colors = New One_Clik.Bloom(-1) {}
        Radiobutton2.Customization = ""
        Radiobutton2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Radiobutton2.Image = Nothing
        Radiobutton2.Location = New System.Drawing.Point(9, 157)
        Radiobutton2.Name = "Radiobutton2"
        Radiobutton2.NoRounding = False
        Radiobutton2.Size = New System.Drawing.Size(100, 14)
        Radiobutton2.TabIndex = 3
        Radiobutton2.Text = "Current Kmsg"
        Radiobutton2.Transparent = False
        '
        'Radiobutton3
        '
        Radiobutton3.Checked = False
        Radiobutton3.Colors = New One_Clik.Bloom(-1) {}
        Radiobutton3.Customization = ""
        Radiobutton3.Font = New System.Drawing.Font("Verdana", 8.0!)
        Radiobutton3.Image = Nothing
        Radiobutton3.Location = New System.Drawing.Point(9, 177)
        Radiobutton3.Name = "Radiobutton3"
        Radiobutton3.NoRounding = False
        Radiobutton3.Size = New System.Drawing.Size(60, 14)
        Radiobutton3.TabIndex = 4
        Radiobutton3.Text = "Logcat"
        Radiobutton3.Transparent = False


        '
        'NumericUpDown1
        '


        RD = {Radiobutton1, Radiobutton2, Radiobutton3}

        Dim CS As Control()
        CS = {Radiobutton1, Radiobutton2, Radiobutton3}
        GroupBox1.Controls.AddRange(CS)
    End Sub
    Private Sub ScreenShotD()

        Dim Label1 As New Label
        Label1.BackColor = System.Drawing.Color.Transparent
        Label1.ForeColor = System.Drawing.Color.White
        Label1.Location = New System.Drawing.Point(6, 117)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(190, 260)
        Label1.TabIndex = 3
        Label1.Text = "ScreenShot" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Press Perform Action" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "And Watch The Magic Happen"
        Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        Dim CS As Control()
        CS = {Label1}
        LB = {Label1}
        GroupBox1.Controls.AddRange(CS)

    End Sub
#End Region

#Region "functions"

    Private Sub Starter(ByVal process As String, ByVal param As String(), Optional ByVal Sec As Integer = 60, Optional ByVal timing As Integer = 3)
        numOutputLines = 0
        ' Initialize the process and its StartInfo properties.
        ' The sort command is a console application that
        ' reads and sorts text input.
        Dim sortProcess As New Process()
        sortProcess.StartInfo.WorkingDirectory = Application.StartupPath
        sortProcess.StartInfo.FileName = process
        Dim args As String = ""
        For Each arg In param
            args &= """" & arg & """ "
        Next
        args = args.Trim()
        sortProcess.StartInfo.Arguments = args.ToLower

        ' Set UseShellExecute to false for redirection.
        sortProcess.StartInfo.UseShellExecute = False
        sortProcess.StartInfo.CreateNoWindow = True

        ' Redirect the standard output of the sort command.  
        ' Read the stream asynchronously using an event handler.
        sortProcess.StartInfo.RedirectStandardOutput = True
        sortProcess.StartInfo.RedirectStandardError = True
        sortOutput = New StringBuilder()

        ' Set our event handler to asynchronously read the sort output.
        AddHandler sortProcess.OutputDataReceived, AddressOf SortOutputHandler
        AddHandler sortProcess.ErrorDataReceived, AddressOf SortOutputHandler
        ' Redirect standard input as well.  This stream
        ' is used synchronously.
        ' sortProcess.StartInfo.RedirectStandardInput = True

        ' Start the process.
        sortProcess.Start()

        ' Use a stream writer to synchronously write the sort input.

        ' Start the asynchronous read of the sort output stream.
        sortProcess.BeginOutputReadLine()
        sortProcess.BeginErrorReadLine()

        ' PROMpt the user for input text lines.  Write each 
        ' line to the redirected input stream of the sort command.


        ' Wait for the sort process to write the sorted text lines.
        Dim counter As Integer = 0
dly:

        Do Until sortProcess.HasExited
            Delay(5)
            counter += 5
            If counter >= Sec Then
                If sortProcess.HasExited = False Then
                    '''' Force Close???
                    'Sec = 30
                    If MsgBox2("Not Responding", "This Operation is taking longer than usually" & vbNewLine _
                               & "Do You Want To Stop it?? (I Recommend No)" & vbNewLine _
                               & "If not you will be promted again in 30 seconds.", "Yes", "No") Then
                        Delay(5)
                        Exit Do
                    Else
                        counter = 30
                        GoTo dly
                    End If
                End If
            End If
        Loop

        sortProcess.Close()
        Delay(timing)
    End Sub
    Private Sub StartS(ByVal process As String, ByVal param As String(), Optional ByVal Sec As Integer = 60, Optional ByVal timing As Integer = 3)
        Starter(process, param, Sec, timing)
        If numOutputLines <> 0 Then
            TextBox1.Text &= "[" & Date.Now & "] " & sortOutput.ToString

        Else
            TextBox1.Text &= "[" & Date.Now & "] " & "Nothing Returned" + vbNewLine
        End If


    End Sub
    Private Sub StartR1(ByVal process As String, ByVal param As String(), Optional ByVal Sec As Integer = 60, Optional ByVal timing As Integer = 3)
        numOutputLines = 0
        ' Initialize the process and its StartInfo properties.
        ' The sort command is a console application that
        ' reads and sorts text input.
        Dim sortProcess As New Process()
        sortProcess.StartInfo.WorkingDirectory = Application.StartupPath
        sortProcess.StartInfo.FileName = process
        Dim args As String = ""
        For Each arg In param
            args &= """" & arg & """ "
        Next
        args = args.Trim()
        sortProcess.StartInfo.Arguments = args

        ' Set UseShellExecute to false for redirection.
        sortProcess.StartInfo.UseShellExecute = False
        sortProcess.StartInfo.CreateNoWindow = True

        ' Redirect the standard output of the sort command.  
        ' Read the stream asynchronously using an event handler.
        sortProcess.StartInfo.RedirectStandardOutput = True
        sortProcess.StartInfo.RedirectStandardError = True
        sortOutput = New StringBuilder()

        ' Set our event handler to asynchronously read the sort output.
        AddHandler sortProcess.OutputDataReceived, AddressOf SortOutputHandler
        AddHandler sortProcess.ErrorDataReceived, AddressOf SortOutputHandler
        ' Redirect standard input as well.  This stream
        ' is used synchronously.
        ' sortProcess.StartInfo.RedirectStandardInput = True

        ' Start the process.
        sortProcess.Start()

        ' Use a stream writer to synchronously write the sort input.

        ' Start the asynchronous read of the sort output stream.
        sortProcess.BeginOutputReadLine()
        sortProcess.BeginErrorReadLine()

        ' PROMpt the user for input text lines.  Write each 
        ' line to the redirected input stream of the sort command.


        ' Wait for the sort process to write the sorted text lines.
        Dim counter As Integer = 0
dly:

        Do Until sortProcess.HasExited
            Delay(5)
            counter += 5
            If counter >= Sec Then
                If sortProcess.HasExited = False Then
                    '''' Force Close???
                    'Sec = 30
                    If MsgBox2("Not Responding", "This Operation is taking longer than usually" & vbNewLine _
                               & "Do You Want To Stop it?? (I Recommend No)" & vbNewLine _
                               & "If not you will be promted again in 30 seconds.", "Yes", "No") Then
                        Delay(5)
                        Exit Do
                    Else
                        counter = 30
                        GoTo dly
                    End If
                End If
            End If
        Loop

        sortProcess.Close()
        Delay(timing)



    End Sub
    Private Function StartR(ByVal process As String, ByVal param As String(), Optional ByVal Sec As Integer = 60, Optional ByVal timing As Integer = 3) As String
        Starter(process, param, Sec, timing)
        If numOutputLines <> 0 Then
            Return sortOutput.ToString
        Else
            Return ""
        End If


    End Function
    Private Shared sortOutput As StringBuilder = Nothing
    Private Shared numOutputLines As Integer = 0
    Private Sub SortOutputHandler(sendingProcess As Object, _
       outLine As DataReceivedEventArgs)

        ' Collect the sort command output.
        If Not String.IsNullOrEmpty(outLine.Data) Then
            numOutputLines += 1
            sortOutput.AppendLine(outLine.Data)
        End If
    End Sub

    Private Sub Delay(ByVal dblSecs As Double)
        Const OneSec As Double = 1.0# \ (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents() ' Allow windows messages to be processed
        Loop

    End Sub

    Private Function MsgBox2(ByVal title As String, ByVal msg As String, Optional YES As String = "Ok", Optional No As String = "Cancel")
        Dim ok As New Dialog1(title, msg, YES, No)
        ok.ShowDialog()
        If ok.DialogResult = System.Windows.Forms.DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub excpt(ByRef ex As Exception)

        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath + "\crash\") = False Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath + "\crash\")
        End If
        Dim strw2 As New StreamWriter(Application.StartupPath + "\crash\crash." + Date.Now.Date.ToShortDateString.Replace("/", ".") + ".txt", True, Encoding.UTF8)
        strw2.WriteLine("----------------" + Date.Now + "----------------")
        strw2.WriteLine(ex.Message.ToString)
        strw2.WriteLine(ex.StackTrace.ToString)
        strw2.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            TextBox1.SelectionStart = TextBox1.Text.Length - 1
            TextBox1.SelectionLength = 0
            TextBox1.ScrollToCaret()
        Catch ex As Exception

        End Try

    End Sub

    Private Function AFI(Optional ByVal display As Boolean = True) As String
        Dim ADB As String = StartR("apps\adb.exe", {"devices"}, 60, 0).ToLower
        If ADB.Contains("	device") Then
            If display Then
                PhoneM.Text = "ADB"
            End If
            Return "ADB"
        ElseIf ADB.Contains("recovery") Then
            If display Then
                PhoneM.Text = "ADB - Recovery"
            End If
            Return "ADB - Recovery"
        ElseIf StartR("apps\fastboot.exe", {"devices"}, 60, 0).ToLower.Contains("fastboot") Then
            If display Then
                PhoneM.Text = "Fastboot"
            End If
            Return "Fastboot"
        Else
            If display Then
                PhoneM.Text = "Not Connected"
            End If
            Return "None"

        End If
        Return "None"


    End Function

    Private Sub Completion(ByRef ComboBox4 As String)

        Dim ADF As String = AFI()
        If ComboBox4 <> Nothing Then
            If ComboBox4 = "Reboot" Then
                If ADF.Contains("ADB") Then
                    MSG("Rebooting")
                    StartR("apps\adb.exe", {"Reboot"})
                ElseIf ADF = "Fastboot" Then
                    MSG("Rebooting")
                    StartR("apps\fastboot.exe", {"Reboot"})
                End If
            ElseIf ComboBox4 = "Bootloader" Then
                If ADF.Contains("ADB") Then
                    MSG("Booting into Bootloader")
                    StartR("apps\adb.exe", {"Reboot-bootloader"})
                ElseIf ADF = "Fastboot" Then
                    MSG("Booting into Bootloader")
                    StartR("apps\fastboot.exe", {"Reboot-bootloader"})
                End If
            ElseIf ComboBox4.Contains("Recovery") Then
                If ADF.Contains("ADB") Then
                    If ADF = "ADB" Then
                        MSG("Booting into Recovery")
                        StartR("apps\adb.exe", {"Reboot", "recovery"})
                    End If
                ElseIf ADF = "Fastboot" Then
                    StartR("apps\fastboot.exe", {"fastboot", "boot", "recoveries\recovery.img"})
                    MSG("Booting Into Recovery")
                    StartR("apps\adb.exe", {"Reboot", "recovery"})
                End If
            End If
        End If
    End Sub

    Private Function ShortCut(ByVal arg As String)
        Dim ShortCutPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.Startup)
        Dim VbsObj As Object
        Dim ss As String = (Application.ExecutablePath).ToString
        VbsObj = CreateObject("WScript.Shell")

        Dim MyShortcut As Object
        ShortCutPath = VbsObj.SpecialFolders(ShortCutPath)
        MyShortcut = VbsObj.CreateShortcut(System.Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\OXOC.lnk")
        MyShortcut.TargetPath = ss
        MyShortcut.Arguments = arg

        MyShortcut.Save()
        Return Nothing

    End Function

    Private Sub CheckChanged(sender As Object)
        Dim radio As Radiobutton = sender
        If radio.Name = "RadioButton1" And radio.Checked Then
            If ListBox1.SelectedItem.ToString = "Kernel Repack" Then ''Single Repack
                CheckB(1).Visible = True
                LB(5).Visible = False

            Else ''''Multirepack
                CheckB(0).Visible = True
                LB(4).Visible = False
                CB(2).Visible = True
                LB(2).Visible = True
            End If

        Else
            If ListBox1.SelectedItem.ToString = "Kernel Repack" Then ''Single Repack
                CheckB(1).Visible = False
                LB(5).Visible = True

            Else ''''Multirepack

                CheckB(0).Visible = False
                LB(4).Visible = True
                CB(2).Visible = False
                LB(2).Visible = False
            End If

        End If

    End Sub



    Private Sub StartCustom(ByVal process As String, ByVal param As String(), Optional ByVal Sec As Integer = 60, Optional ByVal timing As Integer = 3)
        numOutputLines = 0
        ' Initialize the process and its StartInfo properties.
        ' The sort command is a console application that
        ' reads and sorts text input.
        Dim sortProcess As New Process()
        sortProcess.StartInfo.WorkingDirectory = Application.StartupPath
        sortProcess.StartInfo.FileName = "apps\redirect.exe"
        Dim args As String = ""
        For Each arg In param
            args &= """" & arg & """ "
        Next
        args = args.Trim()
        sortProcess.StartInfo.Arguments = process & "," & args.ToLower


        sortProcess.Start()


    End Sub
    Private Function SaveLog(ByVal Name As String, ByRef Log As String)
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath + "\Logs\") = False Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath + "\Logs\")
        End If
        Dim strw2 As New StreamWriter(Application.StartupPath + "\Logs\" & Name & "." + Date.Now.Date.ToShortDateString.Replace("/", ".") + ".txt", True, Encoding.UTF8)
        strw2.WriteLine("----------------" + Date.Now + "----------------")
        strw2.WriteLine(Log)
        strw2.Close()
        Return Application.StartupPath + "\Logs\" & Name & "." + Date.Now.Date.ToShortDateString.Replace("/", ".") + ".txt"
    End Function

    Private Sub SortOutputHandler2(sendingProcess As Object, _
        outLine As DataReceivedEventArgs)

        ' Collect the sort command output.
        If Not String.IsNullOrEmpty(outLine.Data) Then
            numOutputLines += 1
            Dim Deleg As New TB4D(AddressOf TB4)
            Invoke(Deleg, outLine.Data)
            ' TextBox1.Text &= (outLine.Data) & vbNewLine
            If numOutputLines > 1000 Then
                StartR("app\adb.exe", {"kill-server"})
            End If
        End If
    End Sub

    Private Delegate Sub TB4D(ByRef text As String)
    Private Sub TB4(ByRef text As String)
        TextBox1.Text &= (text) & vbNewLine
    End Sub

    Private Sub ClearTMP()
        Delay(2)
        If Not Directory.Exists("TMP") Then
            Return
        End If
        Dim files() As String
        files = Directory.GetFileSystemEntries("TMP")
        For Each element As String In files
            'Do not clear sub directories
            If (Not Directory.Exists(element)) Then
                Try
                    File.Delete(Path.Combine("TMP", Path.GetFileName(element)))
                Catch ex As Exception
                End Try

            End If
        Next
    End Sub

    Private Sub GetBatt(ByVal Mode As String)
        If Mode = "ADB" Then
            Batt.Text = StartR("apps\adb.exe", {"shell", "cat", "/sys/class/power_supply/battery/capacity"}).Split(vbNewLine)(0) & "%"
        Else
            Batt.Text = StartR("apps\fastboot.exe", {"getvar", "devpower"}).Replace("devpower: ", "").Split(vbNewLine)(0) & "%"
        End If
    End Sub
    Private Sub Asso(sender As Object, e As EventArgs)
        If CheckB(0).Checked Then
            My.Computer.Registry.ClassesRoot.CreateSubKey(".img").SetValue("", "IMG", Microsoft.Win32.RegistryValueKind.String)
            My.Computer.Registry.ClassesRoot.CreateSubKey("Img\shell\open\command").SetValue("", Application.ExecutablePath & " ""%l"" ", Microsoft.Win32.RegistryValueKind.String)
        End If
    End Sub
    Private Sub AtBoot(sender As Object, e As EventArgs)
        StartupTSMI.Checked = CheckB(1).Checked
        If CheckB(1).Checked Then
            ShortCut("-startup")
        Else
            If My.Computer.FileSystem.FileExists(System.Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\OXOC.lnk") Then
                My.Computer.FileSystem.DeleteFile(System.Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\OXOC.lnk")
            End If
        End If
    End Sub
#End Region

#Region "UI"
    Declare Function AllocConsole Lib "kernel32" () As Integer
    Declare Function FreeConsole Lib "kernel32" () As Integer
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click


        Dim strw2 As New StreamWriter(Application.StartupPath + "\Log\Log." + Date.Now.Date.ToShortDateString.Replace("/", ".") + ".txt", True, Encoding.UTF8)
        strw2.WriteLine(TextBox1.Text)
        strw2.Close()

    End Sub

    Private Sub PhoneStat_Tick(sender As System.Object, e As System.EventArgs)
        If Button1.Enabled Then
            PhoneStat.Stop()
            AFI()
            PhoneStat.Start()
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        TextBox1.Clear()
    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles XClose.Click
        If MsgBox2("Closing", "Are You Sure You Want To Quit?", "Yes", "No") Then
            Application.Exit()
            OXOC.Visible = False
            Visible = False
        End If

    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Mini.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TextBox1_MouseHover(sender As System.Object, e As System.EventArgs) Handles TextBox1.MouseHover
        Me.Refresh()
        TextBox1.Refresh()
    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles About.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub Help_Click(sender As Object, e As EventArgs) Handles Help.Click
        Dim HelpM As Dialog2 = Nothing
        If ListBox1.SelectedItem = "Flash Kernel" Then
            HelpM = New Dialog2("Make Sure You Have The Kernel In The Kernels Folder As An IMG" & vbNewLine & _
 "Modules Are Not Really Optional unless The Kernel Developer stated He Used The Same Modules As The ROM Or His Previous Work, Place The As A Zip In The Modules Folder" & vbNewLine & _
"Choose What Action You What When The Process Is Over" & vbNewLine & "Click Perform Action And Wait." & vbNewLine & vbNewLine)
        ElseIf ListBox1.SelectedItem = "Flash Recovery" Then
            HelpM = New Dialog2("Make Sure You Have The Recovery In The Recoveries Folder As An IMG" & vbNewLine & _
 "Modules Are Not Really Optional unless The Kernel Developer stated He Used The Same Modules As The ROM Or His Previous Work" & vbNewLine & _
"Choose What Action You What When The Process Is Over" & vbNewLine & "Click Perform Action And Wait." & vbNewLine & vbNewLine)
        ElseIf ListBox1.SelectedItem = "Help" Then

        ElseIf ListBox1.SelectedItem = "Kernel Repack" Then
            HelpM = New Dialog2("Make Sure You Have The Kernel In The Kernels Folder As An IMG" & vbNewLine & _
 "The RamDisk Is Actually Just The Kernel You Want The RamDisk FROM (As An IMG ofc), In The Kernels Folder" & vbNewLine & _
"Choose What Action You What When The Process Is Over" & vbNewLine & "Click Perform Action And Wait, " & vbNewLine & "The Repacked Are Pulled In A Folder Called Repacked Beside This App, If That Option Is Enabled." & vbNewLine & vbNewLine)
        ElseIf ListBox1.SelectedItem = "MultiKernel Repack" Then
            HelpM = New Dialog2("This Performs The Same As Repack But Allows Multiple Repacking At Once, Good For Those Who Repack Kernels For Different ROMs/Kernels" & vbNewLine & "Make Sure You Have The Kernel In The Kernels Folder As An IMG" & vbNewLine & _
 "The RamDisk Is Actually Just The Kernel You Want The RamDisk FROM (As An IMG ofc), In The Kernels Folder" & vbNewLine & _
"Choose What Action You What When The Process Is Over" & vbNewLine & "Click Perform Action And Wait, " & vbNewLine & "The Repacked Are Pulled In A Folder Called Repacked Beside This App, If That Option Is Enabled." & vbNewLine & vbNewLine & vbNewLine & vbNewLine)
        ElseIf ListBox1.SelectedItem = "RUU - Advance" Then
            HelpM = New Dialog2("This Allows Flashing Zips Through Ruu Without HTC's RUU" & vbNewLine & _
"If You Dont Know What This Is You Should Avoid It" & vbNewLine & _
"Normal RUU Operation Applies," & vbNewLine & "I.E: Relock Required, Correct CID, etc" & vbNewLine & "Click Perform Action And Wait.")
        ElseIf ListBox1.SelectedItem = "Root" Then
            HelpM = New Dialog2("One Root Click As Long As You Have Recovery Installed Or HBoot Higher Than 0.43 With Recovery.img In The Recovery Folder" & vbNewLine & _
"Choose What Action You What When The Process Is Over" & vbNewLine & "Click Perform Action And Wait.")
        ElseIf ListBox1.SelectedItem = "Erase Cache" Then
            HelpM = New Dialog2("Will Erase Your Cache" & vbNewLine & _
"Choose What Action You What When The Process Is Over" & vbNewLine & "Click Perform Action And Wait.")
        ElseIf ListBox1.SelectedItem = "Reboot Into..." Then
            HelpM = New Dialog2("Choose Whether You Want To Reboot The Phone,Boot Into Recovery Or Fastboot")
        ElseIf ListBox1.SelectedItem = "Lock/Unlock" Then
            If RD(0).Checked Then
                HelpM = New Dialog2("To Unlock Your Phone You Need Unlock_Code.bin Which You Get FROM HTCDev," & vbNewLine & " Please Dont Ask Me How," & vbNewLine & "Note That HTC States To Void Your Warrenty Upon Unlock," & vbNewLine & "While Unlocking Your Device Will Give You Access To Top Class ROMs And Kernels.")
            Else
                HelpM = New Dialog2("Relocking Your Phone Will Cause You To Loss Access To Custom ROMs And Recoveries." & vbNewLine & "Note That You Will Not Even Be Able To Boot Into Your Current Installed Custom ROM Or Recovery," & vbNewLine & "You'll Need To Flash Stock Recovery And ROM")
            End If
        ElseIf ListBox1.SelectedIndex = -1 Then
            HelpM = New Dialog2("Select An Option And Click ? To Get Some Pointers")
        End If
        Try
            HelpM.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Radiobutton_CheckedChanged(sender As Object)
        If RD(0).Checked Then
            CB(1).Enabled = True : CB(1).Visible = True : LB(1).Visible = True
            CB(0).Enabled = False : CB(0).Visible = False : LB(0).Visible = False
        Else
            CB(0).Enabled = True : CB(0).Visible = True : LB(0).Visible = True
            CB(1).Enabled = False : CB(1).Visible = False : LB(1).Visible = False
        End If
    End Sub

    Private Sub OXOC_MouseClick(sender As Object, e As MouseEventArgs) Handles OXOC.MouseDoubleClick
        Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub



    Private Sub StartupTSMI_Click(sender As Object, e As EventArgs) Handles StartupTSMI.Click
        If StartupTSMI.Checked Then
            My.Computer.FileSystem.DeleteFile(System.Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\OXOC.lnk")
            StartupTSMI.Checked = False
        Else
            StartupTSMI.Checked = True
            ShortCut("-startup")
        End If
    End Sub

    Private Sub ExitTSMI_Click(sender As Object, e As EventArgs) Handles ExitTSMI.Click
        If MsgBox2("Closing", "Are You Sure You Want To Quit?", "Yes", "No") Then
            Application.Exit()
        End If
    End Sub

    Private Sub RestoreTSMI_Click(sender As Object, e As EventArgs) Handles RestoreTSMI.Click
        If Visible Then
            Visible = False
        Else
            Visible = True
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

#End Region

   

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        OXOC.Visible = False
        Visible = False
        StartR("apps\adb.exe", {"kill-server"})
    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Visible = False
        End If
    End Sub

    Private Sub PhoneDetection_Tick(sender As Object, e As EventArgs) Handles PhoneDetection.Tick
        If Button1.Enabled Then
            Dim ADF As String = AFI()
            If Found = False Then
                If ADF = "ADB" Then
                    OXOC.ShowBalloonTip(20, "Detection", "Your Phone Has Been Connected", ToolTipIcon.Info)
                    GetBatt("ADB")
                ElseIf ADF = "ADB - Recovery" Then
                    OXOC.ShowBalloonTip(20, "Detection", "Your Phone Has Been Connected", ToolTipIcon.Info)
                    GetBatt("ADB")
                ElseIf ADF = "Fastboot" Then
                    OXOC.ShowBalloonTip(20, "Detection", "Your Phone Has Been Connected", ToolTipIcon.Info)
                    GetBatt("Fastboot")
                End If
                If ADF <> "None" Then
                    Found = True
                End If
            Else
                If ADF = "None" Then
                    Found = False
                    Batt.Text = "NaN%"
                    OXOC.ShowBalloonTip(20, "Detection", "Your Phone Has Been Disconnected", ToolTipIcon.Info)
                ElseIf ADF = "ADB" Then
                    GetBatt("ADB")
                ElseIf ADF = "ADB - Recovery" Then
                    GetBatt("ADB")
                ElseIf ADF = "Fastboot" Then
                    GetBatt("Fastboot")
                End If
                If ADF <> "None" Then
                    Found = True
                End If
            End If
        End If
        PhoneDetection.Start()
    End Sub


    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs)
        Dim senderComboBox As ComboBox = DirectCast(sender, ComboBox)
        Dim width As Integer = senderComboBox.DropDownWidth
        Dim g As Graphics = senderComboBox.CreateGraphics()
        Dim font As Font = senderComboBox.Font
        Dim vertScrollBarWidth As Integer = If((senderComboBox.Items.Count > senderComboBox.MaxDropDownItems), SystemInformation.VerticalScrollBarWidth, 0)

        Dim newWidth As Integer
        For Each s As String In DirectCast(sender, ComboBox).Items
            newWidth = CInt(g.MeasureString(s, font).Width) + vertScrollBarWidth
            If width < newWidth Then
                width = newWidth
            End If
        Next
        senderComboBox.DropDownWidth = width
    End Sub

    Private Sub GroupBox1_DragDrop(sender As Object, e As DragEventArgs) Handles GroupBox1.DragDrop
        Stat.Text = ""
        If e.Data.GetData("FileDrop", False)(0).ToString.ToLower.EndsWith(".zip") Then

            Dim CopyMove As New Dialog1("Copy/Move", "Would you like to Copy/Move" & vbNewLine & _
                                  e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1) & vbNewLine & _
                                  "To The Module Folder??", "Copy", "Move")

            CopyMove.ShowDialog()
            Dim OverWrite As New Dialog1("Overwrite", "Module Already Exist!!" & vbNewLine & _
                                e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1) & vbNewLine & _
                                "Do You Want To Overwrite it??", "Yes", "No")
            If My.Computer.FileSystem.FileExists("Modules\" & e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1)) Then
                OverWrite.ShowDialog()
                If OverWrite.DialogResult <> Windows.Forms.DialogResult.OK Then
                    MSG("Operation Cancelled!!")
                    Exit Sub
                End If
            End If


            If CopyMove.DialogResult = Windows.Forms.DialogResult.OK Then
                ''''Copy

                Try
                    My.Computer.FileSystem.CopyFile(e.Data.GetData("FileDrop", False)(0).ToString, Application.StartupPath & "\Modules\" & e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1), True)
                    MSG("Successfully Copyied Module " & e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1) & " To Module Folder")
                Catch ex As Exception
                    MSG("Error Has Occurred During Process, Please Try Again!!")

                End Try
            ElseIf CopyMove.DialogResult = Windows.Forms.DialogResult.Cancel Then
                ''''Move
                Try
                    My.Computer.FileSystem.MoveFile(e.Data.GetData("FileDrop", False)(0).ToString, Application.StartupPath & "\Modules\" & e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1), True)
                    MSG("Successfully Moved Module " & e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1) & " To Module Folder")
                Catch ex As Exception
                    MSG("Error Has Occurred During Process, Please Try Again!!")
                    TextBox1.Text &= "[" & Date.Now & "] Module Zip COULD Have Been Accessed By Another Process!!" & vbNewLine
                    TextBox1.Text &= "[" & Date.Now & "] Module Zip Close That First!!" & vbNewLine
                End Try
            Else
                ''''Cancel
                MSG("Operation Cancelled!!")
                Exit Sub
            End If


        ElseIf e.Data.GetData("FileDrop", False)(0).ToString.ToLower.EndsWith(".img") Then
            Dim CopyMove As New Dialog1("Copy/Move", "Would you like to Copy/Move" & vbNewLine & _
                                  e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1) & vbNewLine & _
                                  "To The Kernels Folder??", "Copy", "Move")

            CopyMove.ShowDialog()
            Dim OverWrite As New Dialog1("Overwrite", "Kernel Already Exist!!" & vbNewLine & _
                                e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1) & vbNewLine & _
                                "Do You Want To Overwrite it??", "Yes", "No")
            If My.Computer.FileSystem.FileExists("Kernels\" & e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1)) Then
                OverWrite.ShowDialog()
                If OverWrite.DialogResult <> Windows.Forms.DialogResult.OK Then
                    MSG("Operation Cancelled!!")
                    Exit Sub
                End If
            End If


            If CopyMove.DialogResult = Windows.Forms.DialogResult.OK Then
                ''''Copy

                Try
                    My.Computer.FileSystem.CopyFile(e.Data.GetData("FileDrop", False)(0).ToString, Application.StartupPath & "\Kernels\" & e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1), True)
                    MSG("Successfully Copyied Kernel " & e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1) & " To Kernel Folder")
                Catch ex As Exception
                    MSG("Error Has Occurred During Process, Please Try Again!!")

                End Try
            ElseIf CopyMove.DialogResult = Windows.Forms.DialogResult.Cancel Then
                ''''Move
                Try
                    My.Computer.FileSystem.MoveFile(e.Data.GetData("FileDrop", False)(0).ToString, Application.StartupPath & "\Kernels\" & e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1), True)
                    MSG("Successfully Moved Kernel " & e.Data.GetData("FileDrop", False)(0).ToString.Split("\")(e.Data.GetData("FileDrop", False)(0).ToString.Split("\").Length - 1) & " To Kernel Folder")
                Catch ex As Exception
                    MSG("Error Has Occurred During Process, Please Try Again!!")
                    TextBox1.Text &= "[" & Date.Now & "] Kernel COULD Have Been Accessed By Another Process!!" & vbNewLine
                    TextBox1.Text &= "[" & Date.Now & "] Kernel Close That First!!" & vbNewLine
                End Try
            Else
                ''''Cancel
                MSG("Operation Cancelled!!")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub GroupBox1_DragEnter(sender As Object, e As DragEventArgs) Handles GroupBox1.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
           
            e.Effect = DragDropEffects.All
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

 
End Class
