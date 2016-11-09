<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProgramacionEspecial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProgramacionEspecial))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.DtpFechaIniPres = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.CbxPeriodo = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.CbxDeduccion = New System.Windows.Forms.ComboBox
        Me.DtpFechaPrimerPag = New System.Windows.Forms.DateTimePicker
        Me.TxtMonto = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblInteres = New System.Windows.Forms.Label
        Me.LblSegDeuda = New System.Windows.Forms.Label
        Me.TxtSección = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDepartamento = New System.Windows.Forms.TextBox
        Me.TxtDivision = New System.Windows.Forms.TextBox
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.TxtCodigoBuxis = New System.Windows.Forms.TextBox
        Me.TxtCodigoAs = New System.Windows.Forms.TextBox
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtNumSolicitud = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TbpNormalesEspeciales = New System.Windows.Forms.TabControl
        Me.TbpEspeciales = New System.Windows.Forms.TabPage
        Me.TxtTotalCuotasEspeciales = New System.Windows.Forms.TextBox
        Me.BtnEliminar = New System.Windows.Forms.Button
        Me.BtnAgregar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.DgvProgramacionesEspeciales = New System.Windows.Forms.DataGridView
        Me.TxtCuotaEspecial = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.DtpFechaPago = New System.Windows.Forms.DateTimePicker
        Me.Label24 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.TbpNormalesEspeciales.SuspendLayout()
        Me.TbpEspeciales.SuspendLayout()
        CType(Me.DgvProgramacionesEspeciales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImprimir
        '
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(720, 96)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(72, 24)
        Me.btnImprimir.TabIndex = 6
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'DtpFechaIniPres
        '
        Me.DtpFechaIniPres.CalendarTitleForeColor = System.Drawing.Color.White
        Me.DtpFechaIniPres.Checked = False
        Me.DtpFechaIniPres.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaIniPres.Location = New System.Drawing.Point(489, 125)
        Me.DtpFechaIniPres.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DtpFechaIniPres.Name = "DtpFechaIniPres"
        Me.DtpFechaIniPres.Size = New System.Drawing.Size(212, 22)
        Me.DtpFechaIniPres.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(409, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 16)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Inicio Préstamo:"
        '
        'CbxPeriodo
        '
        Me.CbxPeriodo.BackColor = System.Drawing.Color.White
        Me.CbxPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxPeriodo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxPeriodo.ForeColor = System.Drawing.Color.Navy
        Me.CbxPeriodo.FormattingEnabled = True
        Me.CbxPeriodo.Location = New System.Drawing.Point(489, 96)
        Me.CbxPeriodo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxPeriodo.Name = "CbxPeriodo"
        Me.CbxPeriodo.Size = New System.Drawing.Size(212, 24)
        Me.CbxPeriodo.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(409, 100)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 16)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Periodo:"
        '
        'CbxDeduccion
        '
        Me.CbxDeduccion.BackColor = System.Drawing.Color.White
        Me.CbxDeduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.CbxDeduccion.Enabled = False
        Me.CbxDeduccion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxDeduccion.ForeColor = System.Drawing.Color.Navy
        Me.CbxDeduccion.FormattingEnabled = True
        Me.CbxDeduccion.Location = New System.Drawing.Point(489, 45)
        Me.CbxDeduccion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxDeduccion.Name = "CbxDeduccion"
        Me.CbxDeduccion.Size = New System.Drawing.Size(212, 24)
        Me.CbxDeduccion.TabIndex = 3
        '
        'DtpFechaPrimerPag
        '
        Me.DtpFechaPrimerPag.CalendarTitleForeColor = System.Drawing.Color.White
        Me.DtpFechaPrimerPag.Checked = False
        Me.DtpFechaPrimerPag.CustomFormat = "dd/MMM/yyyy"
        Me.DtpFechaPrimerPag.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaPrimerPag.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaPrimerPag.Location = New System.Drawing.Point(307, 10)
        Me.DtpFechaPrimerPag.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DtpFechaPrimerPag.Name = "DtpFechaPrimerPag"
        Me.DtpFechaPrimerPag.Size = New System.Drawing.Size(107, 22)
        Me.DtpFechaPrimerPag.TabIndex = 2
        Me.DtpFechaPrimerPag.Visible = False
        '
        'TxtMonto
        '
        Me.TxtMonto.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonto.ForeColor = System.Drawing.Color.Navy
        Me.TxtMonto.Location = New System.Drawing.Point(629, 20)
        Me.TxtMonto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.ReadOnly = True
        Me.TxtMonto.Size = New System.Drawing.Size(72, 20)
        Me.TxtMonto.TabIndex = 6
        Me.TxtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(583, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 16)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Monto:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LblInteres)
        Me.GroupBox1.Controls.Add(Me.LblSegDeuda)
        Me.GroupBox1.Controls.Add(Me.TxtSección)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtDepartamento)
        Me.GroupBox1.Controls.Add(Me.CbxDeduccion)
        Me.GroupBox1.Controls.Add(Me.TxtDivision)
        Me.GroupBox1.Controls.Add(Me.BtnGuardar)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoBuxis)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoAs)
        Me.GroupBox1.Controls.Add(Me.TxtNombre)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TxtNumSolicitud)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Controls.Add(Me.DtpFechaIniPres)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.CbxPeriodo)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.TxtMonto)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(800, 158)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Programación de Descuentos"
        '
        'LblInteres
        '
        Me.LblInteres.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblInteres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblInteres.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInteres.Location = New System.Drawing.Point(489, 73)
        Me.LblInteres.Name = "LblInteres"
        Me.LblInteres.Size = New System.Drawing.Size(46, 20)
        Me.LblInteres.TabIndex = 112
        Me.LblInteres.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblSegDeuda
        '
        Me.LblSegDeuda.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblSegDeuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSegDeuda.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSegDeuda.Location = New System.Drawing.Point(640, 73)
        Me.LblSegDeuda.Name = "LblSegDeuda"
        Me.LblSegDeuda.Size = New System.Drawing.Size(46, 20)
        Me.LblSegDeuda.TabIndex = 113
        Me.LblSegDeuda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtSección
        '
        Me.TxtSección.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtSección.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSección.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtSección.ForeColor = System.Drawing.Color.Navy
        Me.TxtSección.Location = New System.Drawing.Point(90, 125)
        Me.TxtSección.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtSección.Name = "TxtSección"
        Me.TxtSección.ReadOnly = True
        Me.TxtSección.Size = New System.Drawing.Size(297, 22)
        Me.TxtSección.TabIndex = 122
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Sección:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(684, 75)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(19, 16)
        Me.Label22.TabIndex = 126
        Me.Label22.Text = "%"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(534, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 16)
        Me.Label8.TabIndex = 125
        Me.Label8.Text = "%"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(10, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 16)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "Departamento:"
        '
        'TxtDepartamento
        '
        Me.TxtDepartamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TxtDepartamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDepartamento.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtDepartamento.ForeColor = System.Drawing.Color.Navy
        Me.TxtDepartamento.Location = New System.Drawing.Point(90, 98)
        Me.TxtDepartamento.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtDepartamento.Name = "TxtDepartamento"
        Me.TxtDepartamento.ReadOnly = True
        Me.TxtDepartamento.Size = New System.Drawing.Size(297, 22)
        Me.TxtDepartamento.TabIndex = 120
        '
        'TxtDivision
        '
        Me.TxtDivision.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDivision.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtDivision.ForeColor = System.Drawing.Color.Navy
        Me.TxtDivision.Location = New System.Drawing.Point(90, 72)
        Me.TxtDivision.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtDivision.Name = "TxtDivision"
        Me.TxtDivision.ReadOnly = True
        Me.TxtDivision.Size = New System.Drawing.Size(297, 22)
        Me.TxtDivision.TabIndex = 23
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnGuardar.ForeColor = System.Drawing.Color.Black
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(720, 120)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(72, 24)
        Me.BtnGuardar.TabIndex = 7
        Me.BtnGuardar.Text = "&Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'TxtCodigoBuxis
        '
        Me.TxtCodigoBuxis.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCodigoBuxis.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCodigoBuxis.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoBuxis.Location = New System.Drawing.Point(280, 46)
        Me.TxtCodigoBuxis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoBuxis.Name = "TxtCodigoBuxis"
        Me.TxtCodigoBuxis.ReadOnly = True
        Me.TxtCodigoBuxis.Size = New System.Drawing.Size(107, 22)
        Me.TxtCodigoBuxis.TabIndex = 116
        Me.TxtCodigoBuxis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCodigoAs
        '
        Me.TxtCodigoAs.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCodigoAs.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCodigoAs.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoAs.Location = New System.Drawing.Point(90, 46)
        Me.TxtCodigoAs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoAs.Name = "TxtCodigoAs"
        Me.TxtCodigoAs.ReadOnly = True
        Me.TxtCodigoAs.Size = New System.Drawing.Size(86, 22)
        Me.TxtCodigoAs.TabIndex = 117
        Me.TxtCodigoAs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.ForeColor = System.Drawing.Color.Navy
        Me.TxtNombre.Location = New System.Drawing.Point(90, 21)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(297, 22)
        Me.TxtNombre.TabIndex = 7
        Me.TxtNombre.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(10, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 16)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Socio:"
        '
        'TxtNumSolicitud
        '
        Me.TxtNumSolicitud.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtNumSolicitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumSolicitud.ForeColor = System.Drawing.Color.Red
        Me.TxtNumSolicitud.Location = New System.Drawing.Point(489, 18)
        Me.TxtNumSolicitud.Name = "TxtNumSolicitud"
        Me.TxtNumSolicitud.ReadOnly = True
        Me.TxtNumSolicitud.Size = New System.Drawing.Size(61, 22)
        Me.TxtNumSolicitud.TabIndex = 0
        Me.TxtNumSolicitud.TabStop = False
        Me.TxtNumSolicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(562, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 16)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Seguro Deuda:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(409, 74)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 16)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Interés:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(408, 48)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 16)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Tipo Solicitid:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "Codigo AS:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(10, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 16)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "División:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(409, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nº Solicitud:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(208, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Codigo Buxis:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(225, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 16)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Fecha Anterior:"
        Me.Label18.Visible = False
        '
        'TbpNormalesEspeciales
        '
        Me.TbpNormalesEspeciales.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TbpNormalesEspeciales.Controls.Add(Me.TbpEspeciales)
        Me.TbpNormalesEspeciales.Location = New System.Drawing.Point(8, 173)
        Me.TbpNormalesEspeciales.Name = "TbpNormalesEspeciales"
        Me.TbpNormalesEspeciales.SelectedIndex = 0
        Me.TbpNormalesEspeciales.Size = New System.Drawing.Size(798, 486)
        Me.TbpNormalesEspeciales.TabIndex = 13
        '
        'TbpEspeciales
        '
        Me.TbpEspeciales.Controls.Add(Me.TxtTotalCuotasEspeciales)
        Me.TbpEspeciales.Controls.Add(Me.BtnEliminar)
        Me.TbpEspeciales.Controls.Add(Me.BtnAgregar)
        Me.TbpEspeciales.Controls.Add(Me.Label6)
        Me.TbpEspeciales.Controls.Add(Me.DgvProgramacionesEspeciales)
        Me.TbpEspeciales.Controls.Add(Me.TxtCuotaEspecial)
        Me.TbpEspeciales.Controls.Add(Me.Label23)
        Me.TbpEspeciales.Controls.Add(Me.DtpFechaPago)
        Me.TbpEspeciales.Controls.Add(Me.Label24)
        Me.TbpEspeciales.Controls.Add(Me.DtpFechaPrimerPag)
        Me.TbpEspeciales.Controls.Add(Me.Label18)
        Me.TbpEspeciales.Location = New System.Drawing.Point(4, 28)
        Me.TbpEspeciales.Name = "TbpEspeciales"
        Me.TbpEspeciales.Padding = New System.Windows.Forms.Padding(3)
        Me.TbpEspeciales.Size = New System.Drawing.Size(790, 454)
        Me.TbpEspeciales.TabIndex = 1
        Me.TbpEspeciales.Text = " Cuotas Preferenciales"
        Me.TbpEspeciales.UseVisualStyleBackColor = True
        '
        'TxtTotalCuotasEspeciales
        '
        Me.TxtTotalCuotasEspeciales.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTotalCuotasEspeciales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotalCuotasEspeciales.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalCuotasEspeciales.ForeColor = System.Drawing.Color.Blue
        Me.TxtTotalCuotasEspeciales.Location = New System.Drawing.Point(688, 8)
        Me.TxtTotalCuotasEspeciales.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTotalCuotasEspeciales.MaxLength = 7
        Me.TxtTotalCuotasEspeciales.Name = "TxtTotalCuotasEspeciales"
        Me.TxtTotalCuotasEspeciales.ReadOnly = True
        Me.TxtTotalCuotasEspeciales.Size = New System.Drawing.Size(96, 22)
        Me.TxtTotalCuotasEspeciales.TabIndex = 179
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
        Me.BtnEliminar.Location = New System.Drawing.Point(243, 36)
        Me.BtnEliminar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(24, 24)
        Me.BtnEliminar.TabIndex = 178
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
        Me.BtnAgregar.Location = New System.Drawing.Point(214, 36)
        Me.BtnAgregar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(24, 24)
        Me.BtnAgregar.TabIndex = 177
        Me.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 16)
        Me.Label6.TabIndex = 176
        Me.Label6.Text = "Cuota Capital:"
        '
        'DgvProgramacionesEspeciales
        '
        Me.DgvProgramacionesEspeciales.AllowUserToAddRows = False
        Me.DgvProgramacionesEspeciales.AllowUserToDeleteRows = False
        Me.DgvProgramacionesEspeciales.AllowUserToResizeColumns = False
        Me.DgvProgramacionesEspeciales.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvProgramacionesEspeciales.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvProgramacionesEspeciales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvProgramacionesEspeciales.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvProgramacionesEspeciales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvProgramacionesEspeciales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvProgramacionesEspeciales.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvProgramacionesEspeciales.Location = New System.Drawing.Point(2, 69)
        Me.DgvProgramacionesEspeciales.MultiSelect = False
        Me.DgvProgramacionesEspeciales.Name = "DgvProgramacionesEspeciales"
        Me.DgvProgramacionesEspeciales.ReadOnly = True
        Me.DgvProgramacionesEspeciales.RowHeadersVisible = False
        Me.DgvProgramacionesEspeciales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProgramacionesEspeciales.Size = New System.Drawing.Size(785, 382)
        Me.DgvProgramacionesEspeciales.TabIndex = 175
        '
        'TxtCuotaEspecial
        '
        Me.TxtCuotaEspecial.BackColor = System.Drawing.Color.White
        Me.TxtCuotaEspecial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuotaEspecial.ForeColor = System.Drawing.Color.Navy
        Me.TxtCuotaEspecial.Location = New System.Drawing.Point(101, 37)
        Me.TxtCuotaEspecial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCuotaEspecial.Name = "TxtCuotaEspecial"
        Me.TxtCuotaEspecial.Size = New System.Drawing.Size(107, 20)
        Me.TxtCuotaEspecial.TabIndex = 169
        Me.TxtCuotaEspecial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(386, 180)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(0, 16)
        Me.Label23.TabIndex = 162
        '
        'DtpFechaPago
        '
        Me.DtpFechaPago.CustomFormat = "dd/MMM/yyyy"
        Me.DtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaPago.Location = New System.Drawing.Point(101, 8)
        Me.DtpFechaPago.Name = "DtpFechaPago"
        Me.DtpFechaPago.Size = New System.Drawing.Size(107, 22)
        Me.DtpFechaPago.TabIndex = 160
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label24.Location = New System.Drawing.Point(11, 13)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 16)
        Me.Label24.TabIndex = 159
        Me.Label24.Text = "Fecha de Pago:"
        '
        'FrmProgramacionEspecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(814, 662)
        Me.Controls.Add(Me.TbpNormalesEspeciales)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmProgramacionEspecial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Programación Solicitudes Descuentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TbpNormalesEspeciales.ResumeLayout(False)
        Me.TbpEspeciales.ResumeLayout(False)
        Me.TbpEspeciales.PerformLayout()
        CType(Me.DgvProgramacionesEspeciales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents DtpFechaIniPres As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CbxPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CbxDeduccion As System.Windows.Forms.ComboBox
    Friend WithEvents DtpFechaPrimerPag As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNumSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoBuxis As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoAs As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents TxtDivision As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents TxtSección As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblSegDeuda As System.Windows.Forms.Label
    Friend WithEvents LblInteres As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TbpNormalesEspeciales As System.Windows.Forms.TabControl
    Friend WithEvents TbpEspeciales As System.Windows.Forms.TabPage
    Friend WithEvents DgvProgramacionesEspeciales As System.Windows.Forms.DataGridView
    Friend WithEvents TxtCuotaEspecial As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents TxtTotalCuotasEspeciales As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
