Imports Microsoft.Win32

Public Class DockOpacity

    Dim dockOpacity As Double = Nothing
    Dim dockHoverOpacity As Double = Nothing

    Private Sub NormalOpacityBar_Scroll(sender As System.Object, e As System.EventArgs) Handles NormalOpacityBar.Scroll
        NormalOpacityLabel.Text = CStr(NormalOpacityBar.Value)
        dockOpacity = NormalOpacityBar.Value / 100
        Me.Owner.Opacity = dockOpacity
    End Sub

    Private Sub HoverOpacityBar_Scroll(sender As Object, e As System.EventArgs) Handles HoverOpacityBar.Scroll
        HoverOpacityLabel.Text = CStr(HoverOpacityBar.Value)
        dockHoverOpacity = HoverOpacityBar.Value / 100
        Me.Owner.Opacity = dockHoverOpacity
    End Sub

    Private Sub buttonSave_Click(sender As System.Object, e As System.EventArgs) Handles buttonSave.Click
        Dim dockOpacityKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        dockOpacityKey.SetValue("dockOpacity", NormalOpacityBar.Value, RegistryValueKind.DWord)
        dockOpacityKey.SetValue("dockHoverOpacity", HoverOpacityBar.Value, RegistryValueKind.DWord)
        Me.Close()
    End Sub

    Private Sub DockOpacity_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dockOpacityKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        dockOpacity = CDbl(dockOpacityKey.GetValue("dockOpacity", Nothing))
        dockHoverOpacity = CDbl(dockOpacityKey.GetValue("dockHoverOpacity", Nothing))

        If dockOpacity = 0 Then
            NormalOpacityBar.Value = 100
        Else
            NormalOpacityBar.Value = CInt(dockOpacity)
        End If

        If dockHoverOpacity = 0 Then
            HoverOpacityBar.Value = 100
        Else
            HoverOpacityBar.Value = CInt(dockHoverOpacity)
        End If

        NormalOpacityLabel.Text = CStr(NormalOpacityBar.Value)
        HoverOpacityLabel.Text = CStr(HoverOpacityBar.Value)
    End Sub
End Class