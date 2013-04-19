<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemoveForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RemoveForm))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.buttonOK = New System.Windows.Forms.Button()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.Protip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FlavorTextLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 42)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox1.Size = New System.Drawing.Size(260, 186)
        Me.ListBox1.TabIndex = 0
        '
        'buttonOK
        '
        Me.buttonOK.Location = New System.Drawing.Point(12, 234)
        Me.buttonOK.Name = "buttonOK"
        Me.buttonOK.Size = New System.Drawing.Size(105, 23)
        Me.buttonOK.TabIndex = 1
        Me.buttonOK.Text = "&Remove item(s)"
        Me.buttonOK.UseVisualStyleBackColor = True
        '
        'buttonCancel
        '
        Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonCancel.Location = New System.Drawing.Point(167, 234)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(105, 23)
        Me.buttonCancel.TabIndex = 1
        Me.buttonCancel.Text = "&Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'FlavorTextLabel
        '
        Me.FlavorTextLabel.Location = New System.Drawing.Point(9, 9)
        Me.FlavorTextLabel.Name = "FlavorTextLabel"
        Me.FlavorTextLabel.Size = New System.Drawing.Size(263, 30)
        Me.FlavorTextLabel.TabIndex = 2
        Me.FlavorTextLabel.Text = "Please select the items you wish to remove. You can hold CTRL to select several i" & _
    "tems at once."
        '
        'RemoveForm
        '
        Me.AcceptButton = Me.buttonOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.buttonCancel
        Me.ClientSize = New System.Drawing.Size(284, 268)
        Me.Controls.Add(Me.FlavorTextLabel)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.buttonOK)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RemoveForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Remove item(s)"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents buttonOK As System.Windows.Forms.Button
    Friend WithEvents buttonCancel As System.Windows.Forms.Button
    Friend WithEvents Protip As System.Windows.Forms.ToolTip
    Friend WithEvents FlavorTextLabel As System.Windows.Forms.Label
End Class
