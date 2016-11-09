<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmManSolicitudes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmManSolicitudes))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GbxDatos = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkSoloSocios = New System.Windows.Forms.CheckBox
        Me.chxMostrarlistado = New System.Windows.Forms.CheckBox
        Me.chkTipoPrestamo = New System.Windows.Forms.CheckBox
        Me.ChxGeneraIVA = New System.Windows.Forms.CheckBox
        Me.ChxCotizacion = New System.Windows.Forms.CheckBox
        Me.ChxVariosPeriodos = New System.Windows.Forms.CheckBox
        Me.ChxOrdenCompra = New System.Windows.Forms.CheckBox
        Me.CbxTipDocumento = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtMontoMax = New System.Windows.Forms.TextBox
        Me.BtnEliminar = New System.Windows.Forms.Button
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.BtnNueva = New System.Windows.Forms.Button
        Me.TxtMontoFin = New System.Windows.Forms.TextBox
        Me.TxtMontoIni = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.CbxDeduccion = New System.Windows.Forms.ComboBox
        Me.NudCuotaMax = New System.Windows.Forms.NumericUpDown
        Me.NudCuotaMin = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.TxtCodigoSolicitud = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DgvSolicitudes = New System.Windows.Forms.DataGridView
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GbxDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NudCuotaMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudCuotaMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GbxDatos
        '
        Me.GbxDatos.BackColor = System.Drawing.Color.Transparent
        Me.GbxDatos.Controls.Add(Me.Label1)
        Me.GbxDatos.Controls.Add(Me.GroupBox1)
        Me.GbxDatos.Controls.Add(Me.CbxTipDocumento)
        Me.GbxDatos.Controls.Add(Me.Label5)
        Me.GbxDatos.Controls.Add(Me.TxtMontoMax)
        Me.GbxDatos.Controls.Add(Me.BtnEliminar)
        Me.GbxDatos.Controls.Add(Me.BtnGuardar)
        Me.GbxDatos.Controls.Add(Me.BtnNueva)
        Me.GbxDatos.Controls.Add(Me.TxtMontoFin)
        Me.GbxDatos.Controls.Add(Me.TxtMontoIni)
        Me.GbxDatos.Controls.Add(Me.Label12)
        Me.GbxDatos.Controls.Add(Me.Label11)
        Me.GbxDatos.Controls.Add(Me.CbxDeduccion)
        Me.GbxDatos.Controls.Add(Me.NudCuotaMax)
        Me.GbxDatos.Controls.Add(Me.NudCuotaMin)
        Me.GbxDatos.Controls.Add(Me.Label8)
        Me.GbxDatos.Controls.Add(Me.Label7)
        Me.GbxDatos.Controls.Add(Me.TxtDescripcion)
        Me.GbxDatos.Controls.Add(Me.TxtCodigoSolicitud)
        Me.GbxDatos.Controls.Add(Me.Label4)
        Me.GbxDatos.Controls.Add(Me.Label3)
        Me.GbxDatos.Controls.Add(Me.Label2)
        Me.GbxDatos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxDatos.ForeColor = System.Drawing.Color.Navy
        Me.GbxDatos.Location = New System.Drawing.Point(16, 8)
        Me.GbxDatos.Name = "GbxDatos"
        Me.GbxDatos.Size = New System.Drawing.Size(650, 195)
        Me.GbxDatos.TabIndex = 0
        Me.GbxDatos.TabStop = False
        Me.GbxDatos.Text = "Registro de Tipos de Solicitudes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(252, 172)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Monto Final:"
        Me.Label1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkSoloSocios)
        Me.GroupBox1.Controls.Add(Me.chxMostrarlistado)
        Me.GroupBox1.Controls.Add(Me.chkTipoPrestamo)
        Me.GroupBox1.Controls.Add(Me.ChxGeneraIVA)
        Me.GroupBox1.Controls.Add(Me.ChxCotizacion)
        Me.GroupBox1.Controls.Add(Me.ChxVariosPeriodos)
        Me.GroupBox1.Controls.Add(Me.ChxOrdenCompra)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(437, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 175)
        Me.GroupBox1.TabIndex = 70
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones"
        '
        'chkSoloSocios
        '
        Me.chkSoloSocios.AutoSize = True
        Me.chkSoloSocios.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSoloSocios.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkSoloSocios.Location = New System.Drawing.Point(22, 150)
        Me.chkSoloSocios.Name = "chkSoloSocios"
        Me.chkSoloSocios.Size = New System.Drawing.Size(109, 20)
        Me.chkSoloSocios.TabIndex = 73
        Me.chkSoloSocios.Text = "Aplica solo socios"
        Me.chkSoloSocios.UseVisualStyleBackColor = True
        '
        'chxMostrarlistado
        '
        Me.chxMostrarlistado.AutoSize = True
        Me.chxMostrarlistado.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chxMostrarlistado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chxMostrarlistado.Location = New System.Drawing.Point(22, 128)
        Me.chxMostrarlistado.Name = "chxMostrarlistado"
        Me.chxMostrarlistado.Size = New System.Drawing.Size(115, 20)
        Me.chxMostrarlistado.TabIndex = 72
        Me.chxMostrarlistado.Text = "Mostrar en listados"
        Me.chxMostrarlistado.UseVisualStyleBackColor = True
        '
        'chkTipoPrestamo
        '
        Me.chkTipoPrestamo.AutoSize = True
        Me.chkTipoPrestamo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTipoPrestamo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkTipoPrestamo.Location = New System.Drawing.Point(22, 106)
        Me.chkTipoPrestamo.Name = "chkTipoPrestamo"
        Me.chkTipoPrestamo.Size = New System.Drawing.Size(104, 20)
        Me.chkTipoPrestamo.TabIndex = 71
        Me.chkTipoPrestamo.Text = "Es tipo prestamo"
        Me.chkTipoPrestamo.UseVisualStyleBackColor = True
        '
        'ChxGeneraIVA
        '
        Me.ChxGeneraIVA.AutoSize = True
        Me.ChxGeneraIVA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChxGeneraIVA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChxGeneraIVA.Location = New System.Drawing.Point(22, 84)
        Me.ChxGeneraIVA.Name = "ChxGeneraIVA"
        Me.ChxGeneraIVA.Size = New System.Drawing.Size(86, 20)
        Me.ChxGeneraIVA.TabIndex = 70
        Me.ChxGeneraIVA.Text = "Genera  IVA"
        Me.ChxGeneraIVA.UseVisualStyleBackColor = True
        '
        'ChxCotizacion
        '
        Me.ChxCotizacion.AutoSize = True
        Me.ChxCotizacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChxCotizacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChxCotizacion.Location = New System.Drawing.Point(22, 40)
        Me.ChxCotizacion.Name = "ChxCotizacion"
        Me.ChxCotizacion.Size = New System.Drawing.Size(122, 20)
        Me.ChxCotizacion.TabIndex = 8
        Me.ChxCotizacion.Text = "Requiere Cotización"
        Me.ChxCotizacion.UseVisualStyleBackColor = True
        '
        'ChxVariosPeriodos
        '
        Me.ChxVariosPeriodos.AutoSize = True
        Me.ChxVariosPeriodos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChxVariosPeriodos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChxVariosPeriodos.Location = New System.Drawing.Point(22, 18)
        Me.ChxVariosPeriodos.Name = "ChxVariosPeriodos"
        Me.ChxVariosPeriodos.Size = New System.Drawing.Size(137, 20)
        Me.ChxVariosPeriodos.TabIndex = 7
        Me.ChxVariosPeriodos.Text = "Autorización Automática"
        Me.ChxVariosPeriodos.UseVisualStyleBackColor = True
        '
        'ChxOrdenCompra
        '
        Me.ChxOrdenCompra.AutoSize = True
        Me.ChxOrdenCompra.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChxOrdenCompra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChxOrdenCompra.Location = New System.Drawing.Point(22, 62)
        Me.ChxOrdenCompra.Name = "ChxOrdenCompra"
        Me.ChxOrdenCompra.Size = New System.Drawing.Size(152, 20)
        Me.ChxOrdenCompra.TabIndex = 69
        Me.ChxOrdenCompra.Text = "Genera Orden de Compra"
        Me.ChxOrdenCompra.UseVisualStyleBackColor = True
        '
        'CbxTipDocumento
        '
        Me.CbxTipDocumento.DisplayMember = "1"
        Me.CbxTipDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipDocumento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxTipDocumento.ForeColor = System.Drawing.Color.Navy
        Me.CbxTipDocumento.FormattingEnabled = True
        Me.CbxTipDocumento.Location = New System.Drawing.Point(104, 54)
        Me.CbxTipDocumento.Name = "CbxTipDocumento"
        Me.CbxTipDocumento.Size = New System.Drawing.Size(312, 24)
        Me.CbxTipDocumento.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(20, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Tipo Docto.:"
        '
        'TxtMontoMax
        '
        Me.TxtMontoMax.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoMax.ForeColor = System.Drawing.Color.Navy
        Me.TxtMontoMax.Location = New System.Drawing.Point(161, 155)
        Me.TxtMontoMax.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtMontoMax.MaxLength = 7
        Me.TxtMontoMax.Name = "TxtMontoMax"
        Me.TxtMontoMax.Size = New System.Drawing.Size(72, 22)
        Me.TxtMontoMax.TabIndex = 6
        Me.TxtMontoMax.Text = "0.00"
        Me.TxtMontoMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnEliminar.ForeColor = System.Drawing.Color.Black
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(344, 79)
        Me.BtnEliminar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(72, 24)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnGuardar.ForeColor = System.Drawing.Color.Black
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(264, 79)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(72, 24)
        Me.BtnGuardar.TabIndex = 11
        Me.BtnGuardar.Text = "&Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnNueva
        '
        Me.BtnNueva.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnNueva.ForeColor = System.Drawing.Color.Black
        Me.BtnNueva.Image = CType(resources.GetObject("BtnNueva.Image"), System.Drawing.Image)
        Me.BtnNueva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNueva.Location = New System.Drawing.Point(184, 79)
        Me.BtnNueva.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnNueva.Name = "BtnNueva"
        Me.BtnNueva.Size = New System.Drawing.Size(72, 24)
        Me.BtnNueva.TabIndex = 12
        Me.BtnNueva.Text = "&Nueva"
        Me.BtnNueva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNueva.UseVisualStyleBackColor = True
        '
        'TxtMontoFin
        '
        Me.TxtMontoFin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoFin.ForeColor = System.Drawing.Color.Navy
        Me.TxtMontoFin.Location = New System.Drawing.Point(336, 170)
        Me.TxtMontoFin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtMontoFin.MaxLength = 7
        Me.TxtMontoFin.Name = "TxtMontoFin"
        Me.TxtMontoFin.Size = New System.Drawing.Size(80, 22)
        Me.TxtMontoFin.TabIndex = 5
        Me.TxtMontoFin.Text = "0.00"
        Me.TxtMontoFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtMontoFin.Visible = False
        '
        'TxtMontoIni
        '
        Me.TxtMontoIni.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMontoIni.ForeColor = System.Drawing.Color.Navy
        Me.TxtMontoIni.Location = New System.Drawing.Point(336, 153)
        Me.TxtMontoIni.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtMontoIni.MaxLength = 7
        Me.TxtMontoIni.Name = "TxtMontoIni"
        Me.TxtMontoIni.Size = New System.Drawing.Size(80, 22)
        Me.TxtMontoIni.TabIndex = 4
        Me.TxtMontoIni.Text = "0.00"
        Me.TxtMontoIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtMontoIni.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(20, 158)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(138, 16)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Consumo Maximo Hasta : $"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(252, 155)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 16)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "Monto Inicial:"
        Me.Label11.Visible = False
        '
        'CbxDeduccion
        '
        Me.CbxDeduccion.DisplayMember = "1"
        Me.CbxDeduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxDeduccion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxDeduccion.ForeColor = System.Drawing.Color.Navy
        Me.CbxDeduccion.FormattingEnabled = True
        Me.CbxDeduccion.Location = New System.Drawing.Point(104, 28)
        Me.CbxDeduccion.Name = "CbxDeduccion"
        Me.CbxDeduccion.Size = New System.Drawing.Size(312, 24)
        Me.CbxDeduccion.TabIndex = 1
        '
        'NudCuotaMax
        '
        Me.NudCuotaMax.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudCuotaMax.ForeColor = System.Drawing.Color.Navy
        Me.NudCuotaMax.Location = New System.Drawing.Point(161, 129)
        Me.NudCuotaMax.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.NudCuotaMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudCuotaMax.Name = "NudCuotaMax"
        Me.NudCuotaMax.Size = New System.Drawing.Size(72, 22)
        Me.NudCuotaMax.TabIndex = 10
        Me.NudCuotaMax.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudCuotaMin
        '
        Me.NudCuotaMin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudCuotaMin.ForeColor = System.Drawing.Color.Navy
        Me.NudCuotaMin.Location = New System.Drawing.Point(344, 131)
        Me.NudCuotaMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudCuotaMin.Name = "NudCuotaMin"
        Me.NudCuotaMin.Size = New System.Drawing.Size(72, 22)
        Me.NudCuotaMin.TabIndex = 9
        Me.NudCuotaMin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudCuotaMin.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(20, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(142, 16)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Máximo cuotas Quincenales:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(248, 131)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 16)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Cuota Minima:"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.ForeColor = System.Drawing.Color.Navy
        Me.TxtDescripcion.Location = New System.Drawing.Point(104, 104)
        Me.TxtDescripcion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(312, 22)
        Me.TxtDescripcion.TabIndex = 2
        '
        'TxtCodigoSolicitud
        '
        Me.TxtCodigoSolicitud.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCodigoSolicitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoSolicitud.ForeColor = System.Drawing.Color.Red
        Me.TxtCodigoSolicitud.Location = New System.Drawing.Point(104, 80)
        Me.TxtCodigoSolicitud.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoSolicitud.Name = "TxtCodigoSolicitud"
        Me.TxtCodigoSolicitud.ReadOnly = True
        Me.TxtCodigoSolicitud.Size = New System.Drawing.Size(80, 22)
        Me.TxtCodigoSolicitud.TabIndex = 20
        Me.TxtCodigoSolicitud.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(20, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Descripción:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(20, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Deducción:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(20, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Codigo :"
        '
        'DgvSolicitudes
        '
        Me.DgvSolicitudes.AllowUserToAddRows = False
        Me.DgvSolicitudes.AllowUserToDeleteRows = False
        Me.DgvSolicitudes.AllowUserToResizeColumns = False
        Me.DgvSolicitudes.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.DgvSolicitudes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvSolicitudes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSolicitudes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSolicitudes.DefaultCellStyle = DataGridViewCellStyle7
        Me.DgvSolicitudes.Location = New System.Drawing.Point(16, 209)
        Me.DgvSolicitudes.MultiSelect = False
        Me.DgvSolicitudes.Name = "DgvSolicitudes"
        Me.DgvSolicitudes.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSolicitudes.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSolicitudes.Size = New System.Drawing.Size(793, 343)
        Me.DgvSolicitudes.TabIndex = 1
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(675, 15)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(133, 185)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 11
        Me.pbImagen.TabStop = False
        '
        'FrmManSolicitudes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(822, 561)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.DgvSolicitudes)
        Me.Controls.Add(Me.GbxDatos)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmManSolicitudes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Catálogo de Tipos de Solicitudes"
        Me.GbxDatos.ResumeLayout(False)
        Me.GbxDatos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NudCuotaMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudCuotaMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GbxDatos As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnNueva As System.Windows.Forms.Button
    Friend WithEvents ChxVariosPeriodos As System.Windows.Forms.CheckBox
    Friend WithEvents ChxCotizacion As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NudCuotaMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudCuotaMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents CbxDeduccion As System.Windows.Forms.ComboBox
    Friend WithEvents TxtMontoFin As System.Windows.Forms.TextBox
    Friend WithEvents TxtMontoIni As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DgvSolicitudes As System.Windows.Forms.DataGridView
    Friend WithEvents TxtMontoMax As System.Windows.Forms.TextBox
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ChxOrdenCompra As System.Windows.Forms.CheckBox
    Friend WithEvents CbxTipDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChxGeneraIVA As System.Windows.Forms.CheckBox
    Friend WithEvents chkTipoPrestamo As System.Windows.Forms.CheckBox
    Friend WithEvents chxMostrarlistado As System.Windows.Forms.CheckBox
    Friend WithEvents chkSoloSocios As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
