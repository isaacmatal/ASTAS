<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguridad_Compañias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Seguridad_Compañias))
        Me.dgvCompañias = New System.Windows.Forms.DataGridView
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripción = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Direccion_C = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Telefonos_C = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Contribuyente_C = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TipoContribuyente_C = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RepreLegal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Logo_C = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NIT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NRC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsuarioC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtNIT = New System.Windows.Forms.MaskedTextBox
        Me.txtNRC = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtLOGO = New System.Windows.Forms.TextBox
        Me.txtREPRESENTANTE_LEGAL = New System.Windows.Forms.TextBox
        Me.cmbCONTRIBUYENTE = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnLogo = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.txtTELEFONOS = New System.Windows.Forms.TextBox
        Me.txtDIRECCION = New System.Windows.Forms.TextBox
        Me.txtDESCRIPCION_COMPAÑIA = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCOMPAÑIA = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.OpenFileDialogAbrir = New System.Windows.Forms.OpenFileDialog
        CType(Me.dgvCompañias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCompañias
        '
        Me.dgvCompañias.AllowUserToAddRows = False
        Me.dgvCompañias.AllowUserToDeleteRows = False
        Me.dgvCompañias.AllowUserToResizeColumns = False
        Me.dgvCompañias.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvCompañias.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCompañias.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCompañias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCompañias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompañias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripción, Me.Direccion_C, Me.Telefonos_C, Me.Contribuyente_C, Me.TipoContribuyente_C, Me.RepreLegal, Me.Logo_C, Me.NIT, Me.NRC, Me.UsuarioC, Me.FechaC})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCompañias.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCompañias.Location = New System.Drawing.Point(8, 216)
        Me.dgvCompañias.MultiSelect = False
        Me.dgvCompañias.Name = "dgvCompañias"
        Me.dgvCompañias.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCompañias.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCompañias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCompañias.Size = New System.Drawing.Size(760, 256)
        Me.dgvCompañias.TabIndex = 4
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        '
        'Descripción
        '
        Me.Descripción.HeaderText = "Compañía"
        Me.Descripción.Name = "Descripción"
        Me.Descripción.ReadOnly = True
        '
        'Direccion_C
        '
        Me.Direccion_C.HeaderText = "Dirección"
        Me.Direccion_C.Name = "Direccion_C"
        Me.Direccion_C.ReadOnly = True
        '
        'Telefonos_C
        '
        Me.Telefonos_C.HeaderText = "Teléfonos"
        Me.Telefonos_C.Name = "Telefonos_C"
        Me.Telefonos_C.ReadOnly = True
        '
        'Contribuyente_C
        '
        Me.Contribuyente_C.HeaderText = "Contribuyente"
        Me.Contribuyente_C.Name = "Contribuyente_C"
        Me.Contribuyente_C.ReadOnly = True
        '
        'TipoContribuyente_C
        '
        Me.TipoContribuyente_C.HeaderText = "Tipo Contribuyente"
        Me.TipoContribuyente_C.Name = "TipoContribuyente_C"
        Me.TipoContribuyente_C.ReadOnly = True
        '
        'RepreLegal
        '
        Me.RepreLegal.HeaderText = "Representante Legal"
        Me.RepreLegal.Name = "RepreLegal"
        Me.RepreLegal.ReadOnly = True
        '
        'Logo_C
        '
        Me.Logo_C.HeaderText = "Logo"
        Me.Logo_C.Name = "Logo_C"
        Me.Logo_C.ReadOnly = True
        '
        'NIT
        '
        Me.NIT.HeaderText = "NIT"
        Me.NIT.Name = "NIT"
        Me.NIT.ReadOnly = True
        '
        'NRC
        '
        Me.NRC.HeaderText = "NRC"
        Me.NRC.Name = "NRC"
        Me.NRC.ReadOnly = True
        '
        'UsuarioC
        '
        Me.UsuarioC.HeaderText = "Usuario Creación"
        Me.UsuarioC.Name = "UsuarioC"
        Me.UsuarioC.ReadOnly = True
        '
        'FechaC
        '
        Me.FechaC.HeaderText = "Fecha Creación"
        Me.FechaC.Name = "FechaC"
        Me.FechaC.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtNIT)
        Me.GroupBox1.Controls.Add(Me.txtNRC)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtLOGO)
        Me.GroupBox1.Controls.Add(Me.txtREPRESENTANTE_LEGAL)
        Me.GroupBox1.Controls.Add(Me.cmbCONTRIBUYENTE)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnLogo)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.txtTELEFONOS)
        Me.GroupBox1.Controls.Add(Me.txtDIRECCION)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION_COMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(586, 200)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Compañias"
        '
        'txtNIT
        '
        Me.txtNIT.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtNIT.ForeColor = System.Drawing.Color.Navy
        Me.txtNIT.Location = New System.Drawing.Point(107, 120)
        Me.txtNIT.Mask = "####-######-###-#"
        Me.txtNIT.Name = "txtNIT"
        Me.txtNIT.Size = New System.Drawing.Size(144, 22)
        Me.txtNIT.TabIndex = 29
        '
        'txtNRC
        '
        Me.txtNRC.BackColor = System.Drawing.SystemColors.Window
        Me.txtNRC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNRC.ForeColor = System.Drawing.Color.Navy
        Me.txtNRC.Location = New System.Drawing.Point(339, 120)
        Me.txtNRC.MaxLength = 17
        Me.txtNRC.Name = "txtNRC"
        Me.txtNRC.Size = New System.Drawing.Size(144, 22)
        Me.txtNRC.TabIndex = 28
        Me.txtNRC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(299, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 16)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Logo :"
        '
        'txtLOGO
        '
        Me.txtLOGO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtLOGO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLOGO.ForeColor = System.Drawing.Color.Navy
        Me.txtLOGO.Location = New System.Drawing.Point(339, 144)
        Me.txtLOGO.MaxLength = 100
        Me.txtLOGO.Name = "txtLOGO"
        Me.txtLOGO.ReadOnly = True
        Me.txtLOGO.Size = New System.Drawing.Size(120, 22)
        Me.txtLOGO.TabIndex = 0
        '
        'txtREPRESENTANTE_LEGAL
        '
        Me.txtREPRESENTANTE_LEGAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtREPRESENTANTE_LEGAL.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREPRESENTANTE_LEGAL.ForeColor = System.Drawing.Color.Navy
        Me.txtREPRESENTANTE_LEGAL.Location = New System.Drawing.Point(107, 168)
        Me.txtREPRESENTANTE_LEGAL.MaxLength = 100
        Me.txtREPRESENTANTE_LEGAL.Name = "txtREPRESENTANTE_LEGAL"
        Me.txtREPRESENTANTE_LEGAL.Size = New System.Drawing.Size(376, 22)
        Me.txtREPRESENTANTE_LEGAL.TabIndex = 0
        '
        'cmbCONTRIBUYENTE
        '
        Me.cmbCONTRIBUYENTE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCONTRIBUYENTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCONTRIBUYENTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCONTRIBUYENTE.ForeColor = System.Drawing.Color.Navy
        Me.cmbCONTRIBUYENTE.FormattingEnabled = True
        Me.cmbCONTRIBUYENTE.Location = New System.Drawing.Point(107, 144)
        Me.cmbCONTRIBUYENTE.Name = "cmbCONTRIBUYENTE"
        Me.cmbCONTRIBUYENTE.Size = New System.Drawing.Size(144, 24)
        Me.cmbCONTRIBUYENTE.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(8, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Rep. Legal :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(8, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Contribuyente:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(299, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 16)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "NRC :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(8, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 16)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "NIT :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(8, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Teléfonos :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(8, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Dirección :"
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(299, 24)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(72, 24)
        Me.btnNuevo.TabIndex = 10
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(411, 24)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(72, 24)
        Me.btnEliminar.TabIndex = 9
        Me.btnEliminar.Text = "&Eiminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnLogo
        '
        Me.btnLogo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnLogo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLogo.Image = CType(resources.GetObject("btnLogo.Image"), System.Drawing.Image)
        Me.btnLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogo.Location = New System.Drawing.Point(459, 144)
        Me.btnLogo.Name = "btnLogo"
        Me.btnLogo.Size = New System.Drawing.Size(24, 24)
        Me.btnLogo.TabIndex = 8
        Me.btnLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLogo.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(179, 24)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(72, 24)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtTELEFONOS
        '
        Me.txtTELEFONOS.BackColor = System.Drawing.SystemColors.Window
        Me.txtTELEFONOS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTELEFONOS.ForeColor = System.Drawing.Color.Navy
        Me.txtTELEFONOS.Location = New System.Drawing.Point(107, 96)
        Me.txtTELEFONOS.MaxLength = 100
        Me.txtTELEFONOS.Name = "txtTELEFONOS"
        Me.txtTELEFONOS.Size = New System.Drawing.Size(376, 22)
        Me.txtTELEFONOS.TabIndex = 0
        '
        'txtDIRECCION
        '
        Me.txtDIRECCION.BackColor = System.Drawing.SystemColors.Window
        Me.txtDIRECCION.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIRECCION.ForeColor = System.Drawing.Color.Navy
        Me.txtDIRECCION.Location = New System.Drawing.Point(107, 72)
        Me.txtDIRECCION.MaxLength = 200
        Me.txtDIRECCION.Name = "txtDIRECCION"
        Me.txtDIRECCION.Size = New System.Drawing.Size(464, 22)
        Me.txtDIRECCION.TabIndex = 0
        '
        'txtDESCRIPCION_COMPAÑIA
        '
        Me.txtDESCRIPCION_COMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION_COMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_COMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_COMPAÑIA.Location = New System.Drawing.Point(107, 48)
        Me.txtDESCRIPCION_COMPAÑIA.MaxLength = 200
        Me.txtDESCRIPCION_COMPAÑIA.Name = "txtDESCRIPCION_COMPAÑIA"
        Me.txtDESCRIPCION_COMPAÑIA.Size = New System.Drawing.Size(464, 22)
        Me.txtDESCRIPCION_COMPAÑIA.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Compañía :"
        '
        'txtCOMPAÑIA
        '
        Me.txtCOMPAÑIA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCOMPAÑIA.ForeColor = System.Drawing.Color.Red
        Me.txtCOMPAÑIA.Location = New System.Drawing.Point(107, 24)
        Me.txtCOMPAÑIA.Name = "txtCOMPAÑIA"
        Me.txtCOMPAÑIA.ReadOnly = True
        Me.txtCOMPAÑIA.Size = New System.Drawing.Size(72, 22)
        Me.txtCOMPAÑIA.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código :"
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(632, 8)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(136, 203)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 5
        Me.pbImagen.TabStop = False
        '
        'OpenFileDialogAbrir
        '
        Me.OpenFileDialogAbrir.Title = "Seleccione el Logo de la Compañia"
        '
        'Seguridad_Compañias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 476)
        Me.Controls.Add(Me.dgvCompañias)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pbImagen)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Seguridad_Compañias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguridad - Catálogo de Compañías"
        CType(Me.dgvCompañias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCompañias As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtDESCRIPCION_COMPAÑIA As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCOMPAÑIA As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTELEFONOS As System.Windows.Forms.TextBox
    Friend WithEvents txtDIRECCION As System.Windows.Forms.TextBox
    Friend WithEvents txtREPRESENTANTE_LEGAL As System.Windows.Forms.TextBox
    Friend WithEvents cmbCONTRIBUYENTE As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLOGO As System.Windows.Forms.TextBox
    Friend WithEvents btnLogo As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialogAbrir As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripción As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Direccion_C As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Telefonos_C As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Contribuyente_C As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoContribuyente_C As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepreLegal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Logo_C As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NRC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtNRC As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNIT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
