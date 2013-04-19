Public Class RemoveForm

    Private Sub buttonCancel_Click(sender As System.Object, e As System.EventArgs) Handles buttonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub buttonOK_Click(sender As System.Object, e As System.EventArgs) Handles buttonOK.Click
        If ListBox1.SelectedItems.Count < 1 Then
            MessageBox.Show(MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("RemoveFormNoItemsSelected"), My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Else
            Dim items As String = Nothing
            For Each element In ListBox1.SelectedItems
                items &= element & vbNewLine
            Next

            Dim response As DialogResult = MessageBox.Show("Are you sure you want to remove the selected item(s)?" & vbNewLine & vbNewLine & items, _
                                                           My.Application.Info.AssemblyName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)

            If response = Windows.Forms.DialogResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    Private Sub RemoveForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Multi-language stuff
        Me.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("RemoveFormTitleBar")
        FlavorTextLabel.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("RemoveFormFlavorTextLabel")
        buttonOK.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("RemoveFormRemoveItemsButton")
        buttonCancel.Text = MainForm.CURRENT_LANGUAGE_RESOURCE.GetString("RemoveFormCancelButton")
    End Sub
End Class