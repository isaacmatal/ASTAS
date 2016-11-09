<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCooperativaGenerarCheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCooperativaGenerarCheque))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Lbl_Correlativo = New System.Windows.Forms.Label
        Me.BtnBuscarProv = New System.Windows.Forms.Button
        Me.lblNOMBRE_PROVEEDOR = New System.Windows.Forms.TextBox
        Me.BtnProveedor = New System.Windows.Forms.Button
        Me.TxtCreditoFiscal = New System.Windows.Forms.TextBox
        Me.lblTotalCheque = New System.Windows.Forms.Label
        Me.btnEditarConcepto = New System.Windows.Forms.Button
        Me.lblRetencion = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.lblIVA = New System.Windows.Forms.Label
        Me.lblSubTotal = New System.Windows.Forms.Label
        Me.dpFECHA_OC = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtCONCEPTO = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblOC = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbCENTRO_COSTO = New System.Windows.Forms.ComboBox
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCUENTA = New System.Windows.Forms.Label
        Me.lblLIBRO_CONTABLE = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkNoNeg = New System.Windows.Forms.CheckBox
        Me.lblCUENTA_COMPLETA = New System.Windows.Forms.Label
        Me.cmbBANCO = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbCHEQUERA = New System.Windows.Forms.ComboBox
        Me.cmbCUENTA_BANCARIA = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnAnular = New System.Windows.Forms.Button
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lbl_Correlativo)
        Me.GroupBox1.Controls.Add(Me.BtnBuscarProv)
        Me.GroupBox1.Controls.Add(Me.lblNOMBRE_PROVEEDOR)
        Me.GroupBox1.Controls.Add(Me.BtnProveedor)
        Me.GroupBox1.Controls.Add(Me.TxtCreditoFiscal)
        Me.GroupBox1.Controls.Add(Me.lblTotalCheque)
        Me.GroupBox1.Controls.Add(Me.btnEditarConcepto)
        Me.GroupBox1.Controls.Add(Me.lblRetencion)
        Me.GroupBox1.Controls.Add(Me.lblTotal)
        Me.GroupBox1.Controls.Add(Me.lblIVA)
        Me.GroupBox1.Controls.Add(Me.lblSubTotal)
        Me.GroupBox1.Controls.Add(Me.dpFECHA_OC)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtCONCEPTO)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblOC)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCENTRO_COSTO)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(496, 232)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cheque "
        '
        'Lbl_Correlativo
        '
        Me.Lbl_Correlativo.AutoSize = True
        Me.Lbl_Correlativo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Correlativo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_Correlativo.Location = New System.Drawing.Point(158, 126)
        Me.Lbl_Correlativo.Name = "Lbl_Correlativo"
        Me.Lbl_Correlativo.Size = New System.Drawing.Size(14, 16)
        Me.Lbl_Correlativo.TabIndex = 117
        Me.Lbl_Correlativo.Text = "0"
        Me.Lbl_Correlativo.Visible = False
        '
        'BtnBuscarProv
        '
        Me.BtnBuscarProv.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarProv.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarProv.Image = CType(resources.GetObject("BtnBuscarProv.Image"), System.Drawing.Image)
        Me.BtnBuscarProv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarProv.Location = New System.Drawing.Point(433, 95)
        Me.BtnBuscarProv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscarProv.Name = "BtnBuscarProv"
        Me.BtnBuscarProv.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarProv.TabIndex = 121
        Me.BtnBuscarProv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarProv.UseVisualStyleBackColor = True
        '
        'lblNOMBRE_PROVEEDOR
        '
        Me.lblNOMBRE_PROVEEDOR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblNOMBRE_PROVEEDOR.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNOMBRE_PROVEEDOR.ForeColor = System.Drawing.Color.Navy
        Me.lblNOMBRE_PROVEEDOR.Location = New System.Drawing.Point(80, 96)
        Me.lblNOMBRE_PROVEEDOR.MaxLength = 75
        Me.lblNOMBRE_PROVEEDOR.Name = "lblNOMBRE_PROVEEDOR"
        Me.lblNOMBRE_PROVEEDOR.ReadOnly = True
        Me.lblNOMBRE_PROVEEDOR.Size = New System.Drawing.Size(354, 22)
        Me.lblNOMBRE_PROVEEDOR.TabIndex = 120
        '
        'BtnProveedor
        '
        Me.BtnProveedor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnProveedor.Image = CType(resources.GetObject("BtnProveedor.Image"), System.Drawing.Image)
        Me.BtnProveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnProveedor.Location = New System.Drawing.Point(456, 96)
        Me.BtnProveedor.Name = "BtnProveedor"
        Me.BtnProveedor.Size = New System.Drawing.Size(24, 24)
        Me.BtnProveedor.TabIndex = 119
        Me.BtnProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnProveedor.UseVisualStyleBackColor = True
        '
        'TxtCreditoFiscal
        '
        Me.TxtCreditoFiscal.Location = New System.Drawing.Point(80, 120)
        Me.TxtCreditoFiscal.Name = "TxtCreditoFiscal"
        Me.TxtCreditoFiscal.Size = New System.Drawing.Size(72, 22)
        Me.TxtCreditoFiscal.TabIndex = 118
        '
        'lblTotalCheque
        '
        Me.lblTotalCheque.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTotalCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCheque.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCheque.ForeColor = System.Drawing.Color.Navy
        Me.lblTotalCheque.Location = New System.Drawing.Point(392, 200)
        Me.lblTotalCheque.Name = "lblTotalCheque"
        Me.lblTotalCheque.Size = New System.Drawing.Size(88, 22)
        Me.lblTotalCheque.TabIndex = 117
        Me.lblTotalCheque.Text = "0.00"
        Me.lblTotalCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnEditarConcepto
        '
        Me.btnEditarConcepto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEditarConcepto.Image = CType(resources.GetObject("btnEditarConcepto.Image"), System.Drawing.Image)
        Me.btnEditarConcepto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditarConcepto.Location = New System.Drawing.Point(456, 144)
        Me.btnEditarConcepto.Name = "btnEditarConcepto"
        Me.btnEditarConcepto.Size = New System.Drawing.Size(24, 24)
        Me.btnEditarConcepto.TabIndex = 105
        Me.btnEditarConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditarConcepto.UseVisualStyleBackColor = True
        '
        'lblRetencion
        '
        Me.lblRetencion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRetencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRetencion.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblRetencion.ForeColor = System.Drawing.Color.Red
        Me.lblRetencion.Location = New System.Drawing.Point(296, 200)
        Me.lblRetencion.Name = "lblRetencion"
        Me.lblRetencion.Size = New System.Drawing.Size(88, 22)
        Me.lblRetencion.TabIndex = 117
        Me.lblRetencion.Text = "0.00"
        Me.lblRetencion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotal.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblTotal.Location = New System.Drawing.Point(200, 200)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(88, 22)
        Me.lblTotal.TabIndex = 117
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIVA
        '
        Me.lblIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIVA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblIVA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblIVA.Location = New System.Drawing.Point(104, 200)
        Me.lblIVA.Name = "lblIVA"
        Me.lblIVA.Size = New System.Drawing.Size(88, 22)
        Me.lblIVA.TabIndex = 117
        Me.lblIVA.Text = "0.00"
        Me.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSubTotal
        '
        Me.lblSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSubTotal.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblSubTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSubTotal.Location = New System.Drawing.Point(8, 200)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(88, 22)
        Me.lblSubTotal.TabIndex = 116
        Me.lblSubTotal.Text = "0.00"
        Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dpFECHA_OC
        '
        Me.dpFECHA_OC.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_OC.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_OC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_OC.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_OC.Location = New System.Drawing.Point(368, 120)
        Me.dpFECHA_OC.Name = "dpFECHA_OC"
        Me.dpFECHA_OC.Size = New System.Drawing.Size(112, 22)
        Me.dpFECHA_OC.TabIndex = 44
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(280, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 16)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Fecha Cheque :"
        '
        'txtCONCEPTO
        '
        Me.txtCONCEPTO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCONCEPTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONCEPTO.ForeColor = System.Drawing.Color.Navy
        Me.txtCONCEPTO.Location = New System.Drawing.Point(80, 144)
        Me.txtCONCEPTO.MaxLength = 75
        Me.txtCONCEPTO.Name = "txtCONCEPTO"
        Me.txtCONCEPTO.ReadOnly = True
        Me.txtCONCEPTO.Size = New System.Drawing.Size(376, 22)
        Me.txtCONCEPTO.TabIndex = 43
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Teal
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(8, 176)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(472, 20)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "      Subtotal                  (+) IVA                      Total               " & _
            "  (-) % Retenc.        Total Cheque"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Concepto"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(8, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 16)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Proveedor"
        '
        'lblOC
        '
        Me.lblOC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOC.ForeColor = System.Drawing.Color.Red
        Me.lblOC.Location = New System.Drawing.Point(80, 72)
        Me.lblOC.Name = "lblOC"
        Me.lblOC.Size = New System.Drawing.Size(72, 22)
        Me.lblOC.TabIndex = 2
        Me.lblOC.Text = "999"
        Me.lblOC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Factura No.:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "N° OC :"
        '
        'cmbCENTRO_COSTO
        '
        Me.cmbCENTRO_COSTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCENTRO_COSTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCENTRO_COSTO.Enabled = False
        Me.cmbCENTRO_COSTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCENTRO_COSTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbCENTRO_COSTO.FormattingEnabled = True
        Me.cmbCENTRO_COSTO.Location = New System.Drawing.Point(80, 48)
        Me.cmbCENTRO_COSTO.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbCENTRO_COSTO.Name = "cmbCENTRO_COSTO"
        Me.cmbCENTRO_COSTO.Size = New System.Drawing.Size(288, 24)
        Me.cmbCENTRO_COSTO.TabIndex = 0
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Enabled = False
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(80, 24)
        Me.cmbCOMPAÑIA.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(400, 24)
        Me.cmbCOMPAÑIA.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Centro Costo"
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
        'lblCUENTA
        '
        Me.lblCUENTA.AutoSize = True
        Me.lblCUENTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCUENTA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCUENTA.Location = New System.Drawing.Point(288, 56)
        Me.lblCUENTA.Name = "lblCUENTA"
        Me.lblCUENTA.Size = New System.Drawing.Size(14, 16)
        Me.lblCUENTA.TabIndex = 113
        Me.lblCUENTA.Text = "0"
        Me.lblCUENTA.Visible = False
        '
        'lblLIBRO_CONTABLE
        '
        Me.lblLIBRO_CONTABLE.AutoSize = True
        Me.lblLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLIBRO_CONTABLE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLIBRO_CONTABLE.Location = New System.Drawing.Point(304, 56)
        Me.lblLIBRO_CONTABLE.Name = "lblLIBRO_CONTABLE"
        Me.lblLIBRO_CONTABLE.Size = New System.Drawing.Size(14, 16)
        Me.lblLIBRO_CONTABLE.TabIndex = 114
        Me.lblLIBRO_CONTABLE.Text = "0"
        Me.lblLIBRO_CONTABLE.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkNoNeg)
        Me.GroupBox2.Controls.Add(Me.lblCUENTA_COMPLETA)
        Me.GroupBox2.Controls.Add(Me.cmbBANCO)
        Me.GroupBox2.Controls.Add(Me.lblLIBRO_CONTABLE)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblCUENTA)
        Me.GroupBox2.Controls.Add(Me.cmbCHEQUERA)
        Me.GroupBox2.Controls.Add(Me.cmbCUENTA_BANCARIA)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(7, 243)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(496, 116)
        Me.GroupBox2.TabIndex = 107
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Selección del Banco"
        '
        'chkNoNeg
        '
        Me.chkNoNeg.AutoSize = True
        Me.chkNoNeg.Checked = True
        Me.chkNoNeg.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoNeg.Location = New System.Drawing.Point(11, 96)
        Me.chkNoNeg.Name = "chkNoNeg"
        Me.chkNoNeg.Size = New System.Drawing.Size(104, 20)
        Me.chkNoNeg.TabIndex = 116
        Me.chkNoNeg.Text = "No Negociable"
        Me.chkNoNeg.UseVisualStyleBackColor = True
        '
        'lblCUENTA_COMPLETA
        '
        Me.lblCUENTA_COMPLETA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCUENTA_COMPLETA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCUENTA_COMPLETA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblCUENTA_COMPLETA.ForeColor = System.Drawing.Color.Navy
        Me.lblCUENTA_COMPLETA.Location = New System.Drawing.Point(360, 48)
        Me.lblCUENTA_COMPLETA.Name = "lblCUENTA_COMPLETA"
        Me.lblCUENTA_COMPLETA.Size = New System.Drawing.Size(120, 22)
        Me.lblCUENTA_COMPLETA.TabIndex = 2
        Me.lblCUENTA_COMPLETA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBANCO
        '
        Me.cmbBANCO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBANCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBANCO.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbBANCO.ForeColor = System.Drawing.Color.Navy
        Me.cmbBANCO.FormattingEnabled = True
        Me.cmbBANCO.Location = New System.Drawing.Point(96, 24)
        Me.cmbBANCO.Name = "cmbBANCO"
        Me.cmbBANCO.Size = New System.Drawing.Size(384, 24)
        Me.cmbBANCO.TabIndex = 108
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Chequera :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 16)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Cuenta Banco :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 16)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "Banco :"
        '
        'cmbCHEQUERA
        '
        Me.cmbCHEQUERA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCHEQUERA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCHEQUERA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbCHEQUERA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCHEQUERA.FormattingEnabled = True
        Me.cmbCHEQUERA.Location = New System.Drawing.Point(96, 72)
        Me.cmbCHEQUERA.Name = "cmbCHEQUERA"
        Me.cmbCHEQUERA.Size = New System.Drawing.Size(384, 24)
        Me.cmbCHEQUERA.TabIndex = 107
        '
        'cmbCUENTA_BANCARIA
        '
        Me.cmbCUENTA_BANCARIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCUENTA_BANCARIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCUENTA_BANCARIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbCUENTA_BANCARIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCUENTA_BANCARIA.FormattingEnabled = True
        Me.cmbCUENTA_BANCARIA.Location = New System.Drawing.Point(96, 48)
        Me.cmbCUENTA_BANCARIA.Name = "cmbCUENTA_BANCARIA"
        Me.cmbCUENTA_BANCARIA.Size = New System.Drawing.Size(192, 24)
        Me.cmbCUENTA_BANCARIA.TabIndex = 107
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(296, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "Cuenta :"
        '
        'btnAnular
        '
        Me.btnAnular.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnAnular.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnular.Location = New System.Drawing.Point(311, 362)
        Me.btnAnular.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(80, 24)
        Me.btnAnular.TabIndex = 110
        Me.btnAnular.Text = "&Cancelar"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(111, 362)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(80, 24)
        Me.btnGenerar.TabIndex = 109
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'FrmCooperativaGenerarCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 390)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnAnular)
        Me.Controls.Add(Me.btnGenerar)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmCooperativaGenerarCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa Cheque"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalCheque As System.Windows.Forms.Label
    Friend WithEvents btnEditarConcepto As System.Windows.Forms.Button
    Friend WithEvents lblRetencion As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblIVA As System.Windows.Forms.Label
    Friend WithEvents lblSubTotal As System.Windows.Forms.Label
    Friend WithEvents dpFECHA_OC As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCONCEPTO As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblOC As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCENTRO_COSTO As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCUENTA As System.Windows.Forms.Label
    Friend WithEvents lblLIBRO_CONTABLE As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCUENTA_COMPLETA As System.Windows.Forms.Label
    Friend WithEvents cmbBANCO As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbCHEQUERA As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCUENTA_BANCARIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents TxtCreditoFiscal As System.Windows.Forms.TextBox
    Friend WithEvents BtnProveedor As System.Windows.Forms.Button
    Friend WithEvents lblNOMBRE_PROVEEDOR As System.Windows.Forms.TextBox
    Friend WithEvents chkNoNeg As System.Windows.Forms.CheckBox
    Friend WithEvents BtnBuscarProv As System.Windows.Forms.Button
    Friend WithEvents Lbl_Correlativo As System.Windows.Forms.Label
End Class
