Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Drawing

Imports IniFile
Imports MCLHotkey

Public Class MainForm
#Region "Declarations"
    Public WithEvents oSkype As New SKYPE4COMLib.Skype

    Public GL_VERSION As Integer = getNumericVersion()
    Public CURRENT_LANGUAGE_RESOURCE As Resources.ResourceManager = My.Resources.mlsEnglish.ResourceManager

    Public PathContainer As New SortedDictionary(Of String, String)
    Public ArgsContainer As New SortedDictionary(Of String, String)
    Public IconsContainer As New SortedDictionary(Of String, String)
    Public LaunchersContainer As New SortedDictionary(Of String, String)

    Dim hotKeyComp As New MCLHotkey.SystemWideHotkeyComponent

    Public skipUpdateThisSession As Boolean = False
    Public sendSkypeNotification As Boolean = False
    Public playTimeInSkypeNotifications As Boolean = True

    Public currentRunningGame As String = Nothing
    Public currentRunningGameTimeStamp As Date = Nothing
    Public currentRunningGameProcess As Process = Nothing
    Public CurrentRunningGameProcessName As String = Nothing

    Public processMonitorTimer As New System.Threading.Timer(AddressOf processMonitorTimer_Tick, Nothing, System.Threading.Timeout.Infinite, 1000)
    Public processMonitorCounter As Integer = 0

    Dim skypeThread As New Thread(New ThreadStart(AddressOf skypeConnect))

    Dim steamIconPath As String = Path.Combine(My.Application.Info.DirectoryPath, "steamicons\")
    Dim iconPath As String = Path.Combine(My.Application.Info.DirectoryPath, "icons\")

    Public Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    Public Declare Auto Function SHGetFileInfo Lib "shell32.dll" _
            (ByVal pszPath As String, _
             ByVal dwFileAttributes As Integer, _
             ByRef psfi As SHFILEINFO, _
             ByVal cbFileInfo As Integer, _
             ByVal uFlags As Integer) As IntPtr

    Public Const SHGFI_ICON = &H100
    Public Const SHGFI_SMALLICON = &H1
    Public Const SHGFI_LARGEICON = &H0
    Public nIndex = 0
    Public hImgLarge As IntPtr

    Public Enum iniTypes
        settings = 0
        arguments = 1
        icons = 2
        launchers = 3
    End Enum

    Public Enum gameTypes
        normal = 0
        steam = 1
        normalWithLauncher = 2
        steamWithExe = 3
    End Enum
#End Region


    Public Function GetSmallIcon(ByVal FilePath As String) As System.Drawing.Icon
        Dim fName As String
        Dim shinfo As SHFILEINFO
        shinfo = New SHFILEINFO()

        shinfo.szDisplayName = New String(Chr(0), 260)
        shinfo.szTypeName = New String(Chr(0), 80)

        fName = FilePath

        hImgLarge = SHGetFileInfo(fName, 0,
        shinfo, Marshal.SizeOf(shinfo),
        SHGFI_ICON Or SHGFI_SMALLICON)

        Dim myIcon As System.Drawing.Icon
        myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon)

        Return myIcon
    End Function

    Public Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal interpolationMode As Drawing2D.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth, percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = interpolationMode
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    Sub createOrLoadINI(ByVal path As String, ByVal type As iniTypes)
        If File.Exists(path) Then
            Dim iniFile As New IniFile.IniFile(path)
            Dim zkeys As ArrayList = iniFile.GetKeys("entries")

            For counter As Integer = 0 To zkeys.Count Step 1
                If zkeys.Count = 0 Then Exit For
                Dim key As IniFile.Key = zkeys(counter)

                Select Case type
                    Case iniTypes.settings
                        addGame(key.Value, key.Name, True)
                    Case iniTypes.arguments
                        ArgsContainer.Add(key.Name, key.Value)
                    Case iniTypes.icons
                        IconsContainer.Add(key.Name, key.Value)
                    Case iniTypes.launchers
                        LaunchersContainer.Add(key.Name, key.Value)
                End Select

                If counter = zkeys.Count - 1 Then Exit For
            Next
        Else
            Dim iniFile As New IniFile.IniFile(path)
            iniFile.AddSection("entries")
            iniFile.Save(path)
        End If
    End Sub

    Public Sub takeGameViaCommandLine(ByVal args As String)
        Dim skip As Boolean = False
        Dim currentFile As String = args
        Dim currentExtension As String = System.IO.Path.GetExtension(currentFile.ToLower())
        Dim friendlyFileName As String = Path.GetFileNameWithoutExtension(currentFile)

        If currentExtension = ".lnk" Then
            'Shell shortcut
            Dim theShell As New IWshRuntimeLibrary.WshShell()
            Dim theShortcut As IWshRuntimeLibrary.WshShortcut = theShell.CreateShortcut(currentFile)
            currentFile = theShortcut.TargetPath
        ElseIf currentExtension = ".exe" Or currentExtension = ".bat" Or currentExtension = ".cmd" Or currentExtension = ".jar" Then
            'Executeable
        ElseIf currentExtension = ".url" Then
            'Internet shortcut (Steam shortcut)
            Dim iniFile As New IniFile.IniFile(currentFile)
            Dim keyz As ArrayList = iniFile.GetKeys("InternetShortcut")

            For counter As Integer = 0 To (keyz.Count - 1) Step 1
                Dim key As IniFile.Key = keyz(counter)
                If key.Name.ToLower = "url" Then
                    If key.Value.ToLower.StartsWith("steam://rungameid/") Then
                        currentFile = key.Value.ToLower
                        Exit For
                    Else
                        skip = True
                        Exit For
                    End If
                End If
            Next
        Else
            'Anything else
            skip = True
        End If

        If skip = False Then
            'For anyone interested enough to be reading the source, here is my rationale for
            'creating a new instance of AddNewGameForm instead of using the already instantiated one:

            'When applications receive command line arguments as they're running, they don't get them
            'as an array of values, nope. What you get are two separate values, that each fire separate events,
            'much like if you press an automatic gun's trigger twice in rapid succession instead of holding
            'it down long enough to fire two bullets. In the first case, you did two events (two presses) to
            'fire two bullets, but in the second case you only did one event to accomplish the same goal.

            'This is also true for how this works. I create a new instance of the add game window because if not,
            '.NET throws a hissy fit over the fact that I'm trying to show a dialog that's already being shown.
            'Creating new instances of the same form overcomes this, but creates several dialogs layered on top
            'of each other. It is, however, the lesser of two evils, and at least this way, it works the way it's
            'supposed to, albeit a bit cumbersome. I'll take cumbersome over not working any day!
            Dim tempANGF As New AddNewGameForm

            tempANGF.gameNameTextBox.Text = friendlyFileName

            If currentFile.StartsWith("steam://rungameid/") Then
                tempANGF.steamGameRadio.Checked = True
                tempANGF.steamAppIDTextBox.Text = currentFile.Remove(0, 18)
                tempANGF.getFromOtherFileRadio.Checked = True
            Else
                tempANGF.gamePathTextBox.Text = currentFile
                tempANGF.normalGameRadio.Checked = True
                tempANGF.getFromExeRadio.Checked = True

                Dim sourceBitmap As Bitmap = GetSmallIcon(currentFile).ToBitmap
                tempANGF.gameIconPreviewBox.BackgroundImage = sourceBitmap
            End If

            If tempANGF.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim gameName, cmdArgs, gamePath, launcherPath As String
                Dim gameType As gameTypes
                Dim img As Bitmap

                gamePath = Nothing
                launcherPath = Nothing

                'Determine type of game to be added
                If tempANGF.normalGameRadio.Checked Then
                    gamePath = tempANGF.gamePathTextBox.Text.Trim
                    If tempANGF.usesLauncherCheckBox.Checked Then
                        launcherPath = tempANGF.launcherPathTextBox.Text.Trim
                        gameType = gameTypes.normalWithLauncher
                    Else
                        gameType = gameTypes.normal
                    End If
                Else
                    gamePath = tempANGF.steamAppIDTextBox.Text.Trim
                    If tempANGF.specifySteamExeCheckBox.Checked Then
                        launcherPath = tempANGF.steamExePathTextBox.Text.Trim
                        gameType = gameTypes.steamWithExe
                    Else
                        gameType = gameTypes.steam
                    End If
                End If

                gameName = tempANGF.gameNameTextBox.Text.Trim.Replace("="c, "-"c).Replace("&", "&&")
                cmdArgs = tempANGF.commandLineTextBox.Text.Trim.Replace("=", "|||")

                If tempANGF.getFromExeRadio.Checked Then ' From EXE
                    If tempANGF.normalGameRadio.Checked Then ' From EXE and normal game
                        Dim fileName As String = tempANGF.gamePathTextBox.Text
                        Dim extension As String = Path.GetExtension(fileName).ToLower
                        img = New Bitmap(GetSmallIcon(fileName).ToBitmap)
                    Else ' From EXE and Steam game
                        Dim fileName As String = tempANGF.steamExePathTextBox.Text
                        Dim extension As String = Path.GetExtension(fileName).ToLower
                        img = New Bitmap(GetSmallIcon(fileName).ToBitmap)
                    End If
                Else ' From other file
                    Select Case Path.GetExtension(tempANGF.customIconPathTextBox.Text)
                        Case ".exe" ' The other file is an application
                            Dim fileName As String = tempANGF.customIconPathTextBox.Text
                            Dim extension As String = Path.GetExtension(fileName).ToLower
                            img = New Bitmap(GetSmallIcon(fileName).ToBitmap)

                            If img.Width > 16 Or img.Height > 16 Then 'If the image isn't 16x16, resize it
                                img = ResizeImage(img, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBicubic, True)
                            End If
                        Case Else REM The other file is an image
                            img = New Bitmap(tempANGF.customIconPathTextBox.Text)
                            img = ResizeImage(img, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBicubic, True)
                    End Select
                End If

                Dim errorMsg As String = Nothing
                Select Case gameType
                    Case gameTypes.normal
                        errorMsg = newAddGame(gameTypes.normal, gameName, gamePath, img, Nothing, cmdArgs)
                    Case gameTypes.normalWithLauncher
                        errorMsg = newAddGame(gameTypes.normal, gameName, gamePath, img, launcherPath, cmdArgs)
                    Case gameTypes.steam
                        errorMsg = newAddGame(gameTypes.steam, gameName, gamePath, img, Nothing, cmdArgs)
                    Case gameTypes.steamWithExe
                        errorMsg = newAddGame(gameTypes.steam, gameName, gamePath, img, launcherPath, cmdArgs)
                End Select

                If errorMsg <> "Success" Then
                    MessageBox.Show(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormAddGameFailed1") & vbNewLine & errorMsg & vbNewLine & vbNewLine & _
                                    CURRENT_LANGUAGE_RESOURCE.GetString("MainFormAddGameFailed2"), _
                                    My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    populateDock()
                    clearMenu()
                    rebuildMenu()
                    commitChanges()
                End If
            End If

            tempANGF.resetForm()
            tempANGF.Dispose()
        End If
    End Sub

    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddHandler My.Application.StartupNextInstance, AddressOf CallingNewInstance

        setLanguage()
        setMenuLanguageStrings()
        addHotKey()
        loadINIs()
        commitChanges()
        clearMenu()
        rebuildMenu()
        togglePlayTimeInSkypeNotifications(playTimeToggleType.check)
        skypeNotificationRegistryValueCheck()
        skypeWorker.RunWorkerAsync()
        restoreDock()
        checkGameLauncherCmdArgs()
        autoUpdater()
        enableTheme()
        checkForDeadLinks()

        Me.Visible = False
        Me.Hide()
        My.Computer.FileSystem.CurrentDirectory = My.Application.Info.DirectoryPath
        TrayIcon.Text = "Game Launcher"
    End Sub

    Private Sub CallingNewInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs)
        If e.CommandLine.Count > 0 Then
            For Each cmdLineArg As String In e.CommandLine
                takeGameViaCommandLine(cmdLineArg)
            Next
        End If
    End Sub

    Private Sub setLanguage()
        'Get or set language
        Dim languageKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim currentLanguage As String = languageKey.GetValue("currentLanguage", Nothing)

        If currentLanguage Is Nothing Then
            ' Language not set, default to English
            languageKey.SetValue("currentLanguage", "English")
            CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsEnglish.ResourceManager
        Else
            Select Case currentLanguage
                Case "English"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsEnglish.ResourceManager
                Case "Norwegian"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsNorwegian.ResourceManager
                Case "German"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsGerman.ResourceManager
                Case "Serbian (Cyrillic)"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsSerbianCyrillic.ResourceManager
                Case "Serbian (Latin)"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsSerbianLatin.ResourceManager
                Case "Spanish"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsSpanish.ResourceManager
                Case "Catalan"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsCatalan.ResourceManager
                Case "Portuguese"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsPortuguese.ResourceManager
                Case "Swedish"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsSwedish.ResourceManager
                Case "French"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsFrench.ResourceManager
                Case "Vietnamese"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsVietnamese.ResourceManager
                Case "Finnish"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsFinnish.ResourceManager
                Case "Pirate"
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsPirate.ResourceManager
                Case Else
                    ' Language set not valid, default to English
                    languageKey.SetValue("currentLanguage", "English")
                    CURRENT_LANGUAGE_RESOURCE = My.Resources.mlsEnglish.ResourceManager
            End Select
        End If
    End Sub

    Private Sub setMenuLanguageStrings()
        ' Multi-language stuff
        QuitToolStripMenuItem.Text = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuQuit")
        OptionsMenuItem.Text = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuOptions")
        AddGameMenuItem.Text = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuOptionsAddGame")
        RemoveGameMenuItem.Text = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuOptionsRemoveGames")
        ClearGameListMenuItem.Text = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuOptionsClearGameList")
        PreferencesToolStripMenuItem.Text = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuOptionsPreferences")
        StatisticsToolStripMenuItem.Text = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuOptionsStatistics")
        AboutGameLauncherToolStripMenuItem.Text = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuOptionsAbout")

        AddGameMenuItem.ToolTipText = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuAddGameTooltip")
        RemoveGameMenuItem.ToolTipText = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuRemoveGamesTooltip")
        ClearGameListMenuItem.ToolTipText = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuClearGameListTooltip")
        AboutGameLauncherToolStripMenuItem.ToolTipText = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuAboutTooltip")

        TrayIcon.Text = CURRENT_LANGUAGE_RESOURCE.GetString("MainFormLoadingMessage")
    End Sub

    Private Sub addHotKey()
        With hotKeyComp
            .WinKey = True
            .HotKey = Keys.G
        End With
        AddHandler hotKeyComp.HotkeyPressed, AddressOf HotKey
    End Sub

    Private Sub loadINIs()
        Dim settingsINIPath As String = Path.Combine(My.Application.Info.DirectoryPath, "settings.ini")
        Dim argsINIPath As String = Path.Combine(My.Application.Info.DirectoryPath, "args.ini")
        Dim iconsINIPath As String = Path.Combine(My.Application.Info.DirectoryPath, "icons.ini")
        Dim launchersINIPath As String = Path.Combine(My.Application.Info.DirectoryPath, "launchers.ini")

        createOrLoadINI(iconsINIPath, iniTypes.icons)
        createOrLoadINI(launchersINIPath, iniTypes.launchers)
        createOrLoadINI(settingsINIPath, iniTypes.settings)
        createOrLoadINI(argsINIPath, iniTypes.arguments)
    End Sub

    Private Sub restoreDock()
        Dim dockShown As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim dockShownVar As Integer = dockShown.GetValue("dockShown", Nothing)
        If dockShownVar = 0 Then
            'Value doesn't exist, create it
            dockShown.SetValue("dockShown", 0, RegistryValueKind.DWord)
        Else
            'Value exists, use it
            If dockShownVar = 1 Then
                dockToggle()
            End If
        End If
    End Sub

    Private Sub checkGameLauncherCmdArgs()
        Dim showTip As Boolean = True
        If My.Application.CommandLineArgs.Count > 0 Then
            For Each cmdLineArg As String In My.Application.CommandLineArgs
                If cmdLineArg = "/q" Then
                    showTip = False
                Else
                    takeGameViaCommandLine(cmdLineArg)
                End If
            Next
        Else
            showTip = True
        End If

        If showTip Then
            showBalloonTip()
        End If
    End Sub

    Private Sub enableTheme()
        Dim regKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim isThemed As Integer = CInt(regKey.GetValue("isThemed", Nothing))
        If isThemed = 1 Then
            MainContextMenu.Renderer = New CustomToolStripRenderer()
        ElseIf isThemed = Nothing Then
            'Set the key
            regKey.SetValue("isThemed", 0, RegistryValueKind.DWord)
        End If
    End Sub

    Private Sub autoUpdater()
        Dim regKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim value As Integer = CInt(regKey.GetValue("autoUpdate", 9001))

        If value = 9001 Then
            'Doesn't exist, create it and set it to be enabled
            regKey.SetValue("autoUpdate", 1, RegistryValueKind.DWord)
        ElseIf value = 1 Then
            'AutoUpdate is enabled, do nothing
        ElseIf value = 0 Then
            'AutoUpdate is disabled, disable checking for updates
            skipUpdateThisSession = True
            UpdateChecker.Enabled = False
        End If
    End Sub

    Private Sub checkForDeadLinks()
        'Check for dead links (i.e. when a game has been uninstalled)
        Dim deadGames As New Dictionary(Of String, String)
        For Each kvp As KeyValuePair(Of String, String) In PathContainer
            If Not kvp.Value.StartsWith("steam://") Then
                If Not My.Computer.FileSystem.FileExists(kvp.Value) Then
                    deadGames.Add(kvp.Key, kvp.Value)
                End If
            Else
                Try
                    If Not My.Computer.FileSystem.FileExists(LaunchersContainer(kvp.Key)) Then
                        deadGames.Add(kvp.Key, LaunchersContainer(kvp.Key))
                    End If
                Catch ex As KeyNotFoundException
                    ' Do nothing
                End Try
            End If
        Next

        If deadGames.Count > 0 Then
            Dim deadGameString As String = Nothing
            For Each game As String In deadGames.Keys
                deadGameString &= game.Replace("&&", "&") & vbNewLine
            Next

            Dim response As DialogResult = MessageBox.Show("Game Launcher has detected that the following games no longer exist on your computer: " & _
                                                        vbNewLine & vbNewLine & deadGameString & vbNewLine & _
                                                        "Do you want to remove them from your game list?", Application.ProductName, MessageBoxButtons.YesNo, _
                                                        MessageBoxIcon.Question)

            If response = Windows.Forms.DialogResult.Yes Then
                For Each item As String In deadGames.Keys
                    Dim success As Boolean
                    Dim elementToRemove As Object = Nothing
                    For Each element As Object In MainContextMenu.Items
                        If element.Text = item Then
                            success = True
                            elementToRemove = element
                            Exit For
                        End If
                    Next
                    If success Then
                        MainContextMenu.Items.Remove(elementToRemove)

                        If PathContainer(item).StartsWith("steam://") Then
                            Dim bmpName As String = Path.Combine(steamIconPath, PathContainer(item).Remove(0, 18) & ".bmp")
                            If File.Exists(bmpName) Then
                                My.Computer.FileSystem.DeleteFile(bmpName)
                            End If
                        End If

                        If ArgsContainer.ContainsKey(item) Then
                            ArgsContainer.Remove(item)
                        End If

                        If IconsContainer.ContainsKey(item) Then
                            Dim imageName As String = Path.Combine(iconPath, IconsContainer(item) & ".png")
                            If File.Exists(imageName) Then
                                My.Computer.FileSystem.DeleteFile(imageName)
                            End If
                            IconsContainer.Remove(item)
                        End If

                        If LaunchersContainer.ContainsKey(item) Then
                            LaunchersContainer.Remove(item)
                        End If

                        PathContainer.Remove(item)
                    End If
                Next
                populateDock()
                commitChanges()
            End If
        End If
    End Sub

    Public Function calculateTime() As String
        Dim timeThen As Date = currentRunningGameTimeStamp
        Dim timeNow As Date = Date.Now
        Dim difference As TimeSpan = timeNow - timeThen
        Dim returnValue As String = Nothing
        Dim hourString, minuteString, secondString As String
        Dim hourPluralString, minutePluralString, secondPluralString As String

        hourString = CURRENT_LANGUAGE_RESOURCE.GetString("MainFormTimeHourSingular")
        minuteString = CURRENT_LANGUAGE_RESOURCE.GetString("MainFormTimeMinuteSingular")
        secondString = CURRENT_LANGUAGE_RESOURCE.GetString("MainFormTimeSecondSingular")
        hourPluralString = CURRENT_LANGUAGE_RESOURCE.GetString("MainFormTimeHourPlural")
        minutePluralString = CURRENT_LANGUAGE_RESOURCE.GetString("MainFormTimeMinutePlural")
        secondPluralString = CURRENT_LANGUAGE_RESOURCE.GetString("MainFormTimeSecondPlural")

        Dim h, m, s As Integer
        h = difference.Hours
        m = difference.Minutes
        s = difference.Seconds

        If h > 1 Then hourString = hourPluralString
        If m > 1 Then minuteString = minutePluralString
        If s > 1 Then secondString = secondPluralString

        If h < 1 And m < 1 Then returnValue = s & " " & secondString 'If under an hour and under a minute, return seconds only
        If h < 1 And m > 0 Then returnValue = m & " " & minuteString & ", " & s & " " & secondString 'If under an hour but over a minute, return minutes and seconds
        If h > 0 Then returnValue = h & " " & hourString & ", " & m & " " & minuteString & ", " & s & " " & secondString 'If over an hour, return everything

        Return returnValue
    End Function

    Public Sub HotKey()
        Dim loc As New System.Drawing.Point
        loc.X = Cursor.Position.X
        loc.Y = Cursor.Position.Y

        If MainContextMenu.Visible = True Then
            MainContextMenu.Close()
        Else
            MainContextMenu.Show(loc)
        End If
    End Sub

    Public Function getNumericVersion() As Integer
        Dim version As String = Nothing
        version &= My.Application.Info.Version.Major
        version &= My.Application.Info.Version.Minor
        version &= My.Application.Info.Version.Build
        version &= My.Application.Info.Version.Revision
        Return CInt(version)
    End Function

    Public Function isProcessRunning(name As String) As Boolean
        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName.StartsWith(name, StringComparison.CurrentCultureIgnoreCase) Then
                Return True
            End If
        Next
        Return False
    End Function

#Region "Skype Functions"
    Sub skypeConnect()
        Try
            If sendSkypeNotification Then
                If isProcessRunning("skype") Then
                    oSkype.Attach(8, False)
                End If
            End If
        Catch ex As Exception
            'User didn't respond to access request or isn't logged in to Skype, don't notify the user
        End Try
    End Sub

    Public Function toggleSkypeNotifications(ByVal check As Boolean) As Boolean
        Dim skypeNotificationKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)

        Dim val As Integer = skypeNotificationKey.GetValue("sendSkypeNotifications", 1337)
        If val = 0 Then
            'Notifications are turned off
            If check Then
                Return False
            Else
                skypeNotificationKey.SetValue("sendSkypeNotifications", 1, RegistryValueKind.DWord)
                sendSkypeNotification = True
                skypeWorker.RunWorkerAsync()
                Return True
            End If
        ElseIf val = 1 Then
            'Notifications are turned on
            If check Then
                Return True
            Else
                skypeNotificationKey.SetValue("sendSkypeNotifications", 0, RegistryValueKind.DWord)
                sendSkypeNotification = False
                Return False
            End If
        Else
            'Contains some other value, what the fuck man, turn that shit off
            If check = False Then
                skypeNotificationKey.SetValue("sendSkypeNotifications", 0, RegistryValueKind.DWord)
                sendSkypeNotification = False
            End If

            Return False
        End If
    End Function

    Public Function skypeNotificationRegistryValueCheck() As Boolean
        Dim skypeNotificationKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)

        If IsNothing(skypeNotificationKey.GetValue("sendSkypeNotifications", Nothing)) Then
            'Value doesn't exist, create it
            skypeNotificationKey.SetValue("sendSkypeNotifications", 0, RegistryValueKind.DWord) 'Default to disabled
            sendSkypeNotification = False
            Return False
        Else
            'Value already exists, check its value
            Dim val As Integer = skypeNotificationKey.GetValue("sendSkypeNotifications", 1337)
            If CInt(val) = 0 Then
                'Notifications are turned off
                sendSkypeNotification = False
                Return False
            ElseIf CInt(val) = 1 Then
                'Notifications are turned on
                sendSkypeNotification = True
                Return True
            Else
                'Contains some other value, what the fuck man
                sendSkypeNotification = False
                Return False
            End If
        End If
    End Function
