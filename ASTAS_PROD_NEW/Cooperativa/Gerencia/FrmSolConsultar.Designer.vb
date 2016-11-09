<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolConsultar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolConsultar))
        Me.DgvSolicitudes = New System.Windows.Forms.DataGridView
        Me.GbxCriterioBusq = New System.Windows.Forms.GroupBox
        Me.ChkBox2 = New System.Windows.Forms.CheckBox
        Me.TxtNumSol = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.ChkBox4 = New System.Windows.Forms.CheckBox
        Me.ChkBox3 = New System.Windows.Forms.CheckBox
        Me.ChkBox1 = New System.Windows.Forms.CheckBox
        Me.DpFechaFin = New System.Windows.Forms.DateTimePicker
        Me.DpFechaIni = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.CbxCompania = New System.Windows.Forms.ComboBox
        Me.CbxTipoSolicitudes = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.BtnImprimir = New System.Windows.Forms.Button
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxCriterioBusq.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvSolicitudes
        '
        Me.DgvSolicitudes.AllowUserToAddRows = False
        Me.DgvSolicitudes.AllowUserToDeleteRows = False
        Me.DgvSolicitudes.AllowUserToResizeColumns = False
        Me.DgvSolicitudes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.DgvSolicitudes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvSolicitudes.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSolicitudes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSolicitudes.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvSolicitudes.Location = New System.Drawing.Point(7, 106)
        Me.DgvSolicitudes.MultiSelect = False
        Me.DgvSolicitudes.Name = "DgvSolicitudes"
        Me.DgvSolicitudes.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSolicitudes.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSolicitudes.Size = New System.Drawing.Size(936, 409)
        Me.DgvSolicitudes.TabIndex = 31
        '
        'GbxCriterioBusq
        '
        Me.GbxCriterioBusq.BackColor = System.Drawing.Color.Transparent
        Me.GbxCriterioBusq.Controls.Add(Me.ChkBox2)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtNumSol)
        Me.GbxCriterioBusq.Controls.Add(Me.Label14)
        Me.GbxCriterioBusq.Controls.Add(Me.ChkBox4)
        Me.GbxCriterioBusq.Controls.Add(Me.ChkBox3)
        Me.GbxCriterioBusq.Controls.Add(Me.ChkBox1)
        Me.GbxCriterioBusq.Controls.Add(Me.DpFechaFin)
        Me.GbxCriterioBusq.Controls.Add(Me.DpFechaIni)
        Me.GbxCriterioBusq.Controls.Add(Me.Label1)
        Me.GbxCriterioBusq.Controls.Add(Me.CbxCompania)
        Me.GbxCriterioBusq.Controls.Add(Me.CbxTipoSolicitudes)
        Me.GbxCriterioBusq.Controls.Add(Me.Label3)
        Me.GbxCriterioBusq.Controls.Add(Me.Label12)
        Me.GbxCriterioBusq.Controls.Add(Me.Label2)
        Me.GbxCriterioBusq.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCriterioBusq.ForeColor = System.Drawing.Color.Navy
        Me.GbxCriterioBusq.Location = New System.Drawing.Point(7, 7)
        Me.GbxCriterioBusq.Name = "GbxCriterioBusq"
        Me.GbxCriterioBusq.Size = New System.Drawing.Size(842, 88)
        Me.GbxCriterioBusq.TabIndex = 30
        Me.GbxCriterioBusq.TabStop = False
        Me.GbxCriterioBusq.Text = "Consultar Solicitudes"
        '
        'ChkBox2
        '
        Me.ChkBox2.AutoSize = True
        Me.ChkBox2.Location = New System.Drawing.Point(739, 27)
        Me.ChkBox2.Name = "ChkBox2"
        Me.ChkBox2.Size = New System.Drawing.Size(91, 20)
        Me.ChkBox2.TabIndex = 32
        Me.ChkBox2.Text = "Denegadas"
        Me.ChkBox2.UseVisualStyleBackColor = True
        '
        'TxtNumSol
        '
        Me.TxtNumSol.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtNumSol.ForeColor = System.Drawing.Color.Navy
        Me.TxtNumSol.Location = New System.Drawing.Point(487, 48)
        Me.TxtNumSol.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNumSol.Name = "TxtNumSol"
        Me.TxtNumSol.Size = New System.Drawing.Size(80, 22)
        Me.TxtNumSol.TabIndex = 3
        Me.TxtNumSol.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(424, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 16)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "N° Solicitud:"
        Me.Label14.Visible = False
        '
        'ChkBox4
        '
        Me.ChkBox4.AutoSize = True
        Me.ChkBox4.Checked = True
        Me.ChkBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBox4.Location = New System.Drawing.Point(739, 65)
        Me.ChkBox4.Name = "ChkBox4"
        Me.ChkBox4.Size = New System.Drawing.Size(62, 20)
        Me.ChkBox4.TabIndex = 31
        Me.ChkBox4.Text = "Todas"
        Me.ChkBox4.UseVisualStyleBackColor = True
        '
        'ChkBox3
        '
        Me.ChkBox3.AutoSize = True
        Me.ChkBox3.Location = New System.Drawing.Point(739, 46)
        Me.ChkBox3.Name = "ChkBox3"
        Me.ChkBox3.Size = New System.Drawing.Size(79, 20)
        Me.ChkBox3.TabIndex = 30
        Me.ChkBox3.Text = "Anuladas"
        Me.ChkBox3.UseVisualStyleBackColor = True
        '
        'ChkBox1
        '
        Me.ChkBox1.AutoSize = True
        Me.ChkBox1.Location = New System.Drawing.Point(739, 9)
        Me.ChkBox1.Name = "ChkBox1"
        Me.ChkBox1.Size = New System.Drawing.Size(88, 20)
        Me.ChkBox1.TabIndex = 29
        Me.ChkBox1.Text = "Aprobadas"
        Me.ChkBox1.UseVisualStyleBackColor = True
        '
        'DpFechaFin
        '
        Me.DpFechaFin.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaFin.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaFin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaFin.Location = New System.Drawing.Point(616, 49)
        Me.DpFechaFin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DpFechaFin.Name = "DpFechaFin"
        Me.DpFechaFin.Size = New System.Drawing.Size(112, 22)
        Me.DpFechaFin.TabIndex = 27
        '
        'DpFechaIni
        '
        Me.DpFechaIni.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaIni.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaIni.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaIni.Location = New System.Drawing.Point(616, 23)
        Me.DpFechaIni.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DpFechaIni.Name = "DpFechaIni"
        Me.DpFechaIni.Size = New System.Drawing.Size(112, 22)
        Me.DpFechaIni.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(576, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 16)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Hasta:"
        '
        'CbxCompania
        '
        Me.CbxCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCompania.Enabled = False
        Me.CbxCompania.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CbxCompania.ForeColor = System.Drawing.Color.Navy
        Me.CbxCompania.FormattingEnabled = True
        Me.CbxCompania.Location = New System.Drawing.Point(96, 21)
        Me.CbxCompania.Name = "CbxCompania"
        Me.CbxCompania.Size = New System.Drawing.Size(471, 24)
        Me.CbxCompania.TabIndex = 21
        '
        'CbxTipoSolicitudes
        '
        Me.CbxTipoSolicitudes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoSolicitudes.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CbxTipoSolicitudes.ForeColor = System.Drawing.Color.Navy
        Me.CbxTipoSolicitudes.FormattingEnabled = True
        Me.CbxTipoSolicitudes.Location = New System.Drawing.Point(96, 47)
        Me.CbxTipoSolicitudes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxTipoSolicitudes.Name = "CbxTipoSolicitudes"
        Me.CbxTipoSolicitudes.Size = New System.Drawing.Size(315, 24)
        Me.CbxTipoSolicitudes.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Compañia:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(8, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Tipo de Solicitud:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(576, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Desde:"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.Transparent
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(863, 12)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(72, 33)
        Me.BtnBuscar.TabIndex = 25
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.BackColor = System.Drawing.Color.Transparent
        Me.BtnImprimir.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnImprimir.ForeColor = System.Drawing.Color.Black
        Me.BtnImprimir.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImprimir.Location = New System.Drawing.Point(863, 50)
        Me.BtnImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(72, 33)
        Me.BtnImprimir.TabIndex = 32
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'FrmSolConsultar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(951, 526)
        Me.Controls.Add(Me.BtnImprimir)
        Me.Controls.Add(Me.DgvSolicitudes)
        Me.Controls.Add(Me.GbxCriterioBusq)
        Me.Controls.Add(Me.BtnBuscar)
        Me.Name = "FrmSolConsultar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Estado de Solicitudes"
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxCriterioBusq.ResumeLayout(False)
        Me.GbxCriterioBusq.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvSolicitudes As System.Windows.Forms.DataGridView
    Friend WithEvents GbxCriterioBusq As System.Windows.Forms.GroupBox
    Friend WithEvents DpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CbxCompania As System.Windows.Forms.ComboBox
    Friend WithEvents CbxTipoSolicitudes As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNumSol As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents ChkBox2 As System.Windows.Forms.CheckBox
End Class
