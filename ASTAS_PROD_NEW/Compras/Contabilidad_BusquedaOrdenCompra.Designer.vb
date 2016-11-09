<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_BusquedaOrdenCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_BusquedaOrdenCompra))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbAfectanInventarios = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkFechas = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.dpFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dpFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtNRC = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNIT = New System.Windows.Forms.TextBox
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.txtNOMBER_COMERCIAL = New System.Windows.Forms.TextBox
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.txtNOMBRE_PROVEEDOR = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtOC = New System.Windows.Forms.TextBox
        Me.dgvOrdenesCompra = New System.Windows.Forms.DataGridView
        Me.OC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaOC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Procesada = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Descripcion_Prov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombe_Leg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Numero_NIT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NRC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FormaPago = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CondicionPago = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Usuario_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvOrdenesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cbAfectanInventarios)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.chkFechas)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dpFechaHasta)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dpFechaDesde)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtNRC)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNIT)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.txtNOMBER_COMERCIAL)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.txtNOMBRE_PROVEEDOR)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtOC)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(828, 147)
        Me.GroupBox1.TabIndex = 84
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(68, 76)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(114, 16)
        Me.Label14.TabIndex = 112
        Me.Label14.Text = "Revisado 21/05/2014"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Teal
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(696, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 20)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "NRC"
        '
        'cbAfectanInventarios
        '
        Me.cbAfectanInventarios.AutoSize = True
        Me.cbAfectanInventarios.Checked = True
        Me.cbAfectanInventarios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAfectanInventarios.Enabled = False
        Me.cbAfectanInventarios.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cbAfectanInventarios.ForeColor = System.Drawing.Color.Black
        Me.cbAfectanInventarios.Location = New System.Drawing.Point(343, 52)
        Me.cbAfectanInventarios.Name = "cbAfectanInventarios"
        Me.cbAfectanInventarios.Size = New System.Drawing.Size(116, 20)
        Me.cbAfectanInventarios.TabIndex = 57
        Me.cbAfectanInventarios.Text = "Afectan Inventarios"
        Me.cbAfectanInventarios.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Teal
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(584, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 20)
        Me.Label7.TabIndex = 103
        Me.Label7.Text = "NIT"
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFechas.Checked = True
        Me.chkFechas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFechas.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.chkFechas.ForeColor = System.Drawing.Color.Red
        Me.chkFechas.Location = New System.Drawing.Point(544, 72)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(197, 20)
        Me.chkFechas.TabIndex = 56
        Me.chkFechas.Text = "No considerar Fechas en búsqueda"
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Teal
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(328, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(273, 20)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "Nombre Comercial"
        '
        'dpFechaHasta
        '
        Me.dpFechaHasta.CustomFormat = "dd-MMM-yyyy"
        Me.dpFechaHasta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaHasta.Location = New System.Drawing.Point(624, 48)
        Me.dpFechaHasta.Name = "dpFechaHasta"
        Me.dpFechaHasta.Size = New System.Drawing.Size(120, 22)
        Me.dpFechaHasta.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(8, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 20)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "N° OC"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(72, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(396, 20)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Nombre Proveedor"
        '
        'dpFechaDesde
        '
        Me.dpFechaDesde.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFechaDesde.CustomFormat = "dd-MMM-yyyy"
        Me.dpFechaDesde.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaDesde.Location = New System.Drawing.Point(624, 24)
        Me.dpFechaDesde.Name = "dpFechaDesde"
        Me.dpFechaDesde.Size = New System.Drawing.Size(120, 22)
        Me.dpFechaDesde.TabIndex = 54
        '
        'btnBuscar
        '
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(795, 119)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscar.TabIndex = 99
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(544, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 16)
        Me.Label17.TabIndex = 53
        Me.Label17.Text = "Hasta :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(544, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 16)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Desde :"
        '
        'txtNRC
        '
        Me.txtNRC.ForeColor = System.Drawing.Color.Navy
        Me.txtNRC.Location = New System.Drawing.Point(699, 119)
        Me.txtNRC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNRC.MaxLength = 20
        Me.txtNRC.Name = "txtNRC"
        Me.txtNRC.Size = New System.Drawing.Size(96, 22)
        Me.txtNRC.TabIndex = 97
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Bodega :"
        '
        'txtNIT
        '
        Me.txtNIT.ForeColor = System.Drawing.Color.Navy
        Me.txtNIT.Location = New System.Drawing.Point(587, 119)
        Me.txtNIT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNIT.MaxLength = 17
        Me.txtNIT.Name = "txtNIT"
        Me.txtNIT.Size = New System.Drawing.Size(112, 22)
        Me.txtNIT.TabIndex = 96
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(71, 48)
        Me.cmbBODEGA.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(265, 24)
        Me.cmbBODEGA.TabIndex = 1
        '
        'txtNOMBER_COMERCIAL
        '
        Me.txtNOMBER_COMERCIAL.ForeColor = System.Drawing.Color.Navy
        Me.txtNOMBER_COMERCIAL.Location = New System.Drawing.Point(331, 119)
        Me.txtNOMBER_COMERCIAL.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNOMBER_COMERCIAL.MaxLength = 200
        Me.txtNOMBER_COMERCIAL.Name = "txtNOMBER_COMERCIAL"
        Me.txtNOMBER_COMERCIAL.Size = New System.Drawing.Size(256, 22)
        Me.txtNOMBER_COMERCIAL.TabIndex = 95
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(72, 24)
        Me.cmbCOMPAÑIA.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(440, 24)
        Me.cmbCOMPAÑIA.TabIndex = 0
        '
        'txtNOMBRE_PROVEEDOR
        '
        Me.txtNOMBRE_PROVEEDOR.ForeColor = System.Drawing.Color.Navy
        Me.txtNOMBRE_PROVEEDOR.Location = New System.Drawing.Point(75, 119)
        Me.txtNOMBRE_PROVEEDOR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNOMBRE_PROVEEDOR.MaxLength = 200
        Me.txtNOMBRE_PROVEEDOR.Name = "txtNOMBRE_PROVEEDOR"
        Me.txtNOMBRE_PROVEEDOR.Size = New System.Drawing.Size(256, 22)
        Me.txtNOMBRE_PROVEEDOR.TabIndex = 95
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía :"
        '
        'txtOC
        '
        Me.txtOC.ForeColor = System.Drawing.Color.Navy
        Me.txtOC.Location = New System.Drawing.Point(11, 119)
        Me.txtOC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtOC.MaxLength = 200
        Me.txtOC.Name = "txtOC"
        Me.txtOC.Size = New System.Drawing.Size(64, 22)
        Me.txtOC.TabIndex = 94
        '
        'dgvOrdenesCompra
        '
        Me.dgvOrdenesCompra.AllowUserToAddRows = False
        Me.dgvOrdenesCompra.AllowUserToDeleteRows = False
        Me.dgvOrdenesCompra.AllowUserToResizeColumns = False
        Me.dgvOrdenesCompra.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvOrdenesCompra.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOrdenesCompra.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvOrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrdenesCompra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OC, Me.FechaOC, Me.Procesada, Me.Descripcion_Prov, Me.Nombe_Leg, Me.Numero_NIT, Me.NRC, Me.FormaPago, Me.CondicionPago, Me.Usuario_Creacion, Me.Fecha_Creacion})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOrdenesCompra.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvOrdenesCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOrdenesCompra.Location = New System.Drawing.Point(0, 147)
        Me.dgvOrdenesCompra.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvOrdenesCompra.Name = "dgvOrdenesCompra"
        Me.dgvOrdenesCompra.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOrdenesCompra.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvOrdenesCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrdenesCompra.Size = New System.Drawing.Size(828, 371)
        Me.dgvOrdenesCompra.TabIndex = 98
        '
        'OC
        '
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.OC.DefaultCellStyle = DataGridViewCellStyle2
        Me.OC.HeaderText = "Orden Compra"
        Me.OC.Name = "OC"
        Me.OC.ReadOnly = True
        '
        'FechaOC
        '
        Me.FechaOC.HeaderText = "Fecha OC"
        Me.FechaOC.Name = "FechaOC"
        Me.FechaOC.ReadOnly = True
        '
        'Procesada
        '
        Me.Procesada.HeaderText = "Procesada"
        Me.Procesada.Name = "Procesada"
        Me.Procesada.ReadOnly = True
        '
        'Descripcion_Prov
        '
        Me.Descripcion_Prov.HeaderText = "Nombre Proveedor"
        Me.Descripcion_Prov.Name = "Descripcion_Prov"
        Me.Descripcion_Prov.ReadOnly = True
        '
        'Nombe_Leg
        '
        Me.Nombe_Leg.HeaderText = "Nombre Legal"
        Me.Nombe_Leg.Name = "Nombe_Leg"
        Me.Nombe_Leg.ReadOnly = True
        '
        'Numero_NIT
        '
        Me.Numero_NIT.HeaderText = "NIT"
        Me.Numero_NIT.Name = "Numero_NIT"
        Me.Numero_NIT.ReadOnly = True
        '
        'NRC
        '
        Me.NRC.HeaderText = "Registro Fiscal"
        Me.NRC.Name = "NRC"
        Me.NRC.ReadOnly = True
        '
        'FormaPago
        '
        Me.FormaPago.HeaderText = "Forma Pago"
        Me.FormaPago.Name = "FormaPago"
        Me.FormaPago.ReadOnly = True
        '
        'CondicionPago
        '
        Me.CondicionPago.HeaderText = "Condición Pago"
        Me.CondicionPago.Name = "CondicionPago"
        Me.CondicionPago.ReadOnly = True
        '
        'Usuario_Creacion
        '
        Me.Usuario_Creacion.HeaderText = "Usuario Creación"
        Me.Usuario_Creacion.Name = "Usuario_Creacion"
        Me.Usuario_Creacion.ReadOnly = True
        '
        'Fecha_Creacion
        '
        Me.Fecha_Creacion.HeaderText = "Fecha Creación"
        Me.Fecha_Creacion.Name = "Fecha_Creacion"
        Me.Fecha_Creacion.ReadOnly = True
        '
        'Contabilidad_BusquedaOrdenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 518)
        Me.Controls.Add(Me.dgvOrdenesCompra)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_BusquedaOrdenCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas x Pagar - Búsqueda de Ordenes de Compra"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvOrdenesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkFechas As System.Windows.Forms.CheckBox
    Friend WithEvents dpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtOC As System.Windows.Forms.TextBox
    Friend WithEvents txtNOMBRE_PROVEEDOR As System.Windows.Forms.TextBox
    Friend WithEvents txtNOMBER_COMERCIAL As System.Windows.Forms.TextBox
    Friend WithEvents txtNIT As System.Windows.Forms.TextBox
    Friend WithEvents txtNRC As System.Windows.Forms.TextBox
    Friend WithEvents dgvOrdenesCompra As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cbAfectanInventarios As System.Windows.Forms.CheckBox
    Friend WithEvents OC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaOC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Procesada As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Descripcion_Prov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombe_Leg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero_NIT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NRC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormaPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CondicionPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Creacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Creacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
