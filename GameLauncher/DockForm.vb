Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.Windows.Forms

Public Class DockForm
    Inherits Form

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            If Not Me.DesignMode Then cp.ExStyle = cp.ExStyle Or &H80
            Return cp
        End Get
    End Property

    Protected NormalOpacityVar As Double = 1

    Protected HoverOpacityVar As Double = 1
    Public Property NormalOpacity As Double
        Get
            Return NormalOpacityVar
        End Get
        Set(value As Double)
            NormalOpacityVar = value
        End Set
    End Property

    Public Property HoverOpacity As Double
        Get
            Return HoverOpacityVar
        End Get
        Set(value As Double)
            HoverOpacityVar = value
        End Set
    End Property

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RegisterBar()

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Height = My.Computer.Screen.WorkingArea.Height
        Me.Width += 2

        Dim dockOpacityKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim savedOpacity As Integer = CInt(dockOpacityKey.GetValue("dockOpacity", Nothing))
        If savedOpacity = 0 Then
            'Value doesn't exist, create it
            dockOpacityKey.SetValue("dockOpacity", 100, RegistryValueKind.DWord)
        Else
            'Value exists, use it
            Me.NormalOpacity = savedOpacity / 100
            Me.Opacity = Me.NormalOpacity
        End If

        Dim savedHoverOpacity As Integer = CInt(dockOpacityKey.GetValue("dockHoverOpacity", Nothing))
        If savedHoverOpacity = 0 Then
            'Value doesn't exist, create it
            dockOpacityKey.SetValue("dockHoverOpacity", 100, RegistryValueKind.DWord)
        Else
            'Value exists, use it
            Me.HoverOpacity = savedHoverOpacity / 100
        End If

        Dim dockTopMostKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Dim savedValue As Integer = CInt(dockTopMostKey.GetValue("dockTopMost", Nothing))
        If savedValue = 0 Then
            Me.TopMost = False
            AlwaysOnTopToolStripMenuItem.Checked = False
        Else
            Me.TopMost = True
            AlwaysOnTopToolStripMenuItem.Checked = True
        End If
    End Sub
    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        RegisterBar()
    End Sub

