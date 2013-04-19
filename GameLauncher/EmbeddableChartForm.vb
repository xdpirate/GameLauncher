Public Class EmbeddableChartForm

    Private Sub btnCopy_Click(sender As System.Object, e As System.EventArgs) Handles CopyButton.Click
        My.Computer.Clipboard.SetText(LinkTextBox.Text)
        MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("EmbeddableChartFormCopiedToClipBoardText"), "Game Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub isgdLinkLabel_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        System.Diagnostics.Process.Start("http://is.gd/")
    End Sub

    Private Sub btnVisitLink_Click(sender As System.Object, e As System.EventArgs) Handles VisitLinkButton.Click
        System.Diagnostics.Process.Start(LinkTextBox.Text)
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles GTFOButton.Click
        Me.Close()
    End Sub

    Private Sub EmbeddableChartForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Multi-language stuff
        Me.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("EmbeddableChartFormTitleBar")
        FlavorTextLabel.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("EmbeddableChartFormFlavorTextLabel")
        CopyButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("EmbeddableChartFormCopyButton")
        VisitLinkButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("EmbeddableChartFormVisitLinkButton")
        GTFOButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("EmbeddableChartFormGTFOButton")
        CourtesyLabel.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("EmbeddableChartFormCourtesyLabel")
    End Sub
End Class