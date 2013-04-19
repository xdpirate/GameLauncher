<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DockForm
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.DockContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AlwaysOnTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeOpacityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseTheDockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DockContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.ContextMenuStrip = Me.DockContextMenu
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(24, 320)
        Me.ToolStrip1.TabIndex = 0
        '
        'DockContextMenu
        '
        Me.DockContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlwaysOnTopToolStripMenuItem, Me.ChangeOpacityToolStripMenuItem, Me.ToolStripSeparator1, Me.CloseTheDockToolStripMenuItem})
        Me.DockContextMenu.Name = "DockContextMenu"
        Me.DockContextMenu.Size = New System.Drawing.Size(158, 98)
        '
        'AlwaysOnTopToolStripMenuItem
        '
        Me.AlwaysOnTopToolStripMenuItem.Checked = True
        Me.AlwaysOnTopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AlwaysOnTopToolStripMenuItem.Name = "AlwaysOnTopToolStripMenuItem"
        Me.AlwaysOnTopToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.AlwaysOnTopToolStripMenuItem.Text = "Always on top"
        '
        'ChangeOpacityToolStripMenuItem
        '
        Me.ChangeOpacityToolStripMenuItem.Name = "ChangeOpacityToolStripMenuItem"
        Me.ChangeOpacityToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ChangeOpacityToolStripMenuItem.Text = "Change &opacity"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(154, 6)
        '
        'CloseTheDockToolStripMenuItem
        '
        Me.CloseTheDockToolStripMenuItem.Name = "CloseTheDockToolStripMenuItem"
        Me.CloseTheDockToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.CloseTheDockToolStripMenuItem.Text = "&Close the dock"
        '
        'DockForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(22, 318)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DockForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.DockContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DockContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChangeOpacityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseTheDockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlwaysOnTopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
