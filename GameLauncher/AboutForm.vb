Imports System.Net
Imports System.IO

Public Class AboutForm

    Private Sub WebsiteLink_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles WebsiteLink.LinkClicked
        System.Diagnostics.Process.Start("http://gamelauncher.pvpsucks.com/")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ContactLink.LinkClicked
        System.Diagnostics.Process.Start("mailto:retrocrew.djlarz@gmail.com")
    End Sub

    Private Sub CloseButton_Click(sender As System.Object, e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub AboutForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Game Launcher v" & My.Application.Info.Version.ToString
        RichTextBox1.Rtf = My.Resources.rtfInfo

        'Set multi-language values
        AuthorNoteLabel.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AboutFormAuthorNote") & vbNewLine & MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("TranslationAuthor")
        UpdateCheckButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AboutFormUpdateCheckButtonText")
        WebsiteLink.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AboutFormWebsiteLinkText")
        ContactLink.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AboutFormContactText")
        CloseButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AboutFormCloseButtonText")
    End Sub

    Private Sub RichTextBox1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles UpdateCheckButton.Click
        Try
            Dim webVersion As String = MainForm.phoneHome()
            Dim newVersion As New Version(Val(webVersion(0)), Val(webVersion(1)), Val(webVersion(2)), Val(webVersion(3)))
            If CInt(webVersion) > MainForm.GL_VERSION Then

                Dim fileReader As New WebClient()
                Dim data As Stream
                Dim sr As StreamReader
                Dim changeLog As String
                Try
                    data = fileReader.OpenRead("http://gamelauncher.pvpsucks.com/changelog")
                    sr = New StreamReader(data)
                    changeLog = sr.ReadToEnd
                    data.Close()
                Catch ex As Exception
                    changeLog = String.Format("[Fetching the change log failed: {0}]", ex.Message)
                End Try

                If MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AboutFormNewVersion1") & newVersion.ToString & ")!" & vbNewLine & vbNewLine & _
                                   changeLog & vbNewLine & vbNewLine & _
                                   MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AboutFormNewVersion2"), _
                                    My.Application.Info.AssemblyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                    MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    System.Diagnostics.Process.Start("http://gamelauncher.pvpsucks.com/?q=dl")
                    End
                End If
            Else
                MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AboutFormUpToDate"), _
                                My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AboutFormUpdateError1") & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & _
                            MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AboutFormUpdateError2"), My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class