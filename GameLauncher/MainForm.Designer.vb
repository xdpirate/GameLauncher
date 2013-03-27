<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MainContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddGameMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveGameMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearGameListMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatisticsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutGameLauncherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UpdateChecker = New System.Windows.Forms.Timer(Me.components)
        Me.skypeWorker = New System.ComponentModel.BackgroundWorker()
        Me.updateWorker = New System.ComponentModel.BackgroundWorker()
        Me.processMonitorTimer = New System.Windows.Forms.Timer(Me.components)
        Me.processMonitorWorker = New System.ComponentModel.BackgroundWorker()
        Me.runGameWorker = New System.ComponentModel.BackgroundWorker()
        Me.MainContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrayIcon
        '
        Me.TrayIcon.ContextMenuStrip = Me.MainContextMenu
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "Game Launcher"
        Me.TrayIcon.Visible = True
        '
        'MainContextMenu
        '
        Me.MainContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitToolStripMenuItem, Me.OptionsMenuItem, Me.ToolStripSeparator1})
        Me.MainContextMenu.Name = "ContextMenuStrip1"
        Me.MainContextMenu.ShowItemToolTips = False
        Me.MainContextMenu.Size = New System.Drawing.Size(117, 54)
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.QuitToolStripMenuItem.Text = "&Quit"
        Me.QuitToolStripMenuItem.ToolTipText = "Exit Game Launcher. Note that if you have GL registered as a startup application," & _
    " it will show up on next login."
        '
        'OptionsMenuItem
        '
        Me.OptionsMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddGameMenuItem, Me.RemoveGameMenuItem, Me.ClearGameListMenuItem, Me.ToolStripSeparator2, Me.PreferencesToolStripMenuItem, Me.StatisticsToolStripMenuItem, Me.ToolStripSeparator3, Me.AboutGameLauncherToolStripMenuItem})
        Me.OptionsMenuItem.Name = "OptionsMenuItem"
        Me.OptionsMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.OptionsMenuItem.Text = "&Options"
        '
        'AddGameMenuItem
        '
        Me.AddGameMenuItem.Name = "AddGameMenuItem"
        Me.AddGameMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.AddGameMenuItem.Text = "&Add game..."
        Me.AddGameMenuItem.ToolTipText = "Add a game to the list. You can also double click the tray icon to add games quic" & _
    "kly by dragging and dropping shortcuts or executables."
        '
        'RemoveGameMenuItem
        '
        Me.RemoveGameMenuItem.Name = "RemoveGameMenuItem"
        Me.RemoveGameMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.RemoveGameMenuItem.Text = "&Remove games..."
        Me.RemoveGameMenuItem.ToolTipText = "Remove one or more games from the list."
        '
        'ClearGameListMenuItem
        '
        Me.ClearGameListMenuItem.Name = "ClearGameListMenuItem"
        Me.ClearGameListMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.ClearGameListMenuItem.Text = "&Clear game list..."
        Me.ClearGameListMenuItem.ToolTipText = "Delete every item in the game list. This action cannot be undone!"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(190, 6)
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.PreferencesToolStripMenuItem.Text = "&Preferences"
        '
        'StatisticsToolStripMenuItem
        '
        Me.StatisticsToolStripMenuItem.Name = "StatisticsToolStripMenuItem"
        Me.StatisticsToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.StatisticsToolStripMenuItem.Text = "S&tatistics"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(190, 6)
        '
        'AboutGameLauncherToolStripMenuItem
        '
        Me.AboutGameLauncherToolStripMenuItem.Name = "AboutGameLauncherToolStripMenuItem"
        Me.AboutGameLauncherToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.AboutGameLauncherToolStripMenuItem.Text = "About &Game Launcher"
        Me.AboutGameLauncherToolStripMenuItem.ToolTipText = "Show information about the application and its contributors."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(113, 6)
        '
        'UpdateChecker
        '
        Me.UpdateChecker.Enabled = True
        Me.UpdateChecker.Interval = 7200000
        '
        'skypeWorker
        '
        '
        'updateWorker
        '
        '
        'processMonitorTimer
        '
        Me.processMonitorTimer.Interval = 1000
        '
        'processMonitorWorker
        '
        '
        'runGameWorker
        '
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(53, 30)
        Me.ControlBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.Opacity = 0.0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.MainContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents MainContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OptionsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddGameMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveGameMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearGameListMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents QuitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutGameLauncherToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateChecker As System.Windows.Forms.Timer
    Friend WithEvents skypeWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents updateWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents PreferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatisticsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents processMonitorTimer As System.Windows.Forms.Timer
    Friend WithEvents processMonitorWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents runGameWorker As System.ComponentModel.BackgroundWorker

End Class
