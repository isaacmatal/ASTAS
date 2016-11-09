<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSolicitudes
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
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSolicitudes))
        Me.TbcSolicitudes = New System.Windows.Forms.TabControl
        Me.TbpSolicitud = New System.Windows.Forms.TabPage
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.lblInteres = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.GbxDatos = New System.Windows.Forms.GroupBox
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
        Me.txtNumVale = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.LblIndemnizacion = New System.Windows.Forms.Label
        Me.LblDisponible = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtValVale = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCodigoBuxis = New System.Windows.Forms.TextBox
        Me.ChxAutorizacionExp = New System.Windows.Forms.CheckBox
        Me.GbxCondicionesdePag = New System.Windows.Forms.GroupBox
        Me.txtAguin = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtBonif = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CbxPeriodo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.NudPlazo = New System.Windows.Forms.NumericUpDown
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtDivision = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtDepartamento = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCodigoAs = New System.Windows.Forms.TextBox
        Me.BtnBuscarSocio = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblDeduccion = New System.Windows.Forms.Label
        Me.BtnBuscarSol = New System.Windows.Forms.Button
        Me.TxtNumeroSol = New System.Windows.Forms.TextBox
        Me.DpFechaSol = New System.Windows.Forms.DateTimePicker
        Me.CbxSolicitudes = New System.Windows.Forms.ComboBox
        Me.LblMontoMax = New System.Windows.Forms.Label
        Me.LblTituloMonto = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.BtnNueva = New System.Windows.Forms.Button
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.TbpHojaDatos = New System.Windows.Forms.TabPage
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtMotivoBloqueo = New System.Windows.Forms.TextBox
        Me.TbcSolicitudes.SuspendLayout()
        Me.TbpSolicitud.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxDatos.SuspendLayout()
        Me.gbFiadores.SuspendLayout()
        CType(Me.dgvFiadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxCondicionesdePag.SuspendLayout()
        CType(Me.NudPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbcSolicitudes
        '
        Me.TbcSolicitudes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TbcSolicitudes.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TbcSolicitudes.Controls.Add(Me.TbpSolicitud)
        Me.TbcSolicitudes.Controls.Add(Me.TbpHojaDatos)
        Me.TbcSolicitudes.HotTrack = True
        Me.TbcSolicitudes.Location = New System.Drawing.Point(12, 6)
        Me.TbcSolicitudes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TbcSolicitudes.Name = "TbcSolicitudes"
        Me.TbcSolicitudes.SelectedIndex = 0
        Me.TbcSolicitudes.Size = New System.Drawing.Size(848, 409)
        Me.TbcSolicitudes.TabIndex = 0
        '
        'TbpSolicitud
        '
        Me.TbpSolicitud.BackColor = System.Drawing.Color.Transparent
        Me.TbpSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TbpSolicitud.Controls.Add(Me.pbImagen)
        Me.TbpSolicitud.Controls.Add(Me.lblInteres)
        Me.TbpSolicitud.Controls.Add(Me.Label23)
        Me.TbpSolicitud.Controls.Add(Me.Label20)
        Me.TbpSolicitud.Controls.Add(Me.GbxDatos)
        Me.TbpSolicitud.Controls.Add(Me.BtnBuscarSol)
        Me.TbpSolicitud.Controls.Add(Me.TxtNumeroSol)
        Me.TbpSolicitud.Controls.Add(Me.DpFechaSol)
        Me.TbpSolicitud.Controls.Add(Me.CbxSolicitudes)
        Me.TbpSolicitud.Controls.Add(Me.LblMontoMax)
        Me.TbpSolicitud.Controls.Add(Me.LblTituloMonto)
        Me.TbpSolicitud.Controls.Add(Me.Label13)
        Me.TbpSolicitud.Controls.Add(Me.Label14)
        Me.TbpSolicitud.Controls.Add(Me.Label12)
        Me.TbpSolicitud.Controls.Add(Me.BtnNueva)
        Me.TbpSolicitud.Controls.Add(Me.BtnGuardar)
        Me.TbpSolicitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbpSolicitud.Location = New System.Drawing.Point(4, 28)
        Me.TbpSolicitud.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TbpSolicitud.Name = "TbpSolicitud"
        Me.TbpSolicitud.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TbpSolicitud.Size = New System.Drawing.Size(840, 377)
        Me.TbpSolicitud.TabIndex = 0
        Me.TbpSolicitud.Text = "Solicitud"
        '
        'pbImagen
        '
        Me.pbImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(754, 3)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(76, 81)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 5
        Me.pbImagen.TabStop = False
        '
        'lblInteres
        '
        Me.lblInteres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInteres.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblInteres.ForeColor = System.Drawing.Color.Navy
        Me.lblInteres.Location = New System.Drawing.Point(400, 15)
        Me.lblInteres.Name = "lblInteres"
        Me.lblInteres.Size = New System.Drawing.Size(38, 19)
        Me.lblInteres.TabIndex = 36
        Me.lblInteres.Text = "0.00"
        Me.lblInteres.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(534, 15)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(10, 16)
        Me.Label23.TabIndex = 35
        Me.Label23.Text = "$"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(347, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 16)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "% Interés:          "
        '
        'GbxDatos
        '
        Me.GbxDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxDatos.Controls.Add(Me.txtMotivoBloqueo)
        Me.GbxDatos.Controls.Add(Me.gbFiadores)
        Me.GbxDatos.Controls.Add(Me.txtNumVale)
        Me.GbxDatos.Controls.Add(Me.Label4)
        Me.GbxDatos.Controls.Add(Me.Label24)
        Me.GbxDatos.Controls.Add(Me.Label22)
        Me.GbxDatos.Controls.Add(Me.Label7)
        Me.GbxDatos.Controls.Add(Me.Label21)
        Me.GbxDatos.Controls.Add(Me.LblIndemnizacion)
        Me.GbxDatos.Controls.Add(Me.LblDisponible)
        Me.GbxDatos.Controls.Add(Me.Label18)
        Me.GbxDatos.Controls.Add(Me.TxtValVale)
        Me.GbxDatos.Controls.Add(Me.Label3)
        Me.GbxDatos.Controls.Add(Me.TxtCodigoBuxis)
        Me.GbxDatos.Controls.Add(Me.ChxAutorizacionExp)
        Me.GbxDatos.Controls.Add(Me.GbxCondicionesdePag)
        Me.GbxDatos.Controls.Add(Me.Label10)
        Me.GbxDatos.Controls.Add(Me.TxtDivision)
        Me.GbxDatos.Controls.Add(Me.Label11)
        Me.GbxDatos.Controls.Add(Me.TxtDepartamento)
        Me.GbxDatos.Controls.Add(Me.Label6)
        Me.GbxDatos.Controls.Add(Me.TxtNombre)
        Me.GbxDatos.Controls.Add(Me.Label1)
        Me.GbxDatos.Controls.Add(Me.TxtCodigoAs)
        Me.GbxDatos.Controls.Add(Me.BtnBuscarSocio)
        Me.GbxDatos.Controls.Add(Me.Label2)
        Me.GbxDatos.Controls.Add(Me.LblDeduccion)
        Me.GbxDatos.ForeColor = System.Drawing.Color.Navy
        Me.GbxDatos.Location = New System.Drawing.Point(21, 81)
        Me.GbxDatos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxDatos.Name = "GbxDatos"
        Me.GbxDatos.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxDatos.Size = New System.Drawing.Size(809, 287)
        Me.GbxDatos.TabIndex = 2
        Me.GbxDatos.TabStop = False
        Me.GbxDatos.Text = "Datos Generales"
        '
        'gbFiadores
        '
        Me.gbFiadores.Controls.Add(Me.btnFiadores)
        Me.gbFiadores.Controls.Add(Me.txtDeudaFiador)
        Me.gbFiadores.Controls.Add(Me.txtNombreFiador)
        Me.gbFiadores.Controls.Add(Me.txtCodFiador)
        Me.gbFiadores.Controls.Add(Me.dgvFiadores)
        Me.gbFiadores.ForeColor = System.Drawing.Color.Navy
        Me.gbFiadores.Location = New System.Drawing.Point(485, 147)
        Me.gbFiadores.Name = "gbFiadores"
        Me.gbFiadores.Size = New System.Drawing.Size(317, 137)
        Me.gbFiadores.TabIndex = 36
        Me.gbFiadores.TabStop = False
        Me.gbFiadores.Text = "Fiadores"
        '
        'btnFiadores
        '
        Me.btnFiadores.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnFiadores.ForeColor = System.Drawing.Color.Black
        Me.btnFiadores.Image = Global.ASTAS.My.Resources.Resources.down
        Me.btnFiadores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFiadores.Location = New System.Drawing.Point(287, 15)
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
        Me.txtDeudaFiador.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeudaFiador.ForeColor = System.Drawing.Color.Navy
        Me.txtDeudaFiador.Location = New System.Drawing.Point(224, 18)
        Me.txtDeudaFiador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDeudaFiador.MaxLength = 7
        Me.txtDeudaFiador.Name = "txtDeudaFiador"
        Me.txtDeudaFiador.ReadOnly = True
        Me.txtDeudaFiador.Size = New System.Drawing.Size(61, 20)
        Me.txtDeudaFiador.TabIndex = 42
        Me.txtDeudaFiador.Text = "0.00"
        Me.txtDeudaFiador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNombreFiador
        '
        Me.txtNombreFiador.BackColor = System.Drawing.Color.White
        Me.txtNombreFiador.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreFiador.ForeColor = System.Drawing.Color.Navy
        Me.txtNombreFiador.Location = New System.Drawing.Point(63, 18)
        Me.txtNombreFiador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNombreFiador.MaxLength = 9
        Me.txtNombreFiador.Name = "txtNombreFiador"
        Me.txtNombreFiador.ReadOnly = True
        Me.txtNombreFiador.Size = New System.Drawing.Size(158, 20)
        Me.txtNombreFiador.TabIndex = 56
        '
        'txtCodFiador
        '
        Me.txtCodFiador.Font = New System.Drawing.Font("Arial Narrow", 8.25!)
        Me.txtCodFiador.ForeColor = System.Drawing.Color.Navy
        Me.txtCodFiador.Location = New System.Drawing.Point(10, 18)
        Me.txtCodFiador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodFiador.MaxLength = 9
        Me.txtCodFiador.Name = "txtCodFiador"
        Me.txtCodFiador.Size = New System.Drawing.Size(50, 20)
        Me.txtCodFiador.TabIndex = 37
        '
        'dgvFiadores
        '
        Me.dgvFiadores.AllowUserToAddRows = False
        Me.dgvFiadores.AllowUserToDeleteRows = False
        Me.dgvFiadores.AllowUserToResizeColumns = False
        Me.dgvFiadores.AllowUserToResizeRows = False
        Me.dgvFiadores.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvFiadores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvFiadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFiadores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codfia, Me.nombfia, Me.totdeuda, Me.elimfia})
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFiadores.DefaultCellStyle = DataGridViewCellStyle20
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
        Me.dgvFiadores.Size = New System.Drawing.Size(298, 88)
        Me.dgvFiadores.TabIndex = 55
        '
        'codfia
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codfia.DefaultCellStyle = DataGridViewCellStyle17
        Me.codfia.HeaderText = "Código"
        Me.codfia.Name = "codfia"
        Me.codfia.ReadOnly = True
        Me.codfia.Width = 50
        '
        'nombfia
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.nombfia.DefaultCellStyle = DataGridViewCellStyle18
        Me.nombfia.HeaderText = "Nombre"
        Me.nombfia.Name = "nombfia"
        Me.nombfia.ReadOnly = True
        Me.nombfia.Width = 160
        '
        'totdeuda
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.totdeuda.DefaultCellStyle = DataGridViewCellStyle19
        Me.totdeuda.HeaderText = "Deuda"
        Me.totdeuda.Name = "totdeuda"
        Me.totdeuda.ReadOnly = True
        Me.totdeuda.Width = 60
        '
        'elimfia
        '
        Me.elimfia.HeaderText = "X"
        Me.elimfia.Name = "elimfia"
        Me.elimfia.ReadOnly = True
        Me.elimfia.Text = ""
        Me.elimfia.Width = 20
        '
        'txtNumVale
        '
        Me.txtNumVale.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtNumVale.ForeColor = System.Drawing.Color.Navy
        Me.txtNumVale.Location = New System.Drawing.Point(311, 79)
        Me.txtNumVale.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNumVale.MaxLength = 9
        Me.txtNumVale.Name = "txtNumVale"
        Me.txtNumVale.Size = New System.Drawing.Size(88, 22)
        Me.txtNumVale.TabIndex = 3
        Me.txtNumVale.Text = "0"
        Me.txtNumVale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(210, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Factura ó Vale No.:"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(299, 53)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(10, 16)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "$"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(369, 215)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(10, 16)
        Me.Label22.TabIndex = 34
        Me.Label22.Text = "$"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(90, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 16)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "$"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(8, 213)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 16)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "Indemnización:"
        '
        'LblIndemnizacion
        '
        Me.LblIndemnizacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblIndemnizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblIndemnizacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.LblIndemnizacion.ForeColor = System.Drawing.Color.Navy
        Me.LblIndemnizacion.Location = New System.Drawing.Point(102, 213)
        Me.LblIndemnizacion.Name = "LblIndemnizacion"
        Me.LblIndemnizacion.Size = New System.Drawing.Size(88, 22)
        Me.LblIndemnizacion.TabIndex = 32
        Me.LblIndemnizacion.Text = "0.00"
        Me.LblIndemnizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDisponible
        '
        Me.LblDisponible.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblDisponible.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDisponible.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDisponible.ForeColor = System.Drawing.Color.Navy
        Me.LblDisponible.Location = New System.Drawing.Point(382, 213)
        Me.LblDisponible.Name = "LblDisponible"
        Me.LblDisponible.Size = New System.Drawing.Size(88, 22)
        Me.LblDisponible.TabIndex = 0
        Me.LblDisponible.Text = "0.00"
        Me.LblDisponible.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(283, 215)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 16)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Disponible Socio:"
        '
        'TxtValVale
        '
        Me.TxtValVale.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtValVale.ForeColor = System.Drawing.Color.Navy
        Me.TxtValVale.Location = New System.Drawing.Point(311, 51)
        Me.TxtValVale.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtValVale.MaxLength = 7
        Me.TxtValVale.Name = "TxtValVale"
        Me.TxtValVale.Size = New System.Drawing.Size(88, 22)
        Me.TxtValVale.TabIndex = 2
        Me.TxtValVale.Text = "0.00"
        Me.TxtValVale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(9, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Codigo Buxis:"
        '
        'TxtCodigoBuxis
        '
        Me.TxtCodigoBuxis.BackColor = System.Drawing.Color.White
        Me.TxtCodigoBuxis.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCodigoBuxis.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoBuxis.Location = New System.Drawing.Point(102, 47)
        Me.TxtCodigoBuxis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoBuxis.Name = "TxtCodigoBuxis"
        Me.TxtCodigoBuxis.Size = New System.Drawing.Size(97, 22)
        Me.TxtCodigoBuxis.TabIndex = 0
        '
        'ChxAutorizacionExp
        '
        Me.ChxAutorizacionExp.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChxAutorizacionExp.ForeColor = System.Drawing.Color.Red
        Me.ChxAutorizacionExp.Location = New System.Drawing.Point(304, 20)
        Me.ChxAutorizacionExp.Name = "ChxAutorizacionExp"
        Me.ChxAutorizacionExp.Size = New System.Drawing.Size(81, 22)
        Me.ChxAutorizacionExp.TabIndex = 0
        Me.ChxAutorizacionExp.Text = "Excepción"
        Me.ChxAutorizacionExp.UseVisualStyleBackColor = True
        Me.ChxAutorizacionExp.Visible = False
        '
        'GbxCondicionesdePag
        '
        Me.GbxCondicionesdePag.Controls.Add(Me.txtAguin)
        Me.GbxCondicionesdePag.Controls.Add(Me.Label16)
        Me.GbxCondicionesdePag.Controls.Add(Me.txtBonif)
        Me.GbxCondicionesdePag.Controls.Add(Me.Label8)
        Me.GbxCondicionesdePag.Controls.Add(Me.CbxPeriodo)
        Me.GbxCondicionesdePag.Controls.Add(Me.Label5)
        Me.GbxCondicionesdePag.Controls.Add(Me.NudPlazo)
        Me.GbxCondicionesdePag.Controls.Add(Me.Label15)
        Me.GbxCondicionesdePag.ForeColor = System.Drawing.Color.Navy
        Me.GbxCondicionesdePag.Location = New System.Drawing.Point(485, 31)
        Me.GbxCondicionesdePag.Name = "GbxCondicionesdePag"
        Me.GbxCondicionesdePag.Size = New System.Drawing.Size(317, 113)
        Me.GbxCondicionesdePag.TabIndex = 5
        Me.GbxCondicionesdePag.TabStop = False
        Me.GbxCondicionesdePag.Text = "Condición de Pago"
        '
        'txtAguin
        '
        Me.txtAguin.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtAguin.ForeColor = System.Drawing.Color.Navy
        Me.txtAguin.Location = New System.Drawing.Point(168, 81)
        Me.txtAguin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAguin.MaxLength = 7
        Me.txtAguin.Name = "txtAguin"
        Me.txtAguin.Size = New System.Drawing.Size(92, 22)
        Me.txtAguin.TabIndex = 3
        Me.txtAguin.Text = "0.00"
        Me.txtAguin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(6, 83)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(138, 16)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Descuento en Aguinaldo:    "
        '
        'txtBonif
        '
        Me.txtBonif.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtBonif.ForeColor = System.Drawing.Color.Navy
        Me.txtBonif.Location = New System.Drawing.Point(168, 53)
        Me.txtBonif.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBonif.MaxLength = 7
        Me.txtBonif.Name = "txtBonif"
        Me.txtBonif.Size = New System.Drawing.Size(92, 22)
        Me.txtBonif.TabIndex = 2
        Me.txtBonif.Text = "0.00"
        Me.txtBonif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(7, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(137, 16)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Descuento en Bonificación: "
        '
        'CbxPeriodo
        '
        Me.CbxPeriodo.BackColor = System.Drawing.SystemColors.Info
        Me.CbxPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxPeriodo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CbxPeriodo.ForeColor = System.Drawing.Color.Navy
        Me.CbxPeriodo.FormattingEnabled = True
        Me.CbxPeriodo.ItemHeight = 16
        Me.CbxPeriodo.Items.AddRange(New Object() {"QUINCENAL", "MENSUAL"})
        Me.CbxPeriodo.Location = New System.Drawing.Point(168, 20)
        Me.CbxPeriodo.Name = "CbxPeriodo"
        Me.CbxPeriodo.Size = New System.Drawing.Size(139, 24)
        Me.CbxPeriodo.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(118, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Periodo:"
        '
        'NudPlazo
        '
        Me.NudPlazo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.NudPlazo.ForeColor = System.Drawing.Color.Navy
        Me.NudPlazo.Location = New System.Drawing.Point(50, 21)
        Me.NudPlazo.Maximum = New Decimal(New Integer() {168, 0, 0, 0})
        Me.NudPlazo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudPlazo.Name = "NudPlazo"
        Me.NudPlazo.Size = New System.Drawing.Size(44, 22)
        Me.NudPlazo.TabIndex = 0
        Me.NudPlazo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(7, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Plazo:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(9, 180)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "División:"
        '
        'TxtDivision
        '
        Me.TxtDivision.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDivision.Enabled = False
        Me.TxtDivision.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtDivision.ForeColor = System.Drawing.Color.Navy
        Me.TxtDivision.Location = New System.Drawing.Point(102, 180)
        Me.TxtDivision.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtDivision.Name = "TxtDivision"
        Me.TxtDivision.ReadOnly = True
        Me.TxtDivision.Size = New System.Drawing.Size(368, 22)
        Me.TxtDivision.TabIndex = 21
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(9, 147)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Departamento:"
        '
        'TxtDepartamento
        '
        Me.TxtDepartamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TxtDepartamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDepartamento.Enabled = False
        Me.TxtDepartamento.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtDepartamento.ForeColor = System.Drawing.Color.Navy
        Me.TxtDepartamento.Location = New System.Drawing.Point(102, 147)
        Me.TxtDepartamento.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtDepartamento.Name = "TxtDepartamento"
        Me.TxtDepartamento.ReadOnly = True
        Me.TxtDepartamento.Size = New System.Drawing.Size(368, 22)
        Me.TxtDepartamento.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(260, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Valor: "
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtNombre.Enabled = False
        Me.TxtNombre.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtNombre.ForeColor = System.Drawing.Color.Navy
        Me.TxtNombre.Location = New System.Drawing.Point(102, 114)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(368, 22)
        Me.TxtNombre.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo AS:"
        '
        'TxtCodigoAs
        '
        Me.TxtCodigoAs.BackColor = System.Drawing.Color.White
        Me.TxtCodigoAs.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCodigoAs.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoAs.Location = New System.Drawing.Point(102, 79)
        Me.TxtCodigoAs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoAs.MaxLength = 6
        Me.TxtCodigoAs.Name = "TxtCodigoAs"
        Me.TxtCodigoAs.Size = New System.Drawing.Size(97, 22)
        Me.TxtCodigoAs.TabIndex = 1
        '
        'BtnBuscarSocio
        '
        Me.BtnBuscarSocio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarSocio.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSocio.Image = CType(resources.GetObject("BtnBuscarSocio.Image"), System.Drawing.Image)
        Me.BtnBuscarSocio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSocio.Location = New System.Drawing.Point(204, 45)
        Me.BtnBuscarSocio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscarSocio.Name = "BtnBuscarSocio"
        Me.BtnBuscarSocio.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarSocio.TabIndex = 4
        Me.BtnBuscarSocio.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolTip1.SetToolTip(Me.BtnBuscarSocio, "Buscar Socio")
        Me.BtnBuscarSocio.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre del Socio:"
        '
        'LblDeduccion
        '
        Me.LblDeduccion.AutoSize = True
        Me.LblDeduccion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDeduccion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblDeduccion.Location = New System.Drawing.Point(261, 25)
        Me.LblDeduccion.Name = "LblDeduccion"
        Me.LblDeduccion.Size = New System.Drawing.Size(16, 16)
        Me.LblDeduccion.TabIndex = 0
        Me.LblDeduccion.Text = "D"
        Me.LblDeduccion.Visible = False
        '
        'BtnBuscarSol
        '
        Me.BtnBuscarSol.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscarSol.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSol.Image = CType(resources.GetObject("BtnBuscarSol.Image"), System.Drawing.Image)
        Me.BtnBuscarSol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSol.Location = New System.Drawing.Point(213, 46)
        Me.BtnBuscarSol.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscarSol.Name = "BtnBuscarSol"
        Me.BtnBuscarSol.Size = New System.Drawing.Size(72, 25)
        Me.BtnBuscarSol.TabIndex = 1
        Me.BtnBuscarSol.Text = "Buscar"
        Me.BtnBuscarSol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnBuscarSol, "Buscar solicitud guardada previamente")
        Me.BtnBuscarSol.UseVisualStyleBackColor = True
        '
        'TxtNumeroSol
        '
        Me.TxtNumeroSol.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtNumeroSol.Enabled = False
        Me.TxtNumeroSol.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroSol.ForeColor = System.Drawing.Color.Red
        Me.TxtNumeroSol.Location = New System.Drawing.Point(117, 46)
        Me.TxtNumeroSol.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNumeroSol.Name = "TxtNumeroSol"
        Me.TxtNumeroSol.ReadOnly = True
        Me.TxtNumeroSol.Size = New System.Drawing.Size(74, 22)
        Me.TxtNumeroSol.TabIndex = 14
        Me.TxtNumeroSol.Tag = ""
        Me.TxtNumeroSol.Text = "0"
        Me.TxtNumeroSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DpFechaSol
        '
        Me.DpFechaSol.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaSol.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.DpFechaSol.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DpFechaSol.Location = New System.Drawing.Point(639, 46)
        Me.DpFechaSol.Name = "DpFechaSol"
        Me.DpFechaSol.Size = New System.Drawing.Size(94, 22)
        Me.DpFechaSol.TabIndex = 2
        '
        'CbxSolicitudes
        '
        Me.CbxSolicitudes.BackColor = System.Drawing.SystemColors.Info
        Me.CbxSolicitudes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxSolicitudes.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxSolicitudes.ForeColor = System.Drawing.Color.Navy
        Me.CbxSolicitudes.FormattingEnabled = True
        Me.CbxSolicitudes.Location = New System.Drawing.Point(117, 12)
        Me.CbxSolicitudes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxSolicitudes.Name = "CbxSolicitudes"
        Me.CbxSolicitudes.Size = New System.Drawing.Size(225, 24)
        Me.CbxSolicitudes.TabIndex = 0
        '
        'LblMontoMax
        '
        Me.LblMontoMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblMontoMax.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.LblMontoMax.ForeColor = System.Drawing.Color.Navy
        Me.LblMontoMax.Location = New System.Drawing.Point(547, 15)
        Me.LblMontoMax.Name = "LblMontoMax"
        Me.LblMontoMax.Size = New System.Drawing.Size(88, 19)
        Me.LblMontoMax.TabIndex = 0
        Me.LblMontoMax.Text = "0.00"
        Me.LblMontoMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTituloMonto
        '
        Me.LblTituloMonto.AutoSize = True
        Me.LblTituloMonto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTituloMonto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblTituloMonto.Location = New System.Drawing.Point(444, 15)
        Me.LblTituloMonto.Name = "LblTituloMonto"
        Me.LblTituloMonto.Size = New System.Drawing.Size(97, 16)
        Me.LblTituloMonto.TabIndex = 0
        Me.LblTituloMonto.Text = "Máximo a otorgar: "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(540, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Fecha de Solicitud:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(29, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 16)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "N° Solicitud:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(29, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Tipo de Solicitud:"
        '
        'BtnNueva
        '
        Me.BtnNueva.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnNueva.ForeColor = System.Drawing.Color.Black
        Me.BtnNueva.Image = CType(resources.GetObject("BtnNueva.Image"), System.Drawing.Image)
        Me.BtnNueva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNueva.Location = New System.Drawing.Point(321, 46)
        Me.BtnNueva.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnNueva.Name = "BtnNueva"
        Me.BtnNueva.Size = New System.Drawing.Size(72, 24)
        Me.BtnNueva.TabIndex = 4
        Me.BtnNueva.Text = "&Nueva"
        Me.BtnNueva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnNueva, "Limpia los campos para ingresar nueva solicitud")
        Me.BtnNueva.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnGuardar.ForeColor = System.Drawing.Color.Black
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(429, 46)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(72, 24)
        Me.BtnGuardar.TabIndex = 3
        Me.BtnGuardar.Text = "&Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnGuardar, "Guarda la solicitud")
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'TbpHojaDatos
        '
        Me.TbpHojaDatos.BackColor = System.Drawing.Color.Transparent
        Me.TbpHojaDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TbpHojaDatos.Location = New System.Drawing.Point(4, 25)
        Me.TbpHojaDatos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TbpHojaDatos.Name = "TbpHojaDatos"
        Me.TbpHojaDatos.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TbpHojaDatos.Size = New System.Drawing.Size(840, 380)
        Me.TbpHojaDatos.TabIndex = 1
        '
        'txtMotivoBloqueo
        '
        Me.txtMotivoBloqueo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtMotivoBloqueo.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivoBloqueo.ForeColor = System.Drawing.Color.Teal
        Me.txtMotivoBloqueo.Location = New System.Drawing.Point(12, 238)
        Me.txtMotivoBloqueo.Multiline = True
        Me.txtMotivoBloqueo.Name = "txtMotivoBloqueo"
        Me.txtMotivoBloqueo.ReadOnly = True
        Me.txtMotivoBloqueo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMotivoBloqueo.Size = New System.Drawing.Size(458, 54)
        Me.txtMotivoBloqueo.TabIndex = 37
        Me.txtMotivoBloqueo.Visible = False
        '
        'FrmSolicitudes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(872, 417)
        Me.Controls.Add(Me.TbcSolicitudes)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmSolicitudes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = ""
        Me.Text = "Cooperativa - Solicitudes sin Cotización"
        Me.TbcSolicitudes.ResumeLayout(False)
        Me.TbpSolicitud.ResumeLayout(False)
        Me.TbpSolicitud.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxDatos.ResumeLayout(False)
        Me.GbxDatos.PerformLayout()
        Me.gbFiadores.ResumeLayout(False)
        Me.gbFiadores.PerformLayout()
        CType(Me.dgvFiadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxCondicionesdePag.ResumeLayout(False)
        Me.GbxCondicionesdePag.PerformLayout()
        CType(Me.NudPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TbcSolicitudes As System.Windows.Forms.TabControl
    Friend WithEvents TbpSolicitud As System.Windows.Forms.TabPage
    Friend WithEvents TbpHojaDatos As System.Windows.Forms.TabPage
    Friend WithEvents GbxDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoAs As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarSocio As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents GbxCondicionesdePag As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents NudPlazo As System.Windows.Forms.NumericUpDown
    Friend WithEvents CbxPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChxAutorizacionExp As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtDivision As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoBuxis As System.Windows.Forms.TextBox
    Friend WithEvents BtnNueva As System.Windows.Forms.Button
    Friend WithEvents TxtValVale As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumeroSol As System.Windows.Forms.TextBox
    Friend WithEvents CbxSolicitudes As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscarSol As System.Windows.Forms.Button
    Friend WithEvents LblDeduccion As System.Windows.Forms.Label
    Friend WithEvents LblMontoMax As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblTituloMonto As System.Windows.Forms.Label
    Friend WithEvents DpFechaSol As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblDisponible As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents LblIndemnizacion As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblInteres As System.Windows.Forms.Label
    Friend WithEvents txtAguin As System.Windows.Forms.TextBox
    Friend WithEvents txtBonif As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtNumVale As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbFiadores As System.Windows.Forms.GroupBox
    Friend WithEvents dgvFiadores As System.Windows.Forms.DataGridView
    Friend WithEvents txtCodFiador As System.Windows.Forms.TextBox
    Friend WithEvents txtDeudaFiador As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreFiador As System.Windows.Forms.TextBox
    Friend WithEvents btnFiadores As System.Windows.Forms.Button
    Friend WithEvents codfia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombfia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totdeuda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents elimfia As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents txtMotivoBloqueo As System.Windows.Forms.TextBox
End Class
