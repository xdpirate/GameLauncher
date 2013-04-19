<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddNewGameForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddNewGameForm))
        Me.gamePathTextBox = New System.Windows.Forms.TextBox()
        Me.gameNameTextBox = New System.Windows.Forms.TextBox()
        Me.commandLineTextBox = New System.Windows.Forms.TextBox()
        Me.GameNameLabel = New System.Windows.Forms.Label()
        Me.CmdArgsLabel = New System.Windows.Forms.Label()
        Me.pathBrowseButton = New System.Windows.Forms.Button()
        Me.IconGroupBox = New System.Windows.Forms.GroupBox()
        Me.keepCurrentIconRadio = New System.Windows.Forms.RadioButton()
        Me.customIconPathTextBox = New System.Windows.Forms.TextBox()
        Me.gameIconPreviewBox = New System.Windows.Forms.PictureBox()
        Me.iconBrowseButton = New System.Windows.Forms.Button()
        Me.getFromOtherFileRadio = New System.Windows.Forms.RadioButton()
        Me.getFromExeRadio = New System.Windows.Forms.RadioButton()
        Me.okayButton = New System.Windows.Forms.Button()
        Me.cancelAddGameButton = New System.Windows.Forms.Button()
        Me.browseForExeDialog = New System.Windows.Forms.OpenFileDialog()
        Me.browseForIconDialog = New System.Windows.Forms.OpenFileDialog()
        Me.normalGameRadio = New System.Windows.Forms.RadioButton()
        Me.steamGameRadio = New System.Windows.Forms.RadioButton()
        Me.steamAppIDTextBox = New System.Windows.Forms.TextBox()
        Me.GamePathsGroupBox = New System.Windows.Forms.GroupBox()
        Me.specifySteamExeCheckBox = New System.Windows.Forms.CheckBox()
        Me.steamExePathTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.steamExeBrowseButton = New System.Windows.Forms.Button()
        Me.launcherBrowseButton = New System.Windows.Forms.Button()
        Me.launcherPathTextBox = New System.Windows.Forms.TextBox()
        Me.usesLauncherCheckBox = New System.Windows.Forms.CheckBox()
        Me.GameInfoGroupBox = New System.Windows.Forms.GroupBox()
        Me.helpTextLabel = New System.Windows.Forms.Label()
        Me.HelpGroupBox = New System.Windows.Forms.GroupBox()
        Me.IconGroupBox.SuspendLayout()
        CType(Me.gameIconPreviewBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GamePathsGroupBox.SuspendLayout()
        Me.GameInfoGroupBox.SuspendLayout()
        Me.HelpGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'gamePathTextBox
        '
        Me.gamePathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gamePathTextBox.Location = New System.Drawing.Point(131, 19)
        Me.gamePathTextBox.Name = "gamePathTextBox"
        Me.gamePathTextBox.ReadOnly = True
        Me.gamePathTextBox.Size = New System.Drawing.Size(152, 20)
        Me.gamePathTextBox.TabIndex = 1
        '
        'gameNameTextBox
        '
        Me.gameNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gameNameTextBox.Location = New System.Drawing.Point(9, 32)
        Me.gameNameTextBox.Name = "gameNameTextBox"
        Me.gameNameTextBox.Size = New System.Drawing.Size(360, 20)
        Me.gameNameTextBox.TabIndex = 1
        '
        'commandLineTextBox
        '
        Me.commandLineTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.commandLineTextBox.Location = New System.Drawing.Point(9, 71)
        Me.commandLineTextBox.Name = "commandLineTextBox"
        Me.commandLineTextBox.Size = New System.Drawing.Size(360, 20)
        Me.commandLineTextBox.TabIndex = 3
        '
        'GameNameLabel
        '
        Me.GameNameLabel.AutoSize = True
        Me.GameNameLabel.Location = New System.Drawing.Point(6, 16)
        Me.GameNameLabel.Name = "GameNameLabel"
        Me.GameNameLabel.Size = New System.Drawing.Size(38, 13)
        Me.GameNameLabel.TabIndex = 0
        Me.GameNameLabel.Text = "Name:"
        '
        'CmdArgsLabel
        '
        Me.CmdArgsLabel.AutoSize = True
        Me.CmdArgsLabel.Location = New System.Drawing.Point(6, 55)
        Me.CmdArgsLabel.Name = "CmdArgsLabel"
        Me.CmdArgsLabel.Size = New System.Drawing.Size(128, 13)
        Me.CmdArgsLabel.TabIndex = 2
        Me.CmdArgsLabel.Text = "Command line arguments:"
        '
        'pathBrowseButton
        '
        Me.pathBrowseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pathBrowseButton.Location = New System.Drawing.Point(289, 16)
        Me.pathBrowseButton.Name = "pathBrowseButton"
        Me.pathBrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.pathBrowseButton.TabIndex = 2
        Me.pathBrowseButton.Text = "&Browse..."
        Me.pathBrowseButton.UseVisualStyleBackColor = True
        '
        'IconGroupBox
        '
        Me.IconGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconGroupBox.Controls.Add(Me.keepCurrentIconRadio)
        Me.IconGroupBox.Controls.Add(Me.customIconPathTextBox)
        Me.IconGroupBox.Controls.Add(Me.gameIconPreviewBox)
        Me.IconGroupBox.Controls.Add(Me.iconBrowseButton)
        Me.IconGroupBox.Controls.Add(Me.getFromOtherFileRadio)
        Me.IconGroupBox.Controls.Add(Me.getFromExeRadio)
        Me.IconGroupBox.Location = New System.Drawing.Point(12, 263)
        Me.IconGroupBox.Name = "IconGroupBox"
        Me.IconGroupBox.Size = New System.Drawing.Size(375, 91)
        Me.IconGroupBox.TabIndex = 2
        Me.IconGroupBox.TabStop = False
        Me.IconGroupBox.Text = "Icon"
        '
        'keepCurrentIconRadio
        '
        Me.keepCurrentIconRadio.AutoSize = True
        Me.keepCurrentIconRadio.Enabled = False
        Me.keepCurrentIconRadio.Location = New System.Drawing.Point(7, 66)
        Me.keepCurrentIconRadio.Name = "keepCurrentIconRadio"
        Me.keepCurrentIconRadio.Size = New System.Drawing.Size(109, 17)
        Me.keepCurrentIconRadio.TabIndex = 4
        Me.keepCurrentIconRadio.TabStop = True
        Me.keepCurrentIconRadio.Text = "Keep current icon"
        Me.keepCurrentIconRadio.UseVisualStyleBackColor = True
        '
        'customIconPathTextBox
        '
        Me.customIconPathTextBox.Location = New System.Drawing.Point(144, 42)
        Me.customIconPathTextBox.Name = "customIconPathTextBox"
        Me.customIconPathTextBox.ReadOnly = True
        Me.customIconPathTextBox.Size = New System.Drawing.Size(139, 20)
        Me.customIconPathTextBox.TabIndex = 2
        '
        'gameIconPreviewBox
        '
        Me.gameIconPreviewBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gameIconPreviewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.gameIconPreviewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gameIconPreviewBox.Location = New System.Drawing.Point(340, 13)
        Me.gameIconPreviewBox.Name = "gameIconPreviewBox"
        Me.gameIconPreviewBox.Size = New System.Drawing.Size(24, 24)
        Me.gameIconPreviewBox.TabIndex = 3
        Me.gameIconPreviewBox.TabStop = False
        '
        'iconBrowseButton
        '
        Me.iconBrowseButton.Enabled = False
        Me.iconBrowseButton.Location = New System.Drawing.Point(289, 40)
        Me.iconBrowseButton.Name = "iconBrowseButton"
        Me.iconBrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.iconBrowseButton.TabIndex = 3
        Me.iconBrowseButton.Text = "B&rowse..."
        Me.iconBrowseButton.UseVisualStyleBackColor = True
        '
        'getFromOtherFileRadio
        '
        Me.getFromOtherFileRadio.AutoSize = True
        Me.getFromOtherFileRadio.Location = New System.Drawing.Point(7, 43)
        Me.getFromOtherFileRadio.Name = "getFromOtherFileRadio"
        Me.getFromOtherFileRadio.Size = New System.Drawing.Size(108, 17)
        Me.getFromOtherFileRadio.TabIndex = 1
        Me.getFromOtherFileRadio.Text = "Get from other file"
        Me.getFromOtherFileRadio.UseVisualStyleBackColor = True
        '
        'getFromExeRadio
        '
        Me.getFromExeRadio.AutoSize = True
        Me.getFromExeRadio.Checked = True
        Me.getFromExeRadio.Location = New System.Drawing.Point(7, 20)
        Me.getFromExeRadio.Name = "getFromExeRadio"
        Me.getFromExeRadio.Size = New System.Drawing.Size(120, 17)
        Me.getFromExeRadio.TabIndex = 0
        Me.getFromExeRadio.TabStop = True
        Me.getFromExeRadio.Text = "Get from executable"
        Me.getFromExeRadio.UseVisualStyleBackColor = True
        '
        'okayButton
        '
        Me.okayButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.okayButton.Location = New System.Drawing.Point(231, 455)
        Me.okayButton.Name = "okayButton"
        Me.okayButton.Size = New System.Drawing.Size(75, 23)
        Me.okayButton.TabIndex = 4
        Me.okayButton.Text = "&OK"
        Me.okayButton.UseVisualStyleBackColor = True
        '
        'cancelAddGameButton
        '
        Me.cancelAddGameButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelAddGameButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancelAddGameButton.Location = New System.Drawing.Point(312, 455)
        Me.cancelAddGameButton.Name = "cancelAddGameButton"
        Me.cancelAddGameButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelAddGameButton.TabIndex = 5
        Me.cancelAddGameButton.Text = "&Cancel"
        Me.cancelAddGameButton.UseVisualStyleBackColor = True
        '
        'browseForExeDialog
        '
        Me.browseForExeDialog.Filter = "Executable files|*.exe;*.jar;*.cmd;*.bat"
        '
        'browseForIconDialog
        '
        Me.browseForIconDialog.Filter = "Icon, image and executable files|*.ico;*.png;*.bmp;*.jpg;*.gif;*.jpeg;*.exe"
        '
        'normalGameRadio
        '
        Me.normalGameRadio.AutoSize = True
        Me.normalGameRadio.Checked = True
        Me.normalGameRadio.Location = New System.Drawing.Point(6, 19)
        Me.normalGameRadio.Name = "normalGameRadio"
        Me.normalGameRadio.Size = New System.Drawing.Size(87, 17)
        Me.normalGameRadio.TabIndex = 0
        Me.normalGameRadio.TabStop = True
        Me.normalGameRadio.Text = "Normal game"
        Me.normalGameRadio.UseVisualStyleBackColor = True
        '
        'steamGameRadio
        '
        Me.steamGameRadio.AutoSize = True
        Me.steamGameRadio.Location = New System.Drawing.Point(6, 71)
        Me.steamGameRadio.Name = "steamGameRadio"
        Me.steamGameRadio.Size = New System.Drawing.Size(84, 17)
        Me.steamGameRadio.TabIndex = 6
        Me.steamGameRadio.Text = "Steam game"
        Me.steamGameRadio.UseVisualStyleBackColor = True
        '
        'steamAppIDTextBox
        '
        Me.steamAppIDTextBox.Location = New System.Drawing.Point(144, 90)
        Me.steamAppIDTextBox.Name = "steamAppIDTextBox"
        Me.steamAppIDTextBox.Size = New System.Drawing.Size(139, 20)
        Me.steamAppIDTextBox.TabIndex = 8
        '
        'GamePathsGroupBox
        '
        Me.GamePathsGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GamePathsGroupBox.Controls.Add(Me.specifySteamExeCheckBox)
        Me.GamePathsGroupBox.Controls.Add(Me.steamExePathTextBox)
        Me.GamePathsGroupBox.Controls.Add(Me.Label1)
        Me.GamePathsGroupBox.Controls.Add(Me.steamExeBrowseButton)
        Me.GamePathsGroupBox.Controls.Add(Me.launcherBrowseButton)
        Me.GamePathsGroupBox.Controls.Add(Me.launcherPathTextBox)
        Me.GamePathsGroupBox.Controls.Add(Me.usesLauncherCheckBox)
        Me.GamePathsGroupBox.Controls.Add(Me.steamAppIDTextBox)
        Me.GamePathsGroupBox.Controls.Add(Me.gamePathTextBox)
        Me.GamePathsGroupBox.Controls.Add(Me.steamGameRadio)
        Me.GamePathsGroupBox.Controls.Add(Me.pathBrowseButton)
        Me.GamePathsGroupBox.Controls.Add(Me.normalGameRadio)
        Me.GamePathsGroupBox.Location = New System.Drawing.Point(12, 118)
        Me.GamePathsGroupBox.Name = "GamePathsGroupBox"
        Me.GamePathsGroupBox.Size = New System.Drawing.Size(375, 139)
        Me.GamePathsGroupBox.TabIndex = 1
        Me.GamePathsGroupBox.TabStop = False
        Me.GamePathsGroupBox.Text = "Game path/Steam app ID"
        '
        'specifySteamExeCheckBox
        '
        Me.specifySteamExeCheckBox.AutoSize = True
        Me.specifySteamExeCheckBox.Location = New System.Drawing.Point(22, 114)
        Me.specifySteamExeCheckBox.Name = "specifySteamExeCheckBox"
        Me.specifySteamExeCheckBox.Size = New System.Drawing.Size(116, 17)
        Me.specifySteamExeCheckBox.TabIndex = 9
        Me.specifySteamExeCheckBox.Text = "Specify executable"
        Me.specifySteamExeCheckBox.UseVisualStyleBackColor = True
        '
        'steamExePathTextBox
        '
        Me.steamExePathTextBox.Location = New System.Drawing.Point(144, 114)
        Me.steamExePathTextBox.Name = "steamExePathTextBox"
        Me.steamExePathTextBox.ReadOnly = True
        Me.steamExePathTextBox.Size = New System.Drawing.Size(139, 20)
        Me.steamExePathTextBox.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Steam App ID:"
        '
        'steamExeBrowseButton
        '
        Me.steamExeBrowseButton.Location = New System.Drawing.Point(289, 110)
        Me.steamExeBrowseButton.Name = "steamExeBrowseButton"
        Me.steamExeBrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.steamExeBrowseButton.TabIndex = 11
        Me.steamExeBrowseButton.Text = "Bro&wse..."
        Me.steamExeBrowseButton.UseVisualStyleBackColor = True
        '
        'launcherBrowseButton
        '
        Me.launcherBrowseButton.Enabled = False
        Me.launcherBrowseButton.Location = New System.Drawing.Point(289, 43)
        Me.launcherBrowseButton.Name = "launcherBrowseButton"
        Me.launcherBrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.launcherBrowseButton.TabIndex = 5
        Me.launcherBrowseButton.Text = "B&rowse..."
        Me.launcherBrowseButton.UseVisualStyleBackColor = True
        '
        'launcherPathTextBox
        '
        Me.launcherPathTextBox.Enabled = False
        Me.launcherPathTextBox.Location = New System.Drawing.Point(131, 45)
        Me.launcherPathTextBox.Name = "launcherPathTextBox"
        Me.launcherPathTextBox.ReadOnly = True
        Me.launcherPathTextBox.Size = New System.Drawing.Size(152, 20)
        Me.launcherPathTextBox.TabIndex = 4
        '
        'usesLauncherCheckBox
        '
        Me.usesLauncherCheckBox.AutoSize = True
        Me.usesLauncherCheckBox.Location = New System.Drawing.Point(22, 47)
        Me.usesLauncherCheckBox.Name = "usesLauncherCheckBox"
        Me.usesLauncherCheckBox.Size = New System.Drawing.Size(103, 17)
        Me.usesLauncherCheckBox.TabIndex = 3
        Me.usesLauncherCheckBox.Text = "Uses a launcher"
        Me.usesLauncherCheckBox.UseVisualStyleBackColor = True
        '
        'GameInfoGroupBox
        '
        Me.GameInfoGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GameInfoGroupBox.Controls.Add(Me.GameNameLabel)
        Me.GameInfoGroupBox.Controls.Add(Me.gameNameTextBox)
        Me.GameInfoGroupBox.Controls.Add(Me.CmdArgsLabel)
        Me.GameInfoGroupBox.Controls.Add(Me.commandLineTextBox)
        Me.GameInfoGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.GameInfoGroupBox.Name = "GameInfoGroupBox"
        Me.GameInfoGroupBox.Size = New System.Drawing.Size(375, 100)
        Me.GameInfoGroupBox.TabIndex = 0
        Me.GameInfoGroupBox.TabStop = False
        Me.GameInfoGroupBox.Text = "Game information"
        '
        'helpTextLabel
        '
        Me.helpTextLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.helpTextLabel.ForeColor = System.Drawing.Color.DarkGray
        Me.helpTextLabel.Location = New System.Drawing.Point(6, 16)
        Me.helpTextLabel.Name = "helpTextLabel"
        Me.helpTextLabel.Size = New System.Drawing.Size(358, 67)
        Me.helpTextLabel.TabIndex = 0
        Me.helpTextLabel.Text = "Hover over an item to show help in this panel."
        '
        'HelpGroupBox
        '
        Me.HelpGroupBox.Controls.Add(Me.helpTextLabel)
        Me.HelpGroupBox.Location = New System.Drawing.Point(12, 360)
        Me.HelpGroupBox.Name = "HelpGroupBox"
        Me.HelpGroupBox.Size = New System.Drawing.Size(375, 86)
        Me.HelpGroupBox.TabIndex = 3
        Me.HelpGroupBox.TabStop = False
        Me.HelpGroupBox.Text = "Help"
        '
        'AddNewGameForm
        '
        Me.AcceptButton = Me.okayButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cancelAddGameButton
        Me.ClientSize = New System.Drawing.Size(399, 490)
        Me.Controls.Add(Me.HelpGroupBox)
        Me.Controls.Add(Me.GameInfoGroupBox)
        Me.Controls.Add(Me.GamePathsGroupBox)
        Me.Controls.Add(Me.cancelAddGameButton)
        Me.Controls.Add(Me.okayButton)
        Me.Controls.Add(Me.IconGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "AddNewGameForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add or edit game"
        Me.IconGroupBox.ResumeLayout(False)
        Me.IconGroupBox.PerformLayout()
        CType(Me.gameIconPreviewBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GamePathsGroupBox.ResumeLayout(False)
        Me.GamePathsGroupBox.PerformLayout()
        Me.GameInfoGroupBox.ResumeLayout(False)
        Me.GameInfoGroupBox.PerformLayout()
        Me.HelpGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gamePathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents gameNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents commandLineTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GameNameLabel As System.Windows.Forms.Label
    Friend WithEvents CmdArgsLabel As System.Windows.Forms.Label
    Friend WithEvents pathBrowseButton As System.Windows.Forms.Button
    Friend WithEvents IconGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents iconBrowseButton As System.Windows.Forms.Button
    Friend WithEvents getFromOtherFileRadio As System.Windows.Forms.RadioButton
    Friend WithEvents getFromExeRadio As System.Windows.Forms.RadioButton
    Friend WithEvents gameIconPreviewBox As System.Windows.Forms.PictureBox
    Friend WithEvents okayButton As System.Windows.Forms.Button
    Friend WithEvents cancelAddGameButton As System.Windows.Forms.Button
    Friend WithEvents browseForExeDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents browseForIconDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents normalGameRadio As System.Windows.Forms.RadioButton
    Friend WithEvents steamGameRadio As System.Windows.Forms.RadioButton
    Friend WithEvents steamAppIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GamePathsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents GameInfoGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents launcherBrowseButton As System.Windows.Forms.Button
    Friend WithEvents launcherPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents usesLauncherCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents helpTextLabel As System.Windows.Forms.Label
    Friend WithEvents HelpGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents specifySteamExeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents steamExePathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents steamExeBrowseButton As System.Windows.Forms.Button
    Friend WithEvents customIconPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents keepCurrentIconRadio As System.Windows.Forms.RadioButton
End Class
