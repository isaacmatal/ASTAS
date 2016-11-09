<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIlustrativoProgramacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIlustrativoProgramacion))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label8 = New System.Windows.Forms.Label
        Me.CbxDeduccion = New System.Windows.Forms.ComboBox
        Me.DgvProgramacion = New System.Windows.Forms.DataGridView
        Me.TxtMonto = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GbxPrograDesc = New System.Windows.Forms.GroupBox
        Me.DtpFechaPrimerPag = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtCuotasMax = New System.Windows.Forms.TextBox
        Me.LblSegDeuda = New System.Windows.Forms.Label
        Me.LblInteres = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.TxtCuota = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.DtpFechaIniPres = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.CbxPeriodo = New System.Windows.Forms.ComboBox
        Me.BtnCalcular = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.NudNumeroCuot = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpNormales = New System.Windows.Forms.TabPage
        Me.tpEspeciales = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtTotalCuotasEspeciales = New System.Windows.Forms.TextBox
        Me.BtnEliminar = New System.Windows.Forms.Button
        Me.BtnAgregar = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtCuotaEspecial = New System.Windows.Forms.TextBox
        Me.CbxPeriodoEspeciales = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.DtpFechaPago = New System.Windows.Forms.DateTimePicker
        Me.Label24 = New System.Windows.Forms.Label
        Me.DgvProgramacionesEspeciales = New System.Windows.Forms.DataGridView
        CType(Me.DgvProgramacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxPrograDesc.SuspendLayout()
        CType(Me.NudNumeroCuot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpNormales.SuspendLayout()
        Me.tpEspeciales.SuspendLayout()
        CType(Me.DgvProgramacionesEspeciales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(341, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Interes:"
        '
        'CbxDeduccion
        '
        Me.CbxDeduccion.BackColor = System.Drawing.SystemColors.Window
        Me.CbxDeduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxDeduccion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxDeduccion.ForeColor = System.Drawing.Color.Navy
        Me.CbxDeduccion.FormattingEnabled = True
        Me.CbxDeduccion.Location = New System.Drawing.Point(97, 25)
        Me.CbxDeduccion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxDeduccion.Name = "CbxDeduccion"
        Me.CbxDeduccion.Size = New System.Drawing.Size(240, 24)
        Me.CbxDeduccion.TabIndex = 3
        '
        'DgvProgramacion
        '
        Me.DgvProgramacion.AllowUserToAddRows = False
        Me.DgvProgramacion.AllowUserToDeleteRows = False
        Me.DgvProgramacion.AllowUserToResizeColumns = False
        Me.DgvProgramacion.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvProgramacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvProgramacion.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvProgramacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvProgramacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvProgramacion.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvProgramacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvProgramacion.Location = New System.Drawing.Point(3, 3)
        Me.DgvProgramacion.MultiSelect = False
        Me.DgvProgramacion.Name = "DgvProgramacion"
        Me.DgvProgramacion.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvProgramacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvProgramacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProgramacion.Size = New System.Drawing.Size(781, 423)
        Me.DgvProgramacion.TabIndex = 10
        '
        'TxtMonto
        '
        Me.TxtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonto.ForeColor = System.Drawing.Color.Navy
        Me.TxtMonto.Location = New System.Drawing.Point(97, 120)
        Me.TxtMonto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(78, 20)
        Me.TxtMonto.TabIndex = 6
        Me.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(341, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Primer Pago:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo Solicitud:"
        '
        'GbxPrograDesc
        '
        Me.GbxPrograDesc.BackColor = System.Drawing.Color.Transparent
        Me.GbxPrograDesc.Controls.Add(Me.DtpFechaPrimerPag)
        Me.GbxPrograDesc.Controls.Add(Me.Label13)
        Me.GbxPrograDesc.Controls.Add(Me.Label12)
        Me.GbxPrograDesc.Controls.Add(Me.Label11)
        Me.GbxPrograDesc.Controls.Add(Me.TxtCuotasMax)
        Me.GbxPrograDesc.Controls.Add(Me.LblSegDeuda)
        Me.GbxPrograDesc.Controls.Add(Me.LblInteres)
        Me.GbxPrograDesc.Controls.Add(Me.Label10)
        Me.GbxPrograDesc.Controls.Add(Me.btnImprimir)
        Me.GbxPrograDesc.Controls.Add(Me.TxtCuota)
        Me.GbxPrograDesc.Controls.Add(Me.Label9)
        Me.GbxPrograDesc.Controls.Add(Me.BtnNuevo)
        Me.GbxPrograDesc.Controls.Add(Me.DtpFechaIniPres)
        Me.GbxPrograDesc.Controls.Add(Me.Label6)
        Me.GbxPrograDesc.Controls.Add(Me.CbxPeriodo)
        Me.GbxPrograDesc.Controls.Add(Me.BtnCalcular)
        Me.GbxPrograDesc.Controls.Add(Me.Label2)
        Me.GbxPrograDesc.Controls.Add(Me.Label8)
        Me.GbxPrograDesc.Controls.Add(Me.CbxDeduccion)
        Me.GbxPrograDesc.Controls.Add(Me.TxtMonto)
        Me.GbxPrograDesc.Controls.Add(Me.Label4)
        Me.GbxPrograDesc.Controls.Add(Me.Label1)
        Me.GbxPrograDesc.Controls.Add(Me.Label7)
        Me.GbxPrograDesc.Controls.Add(Me.NudNumeroCuot)
        Me.GbxPrograDesc.Controls.Add(Me.Label5)
        Me.GbxPrograDesc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxPrograDesc.ForeColor = System.Drawing.Color.Navy
        Me.GbxPrograDesc.Location = New System.Drawing.Point(8, 8)
        Me.GbxPrograDesc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxPrograDesc.Name = "GbxPrograDesc"
        Me.GbxPrograDesc.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxPrograDesc.Size = New System.Drawing.Size(720, 151)
        Me.GbxPrograDesc.TabIndex = 5
        Me.GbxPrograDesc.TabStop = False
        Me.GbxPrograDesc.Text = "Programación de Descuentos"
        '
        'DtpFechaPrimerPag
        '
        Me.DtpFechaPrimerPag.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaPrimerPag.Location = New System.Drawing.Point(421, 89)
        Me.DtpFechaPrimerPag.Name = "DtpFechaPrimerPag"
        Me.DtpFechaPrimerPag.Size = New System.Drawing.Size(200, 22)
        Me.DtpFechaPrimerPag.TabIndex = 118
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(615, 122)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(19, 16)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "%"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(469, 121)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(19, 16)
        Me.Label12.TabIndex = 116
        Me.Label12.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(210, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 16)
        Me.Label11.TabIndex = 115
        Me.Label11.Text = "Cuotas Máx:"
        '
        'TxtCuotasMax
        '
        Me.TxtCuotasMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuotasMax.ForeColor = System.Drawing.Color.Navy
        Me.TxtCuotasMax.Location = New System.Drawing.Point(280, 58)
        Me.TxtCuotasMax.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCuotasMax.Name = "TxtCuotasMax"
        Me.TxtCuotasMax.ReadOnly = True
        Me.TxtCuotasMax.Size = New System.Drawing.Size(56, 20)
        Me.TxtCuotasMax.TabIndex = 114
        Me.TxtCuotasMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblSegDeuda
        '
        Me.LblSegDeuda.BackColor = System.Drawing.SystemColors.Window
        Me.LblSegDeuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSegDeuda.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSegDeuda.Location = New System.Drawing.Point(566, 120)
        Me.LblSegDeuda.Name = "LblSegDeuda"
        Me.LblSegDeuda.Size = New System.Drawing.Size(49, 20)
        Me.LblSegDeuda.TabIndex = 113
        Me.LblSegDeuda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblInteres
        '
        Me.LblInteres.BackColor = System.Drawing.SystemColors.Window
        Me.LblInteres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblInteres.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInteres.Location = New System.Drawing.Point(420, 120)
        Me.LblInteres.Name = "LblInteres"
        Me.LblInteres.Size = New System.Drawing.Size(49, 20)
        Me.LblInteres.TabIndex = 112
        Me.LblInteres.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(488, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 16)
        Me.Label10.TabIndex = 110
        Me.Label10.Text = "Seguro Deuda:"
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(640, 120)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(72, 24)
        Me.btnImprimir.TabIndex = 109
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'TxtCuota
        '
        Me.TxtCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuota.ForeColor = System.Drawing.Color.Navy
        Me.TxtCuota.Location = New System.Drawing.Point(97, 90)
        Me.TxtCuota.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCuota.Name = "TxtCuota"
        Me.TxtCuota.Size = New System.Drawing.Size(78, 20)
        Me.TxtCuota.TabIndex = 19
        Me.TxtCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(8, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 16)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Cuota:                $"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnNuevo.ForeColor = System.Drawing.Color.Black
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(640, 96)
        Me.BtnNuevo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(72, 24)
        Me.BtnNuevo.TabIndex = 17
        Me.BtnNuevo.Text = "&Nuevo"
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'DtpFechaIniPres
        '
        Me.DtpFechaIniPres.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaIniPres.Location = New System.Drawing.Point(421, 58)
        Me.DtpFechaIniPres.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DtpFechaIniPres.Name = "DtpFechaIniPres"
        Me.DtpFechaIniPres.Size = New System.Drawing.Size(204, 22)
        Me.DtpFechaIniPres.TabIndex = 16
        Me.DtpFechaIniPres.Value = New Date(2013, 10, 31, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(341, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 16)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Inicio Préstamo:"
        '
        'CbxPeriodo
        '
        Me.CbxPeriodo.BackColor = System.Drawing.SystemColors.Window
        Me.CbxPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxPeriodo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxPeriodo.ForeColor = System.Drawing.Color.Navy
        Me.CbxPeriodo.FormattingEnabled = True
        Me.CbxPeriodo.Location = New System.Drawing.Point(421, 25)
        Me.CbxPeriodo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxPeriodo.Name = "CbxPeriodo"
        Me.CbxPeriodo.Size = New System.Drawing.Size(204, 24)
        Me.CbxPeriodo.TabIndex = 10
        '
        'BtnCalcular
        '
        Me.BtnCalcular.Enabled = False
        Me.BtnCalcular.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnCalcular.ForeColor = System.Drawing.Color.Black
        Me.BtnCalcular.Image = CType(resources.GetObject("BtnCalcular.Image"), System.Drawing.Image)
        Me.BtnCalcular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCalcular.Location = New System.Drawing.Point(640, 72)
        Me.BtnCalcular.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCalcular.Name = "BtnCalcular"
        Me.BtnCalcular.Size = New System.Drawing.Size(72, 24)
        Me.BtnCalcular.TabIndex = 10
        Me.BtnCalcular.Text = "&Calcular"
        Me.BtnCalcular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCalcular.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(341, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Periodo:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Monto Préstamo:$"
        '
        'NudNumeroCuot
        '
        Me.NudNumeroCuot.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudNumeroCuot.ForeColor = System.Drawing.Color.Navy
        Me.NudNumeroCuot.Location = New System.Drawing.Point(97, 58)
        Me.NudNumeroCuot.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NudNumeroCuot.Maximum = New Decimal(New Integer() {168, 0, 0, 0})
        Me.NudNumeroCuot.Name = "NudNumeroCuot"
        Me.NudNumeroCuot.Size = New System.Drawing.Size(77, 22)
        Me.NudNumeroCuot.TabIndex = 4
        Me.NudNumeroCuot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nº de Cuotas:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpNormales)
        Me.TabControl1.Controls.Add(Me.tpEspeciales)
        Me.TabControl1.Location = New System.Drawing.Point(8, 159)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(795, 458)
        Me.TabControl1.TabIndex = 11
        '
        'tpNormales
        '
        Me.tpNormales.Controls.Add(Me.DgvProgramacion)
        Me.tpNormales.Location = New System.Drawing.Point(4, 25)
        Me.tpNormales.Name = "tpNormales"
        Me.tpNormales.Padding = New System.Windows.Forms.Padding(3)
        Me.tpNormales.Size = New System.Drawing.Size(787, 429)
        Me.tpNormales.TabIndex = 0
        Me.tpNormales.Text = "Cuotas Normales"
        Me.tpNormales.UseVisualStyleBackColor = True
        '
        'tpEspeciales
        '
        Me.tpEspeciales.Controls.Add(Me.Label3)
        Me.tpEspeciales.Controls.Add(Me.TxtTotalCuotasEspeciales)
        Me.tpEspeciales.Controls.Add(Me.BtnEliminar)
        Me.tpEspeciales.Controls.Add(Me.BtnAgregar)
        Me.tpEspeciales.Controls.Add(Me.Label14)
        Me.tpEspeciales.Controls.Add(Me.TxtCuotaEspecial)
        Me.tpEspeciales.Controls.Add(Me.CbxPeriodoEspeciales)
        Me.tpEspeciales.Controls.Add(Me.Label21)
        Me.tpEspeciales.Controls.Add(Me.DtpFechaPago)
        Me.tpEspeciales.Controls.Add(Me.Label24)
        Me.tpEspeciales.Controls.Add(Me.DgvProgramacionesEspeciales)
        Me.tpEspeciales.Location = New System.Drawing.Point(4, 25)
        Me.tpEspeciales.Name = "tpEspeciales"
        Me.tpEspeciales.Padding = New System.Windows.Forms.Padding(3)
        Me.tpEspeciales.Size = New System.Drawing.Size(787, 429)
        Me.tpEspeciales.TabIndex = 1
        Me.tpEspeciales.Text = "Cuotas Especiales"
        Me.tpEspeciales.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(496, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 22)
        Me.Label3.TabIndex = 190
        Me.Label3.Text = "Total Cuota:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label3.Visible = False
        '
        'TxtTotalCuotasEspeciales
        '
        Me.TxtTotalCuotasEspeciales.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTotalCuotasEspeciales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotalCuotasEspeciales.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalCuotasEspeciales.ForeColor = System.Drawing.Color.Blue
        Me.TxtTotalCuotasEspeciales.Location = New System.Drawing.Point(598, 29)
        Me.TxtTotalCuotasEspeciales.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTotalCuotasEspeciales.MaxLength = 7
        Me.TxtTotalCuotasEspeciales.Name = "TxtTotalCuotasEspeciales"
        Me.TxtTotalCuotasEspeciales.ReadOnly = True
        Me.TxtTotalCuotasEspeciales.Size = New System.Drawing.Size(96, 25)
        Me.TxtTotalCuotasEspeciales.TabIndex = 189
        Me.TxtTotalCuotasEspeciales.Text = "0"
        Me.TxtTotalCuotasEspeciales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotalCuotasEspeciales.Visible = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.Color.Transparent
        Me.BtnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnEliminar.ForeColor = System.Drawing.Color.Black
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(241, 26)
        Me.BtnEliminar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(24, 24)
        Me.BtnEliminar.TabIndex = 188
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'BtnAgregar
        '
        Me.BtnAgregar.BackColor = System.Drawing.Color.Transparent
        Me.BtnAgregar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnAgregar.ForeColor = System.Drawing.Color.Black
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAgregar.Location = New System.Drawing.Point(212, 26)
        Me.BtnAgregar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(24, 24)
        Me.BtnAgregar.TabIndex = 187
        Me.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(6, 29)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 16)
        Me.Label14.TabIndex = 186
        Me.Label14.Text = "Cuota Especial:"
        '
        'TxtCuotaEspecial
        '
        Me.TxtCuotaEspecial.BackColor = System.Drawing.Color.White
        Me.TxtCuotaEspecial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuotaEspecial.ForeColor = System.Drawing.Color.Navy
        Me.TxtCuotaEspecial.Location = New System.Drawing.Point(99, 27)
        Me.TxtCuotaEspecial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCuotaEspecial.Name = "TxtCuotaEspecial"
        Me.TxtCuotaEspecial.Size = New System.Drawing.Size(107, 20)
        Me.TxtCuotaEspecial.TabIndex = 185
        Me.TxtCuotaEspecial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CbxPeriodoEspeciales
        '
        Me.CbxPeriodoEspeciales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxPeriodoEspeciales.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxPeriodoEspeciales.ForeColor = System.Drawing.Color.Navy
        Me.CbxPeriodoEspeciales.FormattingEnabled = True
        Me.CbxPeriodoEspeciales.Location = New System.Drawing.Point(482, 3)
        Me.CbxPeriodoEspeciales.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxPeriodoEspeciales.Name = "CbxPeriodoEspeciales"
        Me.CbxPeriodoEspeciales.Size = New System.Drawing.Size(212, 24)
        Me.CbxPeriodoEspeciales.TabIndex = 184
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label21.Location = New System.Drawing.Point(406, 6)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 16)
        Me.Label21.TabIndex = 183
        Me.Label21.Text = "Periodo:"
        '
        'DtpFechaPago
        '
        Me.DtpFechaPago.Location = New System.Drawing.Point(99, 3)
        Me.DtpFechaPago.Name = "DtpFechaPago"
        Me.DtpFechaPago.Size = New System.Drawing.Size(272, 22)
        Me.DtpFechaPago.TabIndex = 182
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label24.Location = New System.Drawing.Point(6, 3)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 16)
        Me.Label24.TabIndex = 181
        Me.Label24.Text = "Fecha de Pago:"
        '
        'DgvProgramacionesEspeciales
        '
        Me.DgvProgramacionesEspeciales.AllowUserToAddRows = False
        Me.DgvProgramacionesEspeciales.AllowUserToDeleteRows = False
        Me.DgvProgramacionesEspeciales.AllowUserToResizeColumns = False
        Me.DgvProgramacionesEspeciales.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvProgramacionesEspeciales.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvProgramacionesEspeciales.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvProgramacionesEspeciales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgvProgramacionesEspeciales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvProgramacionesEspeciales.DefaultCellStyle = DataGridViewCellStyle7
        Me.DgvProgramacionesEspeciales.Location = New System.Drawing.Point(3, 56)
        Me.DgvProgramacionesEspeciales.MultiSelect = False
        Me.DgvProgramacionesEspeciales.Name = "DgvProgramacionesEspeciales"
        Me.DgvProgramacionesEspeciales.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvProgramacionesEspeciales.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DgvProgramacionesEspeciales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProgramacionesEspeciales.Size = New System.Drawing.Size(781, 370)
        Me.DgvProgramacionesEspeciales.TabIndex = 11
        '
        'FrmIlustrativoProgramacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 621)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GbxPrograDesc)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmIlustrativoProgramacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Programación Cálculo Ilustrativo"
        CType(Me.DgvProgramacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxPrograDesc.ResumeLayout(False)
        Me.GbxPrograDesc.PerformLayout()
        CType(Me.NudNumeroCuot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpNormales.ResumeLayout(False)
        Me.tpEspeciales.ResumeLayout(False)
        Me.tpEspeciales.PerformLayout()
        CType(Me.DgvProgramacionesEspeciales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CbxDeduccion As System.Windows.Forms.ComboBox
    Friend WithEvents TxtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GbxPrograDesc As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NudNumeroCuot As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtnCalcular As System.Windows.Forms.Button
    Friend WithEvents CbxPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaIniPres As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents TxtCuota As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents DgvProgramacion As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblInteres As System.Windows.Forms.Label
    Friend WithEvents LblSegDeuda As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtCuotasMax As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpNormales As System.Windows.Forms.TabPage
    Friend WithEvents tpEspeciales As System.Windows.Forms.TabPage
    Friend WithEvents DgvProgramacionesEspeciales As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalCuotasEspeciales As System.Windows.Forms.TextBox
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtCuotaEspecial As System.Windows.Forms.TextBox
    Friend WithEvents CbxPeriodoEspeciales As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaPrimerPag As System.Windows.Forms.DateTimePicker
End Class
