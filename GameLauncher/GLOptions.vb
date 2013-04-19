Imports Microsoft.Win32

Public Class GLOptions

    Private Sub GLOptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        runOnStartUpCheckBox.Checked = MainForm.toggleRunOnStartup(True)
        sendSkypeNotificationsCheckBox.Checked = MainForm.toggleSkypeNotifications(True)
        playTimeInSkypeNotificationsCheckBox.Checked = MainForm.togglePlayTimeInSkypeNotifications(MainForm.playTimeToggleType.check)
        playTimeInSkypeNotificationsCheckBox.Enabled = sendSkypeNotificationsCheckBox.Checked
        integrateWithExplorerCheckBox.Checked = toggleShellExtension(True)

        Dim autoUpdateKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim value As Integer = CInt(autoUpdateKey.GetValue("autoUpdate", 9001))
        If value = 9001 Then
            'Doesn't exist, create it and set it to be enabled
            autoUpdateKey.SetValue("autoUpdate", 1, RegistryValueKind.DWord)
            autoUpdateCheckBox.Checked = True
        ElseIf value = 1 Then
            'AutoUpdate is enabled
            autoUpdateCheckBox.Checked = True
        ElseIf value = 0 Then
            'AutoUpdate is disabled
            autoUpdateCheckBox.Checked = False
        End If

        'Get or set language
        Dim languageKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim currentLanguage As String = languageKey.GetValue("currentLanguage", Nothing)

        If currentLanguage Is Nothing Then
            LanguagePicker.SelectedItem = "English"
        Else
            LanguagePicker.SelectedItem = currentLanguage
        End If

        ' Multi-language stuff
        Me.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("GLOptionsFormTitleBar")
        PreferencesGroupBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("GLOptionsFormPreferencesGroupBox")
        integrateWithExplorerCheckBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("GLOptionsFormIntegrateWithExplorerCheckBox")
        runOnStartUpCheckBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("GLOptionsFormStartOnLoginCheckBox")
        sendSkypeNotificationsCheckBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("GLOptionsFormSkypeNotificationsCheckBox")
        playTimeInSkypeNotificationsCheckBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("GLOptionsFormPlayTimeInSkypeNotificationsCheckBox")
        autoUpdateCheckBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("GLOptionsFormAutoUpdateCheckBox")
        GTFOButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("GLOptionsFormGTFOButton")
    End Sub

    Private Sub runOnStartUpCheckBox_Click(sender As Object, e As System.EventArgs) Handles runOnStartUpCheckBox.Click
        runOnStartUpCheckBox.Checked = MainForm.toggleRunOnStartup(False)
    End Sub

    Private Sub sendSkypeNotificationsCheckBox_Click(sender As Object, e As System.EventArgs) Handles sendSkypeNotificationsCheckBox.Click
        sendSkypeNotificationsCheckBox.Checked = MainForm.toggleSkypeNotifications(False)
        playTimeInSkypeNotificationsCheckBox.Enabled = sendSkypeNotificationsCheckBox.Checked
    End Sub

    Private Sub playTimeInSkypeNotificationsCheckBox_Click(sender As Object, e As System.EventArgs) Handles playTimeInSkypeNotificationsCheckBox.Click
        playTimeInSkypeNotificationsCheckBox.Checked = MainForm.togglePlayTimeInSkypeNotifications(MainForm.playTimeToggleType.toggle)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles GTFOButton.Click
        Me.Close()
    End Sub

    Public Sub setShellKeys()
        Dim exeKey As RegistryKey = My.Computer.Registry.ClassesRoot.CreateSubKey("exefile\shell\addtogl", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim batKey As RegistryKey = My.Computer.Registry.ClassesRoot.CreateSubKey("batfile\shell\addtogl", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim jarKey As RegistryKey = My.Computer.Registry.ClassesRoot.CreateSubKey("jarfile\shell\addtogl", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim cmdKey As RegistryKey = My.Computer.Registry.ClassesRoot.CreateSubKey("cmdfile\shell\addtogl", RegistryKeyPermissionCheck.ReadWriteSubTree)

        Dim exeKeyCommand As RegistryKey = My.Computer.Registry.ClassesRoot.CreateSubKey("exefile\shell\addtogl\command", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim batKeyCommand As RegistryKey = My.Computer.Registry.ClassesRoot.CreateSubKey("batfile\shell\addtogl\command", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim jarKeyCommand As RegistryKey = My.Computer.Registry.ClassesRoot.CreateSubKey("jarfile\shell\addtogl\command", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim cmdKeyCommand As RegistryKey = My.Computer.Registry.ClassesRoot.CreateSubKey("cmdfile\shell\addtogl\command", RegistryKeyPermissionCheck.ReadWriteSubTree)

        Dim text As String = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("GLOptionsFormExplorerIntegrationText")

        exeKey.SetValue("", text, RegistryValueKind.String)
        batKey.SetValue("", text, RegistryValueKind.String)
        jarKey.SetValue("", text, RegistryValueKind.String)
        cmdKey.SetValue("", text, RegistryValueKind.String)

        text = """" & Application.ExecutablePath & """"

        exeKey.SetValue("Icon", text, RegistryValueKind.String)
        batKey.SetValue("Icon", text, RegistryValueKind.String)
        jarKey.SetValue("Icon", text, RegistryValueKind.String)
        cmdKey.SetValue("Icon", text, RegistryValueKind.String)

        text = """" & Application.ExecutablePath & """ ""%1"""

        exeKeyCommand.SetValue("", text, RegistryValueKind.String)
        batKeyCommand.SetValue("", text, RegistryValueKind.String)
        jarKeyCommand.SetValue("", text, RegistryValueKind.String)
        cmdKeyCommand.SetValue("", text, RegistryValueKind.String)
    End Sub

    Public Sub removeShellKeys()
        Try
            My.Computer.Registry.ClassesRoot.DeleteSubKeyTree("exefile\shell\addtogl")
            My.Computer.Registry.ClassesRoot.DeleteSubKeyTree("batfile\shell\addtogl")
            My.Computer.Registry.ClassesRoot.DeleteSubKeyTree("jarfile\shell\addtogl")
            My.Computer.Registry.ClassesRoot.DeleteSubKeyTree("cmdfile\shell\addtogl")
        Catch ex As Exception

        End Try
    End Sub

    Public Function toggleShellExtension(ByVal check As Boolean) As Boolean
        Dim regKey As Microsoft.Win32.RegistryKey

        regKey = My.Computer.Registry.ClassesRoot.OpenSubKey("exefile\shell\addtogl", True)

        If regKey Is Nothing Then
            If check Then
                Return False
            Else
                ' Turn on
                setShellKeys()
                Return True
            End If
        Else
            If check Then
                Return True
            Else
                ' Turn off
                removeShellKeys()
                Return False
            End If
        End If
    End Function

    Private Sub integrateWithExplorerCheckBox_Click(sender As Object, e As System.EventArgs) Handles integrateWithExplorerCheckBox.Click
        integrateWithExplorerCheckBox.Checked = toggleShellExtension(False)
    End Sub

    Private Sub autoUpdateCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles autoUpdateCheckBox.CheckedChanged
        Dim autoUpdateKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        If autoUpdateCheckBox.Checked Then
            autoUpdateKey.SetValue("autoUpdate", 1, RegistryValueKind.DWord)
            MainForm.skipUpdateThisSession = False
            MainForm.UpdateChecker.Enabled = True
        Else
            autoUpdateKey.SetValue("autoUpdate", 0, RegistryValueKind.DWord)
        End If
    End Sub

    Private Sub LanguagePicker_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LanguagePicker.SelectedIndexChanged
        Dim languageKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        languageKey.SetValue("currentLanguage", LanguagePicker.SelectedItem)
    End Sub
End Class