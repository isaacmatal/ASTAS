<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolicitudesCotizacion
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitudesCotizacion))
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TbcSolicitudes = New System.Windows.Forms.TabControl
        Me.TbpSolicitud = New System.Windows.Forms.TabPage
        Me.gbFiadores = New System.Windows.Forms.GroupBox
        Me.btnFiadores = New System.Windows.Forms.Button
        Me.txtDeudaFiador = New System.Windows.Forms.TextBox
        Me.txtNombreFiador = New System.Windows.Forms.TextBox
        Me.txtCodFiador = New System.Windows.Forms.TextBox
        Me.dgvFiadores = New System.Windows.Forms.DataGridView
        Me.codfia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombfia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.totdeuda = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.elimfia = New System.Windows.Forms.DataGridViewButtonColumn
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.TxtInteres = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblMontoMax = New System.Windows.Forms.Label
        Me.LblTituloMonto = New System.Windows.Forms.Label
        Me.GbxDatos = New System.Windows.Forms.GroupBox
        Me.LblIndemnizacion = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.LblDeduccion = New System.Windows.Forms.Label
        Me.ChxAutorizacionExp = New System.Windows.Forms.CheckBox
        Me.GbxCondicionesdePag = New System.Windows.Forms.GroupBox
        Me.txtAguin = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtBonif = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.CbxPeriodo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.NudPlazo = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtValSol = New System.Windows.Forms.TextBox
        Me.LblDisponible = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtCodigoBuxis = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtCodigoAs = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDivision = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtDepartamento = New System.Windows.Forms.TextBox
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.BtnBuscarSocio = New System.Windows.Forms.Button
        Me.BtnNueva = New System.Windows.Forms.Button
        Me.DpFechaSol = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.BtnBuscarSol = New System.Windows.Forms.Button
        Me.TxtNumeroSol = New System.Windows.Forms.TextBox
        Me.GbxCotizacion = New System.Windows.Forms.GroupBox
        Me.lblOC = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnGenerarOC = New System.Windows.Forms.Button
        Me.btnNvoDetalle = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.DtpFechaCotiza = New System.Windows.Forms.DateTimePicker
        Me.DgCotizacion = New System.Windows.Forms.DataGridView
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrecUnit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lineadetalle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nueva = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.modificada = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.BtnEliminar = New System.Windows.Forms.Button
        Me.ChkEs_Factura = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.BtnAgregar = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.TxtIVACotizacion = New System.Windows.Forms.TextBox
        Me.TxtValUnitario = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtCantidad = New System.Windows.Forms.TextBox
        Me.TxtNumCotizacion = New System.Windows.Forms.TextBox
        Me.TxtSubTotalCotizacion = New System.Windows.Forms.TextBox
        Me.BtnBuscarProv = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtProveedor = New System.Windows.Forms.TextBox
        Me.LblTitulos = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.TxtTotalCotizacion = New System.Windows.Forms.TextBox
        Me.CbxSolicitudes = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TbpHojaDatos = New System.Windows.Forms.TabPage
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtMotivoBloqueo = New System.Windows.Forms.TextBox
        Me.TbcSolicitudes.SuspendLayout()
        Me.TbpSolicitud.SuspendLayout()
        Me.gbFiadores.SuspendLayout()
        CType(Me.dgvFiadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxDatos.SuspendLayout()
        Me.GbxCondicionesdePag.SuspendLayout()
        CType(Me.NudPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxCotizacion.SuspendLayout()
        CType(Me.DgCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbcSolicitudes
        '
        Me.TbcSolicitudes.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TbcSolicitudes.Controls.Add(Me.TbpSolicitud)
        Me.TbcSolicitudes.Controls.Add(Me.TbpHojaDatos)
        Me.TbcSolicitudes.Location = New System.Drawing.Point(8, 8)
        Me.TbcSolicitudes.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TbcSolicitudes.Name = "TbcSolicitudes"
        Me.TbcSolicitudes.SelectedIndex = 0
        Me.TbcSolicitudes.Size = New System.Drawing.Size(784, 635)
        Me.TbcSolicitudes.TabIndex = 0
        '
        'TbpSolicitud
        '
        Me.TbpSolicitud.BackColor = System.Drawing.SystemColors.Control
        Me.TbpSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TbpSolicitud.Controls.Add(Me.txtMotivoBloqueo)
        Me.TbpSolicitud.Controls.Add(Me.gbFiadores)
        Me.TbpSolicitud.Controls.Add(Me.btnGuardar)
        Me.TbpSolicitud.Controls.Add(Me.TxtInteres)
        Me.TbpSolicitud.Controls.Add(Me.Label6)
        Me.TbpSolicitud.Controls.Add(Me.LblMontoMax)
        Me.TbpSolicitud.Controls.Add(Me.LblTituloMonto)
        Me.TbpSolicitud.Controls.Add(Me.GbxDatos)
        Me.TbpSolicitud.Controls.Add(Me.BtnNueva)
        Me.TbpSolicitud.Controls.Add(Me.DpFechaSol)
        Me.TbpSolicitud.Controls.Add(Me.Label15)
        Me.TbpSolicitud.Controls.Add(Me.BtnBuscarSol)
        Me.TbpSolicitud.Controls.Add(Me.TxtNumeroSol)
        Me.TbpSolicitud.Controls.Add(Me.GbxCotizacion)
        Me.TbpSolicitud.Controls.Add(Me.CbxSolicitudes)
        Me.TbpSolicitud.Controls.Add(Me.Label14)
        Me.TbpSolicitud.Controls.Add(Me.Label1)
        Me.TbpSolicitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TbpSolicitud.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TbpSolicitud.Location = New System.Drawing.Point(4, 28)
        Me.TbpSolicitud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TbpSolicitud.Name = "TbpSolicitud"
        Me.TbpSolicitud.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TbpSolicitud.Size = New System.Drawing.Size(776, 603)
        Me.TbpSolicitud.TabIndex = 0
        Me.TbpSolicitud.Text = "Solicitud"
        '
        'gbFiadores
        '
        Me.gbFiadores.BackColor = System.Drawing.Color.Transparent
        Me.gbFiadores.Controls.Add(Me.btnFiadores)
        Me.gbFiadores.Controls.Add(Me.txtDeudaFiador)
        Me.gbFiadores.Controls.Add(Me.txtNombreFiador)
        Me.gbFiadores.Controls.Add(Me.txtCodFiador)
        Me.gbFiadores.Controls.Add(Me.dgvFiadores)
        Me.gbFiadores.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gbFiadores.ForeColor = System.Drawing.Color.Navy
        Me.gbFiadores.Location = New System.Drawing.Point(8, 459)
        Me.gbFiadores.Name = "gbFiadores"
        Me.gbFiadores.Size = New System.Drawing.Size(385, 139)
        Me.gbFiadores.TabIndex = 37
        Me.gbFiadores.TabStop = False
        Me.gbFiadores.Text = "Fiadores"
        '
        'btnFiadores
        '
        Me.btnFiadores.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnFiadores.ForeColor = System.Drawing.Color.Black
        Me.btnFiadores.Image = Global.ASTAS.My.Resources.Resources.down
        Me.btnFiadores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFiadores.Location = New System.Drawing.Point(353, 15)
        Me.btnFiadores.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFiadores.Name = "btnFiadores"
        Me.btnFiadores.Size = New System.Drawing.Size(24, 24)
        Me.btnFiadores.TabIndex = 37
        Me.btnFiadores.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFiadores.UseVisualStyleBackColor = True
        '
        'txtDeudaFiador
        '
        Me.txtDeudaFiador.BackColor = System.Drawing.Color.White
        Me.txtDeudaFiador.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeudaFiador.ForeColor = System.Drawing.Color.Navy
        Me.txtDeudaFiador.Location = New System.Drawing.Point(290, 16)
        Me.txtDeudaFiador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDeudaFiador.MaxLength = 7
        Me.txtDeudaFiador.Name = "txtDeudaFiador"
        Me.txtDeudaFiador.ReadOnly = True
        Me.txtDeudaFiador.Size = New System.Drawing.Size(61, 22)
        Me.txtDeudaFiador.TabIndex = 42
        Me.txtDeudaFiador.Text = "0.00"
        Me.txtDeudaFiador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNombreFiador
        '
        Me.txtNombreFiador.BackColor = System.Drawing.Color.White
        Me.txtNombreFiador.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreFiador.ForeColor = System.Drawing.Color.Navy
        Me.txtNombreFiador.Location = New System.Drawing.Point(63, 16)
        Me.txtNombreFiador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNombreFiador.MaxLength = 9
        Me.txtNombreFiador.Name = "txtNombreFiador"
        Me.txtNombreFiador.ReadOnly = True
        Me.txtNombreFiador.Size = New System.Drawing.Size(224, 22)
        Me.txtNombreFiador.TabIndex = 56
        '
        'txtCodFiador
        '
        Me.txtCodFiador.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodFiador.ForeColor = System.Drawing.Color.Navy
        Me.txtCodFiador.Location = New System.Drawing.Point(10, 16)
        Me.txtCodFiador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodFiador.MaxLength = 9
        Me.txtCodFiador.Name = "txtCodFiador"
        Me.txtCodFiador.Size = New System.Drawing.Size(50, 22)
        Me.txtCodFiador.TabIndex = 37
        '
        'dgvFiadores
        '
        Me.dgvFiadores.AllowUserToAddRows = False
        Me.dgvFiadores.AllowUserToDeleteRows = False
        Me.dgvFiadores.AllowUserToResizeColumns = False
        Me.dgvFiadores.AllowUserToResizeRows = False
        Me.dgvFiadores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFiadores.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvFiadores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvFiadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFiadores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codfia, Me.nombfia, Me.totdeuda, Me.elimfia})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFiadores.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvFiadores.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.dgvFiadores.Location = New System.Drawing.Point(10, 41)
        Me.dgvFiadores.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgvFiadores.MultiSelect = False
        Me.dgvFiadores.Name = "dgvFiadores"
        Me.dgvFiadores.ReadOnly = True
        Me.dgvFiadores.RowHeadersVisible = False
        Me.dgvFiadores.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvFiadores.RowTemplate.ReadOnly = True
        Me.dgvFiadores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvFiadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFiadores.Size = New System.Drawing.Size(369, 91)
        Me.dgvFiadores.TabIndex = 55
        '
        'codfia
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codfia.DefaultCellStyle = DataGridViewCellStyle13
        Me.codfia.HeaderText = "Código"
        Me.codfia.Name = "codfia"
        Me.codfia.ReadOnly = True
        Me.codfia.Width = 50
        '
        'nombfia
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.nombfia.DefaultCellStyle = DataGridViewCellStyle14
        Me.nombfia.HeaderText = "Nombre"
        Me.nombfia.Name = "nombfia"
        Me.nombfia.ReadOnly = True
        Me.nombfia.Width = 200
        '
        'totdeuda
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.totdeuda.DefaultCellStyle = DataGridViewCellStyle15
        Me.totdeuda.HeaderText = "Deuda"
        Me.totdeuda.Name = "totdeuda"
        Me.totdeuda.ReadOnly = True
        Me.totdeuda.Width = 80
        '
        'elimfia
        '
        Me.elimfia.HeaderText = "X"
        Me.elimfia.Name = "elimfia"
        Me.elimfia.ReadOnly = True
        Me.elimfia.Text = ""
        Me.elimfia.Width = 20
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.Image = Global.ASTAS.My.Resources.Resources.filesave
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(375, 37)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(72, 24)
        Me.btnGuardar.TabIndex = 32
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Limpia los campos para ingresar nueva solicitud")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'TxtInteres
        '
        Me.TxtInteres.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtInteres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInteres.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInteres.ForeColor = System.Drawing.Color.Navy
        Me.TxtInteres.Location = New System.Drawing.Point(410, 7)
        Me.TxtInteres.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtInteres.MaxLength = 5
        Me.TxtInteres.Name = "TxtInteres"
        Me.TxtInteres.ReadOnly = True
        Me.TxtInteres.Size = New System.Drawing.Size(37, 22)
        Me.TxtInteres.TabIndex = 30
        Me.TxtInteres.Text = "0.00"
        Me.TxtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(353, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 16)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "% Interés:"
        '
        'LblMontoMax
        '
        Me.LblMontoMax.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblMontoMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblMontoMax.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.LblMontoMax.ForeColor = System.Drawing.Color.Navy
        Me.LblMontoMax.Location = New System.Drawing.Point(555, 7)
        Me.LblMontoMax.Name = "LblMontoMax"
        Me.LblMontoMax.Size = New System.Drawing.Size(88, 22)
        Me.LblMontoMax.TabIndex = 28
        Me.LblMontoMax.Text = "0.00"
        Me.LblMontoMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTituloMonto
        '
        Me.LblTituloMonto.AutoSize = True
        Me.LblTituloMonto.BackColor = System.Drawing.Color.Transparent
        Me.LblTituloMonto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloMonto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblTituloMonto.Location = New System.Drawing.Point(454, 9)
        Me.LblTituloMonto.Name = "LblTituloMonto"
        Me.LblTituloMonto.Size = New System.Drawing.Size(103, 16)
        Me.LblTituloMonto.TabIndex = 29
        Me.LblTituloMonto.Text = "Máximo a otorgar: $"
        '
        'GbxDatos
        '
        Me.GbxDatos.BackColor = System.Drawing.Color.Transparent
        Me.GbxDatos.Controls.Add(Me.LblIndemnizacion)
        Me.GbxDatos.Controls.Add(Me.Label13)
        Me.GbxDatos.Controls.Add(Me.Label10)
        Me.GbxDatos.Controls.Add(Me.LblDeduccion)
        Me.GbxDatos.Controls.Add(Me.ChxAutorizacionExp)
        Me.GbxDatos.Controls.Add(Me.GbxCondicionesdePag)
        Me.GbxDatos.Controls.Add(Me.TxtValSol)
        Me.GbxDatos.Controls.Add(Me.LblDisponible)
        Me.GbxDatos.Controls.Add(Me.Label19)
        Me.GbxDatos.Controls.Add(Me.Label11)
        Me.GbxDatos.Controls.Add(Me.TxtCodigoBuxis)
        Me.GbxDatos.Controls.Add(Me.Label12)
        Me.GbxDatos.Controls.Add(Me.TxtCodigoAs)
        Me.GbxDatos.Controls.Add(Me.Label2)
        Me.GbxDatos.Controls.Add(Me.TxtDivision)
        Me.GbxDatos.Controls.Add(Me.Label9)
        Me.GbxDatos.Controls.Add(Me.TxtDepartamento)
        Me.GbxDatos.Controls.Add(Me.TxtNombre)
        Me.GbxDatos.Controls.Add(Me.BtnBuscarSocio)
        Me.GbxDatos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxDatos.ForeColor = System.Drawing.Color.Navy
        Me.GbxDatos.Location = New System.Drawing.Point(8, 68)
        Me.GbxDatos.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GbxDatos.Name = "GbxDatos"
        Me.GbxDatos.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GbxDatos.Size = New System.Drawing.Size(760, 155)
        Me.GbxDatos.TabIndex = 2
        Me.GbxDatos.TabStop = False
        Me.GbxDatos.Text = "Datos Generales"
        '
        'LblIndemnizacion
        '
        Me.LblIndemnizacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblIndemnizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblIndemnizacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.LblIndemnizacion.ForeColor = System.Drawing.Color.Navy
        Me.LblIndemnizacion.Location = New System.Drawing.Point(299, 49)
        Me.LblIndemnizacion.Name = "LblIndemnizacion"
        Me.LblIndemnizacion.Size = New System.Drawing.Size(88, 22)
        Me.LblIndemnizacion.TabIndex = 38
        Me.LblIndemnizacion.Text = "0.00"
        Me.LblIndemnizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(10, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 16)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Nombre Socio:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(204, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 16)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Indemnización:     $ "
        '
        'LblDeduccion
        '
        Me.LblDeduccion.AutoSize = True
        Me.LblDeduccion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDeduccion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblDeduccion.Location = New System.Drawing.Point(399, 11)
        Me.LblDeduccion.Name = "LblDeduccion"
        Me.LblDeduccion.Size = New System.Drawing.Size(16, 16)
        Me.LblDeduccion.TabIndex = 35
        Me.LblDeduccion.Text = "D"
        Me.LblDeduccion.Visible = False
        '
        'ChxAutorizacionExp
        '
        Me.ChxAutorizacionExp.AutoSize = True
        Me.ChxAutorizacionExp.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChxAutorizacionExp.ForeColor = System.Drawing.Color.Red
        Me.ChxAutorizacionExp.Location = New System.Drawing.Point(393, 30)
        Me.ChxAutorizacionExp.Name = "ChxAutorizacionExp"
        Me.ChxAutorizacionExp.Size = New System.Drawing.Size(82, 20)
        Me.ChxAutorizacionExp.TabIndex = 0
        Me.ChxAutorizacionExp.Text = "Excepción"
        Me.ChxAutorizacionExp.UseVisualStyleBackColor = True
        Me.ChxAutorizacionExp.Visible = False
        '
        'GbxCondicionesdePag
        '
        Me.GbxCondicionesdePag.Controls.Add(Me.txtAguin)
        Me.GbxCondicionesdePag.Controls.Add(Me.Label27)
        Me.GbxCondicionesdePag.Controls.Add(Me.txtBonif)
        Me.GbxCondicionesdePag.Controls.Add(Me.Label28)
        Me.GbxCondicionesdePag.Controls.Add(Me.CbxPeriodo)
        Me.GbxCondicionesdePag.Controls.Add(Me.Label5)
        Me.GbxCondicionesdePag.Controls.Add(Me.NudPlazo)
        Me.GbxCondicionesdePag.Controls.Add(Me.Label3)
        Me.GbxCondicionesdePag.ForeColor = System.Drawing.Color.Navy
        Me.GbxCondicionesdePag.Location = New System.Drawing.Point(486, 23)
        Me.GbxCondicionesdePag.Name = "GbxCondicionesdePag"
        Me.GbxCondicionesdePag.Size = New System.Drawing.Size(268, 121)
        Me.GbxCondicionesdePag.TabIndex = 3
        Me.GbxCondicionesdePag.TabStop = False
        Me.GbxCondicionesdePag.Text = "Condición de Pago"
        '
        'txtAguin
        '
        Me.txtAguin.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtAguin.ForeColor = System.Drawing.Color.Navy
        Me.txtAguin.Location = New System.Drawing.Point(148, 87)
        Me.txtAguin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAguin.MaxLength = 7
        Me.txtAguin.Name = "txtAguin"
        Me.txtAguin.Size = New System.Drawing.Size(92, 22)
        Me.txtAguin.TabIndex = 3
        Me.txtAguin.Text = "0.00"
        Me.txtAguin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(8, 89)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(144, 16)
        Me.Label27.TabIndex = 45
        Me.Label27.Text = "Descuento en Aguinaldo:    $"
        '
        'txtBonif
        '
        Me.txtBonif.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtBonif.ForeColor = System.Drawing.Color.Navy
        Me.txtBonif.Location = New System.Drawing.Point(148, 57)
        Me.txtBonif.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBonif.MaxLength = 7
        Me.txtBonif.Name = "txtBonif"
        Me.txtBonif.Size = New System.Drawing.Size(92, 22)
        Me.txtBonif.TabIndex = 2
        Me.txtBonif.Text = "0.00"
        Me.txtBonif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(9, 57)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(143, 16)
        Me.Label28.TabIndex = 44
        Me.Label28.Text = "Descuento en Bonificación: $"
        '
        'CbxPeriodo
        '
        Me.CbxPeriodo.BackColor = System.Drawing.SystemColors.Info
        Me.CbxPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxPeriodo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CbxPeriodo.ForeColor = System.Drawing.Color.Navy
        Me.CbxPeriodo.FormattingEnabled = True
        Me.CbxPeriodo.Items.AddRange(New Object() {"QUINCENAL", "MENSUAL"})
        Me.CbxPeriodo.Location = New System.Drawing.Point(148, 24)
        Me.CbxPeriodo.Name = "CbxPeriodo"
        Me.CbxPeriodo.Size = New System.Drawing.Size(110, 24)
        Me.CbxPeriodo.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(101, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Periodo:"
        '
        'NudPlazo
        '
        Me.NudPlazo.BackColor = System.Drawing.SystemColors.Window
        Me.NudPlazo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudPlazo.ForeColor = System.Drawing.Color.Navy
        Me.NudPlazo.Location = New System.Drawing.Point(43, 24)
        Me.NudPlazo.Name = "NudPlazo"
        Me.NudPlazo.Size = New System.Drawing.Size(44, 22)
        Me.NudPlazo.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Plazo:"
        '
        'TxtValSol
        '
        Me.TxtValSol.BackColor = System.Drawing.SystemColors.Window
        Me.TxtValSol.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtValSol.ForeColor = System.Drawing.Color.Navy
        Me.TxtValSol.Location = New System.Drawing.Point(390, 51)
        Me.TxtValSol.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtValSol.MaxLength = 7
        Me.TxtValSol.Name = "TxtValSol"
        Me.TxtValSol.Size = New System.Drawing.Size(88, 22)
        Me.TxtValSol.TabIndex = 2
        Me.TxtValSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtValSol.Visible = False
        '
        'LblDisponible
        '
        Me.LblDisponible.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblDisponible.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDisponible.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.LblDisponible.ForeColor = System.Drawing.Color.Navy
        Me.LblDisponible.Location = New System.Drawing.Point(299, 25)
        Me.LblDisponible.Name = "LblDisponible"
        Me.LblDisponible.Size = New System.Drawing.Size(88, 20)
        Me.LblDisponible.TabIndex = 30
        Me.LblDisponible.Text = "0.00"
        Me.LblDisponible.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(204, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 16)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "Disponible Socio: $"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(10, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Codigo Buxis:"
        '
        'TxtCodigoBuxis
        '
        Me.TxtCodigoBuxis.BackColor = System.Drawing.Color.White
        Me.TxtCodigoBuxis.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoBuxis.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoBuxis.Location = New System.Drawing.Point(104, 23)
        Me.TxtCodigoBuxis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoBuxis.Name = "TxtCodigoBuxis"
        Me.TxtCodigoBuxis.Size = New System.Drawing.Size(72, 22)
        Me.TxtCodigoBuxis.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(10, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 16)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Codigo AS:"
        '
        'TxtCodigoAs
        '
        Me.TxtCodigoAs.BackColor = System.Drawing.Color.White
        Me.TxtCodigoAs.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoAs.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoAs.Location = New System.Drawing.Point(104, 47)
        Me.TxtCodigoAs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoAs.MaxLength = 6
        Me.TxtCodigoAs.Name = "TxtCodigoAs"
        Me.TxtCodigoAs.Size = New System.Drawing.Size(72, 22)
        Me.TxtCodigoAs.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(10, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "División:"
        '
        'TxtDivision
        '
        Me.TxtDivision.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDivision.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDivision.ForeColor = System.Drawing.Color.Navy
        Me.TxtDivision.Location = New System.Drawing.Point(104, 122)
        Me.TxtDivision.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtDivision.Name = "TxtDivision"
        Me.TxtDivision.ReadOnly = True
        Me.TxtDivision.Size = New System.Drawing.Size(376, 22)
        Me.TxtDivision.TabIndex = 0
        Me.TxtDivision.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(10, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Departamento:"
        '
        'TxtDepartamento
        '
        Me.TxtDepartamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDepartamento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDepartamento.ForeColor = System.Drawing.Color.Navy
        Me.TxtDepartamento.Location = New System.Drawing.Point(104, 98)
        Me.TxtDepartamento.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtDepartamento.Name = "TxtDepartamento"
        Me.TxtDepartamento.ReadOnly = True
        Me.TxtDepartamento.Size = New System.Drawing.Size(376, 22)
        Me.TxtDepartamento.TabIndex = 0
        Me.TxtDepartamento.TabStop = False
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.ForeColor = System.Drawing.Color.Navy
        Me.TxtNombre.Location = New System.Drawing.Point(104, 73)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(376, 22)
        Me.TxtNombre.TabIndex = 0
        Me.TxtNombre.TabStop = False
        '
        'BtnBuscarSocio
        '
        Me.BtnBuscarSocio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarSocio.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSocio.Image = CType(resources.GetObject("BtnBuscarSocio.Image"), System.Drawing.Image)
        Me.BtnBuscarSocio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarSocio.Location = New System.Drawing.Point(177, 23)
        Me.BtnBuscarSocio.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnBuscarSocio.Name = "BtnBuscarSocio"
        Me.BtnBuscarSocio.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarSocio.TabIndex = 1
        Me.BtnBuscarSocio.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolTip1.SetToolTip(Me.BtnBuscarSocio, "Buscar Socio")
        Me.BtnBuscarSocio.UseVisualStyleBackColor = True
        '
        'BtnNueva
        '
        Me.BtnNueva.BackColor = System.Drawing.Color.Transparent
        Me.BtnNueva.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnNueva.ForeColor = System.Drawing.Color.Black
        Me.BtnNueva.Image = CType(resources.GetObject("BtnNueva.Image"), System.Drawing.Image)
        Me.BtnNueva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNueva.Location = New System.Drawing.Point(288, 37)
        Me.BtnNueva.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnNueva.Name = "BtnNueva"
        Me.BtnNueva.Size = New System.Drawing.Size(72, 24)
        Me.BtnNueva.TabIndex = 5
        Me.BtnNueva.Text = "&Nueva"
        Me.BtnNueva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnNueva, "Limpia los campos para ingresar nueva solicitud")
        Me.BtnNueva.UseVisualStyleBackColor = False
        '
        'DpFechaSol
        '
        Me.DpFechaSol.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.DpFechaSol.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaSol.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DpFechaSol.Location = New System.Drawing.Point(556, 38)
        Me.DpFechaSol.Name = "DpFechaSol"
        Me.DpFechaSol.Size = New System.Drawing.Size(87, 22)
        Me.DpFechaSol.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(451, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 16)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Fecha de Solicitud:"
        '
        'BtnBuscarSol
        '
        Me.BtnBuscarSol.BackColor = System.Drawing.Color.Transparent
        Me.BtnBuscarSol.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscarSol.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSol.Image = CType(resources.GetObject("BtnBuscarSol.Image"), System.Drawing.Image)
        Me.BtnBuscarSol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSol.Location = New System.Drawing.Point(200, 37)
        Me.BtnBuscarSol.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscarSol.Name = "BtnBuscarSol"
        Me.BtnBuscarSol.Size = New System.Drawing.Size(72, 24)
        Me.BtnBuscarSol.TabIndex = 2
        Me.BtnBuscarSol.Text = "Buscar"
        Me.BtnBuscarSol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnBuscarSol, "Buscar solicitud guardada previamente")
        Me.BtnBuscarSol.UseVisualStyleBackColor = False
        '
        'TxtNumeroSol
        '
        Me.TxtNumeroSol.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtNumeroSol.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroSol.ForeColor = System.Drawing.Color.Red
        Me.TxtNumeroSol.Location = New System.Drawing.Point(114, 37)
        Me.TxtNumeroSol.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNumeroSol.Name = "TxtNumeroSol"
        Me.TxtNumeroSol.ReadOnly = True
        Me.TxtNumeroSol.Size = New System.Drawing.Size(74, 22)
        Me.TxtNumeroSol.TabIndex = 13
        Me.TxtNumeroSol.Text = "0"
        Me.TxtNumeroSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GbxCotizacion
        '
        Me.GbxCotizacion.BackColor = System.Drawing.Color.Transparent
        Me.GbxCotizacion.Controls.Add(Me.lblOC)
        Me.GbxCotizacion.Controls.Add(Me.Label4)
        Me.GbxCotizacion.Controls.Add(Me.btnGenerarOC)
        Me.GbxCotizacion.Controls.Add(Me.btnNvoDetalle)
        Me.GbxCotizacion.Controls.Add(Me.Label25)
        Me.GbxCotizacion.Controls.Add(Me.Label26)
        Me.GbxCotizacion.Controls.Add(Me.Label24)
        Me.GbxCotizacion.Controls.Add(Me.DtpFechaCotiza)
        Me.GbxCotizacion.Controls.Add(Me.DgCotizacion)
        Me.GbxCotizacion.Controls.Add(Me.BtnEliminar)
        Me.GbxCotizacion.Controls.Add(Me.ChkEs_Factura)
        Me.GbxCotizacion.Controls.Add(Me.Label7)
        Me.GbxCotizacion.Controls.Add(Me.BtnAgregar)
        Me.GbxCotizacion.Controls.Add(Me.Label16)
        Me.GbxCotizacion.Controls.Add(Me.TxtDescripcion)
        Me.GbxCotizacion.Controls.Add(Me.TxtIVACotizacion)
        Me.GbxCotizacion.Controls.Add(Me.TxtValUnitario)
        Me.GbxCotizacion.Controls.Add(Me.Label17)
        Me.GbxCotizacion.Controls.Add(Me.TxtCantidad)
        Me.GbxCotizacion.Controls.Add(Me.TxtNumCotizacion)
        Me.GbxCotizacion.Controls.Add(Me.TxtSubTotalCotizacion)
        Me.GbxCotizacion.Controls.Add(Me.BtnBuscarProv)
        Me.GbxCotizacion.Controls.Add(Me.Label18)
        Me.GbxCotizacion.Controls.Add(Me.TxtProveedor)
        Me.GbxCotizacion.Controls.Add(Me.LblTitulos)
        Me.GbxCotizacion.Controls.Add(Me.Label23)
        Me.GbxCotizacion.Controls.Add(Me.TxtTotalCotizacion)
        Me.GbxCotizacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCotizacion.ForeColor = System.Drawing.Color.Navy
        Me.GbxCotizacion.Location = New System.Drawing.Point(8, 223)
        Me.GbxCotizacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCotizacion.Name = "GbxCotizacion"
        Me.GbxCotizacion.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCotizacion.Size = New System.Drawing.Size(760, 234)
        Me.GbxCotizacion.TabIndex = 3
        Me.GbxCotizacion.TabStop = False
        Me.GbxCotizacion.Text = "Ingreso de Cotización"
        '
        'lblOC
        '
        Me.lblOC.AutoSize = True
        Me.lblOC.Location = New System.Drawing.Point(714, 52)
        Me.lblOC.Name = "lblOC"
        Me.lblOC.Size = New System.Drawing.Size(14, 16)
        Me.lblOC.TabIndex = 43
        Me.lblOC.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(614, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Orden de Compra #"
        '
        'btnGenerarOC
        '
        Me.btnGenerarOC.Location = New System.Drawing.Point(601, 73)
        Me.btnGenerarOC.Name = "btnGenerarOC"
        Me.btnGenerarOC.Size = New System.Drawing.Size(153, 23)
        Me.btnGenerarOC.TabIndex = 42
        Me.btnGenerarOC.Text = "Generar Orden Compra"
        Me.btnGenerarOC.UseVisualStyleBackColor = True
        '
        'btnNvoDetalle
        '
        Me.btnNvoDetalle.BackColor = System.Drawing.Color.Transparent
        Me.btnNvoDetalle.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNvoDetalle.ForeColor = System.Drawing.Color.Black
        Me.btnNvoDetalle.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.btnNvoDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNvoDetalle.Location = New System.Drawing.Point(535, 73)
        Me.btnNvoDetalle.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnNvoDetalle.Name = "btnNvoDetalle"
        Me.btnNvoDetalle.Size = New System.Drawing.Size(24, 24)
        Me.btnNvoDetalle.TabIndex = 41
        Me.btnNvoDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnNvoDetalle, "Limpia campos detalle para ingresar nuevo")
        Me.btnNvoDetalle.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(598, 197)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(46, 16)
        Me.Label25.TabIndex = 38
        Me.Label25.Text = "TOTAL:"
        Me.Label25.Visible = False
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.SteelBlue
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Navy
        Me.Label26.Location = New System.Drawing.Point(426, 49)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(111, 20)
        Me.Label26.TabIndex = 40
        Me.Label26.Text = "Pre./Unit Sin IVA"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(598, 167)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 16)
        Me.Label24.TabIndex = 37
        Me.Label24.Text = "IVA:"
        Me.Label24.Visible = False
        '
        'DtpFechaCotiza
        '
        Me.DtpFechaCotiza.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.DtpFechaCotiza.CalendarTitleForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.DtpFechaCotiza.Checked = False
        Me.DtpFechaCotiza.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaCotiza.Location = New System.Drawing.Point(295, 22)
        Me.DtpFechaCotiza.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DtpFechaCotiza.MinDate = New Date(1999, 12, 26, 0, 0, 0, 0)
        Me.DtpFechaCotiza.Name = "DtpFechaCotiza"
        Me.DtpFechaCotiza.Size = New System.Drawing.Size(90, 22)
        Me.DtpFechaCotiza.TabIndex = 1
        '
        'DgCotizacion
        '
        Me.DgCotizacion.AllowUserToAddRows = False
        Me.DgCotizacion.AllowUserToDeleteRows = False
        Me.DgCotizacion.AllowUserToResizeColumns = False
        Me.DgCotizacion.AllowUserToResizeRows = False
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgCotizacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle17
        Me.DgCotizacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DgCotizacion.BackgroundColor = System.Drawing.Color.MintCream
        Me.DgCotizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgCotizacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.DgCotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgCotizacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cantidad, Me.descripcion, Me.PrecUnit, Me.SubTotal, Me.lineadetalle, Me.nueva, Me.modificada})
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgCotizacion.DefaultCellStyle = DataGridViewCellStyle23
        Me.DgCotizacion.Location = New System.Drawing.Point(7, 102)
        Me.DgCotizacion.MultiSelect = False
        Me.DgCotizacion.Name = "DgCotizacion"
        Me.DgCotizacion.ReadOnly = True
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgCotizacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.DgCotizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgCotizacion.Size = New System.Drawing.Size(581, 129)
        Me.DgCotizacion.TabIndex = 10
        '
        'cantidad
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cantidad.DefaultCellStyle = DataGridViewCellStyle19
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        Me.cantidad.Width = 70
        '
        'descripcion
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.descripcion.DefaultCellStyle = DataGridViewCellStyle20
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 260
        '
        'PrecUnit
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PrecUnit.DefaultCellStyle = DataGridViewCellStyle21
        Me.PrecUnit.HeaderText = "Precio Unitario"
        Me.PrecUnit.Name = "PrecUnit"
        Me.PrecUnit.ReadOnly = True
        '
        'SubTotal
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SubTotal.DefaultCellStyle = DataGridViewCellStyle22
        Me.SubTotal.HeaderText = "Sub Total"
        Me.SubTotal.Name = "SubTotal"
        Me.SubTotal.ReadOnly = True
        '
        'lineadetalle
        '
        Me.lineadetalle.HeaderText = "Linea Detalle"
        Me.lineadetalle.Name = "lineadetalle"
        Me.lineadetalle.ReadOnly = True
        Me.lineadetalle.Visible = False
        Me.lineadetalle.Width = 40
        '
        'nueva
        '
        Me.nueva.HeaderText = "nueva"
        Me.nueva.Name = "nueva"
        Me.nueva.ReadOnly = True
        Me.nueva.Visible = False
        Me.nueva.Width = 50
        '
        'modificada
        '
        Me.modificada.HeaderText = "modificada"
        Me.modificada.Name = "modificada"
        Me.modificada.ReadOnly = True
        Me.modificada.Visible = False
        Me.modificada.Width = 50
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.Color.Transparent
        Me.BtnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnEliminar.ForeColor = System.Drawing.Color.Black
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(563, 73)
        Me.BtnEliminar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(24, 24)
        Me.BtnEliminar.TabIndex = 7
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnEliminar, "Eliminar una linea de detalle")
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'ChkEs_Factura
        '
        Me.ChkEs_Factura.AutoSize = True
        Me.ChkEs_Factura.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkEs_Factura.Checked = True
        Me.ChkEs_Factura.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEs_Factura.Location = New System.Drawing.Point(541, 49)
        Me.ChkEs_Factura.Name = "ChkEs_Factura"
        Me.ChkEs_Factura.Size = New System.Drawing.Size(67, 20)
        Me.ChkEs_Factura.TabIndex = 8
        Me.ChkEs_Factura.Text = "Factura"
        Me.ToolTip1.SetToolTip(Me.ChkEs_Factura, "No Chequeado es CCF.")
        Me.ChkEs_Factura.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(596, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Sub Total:"
        Me.Label7.Visible = False
        '
        'BtnAgregar
        '
        Me.BtnAgregar.BackColor = System.Drawing.Color.Transparent
        Me.BtnAgregar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnAgregar.ForeColor = System.Drawing.Color.Black
        Me.BtnAgregar.Image = Global.ASTAS.My.Resources.Resources.down
        Me.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAgregar.Location = New System.Drawing.Point(507, 73)
        Me.BtnAgregar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(24, 24)
        Me.BtnAgregar.TabIndex = 6
        Me.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnAgregar, "Guarda el nuevo item ingresado")
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(182, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 16)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Fecha de Cotización:"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDescripcion.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtDescripcion.ForeColor = System.Drawing.Color.Navy
        Me.TxtDescripcion.Location = New System.Drawing.Point(62, 74)
        Me.TxtDescripcion.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtDescripcion.MaxLength = 150
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(360, 22)
        Me.TxtDescripcion.TabIndex = 4
        '
        'TxtIVACotizacion
        '
        Me.TxtIVACotizacion.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIVACotizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIVACotizacion.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIVACotizacion.ForeColor = System.Drawing.Color.Blue
        Me.TxtIVACotizacion.Location = New System.Drawing.Point(658, 160)
        Me.TxtIVACotizacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtIVACotizacion.MaxLength = 7
        Me.TxtIVACotizacion.Name = "TxtIVACotizacion"
        Me.TxtIVACotizacion.ReadOnly = True
        Me.TxtIVACotizacion.Size = New System.Drawing.Size(96, 25)
        Me.TxtIVACotizacion.TabIndex = 36
        Me.TxtIVACotizacion.Text = "0.00"
        Me.TxtIVACotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtIVACotizacion.Visible = False
        '
        'TxtValUnitario
        '
        Me.TxtValUnitario.BackColor = System.Drawing.SystemColors.Window
        Me.TxtValUnitario.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtValUnitario.ForeColor = System.Drawing.Color.Navy
        Me.TxtValUnitario.Location = New System.Drawing.Point(422, 74)
        Me.TxtValUnitario.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtValUnitario.Name = "TxtValUnitario"
        Me.TxtValUnitario.Size = New System.Drawing.Size(80, 22)
        Me.TxtValUnitario.TabIndex = 5
        Me.TxtValUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(8, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 16)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "N° de Cotización:"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCantidad.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCantidad.ForeColor = System.Drawing.Color.Navy
        Me.TxtCantidad.Location = New System.Drawing.Point(6, 74)
        Me.TxtCantidad.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(56, 22)
        Me.TxtCantidad.TabIndex = 3
        Me.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtNumCotizacion
        '
        Me.TxtNumCotizacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumCotizacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNumCotizacion.Location = New System.Drawing.Point(98, 22)
        Me.TxtNumCotizacion.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtNumCotizacion.MaxLength = 15
        Me.TxtNumCotizacion.Name = "TxtNumCotizacion"
        Me.TxtNumCotizacion.Size = New System.Drawing.Size(78, 22)
        Me.TxtNumCotizacion.TabIndex = 0
        '
        'TxtSubTotalCotizacion
        '
        Me.TxtSubTotalCotizacion.AcceptsReturn = True
        Me.TxtSubTotalCotizacion.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSubTotalCotizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSubTotalCotizacion.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubTotalCotizacion.ForeColor = System.Drawing.Color.Blue
        Me.TxtSubTotalCotizacion.Location = New System.Drawing.Point(658, 127)
        Me.TxtSubTotalCotizacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtSubTotalCotizacion.MaxLength = 7
        Me.TxtSubTotalCotizacion.Name = "TxtSubTotalCotizacion"
        Me.TxtSubTotalCotizacion.ReadOnly = True
        Me.TxtSubTotalCotizacion.Size = New System.Drawing.Size(96, 25)
        Me.TxtSubTotalCotizacion.TabIndex = 35
        Me.TxtSubTotalCotizacion.Text = "0.00"
        Me.TxtSubTotalCotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnBuscarProv
        '
        Me.BtnBuscarProv.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarProv.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarProv.Image = CType(resources.GetObject("BtnBuscarProv.Image"), System.Drawing.Image)
        Me.BtnBuscarProv.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarProv.Location = New System.Drawing.Point(720, 20)
        Me.BtnBuscarProv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscarProv.Name = "BtnBuscarProv"
        Me.BtnBuscarProv.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarProv.TabIndex = 2
        Me.BtnBuscarProv.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolTip1.SetToolTip(Me.BtnBuscarProv, "Buscar proveedor")
        Me.BtnBuscarProv.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(400, 24)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 16)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Proveedor:"
        '
        'TxtProveedor
        '
        Me.TxtProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtProveedor.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor.Location = New System.Drawing.Point(468, 21)
        Me.TxtProveedor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.ReadOnly = True
        Me.TxtProveedor.Size = New System.Drawing.Size(248, 22)
        Me.TxtProveedor.TabIndex = 8
        '
        'LblTitulos
        '
        Me.LblTitulos.BackColor = System.Drawing.Color.SteelBlue
        Me.LblTitulos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulos.ForeColor = System.Drawing.Color.Navy
        Me.LblTitulos.Location = New System.Drawing.Point(10, 49)
        Me.LblTitulos.Name = "LblTitulos"
        Me.LblTitulos.Size = New System.Drawing.Size(416, 20)
        Me.LblTitulos.TabIndex = 0
        Me.LblTitulos.Text = "Cantidad                                         Descripción                     " & _
            "                                            "
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Navy
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Yellow
        Me.Label23.Location = New System.Drawing.Point(601, 101)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(153, 22)
        Me.Label23.TabIndex = 34
        Me.Label23.Text = "Total Cotización"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTotalCotizacion
        '
        Me.TxtTotalCotizacion.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTotalCotizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotalCotizacion.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalCotizacion.ForeColor = System.Drawing.Color.Blue
        Me.TxtTotalCotizacion.Location = New System.Drawing.Point(658, 191)
        Me.TxtTotalCotizacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTotalCotizacion.MaxLength = 7
        Me.TxtTotalCotizacion.Name = "TxtTotalCotizacion"
        Me.TxtTotalCotizacion.ReadOnly = True
        Me.TxtTotalCotizacion.Size = New System.Drawing.Size(96, 25)
        Me.TxtTotalCotizacion.TabIndex = 33
        Me.TxtTotalCotizacion.Text = "0.00"
        Me.TxtTotalCotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTotalCotizacion.Visible = False
        '
        'CbxSolicitudes
        '
        Me.CbxSolicitudes.BackColor = System.Drawing.SystemColors.Info
        Me.CbxSolicitudes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxSolicitudes.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CbxSolicitudes.ForeColor = System.Drawing.Color.Navy
        Me.CbxSolicitudes.FormattingEnabled = True
        Me.CbxSolicitudes.Location = New System.Drawing.Point(114, 5)
        Me.CbxSolicitudes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxSolicitudes.Name = "CbxSolicitudes"
        Me.CbxSolicitudes.Size = New System.Drawing.Size(225, 24)
        Me.CbxSolicitudes.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(18, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 16)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "N° Solicitud:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(18, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo de Solicitud:"
        '
        'TbpHojaDatos
        '
        Me.TbpHojaDatos.BackColor = System.Drawing.SystemColors.Control
        Me.TbpHojaDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TbpHojaDatos.Location = New System.Drawing.Point(4, 28)
        Me.TbpHojaDatos.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TbpHojaDatos.Name = "TbpHojaDatos"
        Me.TbpHojaDatos.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TbpHojaDatos.Size = New System.Drawing.Size(776, 603)
        Me.TbpHojaDatos.TabIndex = 1
        '
        'txtMotivoBloqueo
        '
        Me.txtMotivoBloqueo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtMotivoBloqueo.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivoBloqueo.ForeColor = System.Drawing.Color.Teal
        Me.txtMotivoBloqueo.Location = New System.Drawing.Point(401, 464)
        Me.txtMotivoBloqueo.Multiline = True
        Me.txtMotivoBloqueo.Name = "txtMotivoBloqueo"
        Me.txtMotivoBloqueo.ReadOnly = True
        Me.txtMotivoBloqueo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMotivoBloqueo.Size = New System.Drawing.Size(365, 130)
        Me.txtMotivoBloqueo.TabIndex = 38
        Me.txtMotivoBloqueo.Visible = False
        '
        'FrmSolicitudesCotizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 646)
        Me.Controls.Add(Me.TbcSolicitudes)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmSolicitudesCotizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Solicitudes con Cotización"
        Me.TbcSolicitudes.ResumeLayout(False)
        Me.TbpSolicitud.ResumeLayout(False)
        Me.TbpSolicitud.PerformLayout()
        Me.gbFiadores.ResumeLayout(False)
        Me.gbFiadores.PerformLayout()
        CType(Me.dgvFiadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxDatos.ResumeLayout(False)
        Me.GbxDatos.PerformLayout()
        Me.GbxCondicionesdePag.ResumeLayout(False)
        Me.GbxCondicionesdePag.PerformLayout()
        CType(Me.NudPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxCotizacion.ResumeLayout(False)
        Me.GbxCotizacion.PerformLayout()
        CType(Me.DgCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TbcSolicitudes As System.Windows.Forms.TabControl
    Friend WithEvents TbpSolicitud As System.Windows.Forms.TabPage
    Friend WithEvents GbxDatos As System.Windows.Forms.GroupBox
    Friend WithEvents TbpHojaDatos As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarSocio As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbxSolicitudes As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDivision As System.Windows.Forms.TextBox
    Friend WithEvents GbxCondicionesdePag As System.Windows.Forms.GroupBox
    Friend WithEvents CbxPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NudPlazo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GbxCotizacion As System.Windows.Forms.GroupBox
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents LblTitulos As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents DtpFechaCotiza As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtValUnitario As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtNumCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscarProv As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoBuxis As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoAs As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumeroSol As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscarSol As System.Windows.Forms.Button
    Friend WithEvents TxtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents LblDisponible As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents LblMontoMax As System.Windows.Forms.Label
    Friend WithEvents LblTituloMonto As System.Windows.Forms.Label
    Friend WithEvents DgCotizacion As System.Windows.Forms.DataGridView
    Friend WithEvents DpFechaSol As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents BtnNueva As System.Windows.Forms.Button
    Friend WithEvents TxtValSol As System.Windows.Forms.TextBox
    Friend WithEvents TxtInteres As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblDeduccion As System.Windows.Forms.Label
    Friend WithEvents ChxAutorizacionExp As System.Windows.Forms.CheckBox
    Friend WithEvents TxtTotalCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblIndemnizacion As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtIVACotizacion As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubTotalCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents ChkEs_Factura As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAguin As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtBonif As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnNvoDetalle As System.Windows.Forms.Button
    Friend WithEvents btnGenerarOC As System.Windows.Forms.Button
    Friend WithEvents lblOC As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lineadetalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nueva As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents modificada As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents gbFiadores As System.Windows.Forms.GroupBox
    Friend WithEvents btnFiadores As System.Windows.Forms.Button
    Friend WithEvents txtDeudaFiador As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreFiador As System.Windows.Forms.TextBox
    Friend WithEvents txtCodFiador As System.Windows.Forms.TextBox
    Friend WithEvents dgvFiadores As System.Windows.Forms.DataGridView
    Friend WithEvents codfia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombfia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totdeuda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents elimfia As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents txtMotivoBloqueo As System.Windows.Forms.TextBox
End Class
