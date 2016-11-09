<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Facturacion_Bodegas_Devoluciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Facturacion_Bodegas_Devoluciones))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.dgvCuentasEquivalentes = New System.Windows.Forms.DataGridView
        Me.Seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.codProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.A_DEVOLVER = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrecProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbCONDICION_PAGO = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtDescBONI = New System.Windows.Forms.TextBox
        Me.txtDescAGUI = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtNoRemesa = New System.Windows.Forms.TextBox
        Me.dpFechaDesc = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.TextBox30 = New System.Windows.Forms.TextBox
        Me.txtNumCuotas = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkImpConcepto = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtNomFact = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtNITCliente = New System.Windows.Forms.TextBox
        Me.txtTelCliente = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDUICliente = New System.Windows.Forms.TextBox
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox
        Me.cmbTipDoc = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbPeriodoPago = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.dpFECHA_CONTABLE = New System.Windows.Forms.DateTimePicker
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.txtNombreCliente = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.bntNuevaFact = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkCliExt = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtNoFact = New System.Windows.Forms.TextBox
        Me.lblCodBuxis = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtSUBTOTAL = New System.Windows.Forms.TextBox
        Me.txtIVA = New System.Windows.Forms.TextBox
        Me.txtTotFact = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtCESC = New System.Windows.Forms.TextBox
        CType(Me.dgvCuentasEquivalentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(18, 252)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(80, 24)
        Me.btnImprimir.TabIndex = 91
        Me.btnImprimir.Text = "Procesar"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'dgvCuentasEquivalentes
        '
        Me.dgvCuentasEquivalentes.AllowUserToAddRows = False
        Me.dgvCuentasEquivalentes.AllowUserToDeleteRows = False
        Me.dgvCuentasEquivalentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuentasEquivalentes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccion, Me.codProd, Me.descProd, Me.desc, Me.Cant, Me.A_DEVOLVER, Me.PrecProd, Me.Total})
        Me.dgvCuentasEquivalentes.Location = New System.Drawing.Point(5, 282)
        Me.dgvCuentasEquivalentes.Name = "dgvCuentasEquivalentes"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCuentasEquivalentes.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvCuentasEquivalentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCuentasEquivalentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCuentasEquivalentes.Size = New System.Drawing.Size(730, 295)
        Me.dgvCuentasEquivalentes.TabIndex = 61
        '
        'Seleccion
        '
        Me.Seleccion.HeaderText = ""
        Me.Seleccion.Name = "Seleccion"
        Me.Seleccion.Width = 30
        '
        'codProd
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codProd.DefaultCellStyle = DataGridViewCellStyle1
        Me.codProd.HeaderText = "Producto"
        Me.codProd.Name = "codProd"
        Me.codProd.Width = 70
        '
        'descProd
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.descProd.DefaultCellStyle = DataGridViewCellStyle2
        Me.descProd.HeaderText = "Descripción Producto"
        Me.descProd.Name = "descProd"
        Me.descProd.Width = 240
        '
        'desc
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.desc.DefaultCellStyle = DataGridViewCellStyle3
        Me.desc.HeaderText = "Unidad Medida"
        Me.desc.Name = "desc"
        Me.desc.Width = 70
        '
        'Cant
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cant.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cant.HeaderText = "Cantidad"
        Me.Cant.Name = "Cant"
        Me.Cant.Width = 65
        '
        'A_DEVOLVER
        '
        Me.A_DEVOLVER.HeaderText = "A Devolver"
        Me.A_DEVOLVER.Name = "A_DEVOLVER"
        Me.A_DEVOLVER.Width = 65
        '
        'PrecProd
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PrecProd.DefaultCellStyle = DataGridViewCellStyle5
        Me.PrecProd.HeaderText = "Precio Unit."
        Me.PrecProd.Name = "PrecProd"
        Me.PrecProd.Width = 70
        '
        'Total
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Total.DefaultCellStyle = DataGridViewCellStyle6
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.Width = 80
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbCONDICION_PAGO)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.txtDescBONI)
        Me.GroupBox2.Controls.Add(Me.txtDescAGUI)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtNoRemesa)
        Me.GroupBox2.Controls.Add(Me.dpFechaDesc)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.TextBox30)
        Me.GroupBox2.Controls.Add(Me.txtNumCuotas)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.chkImpConcepto)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtNomFact)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtNITCliente)
        Me.GroupBox2.Controls.Add(Me.txtTelCliente)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtDUICliente)
        Me.GroupBox2.Controls.Add(Me.cmbFormaPago)
        Me.GroupBox2.Controls.Add(Me.cmbTipDoc)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cmbPeriodoPago)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(18, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(704, 138)
        Me.GroupBox2.TabIndex = 60
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Cliente / Socio"
        '
        'cmbCONDICION_PAGO
        '
        Me.cmbCONDICION_PAGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCONDICION_PAGO.Enabled = False
        Me.cmbCONDICION_PAGO.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmbCONDICION_PAGO.ForeColor = System.Drawing.Color.Navy
        Me.cmbCONDICION_PAGO.FormattingEnabled = True
        Me.cmbCONDICION_PAGO.Location = New System.Drawing.Point(534, 67)
        Me.cmbCONDICION_PAGO.Name = "cmbCONDICION_PAGO"
        Me.cmbCONDICION_PAGO.Size = New System.Drawing.Size(164, 22)
        Me.cmbCONDICION_PAGO.TabIndex = 94
        Me.cmbCONDICION_PAGO.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(448, 68)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 14)
        Me.Label22.TabIndex = 93
        Me.Label22.Text = "Condicion Pago :"
        Me.Label22.Visible = False
        '
        'txtDescBONI
        '
        Me.txtDescBONI.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescBONI.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescBONI.Location = New System.Drawing.Point(302, 112)
        Me.txtDescBONI.Name = "txtDescBONI"
        Me.txtDescBONI.ReadOnly = True
        Me.txtDescBONI.Size = New System.Drawing.Size(124, 22)
        Me.txtDescBONI.TabIndex = 92
        Me.txtDescBONI.Text = "0.00"
        Me.txtDescBONI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescAGUI
        '
        Me.txtDescAGUI.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescAGUI.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescAGUI.Location = New System.Drawing.Point(303, 89)
        Me.txtDescAGUI.Name = "txtDescAGUI"
        Me.txtDescAGUI.ReadOnly = True
        Me.txtDescAGUI.Size = New System.Drawing.Size(123, 22)
        Me.txtDescAGUI.TabIndex = 91
        Me.txtDescAGUI.Text = "0.00"
        Me.txtDescAGUI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(180, 114)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(127, 14)
        Me.Label20.TabIndex = 90
        Me.Label20.Text = "Descuento Bonificacion :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(188, 91)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(115, 14)
        Me.Label19.TabIndex = 89
        Me.Label19.Text = "Descuento Aguinaldo :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(233, 68)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 14)
        Me.Label17.TabIndex = 88
        Me.Label17.Text = "Remesa No.:"
        '
        'txtNoRemesa
        '
        Me.txtNoRemesa.BackColor = System.Drawing.SystemColors.Window
        Me.txtNoRemesa.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoRemesa.Location = New System.Drawing.Point(303, 65)
        Me.txtNoRemesa.Name = "txtNoRemesa"
        Me.txtNoRemesa.ReadOnly = True
        Me.txtNoRemesa.Size = New System.Drawing.Size(122, 22)
        Me.txtNoRemesa.TabIndex = 87
        '
        'dpFechaDesc
        '
        Me.dpFechaDesc.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFechaDesc.CustomFormat = "dd-MMM-yyyy"
        Me.dpFechaDesc.Enabled = False
        Me.dpFechaDesc.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.dpFechaDesc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaDesc.Location = New System.Drawing.Point(608, 91)
        Me.dpFechaDesc.Name = "dpFechaDesc"
        Me.dpFechaDesc.Size = New System.Drawing.Size(90, 20)
        Me.dpFechaDesc.TabIndex = 63
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(568, 94)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 14)
        Me.Label16.TabIndex = 86
        Me.Label16.Text = "Desde:"
        '
        'TextBox30
        '
        Me.TextBox30.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox30.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox30.ForeColor = System.Drawing.Color.Navy
        Me.TextBox30.Location = New System.Drawing.Point(104, 89)
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New System.Drawing.Size(104, 22)
        Me.TextBox30.TabIndex = 85
        Me.TextBox30.Visible = False
        '
        'txtNumCuotas
        '
        Me.txtNumCuotas.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumCuotas.Enabled = False
        Me.txtNumCuotas.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtNumCuotas.ForeColor = System.Drawing.Color.Navy
        Me.txtNumCuotas.Location = New System.Drawing.Point(534, 91)
        Me.txtNumCuotas.Name = "txtNumCuotas"
        Me.txtNumCuotas.ReadOnly = True
        Me.txtNumCuotas.Size = New System.Drawing.Size(34, 20)
        Me.txtNumCuotas.TabIndex = 69
        Me.txtNumCuotas.Text = "0"
        Me.txtNumCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(449, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "# Cuotas :"
        '
        'chkImpConcepto
        '
        Me.chkImpConcepto.AutoSize = True
        Me.chkImpConcepto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImpConcepto.ForeColor = System.Drawing.Color.Red
        Me.chkImpConcepto.Location = New System.Drawing.Point(214, 94)
        Me.chkImpConcepto.Name = "chkImpConcepto"
        Me.chkImpConcepto.Size = New System.Drawing.Size(112, 20)
        Me.chkImpConcepto.TabIndex = 62
        Me.chkImpConcepto.Text = "Imprimir Concepto"
        Me.chkImpConcepto.UseVisualStyleBackColor = True
        Me.chkImpConcepto.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(16, 89)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 14)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "Concepto :"
        Me.Label12.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(16, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 14)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "Teléfono :"
        '
        'txtNomFact
        '
        Me.txtNomFact.BackColor = System.Drawing.SystemColors.Window
        Me.txtNomFact.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomFact.ForeColor = System.Drawing.Color.Navy
        Me.txtNomFact.Location = New System.Drawing.Point(104, 17)
        Me.txtNomFact.Name = "txtNomFact"
        Me.txtNomFact.ReadOnly = True
        Me.txtNomFact.Size = New System.Drawing.Size(322, 22)
        Me.txtNomFact.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(16, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 14)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "Nombre Factura :"
        '
        'txtNITCliente
        '
        Me.txtNITCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtNITCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNITCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtNITCliente.Location = New System.Drawing.Point(303, 41)
        Me.txtNITCliente.Name = "txtNITCliente"
        Me.txtNITCliente.ReadOnly = True
        Me.txtNITCliente.Size = New System.Drawing.Size(122, 22)
        Me.txtNITCliente.TabIndex = 55
        '
        'txtTelCliente
        '
        Me.txtTelCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtTelCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtTelCliente.Location = New System.Drawing.Point(104, 65)
        Me.txtTelCliente.Name = "txtTelCliente"
        Me.txtTelCliente.ReadOnly = True
        Me.txtTelCliente.Size = New System.Drawing.Size(104, 22)
        Me.txtTelCliente.TabIndex = 53
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 14)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "DUI :"
        '
        'txtDUICliente
        '
        Me.txtDUICliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtDUICliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDUICliente.ForeColor = System.Drawing.Color.Navy
        Me.txtDUICliente.Location = New System.Drawing.Point(104, 41)
        Me.txtDUICliente.Name = "txtDUICliente"
        Me.txtDUICliente.ReadOnly = True
        Me.txtDUICliente.Size = New System.Drawing.Size(104, 22)
        Me.txtDUICliente.TabIndex = 51
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Enabled = False
        Me.cmbFormaPago.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmbFormaPago.ForeColor = System.Drawing.Color.Navy
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.Items.AddRange(New Object() {"Contado", "Crédito", "Cheque", "Tarjeta de Crédito"})
        Me.cmbFormaPago.Location = New System.Drawing.Point(534, 43)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(164, 22)
        Me.cmbFormaPago.TabIndex = 50
        '
        'cmbTipDoc
        '
        Me.cmbTipDoc.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipDoc.Enabled = False
        Me.cmbTipDoc.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmbTipDoc.ForeColor = System.Drawing.Color.Navy
        Me.cmbTipDoc.FormattingEnabled = True
        Me.cmbTipDoc.Items.AddRange(New Object() {"Consumidor Final", "Crédito Fiscal"})
        Me.cmbTipDoc.Location = New System.Drawing.Point(534, 19)
        Me.cmbTipDoc.Name = "cmbTipDoc"
        Me.cmbTipDoc.Size = New System.Drawing.Size(164, 22)
        Me.cmbTipDoc.TabIndex = 49
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(446, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 14)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Tipo Documento :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(446, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Forma Pago :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(256, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 14)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "NIT :"
        '
        'cmbPeriodoPago
        '
        Me.cmbPeriodoPago.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPeriodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoPago.Enabled = False
        Me.cmbPeriodoPago.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodoPago.ForeColor = System.Drawing.Color.Navy
        Me.cmbPeriodoPago.FormattingEnabled = True
        Me.cmbPeriodoPago.Items.AddRange(New Object() {"QQ - Quincenal", "MM - Mensual", "BO - Bonificación", "AG - Aguinaldo"})
        Me.cmbPeriodoPago.Location = New System.Drawing.Point(534, 67)
        Me.cmbPeriodoPago.Name = "cmbPeriodoPago"
        Me.cmbPeriodoPago.Size = New System.Drawing.Size(164, 24)
        Me.cmbPeriodoPago.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(446, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Periodo Pago :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(473, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 14)
        Me.Label15.TabIndex = 64
        Me.Label15.Text = "Fecha Factura :"
        '
        'dpFECHA_CONTABLE
        '
        Me.dpFECHA_CONTABLE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CONTABLE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CONTABLE.Location = New System.Drawing.Point(560, 48)
        Me.dpFECHA_CONTABLE.Name = "dpFECHA_CONTABLE"
        Me.dpFECHA_CONTABLE.Size = New System.Drawing.Size(108, 22)
        Me.dpFECHA_CONTABLE.TabIndex = 40
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtCliente.Location = New System.Drawing.Point(104, 45)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(81, 22)
        Me.txtCliente.TabIndex = 3
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtNombreCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtNombreCliente.Location = New System.Drawing.Point(104, 68)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombreCliente.Size = New System.Drawing.Size(344, 22)
        Me.txtNombreCliente.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 14)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Codigo Buxis :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.bntNuevaFact)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.chkCliExt)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.txtNoFact)
        Me.GroupBox4.Controls.Add(Me.lblCodBuxis)
        Me.GroupBox4.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label58)
        Me.GroupBox4.Controls.Add(Me.dpFECHA_CONTABLE)
        Me.GroupBox4.Controls.Add(Me.txtNombreCliente)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtCliente)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox4.Location = New System.Drawing.Point(17, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(705, 97)
        Me.GroupBox4.TabIndex = 62
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Generales"
        '
        'bntNuevaFact
        '
        Me.bntNuevaFact.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.bntNuevaFact.Location = New System.Drawing.Point(668, 20)
        Me.bntNuevaFact.Name = "bntNuevaFact"
        Me.bntNuevaFact.Size = New System.Drawing.Size(25, 25)
        Me.bntNuevaFact.TabIndex = 75
        Me.ToolTip1.SetToolTip(Me.bntNuevaFact, "Nueva Factura")
        Me.bntNuevaFact.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(298, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 14)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "Codigo BUXIS :"
        '
        'chkCliExt
        '
        Me.chkCliExt.AutoSize = True
        Me.chkCliExt.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.chkCliExt.ForeColor = System.Drawing.Color.Red
        Me.chkCliExt.Location = New System.Drawing.Point(195, 47)
        Me.chkCliExt.Name = "chkCliExt"
        Me.chkCliExt.Size = New System.Drawing.Size(98, 18)
        Me.chkCliExt.TabIndex = 74
        Me.chkCliExt.Text = "Cliente Externo"
        Me.chkCliExt.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(16, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 14)
        Me.Label13.TabIndex = 70
        Me.Label13.Text = "Nombre AS :"
        '
        'txtNoFact
        '
        Me.txtNoFact.BackColor = System.Drawing.Color.Yellow
        Me.txtNoFact.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoFact.ForeColor = System.Drawing.Color.Red
        Me.txtNoFact.Location = New System.Drawing.Point(561, 20)
        Me.txtNoFact.Name = "txtNoFact"
        Me.txtNoFact.Size = New System.Drawing.Size(107, 26)
        Me.txtNoFact.TabIndex = 68
        Me.txtNoFact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodBuxis
        '
        Me.lblCodBuxis.BackColor = System.Drawing.Color.Blue
        Me.lblCodBuxis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCodBuxis.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCodBuxis.ForeColor = System.Drawing.Color.Yellow
        Me.lblCodBuxis.Location = New System.Drawing.Point(383, 45)
        Me.lblCodBuxis.Name = "lblCodBuxis"
        Me.lblCodBuxis.Size = New System.Drawing.Size(65, 24)
        Me.lblCodBuxis.TabIndex = 67
        Me.lblCodBuxis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Items.AddRange(New Object() {"01 - Despensa Planta 01", "02 - Despensa Zapotitán"})
        Me.cmbBODEGA.Location = New System.Drawing.Point(104, 20)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(344, 22)
        Me.cmbBODEGA.TabIndex = 2
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(472, 24)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(89, 16)
        Me.Label52.TabIndex = 48
        Me.Label52.Text = "N° Factura :"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label58.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label58.Location = New System.Drawing.Point(16, 21)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(50, 14)
        Me.Label58.TabIndex = 0
        Me.Label58.Text = "Bodega :"
        '
        'txtSUBTOTAL
        '
        Me.txtSUBTOTAL.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtSUBTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSUBTOTAL.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUBTOTAL.ForeColor = System.Drawing.Color.Navy
        Me.txtSUBTOTAL.Location = New System.Drawing.Point(344, 601)
        Me.txtSUBTOTAL.Name = "txtSUBTOTAL"
        Me.txtSUBTOTAL.ReadOnly = True
        Me.txtSUBTOTAL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSUBTOTAL.Size = New System.Drawing.Size(96, 26)
        Me.txtSUBTOTAL.TabIndex = 72
        Me.txtSUBTOTAL.Text = "0.00"
        '
        'txtIVA
        '
        Me.txtIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIVA.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA.ForeColor = System.Drawing.Color.Navy
        Me.txtIVA.Location = New System.Drawing.Point(442, 601)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtIVA.Size = New System.Drawing.Size(96, 26)
        Me.txtIVA.TabIndex = 73
        Me.txtIVA.Text = "0.00"
        '
        'txtTotFact
        '
        Me.txtTotFact.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTotFact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotFact.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotFact.ForeColor = System.Drawing.Color.Red
        Me.txtTotFact.Location = New System.Drawing.Point(638, 601)
        Me.txtTotFact.Name = "txtTotFact"
        Me.txtTotFact.ReadOnly = True
        Me.txtTotFact.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotFact.Size = New System.Drawing.Size(96, 26)
        Me.txtTotFact.TabIndex = 78
        Me.txtTotFact.Text = "0.00"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Teal
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(344, 578)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(390, 20)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "              Subtotal                      IVA                  C.E.S.C.        " & _
            "    Total Factura"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(104, 255)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(0, 20)
        Me.Label14.TabIndex = 92
        '
        'txtCESC
        '
        Me.txtCESC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCESC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCESC.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCESC.ForeColor = System.Drawing.Color.Navy
        Me.txtCESC.Location = New System.Drawing.Point(540, 601)
        Me.txtCESC.Name = "txtCESC"
        Me.txtCESC.ReadOnly = True
        Me.txtCESC.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCESC.Size = New System.Drawing.Size(96, 26)
        Me.txtCESC.TabIndex = 93
        Me.txtCESC.Text = "0.00"
        '
        'Facturacion_Bodegas_Devoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(738, 633)
        Me.Controls.Add(Me.txtCESC)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotFact)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.txtIVA)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.txtSUBTOTAL)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvCuentasEquivalentes)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Facturacion_Bodegas_Devoluciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturación Devoluciones"
        CType(Me.dgvCuentasEquivalentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCuentasEquivalentes As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkImpConcepto As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNomFact As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNITCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtTelCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDUICliente As System.Windows.Forms.TextBox
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents dpFECHA_CONTABLE As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbTipDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents cmbPeriodoPago As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents txtNumCuotas As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox30 As System.Windows.Forms.TextBox
    Friend WithEvents lblCodBuxis As System.Windows.Forms.Label
    Friend WithEvents txtNoFact As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dpFechaDesc As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNoRemesa As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtDescBONI As System.Windows.Forms.TextBox
    Friend WithEvents txtDescAGUI As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents chkCliExt As System.Windows.Forms.CheckBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbCONDICION_PAGO As System.Windows.Forms.ComboBox
    Friend WithEvents txtSUBTOTAL As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents txtTotFact As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bntNuevaFact As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Seleccion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents codProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents A_DEVOLVER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCESC As System.Windows.Forms.TextBox
End Class
