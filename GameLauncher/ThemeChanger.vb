Imports Microsoft.Win32
Imports System.Drawing.Text

Public Class ThemeChanger

    Dim regKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)

    Private Sub useCustomThemeCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles useCustomThemeCheckBox.CheckedChanged
        If useCustomThemeCheckBox.Checked Then
            themingOptionsGroupBox.Enabled = True
            MainForm.MainContextMenu.Renderer = New CustomToolStripRenderer()
            regKey.SetValue("isThemed", 1)
        Else
            themingOptionsGroupBox.Enabled = False
            MainForm.MainContextMenu.RenderMode = ToolStripRenderMode.ManagerRenderMode

            For Each item As ToolStripItem In MainForm.MainContextMenu.Items
                item.Font = ContextMenuStrip.DefaultFont
            Next

            regKey.SetValue("isThemed", 0)
        End If
    End Sub

    Private Sub ThemeChanger_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim isThemed As Integer = CInt(regKey.GetValue("isThemed", Nothing))
        Dim foreColor As Color = Color.FromArgb(regKey.GetValue("foreColor", Nothing))
        Dim backColor As Color = Color.FromArgb(regKey.GetValue("backColor", Nothing))
        Dim listFont As String = regKey.GetValue("listFont", Nothing)

        'Enumerate fonts
        fontPicker.Items.Clear()
        Dim ifc As New InstalledFontCollection()
        For Each ff As FontFamily In ifc.Families
            fontPicker.Items.Add(ff.Name.ToString())
        Next
        fontPicker.SelectedItem = listFont

        If isThemed = 1 Then
            useCustomThemeCheckBox.Checked = True
            foreColorPreview.BackColor = foreColor
            backColorPreview.BackColor = backColor
            fontPreview.Font = New Font(listFont, 8)
        Else
            regKey.SetValue("isThemed", 0, RegistryValueKind.DWord)
            useCustomThemeCheckBox.Checked = False
        End If
    End Sub

    Private Sub PictureBox1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles foreColorPreview.MouseClick
        Dim selectedColor As Color = getUserColor(DirectCast(sender, PictureBox))
        If Not selectedColor = Nothing Then
            foreColorPreview.BackColor = selectedColor
            regKey.SetValue("foreColor", selectedColor.ToArgb())
            MainForm.MainContextMenu.Renderer = New CustomToolStripRenderer()
        End If

    End Sub

    Private Sub PictureBox2_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles backColorPreview.MouseClick
        Dim selectedColor As Color = getUserColor(DirectCast(sender, PictureBox))
        If Not selectedColor = Nothing Then
            backColorPreview.BackColor = selectedColor
            regKey.SetValue("backColor", selectedColor.ToArgb())
            MainForm.MainContextMenu.Renderer = New CustomToolStripRenderer()
        End If
    End Sub

    Private Function getUserColor(sender As PictureBox) As Color
        Dim colorPicker As New ColorDialog
        colorPicker.Color = sender.BackColor
        colorPicker.FullOpen = True
        colorPicker.SolidColorOnly = True

        If colorPicker.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return colorPicker.Color
        Else
            Return Nothing
        End If
    End Function

    Private Sub fontPicker_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles fontPicker.SelectedIndexChanged
        Try
            fontPreview.Font = New Font(fontPicker.SelectedItem.ToString, 8)
            regKey.SetValue("listFont", fontPicker.SelectedItem.ToString())
        Catch ex As Exception

        End Try
    End Sub
End Class