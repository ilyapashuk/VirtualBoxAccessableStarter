Module MainContent
    Public VBoxManagePath As String
    Public VmsList As List(Of String)
    Sub Main()
        If System.IO.File.Exists("VBoxManage.exe") Then
            VBoxManagePath = System.IO.Path.Combine(CurDir, "VBoxManage.exe")
        Else
            VBoxManagePath = "C:\Program Files\Oracle\VirtualBox\VBoxManage.exe"
        End If
        If Not System.IO.File.Exists(VBoxManagePath) Then
            MsgBox("error: can not found VBoxManage command line utility. make shure that the VirtualBox is installed to default path. if it's files placed in other location, you should place utility in same location with VirtualBox files.", "error", vbCritical)
            End
        End If
        Dim VBoxManageListingProcess As New Process
        VBoxManageListingProcess.StartInfo.FileName = VBoxManagePath
        VBoxManageListingProcess.StartInfo.Arguments = "list vms"
        VBoxManageListingProcess.StartInfo.UseShellExecute = False
        VBoxManageListingProcess.StartInfo.CreateNoWindow = True
        VBoxManageListingProcess.StartInfo.RedirectStandardOutput = True
        Dim VBoxOutput As String
        VBoxManageListingProcess.Start()
        VBoxOutput = VBoxManageListingProcess.StandardOutput.ReadToEnd()
        VBoxManageListingProcess.WaitForExit()
        Dim VBoxOutputLines As String()
        VBoxOutputLines = StringToLinesArray(VBoxOutput)
        VmsList = New List(Of String)
        For Each VmLine In VBoxOutputLines
            Dim TempChars As New List(Of Char)
            Dim LineChars As Char()
            LineChars = VmLine.ToCharArray()
            Dim QuoteHandeled As Boolean = False
            For Each VCharObj In LineChars
                If VCharObj = Chr(34) Then
                    If QuoteHandeled Then
                        Exit For
                    End If
                    QuoteHandeled = True
                    Continue For
                End If
                TempChars.Add(VCharObj)
            Next
            Dim ResultName As String
            Dim ResultCharStrings As New List(Of String)
            For Each TempChar In TempChars
                ResultCharStrings.Add(TempChar.ToString)
            Next
            ResultName = String.Join("", ResultCharStrings.ToArray())
            VmsList.Add(ResultName)
        Next
        Form1.ShowDialog()
    End Sub

    Public Function StringToLinesArray(ByVal SourceData As String) As String()
        Dim PreservedSourceData As String
        PreservedSourceData = SourceData.Replace(vbCr, "")
        Dim ResultArray As String()
        ResultArray = PreservedSourceData.Split(vbLf)
        Return ResultArray
    End Function
    Public Sub StartVmByName(ByVal VmName As String)
        Dim VStartProcess As New Process
        VStartProcess.StartInfo.FileName = VBoxManagePath
        VStartProcess.StartInfo.Arguments = "startvm " & Chr(34) & VmName & Chr(34) & " --type separate"
        VStartProcess.Start()
    End Sub
End Module
