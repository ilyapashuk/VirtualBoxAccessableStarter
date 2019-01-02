<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SnapshotManager
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SnapshotManager))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.CurrentStateMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TakeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SnapshotMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RestoreMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CurrentStateMenu.SuspendLayout()
        Me.SnapshotMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        resources.ApplyResources(Me.TreeView1, "TreeView1")
        Me.TreeView1.Name = "TreeView1"
        '
        'CurrentStateMenu
        '
        resources.ApplyResources(Me.CurrentStateMenu, "CurrentStateMenu")
        Me.CurrentStateMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TakeMenuItem})
        Me.CurrentStateMenu.Name = "CurrentStateMenu"
        '
        'TakeMenuItem
        '
        resources.ApplyResources(Me.TakeMenuItem, "TakeMenuItem")
        Me.TakeMenuItem.Name = "TakeMenuItem"
        '
        'SnapshotMenu
        '
        resources.ApplyResources(Me.SnapshotMenu, "SnapshotMenu")
        Me.SnapshotMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestoreMenuItem, Me.DeleteMenuItem})
        Me.SnapshotMenu.Name = "SnapshotMenu"
        '
        'RestoreMenuItem
        '
        resources.ApplyResources(Me.RestoreMenuItem, "RestoreMenuItem")
        Me.RestoreMenuItem.Name = "RestoreMenuItem"
        '
        'DeleteMenuItem
        '
        resources.ApplyResources(Me.DeleteMenuItem, "DeleteMenuItem")
        Me.DeleteMenuItem.Name = "DeleteMenuItem"
        '
        'SnapshotManager
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "SnapshotManager"
        Me.CurrentStateMenu.ResumeLayout(False)
        Me.SnapshotMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents CurrentStateMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TakeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SnapshotMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RestoreMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
