<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CooperativaDepositosBecas
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CooperativaDepositosBecas))
        Me.dgvAutorizaciones = New System.Windows.Forms.DataGridView
        Me.btnCargar = New System.Windows.Forms.Button
        Me.txtArchivo = New System.Windows.Forms.TextBox
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog
        Me.btnArchivo = New System.Windows.Forms.Button
        Me.cmbSheets = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dpFechaDep = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.cmbCuentaBancaria = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbBanco = New System.Windows.Forms.ComboBox
        Me.txtConceptoDeposito = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tabEncabezado = New System.Windows.Forms.TabControl
        Me.tbpCargar = New System.Windows.Forms.TabPage
        Me.tbpConsultar = New System.Windows.Forms.TabPage
        Me.dpFechaDep2 = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbCuentaBanco2 = New System.Windows.Forms.ComboBox
        Me.cmbBanco2 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtConceptoDeposito2 = New System.Windows.Forms.TextBox
        Me.btnGenerateFile = New System.Windows.Forms.Button
        Me.dgvEncabezado = New System.Windows.Forms.DataGridView
        Me.tbpAgregar = New System.Windows.Forms.TabPage
        Me.btnFind = New System.Windows.Forms.Button
        Me.gbxAddDetalle = New System.Windows.Forms.GroupBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.btnDeleteRow = New System.Windows.Forms.Button
        Me.btnSaveRow = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnNewRow = New System.Windows.Forms.Button
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtValor = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnFindSocio = New System.Windows.Forms.Button
        Me.dpFechaDep3 = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtConcepto = New System.Windows.Forms.TextBox
        Me.tbpDividendos = New System.Windows.Forms.TabPage
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.dpFechaDep4 = New System.Windows.Forms.DateTimePicker
        Me.Label21 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.rbAtaf = New System.Windows.Forms.RadioButton
        Me.rbAstas = New System.Windows.Forms.RadioButton
        Me.cmbBanco3 = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cmbCuentaBanco3 = New System.Windows.Forms.ComboBox
        Me.btnGenerar2 = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtConceptoDeposito3 = New System.Windows.Forms.TextBox
        Me.btnCargar2 = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtDesde = New System.Windows.Forms.DateTimePicker
        Me.txtHasta = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.nudReparto = New System.Windows.Forms.NumericUpDown
        Me.Label16 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgvAutorizaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEncabezado.SuspendLayout()
        Me.tbpCargar.SuspendLayout()
        Me.tbpConsultar.SuspendLayout()
        CType(Me.dgvEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpAgregar.SuspendLayout()
        Me.gbxAddDetalle.SuspendLayout()
        Me.tbpDividendos.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.nudReparto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAutorizaciones
        '
        Me.dgvAutorizaciones.AllowUserToAddRows = False
        Me.dgvAutorizaciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvAutorizaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAutorizaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAutorizaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgvAutorizaciones.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvAutorizaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvAutorizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAutorizaciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAutorizaciones.Location = New System.Drawing.Point(3, 196)
        Me.dgvAutorizaciones.Name = "dgvAutorizaciones"
        Me.dgvAutorizaciones.ReadOnly = True
        Me.dgvAutorizaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAutorizaciones.Size = New System.Drawing.Size(940, 216)
        Me.dgvAutorizaciones.TabIndex = 0
        '
        'btnCargar
        '
        Me.btnCargar.BackColor = System.Drawing.Color.Transparent
        Me.btnCargar.Location = New System.Drawing.Point(563, 50)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(75, 23)
        Me.btnCargar.TabIndex = 1
        Me.btnCargar.Text = "&Cargar"
        Me.btnCargar.UseVisualStyleBackColor = False
        '
        'txtArchivo
        '
        Me.txtArchivo.BackColor = System.Drawing.SystemColors.Info
        Me.txtArchivo.Location = New System.Drawing.Point(3, 12)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(556, 20)
        Me.txtArchivo.TabIndex = 2
        '
        'OpenFile
        '
        Me.OpenFile.FileName = "OpenFileDialog1"
        '
        'btnArchivo
        '
        Me.btnArchivo.BackColor = System.Drawing.Color.Transparent
        Me.btnArchivo.Location = New System.Drawing.Point(563, 10)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(75, 23)
        Me.btnArchivo.TabIndex = 7
        Me.btnArchivo.Text = "Archivo"
        Me.btnArchivo.UseVisualStyleBackColor = False
        '
        'cmbSheets
        '
        Me.cmbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSheets.FormattingEnabled = True
        Me.cmbSheets.Location = New System.Drawing.Point(97, 51)
        Me.cmbSheets.Name = "cmbSheets"
        Me.cmbSheets.Size = New System.Drawing.Size(245, 21)
        Me.cmbSheets.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(2, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Hojas en el Libro:"
        '
        'dpFechaDep
        '
        Me.dpFechaDep.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaDep.Location = New System.Drawing.Point(735, 9)
        Me.dpFechaDep.Name = "dpFechaDep"
        Me.dpFechaDep.Size = New System.Drawing.Size(101, 20)
        Me.dpFechaDep.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(650, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Fecha Remesa:"
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.Transparent
        Me.btnGenerar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(653, 28)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(71, 59)
        Me.btnGenerar.TabIndex = 12
        Me.btnGenerar.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Archivo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Banco"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'cmbCuentaBancaria
        '
        Me.cmbCuentaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuentaBancaria.FormattingEnabled = True
        Me.cmbCuentaBancaria.Location = New System.Drawing.Point(398, 91)
        Me.cmbCuentaBancaria.Name = "cmbCuentaBancaria"
        Me.cmbCuentaBancaria.Size = New System.Drawing.Size(240, 21)
        Me.cmbCuentaBancaria.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(303, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Cuenta Bancaria:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(5, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Banco:"
        '
        'cmbBanco
        '
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(56, 91)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(203, 21)
        Me.cmbBanco.TabIndex = 16
        '
        'txtConceptoDeposito
        '
        Me.txtConceptoDeposito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConceptoDeposito.Location = New System.Drawing.Point(447, 51)
        Me.txtConceptoDeposito.MaxLength = 25
        Me.txtConceptoDeposito.Name = "txtConceptoDeposito"
        Me.txtConceptoDeposito.Size = New System.Drawing.Size(109, 20)
        Me.txtConceptoDeposito.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(345, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Concepto Deposito:"
        '
        'tabEncabezado
        '
        Me.tabEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabEncabezado.Controls.Add(Me.tbpCargar)
        Me.tabEncabezado.Controls.Add(Me.tbpConsultar)
        Me.tabEncabezado.Controls.Add(Me.tbpAgregar)
        Me.tabEncabezado.Controls.Add(Me.tbpDividendos)
        Me.tabEncabezado.Location = New System.Drawing.Point(3, 12)
        Me.tabEncabezado.Name = "tabEncabezado"
        Me.tabEncabezado.SelectedIndex = 0
        Me.tabEncabezado.Size = New System.Drawing.Size(944, 182)
        Me.tabEncabezado.TabIndex = 19
        '
        'tbpCargar
        '
        Me.tbpCargar.Controls.Add(Me.txtArchivo)
        Me.tbpCargar.Controls.Add(Me.Label5)
        Me.tbpCargar.Controls.Add(Me.btnCargar)
        Me.tbpCargar.Controls.Add(Me.txtConceptoDeposito)
        Me.tbpCargar.Controls.Add(Me.btnArchivo)
        Me.tbpCargar.Controls.Add(Me.cmbBanco)
        Me.tbpCargar.Controls.Add(Me.cmbSheets)
        Me.tbpCargar.Controls.Add(Me.Label4)
        Me.tbpCargar.Controls.Add(Me.Label1)
        Me.tbpCargar.Controls.Add(Me.Label3)
        Me.tbpCargar.Controls.Add(Me.dpFechaDep)
        Me.tbpCargar.Controls.Add(Me.cmbCuentaBancaria)
        Me.tbpCargar.Controls.Add(Me.Label2)
        Me.tbpCargar.Controls.Add(Me.btnGenerar)
        Me.tbpCargar.Location = New System.Drawing.Point(4, 22)
        Me.tbpCargar.Name = "tbpCargar"
        Me.tbpCargar.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCargar.Size = New System.Drawing.Size(936, 156)
        Me.tbpCargar.TabIndex = 0
        Me.tbpCargar.Text = "Becas"
        Me.tbpCargar.UseVisualStyleBackColor = True
        '
        'tbpConsultar
        '
        Me.tbpConsultar.Controls.Add(Me.dpFechaDep2)
        Me.tbpConsultar.Controls.Add(Me.Label9)
        Me.tbpConsultar.Controls.Add(Me.Label8)
        Me.tbpConsultar.Controls.Add(Me.cmbCuentaBanco2)
        Me.tbpConsultar.Controls.Add(Me.cmbBanco2)
        Me.tbpConsultar.Controls.Add(Me.Label7)
        Me.tbpConsultar.Controls.Add(Me.Label6)
        Me.tbpConsultar.Controls.Add(Me.txtConceptoDeposito2)
        Me.tbpConsultar.Controls.Add(Me.btnGenerateFile)
        Me.tbpConsultar.Controls.Add(Me.dgvEncabezado)
        Me.tbpConsultar.Location = New System.Drawing.Point(4, 22)
        Me.tbpConsultar.Name = "tbpConsultar"
        Me.tbpConsultar.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpConsultar.Size = New System.Drawing.Size(936, 156)
        Me.tbpConsultar.TabIndex = 1
        Me.tbpConsultar.Text = "Consultar"
        Me.tbpConsultar.UseVisualStyleBackColor = True
        '
        'dpFechaDep2
        '
        Me.dpFechaDep2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaDep2.Location = New System.Drawing.Point(692, 6)
        Me.dpFechaDep2.Name = "dpFechaDep2"
        Me.dpFechaDep2.Size = New System.Drawing.Size(101, 20)
        Me.dpFechaDep2.TabIndex = 25
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(589, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Fecha Remesa:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(589, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Cuenta Bancaria:"
        '
        'cmbCuentaBanco2
        '
        Me.cmbCuentaBanco2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuentaBanco2.FormattingEnabled = True
        Me.cmbCuentaBanco2.Location = New System.Drawing.Point(692, 53)
        Me.cmbCuentaBanco2.Name = "cmbCuentaBanco2"
        Me.cmbCuentaBanco2.Size = New System.Drawing.Size(240, 21)
        Me.cmbCuentaBanco2.TabIndex = 23
        '
        'cmbBanco2
        '
        Me.cmbBanco2.FormattingEnabled = True
        Me.cmbBanco2.Location = New System.Drawing.Point(692, 29)
        Me.cmbBanco2.Name = "cmbBanco2"
        Me.cmbBanco2.Size = New System.Drawing.Size(240, 21)
        Me.cmbBanco2.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(589, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Banco:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(589, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Concepto Deposito:"
        '
        'txtConceptoDeposito2
        '
        Me.txtConceptoDeposito2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConceptoDeposito2.Location = New System.Drawing.Point(691, 78)
        Me.txtConceptoDeposito2.MaxLength = 25
        Me.txtConceptoDeposito2.Name = "txtConceptoDeposito2"
        Me.txtConceptoDeposito2.Size = New System.Drawing.Size(143, 20)
        Me.txtConceptoDeposito2.TabIndex = 19
        '
        'btnGenerateFile
        '
        Me.btnGenerateFile.BackColor = System.Drawing.Color.Transparent
        Me.btnGenerateFile.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerateFile.Location = New System.Drawing.Point(840, 80)
        Me.btnGenerateFile.Name = "btnGenerateFile"
        Me.btnGenerateFile.Size = New System.Drawing.Size(90, 56)
        Me.btnGenerateFile.TabIndex = 13
        Me.btnGenerateFile.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Archivo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Banco"
        Me.btnGenerateFile.UseVisualStyleBackColor = False
        '
        'dgvEncabezado
        '
        Me.dgvEncabezado.AllowUserToAddRows = False
        Me.dgvEncabezado.AllowUserToDeleteRows = False
        Me.dgvEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvEncabezado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgvEncabezado.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvEncabezado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEncabezado.Location = New System.Drawing.Point(3, 3)
        Me.dgvEncabezado.Name = "dgvEncabezado"
        Me.dgvEncabezado.ReadOnly = True
        Me.dgvEncabezado.Size = New System.Drawing.Size(582, 150)
        Me.dgvEncabezado.TabIndex = 0
        '
        'tbpAgregar
        '
        Me.tbpAgregar.Controls.Add(Me.btnFind)
        Me.tbpAgregar.Controls.Add(Me.gbxAddDetalle)
        Me.tbpAgregar.Controls.Add(Me.dpFechaDep3)
        Me.tbpAgregar.Controls.Add(Me.Label11)
        Me.tbpAgregar.Controls.Add(Me.btnCancelar)
        Me.tbpAgregar.Controls.Add(Me.btnGuardar)
        Me.tbpAgregar.Controls.Add(Me.btnNuevo)
        Me.tbpAgregar.Controls.Add(Me.Label12)
        Me.tbpAgregar.Controls.Add(Me.txtConcepto)
        Me.tbpAgregar.Location = New System.Drawing.Point(4, 22)
        Me.tbpAgregar.Name = "tbpAgregar"
        Me.tbpAgregar.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpAgregar.Size = New System.Drawing.Size(936, 156)
        Me.tbpAgregar.TabIndex = 2
        Me.tbpAgregar.Text = "Varios Conceptos"
        Me.tbpAgregar.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(249, 6)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 23)
        Me.btnFind.TabIndex = 32
        Me.btnFind.Text = "Consultar"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'gbxAddDetalle
        '
        Me.gbxAddDetalle.Controls.Add(Me.txtNombre)
        Me.gbxAddDetalle.Controls.Add(Me.btnDeleteRow)
        Me.gbxAddDetalle.Controls.Add(Me.btnSaveRow)
        Me.gbxAddDetalle.Controls.Add(Me.Label14)
        Me.gbxAddDetalle.Controls.Add(Me.Label10)
        Me.gbxAddDetalle.Controls.Add(Me.btnNewRow)
        Me.gbxAddDetalle.Controls.Add(Me.txtCodigo)
        Me.gbxAddDetalle.Controls.Add(Me.txtValor)
        Me.gbxAddDetalle.Controls.Add(Me.Label13)
        Me.gbxAddDetalle.Controls.Add(Me.btnFindSocio)
        Me.gbxAddDetalle.Location = New System.Drawing.Point(9, 64)
        Me.gbxAddDetalle.Name = "gbxAddDetalle"
        Me.gbxAddDetalle.Size = New System.Drawing.Size(589, 74)
        Me.gbxAddDetalle.TabIndex = 31
        Me.gbxAddDetalle.TabStop = False
        Me.gbxAddDetalle.Text = "Agregar Socios"
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(106, 40)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(316, 20)
        Me.txtNombre.TabIndex = 33
        '
        'btnDeleteRow
        '
        Me.btnDeleteRow.Enabled = False
        Me.btnDeleteRow.Image = CType(resources.GetObject("btnDeleteRow.Image"), System.Drawing.Image)
        Me.btnDeleteRow.Location = New System.Drawing.Point(548, 37)
        Me.btnDeleteRow.Name = "btnDeleteRow"
        Me.btnDeleteRow.Size = New System.Drawing.Size(27, 25)
        Me.btnDeleteRow.TabIndex = 32
        Me.ToolTip1.SetToolTip(Me.btnDeleteRow, "Eliminar socio de la lista")
        Me.btnDeleteRow.UseVisualStyleBackColor = True
        '
        'btnSaveRow
        '
        Me.btnSaveRow.Enabled = False
        Me.btnSaveRow.Image = CType(resources.GetObject("btnSaveRow.Image"), System.Drawing.Image)
        Me.btnSaveRow.Location = New System.Drawing.Point(521, 37)
        Me.btnSaveRow.Name = "btnSaveRow"
        Me.btnSaveRow.Size = New System.Drawing.Size(27, 25)
        Me.btnSaveRow.TabIndex = 31
        Me.ToolTip1.SetToolTip(Me.btnSaveRow, "Agregar Socio a la lista")
        Me.btnSaveRow.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(103, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Nombre del  Socio"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Còdigo Socio"
        '
        'btnNewRow
        '
        Me.btnNewRow.Enabled = False
        Me.btnNewRow.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.btnNewRow.Location = New System.Drawing.Point(494, 37)
        Me.btnNewRow.Name = "btnNewRow"
        Me.btnNewRow.Size = New System.Drawing.Size(27, 25)
        Me.btnNewRow.TabIndex = 29
        Me.ToolTip1.SetToolTip(Me.btnNewRow, "Nuevo socio")
        Me.btnNewRow.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(6, 39)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(73, 20)
        Me.txtCodigo.TabIndex = 4
        '
        'txtValor
        '
        Me.txtValor.Enabled = False
        Me.txtValor.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor.ForeColor = System.Drawing.Color.Red
        Me.txtValor.Location = New System.Drawing.Point(427, 38)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(61, 22)
        Me.txtValor.TabIndex = 6
        Me.txtValor.Text = "0.00"
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(429, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Valor"
        '
        'btnFindSocio
        '
        Me.btnFindSocio.Enabled = False
        Me.btnFindSocio.Image = Global.ASTAS.My.Resources.Resources.search
        Me.btnFindSocio.Location = New System.Drawing.Point(79, 38)
        Me.btnFindSocio.Name = "btnFindSocio"
        Me.btnFindSocio.Size = New System.Drawing.Size(26, 23)
        Me.btnFindSocio.TabIndex = 5
        Me.btnFindSocio.UseVisualStyleBackColor = True
        '
        'dpFechaDep3
        '
        Me.dpFechaDep3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaDep3.Location = New System.Drawing.Point(384, 38)
        Me.dpFechaDep3.Name = "dpFechaDep3"
        Me.dpFechaDep3.Size = New System.Drawing.Size(101, 20)
        Me.dpFechaDep3.TabIndex = 27
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(297, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Fecha Remesa:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Location = New System.Drawing.Point(168, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Location = New System.Drawing.Point(87, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(9, 6)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 41)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Concepto Deposito:"
        '
        'txtConcepto
        '
        Me.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConcepto.Enabled = False
        Me.txtConcepto.Location = New System.Drawing.Point(110, 38)
        Me.txtConcepto.MaxLength = 25
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(184, 20)
        Me.txtConcepto.TabIndex = 3
        '
        'tbpDividendos
        '
        Me.tbpDividendos.Controls.Add(Me.Label22)
        Me.tbpDividendos.Controls.Add(Me.txtTotal)
        Me.tbpDividendos.Controls.Add(Me.dpFechaDep4)
        Me.tbpDividendos.Controls.Add(Me.Label21)
        Me.tbpDividendos.Controls.Add(Me.GroupBox7)
        Me.tbpDividendos.Controls.Add(Me.cmbBanco3)
        Me.tbpDividendos.Controls.Add(Me.Label19)
        Me.tbpDividendos.Controls.Add(Me.Label20)
        Me.tbpDividendos.Controls.Add(Me.cmbCuentaBanco3)
        Me.tbpDividendos.Controls.Add(Me.btnGenerar2)
        Me.tbpDividendos.Controls.Add(Me.Label18)
        Me.tbpDividendos.Controls.Add(Me.txtConceptoDeposito3)
        Me.tbpDividendos.Controls.Add(Me.btnCargar2)
        Me.tbpDividendos.Controls.Add(Me.Label17)
        Me.tbpDividendos.Controls.Add(Me.txtDesde)
        Me.tbpDividendos.Controls.Add(Me.txtHasta)
        Me.tbpDividendos.Controls.Add(Me.Label15)
        Me.tbpDividendos.Controls.Add(Me.nudReparto)
        Me.tbpDividendos.Controls.Add(Me.Label16)
        Me.tbpDividendos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDividendos.Name = "tbpDividendos"
        Me.tbpDividendos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDividendos.Size = New System.Drawing.Size(936, 156)
        Me.tbpDividendos.TabIndex = 3
        Me.tbpDividendos.Text = "Dividendos"
        Me.tbpDividendos.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(34, 108)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 13)
        Me.Label22.TabIndex = 133
        Me.Label22.Text = "Total Liquido:"
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(111, 105)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 132
        '
        'dpFechaDep4
        '
        Me.dpFechaDep4.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaDep4.Location = New System.Drawing.Point(453, 62)
        Me.dpFechaDep4.Name = "dpFechaDep4"
        Me.dpFechaDep4.Size = New System.Drawing.Size(101, 20)
        Me.dpFechaDep4.TabIndex = 130
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(368, 65)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(82, 13)
        Me.Label21.TabIndex = 131
        Me.Label21.Text = "Fecha Remesa:"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.rbAtaf)
        Me.GroupBox7.Controls.Add(Me.rbAstas)
        Me.GroupBox7.Location = New System.Drawing.Point(174, 70)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(135, 28)
        Me.GroupBox7.TabIndex = 129
        Me.GroupBox7.TabStop = False
        '
        'rbAtaf
        '
        Me.rbAtaf.AutoSize = True
        Me.rbAtaf.ForeColor = System.Drawing.Color.Black
        Me.rbAtaf.Location = New System.Drawing.Point(74, 9)
        Me.rbAtaf.Name = "rbAtaf"
        Me.rbAtaf.Size = New System.Drawing.Size(52, 17)
        Me.rbAtaf.TabIndex = 22
        Me.rbAtaf.TabStop = True
        Me.rbAtaf.Text = "ATAF"
        Me.rbAtaf.UseVisualStyleBackColor = True
        '
        'rbAstas
        '
        Me.rbAstas.AutoSize = True
        Me.rbAstas.ForeColor = System.Drawing.Color.Black
        Me.rbAstas.Location = New System.Drawing.Point(4, 9)
        Me.rbAstas.Name = "rbAstas"
        Me.rbAstas.Size = New System.Drawing.Size(60, 17)
        Me.rbAstas.TabIndex = 28
        Me.rbAstas.TabStop = True
        Me.rbAstas.Text = "ASTAS"
        Me.rbAstas.UseVisualStyleBackColor = True
        '
        'cmbBanco3
        '
        Me.cmbBanco3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco3.FormattingEnabled = True
        Me.cmbBanco3.Location = New System.Drawing.Point(453, 8)
        Me.cmbBanco3.Name = "cmbBanco3"
        Me.cmbBanco3.Size = New System.Drawing.Size(203, 21)
        Me.cmbBanco3.TabIndex = 126
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(402, 11)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 13)
        Me.Label19.TabIndex = 125
        Me.Label19.Text = "Banco:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(358, 38)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(89, 13)
        Me.Label20.TabIndex = 124
        Me.Label20.Text = "Cuenta Bancaria:"
        '
        'cmbCuentaBanco3
        '
        Me.cmbCuentaBanco3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuentaBanco3.FormattingEnabled = True
        Me.cmbCuentaBanco3.Location = New System.Drawing.Point(453, 35)
        Me.cmbCuentaBanco3.Name = "cmbCuentaBanco3"
        Me.cmbCuentaBanco3.Size = New System.Drawing.Size(240, 21)
        Me.cmbCuentaBanco3.TabIndex = 123
        '
        'btnGenerar2
        '
        Me.btnGenerar2.BackColor = System.Drawing.Color.Transparent
        Me.btnGenerar2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar2.Location = New System.Drawing.Point(699, 6)
        Me.btnGenerar2.Name = "btnGenerar2"
        Me.btnGenerar2.Size = New System.Drawing.Size(90, 56)
        Me.btnGenerar2.TabIndex = 122
        Me.btnGenerar2.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Archivo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Banco"
        Me.btnGenerar2.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 13)
        Me.Label18.TabIndex = 121
        Me.Label18.Text = "Concepto Deposito:"
        '
        'txtConceptoDeposito3
        '
        Me.txtConceptoDeposito3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConceptoDeposito3.Enabled = False
        Me.txtConceptoDeposito3.Location = New System.Drawing.Point(111, 5)
        Me.txtConceptoDeposito3.MaxLength = 25
        Me.txtConceptoDeposito3.Name = "txtConceptoDeposito3"
        Me.txtConceptoDeposito3.Size = New System.Drawing.Size(200, 20)
        Me.txtConceptoDeposito3.TabIndex = 120
        Me.txtConceptoDeposito3.Text = "DIVIDENDOS"
        '
        'btnCargar2
        '
        Me.btnCargar2.BackColor = System.Drawing.Color.Transparent
        Me.btnCargar2.Location = New System.Drawing.Point(234, 102)
        Me.btnCargar2.Name = "btnCargar2"
        Me.btnCargar2.Size = New System.Drawing.Size(75, 23)
        Me.btnCargar2.TabIndex = 119
        Me.btnCargar2.Text = "&Cargar"
        Me.btnCargar2.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(58, 79)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 118
        Me.Label17.Text = "Reparto:"
        '
        'txtDesde
        '
        Me.txtDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDesde.Location = New System.Drawing.Point(111, 28)
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.Size = New System.Drawing.Size(200, 20)
        Me.txtDesde.TabIndex = 113
        '
        'txtHasta
        '
        Me.txtHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtHasta.Location = New System.Drawing.Point(111, 49)
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.Size = New System.Drawing.Size(200, 20)
        Me.txtHasta.TabIndex = 114
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(68, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 13)
        Me.Label15.TabIndex = 116
        Me.Label15.Text = "Hasta:"
        '
        'nudReparto
        '
        Me.nudReparto.Location = New System.Drawing.Point(111, 77)
        Me.nudReparto.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.nudReparto.Name = "nudReparto"
        Me.nudReparto.Size = New System.Drawing.Size(57, 20)
        Me.nudReparto.TabIndex = 117
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(65, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 115
        Me.Label16.Text = "Desde:"
        '
        'CooperativaDepositosBecas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 414)
        Me.Controls.Add(Me.tabEncabezado)
        Me.Controls.Add(Me.dgvAutorizaciones)
        Me.Name = "CooperativaDepositosBecas"
        Me.Text = "Cooperativa - Remesas por Conceptos Varios"
        CType(Me.dgvAutorizaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEncabezado.ResumeLayout(False)
        Me.tbpCargar.ResumeLayout(False)
        Me.tbpCargar.PerformLayout()
        Me.tbpConsultar.ResumeLayout(False)
        Me.tbpConsultar.PerformLayout()
        CType(Me.dgvEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpAgregar.ResumeLayout(False)
        Me.tbpAgregar.PerformLayout()
        Me.gbxAddDetalle.ResumeLayout(False)
        Me.gbxAddDetalle.PerformLayout()
        Me.tbpDividendos.ResumeLayout(False)
        Me.tbpDividendos.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.nudReparto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAutorizaciones As System.Windows.Forms.DataGridView
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnArchivo As System.Windows.Forms.Button
    Friend WithEvents cmbSheets As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dpFechaDep As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cmbCuentaBancaria As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents txtConceptoDeposito As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tabEncabezado As System.Windows.Forms.TabControl
    Friend WithEvents tbpCargar As System.Windows.Forms.TabPage
    Friend WithEvents tbpConsultar As System.Windows.Forms.TabPage
    Friend WithEvents dgvEncabezado As System.Windows.Forms.DataGridView
    Friend WithEvents btnGenerateFile As System.Windows.Forms.Button
    Friend WithEvents cmbBanco2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtConceptoDeposito2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbCuentaBanco2 As System.Windows.Forms.ComboBox
    Friend WithEvents dpFechaDep2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbpAgregar As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnFindSocio As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents dpFechaDep3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnNewRow As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents gbxAddDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents btnDeleteRow As System.Windows.Forms.Button
    Friend WithEvents btnSaveRow As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents tbpDividendos As System.Windows.Forms.TabPage
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents nudReparto As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnCargar2 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtConceptoDeposito3 As System.Windows.Forms.TextBox
    Friend WithEvents btnGenerar2 As System.Windows.Forms.Button
    Friend WithEvents cmbBanco3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbCuentaBanco3 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAtaf As System.Windows.Forms.RadioButton
    Friend WithEvents rbAstas As System.Windows.Forms.RadioButton
    Friend WithEvents dpFechaDep4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label

End Class