#Region "AppBar"
    <StructLayout(LayoutKind.Sequential)> Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure
    <StructLayout(LayoutKind.Sequential)> Structure APPBARDATA
        Public cbSize As Integer
        Public hWnd As IntPtr
        Public uCallbackMessage As Integer
        Public uEdge As Integer
        Public rc As RECT
        Public lParam As IntPtr
    End Structure
    Enum ABMsg
        ABM_NEW = 0
        ABM_REMOVE = 1
        ABM_QUERYPOS = 2
        ABM_SETPOS = 3
        ABM_GETSTATE = 4
        ABM_GETTASKBARPOS = 5
        ABM_ACTIVATE = 6
        ABM_GETAUTOHIDEBAR = 7
        ABM_SETAUTOHIDEBAR = 8
        ABM_WINDOWPOSCHANGED = 9
        ABM_SETSTATE = 10
    End Enum
    Enum ABNotify
        ABN_STATECHANGE = 0
        ABN_POSCHANGED
        ABN_FULLSCREENAPP
        ABN_WINDOWARRANGE
    End Enum
    Enum ABEdge
        ABE_LEFT = 0
        ABE_TOP
        ABE_RIGHT
        ABE_BOTTOM
    End Enum
    Private fBarRegistered As Boolean = False
    <DllImport("SHELL32", CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function SHAppBarMessage(ByVal dwMessage As Integer, ByRef BarrData As APPBARDATA) As Integer
    End Function
    <DllImport("USER32")> _
    Public Shared Function GetSystemmetric(ByVal Index As Integer) As Integer
    End Function
    <DllImport("User32.dll", ExactSpelling:=True, CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Public Shared Function MoveWindow(ByVal hWnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal cX As Integer, ByVal cY As Integer, ByVal repaint As Boolean) As Boolean
    End Function
    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function RegisterWindowMessage(ByVal msg As String) As Integer
    End Function
    Private uCallBack As Integer

    Private Sub RegisterBar()
        Dim abd As New APPBARDATA
        Dim ret As Integer
        abd.cbSize = Marshal.SizeOf(abd)
        abd.hWnd = Me.Handle
        If Not fBarRegistered Then
            uCallBack = RegisterWindowMessage("AppBarMessage")
            abd.uCallbackMessage = uCallBack

            ret = SHAppBarMessage(ABMsg.ABM_NEW, abd)
            fBarRegistered = True

            ABSetPos()
        Else
            ret = SHAppBarMessage(ABMsg.ABM_REMOVE, abd)
            fBarRegistered = False
        End If
    End Sub

    Private Sub ABSetPos()
        Dim abd As New APPBARDATA
        abd.cbSize = Marshal.SizeOf(abd)
        abd.hWnd = Me.Handle
        abd.uEdge = ABEdge.ABE_TOP

        'If abd.uEdge = ABEdge.ABE_LEFT OrElse abd.uEdge = ABEdge.ABE_RIGHT Then
        '    abd.rc.top = 0
        '    abd.rc.bottom = SystemInformation.PrimaryMonitorSize.Height
        '    If abd.uEdge = ABEdge.ABE_LEFT Then
        '        abd.rc.left = 0
        '        abd.rc.right = Size.Width
        '    Else
        '        abd.rc.right = SystemInformation.PrimaryMonitorSize.Width
        '        abd.rc.left = abd.rc.right - Size.Width
        '    End If
        'Else
        '    abd.rc.left = 0
        '    abd.rc.right = SystemInformation.PrimaryMonitorSize.Width
        '    If abd.uEdge = ABEdge.ABE_TOP Then
        '        abd.rc.top = 0
        '        abd.rc.bottom = Size.Height
        '    Else
        '        abd.rc.bottom = SystemInformation.PrimaryMonitorSize.Height
        '        abd.rc.top = abd.rc.bottom - Size.Height
        '    End If
        'End If

        abd.rc.top = 0
        abd.rc.left = 0
        abd.rc.bottom = My.Computer.Screen.WorkingArea.Height
        abd.rc.right = Me.Width
        abd.uEdge = ABEdge.ABE_LEFT

        'Query the system for an approved size and position.
        SHAppBarMessage(ABMsg.ABM_QUERYPOS, abd)

        'Adjust the rectangle, depending on the edge to which the appbar is anchored.
        Select Case abd.uEdge
            Case ABEdge.ABE_LEFT
                abd.rc.right = abd.rc.left + Size.Width
            Case ABEdge.ABE_RIGHT
                abd.rc.left = abd.rc.right - Size.Width
            Case ABEdge.ABE_TOP
                abd.rc.bottom = abd.rc.top + Size.Height
            Case ABEdge.ABE_BOTTOM
                abd.rc.top = abd.rc.bottom - Size.Height
        End Select

        'Pass the final bounding rectangle to the system.
        SHAppBarMessage(ABMsg.ABM_SETPOS, abd)

        'Move and size the appbar so that it conforms to the  bounding rectangle passed to the system.
        MoveWindow(abd.hWnd, abd.rc.left, abd.rc.top, abd.rc.right - abd.rc.left, abd.rc.bottom - abd.rc.top, True)
    End Sub

#End Region

    Private Sub ToolStrip1_MouseEnter(sender As Object, e As System.EventArgs) Handles ToolStrip1.MouseEnter
        Me.Focus()
    End Sub

    Private Sub CloseTheDockToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CloseTheDockToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ChangeOpacityToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChangeOpacityToolStripMenuItem.Click
        Dim newDockOpacityForm As New DockOpacity
        newDockOpacityForm.ShowDialog(Me)

        Dim dockOpacityKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        Me.NormalOpacity = CInt(dockOpacityKey.GetValue("dockOpacity", Nothing)) / 100
        Me.HoverOpacity = CInt(dockOpacityKey.GetValue("dockHoverOpacity", Nothing)) / 100
        Me.Opacity = Me.NormalOpacity
    End Sub

    Private Sub DockForm_MouseEnter(sender As Object, e As System.EventArgs) Handles ToolStrip1.MouseEnter
        Me.Opacity = Me.HoverOpacity
    End Sub

    Private Sub DockForm_MouseLeave(sender As Object, e As System.EventArgs) Handles ToolStrip1.MouseLeave
        Me.Opacity = NormalOpacity
    End Sub

    Private Sub AlwaysOnTopToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AlwaysOnTopToolStripMenuItem.Click
        Dim dockTopMostKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\GameLauncher", RegistryKeyPermissionCheck.ReadWriteSubTree)
        dockTopMostKey.SetValue("dockTopMost", 1, RegistryValueKind.DWord)

        If AlwaysOnTopToolStripMenuItem.Checked Then
            AlwaysOnTopToolStripMenuItem.Checked = False
            Me.TopMost = False
            dockTopMostKey.SetValue("dockTopMost", 0, RegistryValueKind.DWord)
        Else
            AlwaysOnTopToolStripMenuItem.Checked = True
            Me.TopMost = True
            dockTopMostKey.SetValue("dockTopMost", 1, RegistryValueKind.DWord)
        End If
    End Sub

End Class


