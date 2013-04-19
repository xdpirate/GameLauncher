Imports System.IO

Public Class DragDropTargetForm

    Public Files() As String
    Dim dropColor As Color = Color.FromArgb(0, 192, 0)

    Private Sub DragDropTargetForm_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Files = CType(e.Data.GetData(DataFormats.FileDrop), String())
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub DragDropTargetForm_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
            Me.BackColor = dropColor
        End If
    End Sub

    Private Sub DragDropTargetForm_DragLeave(sender As Object, e As System.EventArgs) Handles Me.DragLeave
        Me.BackColor = Color.Maroon
    End Sub

    Private Sub DragDropTargetForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim workingAreaWidth As Integer = My.Computer.Screen.WorkingArea.Width
        Dim workingAreaHeight As Integer = My.Computer.Screen.WorkingArea.Height

        With Me
            .Top = (workingAreaHeight - Me.Height) - 5
            .Left = (workingAreaWidth - Me.Width) - 5
            .BackColor = Color.Maroon
        End With
    End Sub

    Private Sub DragDropTargetForm_MouseLeave(sender As Object, e As System.EventArgs) Handles Me.MouseLeave
        Me.BackColor = Color.Maroon
    End Sub

    Private Sub DragDropTargetForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("DragDropTargetFormTitleBar")
    End Sub
End Class