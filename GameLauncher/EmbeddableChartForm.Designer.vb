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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnVisitLink = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.isgdLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(15, 27)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(217, 20)
        Me.TextBox1.TabIndex = 0
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(238, 25)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(92, 23)
        Me.btnCopy.TabIndex = 1
        Me.btnCopy.Text = "&Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnVisitLink
        '
        Me.btnVisitLink.Location = New System.Drawing.Point(238, 54)
        Me.btnVisitLink.Name = "btnVisitLink"
        Me.btnVisitLink.Size = New System.Drawing.Size(92, 23)
        Me.btnVisitLink.TabIndex = 2
        Me.btnVisitLink.Text = "&Visit link"
        Me.btnVisitLink.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(238, 83)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(92, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(295, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Success! Send the link below to your friends and loved ones:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Shortlinks courtesy of"
        '
        'isgdLinkLabel
        '
        Me.isgdLinkLabel.AutoSize = True
        Me.isgdLinkLabel.Location = New System.Drawing.Point(118, 96)
        Me.isgdLinkLabel.Name = "isgdLinkLabel"
        Me.isgdLinkLabel.Size = New System.Drawing.Size(29, 13)
        Me.isgdLinkLabel.TabIndex = 6
        Me.isgdLinkLabel.TabStop = True
        Me.isgdLinkLabel.Text = "is.gd"
        '
        'EmbeddableChartForm
        '
        Me.AcceptButton = Me.btnCopy
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(342, 121)
        Me.Controls.Add(Me.isgdLinkLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnVisitLink)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.TextBox1)
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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnVisitLink As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents isgdLinkLabel As System.Windows.Forms.LinkLabel
End Class
