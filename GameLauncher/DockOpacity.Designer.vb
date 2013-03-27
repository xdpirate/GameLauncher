<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DockOpacity
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
        Me.NormalOpacityBar = New System.Windows.Forms.TrackBar()
        Me.buttonSave = New System.Windows.Forms.Button()
        Me.NormalOpacityLabel = New System.Windows.Forms.Label()
        Me.HoverOpacityBar = New System.Windows.Forms.TrackBar()
        Me.HoverOpacityLabel = New System.Windows.Forms.Label()
        Me.NormalOpacityGroupBox = New System.Windows.Forms.GroupBox()
        Me.HoverOpacityGroupBox = New System.Windows.Forms.GroupBox()
        CType(Me.NormalOpacityBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HoverOpacityBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NormalOpacityGroupBox.SuspendLayout()
        Me.HoverOpacityGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'NormalOpacityBar
        '
        Me.NormalOpacityBar.LargeChange = 10
        Me.NormalOpacityBar.Location = New System.Drawing.Point(6, 19)
        Me.NormalOpacityBar.Maximum = 100
        Me.NormalOpacityBar.Minimum = 1
        Me.NormalOpacityBar.Name = "NormalOpacityBar"
        Me.NormalOpacityBar.Size = New System.Drawing.Size(369, 45)
        Me.NormalOpacityBar.TabIndex = 0
        Me.NormalOpacityBar.TickFrequency = 10
        Me.NormalOpacityBar.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.NormalOpacityBar.Value = 100
        '
        'buttonSave
        '
        Me.buttonSave.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonSave.Location = New System.Drawing.Point(318, 220)
        Me.buttonSave.Name = "buttonSave"
        Me.buttonSave.Size = New System.Drawing.Size(75, 23)
        Me.buttonSave.TabIndex = 1
        Me.buttonSave.Text = "&Save"
        Me.buttonSave.UseVisualStyleBackColor = True
        '
        'NormalOpacityLabel
        '
        Me.NormalOpacityLabel.Location = New System.Drawing.Point(6, 67)
        Me.NormalOpacityLabel.Name = "NormalOpacityLabel"
        Me.NormalOpacityLabel.Size = New System.Drawing.Size(369, 24)
        Me.NormalOpacityLabel.TabIndex = 2
        Me.NormalOpacityLabel.Text = "100"
        Me.NormalOpacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HoverOpacityBar
        '
        Me.HoverOpacityBar.LargeChange = 10
        Me.HoverOpacityBar.Location = New System.Drawing.Point(6, 19)
        Me.HoverOpacityBar.Maximum = 100
        Me.HoverOpacityBar.Minimum = 1
        Me.HoverOpacityBar.Name = "HoverOpacityBar"
        Me.HoverOpacityBar.Size = New System.Drawing.Size(369, 45)
        Me.HoverOpacityBar.TabIndex = 3
        Me.HoverOpacityBar.TickFrequency = 10
        Me.HoverOpacityBar.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.HoverOpacityBar.Value = 100
        '
        'HoverOpacityLabel
        '
        Me.HoverOpacityLabel.Location = New System.Drawing.Point(9, 67)
        Me.HoverOpacityLabel.Name = "HoverOpacityLabel"
        Me.HoverOpacityLabel.Size = New System.Drawing.Size(366, 24)
        Me.HoverOpacityLabel.TabIndex = 2
        Me.HoverOpacityLabel.Text = "100"
        Me.HoverOpacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NormalOpacityGroupBox
        '
        Me.NormalOpacityGroupBox.Controls.Add(Me.NormalOpacityBar)
        Me.NormalOpacityGroupBox.Controls.Add(Me.NormalOpacityLabel)
        Me.NormalOpacityGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.NormalOpacityGroupBox.Name = "NormalOpacityGroupBox"
        Me.NormalOpacityGroupBox.Size = New System.Drawing.Size(381, 98)
        Me.NormalOpacityGroupBox.TabIndex = 4
        Me.NormalOpacityGroupBox.TabStop = False
        Me.NormalOpacityGroupBox.Text = "Dock opacity when not in focus"
        '
        'HoverOpacityGroupBox
        '
        Me.HoverOpacityGroupBox.Controls.Add(Me.HoverOpacityBar)
        Me.HoverOpacityGroupBox.Controls.Add(Me.HoverOpacityLabel)
        Me.HoverOpacityGroupBox.Location = New System.Drawing.Point(12, 116)
        Me.HoverOpacityGroupBox.Name = "HoverOpacityGroupBox"
        Me.HoverOpacityGroupBox.Size = New System.Drawing.Size(381, 98)
        Me.HoverOpacityGroupBox.TabIndex = 5
        Me.HoverOpacityGroupBox.TabStop = False
        Me.HoverOpacityGroupBox.Text = "Dock opacity when in focus (mouse hovering over the dock)"
        '
        'DockOpacity
        '
        Me.AcceptButton = Me.buttonSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.buttonSave
        Me.ClientSize = New System.Drawing.Size(405, 254)
        Me.ControlBox = False
        Me.Controls.Add(Me.HoverOpacityGroupBox)
        Me.Controls.Add(Me.NormalOpacityGroupBox)
        Me.Controls.Add(Me.buttonSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DockOpacity"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change opacity"
        CType(Me.NormalOpacityBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HoverOpacityBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NormalOpacityGroupBox.ResumeLayout(False)
        Me.NormalOpacityGroupBox.PerformLayout()
        Me.HoverOpacityGroupBox.ResumeLayout(False)
        Me.HoverOpacityGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NormalOpacityBar As System.Windows.Forms.TrackBar
    Friend WithEvents buttonSave As System.Windows.Forms.Button
    Friend WithEvents NormalOpacityLabel As System.Windows.Forms.Label
    Friend WithEvents HoverOpacityBar As System.Windows.Forms.TrackBar
    Friend WithEvents HoverOpacityLabel As System.Windows.Forms.Label
    Friend WithEvents NormalOpacityGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents HoverOpacityGroupBox As System.Windows.Forms.GroupBox
End Class
