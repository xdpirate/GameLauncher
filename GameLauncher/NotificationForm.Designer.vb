<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotificationForm
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
        Me.btnYes = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnYes
        '
        Me.btnYes.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnYes.Location = New System.Drawing.Point(132, 115)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(75, 23)
        Me.btnYes.TabIndex = 0
        Me.btnYes.Text = "&Yes"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNo.Location = New System.Drawing.Point(213, 115)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(75, 23)
        Me.btnNo.TabIndex = 1
        Me.btnNo.Text = "&No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'NotificationForm
        '
        Me.AcceptButton = Me.btnYes
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = My.Resources.Resources.GL_Notification
        Me.CancelButton = Me.btnNo
        Me.ClientSize = New System.Drawing.Size(300, 150)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NotificationForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notification"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
End Class
