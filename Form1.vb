Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "VirtualBoxAccessableStarter (VirtualBox V " & BoxClient.VirtualBox.Version & ")"
        For Each Machine In BoxClient.VirtualBox.Machines
            Dim MachineItem As MachineListItem
            MachineItem.Machine = Machine
            Me.ListBox1.Items.Add(MachineItem)
        Next
        Me.RefreshTimer.Start()
    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ListBox1.SelectedItem Is Nothing Then
                Exit Sub
            End If

            Dim OurItem As MachineListItem
            OurItem = ListBox1.SelectedItem
            StartMachine(OurItem.Machine, "separate")
        End If
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        If ListBox1.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim OurItem As MachineListItem
        OurItem = ListBox1.SelectedItem
        StartMachine(OurItem.Machine, "separate")
    End Sub

    Private Sub ExitMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitMenuItem.Click
        Me.Close()
    End Sub

    Private Sub RefreshMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshMenuItem.Click
        Dim Selindex As Integer = ListBox1.SelectedIndex
        ListBox1.Items.Clear()
        For Each Machine In BoxClient.VirtualBox.Machines
            Dim MachineItem As MachineListItem
            MachineItem.Machine = Machine
            Me.ListBox1.Items.Add(MachineItem)
        Next
        Try
            ListBox1.SelectedIndex = Selindex
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AccessableRunMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccessableRunMenuItem.Click
        If ListBox1.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim OurItem As MachineListItem
        OurItem = ListBox1.SelectedItem
        StartMachine(OurItem.Machine, "separate")
    End Sub

    Private Sub StandardRunMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardRunMenuItem.Click
        If ListBox1.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim OurItem As MachineListItem
        OurItem = ListBox1.SelectedItem
        StartMachine(OurItem.Machine, "gui")
    End Sub

    Private Sub BackgroundRunMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackgroundRunMenuItem.Click
        If ListBox1.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim OurItem As MachineListItem
        OurItem = ListBox1.SelectedItem
        StartMachine(OurItem.Machine, "headless")
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox1.ContextMenuStrip = Nothing
        If ListBox1.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim OurItem As MachineListItem
        OurItem = ListBox1.SelectedItem
        If (OurItem.Machine.State = VirtualBox.MachineState.MachineState_Aborted Or OurItem.Machine.State = VirtualBox.MachineState.MachineState_PoweredOff Or OurItem.Machine.State = VirtualBox.MachineState.MachineState_Saved) Then
            ListBox1.ContextMenuStrip = StopMachineContextMenu
            Exit Sub
        End If
    End Sub

    Private Sub ResetStateMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetStateMenuItem.Click
        If ListBox1.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim OurItem As MachineListItem
        OurItem = ListBox1.SelectedItem
        If Not OurItem.Machine.State = VirtualBox.MachineState.MachineState_Saved Then
            Exit Sub
        End If
        Dim MachineTempSession As VirtualBox.ISession
        MachineTempSession = BoxClient.Session
        Try
            OurItem.Machine.LockMachine(MachineTempSession, VirtualBox.LockType.LockType_Write)
            MachineTempSession.Machine.DiscardSavedState(True)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, LocalizeString("error"))
        End Try
        Try
            MachineTempSession.UnlockMachine()
        Catch ex As Exception

        End Try
        MachineTempSession = Nothing
    End Sub

    
    Private Sub StopMachineContextMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles StopMachineContextMenu.Opening
        If ListBox1.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim OurItem As MachineListItem
        OurItem = ListBox1.SelectedItem
        If OurItem.Machine.State = VirtualBox.MachineState.MachineState_Saved Then
            Me.ResetStateMenuItem.Visible = True
            Me.ResetStateMenuItem.Enabled = True
        End If
    End Sub

    Private Sub StopMachineContextMenu_Closed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles StopMachineContextMenu.Closed
        Me.ResetStateMenuItem.Visible = False
        Me.ResetStateMenuItem.Enabled = False
    End Sub

    Private Sub RefreshTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshTimer.Tick
        Dim Selindex As Integer = ListBox1.SelectedIndex
        ListBox1.Items.Clear()
        For Each Machine In BoxClient.VirtualBox.Machines
            Dim MachineItem As MachineListItem
            MachineItem.Machine = Machine
            Me.ListBox1.Items.Add(MachineItem)
        Next
        Try
            ListBox1.SelectedIndex = Selindex
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SnapshotsManagerMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SnapshotsManagerMenuItem.Click
        If ListBox1.SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim OurItem As MachineListItem
        OurItem = Me.ListBox1.SelectedItem
        Dim SForm As New SnapshotManager
        SForm.MachineToOperate = OurItem.Machine
        SForm.ShowDialog()
    End Sub
End Class
