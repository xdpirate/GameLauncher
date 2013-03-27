Public Class AboutForm

    Private Sub WebsiteLink_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles WebsiteLink.LinkClicked
        System.Diagnostics.Process.Start("http://gamelauncher.pvpsucks.com/")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("mailto:retrocrew.djlarz@gmail.com")
    End Sub

    Private Sub CloseButton_Click(sender As System.Object, e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub AboutForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Game Launcher v" & My.Application.Info.Version.ToString
        RichTextBox1.Rtf = My.Resources.rtfInfo
    End Sub

    Private Sub RichTextBox1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            Dim webVersion As String = MainForm.phoneHome()
            Dim newVersion As New Version(Val(webVersion(0)), Val(webVersion(1)), Val(webVersion(2)), Val(webVersion(3)))
            If CInt(webVersion) > MainForm.GL_VERSION Then
                If MessageBox.Show("There is a new version of Game Launcher available (v" & newVersion.ToString & ")!" & vbNewLine & _
                                   "Would you like to download it now?", _
                                    My.Application.Info.AssemblyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                    MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    System.Diagnostics.Process.Start("http://code.google.com/p/game-launcher/downloads/detail?name=GameLauncher-v" & newVersion.ToString & ".rar")
                End If
            Else
                MessageBox.Show("Your Game Launcher installation is up to date!", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occured while checking for updates:" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & "Please try again later, " & _
                            "or contact the author if the problem persists.", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class