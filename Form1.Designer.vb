<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.AppMenu = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunningMachineContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StopMachineContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AccessableRunMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StandardRunMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundRunMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetStateMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AppMenu.SuspendLayout()
        Me.StopMachineContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        resources.ApplyResources(Me.ListBox1, "ListBox1")
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Name = "ListBox1"
        '
        'AppMenu
        '
        resources.ApplyResources(Me.AppMenu, "AppMenu")
        Me.AppMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu})
        Me.AppMenu.Name = "AppMenu"
        '
        'FileMenu
        '
        resources.ApplyResources(Me.FileMenu, "FileMenu")
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshMenuItem, Me.ExitMenuItem})
        Me.FileMenu.Name = "FileMenu"
        '
        'RefreshMenuItem
        '
        resources.ApplyResources(Me.RefreshMenuItem, "RefreshMenuItem")
        Me.RefreshMenuItem.Name = "RefreshMenuItem"
        '
        'ExitMenuItem
        '
        resources.ApplyResources(Me.ExitMenuItem, "ExitMenuItem")
        Me.ExitMenuItem.Name = "ExitMenuItem"
        '
        'RunningMachineContextMenu
        '
        resources.ApplyResources(Me.RunningMachineContextMenu, "RunningMachineContextMenu")
        Me.RunningMachineContextMenu.Name = "RunningMachineContextMenu"
        '
        'StopMachineContextMenu
        '
        resources.ApplyResources(Me.StopMachineContextMenu, "StopMachineContextMenu")
        Me.StopMachineContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AccessableRunMenuItem, Me.StandardRunMenuItem, Me.BackgroundRunMenuItem, Me.ResetStateMenuItem})
        Me.StopMachineContextMenu.Name = "StopMachineContextMenu"
        '
        'AccessableRunMenuItem
        '
        resources.ApplyResources(Me.AccessableRunMenuItem, "AccessableRunMenuItem")
        Me.AccessableRunMenuItem.Name = "AccessableRunMenuItem"
        '
        'StandardRunMenuItem
        '
        resources.ApplyResources(Me.StandardRunMenuItem, "StandardRunMenuItem")
        Me.StandardRunMenuItem.Name = "StandardRunMenuItem"
        '
        'BackgroundRunMenuItem
        '
        resources.ApplyResources(Me.BackgroundRunMenuItem, "BackgroundRunMenuItem")
        Me.BackgroundRunMenuItem.Name = "BackgroundRunMenuItem"
        '
        'ResetStateMenuItem
        '
        resources.ApplyResources(Me.ResetStateMenuItem, "ResetStateMenuItem")
        Me.ResetStateMenuItem.Name = "ResetStateMenuItem"
        '
        'RefreshTimer
        '
        Me.RefreshTimer.Enabled = True
        Me.RefreshTimer.Interval = 5000
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.AppMenu)
        Me.MainMenuStrip = Me.AppMenu
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.AppMenu.ResumeLayout(False)
        Me.AppMenu.PerformLayout()
        Me.StopMachineContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents AppMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunningMachineContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StopMachineContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ResetStateMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccessableRunMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StandardRunMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundRunMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshTimer As System.Windows.Forms.Timer

End Class
