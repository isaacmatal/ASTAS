<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_BusquedaTransaccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_BusquedaTransaccion))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.cmbLIBRO_CONTABLE = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dpFECHA_FIN = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dpFECHA_INI = New System.Windows.Forms.DateTimePicker
        Me.dgvTransacciones = New System.Windows.Forms.DataGridView
        Me.Transaccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Documento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Partida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaContable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Concepto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Anulada = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AnuladaPor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsuarioC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtDOCUMENTO = New System.Windows.Forms.TextBox
        Me.txtPARTIDA = New System.Windows.Forms.TextBox
        Me.txtCONCEPTO = New System.Windows.Forms.TextBox
        Me.txtESTADO = New System.Windows.Forms.TextBox
        Me.txtFECHACONTABLE = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvTransacciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.cmbLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dpFECHA_FIN)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dpFECHA_INI)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(500, 88)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'btnBuscar
        '
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(440, 51)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbLIBRO_CONTABLE
        '
        Me.cmbLIBRO_CONTABLE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLIBRO_CONTABLE.Enabled = False
        Me.cmbLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE.Location = New System.Drawing.Point(110, 18)
        Me.cmbLIBRO_CONTABLE.Name = "cmbLIBRO_CONTABLE"
        Me.cmbLIBRO_CONTABLE.Size = New System.Drawing.Size(384, 24)
        Me.cmbLIBRO_CONTABLE.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(12, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Libro Contable :"
        '
        'dpFECHA_FIN
        '
        Me.dpFECHA_FIN.CalendarForeColor = System.Drawing.Color.Navy
        Me.dpFECHA_FIN.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.dpFECHA_FIN.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_FIN.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_FIN.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_FIN.Location = New System.Drawing.Point(349, 53)
        Me.dpFECHA_FIN.Name = "dpFECHA_FIN"
        Me.dpFECHA_FIN.Size = New System.Drawing.Size(88, 22)
        Me.dpFECHA_FIN.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(299, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Hasta :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(109, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Desde :"
        '
        'dpFECHA_INI
        '
        Me.dpFECHA_INI.CalendarForeColor = System.Drawing.Color.Navy
        Me.dpFECHA_INI.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.dpFECHA_INI.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_INI.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_INI.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_INI.Location = New System.Drawing.Point(165, 53)
        Me.dpFECHA_INI.Name = "dpFECHA_INI"
        Me.dpFECHA_INI.Size = New System.Drawing.Size(88, 22)
        Me.dpFECHA_INI.TabIndex = 0
        '
        'dgvTransacciones
        '
        Me.dgvTransacciones.AllowUserToAddRows = False
        Me.dgvTransacciones.AllowUserToDeleteRows = False
        Me.dgvTransacciones.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightGray
        Me.dgvTransacciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvTransacciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTransacciones.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvTransacciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransacciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransacciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Transaccion, Me.Documento, Me.Partida, Me.FechaContable, Me.Concepto, Me.Anulada, Me.AnuladaPor, Me.UsuarioC, Me.FechaC})
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTransacciones.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgvTransacciones.Location = New System.Drawing.Point(12, 142)
        Me.dgvTransacciones.MultiSelect = False
        Me.dgvTransacciones.Name = "dgvTransacciones"
        Me.dgvTransacciones.ReadOnly = True
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransacciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvTransacciones.RowHeadersVisible = False
        Me.dgvTransacciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransacciones.Size = New System.Drawing.Size(843, 290)
        Me.dgvTransacciones.TabIndex = 5
        '
        'Transaccion
        '
        Me.Transaccion.DataPropertyName = "TRANSACCION"
        Me.Transaccion.HeaderText = "N° Trans"
        Me.Transaccion.Name = "Transaccion"
        Me.Transaccion.ReadOnly = True
        Me.Transaccion.Visible = False
        Me.Transaccion.Width = 59
        '
        'Documento
        '
        Me.Documento.DataPropertyName = "DOCUMENTO"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Documento.DefaultCellStyle = DataGridViewCellStyle15
        Me.Documento.HeaderText = "N° Doc"
        Me.Documento.Name = "Documento"
        Me.Documento.ReadOnly = True
        Me.Documento.Width = 70
        '
        'Partida
        '
        Me.Partida.DataPropertyName = "PARTIDA"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Partida.DefaultCellStyle = DataGridViewCellStyle16
        Me.Partida.HeaderText = "Partida"
        Me.Partida.Name = "Partida"
        Me.Partida.ReadOnly = True
        Me.Partida.Width = 50
        '
        'FechaContable
        '
        Me.FechaContable.DataPropertyName = "FECHA_CONTABLE"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FechaContable.DefaultCellStyle = DataGridViewCellStyle17
        Me.FechaContable.HeaderText = "Fecha Contable"
        Me.FechaContable.Name = "FechaContable"
        Me.FechaContable.ReadOnly = True
        Me.FechaContable.Width = 80
        '
        'Concepto
        '
        Me.Concepto.DataPropertyName = "CONCEPTO"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Concepto.DefaultCellStyle = DataGridViewCellStyle18
        Me.Concepto.HeaderText = "Concepto"
        Me.Concepto.Name = "Concepto"
        Me.Concepto.ReadOnly = True
        Me.Concepto.Width = 320
        '
        'Anulada
        '
        Me.Anulada.DataPropertyName = "ESTADO"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Anulada.DefaultCellStyle = DataGridViewCellStyle19
        Me.Anulada.HeaderText = "Estado"
        Me.Anulada.Name = "Anulada"
        Me.Anulada.ReadOnly = True
        '
        'AnuladaPor
        '
        Me.AnuladaPor.DataPropertyName = "PARTIDA_ANULA"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.AnuladaPor.DefaultCellStyle = DataGridViewCellStyle20
        Me.AnuladaPor.HeaderText = "Partida Anulación"
        Me.AnuladaPor.Name = "AnuladaPor"
        Me.AnuladaPor.ReadOnly = True
        Me.AnuladaPor.Width = 60
        '
        'UsuarioC
        '
        Me.UsuarioC.DataPropertyName = "USUARIO_CREACION"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.UsuarioC.DefaultCellStyle = DataGridViewCellStyle21
        Me.UsuarioC.HeaderText = "Usuario Creación"
        Me.UsuarioC.Name = "UsuarioC"
        Me.UsuarioC.ReadOnly = True
        Me.UsuarioC.Width = 70
        '
        'FechaC
        '
        Me.FechaC.DataPropertyName = "USUARIO_CREACION_FECHA"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FechaC.DefaultCellStyle = DataGridViewCellStyle22
        Me.FechaC.HeaderText = "Fecha Creación"
        Me.FechaC.Name = "FechaC"
        Me.FechaC.ReadOnly = True
        Me.FechaC.Width = 80
        '
        'txtDOCUMENTO
        '
        Me.txtDOCUMENTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtDOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDOCUMENTO.ForeColor = System.Drawing.Color.Navy
        Me.txtDOCUMENTO.Location = New System.Drawing.Point(12, 118)
        Me.txtDOCUMENTO.MaxLength = 8
        Me.txtDOCUMENTO.Name = "txtDOCUMENTO"
        Me.txtDOCUMENTO.Size = New System.Drawing.Size(103, 22)
        Me.txtDOCUMENTO.TabIndex = 0
        Me.txtDOCUMENTO.Tag = "Documento"
        '
        'txtPARTIDA
        '
        Me.txtPARTIDA.BackColor = System.Drawing.SystemColors.Window
        Me.txtPARTIDA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPARTIDA.ForeColor = System.Drawing.Color.Navy
        Me.txtPARTIDA.Location = New System.Drawing.Point(116, 118)
        Me.txtPARTIDA.MaxLength = 8
        Me.txtPARTIDA.Name = "txtPARTIDA"
        Me.txtPARTIDA.Size = New System.Drawing.Size(72, 22)
        Me.txtPARTIDA.TabIndex = 1
        Me.txtPARTIDA.Tag = "Partida"
        Me.txtPARTIDA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCONCEPTO
        '
        Me.txtCONCEPTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONCEPTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONCEPTO.ForeColor = System.Drawing.Color.Navy
        Me.txtCONCEPTO.Location = New System.Drawing.Point(285, 118)
        Me.txtCONCEPTO.MaxLength = 50
        Me.txtCONCEPTO.Name = "txtCONCEPTO"
        Me.txtCONCEPTO.Size = New System.Drawing.Size(361, 22)
        Me.txtCONCEPTO.TabIndex = 3
        Me.txtCONCEPTO.Tag = "Concepto"
        '
        'txtESTADO
        '
        Me.txtESTADO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtESTADO.Location = New System.Drawing.Point(647, 118)
        Me.txtESTADO.Name = "txtESTADO"
        Me.txtESTADO.Size = New System.Drawing.Size(105, 22)
        Me.txtESTADO.TabIndex = 4
        Me.txtESTADO.Tag = "ESTADO"
        '
        'txtFECHACONTABLE
        '
        Me.txtFECHACONTABLE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFECHACONTABLE.Location = New System.Drawing.Point(189, 118)
        Me.txtFECHACONTABLE.Name = "txtFECHACONTABLE"
        Me.txtFECHACONTABLE.Size = New System.Drawing.Size(95, 22)
        Me.txtFECHACONTABLE.TabIndex = 2
        Me.txtFECHACONTABLE.Tag = "FECHA_CONTABLE"
        Me.txtFECHACONTABLE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(648, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 20)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Estado"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(286, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(359, 20)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Concepto"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(191, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 20)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(118, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 20)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "N° Partida"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(13, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 20)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "N° Doc"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(755, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 20)
        Me.Label9.TabIndex = 78
        Me.Label9.Text = "Usuario"
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtUsuario.Location = New System.Drawing.Point(754, 118)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(97, 22)
        Me.txtUsuario.TabIndex = 77
        Me.txtUsuario.Tag = "USUARIO_CREACION"
        '
        'Contabilidad_BusquedaTransaccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 444)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtFECHACONTABLE)
        Me.Controls.Add(Me.txtESTADO)
        Me.Controls.Add(Me.txtCONCEPTO)
        Me.Controls.Add(Me.txtPARTIDA)
        Me.Controls.Add(Me.txtDOCUMENTO)
        Me.Controls.Add(Me.dgvTransacciones)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_BusquedaTransaccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Búsqueda Partidas Contables"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvTransacciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbLIBRO_CONTABLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvTransacciones As System.Windows.Forms.DataGridView
    Friend WithEvents txtDOCUMENTO As System.Windows.Forms.TextBox
    Friend WithEvents txtPARTIDA As System.Windows.Forms.TextBox
    Friend WithEvents txtCONCEPTO As System.Windows.Forms.TextBox
    Friend WithEvents dpFECHA_INI As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpFECHA_FIN As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Transaccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Documento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaContable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Concepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Anulada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AnuladaPor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtESTADO As System.Windows.Forms.TextBox
    Friend WithEvents txtFECHACONTABLE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
End Class
