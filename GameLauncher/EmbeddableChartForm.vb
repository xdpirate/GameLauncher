Public Class EmbeddableChartForm

    Private Sub btnCopy_Click(sender As System.Object, e As System.EventArgs) Handles btnCopy.Click
        My.Computer.Clipboard.SetText(TextBox1.Text)
        MessageBox.Show("Link copied to the clipboard!", "Copy to clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub isgdLinkLabel_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles isgdLinkLabel.LinkClicked
        System.Diagnostics.Process.Start("http://is.gd/")
    End Sub

    Private Sub btnVisitLink_Click(sender As System.Object, e As System.EventArgs) Handles btnVisitLink.Click
        System.Diagnostics.Process.Start(TextBox1.Text)
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class