Imports System.IO

Public Class AddNewGameForm

    Public currentIcon As Image = Nothing

    Sub resetForm()
        gameNameTextBox.Text = Nothing
        commandLineTextBox.Text = Nothing
        normalGameRadio.Checked = True
        gamePathTextBox.Text = Nothing
        usesLauncherCheckBox.Checked = False
        launcherPathTextBox.Text = Nothing
        steamAppIDTextBox.Text = Nothing
        specifySteamExeCheckBox.Checked = False
        steamExePathTextBox.Text = Nothing
        getFromExeRadio.Checked = True
        gameIconPreviewBox.BackgroundImage = Nothing
        customIconPathTextBox.Text = Nothing
        keepCurrentIconRadio.Enabled = False
        currentIcon = Nothing
    End Sub

    Sub setHelp(ByVal helpText As String)
        helpTextLabel.ForeColor = Color.Black
        helpTextLabel.Text = helpText
    End Sub

    Sub resetHelp()
        helpTextLabel.ForeColor = Color.DarkGray
        helpTextLabel.Text = "Hover over an item to show help in this panel."
    End Sub

    Private Sub AddNewGameForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub AddNewGameForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim controls As Control() = {gameNameTextBox, commandLineTextBox, getFromExeRadio, getFromOtherFileRadio, iconBrowseButton, gameIconPreviewBox, _
                                     normalGameRadio, pathBrowseButton, usesLauncherCheckBox, launcherBrowseButton, steamGameRadio, steamAppIDTextBox, _
                                     okayButton, cancelAddGameButton, specifySteamExeCheckBox}

        For Each helpControl As Control In controls
            AddHandler helpControl.MouseLeave, AddressOf resetHelp
        Next
    End Sub

    Private Sub gameNameTextBox_MouseEnter(sender As System.Object, e As System.EventArgs) Handles gameNameTextBox.MouseEnter
        setHelp("Enter the name of the game to be added here. It can be named anything, but equals signs (=) will be replaced with dashes (-) due to technical limitations.")
    End Sub

    Private Sub commandLineTextBox_MouseEnter(sender As System.Object, e As System.EventArgs) Handles commandLineTextBox.MouseEnter
        setHelp("Enter the command-line arguments to be used when launching the game. If you don't know what this is, you can leave it empty.")
    End Sub

    Private Sub getFromExeRadio_MouseEnter(sender As System.Object, e As System.EventArgs) Handles getFromExeRadio.MouseEnter
        setHelp("Select this option if you want Game Launcher to get the game icon from the chosen game executable.")
    End Sub

    Private Sub getFromOtherFileRadio_MouseEnter(sender As System.Object, e As System.EventArgs) Handles getFromOtherFileRadio.MouseEnter
        setHelp("Select this option if you want to specify an icon yourself.")
    End Sub

    Private Sub iconBrowseButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles iconBrowseButton.MouseEnter
        setHelp("Click this button to select a custom icon. It must be a BMP, PNG, GIF, JPG or ICO image, and will be resized to 16x16. " & _
                "You can also specify an EXE-file to extract its main icon and use it. The image will have its aspect ratio preserved.")
    End Sub

    Private Sub normalGameRadio_MouseEnter(sender As System.Object, e As System.EventArgs) Handles normalGameRadio.MouseEnter
        setHelp("Select this option if this is a normal game (i.e. it does not use Steam).")
    End Sub

    Private Sub pathBrowseButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles pathBrowseButton.MouseEnter
        setHelp("Click this button to select the executable used to run the game. This is typically an .exe-file.")
    End Sub

    Private Sub usesLauncherCheckBox_MouseEnter(sender As System.Object, e As System.EventArgs) Handles usesLauncherCheckBox.MouseEnter
        setHelp("Check this box if the game you are adding uses a launcher. A launcher is an executable that will in turn launch the main game. Enabling this " & _
                "will enable playtime tracking for games that require being launched with a launcher.")
    End Sub

    Private Sub launcherBrowseButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles launcherBrowseButton.MouseEnter
        setHelp("Click this button to select the launcher used to launch the main game executable.")
    End Sub

    Private Sub steamGameRadio_MouseEnter(sender As System.Object, e As System.EventArgs) Handles steamGameRadio.MouseEnter
        setHelp("Select this option if this is a game that must be launched through Steam.")
    End Sub

    Private Sub TextBox1_MouseEnter(sender As System.Object, e As System.EventArgs) Handles steamAppIDTextBox.MouseEnter
        setHelp("Enter the Steam App ID here. To find the ID, locate the game in the Steam Store, and copy the ID from the last " & _
                "part of the URL (e.g. http://store.steampowered.com/app/24980/ -> The ID here is 24980)")
    End Sub

    Private Sub cancelAddGameButton_Click(sender As System.Object, e As System.EventArgs) Handles cancelAddGameButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub gameIconPreviewBox_MouseEnter(sender As System.Object, e As System.EventArgs) Handles gameIconPreviewBox.MouseEnter
        setHelp("This shows a preview of the icon that will be used. If Game Launcher is set to retrieve the icon from the executable " & _
                "for the game, you must specify the executable before this preview will update.")
    End Sub

    Private Sub getFromOtherFileRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles getFromOtherFileRadio.CheckedChanged
        If getFromOtherFileRadio.Checked = True Then
            iconBrowseButton.Enabled = True
            customIconPathTextBox.Enabled = True

            If customIconPathTextBox.Text <> "" Then
                Dim fileName As String = customIconPathTextBox.Text
                Dim sourceBitmap As Bitmap
                Dim extension As String = Path.GetExtension(fileName).ToLower

                Select Case extension
                    Case ".exe"
                        sourceBitmap = New Bitmap(MainForm.GetSmallIcon(fileName).ToBitmap)
                        gameIconPreviewBox.BackgroundImage = sourceBitmap

                        If sourceBitmap.Width <= 16 And sourceBitmap.Height <= 16 Then
                            Exit Sub
                        End If
                    Case Else
                        sourceBitmap = New Bitmap(fileName)
                End Select

                gameIconPreviewBox.BackgroundImage = MainForm.ResizeImage(sourceBitmap, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBilinear, True)
            End If
        End If
    End Sub

    Private Sub normalGameRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles normalGameRadio.CheckedChanged
        If normalGameRadio.Checked = True Then
            gamePathTextBox.Enabled = True
            pathBrowseButton.Enabled = True
            usesLauncherCheckBox.Enabled = True

            If usesLauncherCheckBox.Checked = True Then
                launcherPathTextBox.Enabled = True
                launcherBrowseButton.Enabled = True
            Else
                launcherPathTextBox.Enabled = False
                launcherBrowseButton.Enabled = False
            End If

            steamAppIDTextBox.Enabled = False
            specifySteamExeCheckBox.Enabled = False
            steamExePathTextBox.Enabled = False
            steamExeBrowseButton.Enabled = False
        Else
            gamePathTextBox.Enabled = False
            pathBrowseButton.Enabled = False
            usesLauncherCheckBox.Enabled = False
            launcherPathTextBox.Enabled = False
            launcherBrowseButton.Enabled = False
            steamAppIDTextBox.Enabled = True
            specifySteamExeCheckBox.Enabled = True

            If specifySteamExeCheckBox.Checked = True Then
                steamExePathTextBox.Enabled = True
                steamExeBrowseButton.Enabled = True
            Else
                steamExePathTextBox.Enabled = False
                steamExeBrowseButton.Enabled = False
            End If
        End If
    End Sub

    Private Sub okayButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles okayButton.MouseEnter
        setHelp("Click this button when you are done filling out the details of the game to be added.")
    End Sub

    Private Sub cancelAddGameButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles cancelAddGameButton.MouseEnter
        setHelp("Click this button if you wish to cancel adding this game. If you have more games queued up to be added " & _
                "(e.g. if using the drop window or right-clicking items in Explorer), you will need to cancel them all. ")
    End Sub

    Private Sub specifySteamExeCheckBox_MouseEnter(sender As System.Object, e As System.EventArgs) Handles specifySteamExeCheckBox.MouseEnter
        setHelp("Check this box if you want to select the executable Steam uses to run the game. Enabling this will enable playtime tracking for " & _
                "Steam games. If the game uses a launcher, you do not need to select it, simply select the main executable the game runs from.")
    End Sub

    Private Sub steamExeBrowseButton_MouseEnter(sender As System.Object, e As System.EventArgs) Handles steamExeBrowseButton.MouseEnter
        setHelp("Click here to browse for the main executable Steam uses to run the game.")
    End Sub

    Private Sub usesLauncherCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles usesLauncherCheckBox.CheckedChanged
        If usesLauncherCheckBox.Checked = True Then
            launcherPathTextBox.Enabled = True
            launcherBrowseButton.Enabled = True
        Else
            launcherPathTextBox.Enabled = False
            launcherBrowseButton.Enabled = False
        End If
    End Sub

    Private Sub specifySteamExeCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles specifySteamExeCheckBox.CheckedChanged
        If specifySteamExeCheckBox.Checked = True Then
            steamExePathTextBox.Enabled = True
            steamExeBrowseButton.Enabled = True
        Else
            steamExePathTextBox.Enabled = False
            steamExeBrowseButton.Enabled = False
        End If
    End Sub

    Private Sub pathBrowseButton_Click(sender As System.Object, e As System.EventArgs) Handles pathBrowseButton.Click
        If browseForExeDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            gamePathTextBox.Text = browseForExeDialog.FileName

            If getFromExeRadio.Checked = True Then
                Dim fileName As String = gamePathTextBox.Text
                Dim sourceBitmap As Bitmap
                Dim extension As String = Path.GetExtension(fileName).ToLower

                Select Case extension
                    Case ".exe"
                        sourceBitmap = New Bitmap(MainForm.GetSmallIcon(fileName).ToBitmap)
                        gameIconPreviewBox.BackgroundImage = sourceBitmap

                        If sourceBitmap.Width <= 16 And sourceBitmap.Height <= 16 Then
                            Exit Sub
                        End If
                    Case Else
                        sourceBitmap = New Bitmap(fileName)
                End Select

                gameIconPreviewBox.BackgroundImage = MainForm.ResizeImage(sourceBitmap, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBilinear, True)
            End If

            browseForExeDialog.FileName = Nothing
        End If
    End Sub

    Private Sub launcherBrowseButton_Click(sender As System.Object, e As System.EventArgs) Handles launcherBrowseButton.Click
        If browseForExeDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            launcherPathTextBox.Text = browseForExeDialog.FileName
            browseForExeDialog.FileName = Nothing
        End If
    End Sub

    Private Sub steamExeBrowseButton_Click(sender As System.Object, e As System.EventArgs) Handles steamExeBrowseButton.Click
        If browseForExeDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            steamExePathTextBox.Text = browseForExeDialog.FileName
            browseForExeDialog.FileName = Nothing

            If getFromExeRadio.Checked Then
                Dim fileName As String = steamExePathTextBox.Text
                Dim sourceBitmap As Bitmap
                Dim extension As String = Path.GetExtension(fileName).ToLower

                Select Case extension
                    Case ".exe"
                        sourceBitmap = New Bitmap(MainForm.GetSmallIcon(fileName).ToBitmap)
                        gameIconPreviewBox.BackgroundImage = sourceBitmap

                        If sourceBitmap.Width <= 16 And sourceBitmap.Height <= 16 Then
                            Exit Sub
                        End If
                    Case Else
                        sourceBitmap = New Bitmap(fileName)
                End Select

                gameIconPreviewBox.BackgroundImage = MainForm.ResizeImage(sourceBitmap, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBilinear, True)
            End If
        End If
    End Sub

    Private Sub iconBrowseButton_Click(sender As System.Object, e As System.EventArgs) Handles iconBrowseButton.Click
        If browseForIconDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            customIconPathTextBox.Text = browseForIconDialog.FileName
            browseForIconDialog.FileName = Nothing
            Dim fileName As String = customIconPathTextBox.Text
            Dim sourceBitmap As Bitmap
            Dim extension As String = Path.GetExtension(fileName).ToLower

            Select Case extension
                Case ".exe"
                    sourceBitmap = New Bitmap(MainForm.GetSmallIcon(fileName).ToBitmap)
                    gameIconPreviewBox.BackgroundImage = sourceBitmap

                    If sourceBitmap.Width <= 16 And sourceBitmap.Height <= 16 Then
                        Exit Sub
                    End If
                Case Else
                    sourceBitmap = New Bitmap(fileName)
            End Select

            gameIconPreviewBox.BackgroundImage = MainForm.ResizeImage(sourceBitmap, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBilinear, True)
        End If
    End Sub

    Private Sub okayButton_Click(sender As System.Object, e As System.EventArgs) Handles okayButton.Click
        'Put values in vars
        Dim gameName, cmdArgs, gamePath, launcherPath, steamAppID, steamExePath As String

        gameName = ""
        cmdArgs = ""
        gamePath = ""
        launcherPath = ""
        steamAppID = ""
        steamExePath = ""

        gameName = gameNameTextBox.Text.Trim.Replace("="c, "-"c).Replace("&", "&&")
        cmdArgs = commandLineTextBox.Text.Trim.Replace("=", "|||")

        If normalGameRadio.Checked Then
            gamePath = gamePathTextBox.Text.Trim
        Else
            steamAppID = steamAppIDTextBox.Text.Trim
        End If

        If usesLauncherCheckBox.Checked Then
            launcherPath = launcherPathTextBox.Text.Trim
        End If

        If specifySteamExeCheckBox.Checked Then
            steamExePath = steamExePathTextBox.Text.Trim
        End If

        'Validate the form
        If gameName = "" Then
            MessageBox.Show("You must specify a name for the game.", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            gameNameTextBox.Focus()
        ElseIf normalGameRadio.Checked And gamePath = "" Then
            MessageBox.Show("You must specify a path for the main executable.", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            gamePathTextBox.Focus()
        ElseIf normalGameRadio.Checked And usesLauncherCheckBox.Checked And launcherPath = "" Then
            MessageBox.Show("You must specify a path to the launcher.", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            launcherPathTextBox.Focus()
        ElseIf steamGameRadio.Checked And steamAppID = "" Then
            MessageBox.Show("You must enter the Steam App ID for the game.", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            steamAppIDTextBox.Focus()
        ElseIf steamGameRadio.Checked And specifySteamExeCheckBox.Checked And steamExePath = "" Then
            MessageBox.Show("You must specify a path to the executable Steam uses to launch the game.", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            steamExePathTextBox.Focus()
        ElseIf steamGameRadio.Checked And getFromExeRadio.Checked And specifySteamExeCheckBox.Checked = False Then
            MessageBox.Show("You cannot select ""Get from executable"" for the icon if you haven't specified an executable for a Steam game.", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf steamGameRadio.Checked And getFromOtherFileRadio.Checked And customIconPathTextBox.Text = "" Then
            MessageBox.Show("You must specify an icon for this Steam game.", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            customIconPathTextBox.Focus()
        ElseIf normalGameRadio.Checked And getFromOtherFileRadio.Checked And customIconPathTextBox.Text = "" Then
            MessageBox.Show("You must specify an icon if ""Get from other file"" is selected.", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            customIconPathTextBox.Focus()
        Else
            'Everything seems to be in order, now check the validity of the specified exes, if any
            If normalGameRadio.Checked And File.Exists(gamePath) = False Then
                MessageBox.Show("The main game executable could not be found: " & vbNewLine & gamePath, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf normalGameRadio.Checked And usesLauncherCheckBox.Checked And File.Exists(launcherPath) = False Then
                MessageBox.Show("The launcher executable could not be found: " & vbNewLine & launcherPath, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf steamGameRadio.Checked And specifySteamExeCheckBox.Checked And File.Exists(steamExePath) = False Then
                MessageBox.Show("The specified executable for the Steam game could not be found: " & vbNewLine & steamExePath, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                'EXEs exist, all systems are go!
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub AddNewGameForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        AppActivate(Me.Text)
        gameNameTextBox.Focus()
        gameNameTextBox.SelectAll()
    End Sub

    Private Sub keepCurrentIconRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles keepCurrentIconRadio.CheckedChanged
        If keepCurrentIconRadio.Checked Then
            gameIconPreviewBox.BackgroundImage = currentIcon
        End If
    End Sub

    Private Sub getFromExeRadio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles getFromExeRadio.CheckedChanged
        If getFromExeRadio.Checked = True Then
            iconBrowseButton.Enabled = False
            customIconPathTextBox.Enabled = False

            If normalGameRadio.Checked Then
                If gamePathTextBox.Text <> "" Then
                    Dim fileName As String = gamePathTextBox.Text
                    Dim sourceBitmap As Bitmap
                    Dim extension As String = Path.GetExtension(fileName).ToLower

                    Select Case extension
                        Case ".exe"
                            sourceBitmap = New Bitmap(MainForm.GetSmallIcon(fileName).ToBitmap)
                            gameIconPreviewBox.BackgroundImage = sourceBitmap

                            If sourceBitmap.Width <= 16 And sourceBitmap.Height <= 16 Then
                                Exit Sub
                            End If
                        Case Else
                            sourceBitmap = New Bitmap(fileName)
                    End Select

                    gameIconPreviewBox.BackgroundImage = MainForm.ResizeImage(sourceBitmap, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBilinear, True)
                End If
            ElseIf specifySteamExeCheckBox.Checked = True Then
                If steamExePathTextBox.Text <> "" Then
                    Dim fileName As String = steamExePathTextBox.Text
                    Dim sourceBitmap As Bitmap
                    Dim extension As String = Path.GetExtension(fileName).ToLower

                    Select Case extension
                        Case ".exe"
                            sourceBitmap = New Bitmap(MainForm.GetSmallIcon(fileName).ToBitmap)
                            gameIconPreviewBox.BackgroundImage = sourceBitmap

                            If sourceBitmap.Width <= 16 And sourceBitmap.Height <= 16 Then
                                Exit Sub
                            End If
                        Case Else
                            sourceBitmap = New Bitmap(fileName)
                    End Select

                    gameIconPreviewBox.BackgroundImage = MainForm.ResizeImage(sourceBitmap, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBilinear, True)
                End If
            End If
        End If
    End Sub
End Class