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
        Me.GTFOButton = New System.Windows.Forms.Button()
        Me.InfoLabel = New System.Windows.Forms.Label()
        Me.PreferencesGroupBox = New System.Windows.Forms.GroupBox()
        Me.LanguagePicker = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.autoUpdateCheckBox = New System.Windows.Forms.CheckBox()
        Me.integrateWithExplorerCheckBox = New System.Windows.Forms.CheckBox()
        Me.PreferencesGroupBox.SuspendLayout()
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
        'GTFOButton
        '
        Me.GTFOButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GTFOButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.GTFOButton.Location = New System.Drawing.Point(299, 174)
        Me.GTFOButton.Name = "GTFOButton"
        Me.GTFOButton.Size = New System.Drawing.Size(99, 23)
        Me.GTFOButton.TabIndex = 3
        Me.GTFOButton.Text = "&Close"
        Me.GTFOButton.UseVisualStyleBackColor = True
        '
        'InfoLabel
        '
        Me.InfoLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.InfoLabel.AutoSize = True
        Me.InfoLabel.Location = New System.Drawing.Point(9, 179)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(163, 13)
        Me.InfoLabel.TabIndex = 4
        Me.InfoLabel.Text = "Changes take effect immediately."
        '
        'PreferencesGroupBox
        '
        Me.PreferencesGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PreferencesGroupBox.Controls.Add(Me.LanguagePicker)
        Me.PreferencesGroupBox.Controls.Add(Me.Label1)
        Me.PreferencesGroupBox.Controls.Add(Me.autoUpdateCheckBox)
        Me.PreferencesGroupBox.Controls.Add(Me.integrateWithExplorerCheckBox)
        Me.PreferencesGroupBox.Controls.Add(Me.runOnStartUpCheckBox)
        Me.PreferencesGroupBox.Controls.Add(Me.sendSkypeNotificationsCheckBox)
        Me.PreferencesGroupBox.Controls.Add(Me.playTimeInSkypeNotificationsCheckBox)
        Me.PreferencesGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.PreferencesGroupBox.Name = "PreferencesGroupBox"
        Me.PreferencesGroupBox.Size = New System.Drawing.Size(386, 156)
        Me.PreferencesGroupBox.TabIndex = 5
        Me.PreferencesGroupBox.TabStop = False
        Me.PreferencesGroupBox.Text = "Preferences"
        '
        'LanguagePicker
        '
        Me.LanguagePicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LanguagePicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LanguagePicker.FormattingEnabled = True
        Me.LanguagePicker.Items.AddRange(New Object() {"Catalan", "English", "French", "German", "Norwegian", "Portuguese", "Serbian (Cyrillic)", "Serbian (Latin)", "Spanish", "Swedish", "Vietnamese"})
        Me.LanguagePicker.Location = New System.Drawing.Point(259, 128)
        Me.LanguagePicker.Name = "LanguagePicker"
        Me.LanguagePicker.Size = New System.Drawing.Size(121, 21)
        Me.LanguagePicker.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Language (Need restart to apply):"
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
        'GLOptions
        '
        Me.AcceptButton = Me.GTFOButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.GTFOButton
        Me.ClientSize = New System.Drawing.Size(410, 209)
        Me.Controls.Add(Me.PreferencesGroupBox)
        Me.Controls.Add(Me.InfoLabel)
        Me.Controls.Add(Me.GTFOButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "GLOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game Launcher Preferences"
        Me.PreferencesGroupBox.ResumeLayout(False)
        Me.PreferencesGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents runOnStartUpCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents sendSkypeNotificationsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents playTimeInSkypeNotificationsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GTFOButton As System.Windows.Forms.Button
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents PreferencesGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents integrateWithExplorerCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents autoUpdateCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LanguagePicker As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
