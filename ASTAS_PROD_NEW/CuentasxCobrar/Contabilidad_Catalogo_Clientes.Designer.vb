<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Catalogo_Clientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Catalogo_Clientes))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnNuevoCliente = New System.Windows.Forms.Button
        Me.btnGuardarCliente = New System.Windows.Forms.Button
        Me.btnBuscarCliente = New System.Windows.Forms.Button
        Me.btnEliminarCliente = New System.Windows.Forms.Button
        Me.btnNuevoContacto = New System.Windows.Forms.Button
        Me.btnGuardarContacto = New System.Windows.Forms.Button
        Me.btnEliminarContacto = New System.Windows.Forms.Button
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvContactos = New System.Windows.Forms.DataGridView
        Me.CajaChica = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Documento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fondos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Abonos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsuarioC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbDC = New System.Windows.Forms.GroupBox
        Me.cmbORIGENES = New System.Windows.Forms.ComboBox
        Me.txtNitCliente = New System.Windows.Forms.MaskedTextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtDuiCliente = New System.Windows.Forms.MaskedTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtGiro = New System.Windows.Forms.TextBox
        Me.gbE = New System.Windows.Forms.GroupBox
        Me.rbNo = New System.Windows.Forms.RadioButton
        Me.rbSi = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFaxCliente = New System.Windows.Forms.TextBox
        Me.txtTelCliente = New System.Windows.Forms.TextBox
        Me.cmbCONTRIBUYENTE = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtDirCliente = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtRegFiscal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbTIPO_CLIENTE = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.txtNombreCliente = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.gbCC = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtTelContacto = New System.Windows.Forms.TextBox
        Me.txtDirContacto = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtFaxContacto = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtEmailContacto = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtCelContacto = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtContacto = New System.Windows.Forms.TextBox
        Me.txtNombreContacto = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvContactos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDC.SuspendLayout()
        Me.gbE.SuspendLayout()
        Me.gbCC.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Información"
        '
        'btnNuevoCliente
        '
        Me.btnNuevoCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevoCliente.Image = CType(resources.GetObject("btnNuevoCliente.Image"), System.Drawing.Image)
        Me.btnNuevoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoCliente.Location = New System.Drawing.Point(433, 180)
        Me.btnNuevoCliente.Name = "btnNuevoCliente"
        Me.btnNuevoCliente.Size = New System.Drawing.Size(70, 24)
        Me.btnNuevoCliente.TabIndex = 16
        Me.btnNuevoCliente.Text = "&Nuevo"
        Me.btnNuevoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnNuevoCliente, "Reestablece los campos para ingresar un nuevo cliente")
        Me.btnNuevoCliente.UseVisualStyleBackColor = True
        '
        'btnGuardarCliente
        '
        Me.btnGuardarCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarCliente.Image = CType(resources.GetObject("btnGuardarCliente.Image"), System.Drawing.Image)
        Me.btnGuardarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarCliente.Location = New System.Drawing.Point(281, 180)
        Me.btnGuardarCliente.Name = "btnGuardarCliente"
        Me.btnGuardarCliente.Size = New System.Drawing.Size(70, 24)
        Me.btnGuardarCliente.TabIndex = 14
        Me.btnGuardarCliente.Text = "&Guardar"
        Me.btnGuardarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardarCliente, "Guarda los datos del cliente")
        Me.btnGuardarCliente.UseVisualStyleBackColor = True
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCliente.Location = New System.Drawing.Point(205, 180)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(70, 24)
        Me.btnBuscarCliente.TabIndex = 13
        Me.btnBuscarCliente.Text = "&Buscar"
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscarCliente, "Abre una ventana extra para buscar un determinado cliente")
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'btnEliminarCliente
        '
        Me.btnEliminarCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminarCliente.Image = CType(resources.GetObject("btnEliminarCliente.Image"), System.Drawing.Image)
        Me.btnEliminarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminarCliente.Location = New System.Drawing.Point(357, 180)
        Me.btnEliminarCliente.Name = "btnEliminarCliente"
        Me.btnEliminarCliente.Size = New System.Drawing.Size(70, 24)
        Me.btnEliminarCliente.TabIndex = 15
        Me.btnEliminarCliente.Text = "&Eliminar"
        Me.btnEliminarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEliminarCliente, "Elimina los datos de un cliente previamente seleccionado")
        Me.btnEliminarCliente.UseVisualStyleBackColor = True
        '
        'btnNuevoContacto
        '
        Me.btnNuevoContacto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevoContacto.Image = CType(resources.GetObject("btnNuevoContacto.Image"), System.Drawing.Image)
        Me.btnNuevoContacto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoContacto.Location = New System.Drawing.Point(340, 12)
        Me.btnNuevoContacto.Name = "btnNuevoContacto"
        Me.btnNuevoContacto.Size = New System.Drawing.Size(72, 24)
        Me.btnNuevoContacto.TabIndex = 15
        Me.btnNuevoContacto.Text = "N&uevo"
        Me.btnNuevoContacto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnNuevoContacto, "Reestablece los campos para ingresar un nuevo contacto de cliente")
        Me.btnNuevoContacto.UseVisualStyleBackColor = True
        '
        'btnGuardarContacto
        '
        Me.btnGuardarContacto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarContacto.Image = CType(resources.GetObject("btnGuardarContacto.Image"), System.Drawing.Image)
        Me.btnGuardarContacto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarContacto.Location = New System.Drawing.Point(152, 12)
        Me.btnGuardarContacto.Name = "btnGuardarContacto"
        Me.btnGuardarContacto.Size = New System.Drawing.Size(72, 24)
        Me.btnGuardarContacto.TabIndex = 13
        Me.btnGuardarContacto.Text = "G&uardar"
        Me.btnGuardarContacto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardarContacto, "Guarda los datos de contacto del cliente")
        Me.btnGuardarContacto.UseVisualStyleBackColor = True
        '
        'btnEliminarContacto
        '
        Me.btnEliminarContacto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminarContacto.Image = CType(resources.GetObject("btnEliminarContacto.Image"), System.Drawing.Image)
        Me.btnEliminarContacto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminarContacto.Location = New System.Drawing.Point(246, 12)
        Me.btnEliminarContacto.Name = "btnEliminarContacto"
        Me.btnEliminarContacto.Size = New System.Drawing.Size(72, 24)
        Me.btnEliminarContacto.TabIndex = 14
        Me.btnEliminarContacto.Text = "E&liminar"
        Me.btnEliminarContacto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEliminarContacto, "Elimina los datos de contacto del cliente")
        Me.btnEliminarContacto.UseVisualStyleBackColor = True
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(1, 0)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(135, 206)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 102
        Me.pbImagen.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(2, 342)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(232, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Contactos registrados"
        '
        'dgvContactos
        '
        Me.dgvContactos.AllowUserToAddRows = False
        Me.dgvContactos.AllowUserToDeleteRows = False
        Me.dgvContactos.AllowUserToResizeColumns = False
        Me.dgvContactos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvContactos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContactos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CajaChica, Me.Tipo, Me.Direccion, Me.Documento, Me.Fondos, Me.Abonos, Me.Saldo, Me.UsuarioC, Me.FechaC})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvContactos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvContactos.Location = New System.Drawing.Point(2, 364)
        Me.dgvContactos.Name = "dgvContactos"
        Me.dgvContactos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvContactos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvContactos.Size = New System.Drawing.Size(647, 183)
        Me.dgvContactos.TabIndex = 3
        '
        'CajaChica
        '
        Me.CajaChica.HeaderText = "Contacto"
        Me.CajaChica.Name = "CajaChica"
        Me.CajaChica.ReadOnly = True
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Nombre"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'Direccion
        '
        Me.Direccion.HeaderText = "Direccion"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.ReadOnly = True
        '
        'Documento
        '
        Me.Documento.HeaderText = "Teléfono"
        Me.Documento.Name = "Documento"
        Me.Documento.ReadOnly = True
        '
        'Fondos
        '
        Me.Fondos.HeaderText = "Celular"
        Me.Fondos.Name = "Fondos"
        Me.Fondos.ReadOnly = True
        '
        'Abonos
        '
        Me.Abonos.HeaderText = "Fax"
        Me.Abonos.Name = "Abonos"
        Me.Abonos.ReadOnly = True
        '
        'Saldo
        '
        Me.Saldo.HeaderText = "email"
        Me.Saldo.Name = "Saldo"
        Me.Saldo.ReadOnly = True
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
        'gbDC
        '
        Me.gbDC.Controls.Add(Me.cmbORIGENES)
        Me.gbDC.Controls.Add(Me.txtNitCliente)
        Me.gbDC.Controls.Add(Me.Label19)
        Me.gbDC.Controls.Add(Me.txtDuiCliente)
        Me.gbDC.Controls.Add(Me.btnNuevoCliente)
        Me.gbDC.Controls.Add(Me.Label2)
        Me.gbDC.Controls.Add(Me.txtGiro)
        Me.gbDC.Controls.Add(Me.gbE)
        Me.gbDC.Controls.Add(Me.Label5)
        Me.gbDC.Controls.Add(Me.btnGuardarCliente)
        Me.gbDC.Controls.Add(Me.txtFaxCliente)
        Me.gbDC.Controls.Add(Me.txtTelCliente)
        Me.gbDC.Controls.Add(Me.cmbCONTRIBUYENTE)
        Me.gbDC.Controls.Add(Me.btnBuscarCliente)
        Me.gbDC.Controls.Add(Me.Label16)
        Me.gbDC.Controls.Add(Me.txtDirCliente)
        Me.gbDC.Controls.Add(Me.btnEliminarCliente)
        Me.gbDC.Controls.Add(Me.Label10)
        Me.gbDC.Controls.Add(Me.Label13)
        Me.gbDC.Controls.Add(Me.Label11)
        Me.gbDC.Controls.Add(Me.Label7)
        Me.gbDC.Controls.Add(Me.txtRegFiscal)
        Me.gbDC.Controls.Add(Me.Label6)
        Me.gbDC.Controls.Add(Me.cmbTIPO_CLIENTE)
        Me.gbDC.Controls.Add(Me.Label4)
        Me.gbDC.Controls.Add(Me.cmbCOMPAÑIA)
        Me.gbDC.Controls.Add(Me.Label1)
        Me.gbDC.Controls.Add(Me.Label9)
        Me.gbDC.Controls.Add(Me.txtCliente)
        Me.gbDC.Controls.Add(Me.txtNombreCliente)
        Me.gbDC.Controls.Add(Me.Label8)
        Me.gbDC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDC.ForeColor = System.Drawing.Color.Navy
        Me.gbDC.Location = New System.Drawing.Point(139, -2)
        Me.gbDC.Name = "gbDC"
        Me.gbDC.Size = New System.Drawing.Size(510, 208)
        Me.gbDC.TabIndex = 0
        Me.gbDC.TabStop = False
        Me.gbDC.Text = "Datos Cliente"
        '
        'cmbORIGENES
        '
        Me.cmbORIGENES.BackColor = System.Drawing.SystemColors.Window
        Me.cmbORIGENES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbORIGENES.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbORIGENES.ForeColor = System.Drawing.Color.Navy
        Me.cmbORIGENES.FormattingEnabled = True
        Me.cmbORIGENES.Items.AddRange(New Object() {"ASTAS - Asociación de Trabajadores de Avícola Salvadoreña"})
        Me.cmbORIGENES.Location = New System.Drawing.Point(63, 85)
        Me.cmbORIGENES.Name = "cmbORIGENES"
        Me.cmbORIGENES.Size = New System.Drawing.Size(128, 24)
        Me.cmbORIGENES.TabIndex = 3
        '
        'txtNitCliente
        '
        Me.txtNitCliente.Location = New System.Drawing.Point(63, 179)
        Me.txtNitCliente.Mask = "0000-000000-000-0"
        Me.txtNitCliente.Name = "txtNitCliente"
        Me.txtNitCliente.Size = New System.Drawing.Size(128, 22)
        Me.txtNitCliente.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(2, 90)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 16)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Origen :"
        '
        'txtDuiCliente
        '
        Me.txtDuiCliente.Location = New System.Drawing.Point(63, 156)
        Me.txtDuiCliente.Mask = "00000000-0"
        Me.txtDuiCliente.Name = "txtDuiCliente"
        Me.txtDuiCliente.Size = New System.Drawing.Size(128, 22)
        Me.txtDuiCliente.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(197, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Giro :"
        '
        'txtGiro
        '
        Me.txtGiro.BackColor = System.Drawing.SystemColors.Window
        Me.txtGiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGiro.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGiro.ForeColor = System.Drawing.Color.Navy
        Me.txtGiro.Location = New System.Drawing.Point(281, 157)
        Me.txtGiro.MaxLength = 150
        Me.txtGiro.Name = "txtGiro"
        Me.txtGiro.Size = New System.Drawing.Size(222, 22)
        Me.txtGiro.TabIndex = 12
        '
        'gbE
        '
        Me.gbE.Controls.Add(Me.rbNo)
        Me.gbE.Controls.Add(Me.rbSi)
        Me.gbE.Location = New System.Drawing.Point(415, 98)
        Me.gbE.Name = "gbE"
        Me.gbE.Size = New System.Drawing.Size(88, 44)
        Me.gbE.TabIndex = 11
        Me.gbE.TabStop = False
        Me.gbE.Text = "Es Exento"
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Checked = True
        Me.rbNo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbNo.Location = New System.Drawing.Point(44, 18)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(42, 20)
        Me.rbNo.TabIndex = 1
        Me.rbNo.TabStop = True
        Me.rbNo.Text = "NO"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'rbSi
        '
        Me.rbSi.AutoSize = True
        Me.rbSi.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbSi.Location = New System.Drawing.Point(6, 18)
        Me.rbSi.Name = "rbSi"
        Me.rbSi.Size = New System.Drawing.Size(36, 20)
        Me.rbSi.TabIndex = 0
        Me.rbSi.Text = "SI"
        Me.rbSi.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(151, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Nombre :"
        '
        'txtFaxCliente
        '
        Me.txtFaxCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtFaxCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFaxCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaxCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtFaxCliente.Location = New System.Drawing.Point(63, 133)
        Me.txtFaxCliente.MaxLength = 50
        Me.txtFaxCliente.Name = "txtFaxCliente"
        Me.txtFaxCliente.Size = New System.Drawing.Size(128, 22)
        Me.txtFaxCliente.TabIndex = 5
        '
        'txtTelCliente
        '
        Me.txtTelCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtTelCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtTelCliente.Location = New System.Drawing.Point(63, 110)
        Me.txtTelCliente.MaxLength = 50
        Me.txtTelCliente.Name = "txtTelCliente"
        Me.txtTelCliente.Size = New System.Drawing.Size(128, 22)
        Me.txtTelCliente.TabIndex = 4
        '
        'cmbCONTRIBUYENTE
        '
        Me.cmbCONTRIBUYENTE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCONTRIBUYENTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCONTRIBUYENTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCONTRIBUYENTE.ForeColor = System.Drawing.Color.Navy
        Me.cmbCONTRIBUYENTE.FormattingEnabled = True
        Me.cmbCONTRIBUYENTE.Items.AddRange(New Object() {"Pequeño", "Mediano", "Grande"})
        Me.cmbCONTRIBUYENTE.Location = New System.Drawing.Point(281, 109)
        Me.cmbCONTRIBUYENTE.Name = "cmbCONTRIBUYENTE"
        Me.cmbCONTRIBUYENTE.Size = New System.Drawing.Size(128, 24)
        Me.cmbCONTRIBUYENTE.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(197, 112)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 16)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Contribuyente :"
        '
        'txtDirCliente
        '
        Me.txtDirCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtDirCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDirCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtDirCliente.Location = New System.Drawing.Point(63, 62)
        Me.txtDirCliente.MaxLength = 250
        Me.txtDirCliente.Name = "txtDirCliente"
        Me.txtDirCliente.Size = New System.Drawing.Size(440, 22)
        Me.txtDirCliente.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(2, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Dirección :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(2, 136)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 16)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Fax :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(2, 113)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 16)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Teléfono :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(197, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 16)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Registro Fiscal :"
        '
        'txtRegFiscal
        '
        Me.txtRegFiscal.BackColor = System.Drawing.SystemColors.Window
        Me.txtRegFiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRegFiscal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegFiscal.ForeColor = System.Drawing.Color.Navy
        Me.txtRegFiscal.Location = New System.Drawing.Point(281, 134)
        Me.txtRegFiscal.MaxLength = 15
        Me.txtRegFiscal.Name = "txtRegFiscal"
        Me.txtRegFiscal.Size = New System.Drawing.Size(128, 22)
        Me.txtRegFiscal.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(2, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 16)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "DUI :"
        '
        'cmbTIPO_CLIENTE
        '
        Me.cmbTIPO_CLIENTE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_CLIENTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_CLIENTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_CLIENTE.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_CLIENTE.FormattingEnabled = True
        Me.cmbTIPO_CLIENTE.Items.AddRange(New Object() {"Persona Natural", "Jurídica"})
        Me.cmbTIPO_CLIENTE.Location = New System.Drawing.Point(281, 85)
        Me.cmbTIPO_CLIENTE.Name = "cmbTIPO_CLIENTE"
        Me.cmbTIPO_CLIENTE.Size = New System.Drawing.Size(128, 24)
        Me.cmbTIPO_CLIENTE.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(197, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Tipo Cliente :"
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Items.AddRange(New Object() {"ASTAS - Asociación de Trabajadores de Avícola Salvadoreña"})
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(63, 14)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(440, 24)
        Me.cmbCOMPAÑIA.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(2, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Compañía :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(2, 182)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 16)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "NIT :"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.Color.Red
        Me.txtCliente.Location = New System.Drawing.Point(63, 39)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(88, 22)
        Me.txtCliente.TabIndex = 30
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtNombreCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtNombreCliente.Location = New System.Drawing.Point(203, 39)
        Me.txtNombreCliente.MaxLength = 250
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombreCliente.Size = New System.Drawing.Size(300, 22)
        Me.txtNombreCliente.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(2, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Cliente :"
        '
        'gbCC
        '
        Me.gbCC.Controls.Add(Me.btnNuevoContacto)
        Me.gbCC.Controls.Add(Me.btnGuardarContacto)
        Me.gbCC.Controls.Add(Me.btnEliminarContacto)
        Me.gbCC.Controls.Add(Me.Label12)
        Me.gbCC.Controls.Add(Me.txtTelContacto)
        Me.gbCC.Controls.Add(Me.txtDirContacto)
        Me.gbCC.Controls.Add(Me.Label14)
        Me.gbCC.Controls.Add(Me.Label15)
        Me.gbCC.Controls.Add(Me.txtFaxContacto)
        Me.gbCC.Controls.Add(Me.Label17)
        Me.gbCC.Controls.Add(Me.txtEmailContacto)
        Me.gbCC.Controls.Add(Me.Label18)
        Me.gbCC.Controls.Add(Me.txtCelContacto)
        Me.gbCC.Controls.Add(Me.Label21)
        Me.gbCC.Controls.Add(Me.txtContacto)
        Me.gbCC.Controls.Add(Me.txtNombreContacto)
        Me.gbCC.Controls.Add(Me.Label22)
        Me.gbCC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCC.ForeColor = System.Drawing.Color.Navy
        Me.gbCC.Location = New System.Drawing.Point(2, 207)
        Me.gbCC.Name = "gbCC"
        Me.gbCC.Size = New System.Drawing.Size(647, 134)
        Me.gbCC.TabIndex = 1
        Me.gbCC.TabStop = False
        Me.gbCC.Text = "Contactos"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(2, 41)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 16)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Nombre :"
        '
        'txtTelContacto
        '
        Me.txtTelContacto.BackColor = System.Drawing.SystemColors.Window
        Me.txtTelContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelContacto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelContacto.ForeColor = System.Drawing.Color.Navy
        Me.txtTelContacto.Location = New System.Drawing.Point(60, 85)
        Me.txtTelContacto.MaxLength = 20
        Me.txtTelContacto.Name = "txtTelContacto"
        Me.txtTelContacto.Size = New System.Drawing.Size(250, 22)
        Me.txtTelContacto.TabIndex = 2
        '
        'txtDirContacto
        '
        Me.txtDirContacto.BackColor = System.Drawing.SystemColors.Window
        Me.txtDirContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDirContacto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirContacto.ForeColor = System.Drawing.Color.Navy
        Me.txtDirContacto.Location = New System.Drawing.Point(60, 62)
        Me.txtDirContacto.MaxLength = 250
        Me.txtDirContacto.Name = "txtDirContacto"
        Me.txtDirContacto.Size = New System.Drawing.Size(580, 22)
        Me.txtDirContacto.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(2, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 16)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Dirección :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(2, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 16)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Teléfono :"
        '
        'txtFaxContacto
        '
        Me.txtFaxContacto.BackColor = System.Drawing.SystemColors.Window
        Me.txtFaxContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFaxContacto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaxContacto.ForeColor = System.Drawing.Color.Navy
        Me.txtFaxContacto.Location = New System.Drawing.Point(390, 85)
        Me.txtFaxContacto.MaxLength = 20
        Me.txtFaxContacto.Name = "txtFaxContacto"
        Me.txtFaxContacto.Size = New System.Drawing.Size(250, 22)
        Me.txtFaxContacto.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(349, 112)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 16)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "email :"
        '
        'txtEmailContacto
        '
        Me.txtEmailContacto.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmailContacto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailContacto.ForeColor = System.Drawing.Color.Navy
        Me.txtEmailContacto.Location = New System.Drawing.Point(390, 109)
        Me.txtEmailContacto.MaxLength = 100
        Me.txtEmailContacto.Name = "txtEmailContacto"
        Me.txtEmailContacto.Size = New System.Drawing.Size(250, 22)
        Me.txtEmailContacto.TabIndex = 5
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(2, 112)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 16)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Celular :"
        '
        'txtCelContacto
        '
        Me.txtCelContacto.BackColor = System.Drawing.SystemColors.Window
        Me.txtCelContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCelContacto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelContacto.ForeColor = System.Drawing.Color.Navy
        Me.txtCelContacto.Location = New System.Drawing.Point(60, 109)
        Me.txtCelContacto.MaxLength = 20
        Me.txtCelContacto.Name = "txtCelContacto"
        Me.txtCelContacto.Size = New System.Drawing.Size(250, 22)
        Me.txtCelContacto.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(349, 88)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(33, 16)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "Fax :"
        '
        'txtContacto
        '
        Me.txtContacto.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtContacto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContacto.ForeColor = System.Drawing.Color.Red
        Me.txtContacto.Location = New System.Drawing.Point(60, 15)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.ReadOnly = True
        Me.txtContacto.Size = New System.Drawing.Size(88, 22)
        Me.txtContacto.TabIndex = 16
        '
        'txtNombreContacto
        '
        Me.txtNombreContacto.BackColor = System.Drawing.SystemColors.Window
        Me.txtNombreContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreContacto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreContacto.ForeColor = System.Drawing.Color.Navy
        Me.txtNombreContacto.Location = New System.Drawing.Point(60, 38)
        Me.txtNombreContacto.MaxLength = 250
        Me.txtNombreContacto.Name = "txtNombreContacto"
        Me.txtNombreContacto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombreContacto.Size = New System.Drawing.Size(580, 22)
        Me.txtNombreContacto.TabIndex = 0
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(2, 18)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(55, 16)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "Contacto :"
        '
        'Contabilidad_Catalogo_Clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 548)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvContactos)
        Me.Controls.Add(Me.gbDC)
        Me.Controls.Add(Me.gbCC)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_Catalogo_Clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Catálogo de  Clientes"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvContactos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDC.ResumeLayout(False)
        Me.gbDC.PerformLayout()
        Me.gbE.ResumeLayout(False)
        Me.gbE.PerformLayout()
        Me.gbCC.ResumeLayout(False)
        Me.gbCC.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvContactos As System.Windows.Forms.DataGridView
    Friend WithEvents CajaChica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Documento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fondos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abonos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gbDC As System.Windows.Forms.GroupBox
    Friend WithEvents txtNitCliente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDuiCliente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnNuevoCliente As System.Windows.Forms.Button
    Friend WithEvents btnGuardarCliente As System.Windows.Forms.Button
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents btnEliminarCliente As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGiro As System.Windows.Forms.TextBox
    Friend WithEvents gbE As System.Windows.Forms.GroupBox
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbSi As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFaxCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtTelCliente As System.Windows.Forms.TextBox
    Friend WithEvents cmbCONTRIBUYENTE As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDirCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRegFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTIPO_CLIENTE As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gbCC As System.Windows.Forms.GroupBox
    Friend WithEvents btnNuevoContacto As System.Windows.Forms.Button
    Friend WithEvents btnGuardarContacto As System.Windows.Forms.Button
    Friend WithEvents btnEliminarContacto As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTelContacto As System.Windows.Forms.TextBox
    Friend WithEvents txtDirContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFaxContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtEmailContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCelContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbORIGENES As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
