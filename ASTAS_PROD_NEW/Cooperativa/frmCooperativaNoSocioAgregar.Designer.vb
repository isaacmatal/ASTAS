<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCooperativaNoSocioAgregar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCooperativaNoSocioAgregar))
        Me.txtCodAS = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCodBuxis = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNombres = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtApellidos = New System.Windows.Forms.TextBox
        Me.cmbDivision = New System.Windows.Forms.ComboBox
        Me.cmbDepto = New System.Windows.Forms.ComboBox
        Me.cmbSeccion = New System.Windows.Forms.ComboBox
        Me.cmbCargo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnBuscarCliente = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbBanco = New System.Windows.Forms.ComboBox
        Me.txtCuentaBanco = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTipoCuenta = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtpFechaIng = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.mktDUI = New System.Windows.Forms.MaskedTextBox
        Me.mktNIT = New System.Windows.Forms.MaskedTextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.mktTel = New System.Windows.Forms.MaskedTextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtDir = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtSalario = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmbOrigen = New System.Windows.Forms.ComboBox
        Me.BtnEliminar = New System.Windows.Forms.Button
        Me.BtnNuevo = New System.Windows.Forms.Button
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmbStatusSocio = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cmbPeriodoPago = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.chkBloqueoConsumo = New System.Windows.Forms.CheckBox
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.chkEsBuxis = New System.Windows.Forms.CheckBox
        Me.chkRetirado = New System.Windows.Forms.CheckBox
        Me.cmbTipoContrato = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCodAS
        '
        Me.txtCodAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodAS.Location = New System.Drawing.Point(638, 14)
        Me.txtCodAS.Name = "txtCodAS"
        Me.txtCodAS.Size = New System.Drawing.Size(199, 20)
        Me.txtCodAS.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(204, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo Buxis:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(526, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Codigo AS:"
        '
        'txtCodBuxis
        '
        Me.txtCodBuxis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodBuxis.Location = New System.Drawing.Point(292, 14)
        Me.txtCodBuxis.Name = "txtCodBuxis"
        Me.txtCodBuxis.Size = New System.Drawing.Size(171, 20)
        Me.txtCodBuxis.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(204, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombres:"
        '
        'txtNombres
        '
        Me.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombres.Location = New System.Drawing.Point(292, 38)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(199, 20)
        Me.txtNombres.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(526, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Apellidos:"
        '
        'txtApellidos
        '
        Me.txtApellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellidos.Location = New System.Drawing.Point(638, 38)
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.Size = New System.Drawing.Size(200, 20)
        Me.txtApellidos.TabIndex = 3
        '
        'cmbDivision
        '
        Me.cmbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDivision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDivision.FormattingEnabled = True
        Me.cmbDivision.Location = New System.Drawing.Point(292, 64)
        Me.cmbDivision.Name = "cmbDivision"
        Me.cmbDivision.Size = New System.Drawing.Size(199, 22)
        Me.cmbDivision.TabIndex = 4
        '
        'cmbDepto
        '
        Me.cmbDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDepto.FormattingEnabled = True
        Me.cmbDepto.Location = New System.Drawing.Point(638, 64)
        Me.cmbDepto.Name = "cmbDepto"
        Me.cmbDepto.Size = New System.Drawing.Size(200, 22)
        Me.cmbDepto.TabIndex = 5
        '
        'cmbSeccion
        '
        Me.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSeccion.FormattingEnabled = True
        Me.cmbSeccion.Location = New System.Drawing.Point(292, 92)
        Me.cmbSeccion.Name = "cmbSeccion"
        Me.cmbSeccion.Size = New System.Drawing.Size(199, 22)
        Me.cmbSeccion.TabIndex = 6
        '
        'cmbCargo
        '
        Me.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCargo.FormattingEnabled = True
        Me.cmbCargo.Location = New System.Drawing.Point(638, 92)
        Me.cmbCargo.Name = "cmbCargo"
        Me.cmbCargo.Size = New System.Drawing.Size(200, 22)
        Me.cmbCargo.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(204, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "División:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(526, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Depto.:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(204, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Sección:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(526, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 15)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Cargo:"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarCliente.ForeColor = System.Drawing.Color.White
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(467, 11)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(24, 26)
        Me.btnBuscarCliente.TabIndex = 26
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(204, 125)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 15)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Banco:"
        '
        'cmbBanco
        '
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(292, 120)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(199, 22)
        Me.cmbBanco.TabIndex = 8
        '
        'txtCuentaBanco
        '
        Me.txtCuentaBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaBanco.Location = New System.Drawing.Point(638, 120)
        Me.txtCuentaBanco.Name = "txtCuentaBanco"
        Me.txtCuentaBanco.Size = New System.Drawing.Size(199, 20)
        Me.txtCuentaBanco.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(526, 122)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 15)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Cuenta #:"
        '
        'txtTipoCuenta
        '
        Me.txtTipoCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCuenta.Location = New System.Drawing.Point(292, 148)
        Me.txtTipoCuenta.Name = "txtTipoCuenta"
        Me.txtTipoCuenta.Size = New System.Drawing.Size(199, 20)
        Me.txtTipoCuenta.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(204, 151)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 15)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Tipo Cuenta:"
        '
        'dtpFechaIng
        '
        Me.dtpFechaIng.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIng.Location = New System.Drawing.Point(638, 146)
        Me.dtpFechaIng.Name = "dtpFechaIng"
        Me.dtpFechaIng.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaIng.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(526, 149)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 15)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Fecha de Ingreso:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(204, 205)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 15)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "D.U.I.:"
        '
        'mktDUI
        '
        Me.mktDUI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mktDUI.Location = New System.Drawing.Point(292, 200)
        Me.mktDUI.Mask = "00000000-0"
        Me.mktDUI.Name = "mktDUI"
        Me.mktDUI.Size = New System.Drawing.Size(73, 20)
        Me.mktDUI.TabIndex = 14
        '
        'mktNIT
        '
        Me.mktNIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mktNIT.Location = New System.Drawing.Point(638, 174)
        Me.mktNIT.Mask = "0000-000000-000-0"
        Me.mktNIT.Name = "mktNIT"
        Me.mktNIT.Size = New System.Drawing.Size(106, 20)
        Me.mktNIT.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(526, 179)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 15)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "N.I.T.:"
        '
        'mktTel
        '
        Me.mktTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mktTel.Location = New System.Drawing.Point(638, 200)
        Me.mktTel.Mask = "0000-0000"
        Me.mktTel.Name = "mktTel"
        Me.mktTel.Size = New System.Drawing.Size(73, 20)
        Me.mktTel.TabIndex = 15
        Me.mktTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(526, 204)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 15)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Teléfono:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(204, 177)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 15)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Salario:"
        '
        'txtDir
        '
        Me.txtDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDir.Location = New System.Drawing.Point(292, 310)
        Me.txtDir.MaxLength = 250
        Me.txtDir.Multiline = True
        Me.txtDir.Name = "txtDir"
        Me.txtDir.Size = New System.Drawing.Size(543, 70)
        Me.txtDir.TabIndex = 22
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(204, 313)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 15)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Dirección:"
        '
        'txtSalario
        '
        Me.txtSalario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalario.Location = New System.Drawing.Point(292, 174)
        Me.txtSalario.Name = "txtSalario"
        Me.txtSalario.Size = New System.Drawing.Size(73, 20)
        Me.txtSalario.TabIndex = 12
        Me.txtSalario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(204, 231)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 15)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "Empresa:"
        '
        'cmbOrigen
        '
        Me.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Location = New System.Drawing.Point(292, 226)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(199, 22)
        Me.cmbOrigen.TabIndex = 16
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Enabled = False
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnEliminar.ForeColor = System.Drawing.Color.White
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(854, 52)
        Me.BtnEliminar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(75, 26)
        Me.BtnEliminar.TabIndex = 24
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnNuevo.ForeColor = System.Drawing.Color.White
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(854, 16)
        Me.BtnNuevo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(75, 26)
        Me.BtnNuevo.TabIndex = 23
        Me.BtnNuevo.Text = "&Nuevo"
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(854, 88)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 26)
        Me.BtnGuardar.TabIndex = 25
        Me.BtnGuardar.Text = "&Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(526, 232)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 15)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "Estado:"
        '
        'cmbStatusSocio
        '
        Me.cmbStatusSocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatusSocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStatusSocio.FormattingEnabled = True
        Me.cmbStatusSocio.Location = New System.Drawing.Point(638, 228)
        Me.cmbStatusSocio.Name = "cmbStatusSocio"
        Me.cmbStatusSocio.Size = New System.Drawing.Size(197, 22)
        Me.cmbStatusSocio.TabIndex = 17
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(204, 286)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(85, 15)
        Me.Label20.TabIndex = 42
        Me.Label20.Text = "Periodo Pago:"
        '
        'cmbPeriodoPago
        '
        Me.cmbPeriodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPeriodoPago.FormattingEnabled = True
        Me.cmbPeriodoPago.Location = New System.Drawing.Point(292, 282)
        Me.cmbPeriodoPago.Name = "cmbPeriodoPago"
        Me.cmbPeriodoPago.Size = New System.Drawing.Size(199, 22)
        Me.cmbPeriodoPago.TabIndex = 20
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.chkBloqueoConsumo)
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Controls.Add(Me.cmbPeriodoPago)
        Me.GroupBox1.Controls.Add(Me.chkEsBuxis)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.chkRetirado)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cmbTipoContrato)
        Me.GroupBox1.Controls.Add(Me.txtDir)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cmbStatusSocio)
        Me.GroupBox1.Controls.Add(Me.txtCodAS)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbOrigen)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtCodBuxis)
        Me.GroupBox1.Controls.Add(Me.BtnGuardar)
        Me.GroupBox1.Controls.Add(Me.txtSalario)
        Me.GroupBox1.Controls.Add(Me.BtnEliminar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.BtnNuevo)
        Me.GroupBox1.Controls.Add(Me.mktTel)
        Me.GroupBox1.Controls.Add(Me.txtNombres)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.mktNIT)
        Me.GroupBox1.Controls.Add(Me.txtApellidos)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmbDivision)
        Me.GroupBox1.Controls.Add(Me.mktDUI)
        Me.GroupBox1.Controls.Add(Me.cmbDepto)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cmbSeccion)
        Me.GroupBox1.Controls.Add(Me.cmbCargo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnBuscarCliente)
        Me.GroupBox1.Controls.Add(Me.cmbBanco)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.dtpFechaIng)
        Me.GroupBox1.Controls.Add(Me.txtCuentaBanco)
        Me.GroupBox1.Controls.Add(Me.txtTipoCuenta)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(946, 391)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(635, 258)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(125, 15)
        Me.Label21.TabIndex = 84
        Me.Label21.Text = "Consumo Bloqueado"
        '
        'chkBloqueoConsumo
        '
        Me.chkBloqueoConsumo.AutoSize = True
        Me.chkBloqueoConsumo.BackColor = System.Drawing.Color.Transparent
        Me.chkBloqueoConsumo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBloqueoConsumo.Enabled = False
        Me.chkBloqueoConsumo.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.chkBloqueoConsumo.FlatAppearance.BorderSize = 2
        Me.chkBloqueoConsumo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow
        Me.chkBloqueoConsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkBloqueoConsumo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBloqueoConsumo.Location = New System.Drawing.Point(766, 260)
        Me.chkBloqueoConsumo.Name = "chkBloqueoConsumo"
        Me.chkBloqueoConsumo.Size = New System.Drawing.Size(12, 11)
        Me.chkBloqueoConsumo.TabIndex = 83
        Me.chkBloqueoConsumo.UseVisualStyleBackColor = False
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(43, 254)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(85, 131)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 80
        Me.pbImagen.TabStop = False
        '
        'chkEsBuxis
        '
        Me.chkEsBuxis.AutoSize = True
        Me.chkEsBuxis.BackColor = System.Drawing.Color.Transparent
        Me.chkEsBuxis.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEsBuxis.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEsBuxis.Location = New System.Drawing.Point(526, 286)
        Me.chkEsBuxis.Name = "chkEsBuxis"
        Me.chkEsBuxis.Size = New System.Drawing.Size(173, 19)
        Me.chkEsBuxis.TabIndex = 21
        Me.chkEsBuxis.Text = "Enviar Descuentos a Buxis"
        Me.chkEsBuxis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEsBuxis.UseVisualStyleBackColor = False
        '
        'chkRetirado
        '
        Me.chkRetirado.AutoSize = True
        Me.chkRetirado.BackColor = System.Drawing.Color.Transparent
        Me.chkRetirado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRetirado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRetirado.Location = New System.Drawing.Point(526, 257)
        Me.chkRetirado.Name = "chkRetirado"
        Me.chkRetirado.Size = New System.Drawing.Size(73, 19)
        Me.chkRetirado.TabIndex = 19
        Me.chkRetirado.Text = "Retirado"
        Me.chkRetirado.UseVisualStyleBackColor = False
        '
        'cmbTipoContrato
        '
        Me.cmbTipoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTipoContrato.FormattingEnabled = True
        Me.cmbTipoContrato.Location = New System.Drawing.Point(292, 254)
        Me.cmbTipoContrato.Name = "cmbTipoContrato"
        Me.cmbTipoContrato.Size = New System.Drawing.Size(199, 22)
        Me.cmbTipoContrato.TabIndex = 18
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(204, 258)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 15)
        Me.Label22.TabIndex = 46
        Me.Label22.Text = "Tipo Contrato:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(192, 233)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 45
        Me.PictureBox1.TabStop = False
        '
        'frmCooperativaNoSocioAgregar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(976, 403)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmCooperativaNoSocioAgregar"
        Me.Opacity = 0.9
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento Datos Empleados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCodAS As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodBuxis As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents cmbDivision As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDepto As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSeccion As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCargo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents txtCuentaBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIng As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents mktDUI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mktNIT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents mktTel As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDir As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtSalario As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbStatusSocio As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodoPago As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents chkEsBuxis As System.Windows.Forms.CheckBox
    Friend WithEvents chkRetirado As System.Windows.Forms.CheckBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoContrato As System.Windows.Forms.ComboBox
    Friend WithEvents chkBloqueoConsumo As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
End Class
