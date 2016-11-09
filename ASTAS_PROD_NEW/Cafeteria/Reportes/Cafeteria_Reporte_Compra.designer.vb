<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Reporte_Compra
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Reporte_Compra))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblNotificacion = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.TxtProveedor_Nit = New System.Windows.Forms.TextBox
        Me.TxtProveedor_NombreComercial = New System.Windows.Forms.TextBox
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.BtnLimpiar = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtProveedor_Direccion = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtProveedor_RegistroFiscal = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtProveedor_NombreLegal = New System.Windows.Forms.TextBox
        Me.TxtProveedor_Codigo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.cmbTiempo = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.fecha_hasta = New System.Windows.Forms.DateTimePicker
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.fecha_desde = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(725, 13)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(158, 163)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 104
        Me.pbImagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Controls.Add(Me.lblNotificacion)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.TxtProveedor_Nit)
        Me.GroupBox1.Controls.Add(Me.TxtProveedor_NombreComercial)
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Controls.Add(Me.BtnLimpiar)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtProveedor_Direccion)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TxtProveedor_RegistroFiscal)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TxtProveedor_NombreLegal)
        Me.GroupBox1.Controls.Add(Me.TxtProveedor_Codigo)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.cmbTiempo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.fecha_hasta)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.fecha_desde)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(895, 282)
        Me.GroupBox1.TabIndex = 103
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles Genericos"
        '
        'lblNotificacion
        '
        Me.lblNotificacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotificacion.ForeColor = System.Drawing.Color.Red
        Me.lblNotificacion.Location = New System.Drawing.Point(439, 179)
        Me.lblNotificacion.Name = "lblNotificacion"
        Me.lblNotificacion.Size = New System.Drawing.Size(201, 70)
        Me.lblNotificacion.TabIndex = 151
        Me.lblNotificacion.Text = "Asegurarce de haber procesado las recetas previamente, antes de generar el report" & _
            "e. "
        Me.lblNotificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(263, 157)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(171, 20)
        Me.CheckBox2.TabIndex = 150
        Me.CheckBox2.Text = "Todos los Proveedores"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'TxtProveedor_Nit
        '
        Me.TxtProveedor_Nit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_Nit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Nit.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_Nit.Location = New System.Drawing.Point(304, 227)
        Me.TxtProveedor_Nit.MaxLength = 17
        Me.TxtProveedor_Nit.Name = "TxtProveedor_Nit"
        Me.TxtProveedor_Nit.ReadOnly = True
        Me.TxtProveedor_Nit.Size = New System.Drawing.Size(128, 22)
        Me.TxtProveedor_Nit.TabIndex = 149
        '
        'TxtProveedor_NombreComercial
        '
        Me.TxtProveedor_NombreComercial.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_NombreComercial.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_NombreComercial.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_NombreComercial.Location = New System.Drawing.Point(114, 203)
        Me.TxtProveedor_NombreComercial.Name = "TxtProveedor_NombreComercial"
        Me.TxtProveedor_NombreComercial.ReadOnly = True
        Me.TxtProveedor_NombreComercial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtProveedor_NombreComercial.Size = New System.Drawing.Size(318, 22)
        Me.TxtProveedor_NombreComercial.TabIndex = 139
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(210, 155)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscar.TabIndex = 136
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnLimpiar.Image = CType(resources.GetObject("BtnLimpiar.Image"), System.Drawing.Image)
        Me.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLimpiar.Location = New System.Drawing.Point(234, 155)
        Me.BtnLimpiar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(24, 24)
        Me.BtnLimpiar.TabIndex = 143
        Me.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(6, 251)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 16)
        Me.Label7.TabIndex = 148
        Me.Label7.Text = "Direccion"
        '
        'TxtProveedor_Direccion
        '
        Me.TxtProveedor_Direccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_Direccion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Direccion.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_Direccion.Location = New System.Drawing.Point(114, 251)
        Me.TxtProveedor_Direccion.Name = "TxtProveedor_Direccion"
        Me.TxtProveedor_Direccion.ReadOnly = True
        Me.TxtProveedor_Direccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtProveedor_Direccion.Size = New System.Drawing.Size(592, 22)
        Me.TxtProveedor_Direccion.TabIndex = 141
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(6, 203)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 16)
        Me.Label10.TabIndex = 147
        Me.Label10.Text = "Nombre Comercial"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(274, 227)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 16)
        Me.Label8.TabIndex = 146
        Me.Label8.Text = "NIT"
        '
        'TxtProveedor_RegistroFiscal
        '
        Me.TxtProveedor_RegistroFiscal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_RegistroFiscal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_RegistroFiscal.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_RegistroFiscal.Location = New System.Drawing.Point(114, 227)
        Me.TxtProveedor_RegistroFiscal.MaxLength = 20
        Me.TxtProveedor_RegistroFiscal.Name = "TxtProveedor_RegistroFiscal"
        Me.TxtProveedor_RegistroFiscal.ReadOnly = True
        Me.TxtProveedor_RegistroFiscal.Size = New System.Drawing.Size(126, 22)
        Me.TxtProveedor_RegistroFiscal.TabIndex = 140
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(6, 227)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 145
        Me.Label9.Text = "Registro Fiscal"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(6, 179)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 16)
        Me.Label11.TabIndex = 144
        Me.Label11.Text = "Nombre Legal"
        '
        'TxtProveedor_NombreLegal
        '
        Me.TxtProveedor_NombreLegal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_NombreLegal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_NombreLegal.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_NombreLegal.Location = New System.Drawing.Point(114, 179)
        Me.TxtProveedor_NombreLegal.Name = "TxtProveedor_NombreLegal"
        Me.TxtProveedor_NombreLegal.ReadOnly = True
        Me.TxtProveedor_NombreLegal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtProveedor_NombreLegal.Size = New System.Drawing.Size(318, 22)
        Me.TxtProveedor_NombreLegal.TabIndex = 138
        '
        'TxtProveedor_Codigo
        '
        Me.TxtProveedor_Codigo.BackColor = System.Drawing.Color.White
        Me.TxtProveedor_Codigo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Codigo.ForeColor = System.Drawing.Color.Red
        Me.TxtProveedor_Codigo.Location = New System.Drawing.Point(114, 155)
        Me.TxtProveedor_Codigo.Name = "TxtProveedor_Codigo"
        Me.TxtProveedor_Codigo.Size = New System.Drawing.Size(94, 22)
        Me.TxtProveedor_Codigo.TabIndex = 137
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(6, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 16)
        Me.Label12.TabIndex = 142
        Me.Label12.Text = "Proveedor"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(340, 73)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(141, 20)
        Me.CheckBox1.TabIndex = 135
        Me.CheckBox1.Text = "Todos los tiempos"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmbTiempo
        '
        Me.cmbTiempo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiempo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiempo.ForeColor = System.Drawing.Color.Navy
        Me.cmbTiempo.FormattingEnabled = True
        Me.cmbTiempo.Location = New System.Drawing.Point(114, 70)
        Me.cmbTiempo.Name = "cmbTiempo"
        Me.cmbTiempo.Size = New System.Drawing.Size(220, 24)
        Me.cmbTiempo.TabIndex = 121
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(110, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(363, 22)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(6, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Tiempo de Comida:"
        '
        'fecha_hasta
        '
        Me.fecha_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_hasta.Location = New System.Drawing.Point(232, 125)
        Me.fecha_hasta.Name = "fecha_hasta"
        Me.fecha_hasta.Size = New System.Drawing.Size(112, 22)
        Me.fecha_hasta.TabIndex = 1
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(114, 45)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(432, 24)
        Me.cmbBODEGA.TabIndex = 120
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(6, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 122
        Me.Label6.Text = "Bodega:"
        '
        'fecha_desde
        '
        Me.fecha_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_desde.Location = New System.Drawing.Point(114, 125)
        Me.fecha_desde.Name = "fecha_desde"
        Me.fecha_desde.Size = New System.Drawing.Size(112, 22)
        Me.fecha_desde.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 16)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Periodo :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(6, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 16)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Nombre del Doc :"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(114, 97)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(432, 22)
        Me.TextBox1.TabIndex = 66
        Me.TextBox1.Text = "Reporte de Compra Cafeteria"
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(646, 187)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 60)
        Me.btnNuevo.TabIndex = 2
        Me.btnNuevo.Text = "&Imprimir"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(114, 19)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(432, 24)
        Me.cmbCOMPAÑIA.TabIndex = 13
        Me.cmbCOMPAÑIA.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Compañía :"
        Me.Label1.Visible = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 282)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(895, 258)
        Me.CrystalReportViewer1.TabIndex = 104
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'Cafeteria_Reporte_Compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(895, 540)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Cafeteria_Reporte_Compra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria_Reporte_Compra"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTiempo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TxtProveedor_NombreComercial As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_Direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_RegistroFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_NombreLegal As System.Windows.Forms.TextBox
    Friend WithEvents TxtProveedor_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_Nit As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents lblNotificacion As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
