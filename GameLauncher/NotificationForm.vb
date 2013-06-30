Imports System.Net
Imports System.IO

Public Class NotificationForm
    Private isDrawn As Boolean = False
    Private strNewVersion As String = Nothing

    Public Property newVersion As String
        Get
            Return strNewVersion
        End Get
        Set(value As String)
            strNewVersion = value
        End Set
    End Property

    Private Sub NotificationForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Left = My.Computer.Screen.WorkingArea.Right - Me.Width
        Me.Top = My.Computer.Screen.WorkingArea.Bottom - Me.Height

        btnYes.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormOKButton") ' Sneaky reusing of translations!
        btnNo.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AddNewGameFormCancelButton")
    End Sub

    Private Sub NotificationForm_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If e.Location.X >= 280 And e.Location.X <= 297 And e.Location.Y >= 5 And e.Location.Y <= 22 Then
            stopCheckingForUpdates()
        End If
    End Sub

    Private Sub NotificationForm_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If e.Location.X >= 280 And e.Location.X <= 297 And e.Location.Y >= 5 And e.Location.Y <= 22 Then
            Me.Cursor = Cursors.Hand
        Else
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub stopCheckingForUpdates()
        Me.Dispose()
    End Sub

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        If isDrawn Then
            MyBase.OnPaint(e)
        Else
            Dim formGraphics As System.Drawing.Graphics = Me.CreateGraphics()
            formGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            Dim drawString As String = "Game Launcher"
            Dim drawFont As New System.Drawing.Font("Verdana", 14)
            Dim drawBrush As New System.Drawing.SolidBrush(System.Drawing.Color.Black)
            Dim x As Single = 5
            Dim y As Single = 30
            Dim drawArea As New RectangleF(5, 55, 290, 88)
            Dim drawFormat As New System.Drawing.StringFormat
            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat)

            drawFont = New System.Drawing.Font("Verdana", 9)
            drawString = String.Format(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("MainFormNewVersionAvailable1"), Me.newVersion)
            formGraphics.DrawString(drawString, drawFont, drawBrush, drawArea, drawFormat)

            drawFont.Dispose()
            drawBrush.Dispose()
            formGraphics.Dispose()

            isDrawn = True
        End If

    End Sub

    Private Sub btnNo_Click(sender As System.Object, e As System.EventArgs) Handles btnNo.Click
        stopCheckingForUpdates()
    End Sub

    Private Sub btnYes_Click(sender As System.Object, e As System.EventArgs) Handles btnYes.Click
        'Yes clicked
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

        Dim response As DialogResult = MessageBox.Show(changeLog & vbNewLine & vbNewLine & MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("AboutFormNewVersion2"), _
                                                       "Game Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If response = Windows.Forms.DialogResult.Yes Then
            System.Diagnostics.Process.Start("http://gamelauncher.pvpsucks.com/?q=dl")
            End
        End If
        Me.Dispose()
    End Sub
End Class