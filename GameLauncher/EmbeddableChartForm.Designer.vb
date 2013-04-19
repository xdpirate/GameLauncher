<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmbeddableChartForm
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
        Me.LinkTextBox = New System.Windows.Forms.TextBox()
        Me.CopyButton = New System.Windows.Forms.Button()
        Me.VisitLinkButton = New System.Windows.Forms.Button()
        Me.GTFOButton = New System.Windows.Forms.Button()
        Me.FlavorTextLabel = New System.Windows.Forms.Label()
        Me.CourtesyLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LinkTextBox
        '
        Me.LinkTextBox.Location = New System.Drawing.Point(15, 27)
        Me.LinkTextBox.Name = "LinkTextBox"
        Me.LinkTextBox.ReadOnly = True
        Me.LinkTextBox.Size = New System.Drawing.Size(217, 20)
        Me.LinkTextBox.TabIndex = 0
        '
        'CopyButton
        '
        Me.CopyButton.Location = New System.Drawing.Point(238, 25)
        Me.CopyButton.Name = "CopyButton"
        Me.CopyButton.Size = New System.Drawing.Size(92, 23)
        Me.CopyButton.TabIndex = 1
        Me.CopyButton.Text = "&Copy"
        Me.CopyButton.UseVisualStyleBackColor = True
        '
        'VisitLinkButton
        '
        Me.VisitLinkButton.Location = New System.Drawing.Point(238, 54)
        Me.VisitLinkButton.Name = "VisitLinkButton"
        Me.VisitLinkButton.Size = New System.Drawing.Size(92, 23)
        Me.VisitLinkButton.TabIndex = 2
        Me.VisitLinkButton.Text = "&Visit link"
        Me.VisitLinkButton.UseVisualStyleBackColor = True
        '
        'GTFOButton
        '
        Me.GTFOButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.GTFOButton.Location = New System.Drawing.Point(238, 83)
        Me.GTFOButton.Name = "GTFOButton"
        Me.GTFOButton.Size = New System.Drawing.Size(92, 23)
        Me.GTFOButton.TabIndex = 3
        Me.GTFOButton.Text = "Clos&e"
        Me.GTFOButton.UseVisualStyleBackColor = True
        '
        'FlavorTextLabel
        '
        Me.FlavorTextLabel.AutoSize = True
        Me.FlavorTextLabel.Location = New System.Drawing.Point(12, 9)
        Me.FlavorTextLabel.Name = "FlavorTextLabel"
        Me.FlavorTextLabel.Size = New System.Drawing.Size(295, 13)
        Me.FlavorTextLabel.TabIndex = 4
        Me.FlavorTextLabel.Text = "Success! Send the link below to your friends and loved ones:"
        '
        'CourtesyLabel
        '
        Me.CourtesyLabel.AutoSize = True
        Me.CourtesyLabel.Location = New System.Drawing.Point(12, 96)
        Me.CourtesyLabel.Name = "CourtesyLabel"
        Me.CourtesyLabel.Size = New System.Drawing.Size(133, 13)
        Me.CourtesyLabel.TabIndex = 5
        Me.CourtesyLabel.Text = "Shortlinks courtesy of is.gd"
        '
        'EmbeddableChartForm
        '
        Me.AcceptButton = Me.CopyButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.GTFOButton
        Me.ClientSize = New System.Drawing.Size(342, 121)
        Me.Controls.Add(Me.CourtesyLabel)
        Me.Controls.Add(Me.FlavorTextLabel)
        Me.Controls.Add(Me.GTFOButton)
        Me.Controls.Add(Me.VisitLinkButton)
        Me.Controls.Add(Me.CopyButton)
        Me.Controls.Add(Me.LinkTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EmbeddableChartForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Linkable chart"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LinkTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CopyButton As System.Windows.Forms.Button
    Friend WithEvents VisitLinkButton As System.Windows.Forms.Button
    Friend WithEvents GTFOButton As System.Windows.Forms.Button
    Friend WithEvents FlavorTextLabel As System.Windows.Forms.Label
    Friend WithEvents CourtesyLabel As System.Windows.Forms.Label
End Class
