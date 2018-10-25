Module BoxHandler
    Public BoxClient As VirtualBox.VirtualBoxClient

    Public Sub StartMachine(ByRef Machine As VirtualBox.IMachine, ByVal SessionName As String)
        If Not (Machine.State = VirtualBox.MachineState.MachineState_PoweredOff Or Machine.State = VirtualBox.MachineState.MachineState_Aborted Or Machine.State = VirtualBox.MachineState.MachineState_Saved) Then
            Exit Sub
        End If
        Try
            Machine.LaunchVMProcess(BoxClient.Session, SessionName, "")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, LocalizeString("error"))
        End Try
    End Sub
    Structure MachineListItem
        Dim Machine As VirtualBox.IMachine
        Public Overrides Function ToString() As String
            If Not (Machine.State = VirtualBox.MachineState.MachineState_PoweredOff Or Machine.State = VirtualBox.MachineState.MachineState_Aborted Or Machine.State = VirtualBox.MachineState.MachineState_Saved) Then
                Return Machine.Name & "(running or busy)"
            End If
            Return Machine.Name
        End Function
    End Structure
End Module
