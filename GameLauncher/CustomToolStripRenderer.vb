Imports Microsoft.Win32
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class CustomToolStripRenderer
    Inherits System.Windows.Forms.ToolStripProfessionalRenderer

    Private backgroundBrush As Brush = Nothing
    Dim greatestLength As Integer = 0
    Dim regKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)

    Public Sub New()
        MyBase.New(New AwesomeColors())
    End Sub

    Protected Overrides Sub OnRenderItemText(ByVal e As ToolStripItemTextRenderEventArgs)
        Dim isThemed As Integer = regKey.GetValue("isThemed", Nothing)
        Dim foreCol As Color = Color.FromArgb(regKey.GetValue("foreColor", Nothing))
        Dim listFont As String = regKey.GetValue("listFont", Nothing)

        If isThemed = 1 Then
            e.TextColor = foreCol
            e.Item.Font = New Font(listFont, 8, FontStyle.Regular) ' This way the width of the items will increase or decrease as intended
        End If

        MyBase.OnRenderItemText(e)
    End Sub

Protected Overrides Sub OnRenderToolStripBackground(e As System.Windows.Forms.ToolStripRenderEventArgs)
        MyBase.OnRenderToolStripBackground(e)

        Dim backColorRegKeyValue As Integer = regKey.GetValue("backColor", Nothing)
        Dim backColor As Color = Color.FromArgb(backColorRegKeyValue)

        If Me.backgroundBrush Is Nothing Then
            Me.backgroundBrush = New SolidBrush(backColor)
        End If
        e.Graphics.FillRectangle(Me.backgroundBrush, e.AffectedBounds)
    End Sub

    Protected Overrides Sub OnRenderImageMargin(e As System.Windows.Forms.ToolStripRenderEventArgs)
        MyBase.OnRenderImageMargin(e)

        Dim backColorRegKeyValue As Integer = regKey.GetValue("backColor", Nothing)
        Dim backColor As Color = Color.FromArgb(backColorRegKeyValue)

        If Me.backgroundBrush Is Nothing Then
            Me.backgroundBrush = New SolidBrush(backColor)
        End If
        e.Graphics.FillRectangle(Me.backgroundBrush, e.AffectedBounds)
    End Sub
End Class

Class AwesomeColors
    Inherits ProfessionalColorTable

    Dim regKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)

    Public Overrides ReadOnly Property MenuItemSelected() As Color
        Get
            Dim backColor As Color = Color.FromArgb(regKey.GetValue("backColor", Nothing))
            Return backColor
        End Get
    End Property
    Public Overrides ReadOnly Property MenuItemBorder() As Color
        Get
            Dim foreColor As Color = Color.FromArgb(regKey.GetValue("foreColor", Nothing))
            Return foreColor
        End Get
    End Property
End Class
