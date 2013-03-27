<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GLOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GLOptions))
        Me.runOnStartUpCheckBox = New System.Windows.Forms.CheckBox()
        Me.sendSkypeNotificationsCheckBox = New System.Windows.Forms.CheckBox()
        Me.playTimeInSkypeNotificationsCheckBox = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.integrateWithExplorerCheckBox = New System.Windows.Forms.CheckBox()
        Me.autoUpdateCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'runOnStartUpCheckBox
        '
        Me.runOnStartUpCheckBox.AutoSize = True
        Me.runOnStartUpCheckBox.Location = New System.Drawing.Point(6, 42)
        Me.runOnStartUpCheckBox.Name = "runOnStartUpCheckBox"
        Me.runOnStartUpCheckBox.Size = New System.Drawing.Size(204, 17)
        Me.runOnStartUpCheckBox.TabIndex = 0
        Me.runOnStartUpCheckBox.Text = "Start Game Launcher when you log in"
        Me.runOnStartUpCheckBox.UseVisualStyleBackColor = True
        '
        'sendSkypeNotificationsCheckBox
        '
        Me.sendSkypeNotificationsCheckBox.AutoSize = True
        Me.sendSkypeNotificationsCheckBox.Location = New System.Drawing.Point(6, 65)
        Me.sendSkypeNotificationsCheckBox.Name = "sendSkypeNotificationsCheckBox"
        Me.sendSkypeNotificationsCheckBox.Size = New System.Drawing.Size(288, 17)
        Me.sendSkypeNotificationsCheckBox.TabIndex = 1
        Me.sendSkypeNotificationsCheckBox.Text = "Send notifications to Skype when you start/stop playing"
        Me.sendSkypeNotificationsCheckBox.UseVisualStyleBackColor = True
        '
        'playTimeInSkypeNotificationsCheckBox
        '
        Me.playTimeInSkypeNotificationsCheckBox.AutoSize = True
        Me.playTimeInSkypeNotificationsCheckBox.Location = New System.Drawing.Point(15, 88)
        Me.playTimeInSkypeNotificationsCheckBox.Name = "playTimeInSkypeNotificationsCheckBox"
        Me.playTimeInSkypeNotificationsCheckBox.Size = New System.Drawing.Size(231, 17)
        Me.playTimeInSkypeNotificationsCheckBox.TabIndex = 2
        Me.playTimeInSkypeNotificationsCheckBox.Text = "Show time spent playing when exiting game"
        Me.playTimeInSkypeNotificationsCheckBox.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(243, 150)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "&Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Changes take effect immediately."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.autoUpdateCheckBox)
        Me.GroupBox1.Controls.Add(Me.integrateWithExplorerCheckBox)
        Me.GroupBox1.Controls.Add(Me.runOnStartUpCheckBox)
        Me.GroupBox1.Controls.Add(Me.sendSkypeNotificationsCheckBox)
        Me.GroupBox1.Controls.Add(Me.playTimeInSkypeNotificationsCheckBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(306, 135)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "General"
        '
        'integrateWithExplorerCheckBox
        '
        Me.integrateWithExplorerCheckBox.AutoSize = True
        Me.integrateWithExplorerCheckBox.Location = New System.Drawing.Point(6, 19)
        Me.integrateWithExplorerCheckBox.Name = "integrateWithExplorerCheckBox"
        Me.integrateWithExplorerCheckBox.Size = New System.Drawing.Size(178, 17)
        Me.integrateWithExplorerCheckBox.TabIndex = 3
        Me.integrateWithExplorerCheckBox.Text = "Integrate with Windows Explorer"
        Me.integrateWithExplorerCheckBox.UseVisualStyleBackColor = True
        '
        'autoUpdateCheckBox
        '
        Me.autoUpdateCheckBox.AutoSize = True
        Me.autoUpdateCheckBox.Location = New System.Drawing.Point(6, 111)
        Me.autoUpdateCheckBox.Name = "autoUpdateCheckBox"
        Me.autoUpdateCheckBox.Size = New System.Drawing.Size(177, 17)
        Me.autoUpdateCheckBox.TabIndex = 4
        Me.autoUpdateCheckBox.Text = "Automatically check for updates"
        Me.autoUpdateCheckBox.UseVisualStyleBackColor = True
        '
        'GLOptions
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button1
        Me.ClientSize = New System.Drawing.Size(330, 181)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "GLOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game Launcher Preferences"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents runOnStartUpCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents sendSkypeNotificationsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents playTimeInSkypeNotificationsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents integrateWithExplorerCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents autoUpdateCheckBox As System.Windows.Forms.CheckBox
End Class