#End Region

    Public Sub showBalloonTip()
        With TrayIcon
            .BalloonTipIcon = ToolTipIcon.Info
            .BalloonTipTitle = String.Format(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormBalloonTipLoadedMessageTitle"), My.Application.Info.Version.ToString)
            .BalloonTipText = CURRENT_LANGUAGE_RESOURCE.GetString("MainFormBalloonTipLoadedMessageText")
            .ShowBalloonTip(10000)
        End With
    End Sub

    Public Function checkForUpdates() As String
        If skipUpdateThisSession = False Then
            Try
                Dim webVersion As String = phoneHome()
                Dim newVersion As New Version(Val(webVersion(0)), Val(webVersion(1)), Val(webVersion(2)), Val(webVersion(3)))
                If CInt(webVersion) > GL_VERSION Then
                    skipUpdateThisSession = True
                    UpdateChecker.Enabled = False
                    Return newVersion.ToString
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                'An error occured while checking for updates. Ignore it and continue checking for updates.
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
    End Function

    Public Function phoneHome() As String
        Dim fileReader As New WebClient()
        Dim data As Stream
        Dim sr As StreamReader
        Dim currentLine As String
        Try
            data = fileReader.OpenRead("http://gamelauncher.pvpsucks.com/version")
            sr = New StreamReader(data)
            currentLine = sr.ReadLine()
            data.Close()
        Catch ex As Exception
            currentLine = "0"
        End Try

        Return currentLine
    End Function

    Private Sub AddGameMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddGameMenuItem.Click
        If AddNewGameForm.Visible Then
            AppActivate(AddNewGameForm.Text)
            AddNewGameForm.WindowState = FormWindowState.Normal
            AddNewGameForm.Focus()
        Else
            If AddNewGameForm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim gameName, cmdArgs, gamePath, launcherPath As String
                Dim gameType As gameTypes
                Dim img As Bitmap
                gamePath = Nothing
                launcherPath = Nothing

                'Determine type of game to be added
                If AddNewGameForm.normalGameRadio.Checked Then
                    gamePath = AddNewGameForm.gamePathTextBox.Text.Trim
                    If AddNewGameForm.usesLauncherCheckBox.Checked Then
                        launcherPath = AddNewGameForm.launcherPathTextBox.Text.Trim
                        gameType = gameTypes.normalWithLauncher
                    Else
                        gameType = gameTypes.normal
                    End If
                Else
                    gamePath = AddNewGameForm.steamAppIDTextBox.Text.Trim
                    If AddNewGameForm.specifySteamExeCheckBox.Checked Then
                        launcherPath = AddNewGameForm.steamExePathTextBox.Text.Trim
                        gameType = gameTypes.steamWithExe
                    Else
                        gameType = gameTypes.steam
                    End If
                End If

                gameName = AddNewGameForm.gameNameTextBox.Text.Trim.Replace("="c, "-"c).Replace("&", "&&")
                cmdArgs = AddNewGameForm.commandLineTextBox.Text.Trim.Replace("=", "|||")

                If AddNewGameForm.getFromExeRadio.Checked Then ' From EXE
                    If AddNewGameForm.normalGameRadio.Checked Then ' From EXE and normal game
                        Dim fileName As String = AddNewGameForm.gamePathTextBox.Text
                        Dim extension As String = Path.GetExtension(fileName).ToLower
                        img = New Bitmap(GetSmallIcon(fileName).ToBitmap)
                    Else ' From EXE and Steam game
                        Dim fileName As String = AddNewGameForm.steamExePathTextBox.Text
                        Dim extension As String = Path.GetExtension(fileName).ToLower
                        img = New Bitmap(GetSmallIcon(fileName).ToBitmap)
                    End If
                Else ' From other file
                    Select Case Path.GetExtension(AddNewGameForm.customIconPathTextBox.Text)
                        Case ".exe" ' The other file is an application
                            Dim fileName As String = AddNewGameForm.customIconPathTextBox.Text
                            Dim extension As String = Path.GetExtension(fileName).ToLower
                            img = New Bitmap(GetSmallIcon(fileName).ToBitmap)

                            If img.Width > 16 Or img.Height > 16 Then 'If the image isn't 16x16, resize it
                                img = ResizeImage(img, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBicubic, True)
                            End If
                        Case Else REM The other file is an image
                            img = New Bitmap(AddNewGameForm.customIconPathTextBox.Text)
                            img = ResizeImage(img, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBicubic, True)
                    End Select
                End If

                Dim errorMsg As String = Nothing
                Select Case gameType
                    Case gameTypes.normal
                        errorMsg = newAddGame(gameTypes.normal, gameName, gamePath, img, Nothing, cmdArgs)
                    Case gameTypes.normalWithLauncher
                        errorMsg = newAddGame(gameTypes.normal, gameName, gamePath, img, launcherPath, cmdArgs)
                    Case gameTypes.steam
                        errorMsg = newAddGame(gameTypes.steam, gameName, gamePath, img, Nothing, cmdArgs)
                    Case gameTypes.steamWithExe
                        errorMsg = newAddGame(gameTypes.steam, gameName, gamePath, img, launcherPath, cmdArgs)
                End Select

                If errorMsg <> "Success" Then
                    MessageBox.Show(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormAddGameFailed1") & vbNewLine & errorMsg & vbNewLine & vbNewLine & _
                                    CURRENT_LANGUAGE_RESOURCE.GetString("MainFormAddGameFailed2"), _
                                    My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    populateDock()
                    clearMenu()
                    rebuildMenu()
                    commitChanges()
                End If
            End If

            AddNewGameForm.resetForm()
        End If
    End Sub

    Sub commitChanges()
        Dim inifile As New IniFile.IniFile(Path.Combine(My.Application.Info.DirectoryPath, "settings.ini"), True)
        inifile.DeleteSection("entries") 'Flush it
        inifile.AddSection("entries")

        For Each item As KeyValuePair(Of String, String) In PathContainer
            inifile.AddKey(item.Key, item.Value, "entries")
        Next

        inifile.Save("settings.ini")


        Dim argsINI As New IniFile.IniFile(Path.Combine(My.Application.Info.DirectoryPath, "args.ini"))
        argsINI.DeleteSection("entries") 'Flush it
        argsINI.AddSection("entries")

        For Each item As KeyValuePair(Of String, String) In ArgsContainer
            argsINI.AddKey(item.Key, item.Value, "entries")
        Next

        argsINI.Save("args.ini")


        Dim iconsINI As New IniFile.IniFile(Path.Combine(My.Application.Info.DirectoryPath, "icons.ini"))
        iconsINI.DeleteSection("entries") 'Flush it
        iconsINI.AddSection("entries")

        For Each item As KeyValuePair(Of String, String) In IconsContainer
            iconsINI.AddKey(item.Key, item.Value, "entries")
        Next

        iconsINI.Save("icons.ini")


        Dim launchersINI As New IniFile.IniFile(Path.Combine(My.Application.Info.DirectoryPath, "launchers.ini"))
        launchersINI.DeleteSection("entries") 'Flush it
        launchersINI.AddSection("entries")

        For Each item As KeyValuePair(Of String, String) In LaunchersContainer
            launchersINI.AddKey(item.Key, item.Value, "entries")
        Next

        launchersINI.Save("launchers.ini")
    End Sub

    Sub quit()
        If MessageBox.Show(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormQuitApplication"), My.Application.Info.AssemblyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Dim dockShown As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)

            If DockForm.Visible Then
                dockShown.SetValue("dockShown", 1, RegistryValueKind.DWord)
            Else
                dockShown.SetValue("dockShown", 0, RegistryValueKind.DWord)
            End If

            commitChanges()
            TrayIcon.Dispose()
            End
        End If
    End Sub

    Public Function newAddGame(ByVal gameType As gameTypes, ByVal gameName As String, ByVal gamePath As String, ByVal tsmiIcon As Bitmap, Optional ByVal launcherPath As String = Nothing, Optional ByVal cmdArgs As String = Nothing) As String
        Dim tsi As New ToolStripMenuItem()
        Select Case gameType
            Case gameTypes.normal
                If launcherPath = Nothing Then
                    'Normal game without launcher
                    Try
                        PathContainer.Add(gameName, gamePath)
                        tsi.Text = gameName
                        tsi.Image = tsmiIcon

                        'Save the icon
                        Dim newGuid As String = Guid.NewGuid.ToString
                        Dim newIconPath As String = Path.Combine(iconPath, newGuid & ".png")
                        tsmiIcon.Save(newIconPath)
                        IconsContainer.Add(gameName, newGuid)

                        'Command line arguments
                        If cmdArgs <> "" Then
                            ArgsContainer.Add(gameName, cmdArgs)
                        End If

                        MainContextMenu.Items.Add(tsi)
                        Return "Success"
                    Catch ex As Exception
                        Return ex.Message
                    End Try
                Else
                    'Normal game with launcher
                    Try
                        PathContainer.Add(gameName, gamePath)
                        LaunchersContainer.Add(gameName, launcherPath)
                        tsi.Text = gameName
                        tsi.Image = tsmiIcon

                        'Save the icon
                        Dim newGuid As String = Guid.NewGuid.ToString
                        Dim newIconPath As String = Path.Combine(iconPath, newGuid & ".png")
                        tsmiIcon.Save(newIconPath)
                        IconsContainer.Add(gameName, newGuid)

                        'Command line arguments
                        If cmdArgs <> "" Then
                            ArgsContainer.Add(gameName, cmdArgs)
                        End If

                        MainContextMenu.Items.Add(tsi)
                        Return "Success"
                    Catch ex As Exception
                        Return ex.Message
                    End Try
                End If
            Case gameTypes.steam
                If launcherPath = Nothing Then
                    'Steam game without specified exe
                    Try
                        PathContainer.Add(gameName, "steam://rungameid/" & gamePath)
                        tsi.Text = gameName
                        tsi.Image = tsmiIcon

                        'Save the icon
                        Dim newIconPath As String = Path.Combine(steamIconPath, gamePath & ".bmp")
                        tsmiIcon.Save(newIconPath, Imaging.ImageFormat.Bmp)

                        'Command line arguments
                        If cmdArgs <> "" Then
                            ArgsContainer.Add(gameName, cmdArgs)
                        End If

                        MainContextMenu.Items.Add(tsi)
                        Return "Success"
                    Catch ex As Exception
                        Return ex.Message
                    End Try
                Else
                    'Steam game with specified exe
                    Try
                        PathContainer.Add(gameName, "steam://rungameid/" & gamePath)
                        LaunchersContainer.Add(gameName, launcherPath)
                        tsi.Text = gameName
                        tsi.Image = tsmiIcon

                        'Save the icon
                        Dim newIconPath As String = Path.Combine(steamIconPath, gamePath & ".bmp")
                        tsmiIcon.Save(newIconPath, Imaging.ImageFormat.Bmp)

                        'Command line arguments
                        If cmdArgs <> "" Then
                            ArgsContainer.Add(gameName, cmdArgs)
                        End If

                        MainContextMenu.Items.Add(tsi)
                        Return "Success"
                    Catch ex As Exception
                        Return ex.Message
                    End Try
                End If
            Case Else
                Return "Unspecified error occurred."
        End Select
    End Function

    Public Function addGame(ByVal path As String, ByVal caption As String, ByVal skipGetSteamIcon As Boolean) As String
        Try
            Dim tsi As New ToolStripMenuItem()
            PathContainer.Add(caption, path)

            With tsi
                .Text = caption
                .Image = getIcon(path, skipGetSteamIcon, caption)
            End With

            MainContextMenu.Items.Add(tsi)
            Return " "
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function getIcon(ByVal path As String, ByVal skipSteam As Boolean, ByVal gameName As String) As Bitmap
        Dim sourceBitmap As Bitmap
        Dim saveNewSteamIcon As Boolean = False
        Dim saveNewIcon As Boolean = False

        If path.StartsWith("steam") Then
            Dim result As Bitmap = getSteamIcon(path.Remove(0, 18))

            If IsNothing(result) Then
                If skipSteam Then
                    sourceBitmap = Icon.ExtractAssociatedIcon(getSteamExe()).ToBitmap
                Else
                    Dim ofd As New OpenFileDialog
                    With ofd
                        .Filter = "Icons (*.ico, *.exe)|*.ico;*.exe"
                        .InitialDirectory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(getSteamExe()), "steam\games\")
                        .Title = String.Format(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormSelectIconText"), gameName)
                    End With

                    If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                        sourceBitmap = New Bitmap(Icon.ExtractAssociatedIcon(ofd.FileName).ToBitmap)
                        saveNewSteamIcon = True
                    Else
                        sourceBitmap = New Bitmap(Icon.ExtractAssociatedIcon(getSteamExe()).ToBitmap)
                    End If
                End If
            Else
                sourceBitmap = result
            End If
        Else
            If IconsContainer.ContainsKey(gameName) Then
                'The icons file has an entry on this game
                Dim iconName As String = IO.Path.Combine(iconPath, IconsContainer(gameName) & ".png")
                Dim img As Image
                Using bmpTemp = New Bitmap(iconName)
                    img = New Bitmap(bmpTemp)
                End Using

                Return img
            Else
                'The icons file doesn't have an entry, save it
                sourceBitmap = New Bitmap(Icon.ExtractAssociatedIcon(path).ToBitmap)
                saveNewIcon = True
            End If
        End If

        Dim returnBitmap As New Bitmap(16, 16)
        Dim graphix As Graphics = Graphics.FromImage(returnBitmap)
        graphix.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        graphix.DrawImage(sourceBitmap, 0, 0, returnBitmap.Width, returnBitmap.Height)
        sourceBitmap.Dispose()

        If saveNewSteamIcon Then
            Dim newIconLocation As String = IO.Path.Combine(steamIconPath & path.Remove(0, 18) & ".bmp")
            Dim fs As FileStream = File.Create(newIconLocation)

            returnBitmap.Save(fs, Imaging.ImageFormat.Bmp)
            fs.Close()
            fs.Dispose()
        End If

        If saveNewIcon Then
            Dim newGuid As String = Guid.NewGuid.ToString
            Dim newIconLocation As String = IO.Path.Combine(iconPath, newGuid & ".png")
            Dim fs As FileStream = File.Create(newIconLocation)

            returnBitmap.Save(fs, Imaging.ImageFormat.Png)
            fs.Close()
            fs.Dispose()
            IconsContainer.Add(gameName, newGuid)
        End If

        Return returnBitmap
    End Function

    Public Sub runGame(ByVal sender As System.Object, ByVal e As System.EventArgs)
        runGameWorker.RunWorkerAsync(sender)
        MainContextMenu.Close()
    End Sub

    Sub stoppedPlaying()
        If sendSkypeNotification Then
            If isProcessRunning("skype") Then
                Dim moodText As String = String.Format(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormSkypePlayStopped"), currentRunningGame)
                If playTimeInSkypeNotifications Then
                    moodText &= String.Format(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormSkypePlayTimeStopped"), calculateTime() & ")")
                End If
                oSkype.Profile("Mood_Text") = moodText
            End If
        End If

        saveStats()
        currentRunningGame = Nothing
        currentRunningGameTimeStamp = Nothing
    End Sub

    Sub saveStats()
        Dim statsKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher\stats", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim secondsPlayed As Int64
        Dim timeThen As Date = currentRunningGameTimeStamp
        Dim timeNow As Date = Date.Now
        Dim difference As TimeSpan = timeNow - timeThen

        secondsPlayed = ((difference.Hours * 60) * 60) + (difference.Minutes * 60) + difference.Seconds

        statsKey.SetValue(currentRunningGame, (statsKey.GetValue(currentRunningGame, Nothing) + secondsPlayed), RegistryValueKind.QWord)
    End Sub

    Private Sub ClearGameListMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearGameListMenuItem.Click
        If MessageBox.Show(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormClearGameList"), My.Application.Info.AssemblyName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            My.Computer.FileSystem.DeleteDirectory(steamIconPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.CreateDirectory(Path.Combine(My.Application.Info.DirectoryPath, "steamicons"))

            My.Computer.FileSystem.DeleteDirectory(iconPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.CreateDirectory(Path.Combine(My.Application.Info.DirectoryPath, "icons"))

            clearMenu()
            PathContainer.Clear()
            ArgsContainer.Clear()
            IconsContainer.Clear()
            populateDock()
            commitChanges()
        End If
    End Sub

    Public Sub clearMenu()
        Dim buffer As New Collection

        For Each element As Object In MainContextMenu.Items
            If element.Text = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuQuit") Or element.Text = CURRENT_LANGUAGE_RESOURCE.GetString("MainMenuOptions") Then
            Else
                buffer.Add(element.Text)
            End If
        Next

        For Each item As String In buffer
            Dim success As Boolean
            Dim elementToRemove As Object = Nothing
            For Each element As Object In MainContextMenu.Items
                If element.Text = item Then
                    success = True
                    elementToRemove = element
                    Exit For
                End If
            Next
            If success Then
                If item <> "" Then MainContextMenu.Items.Remove(elementToRemove)
            End If
        Next
    End Sub

    Public Sub rebuildMenu()
        For Each element As String In PathContainer.Keys
            Dim tsi As New ToolStripMenuItem
            Dim removeItem As ToolStripMenuItem
            Dim editGameItem As ToolStripMenuItem
            Dim browseGameFolderItem As ToolStripMenuItem

            tsi.Text = element
            tsi.Image = getIcon(PathContainer(element), True, element)
            editGameItem = tsi.DropDownItems.Add(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormEditGameItem"))
            editGameItem.ToolTipText = CURRENT_LANGUAGE_RESOURCE.GetString("MainFormEditGameItemTooltip")
            removeItem = tsi.DropDownItems.Add(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormRemoveGameItem"))
            removeItem.ToolTipText = CURRENT_LANGUAGE_RESOURCE.GetString("MainFormRemoveGameItemTooltip")
            browseGameFolderItem = tsi.DropDownItems.Add(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormBrowseItemFolder"))
            browseGameFolderItem.ToolTipText = CURRENT_LANGUAGE_RESOURCE.GetString("MainFormBrowseItemFolderTooltip")

            MainContextMenu.Items.Add(tsi)

            AddHandler tsi.Click, AddressOf runGame
            AddHandler removeItem.Click, AddressOf removeGame
            AddHandler editGameItem.Click, AddressOf editGame
            AddHandler browseGameFolderItem.Click, AddressOf browseGameFolder
        Next
    End Sub

    Public Sub browseGameFolder(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim daddy As ToolStripMenuItem = sender.OwnerItem
        Dim gameName As String = daddy.Text
        Dim gamePath As String

        Try
            gamePath = PathContainer(gameName)

            If PathContainer(gameName).StartsWith("steam://rungameid/") Then
                gamePath = LaunchersContainer(gameName)
            End If

            Process.Start(Path.GetDirectoryName(gamePath))
        Catch ex As Exception
            MessageBox.Show(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormBrowseItemFolderNoPath") & vbNewLine & vbNewLine & ex.Message, _
                            "Game Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub editGame(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim daddy As ToolStripMenuItem = sender.OwnerItem

        Dim gameName As String = daddy.Text
        Dim gamePath As String = PathContainer(gameName)
        Dim launcherPath As String = Nothing
        Dim arguments As String = Nothing
        Dim gameIsSteam As Boolean = False

        AddNewGameForm.gameNameTextBox.Text = gameName

        If ArgsContainer.ContainsKey(gameName) Then
            arguments = ArgsContainer(gameName).Replace("|||", "=")
            AddNewGameForm.commandLineTextBox.Text = arguments
        End If

        If PathContainer(gameName).StartsWith("steam://rungameid/") Then
            gameIsSteam = True
            AddNewGameForm.steamGameRadio.Checked = True
            AddNewGameForm.steamAppIDTextBox.Text = gamePath.Remove(0, 18)
        Else
            AddNewGameForm.normalGameRadio.Checked = True
            AddNewGameForm.gamePathTextBox.Text = gamePath
        End If

        If LaunchersContainer.ContainsKey(gameName) Then
            launcherPath = LaunchersContainer(gameName)
            If gameIsSteam Then
                AddNewGameForm.specifySteamExeCheckBox.Checked = True
                AddNewGameForm.steamExePathTextBox.Text = launcherPath
            Else
                AddNewGameForm.usesLauncherCheckBox.Checked = True
                AddNewGameForm.launcherPathTextBox.Text = launcherPath
            End If
        End If

        With AddNewGameForm.keepCurrentIconRadio
            .Enabled = True
            .Checked = True
        End With

        AddNewGameForm.currentIcon = daddy.Image
        AddNewGameForm.gameIconPreviewBox.BackgroundImage = AddNewGameForm.currentIcon

        If AddNewGameForm.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Remove the old one first
            Dim icon As Image = daddy.Image
            MainContextMenu.Items.Remove(daddy)
            daddy.Dispose()

            If PathContainer(gameName).StartsWith("steam://") Then
                Dim steamID As String = PathContainer(gameName).Remove(0, 18)
                Dim imageName As String = Path.Combine(steamIconPath, steamID & ".bmp")
                If File.Exists(imageName) Then
                    My.Computer.FileSystem.DeleteFile(imageName)
                End If
            End If

            PathContainer.Remove(gameName)
            ArgsContainer.Remove(gameName)

            If IconsContainer.ContainsKey(gameName) Then
                Dim imageName As String = Path.Combine(iconPath, IconsContainer(gameName) & ".png")
                If File.Exists(imageName) Then
                    My.Computer.FileSystem.DeleteFile(imageName)
                End If
                IconsContainer.Remove(gameName)
            End If

            LaunchersContainer.Remove(gameName)

            'Now add the new one
            Dim cmdArgs As String
            Dim gameType As gameTypes
            Dim img As Bitmap

            gamePath = Nothing
            launcherPath = Nothing

            'Determine type of game to be added
            If AddNewGameForm.normalGameRadio.Checked Then
                gamePath = AddNewGameForm.gamePathTextBox.Text.Trim
                If AddNewGameForm.usesLauncherCheckBox.Checked Then
                    launcherPath = AddNewGameForm.launcherPathTextBox.Text.Trim
                    gameType = gameTypes.normalWithLauncher
                Else
                    gameType = gameTypes.normal
                End If
            Else
                gamePath = AddNewGameForm.steamAppIDTextBox.Text.Trim
                If AddNewGameForm.specifySteamExeCheckBox.Checked Then
                    launcherPath = AddNewGameForm.steamExePathTextBox.Text.Trim
                    gameType = gameTypes.steamWithExe
                Else
                    gameType = gameTypes.steam
                End If
            End If

            gameName = AddNewGameForm.gameNameTextBox.Text.Trim.Replace("="c, "-"c).Replace("&", "&&")
            cmdArgs = AddNewGameForm.commandLineTextBox.Text.Trim.Replace("=", "|||")

            If AddNewGameForm.getFromExeRadio.Checked Then
                Dim sourceBitmap As Bitmap
                If AddNewGameForm.normalGameRadio.Checked Then
                    sourceBitmap = New Bitmap(Drawing.Icon.ExtractAssociatedIcon(AddNewGameForm.gamePathTextBox.Text).ToBitmap)
                Else
                    sourceBitmap = New Bitmap(Drawing.Icon.ExtractAssociatedIcon(AddNewGameForm.steamExePathTextBox.Text).ToBitmap)
                End If

                Dim returnBitmap As New Bitmap(16, 16)
                Dim graphix As Graphics = Graphics.FromImage(returnBitmap)
                graphix.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                graphix.DrawImage(sourceBitmap, 0, 0, 16, 16)
                img = returnBitmap
            ElseIf AddNewGameForm.getFromOtherFileRadio.Checked Then
                Select Case Path.GetExtension(AddNewGameForm.customIconPathTextBox.Text)
                    Case ".exe"
                        Dim customIconFromExePath As String = AddNewGameForm.customIconPathTextBox.Text
                        Dim sourceBitmap As New Bitmap(Drawing.Icon.ExtractAssociatedIcon(customIconFromExePath).ToBitmap)
                        Dim returnBitmap As New Bitmap(16, 16)
                        Dim graphix As Graphics = Graphics.FromImage(returnBitmap)
                        graphix.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                        graphix.DrawImage(sourceBitmap, 0, 0, 16, 16)

                        img = returnBitmap
                    Case Else
                        Dim sourceBitmap As New Bitmap(AddNewGameForm.customIconPathTextBox.Text)
                        Dim returnBitmap As New Bitmap(16, 16)
                        Dim graphix As Graphics = Graphics.FromImage(returnBitmap)
                        graphix.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                        graphix.DrawImage(sourceBitmap, 0, 0, 16, 16)

                        img = returnBitmap
                End Select
            Else
                img = icon
            End If

            Dim errorMsg As String = Nothing
            Select Case gameType
                Case gameTypes.normal
                    errorMsg = newAddGame(gameTypes.normal, gameName, gamePath, img, Nothing, cmdArgs)
                Case gameTypes.normalWithLauncher
                    errorMsg = newAddGame(gameTypes.normal, gameName, gamePath, img, launcherPath, cmdArgs)
                Case gameTypes.steam
                    errorMsg = newAddGame(gameTypes.steam, gameName, gamePath, img, Nothing, cmdArgs)
                Case gameTypes.steamWithExe
                    errorMsg = newAddGame(gameTypes.steam, gameName, gamePath, img, launcherPath, cmdArgs)
            End Select

            If errorMsg <> "Success" Then
                MessageBox.Show(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormAddGameFailed1") & vbNewLine & errorMsg & vbNewLine & vbNewLine & _
                                CURRENT_LANGUAGE_RESOURCE.GetString("MainFormAddGameFailed2"), _
                                My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                populateDock()
                clearMenu()
                rebuildMenu()
                commitChanges()
            End If
        End If

        AddNewGameForm.resetForm()
    End Sub

    Public Sub removeGame(ByVal sender As Object, e As System.EventArgs)
        Dim daddy As ToolStripMenuItem = sender.OwnerItem
        If MessageBox.Show(String.Format(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormRemoveGameMsg"), daddy.Text), "Game Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Dim name As String = daddy.Text
            MainContextMenu.Items.Remove(daddy)
            daddy.Dispose()

            If PathContainer(name).StartsWith("steam://") Then
                Dim steamID As String = PathContainer(name).Remove(0, 18)
                Dim imageName As String = Path.Combine(steamIconPath, steamID & ".bmp")
                If File.Exists(imageName) Then
                    My.Computer.FileSystem.DeleteFile(imageName)
                End If
            End If

            PathContainer.Remove(name)
            ArgsContainer.Remove(name)

            If IconsContainer.ContainsKey(name) Then
                Dim imageName As String = Path.Combine(iconPath, IconsContainer(name) & ".png")
                If File.Exists(imageName) Then
                    My.Computer.FileSystem.DeleteFile(imageName)
                End If
                IconsContainer.Remove(name)
            End If

            LaunchersContainer.Remove(name)

            populateDock()
            commitChanges()
        End If
    End Sub

    Private Sub RemoveGameMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoveGameMenuItem.Click
        RemoveForm.ListBox1.ClearSelected()
        RemoveForm.ListBox1.Items.Clear()

        For Each item As String In PathContainer.Keys
            RemoveForm.ListBox1.Items.Add(item)
        Next

        If RemoveForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each item As String In RemoveForm.ListBox1.SelectedItems
                Dim success As Boolean
                Dim elementToRemove As Object = Nothing
                For Each element As Object In MainContextMenu.Items
                    If element.Text = item Then
                        success = True
                        elementToRemove = element
                        Exit For
                    End If
                Next
                If success Then
                    MainContextMenu.Items.Remove(elementToRemove)

                    If PathContainer(item).StartsWith("steam://") Then
                        Dim bmpName As String = Path.Combine(steamIconPath, PathContainer(item).Remove(0, 18) & ".bmp")
                        If File.Exists(bmpName) Then
                            My.Computer.FileSystem.DeleteFile(bmpName)
                        End If
                    End If

                    If ArgsContainer.ContainsKey(item) Then
                        ArgsContainer.Remove(item)
                    End If

                    If IconsContainer.ContainsKey(item) Then
                        Dim imageName As String = Path.Combine(iconPath, IconsContainer(item) & ".png")
                        If File.Exists(imageName) Then
                            My.Computer.FileSystem.DeleteFile(imageName)
                        End If
                        IconsContainer.Remove(item)
                    End If

                    If LaunchersContainer.ContainsKey(item) Then
                        LaunchersContainer.Remove(item)
                    End If

                    PathContainer.Remove(item)
                End If
            Next
            populateDock()
            commitChanges()
        End If
    End Sub

    Public Function getSteamExe() As String
        Dim keyName As String = "HKEY_CURRENT_USER\Software\Valve\Steam"
        Dim valueName As String = "SteamExe"
        Dim steamExePath As String = My.Computer.Registry.GetValue(keyName, valueName, Nothing)
        steamExePath = steamExePath.Replace("/"c, "\"c)
        Return steamExePath
    End Function

    Public Function toggleRunOnStartup(ByVal check As Boolean) As Boolean
        Dim runKey As RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)

        If IsNothing(runKey.GetValue(My.Application.Info.AssemblyName, Nothing)) Then
            If check Then
                Return False
            Else
                runKey.SetValue(My.Application.Info.AssemblyName, """" & Application.ExecutablePath & """ /q")
                Return True
            End If
        Else
            If check Then
                Return True
            Else
                runKey.DeleteValue(My.Application.Info.AssemblyName)
                Return False
            End If
            Return False
        End If
    End Function

    Private Sub QuitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles QuitToolStripMenuItem.Click
        quit()
    End Sub

    Public Function getSteamIcon(ByVal id As String) As Bitmap
        Dim iconPath As String = Path.Combine(steamIconPath, id & ".bmp")

        If File.Exists(iconPath) Then
            Return Icon.ExtractAssociatedIcon(iconPath).ToBitmap
        Else
            Return Nothing
        End If
    End Function

    Private Sub AboutGameLauncherToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutGameLauncherToolStripMenuItem.Click
        AboutForm.ShowDialog()
    End Sub

    Private Sub UpdateChecker_Tick(sender As System.Object, e As System.EventArgs) Handles UpdateChecker.Tick
        updateWorker.RunWorkerAsync()
    End Sub

    Private Sub TrayIcon_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TrayIcon.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Middle Then
            dockToggle()
        End If
    End Sub


    Public Sub dockToggle()
        If DockForm.Visible = False Then
            DockForm.Show()

            populateDock()
        Else
            DockForm.Close()
        End If
    End Sub

    Public Sub populateDock()
        If DockForm.IsHandleCreated Then
            DockForm.ToolStrip1.Items.Clear()
            For Each game As String In PathContainer.Keys
                Dim currentGame = Nothing
                For Each contextMenuItem As Object In MainContextMenu.Items
                    If game = contextMenuItem.Text Then
                        currentGame = contextMenuItem
                        Exit For
                    End If
                Next

                Dim addedItem As ToolStripItem = DockForm.ToolStrip1.Items.Add(currentGame.Image)
                addedItem.ToolTipText = game.Replace("&&", "&")
                addedItem.Text = game
                addedItem.DisplayStyle = ToolStripItemDisplayStyle.Image

                AddHandler addedItem.Click, AddressOf runGame
            Next
        End If
    End Sub

    Private Sub TrayIcon_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TrayIcon.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            dockToggle()
        ElseIf DragDropTargetForm.Visible Then
            DragDropTargetForm.Close()
        Else
            If DragDropTargetForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim MyFiles() As String = DragDropTargetForm.Files
                Dim i As Integer

                For i = 0 To MyFiles.Length - 1
                    Dim skip As Boolean = False
                    Dim currentFile As String = MyFiles(i)
                    Dim friendlyFileName As String = Path.GetFileNameWithoutExtension(currentFile)
                    Dim currentExtension As String = System.IO.Path.GetExtension(MyFiles(i)).ToLower()

                    If currentExtension = ".lnk" Then
                        'Shell shortcut
                        Dim theShell As New IWshRuntimeLibrary.WshShell()
                        Dim theShortcut As IWshRuntimeLibrary.WshShortcut = theShell.CreateShortcut(MyFiles(i))
                        currentFile = theShortcut.TargetPath
                    ElseIf currentExtension = ".exe" Or currentExtension = ".bat" Or currentExtension = ".cmd" Or currentExtension = ".jar" Then
                        'Executeable
                    ElseIf currentExtension = ".url" Then
                        'Internet shortcut (Steam shortcut)
                        Dim iniFile As New IniFile.IniFile(currentFile)
                        Dim keyz As ArrayList = iniFile.GetKeys("InternetShortcut")

                        For counter As Integer = 0 To (keyz.Count - 1) Step 1
                            Dim key As IniFile.Key = keyz(counter)
                            If key.Name.ToLower = "url" Then
                                If key.Value.ToLower.StartsWith("steam://rungameid/") Then
                                    currentFile = key.Value.ToLower
                                    Exit For
                                Else
                                    skip = True
                                    Exit For
                                End If
                            End If
                        Next
                    Else
                        'Anything else
                        skip = True
                    End If

                    If skip = False Then
                        AddNewGameForm.gameNameTextBox.Text = friendlyFileName

                        If currentFile.StartsWith("steam://rungameid/") Then
                            AddNewGameForm.steamGameRadio.Checked = True
                            AddNewGameForm.steamAppIDTextBox.Text = currentFile.Remove(0, 18)
                            AddNewGameForm.getFromOtherFileRadio.Checked = True
                        Else
                            AddNewGameForm.gamePathTextBox.Text = currentFile
                            AddNewGameForm.normalGameRadio.Checked = True
                            AddNewGameForm.getFromExeRadio.Checked = True

                            Dim sourceBitmap As Bitmap = GetSmallIcon(currentFile).ToBitmap
                            AddNewGameForm.gameIconPreviewBox.BackgroundImage = sourceBitmap
                        End If

                        If AddNewGameForm.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Dim gameName, cmdArgs, gamePath, launcherPath As String
                            Dim gameType As gameTypes
                            Dim img As Bitmap

                            gamePath = Nothing
                            launcherPath = Nothing

                            'Determine type of game to be added
                            If AddNewGameForm.normalGameRadio.Checked Then
                                gamePath = AddNewGameForm.gamePathTextBox.Text.Trim
                                If AddNewGameForm.usesLauncherCheckBox.Checked Then
                                    launcherPath = AddNewGameForm.launcherPathTextBox.Text.Trim
                                    gameType = gameTypes.normalWithLauncher
                                Else
                                    gameType = gameTypes.normal
                                End If
                            Else
                                gamePath = AddNewGameForm.steamAppIDTextBox.Text.Trim
                                If AddNewGameForm.specifySteamExeCheckBox.Checked Then
                                    launcherPath = AddNewGameForm.steamExePathTextBox.Text.Trim
                                    gameType = gameTypes.steamWithExe
                                Else
                                    gameType = gameTypes.steam
                                End If
                            End If

                            gameName = AddNewGameForm.gameNameTextBox.Text.Trim.Replace("="c, "-"c).Replace("&", "&&")
                            cmdArgs = AddNewGameForm.commandLineTextBox.Text.Trim.Replace("=", "|||")

                            If AddNewGameForm.getFromExeRadio.Checked Then ' From EXE
                                If AddNewGameForm.normalGameRadio.Checked Then ' From EXE and normal game
                                    Dim fileName As String = AddNewGameForm.gamePathTextBox.Text
                                    Dim extension As String = Path.GetExtension(fileName).ToLower
                                    img = New Bitmap(GetSmallIcon(fileName).ToBitmap)
                                Else ' From EXE and Steam game
                                    Dim fileName As String = AddNewGameForm.steamExePathTextBox.Text
                                    Dim extension As String = Path.GetExtension(fileName).ToLower
                                    img = New Bitmap(GetSmallIcon(fileName).ToBitmap)
                                End If
                            Else ' From other file
                                Select Case Path.GetExtension(AddNewGameForm.customIconPathTextBox.Text)
                                    Case ".exe" ' The other file is an application
                                        Dim fileName As String = AddNewGameForm.customIconPathTextBox.Text
                                        Dim extension As String = Path.GetExtension(fileName).ToLower
                                        img = New Bitmap(GetSmallIcon(fileName).ToBitmap)

                                        If img.Width > 16 Or img.Height > 16 Then 'If the image isn't 16x16, resize it
                                            img = ResizeImage(img, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBicubic, True)
                                        End If
                                    Case Else REM The other file is an image
                                        img = New Bitmap(AddNewGameForm.customIconPathTextBox.Text)
                                        img = ResizeImage(img, New Size(16, 16), Drawing2D.InterpolationMode.HighQualityBicubic, True)
                                End Select
                            End If

                            Dim errorMsg As String = Nothing
                            Select Case gameType
                                Case gameTypes.normal
                                    errorMsg = newAddGame(gameTypes.normal, gameName, gamePath, img, Nothing, cmdArgs)
                                Case gameTypes.normalWithLauncher
                                    errorMsg = newAddGame(gameTypes.normal, gameName, gamePath, img, launcherPath, cmdArgs)
                                Case gameTypes.steam
                                    errorMsg = newAddGame(gameTypes.steam, gameName, gamePath, img, Nothing, cmdArgs)
                                Case gameTypes.steamWithExe
                                    errorMsg = newAddGame(gameTypes.steam, gameName, gamePath, img, launcherPath, cmdArgs)
                            End Select

                            If errorMsg <> "Success" Then
                                MessageBox.Show(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormAddGameFailed1") & vbNewLine & errorMsg & vbNewLine & vbNewLine & _
                                                CURRENT_LANGUAGE_RESOURCE.GetString("MainFormAddGameFailed2"), _
                                                My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Else
                                populateDock()
                                clearMenu()
                                rebuildMenu()
                                commitChanges()
                            End If
                        End If

                        AddNewGameForm.resetForm()
                    End If
                Next
                DragDropTargetForm.Files = Nothing
            End If
        End If
    End Sub

    Enum playTimeToggleType
        toggle = 0
        check = 1
    End Enum

    Public Function togglePlayTimeInSkypeNotifications(ByVal type As playTimeToggleType) As Boolean
        Dim skypeNotificationKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)

        Dim val As Integer = skypeNotificationKey.GetValue("playTimeInSkypeNotifications", 1337)
        If val = 0 Then
            'Notifications are turned off
            If type = playTimeToggleType.toggle Then
                skypeNotificationKey.SetValue("playTimeInSkypeNotifications", 1, RegistryValueKind.DWord)
                playTimeInSkypeNotifications = True
                Return True
            Else
                skypeNotificationKey.SetValue("playTimeInSkypeNotifications", 0, RegistryValueKind.DWord)
                playTimeInSkypeNotifications = False
                Return False
            End If
        ElseIf val = 1 Then
            'Notifications are turned on
            If type = playTimeToggleType.toggle Then
                skypeNotificationKey.SetValue("playTimeInSkypeNotifications", 0, RegistryValueKind.DWord)
                playTimeInSkypeNotifications = False
                Return False
            Else
                skypeNotificationKey.SetValue("playTimeInSkypeNotifications", 1, RegistryValueKind.DWord)
                playTimeInSkypeNotifications = True
                Return True
            End If
        Else
            'Doesn't exist or contains some other value
            If type = playTimeToggleType.toggle Then
                skypeNotificationKey.SetValue("playTimeInSkypeNotifications", 0, RegistryValueKind.DWord)
                playTimeInSkypeNotifications = False
                Return False
            Else
                skypeNotificationKey.SetValue("playTimeInSkypeNotifications", 1, RegistryValueKind.DWord)
                playTimeInSkypeNotifications = True
                Return True
            End If
        End If
    End Function

    Private Sub skypeWorker_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles skypeWorker.DoWork
        skypeConnect()
    End Sub

    Private Sub updateWorker_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles updateWorker.DoWork
        e.Result = checkForUpdates()
    End Sub

    Private Sub PreferencesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PreferencesToolStripMenuItem.Click
        GLOptions.Show()
    End Sub

    Private Sub StatisticsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StatisticsToolStripMenuItem.Click
        Try
            PieChartForm.Show()
        Catch ex As ObjectDisposedException
            ' No data, do nada
        End Try
    End Sub

    Private Sub processMonitorTimer_Tick(ByVal state As Object)
        If processMonitorCounter < 300 Then
            processMonitorWorker.RunWorkerAsync(CurrentRunningGameProcessName)
            processMonitorCounter += 1
        Else
            processMonitorCounter = 0
            processMonitorTimer.Change(Timeout.Infinite, Timeout.Infinite)
        End If
    End Sub

    Private Sub processMonitorWorker_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles processMonitorWorker.DoWork
        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName = e.Argument Then
                processMonitorTimer.Change(Timeout.Infinite, Timeout.Infinite) ' Stop the timer
                currentRunningGameProcess = clsProcess
                currentRunningGameTimeStamp = currentRunningGameProcess.StartTime
                currentRunningGameProcess.EnableRaisingEvents = True
                AddHandler currentRunningGameProcess.Exited, AddressOf stoppedPlaying
            End If
        Next
    End Sub

    Private Sub runGameWorker_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles runGameWorker.DoWork
        Dim tsi As ToolStripMenuItem = DirectCast(e.Argument, ToolStripMenuItem)
        currentRunningGame = tsi.Text

        Try
            If sendSkypeNotification Then
                If isProcessRunning("skype") Then
                    oSkype.Attach(8, True)
                    If oSkype.AttachmentStatus() = SKYPE4COMLib.TAttachmentStatus.apiAttachSuccess Then
                        If PathContainer(currentRunningGame).StartsWith("steam") Then
                            oSkype.Profile("Mood_Text") = String.Format(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormSkypeNowPlayingSteam"), currentRunningGame.Replace("&&", "&"))
                        Else
                            oSkype.Profile("Mood_Text") = String.Format(CURRENT_LANGUAGE_RESOURCE.GetString("MainFormSkypeNowPlaying"), currentRunningGame.Replace("&&", "&"))
                        End If
                    End If
                End If
            End If
        Catch ex As COMException
            'Skype connection FAILED D:
            TrayIcon.ShowBalloonTip(5000, "Skype connection failed", "Please check your allowed applications in Skype settings", ToolTipIcon.Info)
        End Try


        If PathContainer.ContainsKey(currentRunningGame) Then
            If PathContainer(currentRunningGame).StartsWith("steam://rungameid/") = False Then
                If LaunchersContainer.ContainsKey(currentRunningGame) Then
                    'Normal game with launcher
                    My.Computer.FileSystem.CurrentDirectory = Path.GetDirectoryName(LaunchersContainer(currentRunningGame))
                    CurrentRunningGameProcessName = Path.GetFileNameWithoutExtension(PathContainer(currentRunningGame))
                    processMonitorCounter = 0
                    processMonitorTimer.Change(0, 1000)

                    Dim proc As New Process()
                    Dim startInfo As New ProcessStartInfo
                    startInfo.FileName = LaunchersContainer(currentRunningGame)

                    If ArgsContainer.ContainsKey(currentRunningGame) Then
                        startInfo.Arguments = ArgsContainer(currentRunningGame).Replace("|||", "=")
                    End If

                    proc.StartInfo = startInfo
                    proc.Start()

                    My.Computer.FileSystem.CurrentDirectory = Application.StartupPath
                    Exit Sub
                Else
                    'Normal game without launcher, continue
                    My.Computer.FileSystem.CurrentDirectory = Path.GetDirectoryName(PathContainer(currentRunningGame))
                End If
            Else
                If LaunchersContainer.ContainsKey(currentRunningGame) Then
                    'Steam game with specified EXE
                    CurrentRunningGameProcessName = Path.GetFileNameWithoutExtension(LaunchersContainer(currentRunningGame))
                    processMonitorCounter = 0
                    processMonitorTimer.Change(0, 1000)

                    If ArgsContainer.ContainsKey(currentRunningGame) Then ' If the game has arguments...
                        If PathContainer(currentRunningGame).StartsWith("steam") Then ' If it's a Steam game, launch it from the Steam EXE rather via the Steam protocol!
                            Dim steamID As String = PathContainer(currentRunningGame).Remove(0, 18)
                            Dim proc As New Process()
                            Dim startInfo As New ProcessStartInfo

                            startInfo.FileName = getSteamExe()
                            startInfo.Arguments = "-applaunch " & steamID & " " & ArgsContainer(currentRunningGame).Replace("|||", "=")
                        End If
                        Exit Sub
                    Else
                        'No arguments, launch via steam protocol
                        System.Diagnostics.Process.Start(PathContainer(currentRunningGame))
                        Exit Sub
                    End If
                Else
                    'Steam game without specified EXE, continue
                End If
            End If
        End If

        Dim nProcess As New Process()
        Dim psi As New ProcessStartInfo
        psi.FileName = PathContainer(currentRunningGame)

        If ArgsContainer.ContainsKey(currentRunningGame) Then ' If the game has arguments...
            If PathContainer(currentRunningGame).StartsWith("steam") Then ' If it's a Steam game, launch it from the Steam EXE rather via the Steam protocol!
                Dim steamID As String = PathContainer(currentRunningGame).Substring(18)
                psi.FileName = getSteamExe()
                psi.Arguments = "-applaunch " & steamID & " " & ArgsContainer(currentRunningGame).Replace("|||", "=")
            Else
                psi.Arguments = ArgsContainer(currentRunningGame)
            End If
        End If

        nProcess.StartInfo = psi
        nProcess.EnableRaisingEvents = True

        If PathContainer(currentRunningGame).StartsWith("steam") = False Then 'No need to waste resources on adding a handler for Steam games
            currentRunningGameTimeStamp = Date.Now
            AddHandler nProcess.Exited, AddressOf stoppedPlaying
        End If

        nProcess.Start()

        'Restore the working directory
        My.Computer.FileSystem.CurrentDirectory = Application.StartupPath
    End Sub

    Private Sub updateWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles updateWorker.RunWorkerCompleted
        Dim newVersion As String = DirectCast(e.Result, String)

        If newVersion IsNot Nothing Then 'If new version was found
            NotificationForm.newVersion = DirectCast(e.Result, String)
            NotificationForm.Show()
        End If
    End Sub

    Private Sub ThemeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ThemeToolStripMenuItem.Click
        ThemeChanger.Show()
    End Sub
End Class
