Imports Microsoft.Win32
Imports System.Web
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Net
Imports System.IO

Public Class PieChartForm

#Region "Color Palettes"
    '.NET default chart palettes
    Dim pltBerry As Color() = {Color.BlueViolet, Color.MediumOrchid, Color.RoyalBlue, Color.MediumVioletRed, Color.Blue, Color.BlueViolet, Color.Orchid, Color.MediumSlateBlue, Color.FromArgb(&HC0, 0, &HC0), Color.MediumBlue, Color.Purple}
    Dim pltBrightPastel As Color() = {Color.FromArgb(&H41, 140, 240), Color.FromArgb(&HFC, 180, &H41), Color.FromArgb(&HE0, &H40, 10), Color.FromArgb(5, 100, &H92), Color.FromArgb(&H1A, &H3B, &H69), Color.FromArgb(&HFF, &HE3, 130), Color.FromArgb(&H12, &H9C, &HDD), Color.FromArgb(&HCA, &H6B, &H4B), Color.FromArgb(0, &H5C, &HDB), Color.FromArgb(&HF3, 210, &H88), Color.FromArgb(80, &H63, &H81), Color.FromArgb(&HF1, &HB9, &HA8), Color.FromArgb(&HE0, &H83, 10), Color.FromArgb(120, &H93, 190)}
    Dim pltBright As Color() = {Color.Green, Color.Blue, Color.Purple, Color.Lime, Color.Fuchsia, Color.Teal, Color.Yellow, Color.Gray, Color.Aqua, Color.Navy, Color.Maroon, Color.Red, Color.Olive, Color.Silver, Color.Tomato, Color.Moccasin}
    Dim pltChocolate As Color() = {Color.Sienna, Color.Chocolate, Color.DarkRed, Color.Peru, Color.Brown, Color.SandyBrown, Color.SaddleBrown, Color.FromArgb(&HC0, &H40, 0), Color.Firebrick, Color.FromArgb(&HB6, &H5C, &H3A)}
    Dim pltEarth As Color() = {Color.FromArgb(&HFF, &H80, 0), Color.DarkGoldenrod, Color.FromArgb(&HC0, &H40, 0), Color.OliveDrab, Color.Peru, Color.FromArgb(&HC0, &HC0, 0), Color.ForestGreen, Color.Chocolate, Color.Olive, Color.LightSeaGreen, Color.SandyBrown, Color.FromArgb(0, &HC0, 0), Color.DarkSeaGreen, Color.Firebrick, Color.SaddleBrown, Color.FromArgb(&HC0, 0, 0)}
    Dim pltExcel As Color() = {Color.FromArgb(&H99, &H99, &HFF), Color.FromArgb(&H99, &H33, &H66), Color.FromArgb(&HFF, &HFF, &HCC), Color.FromArgb(&HCC, &HFF, &HFF), Color.FromArgb(&H66, 0, &H66), Color.FromArgb(&HFF, &H80, &H80), Color.FromArgb(0, &H66, &HCC), Color.FromArgb(&HCC, &HCC, &HFF), Color.FromArgb(0, 0, &H80), Color.FromArgb(&HFF, 0, &HFF), Color.FromArgb(&HFF, &HFF, 0), Color.FromArgb(0, &HFF, &HFF), Color.FromArgb(&H80, 0, &H80), Color.FromArgb(&H80, 0, 0), Color.FromArgb(0, &H80, &H80), Color.FromArgb(0, 0, &HFF)}
    Dim pltFire As Color() = {Color.Gold, Color.Red, Color.DeepPink, Color.Crimson, Color.DarkOrange, Color.Magenta, Color.Yellow, Color.OrangeRed, Color.MediumVioletRed, Color.FromArgb(&HDD, &HE2, &H21)}
    Dim pltLight As Color() = {Color.Lavender, Color.LavenderBlush, Color.PeachPuff, Color.LemonChiffon, Color.MistyRose, Color.Honeydew, Color.AliceBlue, Color.WhiteSmoke, Color.AntiqueWhite, Color.LightCyan}
    Dim pltPastel As Color() = {Color.SkyBlue, Color.LimeGreen, Color.MediumOrchid, Color.LightCoral, Color.SteelBlue, Color.YellowGreen, Color.Turquoise, Color.HotPink, Color.Khaki, Color.Tan, Color.DarkSeaGreen, Color.CornflowerBlue, Color.Plum, Color.CadetBlue, Color.PeachPuff, Color.LightSalmon}
    Dim pltSeaGreen As Color() = {Color.SeaGreen, Color.MediumAquamarine, Color.SteelBlue, Color.DarkCyan, Color.CadetBlue, Color.MediumSeaGreen, Color.MediumTurquoise, Color.LightSteelBlue, Color.DarkSeaGreen, Color.SkyBlue}
    Dim pltGrayscale As Color() = {Color.FromArgb(&H2E, &H2E, &H2E), Color.FromArgb(&H3D, &H3D, &H3D), Color.FromArgb(&H4D, &H4D, &H4D), Color.FromArgb(&H5C, &H5C, &H5C), Color.FromArgb(&H69, &H69, &H69), Color.FromArgb(&H78, &H78, &H78), Color.FromArgb(&H80, &H80, &H80), Color.FromArgb(&H82, &H82, &H82), Color.FromArgb(&H91, &H91, &H91), Color.FromArgb(&HA1, &HA1, &HA1), Color.FromArgb(&HAB, &HAB, &HAB), Color.FromArgb(&HB8, &HB8, &HB8), Color.FromArgb(&HC2, &HC2, &HC2), Color.FromArgb(&HCF, &HCF, &HCF), Color.FromArgb(&HD9, &HD9, &HD9), Color.FromArgb(&HE5, &HE5, &HE5)}

    'Custom palettes
    Dim pltGoldfish As Color() = {Color.FromArgb(105, 210, 231), Color.FromArgb(136, 215, 224), Color.FromArgb(167, 219, 216), Color.FromArgb(196, 224, 210), Color.FromArgb(224, 228, 204), Color.FromArgb(234, 181, 126), Color.FromArgb(243, 134, 48), Color.FromArgb(247, 120, 24), Color.FromArgb(250, 105, 0)}
    Dim pltCake As Color() = {Color.FromArgb(119, 79, 56), Color.FromArgb(172, 111, 89), Color.FromArgb(224, 142, 121), Color.FromArgb(233, 177, 148), Color.FromArgb(241, 212, 175), Color.FromArgb(239, 221, 191), Color.FromArgb(236, 229, 206), Color.FromArgb(217, 227, 213), Color.FromArgb(197, 224, 220)}
    Dim pltChewingGum As Color() = {Color.FromArgb(255, 0, 255), Color.FromArgb(255, 28, 227), Color.FromArgb(255, 57, 198), Color.FromArgb(255, 85, 170), Color.FromArgb(255, 113, 142), Color.FromArgb(255, 142, 113), Color.FromArgb(255, 170, 85), Color.FromArgb(255, 198, 57), Color.FromArgb(255, 227, 28), Color.FromArgb(255, 255, 0)}
    Dim pltFruit As Color() = {Color.FromArgb(209, 242, 165), Color.FromArgb(224, 246, 173), Color.FromArgb(239, 250, 180), Color.FromArgb(247, 223, 160), Color.FromArgb(255, 196, 140), Color.FromArgb(255, 178, 134), Color.FromArgb(255, 159, 128), Color.FromArgb(250, 132, 137), Color.FromArgb(245, 105, 145)}
