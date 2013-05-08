<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PieChartForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PieChartForm))
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.saveAsImageButton = New System.Windows.Forms.Button()
        Me.pieCloseButton = New System.Windows.Forms.Button()
        Me.labelPicker = New System.Windows.Forms.ComboBox()
        Me.legendToggleCheckBox = New System.Windows.Forms.CheckBox()
        Me.palettePicker = New System.Windows.Forms.ComboBox()
        Me.clearDataLink = New System.Windows.Forms.LinkLabel()
        Me.generateChartButton = New System.Windows.Forms.Button()
        Me.sortingComboBox = New System.Windows.Forms.ComboBox()
        Me.enable3DCheckBox = New System.Windows.Forms.CheckBox()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(784, 495)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Playing time chart"
        '
        'saveAsImageButton
        '
        Me.saveAsImageButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.saveAsImageButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.saveAsImageButton.Location = New System.Drawing.Point(12, 501)
        Me.saveAsImageButton.Name = "saveAsImageButton"
        Me.saveAsImageButton.Size = New System.Drawing.Size(224, 23)
        Me.saveAsImageButton.TabIndex = 2
        Me.saveAsImageButton.Text = "&Save as image..."
        Me.saveAsImageButton.UseVisualStyleBackColor = True
        '
        'pieCloseButton
        '
        Me.pieCloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pieCloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.pieCloseButton.Location = New System.Drawing.Point(697, 527)
        Me.pieCloseButton.Name = "pieCloseButton"
        Me.pieCloseButton.Size = New System.Drawing.Size(75, 23)
        Me.pieCloseButton.TabIndex = 1
        Me.pieCloseButton.Text = "&Close"
        Me.pieCloseButton.UseVisualStyleBackColor = True
        '
        'labelPicker
        '
        Me.labelPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.labelPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.labelPicker.FormattingEnabled = True
        Me.labelPicker.Location = New System.Drawing.Point(242, 503)
        Me.labelPicker.Name = "labelPicker"
        Me.labelPicker.Size = New System.Drawing.Size(175, 21)
        Me.labelPicker.TabIndex = 3
        '
        'legendToggleCheckBox
        '
        Me.legendToggleCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.legendToggleCheckBox.AutoSize = True
        Me.legendToggleCheckBox.Checked = True
        Me.legendToggleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.legendToggleCheckBox.Location = New System.Drawing.Point(423, 534)
        Me.legendToggleCheckBox.Name = "legendToggleCheckBox"
        Me.legendToggleCheckBox.Size = New System.Drawing.Size(88, 17)
        Me.legendToggleCheckBox.TabIndex = 4
        Me.legendToggleCheckBox.Text = "Show legend"
        Me.legendToggleCheckBox.UseVisualStyleBackColor = True
        '
        'palettePicker
        '
        Me.palettePicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.palettePicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.palettePicker.FormattingEnabled = True
        Me.palettePicker.Items.AddRange(New Object() {"Berry", "Bright Pastel", "Bright", "Cake", "Chocolate", "Earth Tones", "Excel", "Fire", "Goldfish", "Grayscale", "Light", "Pastel", "Sea Green"})
        Me.palettePicker.Location = New System.Drawing.Point(242, 532)
        Me.palettePicker.Name = "palettePicker"
        Me.palettePicker.Size = New System.Drawing.Size(175, 21)
        Me.palettePicker.TabIndex = 5
        '
        'clearDataLink
        '
        Me.clearDataLink.AutoSize = True
        Me.clearDataLink.BackColor = System.Drawing.Color.Transparent
        Me.clearDataLink.Location = New System.Drawing.Point(12, 9)
        Me.clearDataLink.Name = "clearDataLink"
        Me.clearDataLink.Size = New System.Drawing.Size(64, 13)
        Me.clearDataLink.TabIndex = 6
        Me.clearDataLink.TabStop = True
        Me.clearDataLink.Text = "Clear data..."
        Me.clearDataLink.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'generateChartButton
        '
        Me.generateChartButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.generateChartButton.Location = New System.Drawing.Point(12, 530)
        Me.generateChartButton.Name = "generateChartButton"
        Me.generateChartButton.Size = New System.Drawing.Size(224, 23)
        Me.generateChartButton.TabIndex = 7
        Me.generateChartButton.Text = "&Generate linkable chart"
        Me.generateChartButton.UseVisualStyleBackColor = True
        '
        'sortingComboBox
        '
        Me.sortingComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sortingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sortingComboBox.FormattingEnabled = True
        Me.sortingComboBox.Location = New System.Drawing.Point(423, 503)
        Me.sortingComboBox.Name = "sortingComboBox"
        Me.sortingComboBox.Size = New System.Drawing.Size(175, 21)
        Me.sortingComboBox.TabIndex = 8
        '
        'enable3DCheckBox
        '
        Me.enable3DCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.enable3DCheckBox.AutoSize = True
        Me.enable3DCheckBox.Checked = True
        Me.enable3DCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.enable3DCheckBox.Location = New System.Drawing.Point(604, 505)
        Me.enable3DCheckBox.Name = "enable3DCheckBox"
        Me.enable3DCheckBox.Size = New System.Drawing.Size(40, 17)
        Me.enable3DCheckBox.TabIndex = 9
        Me.enable3DCheckBox.Text = "3D"
        Me.enable3DCheckBox.UseVisualStyleBackColor = True
        '
        'PieChartForm
        '
        Me.AcceptButton = Me.pieCloseButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.pieCloseButton
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.enable3DCheckBox)
        Me.Controls.Add(Me.sortingComboBox)
        Me.Controls.Add(Me.generateChartButton)
        Me.Controls.Add(Me.clearDataLink)
        Me.Controls.Add(Me.palettePicker)
        Me.Controls.Add(Me.legendToggleCheckBox)
        Me.Controls.Add(Me.labelPicker)
        Me.Controls.Add(Me.pieCloseButton)
        Me.Controls.Add(Me.saveAsImageButton)
        Me.Controls.Add(Me.Chart1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "PieChartForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game Launcher Playtime Statistics"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents saveAsImageButton As System.Windows.Forms.Button
    Friend WithEvents pieCloseButton As System.Windows.Forms.Button
    Friend WithEvents labelPicker As System.Windows.Forms.ComboBox
    Friend WithEvents legendToggleCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents palettePicker As System.Windows.Forms.ComboBox
    Friend WithEvents clearDataLink As System.Windows.Forms.LinkLabel
    Friend WithEvents generateChartButton As System.Windows.Forms.Button
    Friend WithEvents sortingComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents enable3DCheckBox As System.Windows.Forms.CheckBox
End Class
