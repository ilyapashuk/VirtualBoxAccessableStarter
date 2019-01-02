Public Class SnapshotManager

    Public MachineToOperate As VirtualBox.IMachine
    Public CurrentNode As Windows.Forms.TreeNode
    Private Sub ObserveSnapshot(ByVal SourceShot As VirtualBox.ISnapshot, ByRef NodeToAdd As Windows.Forms.TreeNodeCollection)
        Dim MyNode As New SnapshotTreeNode
        MyNode.Text = SourceShot.Name
        MyNode.NodeSnapshot = SourceShot
        NodeToAdd.Add(MyNode)
        If Not Me.MachineToOperate.CurrentSnapshot Is Nothing Then
            If Me.MachineToOperate.CurrentSnapshot.Id = SourceShot.Id Then
                Dim CurNode As New Windows.Forms.TreeNode(LocalizeString("current state"))
                Me.CurrentNode = CurNode
                MyNode.Nodes.Add(CurNode)
            End If
        End If
        For Each ChildShot In SourceShot.Children
            ObserveSnapshot(ChildShot, MyNode.Nodes)
        Next
    End Sub
    Private Sub ObserveRootSnapshot(ByRef NodeToAdd As Windows.Forms.TreeNodeCollection)
        If Me.MachineToOperate.SnapshotCount = 0 Then
            Dim CurNode As New Windows.Forms.TreeNode(LocalizeString("current state"))
            Me.CurrentNode = CurNode
            NodeToAdd.Add(CurNode)
            Exit Sub
        End If
        Dim SourceShot As VirtualBox.ISnapshot = Me.MachineToOperate.FindSnapshot(Nothing)
        Dim MyNode As New SnapshotTreeNode
        MyNode.Text = SourceShot.Name
        MyNode.NodeSnapshot = SourceShot
        NodeToAdd.Add(MyNode)
        If Not Me.MachineToOperate.CurrentSnapshot Is Nothing Then
            If Me.MachineToOperate.CurrentSnapshot.Id = SourceShot.Id Then
                Dim CurNode As New Windows.Forms.TreeNode(LocalizeString("current state"))
                Me.CurrentNode = CurNode
                MyNode.Nodes.Add(CurNode)
            End If
        End If
        For Each ChildShot In SourceShot.Children
            ObserveSnapshot(ChildShot, NodeToAdd)
        Next
    End Sub

    Private Sub SnapshotManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = LocalizeString("snapshots of") & " " & Me.MachineToOperate.Name
        ObserveRootSnapshot(Me.TreeView1.Nodes)
        If Me.TreeView1.SelectedNode Is Me.CurrentNode Then
            Me.TreeView1.ContextMenuStrip = CurrentStateMenu
        Else
            Me.TreeView1.ContextMenuStrip = SnapshotMenu
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If e.Node Is Me.CurrentNode Then
            Me.TreeView1.ContextMenuStrip = CurrentStateMenu
        Else
            Me.TreeView1.ContextMenuStrip = SnapshotMenu
        End If
    End Sub

    Private Sub TakeMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TakeMenuItem.Click
        Dim ShotName As String = InputBox(LocalizeString("enter the snapshot name"))
        Dim TempSession As VirtualBox.ISession = BoxClient.Session
        Try
            Me.MachineToOperate.LockMachine(TempSession, VirtualBox.LockType.LockType_Shared)
            Dim MId As String
            ObserveProgress(TempSession.Machine.TakeSnapshot(ShotName, "", True, MId))
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "error")
        End Try
        TempSession.UnlockMachine()
        TempSession = Nothing
        Me.TreeView1.Nodes.Clear()
        Me.CurrentNode = Nothing
        ObserveRootSnapshot(Me.TreeView1.Nodes)
        If Me.TreeView1.SelectedNode Is Me.CurrentNode Then
            Me.TreeView1.ContextMenuStrip = CurrentStateMenu
        Else
            Me.TreeView1.ContextMenuStrip = SnapshotMenu
        End If
    End Sub

    Private Sub RestoreMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreMenuItem.Click
        Dim TempSession As VirtualBox.ISession = BoxClient.Session
        Dim OurNode As SnapshotTreeNode
        Try
            OurNode = Me.TreeView1.SelectedNode
        Catch ex As Exception
            Exit Sub
        End Try

        Try
            Me.MachineToOperate.LockMachine(TempSession, VirtualBox.LockType.LockType_Write)
            ObserveProgress(TempSession.Machine.RestoreSnapshot(OurNode.NodeSnapshot))
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "error")
        End Try
        TempSession.UnlockMachine()
        TempSession = Nothing
        Me.TreeView1.Nodes.Clear()
        Me.CurrentNode = Nothing
        ObserveRootSnapshot(Me.TreeView1.Nodes)
        If Me.TreeView1.SelectedNode Is Me.CurrentNode Then
            Me.TreeView1.ContextMenuStrip = CurrentStateMenu
        Else
            Me.TreeView1.ContextMenuStrip = SnapshotMenu
        End If

    End Sub

    Private Sub DeleteMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMenuItem.Click
        Dim TempSession As VirtualBox.ISession = BoxClient.Session
        Dim OurNode As SnapshotTreeNode
        Try
            OurNode = Me.TreeView1.SelectedNode
        Catch ex As Exception
            Exit Sub
        End Try

        Try
            Me.MachineToOperate.LockMachine(TempSession, VirtualBox.LockType.LockType_Write)
            ObserveProgress(TempSession.Machine.DeleteSnapshot(OurNode.NodeSnapshot.Id))
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "error")
        End Try
        TempSession.UnlockMachine()
        TempSession = Nothing
        Me.TreeView1.Nodes.Clear()
        Me.CurrentNode = Nothing
        ObserveRootSnapshot(Me.TreeView1.Nodes)
        If Me.TreeView1.SelectedNode Is Me.CurrentNode Then
            Me.TreeView1.ContextMenuStrip = CurrentStateMenu
        Else
            Me.TreeView1.ContextMenuStrip = SnapshotMenu
        End If

    End Sub
End Class