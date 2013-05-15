<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ThemeChanger
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
        Me.useCustomThemeCheckBox = New System.Windows.Forms.CheckBox()
        Me.themingOptionsGroupBox = New System.Windows.Forms.GroupBox()
        Me.fontPreview = New System.Windows.Forms.TextBox()
        Me.backColorPreview = New System.Windows.Forms.PictureBox()
        Me.foreColorPreview = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fontPicker = New System.Windows.Forms.ComboBox()
        Me.themingOptionsGroupBox.SuspendLayout()
        CType(Me.backColorPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.foreColorPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'useCustomThemeCheckBox
        '
        Me.useCustomThemeCheckBox.AutoSize = True
        Me.useCustomThemeCheckBox.Location = New System.Drawing.Point(12, 12)
        Me.useCustomThemeCheckBox.Name = "useCustomThemeCheckBox"
        Me.useCustomThemeCheckBox.Size = New System.Drawing.Size(114, 17)
        Me.useCustomThemeCheckBox.TabIndex = 0
        Me.useCustomThemeCheckBox.Text = "Use custom theme"
        Me.useCustomThemeCheckBox.UseVisualStyleBackColor = True
        '
        'themingOptionsGroupBox
        '
        Me.themingOptionsGroupBox.Controls.Add(Me.fontPicker)
        Me.themingOptionsGroupBox.Controls.Add(Me.fontPreview)
        Me.themingOptionsGroupBox.Controls.Add(Me.backColorPreview)
        Me.themingOptionsGroupBox.Controls.Add(Me.foreColorPreview)
        Me.themingOptionsGroupBox.Controls.Add(Me.Label3)
        Me.themingOptionsGroupBox.Controls.Add(Me.Label2)
        Me.themingOptionsGroupBox.Controls.Add(Me.Label1)
        Me.themingOptionsGroupBox.Enabled = False
        Me.themingOptionsGroupBox.Location = New System.Drawing.Point(12, 35)
        Me.themingOptionsGroupBox.Name = "themingOptionsGroupBox"
        Me.themingOptionsGroupBox.Size = New System.Drawing.Size(260, 148)
        Me.themingOptionsGroupBox.TabIndex = 1
        Me.themingOptionsGroupBox.TabStop = False
        Me.themingOptionsGroupBox.Text = "Theming options"
        '
        'fontPreview
        '
        Me.fontPreview.Location = New System.Drawing.Point(105, 122)
        Me.fontPreview.Multiline = True
        Me.fontPreview.Name = "fontPreview"
        Me.fontPreview.ReadOnly = True
        Me.fontPreview.Size = New System.Drawing.Size(149, 20)
        Me.fontPreview.TabIndex = 4
        Me.fontPreview.Text = "ABC abc 123"
        Me.fontPreview.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'backColorPreview
        '
        Me.backColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.backColorPreview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.backColorPreview.Location = New System.Drawing.Point(222, 57)
        Me.backColorPreview.Name = "backColorPreview"
        Me.backColorPreview.Size = New System.Drawing.Size(32, 32)
        Me.backColorPreview.TabIndex = 3
        Me.backColorPreview.TabStop = False
        '
        'foreColorPreview
        '
        Me.foreColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.foreColorPreview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.foreColorPreview.Location = New System.Drawing.Point(222, 19)
        Me.foreColorPreview.Name = "foreColorPreview"
        Me.foreColorPreview.Size = New System.Drawing.Size(32, 32)
        Me.foreColorPreview.TabIndex = 3
        Me.foreColorPreview.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Font:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Background color:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Text color:"
        '
        'fontPicker
        '
        Me.fontPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fontPicker.FormattingEnabled = True
        Me.fontPicker.Location = New System.Drawing.Point(105, 95)
        Me.fontPicker.Name = "fontPicker"
        Me.fontPicker.Size = New System.Drawing.Size(149, 21)
        Me.fontPicker.TabIndex = 5
        '
        'ThemeChanger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 192)
        Me.Controls.Add(Me.themingOptionsGroupBox)
        Me.Controls.Add(Me.useCustomThemeCheckBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ThemeChanger"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change look and feel"
        Me.themingOptionsGroupBox.ResumeLayout(False)
        Me.themingOptionsGroupBox.PerformLayout()
        CType(Me.backColorPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.foreColorPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents useCustomThemeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents themingOptionsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fontPreview As System.Windows.Forms.TextBox
    Friend WithEvents backColorPreview As System.Windows.Forms.PictureBox
    Friend WithEvents foreColorPreview As System.Windows.Forms.PictureBox
    Friend WithEvents fontPicker As System.Windows.Forms.ComboBox
End Class
