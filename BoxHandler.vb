Module BoxHandler
    Public Sub StartMachine(ByRef VMachine As String, ByVal SessionName As String)
        Dim VBox As New VirtualBox.VirtualBox
        Dim VSession As New VirtualBox.Session
        Dim Machine As VirtualBox.IMachine
        Machine = VBox.FindMachine(VMachine)
        Machine.LaunchVMProcess(VSession, SessionName, "")
    End Sub
    Public Sub StartVmByName(ByVal VmName As String, ByVal SessionName As String)
        Dim VBX As New VirtualBox.VirtualBox
        Dim OurMachine As VirtualBox.IMachine
        For Each VM As VirtualBox.IMachine In VBX.Machines
            If VM.Name = VmName Then
                OurMachine = VM
                Exit For
            End If
        Next
        Dim OurMachineId As String
        OurMachineId = OurMachine.Id
        StartMachine(OurMachineId, SessionName)
    End Sub
End Module
