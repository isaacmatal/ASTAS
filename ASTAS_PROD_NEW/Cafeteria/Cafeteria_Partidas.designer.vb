<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Partidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Partidas))
        Me.cmbCajas = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbCafeteria = New System.Windows.Forms.ComboBox
        Me.lblCafeteria = New System.Windows.Forms.Label
        Me.dgvMovtos = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.lblTransaccionAnula = New System.Windows.Forms.Label
        Me.lblAnulada = New System.Windows.Forms.Label
        Me.txtPARTIDA = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTRANSACCION = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dpFECHA_CONTABLE = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCONCEPTO = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDOCUMENTO = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbTIPO_DOCUMENTO = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbTIPO_PARTIDA = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbLIBRO_CONTABLE = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.btnCargar = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtCARGOS = New System.Windows.Forms.TextBox
        Me.txtDIFERENCIA = New System.Windows.Forms.TextBox
        Me.txtABONOS = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.dpFECHA_FACTURACION = New System.Windows.Forms.DateTimePicker
        Me.txtCONCEPTO_L = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCUENTA_COMPLETA = New System.Windows.Forms.TextBox
        Me.cmbCENTRO_COSTO = New System.Windows.Forms.ComboBox
        Me.txtMONTO = New System.Windows.Forms.TextBox
        Me.cmbCARGO_ABONO = New System.Windows.Forms.ComboBox
        Me.lblCuenta = New System.Windows.Forms.Label
        Me.btnGuardarLinea = New System.Windows.Forms.Button
        Me.btnBuscarCuenta = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        CType(Me.dgvMovtos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbCajas
        '
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.Location = New System.Drawing.Point(96, 57)
        Me.cmbCajas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(179, 24)
        Me.cmbCajas.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 16)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Caja :"
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(96, 27)
        Me.txtCompañia.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(384, 22)
        Me.txtCompañia.TabIndex = 87
        Me.txtCompañia.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Compañía"
        '
        'cbCafeteria
        '
        Me.cbCafeteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCafeteria.FormattingEnabled = True
        Me.cbCafeteria.Location = New System.Drawing.Point(96, 23)
        Me.cbCafeteria.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbCafeteria.Name = "cbCafeteria"
        Me.cbCafeteria.Size = New System.Drawing.Size(384, 24)
        Me.cbCafeteria.TabIndex = 0
        '
        'lblCafeteria
        '
        Me.lblCafeteria.AutoSize = True
        Me.lblCafeteria.Location = New System.Drawing.Point(8, 22)
        Me.lblCafeteria.Name = "lblCafeteria"
        Me.lblCafeteria.Size = New System.Drawing.Size(56, 16)
        Me.lblCafeteria.TabIndex = 0
        Me.lblCafeteria.Text = "Cafetería :"
        '
        'dgvMovtos
        '
        Me.dgvMovtos.AllowUserToAddRows = False
        Me.dgvMovtos.BackgroundColor = System.Drawing.Color.White
        Me.dgvMovtos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovtos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMovtos.Location = New System.Drawing.Point(3, 19)
        Me.dgvMovtos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvMovtos.Name = "dgvMovtos"
        Me.dgvMovtos.ReadOnly = True
        Me.dgvMovtos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovtos.Size = New System.Drawing.Size(765, 180)
        Me.dgvMovtos.TabIndex = 84
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.lblTransaccionAnula)
        Me.GroupBox1.Controls.Add(Me.lblAnulada)
        Me.GroupBox1.Controls.Add(Me.txtPARTIDA)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtTRANSACCION)
        Me.GroupBox1.Controls.Add(Me.txtCompañia)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dpFECHA_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCONCEPTO)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtDOCUMENTO)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmbTIPO_DOCUMENTO)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbTIPO_PARTIDA)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmbLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(771, 218)
        Me.GroupBox1.TabIndex = 85
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Partidas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(92, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(363, 22)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(675, 30)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 30)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "&Nuevo"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblTransaccionAnula
        '
        Me.lblTransaccionAnula.BackColor = System.Drawing.Color.Yellow
        Me.lblTransaccionAnula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransaccionAnula.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransaccionAnula.ForeColor = System.Drawing.Color.Red
        Me.lblTransaccionAnula.Location = New System.Drawing.Point(608, 130)
        Me.lblTransaccionAnula.Name = "lblTransaccionAnula"
        Me.lblTransaccionAnula.Size = New System.Drawing.Size(64, 29)
        Me.lblTransaccionAnula.TabIndex = 60
        Me.lblTransaccionAnula.Visible = False
        '
        'lblAnulada
        '
        Me.lblAnulada.BackColor = System.Drawing.Color.Yellow
        Me.lblAnulada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAnulada.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnulada.ForeColor = System.Drawing.Color.Red
        Me.lblAnulada.Location = New System.Drawing.Point(512, 130)
        Me.lblAnulada.Name = "lblAnulada"
        Me.lblAnulada.Size = New System.Drawing.Size(96, 29)
        Me.lblAnulada.TabIndex = 59
        Me.lblAnulada.Text = "ANULADA"
        Me.lblAnulada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAnulada.Visible = False
        '
        'txtPARTIDA
        '
        Me.txtPARTIDA.BackColor = System.Drawing.Color.Yellow
        Me.txtPARTIDA.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPARTIDA.ForeColor = System.Drawing.Color.Red
        Me.txtPARTIDA.Location = New System.Drawing.Point(608, 91)
        Me.txtPARTIDA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPARTIDA.Name = "txtPARTIDA"
        Me.txtPARTIDA.ReadOnly = True
        Me.txtPARTIDA.Size = New System.Drawing.Size(64, 25)
        Me.txtPARTIDA.TabIndex = 56
        Me.txtPARTIDA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(512, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 29)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Transacción :"
        '
        'txtTRANSACCION
        '
        Me.txtTRANSACCION.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRANSACCION.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRANSACCION.ForeColor = System.Drawing.Color.Navy
        Me.txtTRANSACCION.Location = New System.Drawing.Point(608, 30)
        Me.txtTRANSACCION.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTRANSACCION.Name = "txtTRANSACCION"
        Me.txtTRANSACCION.ReadOnly = True
        Me.txtTRANSACCION.Size = New System.Drawing.Size(64, 25)
        Me.txtTRANSACCION.TabIndex = 1
        Me.txtTRANSACCION.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(512, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 29)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "N° Partida :"
        '
        'dpFECHA_CONTABLE
        '
        Me.dpFECHA_CONTABLE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CONTABLE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CONTABLE.Location = New System.Drawing.Point(96, 150)
        Me.dpFECHA_CONTABLE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFECHA_CONTABLE.Name = "dpFECHA_CONTABLE"
        Me.dpFECHA_CONTABLE.Size = New System.Drawing.Size(112, 22)
        Me.dpFECHA_CONTABLE.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 16)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Fecha Contable :"
        '
        'txtCONCEPTO
        '
        Me.txtCONCEPTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONCEPTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONCEPTO.ForeColor = System.Drawing.Color.Navy
        Me.txtCONCEPTO.Location = New System.Drawing.Point(96, 180)
        Me.txtCONCEPTO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCONCEPTO.MaxLength = 75
        Me.txtCONCEPTO.Name = "txtCONCEPTO"
        Me.txtCONCEPTO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCONCEPTO.Size = New System.Drawing.Size(648, 22)
        Me.txtCONCEPTO.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(8, 180)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Concepto Gral. :"
        '
        'txtDOCUMENTO
        '
        Me.txtDOCUMENTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtDOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDOCUMENTO.ForeColor = System.Drawing.Color.Navy
        Me.txtDOCUMENTO.Location = New System.Drawing.Point(96, 121)
        Me.txtDOCUMENTO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDOCUMENTO.Name = "txtDOCUMENTO"
        Me.txtDOCUMENTO.Size = New System.Drawing.Size(112, 22)
        Me.txtDOCUMENTO.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 16)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "N° Documento :"
        '
        'cmbTIPO_DOCUMENTO
        '
        Me.cmbTIPO_DOCUMENTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_DOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_DOCUMENTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_DOCUMENTO.FormattingEnabled = True
        Me.cmbTIPO_DOCUMENTO.Location = New System.Drawing.Point(96, 91)
        Me.cmbTIPO_DOCUMENTO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbTIPO_DOCUMENTO.Name = "cmbTIPO_DOCUMENTO"
        Me.cmbTIPO_DOCUMENTO.Size = New System.Drawing.Size(184, 24)
        Me.cmbTIPO_DOCUMENTO.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Tipo Documento :"
        '
        'cmbTIPO_PARTIDA
        '
        Me.cmbTIPO_PARTIDA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_PARTIDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_PARTIDA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_PARTIDA.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_PARTIDA.FormattingEnabled = True
        Me.cmbTIPO_PARTIDA.Location = New System.Drawing.Point(392, 91)
        Me.cmbTIPO_PARTIDA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbTIPO_PARTIDA.Name = "cmbTIPO_PARTIDA"
        Me.cmbTIPO_PARTIDA.Size = New System.Drawing.Size(88, 24)
        Me.cmbTIPO_PARTIDA.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(312, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 16)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Tipo Partida :"
        '
        'cmbLIBRO_CONTABLE
        '
        Me.cmbLIBRO_CONTABLE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE.Location = New System.Drawing.Point(96, 62)
        Me.cmbLIBRO_CONTABLE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbLIBRO_CONTABLE.Name = "cmbLIBRO_CONTABLE"
        Me.cmbLIBRO_CONTABLE.Size = New System.Drawing.Size(384, 24)
        Me.cmbLIBRO_CONTABLE.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 62)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 16)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Libro Contable :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnProcesar)
        Me.GroupBox2.Controls.Add(Me.btnCargar)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtCARGOS)
        Me.GroupBox2.Controls.Add(Me.txtDIFERENCIA)
        Me.GroupBox2.Controls.Add(Me.txtABONOS)
        Me.GroupBox2.Controls.Add(Me.cbCafeteria)
        Me.GroupBox2.Controls.Add(Me.lblCafeteria)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cmbCajas)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.dpFECHA_FACTURACION)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 218)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(771, 134)
        Me.GroupBox2.TabIndex = 86
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalles de Partidas"
        '
        'btnProcesar
        '
        Me.btnProcesar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnProcesar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(675, 81)
        Me.btnProcesar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 30)
        Me.btnProcesar.TabIndex = 4
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcesar.UseVisualStyleBackColor = True
        Me.btnProcesar.Visible = False
        '
        'btnCargar
        '
        Me.btnCargar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnCargar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCargar.Image = Global.ASTAS.My.Resources.Resources.down
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargar.Location = New System.Drawing.Point(675, 23)
        Me.btnCargar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(80, 30)
        Me.btnCargar.TabIndex = 3
        Me.btnCargar.Text = "&Cargar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(488, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 16)
        Me.Label14.TabIndex = 95
        Me.Label14.Text = "Total Cargos :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(488, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 16)
        Me.Label15.TabIndex = 96
        Me.Label15.Text = "Total Abonos :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(488, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 16)
        Me.Label16.TabIndex = 100
        Me.Label16.Text = "Diferencia :"
        '
        'txtCARGOS
        '
        Me.txtCARGOS.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCARGOS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCARGOS.ForeColor = System.Drawing.Color.Navy
        Me.txtCARGOS.Location = New System.Drawing.Point(564, 23)
        Me.txtCARGOS.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCARGOS.Name = "txtCARGOS"
        Me.txtCARGOS.ReadOnly = True
        Me.txtCARGOS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCARGOS.Size = New System.Drawing.Size(104, 22)
        Me.txtCARGOS.TabIndex = 97
        Me.txtCARGOS.Text = "0.0"
        '
        'txtDIFERENCIA
        '
        Me.txtDIFERENCIA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDIFERENCIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIFERENCIA.ForeColor = System.Drawing.Color.Red
        Me.txtDIFERENCIA.Location = New System.Drawing.Point(564, 82)
        Me.txtDIFERENCIA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDIFERENCIA.Name = "txtDIFERENCIA"
        Me.txtDIFERENCIA.ReadOnly = True
        Me.txtDIFERENCIA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDIFERENCIA.Size = New System.Drawing.Size(104, 22)
        Me.txtDIFERENCIA.TabIndex = 99
        Me.txtDIFERENCIA.Text = "0.0"
        '
        'txtABONOS
        '
        Me.txtABONOS.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtABONOS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtABONOS.ForeColor = System.Drawing.Color.Navy
        Me.txtABONOS.Location = New System.Drawing.Point(564, 53)
        Me.txtABONOS.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtABONOS.Name = "txtABONOS"
        Me.txtABONOS.ReadOnly = True
        Me.txtABONOS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtABONOS.Size = New System.Drawing.Size(104, 22)
        Me.txtABONOS.TabIndex = 98
        Me.txtABONOS.Text = "0.0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(8, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 16)
        Me.Label13.TabIndex = 91
        Me.Label13.Text = "Fecha:"
        '
        'dpFECHA_FACTURACION
        '
        Me.dpFECHA_FACTURACION.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_FACTURACION.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_FACTURACION.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_FACTURACION.Location = New System.Drawing.Point(96, 94)
        Me.dpFECHA_FACTURACION.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFECHA_FACTURACION.Name = "dpFECHA_FACTURACION"
        Me.dpFECHA_FACTURACION.Size = New System.Drawing.Size(112, 22)
        Me.dpFECHA_FACTURACION.TabIndex = 2
        '
        'txtCONCEPTO_L
        '
        Me.txtCONCEPTO_L.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONCEPTO_L.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONCEPTO_L.ForeColor = System.Drawing.Color.Navy
        Me.txtCONCEPTO_L.Location = New System.Drawing.Point(126, 49)
        Me.txtCONCEPTO_L.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCONCEPTO_L.MaxLength = 100
        Me.txtCONCEPTO_L.Name = "txtCONCEPTO_L"
        Me.txtCONCEPTO_L.ReadOnly = True
        Me.txtCONCEPTO_L.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCONCEPTO_L.Size = New System.Drawing.Size(376, 22)
        Me.txtCONCEPTO_L.TabIndex = 88
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Teal
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(6, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(761, 25)
        Me.Label12.TabIndex = 94
        Me.Label12.Text = "Cuenta                           Concepto                                        " & _
            "                                                                     Monto      " & _
            "       Cargo/Abono   Centro de Costos"
        '
        'txtCUENTA_COMPLETA
        '
        Me.txtCUENTA_COMPLETA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCUENTA_COMPLETA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUENTA_COMPLETA.ForeColor = System.Drawing.Color.Navy
        Me.txtCUENTA_COMPLETA.Location = New System.Drawing.Point(6, 49)
        Me.txtCUENTA_COMPLETA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCUENTA_COMPLETA.Name = "txtCUENTA_COMPLETA"
        Me.txtCUENTA_COMPLETA.ReadOnly = True
        Me.txtCUENTA_COMPLETA.Size = New System.Drawing.Size(96, 22)
        Me.txtCUENTA_COMPLETA.TabIndex = 0
        '
        'cmbCENTRO_COSTO
        '
        Me.cmbCENTRO_COSTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCENTRO_COSTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCENTRO_COSTO.DropDownWidth = 200
        Me.cmbCENTRO_COSTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCENTRO_COSTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbCENTRO_COSTO.FormattingEnabled = True
        Me.cmbCENTRO_COSTO.Location = New System.Drawing.Point(662, 47)
        Me.cmbCENTRO_COSTO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCENTRO_COSTO.Name = "cmbCENTRO_COSTO"
        Me.cmbCENTRO_COSTO.Size = New System.Drawing.Size(80, 24)
        Me.cmbCENTRO_COSTO.TabIndex = 4
        '
        'txtMONTO
        '
        Me.txtMONTO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtMONTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMONTO.ForeColor = System.Drawing.Color.Navy
        Me.txtMONTO.Location = New System.Drawing.Point(502, 49)
        Me.txtMONTO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMONTO.Name = "txtMONTO"
        Me.txtMONTO.Size = New System.Drawing.Size(80, 22)
        Me.txtMONTO.TabIndex = 2
        Me.txtMONTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbCARGO_ABONO
        '
        Me.cmbCARGO_ABONO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCARGO_ABONO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCARGO_ABONO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCARGO_ABONO.ForeColor = System.Drawing.Color.Navy
        Me.cmbCARGO_ABONO.FormattingEnabled = True
        Me.cmbCARGO_ABONO.Items.AddRange(New Object() {"Cargo", "Abono"})
        Me.cmbCARGO_ABONO.Location = New System.Drawing.Point(582, 47)
        Me.cmbCARGO_ABONO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCARGO_ABONO.Name = "cmbCARGO_ABONO"
        Me.cmbCARGO_ABONO.Size = New System.Drawing.Size(79, 24)
        Me.cmbCARGO_ABONO.TabIndex = 3
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuenta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCuenta.Location = New System.Drawing.Point(99, 20)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(14, 16)
        Me.lblCuenta.TabIndex = 95
        Me.lblCuenta.Text = "0"
        Me.lblCuenta.Visible = False
        '
        'btnGuardarLinea
        '
        Me.btnGuardarLinea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarLinea.Image = Global.ASTAS.My.Resources.Resources.filesave
        Me.btnGuardarLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarLinea.Location = New System.Drawing.Point(743, 43)
        Me.btnGuardarLinea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGuardarLinea.Name = "btnGuardarLinea"
        Me.btnGuardarLinea.Size = New System.Drawing.Size(24, 36)
        Me.btnGuardarLinea.TabIndex = 5
        Me.btnGuardarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardarLinea.UseVisualStyleBackColor = True
        '
        'btnBuscarCuenta
        '
        Me.btnBuscarCuenta.Image = Global.ASTAS.My.Resources.Resources.search
        Me.btnBuscarCuenta.Location = New System.Drawing.Point(102, 46)
        Me.btnBuscarCuenta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBuscarCuenta.Name = "btnBuscarCuenta"
        Me.btnBuscarCuenta.Size = New System.Drawing.Size(24, 33)
        Me.btnBuscarCuenta.TabIndex = 1
        Me.btnBuscarCuenta.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.lblCuenta)
        Me.GroupBox3.Controls.Add(Me.cmbCARGO_ABONO)
        Me.GroupBox3.Controls.Add(Me.btnGuardarLinea)
        Me.GroupBox3.Controls.Add(Me.txtMONTO)
        Me.GroupBox3.Controls.Add(Me.txtCONCEPTO_L)
        Me.GroupBox3.Controls.Add(Me.cmbCENTRO_COSTO)
        Me.GroupBox3.Controls.Add(Me.txtCUENTA_COMPLETA)
        Me.GroupBox3.Controls.Add(Me.btnBuscarCuenta)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 352)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(771, 89)
        Me.GroupBox3.TabIndex = 96
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalles"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvMovtos)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 441)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(771, 203)
        Me.GroupBox4.TabIndex = 97
        Me.GroupBox4.TabStop = False
        '
        'Cafeteria_Partidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(771, 644)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Cafeteria_Partidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria - Partida Contable"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvMovtos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbCafeteria As System.Windows.Forms.ComboBox
    Friend WithEvents lblCafeteria As System.Windows.Forms.Label
    Friend WithEvents cmbCajas As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents dgvMovtos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTransaccionAnula As System.Windows.Forms.Label
    Friend WithEvents lblAnulada As System.Windows.Forms.Label
    Friend WithEvents txtPARTIDA As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTRANSACCION As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dpFECHA_CONTABLE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCONCEPTO As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDOCUMENTO As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTIPO_DOCUMENTO As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTIPO_PARTIDA As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbLIBRO_CONTABLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents btnGuardarLinea As System.Windows.Forms.Button
    Friend WithEvents txtCONCEPTO_L As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCuenta As System.Windows.Forms.Button
    Friend WithEvents txtCUENTA_COMPLETA As System.Windows.Forms.TextBox
    Friend WithEvents cmbCENTRO_COSTO As System.Windows.Forms.ComboBox
    Friend WithEvents txtMONTO As System.Windows.Forms.TextBox
    Friend WithEvents cmbCARGO_ABONO As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCARGOS As System.Windows.Forms.TextBox
    Friend WithEvents txtDIFERENCIA As System.Windows.Forms.TextBox
    Friend WithEvents txtABONOS As System.Windows.Forms.TextBox
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dpFECHA_FACTURACION As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
End Class
