<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCooperativaConsultaProgramacionSolicitudes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCooperativaConsultaProgramacionSolicitudes))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DgvProgramaciones = New System.Windows.Forms.DataGridView
        Me.GbxCotizacion = New System.Windows.Forms.GroupBox
        Me.TxtCodigoBuxis = New System.Windows.Forms.TextBox
        Me.txtNuevo = New System.Windows.Forms.Button
        Me.lblMsj = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnBuscarSocio = New System.Windows.Forms.Button
        Me.TxtCodigoAs = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtNumSolicitud = New System.Windows.Forms.TextBox
        Me.gbDetalles = New System.Windows.Forms.GroupBox
        Me.tbProgramacion = New System.Windows.Forms.TabControl
        Me.tbp0 = New System.Windows.Forms.TabPage
        Me.DgvProgramacionesDetalle = New System.Windows.Forms.DataGridView
        Me.tbp1 = New System.Windows.Forms.TabPage
        Me.dgvProgramacionCancelada = New System.Windows.Forms.DataGridView
        Me.tbp2 = New System.Windows.Forms.TabPage
        Me.dgvProgramacionAnulada = New System.Windows.Forms.DataGridView
        Me.chkTodas = New System.Windows.Forms.CheckBox
        Me.chkCanceladas = New System.Windows.Forms.CheckBox
        Me.chkDetalle = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbTipo = New System.Windows.Forms.ComboBox
        Me.gbPrestamo = New System.Windows.Forms.GroupBox
        Me.txtNoCheque = New System.Windows.Forms.TextBox
        Me.txtBancoAsociacion = New System.Windows.Forms.TextBox
        Me.txtFechaContable = New System.Windows.Forms.TextBox
        Me.txtFormaPago = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkPagado = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.bntImprimir = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbTodas = New System.Windows.Forms.RadioButton
        Me.rbPend = New System.Windows.Forms.RadioButton
        CType(Me.DgvProgramaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxCotizacion.SuspendLayout()
        Me.gbDetalles.SuspendLayout()
        Me.tbProgramacion.SuspendLayout()
        Me.tbp0.SuspendLayout()
        CType(Me.DgvProgramacionesDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbp1.SuspendLayout()
        CType(Me.dgvProgramacionCancelada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbp2.SuspendLayout()
        CType(Me.dgvProgramacionAnulada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbPrestamo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvProgramaciones
        '
        Me.DgvProgramaciones.AllowUserToAddRows = False
        Me.DgvProgramaciones.AllowUserToDeleteRows = False
        Me.DgvProgramaciones.AllowUserToResizeColumns = False
        Me.DgvProgramaciones.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvProgramaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvProgramaciones.BackgroundColor = System.Drawing.Color.Azure
        Me.DgvProgramaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvProgramaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvProgramaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvProgramaciones.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvProgramaciones.Location = New System.Drawing.Point(4, 106)
        Me.DgvProgramaciones.MultiSelect = False
        Me.DgvProgramaciones.Name = "DgvProgramaciones"
        Me.DgvProgramaciones.ReadOnly = True
        Me.DgvProgramaciones.RowHeadersVisible = False
        Me.DgvProgramaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProgramaciones.Size = New System.Drawing.Size(578, 165)
        Me.DgvProgramaciones.TabIndex = 130
        '
        'GbxCotizacion
        '
        Me.GbxCotizacion.BackColor = System.Drawing.Color.Transparent
        Me.GbxCotizacion.Controls.Add(Me.TxtCodigoBuxis)
        Me.GbxCotizacion.Controls.Add(Me.txtNuevo)
        Me.GbxCotizacion.Controls.Add(Me.lblMsj)
        Me.GbxCotizacion.Controls.Add(Me.TxtNombre)
        Me.GbxCotizacion.Controls.Add(Me.Label9)
        Me.GbxCotizacion.Controls.Add(Me.Label1)
        Me.GbxCotizacion.Controls.Add(Me.BtnBuscarSocio)
        Me.GbxCotizacion.Controls.Add(Me.TxtCodigoAs)
        Me.GbxCotizacion.Controls.Add(Me.Label2)
        Me.GbxCotizacion.Controls.Add(Me.TxtNumSolicitud)
        Me.GbxCotizacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCotizacion.ForeColor = System.Drawing.Color.Navy
        Me.GbxCotizacion.Location = New System.Drawing.Point(4, 3)
        Me.GbxCotizacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCotizacion.Name = "GbxCotizacion"
        Me.GbxCotizacion.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCotizacion.Size = New System.Drawing.Size(657, 100)
        Me.GbxCotizacion.TabIndex = 129
        Me.GbxCotizacion.TabStop = False
        Me.GbxCotizacion.Text = "Datos del Socio:"
        '
        'TxtCodigoBuxis
        '
        Me.TxtCodigoBuxis.BackColor = System.Drawing.Color.White
        Me.TxtCodigoBuxis.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCodigoBuxis.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoBuxis.Location = New System.Drawing.Point(61, 25)
        Me.TxtCodigoBuxis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoBuxis.Name = "TxtCodigoBuxis"
        Me.TxtCodigoBuxis.Size = New System.Drawing.Size(107, 22)
        Me.TxtCodigoBuxis.TabIndex = 0
        Me.TxtCodigoBuxis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNuevo
        '
        Me.txtNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtNuevo.ForeColor = System.Drawing.Color.Black
        Me.txtNuevo.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.txtNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtNuevo.Location = New System.Drawing.Point(421, 63)
        Me.txtNuevo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNuevo.Name = "txtNuevo"
        Me.txtNuevo.Size = New System.Drawing.Size(72, 25)
        Me.txtNuevo.TabIndex = 134
        Me.txtNuevo.Text = "Nuevo"
        Me.txtNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.txtNuevo.UseVisualStyleBackColor = True
        '
        'lblMsj
        '
        Me.lblMsj.BackColor = System.Drawing.Color.Blue
        Me.lblMsj.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsj.ForeColor = System.Drawing.Color.Yellow
        Me.lblMsj.Location = New System.Drawing.Point(499, 32)
        Me.lblMsj.Name = "lblMsj"
        Me.lblMsj.Size = New System.Drawing.Size(149, 46)
        Me.lblMsj.TabIndex = 132
        Me.lblMsj.Text = "Solicitud" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pendiente"
        Me.lblMsj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.ForeColor = System.Drawing.Color.Navy
        Me.TxtNombre.Location = New System.Drawing.Point(61, 61)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(355, 22)
        Me.TxtNombre.TabIndex = 127
        Me.TxtNombre.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(3, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 16)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "Socio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(2, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Cod.Buxis:"
        '
        'BtnBuscarSocio
        '
        Me.BtnBuscarSocio.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscarSocio.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSocio.Image = CType(resources.GetObject("BtnBuscarSocio.Image"), System.Drawing.Image)
        Me.BtnBuscarSocio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSocio.Location = New System.Drawing.Point(421, 25)
        Me.BtnBuscarSocio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscarSocio.Name = "BtnBuscarSocio"
        Me.BtnBuscarSocio.Size = New System.Drawing.Size(72, 25)
        Me.BtnBuscarSocio.TabIndex = 2
        Me.BtnBuscarSocio.Text = "Buscar"
        Me.BtnBuscarSocio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarSocio.UseVisualStyleBackColor = True
        '
        'TxtCodigoAs
        '
        Me.TxtCodigoAs.BackColor = System.Drawing.Color.White
        Me.TxtCodigoAs.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCodigoAs.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoAs.Location = New System.Drawing.Point(312, 25)
        Me.TxtCodigoAs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoAs.Name = "TxtCodigoAs"
        Me.TxtCodigoAs.Size = New System.Drawing.Size(104, 22)
        Me.TxtCodigoAs.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(253, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Codigo AS:"
        '
        'TxtNumSolicitud
        '
        Me.TxtNumSolicitud.Location = New System.Drawing.Point(563, 64)
        Me.TxtNumSolicitud.Name = "TxtNumSolicitud"
        Me.TxtNumSolicitud.Size = New System.Drawing.Size(72, 22)
        Me.TxtNumSolicitud.TabIndex = 133
        Me.TxtNumSolicitud.Visible = False
        '
        'gbDetalles
        '
        Me.gbDetalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalles.BackColor = System.Drawing.Color.Transparent
        Me.gbDetalles.Controls.Add(Me.tbProgramacion)
        Me.gbDetalles.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalles.ForeColor = System.Drawing.Color.Navy
        Me.gbDetalles.Location = New System.Drawing.Point(4, 275)
        Me.gbDetalles.Name = "gbDetalles"
        Me.gbDetalles.Size = New System.Drawing.Size(932, 359)
        Me.gbDetalles.TabIndex = 131
        Me.gbDetalles.TabStop = False
        Me.gbDetalles.Text = "Detalle de Cuotas"
        '
        'tbProgramacion
        '
        Me.tbProgramacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbProgramacion.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbProgramacion.Controls.Add(Me.tbp0)
        Me.tbProgramacion.Controls.Add(Me.tbp1)
        Me.tbProgramacion.Controls.Add(Me.tbp2)
        Me.tbProgramacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbProgramacion.Location = New System.Drawing.Point(6, 17)
        Me.tbProgramacion.Name = "tbProgramacion"
        Me.tbProgramacion.SelectedIndex = 0
        Me.tbProgramacion.Size = New System.Drawing.Size(914, 336)
        Me.tbProgramacion.TabIndex = 132
        '
        'tbp0
        '
        Me.tbp0.Controls.Add(Me.DgvProgramacionesDetalle)
        Me.tbp0.Location = New System.Drawing.Point(4, 28)
        Me.tbp0.Name = "tbp0"
        Me.tbp0.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp0.Size = New System.Drawing.Size(906, 304)
        Me.tbp0.TabIndex = 0
        Me.tbp0.Text = "Pendientes"
        Me.tbp0.UseVisualStyleBackColor = True
        '
        'DgvProgramacionesDetalle
        '
        Me.DgvProgramacionesDetalle.AllowUserToAddRows = False
        Me.DgvProgramacionesDetalle.AllowUserToDeleteRows = False
        Me.DgvProgramacionesDetalle.AllowUserToResizeColumns = False
        Me.DgvProgramacionesDetalle.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvProgramacionesDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvProgramacionesDetalle.BackgroundColor = System.Drawing.Color.Azure
        Me.DgvProgramacionesDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvProgramacionesDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvProgramacionesDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvProgramacionesDetalle.DefaultCellStyle = DataGridViewCellStyle6
        Me.DgvProgramacionesDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvProgramacionesDetalle.Location = New System.Drawing.Point(3, 3)
        Me.DgvProgramacionesDetalle.MultiSelect = False
        Me.DgvProgramacionesDetalle.Name = "DgvProgramacionesDetalle"
        Me.DgvProgramacionesDetalle.ReadOnly = True
        Me.DgvProgramacionesDetalle.RowHeadersVisible = False
        Me.DgvProgramacionesDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProgramacionesDetalle.Size = New System.Drawing.Size(900, 298)
        Me.DgvProgramacionesDetalle.TabIndex = 130
        '
        'tbp1
        '
        Me.tbp1.Controls.Add(Me.dgvProgramacionCancelada)
        Me.tbp1.Location = New System.Drawing.Point(4, 28)
        Me.tbp1.Name = "tbp1"
        Me.tbp1.Padding = New System.Windows.Forms.Padding(3)
        Me.tbp1.Size = New System.Drawing.Size(906, 304)
        Me.tbp1.TabIndex = 1
        Me.tbp1.Text = "Canceladas"
        Me.tbp1.UseVisualStyleBackColor = True
        '
        'dgvProgramacionCancelada
        '
        Me.dgvProgramacionCancelada.AllowUserToAddRows = False
        Me.dgvProgramacionCancelada.AllowUserToDeleteRows = False
        Me.dgvProgramacionCancelada.AllowUserToResizeColumns = False
        Me.dgvProgramacionCancelada.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvProgramacionCancelada.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvProgramacionCancelada.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProgramacionCancelada.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvProgramacionCancelada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProgramacionCancelada.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvProgramacionCancelada.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProgramacionCancelada.Location = New System.Drawing.Point(3, 3)
        Me.dgvProgramacionCancelada.MultiSelect = False
        Me.dgvProgramacionCancelada.Name = "dgvProgramacionCancelada"
        Me.dgvProgramacionCancelada.ReadOnly = True
        Me.dgvProgramacionCancelada.RowHeadersVisible = False
        Me.dgvProgramacionCancelada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProgramacionCancelada.Size = New System.Drawing.Size(900, 298)
        Me.dgvProgramacionCancelada.TabIndex = 131
        '
        'tbp2
        '
        Me.tbp2.Controls.Add(Me.dgvProgramacionAnulada)
        Me.tbp2.Location = New System.Drawing.Point(4, 28)
        Me.tbp2.Name = "tbp2"
        Me.tbp2.Size = New System.Drawing.Size(906, 304)
        Me.tbp2.TabIndex = 2
        Me.tbp2.Text = "Anuladas"
        Me.tbp2.UseVisualStyleBackColor = True
        '
        'dgvProgramacionAnulada
        '
        Me.dgvProgramacionAnulada.AllowUserToAddRows = False
        Me.dgvProgramacionAnulada.AllowUserToDeleteRows = False
        Me.dgvProgramacionAnulada.AllowUserToResizeColumns = False
        Me.dgvProgramacionAnulada.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvProgramacionAnulada.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvProgramacionAnulada.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProgramacionAnulada.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvProgramacionAnulada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProgramacionAnulada.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvProgramacionAnulada.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProgramacionAnulada.Location = New System.Drawing.Point(0, 0)
        Me.dgvProgramacionAnulada.MultiSelect = False
        Me.dgvProgramacionAnulada.Name = "dgvProgramacionAnulada"
        Me.dgvProgramacionAnulada.ReadOnly = True
        Me.dgvProgramacionAnulada.RowHeadersVisible = False
        Me.dgvProgramacionAnulada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProgramacionAnulada.Size = New System.Drawing.Size(906, 304)
        Me.dgvProgramacionAnulada.TabIndex = 131
        '
        'chkTodas
        '
        Me.chkTodas.AutoSize = True
        Me.chkTodas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodas.Location = New System.Drawing.Point(8, 18)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(123, 20)
        Me.chkTodas.TabIndex = 133
        Me.chkTodas.Text = "Todas las Solcitudes"
        Me.chkTodas.UseVisualStyleBackColor = True
        '
        'chkCanceladas
        '
        Me.chkCanceladas.AutoSize = True
        Me.chkCanceladas.Enabled = False
        Me.chkCanceladas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCanceladas.Location = New System.Drawing.Point(24, 37)
        Me.chkCanceladas.Name = "chkCanceladas"
        Me.chkCanceladas.Size = New System.Drawing.Size(114, 20)
        Me.chkCanceladas.TabIndex = 134
        Me.chkCanceladas.Text = "Incluir Canceladas"
        Me.chkCanceladas.UseVisualStyleBackColor = True
        '
        'chkDetalle
        '
        Me.chkDetalle.AutoSize = True
        Me.chkDetalle.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDetalle.Location = New System.Drawing.Point(9, 55)
        Me.chkDetalle.Name = "chkDetalle"
        Me.chkDetalle.Size = New System.Drawing.Size(77, 20)
        Me.chkDetalle.TabIndex = 135
        Me.chkDetalle.Text = "Sin Detalle"
        Me.chkDetalle.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkCanceladas)
        Me.GroupBox1.Controls.Add(Me.chkDetalle)
        Me.GroupBox1.Controls.Add(Me.chkTodas)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(663, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(144, 100)
        Me.GroupBox1.TabIndex = 136
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"Pendiente", "Cancelada", "Anulada"})
        Me.cmbTipo.Location = New System.Drawing.Point(668, 72)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(123, 24)
        Me.cmbTipo.TabIndex = 136
        Me.cmbTipo.Visible = False
        '
        'gbPrestamo
        '
        Me.gbPrestamo.BackColor = System.Drawing.Color.Transparent
        Me.gbPrestamo.Controls.Add(Me.txtNoCheque)
        Me.gbPrestamo.Controls.Add(Me.txtBancoAsociacion)
        Me.gbPrestamo.Controls.Add(Me.txtFechaContable)
        Me.gbPrestamo.Controls.Add(Me.txtFormaPago)
        Me.gbPrestamo.Controls.Add(Me.Label7)
        Me.gbPrestamo.Controls.Add(Me.Label6)
        Me.gbPrestamo.Controls.Add(Me.Label5)
        Me.gbPrestamo.Controls.Add(Me.Label4)
        Me.gbPrestamo.Controls.Add(Me.chkPagado)
        Me.gbPrestamo.Controls.Add(Me.Label3)
        Me.gbPrestamo.Location = New System.Drawing.Point(676, 106)
        Me.gbPrestamo.Name = "gbPrestamo"
        Me.gbPrestamo.Size = New System.Drawing.Size(194, 160)
        Me.gbPrestamo.TabIndex = 137
        Me.gbPrestamo.TabStop = False
        Me.gbPrestamo.Text = "Detalle"
        Me.gbPrestamo.Visible = False
        '
        'txtNoCheque
        '
        Me.txtNoCheque.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtNoCheque.ForeColor = System.Drawing.Color.Navy
        Me.txtNoCheque.Location = New System.Drawing.Point(63, 127)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.ReadOnly = True
        Me.txtNoCheque.Size = New System.Drawing.Size(122, 22)
        Me.txtNoCheque.TabIndex = 9
        '
        'txtBancoAsociacion
        '
        Me.txtBancoAsociacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtBancoAsociacion.ForeColor = System.Drawing.Color.Navy
        Me.txtBancoAsociacion.Location = New System.Drawing.Point(63, 99)
        Me.txtBancoAsociacion.Name = "txtBancoAsociacion"
        Me.txtBancoAsociacion.ReadOnly = True
        Me.txtBancoAsociacion.Size = New System.Drawing.Size(122, 22)
        Me.txtBancoAsociacion.TabIndex = 8
        '
        'txtFechaContable
        '
        Me.txtFechaContable.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtFechaContable.ForeColor = System.Drawing.Color.Navy
        Me.txtFechaContable.Location = New System.Drawing.Point(63, 71)
        Me.txtFechaContable.Name = "txtFechaContable"
        Me.txtFechaContable.ReadOnly = True
        Me.txtFechaContable.Size = New System.Drawing.Size(122, 22)
        Me.txtFechaContable.TabIndex = 7
        '
        'txtFormaPago
        '
        Me.txtFormaPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtFormaPago.ForeColor = System.Drawing.Color.Navy
        Me.txtFormaPago.Location = New System.Drawing.Point(63, 43)
        Me.txtFormaPago.Name = "txtFormaPago"
        Me.txtFormaPago.ReadOnly = True
        Me.txtFormaPago.Size = New System.Drawing.Size(122, 22)
        Me.txtFormaPago.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "N.Cheque"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Banco "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Forma"
        '
        'chkPagado
        '
        Me.chkPagado.AutoSize = True
        Me.chkPagado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPagado.Location = New System.Drawing.Point(7, 20)
        Me.chkPagado.Name = "chkPagado"
        Me.chkPagado.Size = New System.Drawing.Size(70, 20)
        Me.chkPagado.TabIndex = 1
        Me.chkPagado.Text = "Pagado  "
        Me.chkPagado.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 16)
        Me.Label3.TabIndex = 0
        '
        'bntImprimir
        '
        Me.bntImprimir.BackColor = System.Drawing.Color.Transparent
        Me.bntImprimir.Enabled = False
        Me.bntImprimir.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.bntImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bntImprimir.Location = New System.Drawing.Point(589, 106)
        Me.bntImprimir.Name = "bntImprimir"
        Me.bntImprimir.Size = New System.Drawing.Size(84, 78)
        Me.bntImprimir.TabIndex = 0
        Me.bntImprimir.Text = "Imprimir Programación Seleccionada"
        Me.bntImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bntImprimir.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.rbPend)
        Me.GroupBox2.Controls.Add(Me.rbTodas)
        Me.GroupBox2.Location = New System.Drawing.Point(589, 183)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(84, 83)
        Me.GroupBox2.TabIndex = 138
        Me.GroupBox2.TabStop = False
        '
        'rbTodas
        '
        Me.rbTodas.AutoSize = True
        Me.rbTodas.Checked = True
        Me.rbTodas.Location = New System.Drawing.Point(7, 22)
        Me.rbTodas.Name = "rbTodas"
        Me.rbTodas.Size = New System.Drawing.Size(56, 20)
        Me.rbTodas.TabIndex = 0
        Me.rbTodas.TabStop = True
        Me.rbTodas.Text = "Todas"
        Me.rbTodas.UseVisualStyleBackColor = True
        '
        'rbPend
        '
        Me.rbPend.AutoSize = True
        Me.rbPend.Location = New System.Drawing.Point(7, 51)
        Me.rbPend.Name = "rbPend"
        Me.rbPend.Size = New System.Drawing.Size(78, 20)
        Me.rbPend.TabIndex = 1
        Me.rbPend.Text = "Pendientes"
        Me.rbPend.UseVisualStyleBackColor = True
        '
        'FrmCooperativaConsultaProgramacionSolicitudes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 637)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.bntImprimir)
        Me.Controls.Add(Me.gbPrestamo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbDetalles)
        Me.Controls.Add(Me.DgvProgramaciones)
        Me.Controls.Add(Me.GbxCotizacion)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmCooperativaConsultaProgramacionSolicitudes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Consulta Solicitudes Programadas"
        CType(Me.DgvProgramaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxCotizacion.ResumeLayout(False)
        Me.GbxCotizacion.PerformLayout()
        Me.gbDetalles.ResumeLayout(False)
        Me.tbProgramacion.ResumeLayout(False)
        Me.tbp0.ResumeLayout(False)
        CType(Me.DgvProgramacionesDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbp1.ResumeLayout(False)
        CType(Me.dgvProgramacionCancelada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbp2.ResumeLayout(False)
        CType(Me.dgvProgramacionAnulada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbPrestamo.ResumeLayout(False)
        Me.gbPrestamo.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvProgramaciones As System.Windows.Forms.DataGridView
    Friend WithEvents GbxCotizacion As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoBuxis As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarSocio As System.Windows.Forms.Button
    Friend WithEvents TxtCodigoAs As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMsj As System.Windows.Forms.Label
    Friend WithEvents gbDetalles As System.Windows.Forms.GroupBox
    Friend WithEvents tbProgramacion As System.Windows.Forms.TabControl
    Friend WithEvents tbp0 As System.Windows.Forms.TabPage
    Friend WithEvents DgvProgramacionesDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents tbp1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvProgramacionCancelada As System.Windows.Forms.DataGridView
    Friend WithEvents tbp2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvProgramacionAnulada As System.Windows.Forms.DataGridView
    Friend WithEvents bntImprimir As System.Windows.Forms.Button
    Friend WithEvents TxtNumSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
    Friend WithEvents chkCanceladas As System.Windows.Forms.CheckBox
    Friend WithEvents chkDetalle As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents gbPrestamo As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBancoAsociacion As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaContable As System.Windows.Forms.TextBox
    Friend WithEvents txtFormaPago As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkPagado As System.Windows.Forms.CheckBox
    Friend WithEvents txtNoCheque As System.Windows.Forms.TextBox
    Friend WithEvents txtNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPend As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodas As System.Windows.Forms.RadioButton
End Class