#End Region

    Dim sortByPlayTime As Boolean = True

    Private Sub PieChartForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitializeChartForm()

        ' Multi-language stuff
        Me.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormTitleBar")
        generateChartButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormGenerateChartButton")
        clearDataLink.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormClearDataLinkText")
        saveAsImageButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormSaveAsImageButton")
        legendToggleCheckBox.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormShowLegendCheckBox")
        pieCloseButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormCloseButtonText")
    End Sub

    Public Sub InitializeChartForm()
        Chart1.Series(0).Points.Clear()
        Chart1.Titles.Clear()

        Dim labelPrevious As Integer = labelPicker.SelectedIndex
        If labelPrevious = -1 Then labelPrevious = 0
        labelPicker.Items.Clear()
        labelPicker.Items.Add(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormLabelPickerOutside"))
        labelPicker.Items.Add(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormLabelPickerInside"))
        labelPicker.Items.Add(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormLabelPickerNone"))
        labelPicker.SelectedIndex = labelPrevious

        Dim sortingPrevious As Integer = sortingComboBox.SelectedIndex
        If sortingPrevious = -1 Then sortingPrevious = 0
        sortingComboBox.Items.Clear()
        sortingComboBox.Items.Add(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormSortingPickerByMostPlayed"))
        sortingComboBox.Items.Add(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormSortingPickerAlphabetically"))
        sortingComboBox.SelectedIndex = sortingPrevious

        If palettePicker.SelectedIndex = -1 Then
            palettePicker.SelectedItem = "Bright Pastel"
        Else
            palettePicker.SelectedIndex = palettePicker.SelectedIndex
        End If


        With Chart1
            .Palette = ChartColorPalette.None
            .Series(0).BorderColor = Color.Black
            .ChartAreas(0).Area3DStyle.Enable3D = enable3DCheckBox.Checked
        End With

        Dim statsKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher\stats", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim values As String() = statsKey.GetValueNames()

        'Make a dictionary depending on sort mode
        Dim i As Integer = 0
        Dim newDict As New SortedDictionary(Of String, String)(New NaturalComparer)
        If sortByPlayTime Then
            While i < values.Length
                newDict.Add(CStr(statsKey.GetValue(values(i))), values(i))
                i += 1
            End While
        Else
            While i < values.Length
                newDict.Add(values(i), CStr(statsKey.GetValue(values(i))))
                i += 1
            End While
        End If

        If newDict.Count = 0 Then
            MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormNoData"), "Game Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            Dim gameName As String = Nothing
            Dim gamePlayTime As Int64 = 0
            Dim total As Int64 = 0
            Dim dataPt As DataPoint = Nothing
            Dim days, hours, mins, secs As Integer
            Dim shortD, shortH, shortM, shortS As String

            shortD = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormTimeDayShorthand")
            shortH = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormTimeHourShorthand")
            shortM = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormTimeMinuteShorthand")
            shortS = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormTimeSecondShorthand")

            For Each kvp As KeyValuePair(Of String, String) In newDict
                If sortByPlayTime Then
                    gamePlayTime = kvp.Key
                    gameName = kvp.Value
                Else
                    gamePlayTime = kvp.Value
                    gameName = kvp.Key
                End If

                gameName = gameName.Replace("&&", "&")

                If gamePlayTime <> Nothing Then
                    total += gamePlayTime
                    dataPt = Chart1.Series(0).Points.Add(gamePlayTime)
                    days = TimeSpan.FromSeconds(gamePlayTime).Days
                    hours = TimeSpan.FromSeconds(gamePlayTime).Hours
                    mins = TimeSpan.FromSeconds(gamePlayTime).Minutes
                    secs = TimeSpan.FromSeconds(gamePlayTime).Seconds
                    dataPt.Label = String.Format("{1}{0}({2}{3} {4}{5} {6}{7} {8}{9}, #PERCENT)", vbNewLine, gameName, days, shortD, hours, shortH, mins, shortM, secs, shortS)
                End If
            Next

            Chart1.Titles.Add(String.Format("{8}: {0}{1} {2}{3} {4}{5} {6}{7}", _
                                            CStr(TimeSpan.FromSeconds(CDbl(total)).Days), shortD, _
                                            CStr(TimeSpan.FromSeconds(CDbl(total)).Hours), shortH, _
                                            CStr(TimeSpan.FromSeconds(CDbl(total)).Minutes), shortM, _
                                            CStr(TimeSpan.FromSeconds(CDbl(total)).Seconds), shortS, _
                                            MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormTotalPlayingTime")))
        End If
    End Sub

    Private Sub saveAsImageButton_Click(sender As System.Object, e As System.EventArgs) Handles saveAsImageButton.Click
        Dim saveChartDialog As New SaveFileDialog
        With saveChartDialog
            .Title = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormSaveAsImageTitlebar")
            .AddExtension = True
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            .FileName = "chart"
            .Filter = "PNG|*.png|JPEG|*.jpg;*.jpeg;*.jfif|GIF|*.gif|TIFF|*.tiff|Bitmap|*.bmp"
        End With

        If saveChartDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim tempImgFormat As Imaging.ImageFormat = Nothing
            Select Case saveChartDialog.FilterIndex
                Case 0
                    tempImgFormat = Imaging.ImageFormat.Png
                Case 1
                    tempImgFormat = Imaging.ImageFormat.Jpeg
                Case 2
                    tempImgFormat = Imaging.ImageFormat.Gif
                Case 3
                    tempImgFormat = Imaging.ImageFormat.Tiff
                Case 4
                    tempImgFormat = Imaging.ImageFormat.Bmp
            End Select

            Try
                Chart1.SaveImage(saveChartDialog.FileName, Imaging.ImageFormat.Png)
                MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormSaveAsImageSuccess"), _
                                MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormSaveAsImageTitleBar"), _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error:" & vbNewLine & vbNewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub pieCloseButton_Click(sender As System.Object, e As System.EventArgs) Handles pieCloseButton.Click
        Me.Close()
    End Sub

    Private Sub labelPicker_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles labelPicker.SelectedIndexChanged
        Select Case labelPicker.SelectedIndex
            Case 0
                Chart1.Series(0).CustomProperties() = "PieLabelStyle=Outside"
            Case 1
                Chart1.Series(0).CustomProperties() = "PieLabelStyle=Inside"
            Case 2
                Chart1.Series(0).CustomProperties() = "PieLabelStyle=Disabled"
        End Select
    End Sub

    Private Sub legendToggleCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles legendToggleCheckBox.CheckedChanged
        If legendToggleCheckBox.Checked Then
            Chart1.Legends(0).Enabled = True
        Else
            Chart1.Legends(0).Enabled = False
        End If
    End Sub

    Private Sub palettePicker_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles palettePicker.SelectedIndexChanged
        Select Case palettePicker.SelectedItem
            Case "Berry"
                Chart1.PaletteCustomColors = pltBerry
            Case "Bright Pastel"
                Chart1.PaletteCustomColors = pltBrightPastel
            Case "Bright"
                Chart1.PaletteCustomColors = pltBright
            Case "Cake"
                Chart1.PaletteCustomColors = pltCake
            Case "Chewing Gum"
                Chart1.PaletteCustomColors = pltChewingGum
            Case "Chocolate"
                Chart1.PaletteCustomColors = pltChocolate
            Case "Earth Tones"
                Chart1.PaletteCustomColors = pltEarth
            Case "Excel"
                Chart1.PaletteCustomColors = pltExcel
            Case "Fire"
                Chart1.PaletteCustomColors = pltFire
            Case "Fruit"
                Chart1.PaletteCustomColors = pltFruit
            Case "Goldfish"
                Chart1.PaletteCustomColors = pltGoldfish
            Case "Grayscale"
                Chart1.PaletteCustomColors = pltGrayscale
            Case "Light"
                Chart1.PaletteCustomColors = pltLight
            Case "Pastel"
                Chart1.PaletteCustomColors = pltPastel
            Case "Sea Green"
                Chart1.PaletteCustomColors = pltSeaGreen
        End Select
    End Sub


    Private Sub clearDataLink_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles clearDataLink.LinkClicked
        RemoveForm.ListBox1.ClearSelected()
        RemoveForm.ListBox1.Items.Clear()

        Dim statsKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher\stats", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim values As String() = statsKey.GetValueNames()
        Array.Sort(values)

        For Each element As String In values
            RemoveForm.ListBox1.Items.Add(element.Replace("&&", "&"))
        Next

        If RemoveForm.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each element As String In RemoveForm.ListBox1.SelectedItems
                statsKey.DeleteValue(element.Replace("&", "&&"))
            Next

            Dim remainingValues As String() = statsKey.GetValueNames()

            If remainingValues.Length = 0 Then
                Me.Close()
            Else
                InitializeChartForm()
            End If
        End If
    End Sub

    Sub generateGoogleChartLink()
        Dim statsKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher\stats", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim baseURL As String = "http://is.gd/create.php?format=simple&url="
        Dim arguments As Dictionary(Of String, String) = New Dictionary(Of String, String)
        arguments.Add("cht", "p3") 'Chart Type = Pie
        arguments.Add("chds", "a") 'Chart Data Scaling = Automatic
        arguments.Add("chs", "1000x300") ' Chart Dimensions

        'Enumerate labels
        Dim valueNames As String() = statsKey.GetValueNames()
        Dim total As Int64 = 0
        Dim days, hours, mins, secs As Integer
        For valueIndex As Integer = 0 To valueNames.Length - 1
            total += CType(statsKey.GetValue(valueNames(valueIndex)), Int64)
            days = TimeSpan.FromSeconds(CDbl(statsKey.GetValue(valueNames(valueIndex)))).Days
            hours = TimeSpan.FromSeconds(CDbl(statsKey.GetValue(valueNames(valueIndex)))).Hours
            mins = TimeSpan.FromSeconds(CDbl(statsKey.GetValue(valueNames(valueIndex)))).Minutes
            secs = TimeSpan.FromSeconds(CDbl(statsKey.GetValue(valueNames(valueIndex)))).Seconds
            valueNames(valueIndex) = HttpUtility.UrlEncode(valueNames(valueIndex).Replace("&&", "&")) & " (" & CInt(days) & "d " & CInt(hours) & "h " & CInt(mins) & "m " & CInt(secs) & "s)"
        Next

        arguments.Add("chtt", String.Format("{8}: {0}{1} {2}{3} {4}{5} {6}{7}", _
                                            CStr(TimeSpan.FromSeconds(CDbl(total)).Days), MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormTimeDayShorthand"), _
                                            CStr(TimeSpan.FromSeconds(CDbl(total)).Hours), MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormTimeHourShorthand"), _
                                            CStr(TimeSpan.FromSeconds(CDbl(total)).Minutes), MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormTimeMinuteShorthand"), _
                                            CStr(TimeSpan.FromSeconds(CDbl(total)).Seconds), MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormTimeSecondShorthand"), _
                                            MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormTotalPlayingTime"))) ' Chart Title

        Dim strColors As String = Nothing
        Dim colors As Color() = Chart1.PaletteCustomColors
        For Each col As Color In colors
            strColors &= String.Format("{0:X2}{1:X2}{2:X2}", col.R, col.G, col.B) & " "
        Next
        strColors = strColors.Trim()
        strColors = strColors.Replace(" "c, "|"c)
        arguments.Add("chco", strColors) 'Chart Colors

        'Enumerate data points
        Dim values As New ArrayList
        For Each valueName As String In statsKey.GetValueNames()
            values.Add(statsKey.GetValue(valueName))
        Next
        Dim valuesString As String = "t:" & String.Join(",", values.ToArray())
        Dim valueNamesString As String = String.Join("|", valueNames)



        'Add data points and labels to arguments dictionary
        arguments.Add("chl", valueNamesString) 'Vertical Pipe Delimited Chart Labels
        arguments.Add("chd", valuesString) 'Comma Delimited Chart Data

        'Build the URL
        Dim url As String = Nothing
        For Each pair As KeyValuePair(Of String, String) In arguments
            url &= pair.Key & "=" & pair.Value & "&"
        Next

        'Launch the URL

        url = baseURL & HttpUtility.UrlEncode("http://chart.googleapis.com/chart?" & url)

        Dim fileReader As New WebClient()
        Dim data As Stream
        Dim sr As StreamReader
        Dim currentLine As String
        Try
            data = fileReader.OpenRead(url)
            sr = New StreamReader(data)
            currentLine = sr.ReadLine()
            data.Close()
        Catch ex As Exception
            currentLine = "0"
        End Try

        EmbeddableChartForm.LinkTextBox.Text = currentLine
        EmbeddableChartForm.ShowDialog()
    End Sub

    Private Sub generateChartButton_Click(sender As System.Object, e As System.EventArgs) Handles generateChartButton.Click
        generateChartButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormPleaseWait")
        generateChartButton.Enabled = False
        generateGoogleChartLink()
        generateChartButton.Enabled = True
        generateChartButton.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("PieChartFormGenerateChartButton")
    End Sub

    Private Sub sortingComboBox_SelectedIndexCommitted(sender As System.Object, e As System.EventArgs) Handles sortingComboBox.SelectionChangeCommitted
        If sortingComboBox.SelectedIndex = 0 Then
            sortByPlayTime = True
        Else
            sortByPlayTime = False
        End If

        InitializeChartForm()
    End Sub

    Private Sub enable3DCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles enable3DCheckBox.CheckedChanged
        InitializeChartForm()
    End Sub
End Class