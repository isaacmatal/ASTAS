<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomCalendar
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomCalendar))
        Me.lblDias = New System.Windows.Forms.Label
        Me.cmbYear = New System.Windows.Forms.ComboBox
        Me.cmbMonth = New System.Windows.Forms.ComboBox
        Me.pbxInfo = New System.Windows.Forms.PictureBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.pbxInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDias
        '
        Me.lblDias.AutoSize = True
        Me.lblDias.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDias.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDias.Location = New System.Drawing.Point(13, 44)
        Me.lblDias.Name = "lblDias"
        Me.lblDias.Size = New System.Drawing.Size(185, 16)
        Me.lblDias.TabIndex = 8
        Me.lblDias.Text = "Dom Lun Mar Miè Jue Vie Sab"
        '
        'cmbYear
        '
        Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Items.AddRange(New Object() {"2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030"})
        Me.cmbYear.Location = New System.Drawing.Point(156, 5)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(50, 21)
        Me.cmbYear.TabIndex = 9
        '
        'cmbMonth
        '
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cmbMonth.Location = New System.Drawing.Point(11, 5)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(144, 21)
        Me.cmbMonth.TabIndex = 9
        '
        'pbxInfo
        '
        Me.pbxInfo.Image = CType(resources.GetObject("pbxInfo.Image"), System.Drawing.Image)
        Me.pbxInfo.Location = New System.Drawing.Point(192, 164)
        Me.pbxInfo.Name = "pbxInfo"
        Me.pbxInfo.Size = New System.Drawing.Size(18, 16)
        Me.pbxInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxInfo.TabIndex = 10
        Me.pbxInfo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbxInfo, resources.GetString("pbxInfo.ToolTip"))
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 25000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Calendario"
        '
        'CustomCalendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.pbxInfo)
        Me.Controls.Add(Me.cmbMonth)
        Me.Controls.Add(Me.lblDias)
        Me.Controls.Add(Me.cmbYear)
        Me.DoubleBuffered = True
        Me.Name = "CustomCalendar"
        Me.Size = New System.Drawing.Size(215, 198)
        CType(Me.pbxInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDias As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents pbxInfo As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
