<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Cheques
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvOrdenesCompra = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpFechaProceso = New System.Windows.Forms.DateTimePicker
        Me.txtPartida = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCheque = New System.Windows.Forms.TextBox
        Me.chkNoNeg = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbRemesa = New System.Windows.Forms.RadioButton
        Me.rbCheque = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkTodas = New System.Windows.Forms.CheckBox
        Me.lblCUENTA_COMPLETA = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.lblLIBRO_CONTABLE = New System.Windows.Forms.Label
        Me.lblCUENTA = New System.Windows.Forms.Label
        Me.cmbBANCO = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.dpFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbCUENTA_BANCARIA = New System.Windows.Forms.ComboBox
        Me.cmbPROVEEDOR = New System.Windows.Forms.ComboBox
        Me.dgvCheques = New System.Windows.Forms.DataGridView
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.numcheque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.montochq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.noneg = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.montoletras = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnImpCheque = New System.Windows.Forms.Button
        CType(Me.dgvOrdenesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvOrdenesCompra
        '
        Me.dgvOrdenesCompra.AllowUserToAddRows = False
        Me.dgvOrdenesCompra.AllowUserToDeleteRows = False
        Me.dgvOrdenesCompra.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvOrdenesCompra.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOrdenesCompra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOrdenesCompra.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvOrdenesCompra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOrdenesCompra.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrdenesCompra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selec})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOrdenesCompra.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvOrdenesCompra.Location = New System.Drawing.Point(11, 139)
        Me.dgvOrdenesCompra.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvOrdenesCompra.Name = "dgvOrdenesCompra"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOrdenesCompra.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvOrdenesCompra.RowHeadersVisible = False
        Me.dgvOrdenesCompra.RowHeadersWidth = 30
        Me.dgvOrdenesCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrdenesCompra.Size = New System.Drawing.Size(950, 231)
        Me.dgvOrdenesCompra.TabIndex = 104
        '
        'selec
        '
        Me.selec.HeaderText = "*"
        Me.selec.Name = "selec"
        Me.selec.Width = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtpFechaProceso)
        Me.GroupBox1.Controls.Add(Me.txtPartida)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCheque)
        Me.GroupBox1.Controls.Add(Me.chkNoNeg)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkTodas)
        Me.GroupBox1.Controls.Add(Me.lblCUENTA_COMPLETA)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnProcesar)
        Me.GroupBox1.Controls.Add(Me.lblLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.lblCUENTA)
        Me.GroupBox1.Controls.Add(Me.cmbBANCO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.dpFechaHasta)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmbCUENTA_BANCARIA)
        Me.GroupBox1.Controls.Add(Me.cmbPROVEEDOR)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(11, 8)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(959, 122)
        Me.GroupBox1.TabIndex = 103
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(239, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 16)
        Me.Label6.TabIndex = 147
        Me.Label6.Text = "Fecha Proceso:"
        '
        'dtpFechaProceso
        '
        Me.dtpFechaProceso.CustomFormat = "dd-MM-yyyy"
        Me.dtpFechaProceso.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaProceso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaProceso.Location = New System.Drawing.Point(325, 41)
        Me.dtpFechaProceso.Name = "dtpFechaProceso"
        Me.dtpFechaProceso.Size = New System.Drawing.Size(83, 22)
        Me.dtpFechaProceso.TabIndex = 146
        '
        'txtPartida
        '
        Me.txtPartida.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartida.ForeColor = System.Drawing.Color.Navy
        Me.txtPartida.Location = New System.Drawing.Point(858, 66)
        Me.txtPartida.MaxLength = 9
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(93, 25)
        Me.txtPartida.TabIndex = 145
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(807, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 144
        Me.Label4.Text = "Partida #"
        '
        'txtCheque
        '
        Me.txtCheque.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheque.ForeColor = System.Drawing.Color.Navy
        Me.txtCheque.Location = New System.Drawing.Point(661, 95)
        Me.txtCheque.MaxLength = 9
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(123, 25)
        Me.txtCheque.TabIndex = 143
        '
        'chkNoNeg
        '
        Me.chkNoNeg.Checked = True
        Me.chkNoNeg.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoNeg.Location = New System.Drawing.Point(810, 97)
        Me.chkNoNeg.Name = "chkNoNeg"
        Me.chkNoNeg.Size = New System.Drawing.Size(104, 20)
        Me.chkNoNeg.TabIndex = 117
        Me.chkNoNeg.Text = "No Negociable"
        Me.chkNoNeg.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbRemesa)
        Me.GroupBox2.Controls.Add(Me.rbCheque)
        Me.GroupBox2.Location = New System.Drawing.Point(498, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(84, 79)
        Me.GroupBox2.TabIndex = 142
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pago con:"
        '
        'rbRemesa
        '
        Me.rbRemesa.AutoSize = True
        Me.rbRemesa.Checked = True
        Me.rbRemesa.Location = New System.Drawing.Point(9, 23)
        Me.rbRemesa.Name = "rbRemesa"
        Me.rbRemesa.Size = New System.Drawing.Size(67, 20)
        Me.rbRemesa.TabIndex = 140
        Me.rbRemesa.TabStop = True
        Me.rbRemesa.Text = "Remesa"
        Me.rbRemesa.UseVisualStyleBackColor = True
        '
        'rbCheque
        '
        Me.rbCheque.AutoSize = True
        Me.rbCheque.Location = New System.Drawing.Point(9, 48)
        Me.rbCheque.Name = "rbCheque"
        Me.rbCheque.Size = New System.Drawing.Size(67, 20)
        Me.rbCheque.TabIndex = 141
        Me.rbCheque.Text = "Cheque"
        Me.rbCheque.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(589, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 16)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Cheque No.:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(187, 23)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Valor a Procesar: $ 0.00"
        '
        'chkTodas
        '
        Me.chkTodas.AutoSize = True
        Me.chkTodas.Location = New System.Drawing.Point(289, 71)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(119, 20)
        Me.chkTodas.TabIndex = 105
        Me.chkTodas.Text = "Seleccionar Todo"
        Me.chkTodas.UseVisualStyleBackColor = True
        '
        'lblCUENTA_COMPLETA
        '
        Me.lblCUENTA_COMPLETA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCUENTA_COMPLETA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCUENTA_COMPLETA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblCUENTA_COMPLETA.ForeColor = System.Drawing.Color.Navy
        Me.lblCUENTA_COMPLETA.Location = New System.Drawing.Point(661, 68)
        Me.lblCUENTA_COMPLETA.Name = "lblCUENTA_COMPLETA"
        Me.lblCUENTA_COMPLETA.Size = New System.Drawing.Size(123, 22)
        Me.lblCUENTA_COMPLETA.TabIndex = 2
        Me.lblCUENTA_COMPLETA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(589, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "Cta.Contable :"
        '
        'btnProcesar
        '
        Me.btnProcesar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnProcesar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesar.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesar.Location = New System.Drawing.Point(414, 41)
        Me.btnProcesar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 41)
        Me.btnProcesar.TabIndex = 106
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'lblLIBRO_CONTABLE
        '
        Me.lblLIBRO_CONTABLE.AutoSize = True
        Me.lblLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLIBRO_CONTABLE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLIBRO_CONTABLE.Location = New System.Drawing.Point(233, 72)
        Me.lblLIBRO_CONTABLE.Name = "lblLIBRO_CONTABLE"
        Me.lblLIBRO_CONTABLE.Size = New System.Drawing.Size(14, 16)
        Me.lblLIBRO_CONTABLE.TabIndex = 114
        Me.lblLIBRO_CONTABLE.Text = "0"
        Me.lblLIBRO_CONTABLE.Visible = False
        '
        'lblCUENTA
        '
        Me.lblCUENTA.AutoSize = True
        Me.lblCUENTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCUENTA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCUENTA.Location = New System.Drawing.Point(254, 72)
        Me.lblCUENTA.Name = "lblCUENTA"
        Me.lblCUENTA.Size = New System.Drawing.Size(14, 16)
        Me.lblCUENTA.TabIndex = 113
        Me.lblCUENTA.Text = "0"
        Me.lblCUENTA.Visible = False
        '
        'cmbBANCO
        '
        Me.cmbBANCO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBANCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBANCO.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbBANCO.ForeColor = System.Drawing.Color.Navy
        Me.cmbBANCO.FormattingEnabled = True
        Me.cmbBANCO.Location = New System.Drawing.Point(661, 13)
        Me.cmbBANCO.Name = "cmbBANCO"
        Me.cmbBANCO.Size = New System.Drawing.Size(290, 24)
        Me.cmbBANCO.TabIndex = 108
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(10, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Fecha Quedan Hasta:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(589, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 16)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Cta.Banco :"
        '
        'dpFechaHasta
        '
        Me.dpFechaHasta.CustomFormat = "dd-MM-yyyy"
        Me.dpFechaHasta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaHasta.Location = New System.Drawing.Point(124, 41)
        Me.dpFechaHasta.Name = "dpFechaHasta"
        Me.dpFechaHasta.Size = New System.Drawing.Size(88, 22)
        Me.dpFechaHasta.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(10, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Proveedor :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(589, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 16)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "Banco :"
        '
        'cmbCUENTA_BANCARIA
        '
        Me.cmbCUENTA_BANCARIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCUENTA_BANCARIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCUENTA_BANCARIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbCUENTA_BANCARIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCUENTA_BANCARIA.FormattingEnabled = True
        Me.cmbCUENTA_BANCARIA.Location = New System.Drawing.Point(661, 40)
        Me.cmbCUENTA_BANCARIA.Name = "cmbCUENTA_BANCARIA"
        Me.cmbCUENTA_BANCARIA.Size = New System.Drawing.Size(290, 24)
        Me.cmbCUENTA_BANCARIA.TabIndex = 107
        '
        'cmbPROVEEDOR
        '
        Me.cmbPROVEEDOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbPROVEEDOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPROVEEDOR.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPROVEEDOR.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPROVEEDOR.ForeColor = System.Drawing.Color.Navy
        Me.cmbPROVEEDOR.FormattingEnabled = True
        Me.cmbPROVEEDOR.Location = New System.Drawing.Point(81, 13)
        Me.cmbPROVEEDOR.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbPROVEEDOR.Name = "cmbPROVEEDOR"
        Me.cmbPROVEEDOR.Size = New System.Drawing.Size(413, 24)
        Me.cmbPROVEEDOR.TabIndex = 1
        '
        'dgvCheques
        '
        Me.dgvCheques.AllowUserToAddRows = False
        Me.dgvCheques.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvCheques.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCheques.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvCheques.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCheques.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvCheques.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCheques.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.numcheque, Me.nombre, Me.montochq, Me.noneg, Me.montoletras, Me.fecha})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCheques.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvCheques.Location = New System.Drawing.Point(12, 392)
        Me.dgvCheques.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvCheques.Name = "dgvCheques"
        Me.dgvCheques.RowHeadersVisible = False
        Me.dgvCheques.Size = New System.Drawing.Size(427, 160)
        Me.dgvCheques.TabIndex = 114
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Visible = False
        Me.DataGridViewCheckBoxColumn1.Width = 30
        '
        'numcheque
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.numcheque.DefaultCellStyle = DataGridViewCellStyle7
        Me.numcheque.HeaderText = "Cheque No."
        Me.numcheque.Name = "numcheque"
        Me.numcheque.ReadOnly = True
        Me.numcheque.Width = 50
        '
        'nombre
        '
        Me.nombre.HeaderText = "A Nombre de"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.nombre.Width = 180
        '
        'montochq
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.montochq.DefaultCellStyle = DataGridViewCellStyle8
        Me.montochq.HeaderText = "Monto"
        Me.montochq.Name = "montochq"
        Me.montochq.ReadOnly = True
        Me.montochq.Width = 70
        '
        'noneg
        '
        Me.noneg.HeaderText = "No Neg"
        Me.noneg.Name = "noneg"
        Me.noneg.Width = 40
        '
        'montoletras
        '
        Me.montoletras.HeaderText = "Monto Letras"
        Me.montoletras.Name = "montoletras"
        Me.montoletras.ReadOnly = True
        Me.montoletras.Visible = False
        Me.montoletras.Width = 110
        '
        'fecha
        '
        DataGridViewCellStyle9.Format = "d"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.fecha.DefaultCellStyle = DataGridViewCellStyle9
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Width = 70
        '
        'btnImpCheque
        '
        Me.btnImpCheque.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImpCheque.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImpCheque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImpCheque.Location = New System.Drawing.Point(445, 441)
        Me.btnImpCheque.Name = "btnImpCheque"
        Me.btnImpCheque.Size = New System.Drawing.Size(76, 75)
        Me.btnImpCheque.TabIndex = 115
        Me.btnImpCheque.Text = "Imprimir Cheques"
        Me.btnImpCheque.UseVisualStyleBackColor = True
        '
        'Contabilidad_Cheques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 570)
        Me.Controls.Add(Me.btnImpCheque)
        Me.Controls.Add(Me.dgvCheques)
        Me.Controls.Add(Me.dgvOrdenesCompra)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Cheques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas por Pagar - Pagos a Proveedores"
        CType(Me.dgvOrdenesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvOrdenesCompra As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbPROVEEDOR As System.Windows.Forms.ComboBox
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbCheque As System.Windows.Forms.RadioButton
    Friend WithEvents rbRemesa As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCUENTA_COMPLETA As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLIBRO_CONTABLE As System.Windows.Forms.Label
    Friend WithEvents lblCUENTA As System.Windows.Forms.Label
    Friend WithEvents cmbBANCO As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbCUENTA_BANCARIA As System.Windows.Forms.ComboBox
    Friend WithEvents chkNoNeg As System.Windows.Forms.CheckBox
    Friend WithEvents txtCheque As System.Windows.Forms.TextBox
    Friend WithEvents dgvCheques As System.Windows.Forms.DataGridView
    Friend WithEvents btnImpCheque As System.Windows.Forms.Button
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents numcheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents montochq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents noneg As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents montoletras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
