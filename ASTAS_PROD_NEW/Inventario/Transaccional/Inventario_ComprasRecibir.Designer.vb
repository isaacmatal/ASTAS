<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_ComprasRecibir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_ComprasRecibir))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkContado = New System.Windows.Forms.CheckBox
        Me.lblISR = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFechaRecep = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Lbl_Descto = New System.Windows.Forms.Label
        Me.cmbTipoDocumento = New System.Windows.Forms.ComboBox
        Me.chkInv = New System.Windows.Forms.CheckBox
        Me.txtFACTURA = New System.Windows.Forms.TextBox
        Me.lblTotalCompra = New System.Windows.Forms.Label
        Me.lblRetencion = New System.Windows.Forms.Label
        Me.lblCESC = New System.Windows.Forms.Label
        Me.lblIVA = New System.Windows.Forms.Label
        Me.lblSubTotal = New System.Windows.Forms.Label
        Me.dpFecha_Comp = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblNOMBRE_PROVEEDOR = New System.Windows.Forms.Label
        Me.lblOC = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnAnular = New System.Windows.Forms.Button
        Me.btnIngresar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblExento = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblExento)
        Me.GroupBox1.Controls.Add(Me.chkContado)
        Me.GroupBox1.Controls.Add(Me.lblISR)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFechaRecep)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Lbl_Descto)
        Me.GroupBox1.Controls.Add(Me.cmbTipoDocumento)
        Me.GroupBox1.Controls.Add(Me.chkInv)
        Me.GroupBox1.Controls.Add(Me.txtFACTURA)
        Me.GroupBox1.Controls.Add(Me.lblTotalCompra)
        Me.GroupBox1.Controls.Add(Me.lblRetencion)
        Me.GroupBox1.Controls.Add(Me.lblCESC)
        Me.GroupBox1.Controls.Add(Me.lblIVA)
        Me.GroupBox1.Controls.Add(Me.lblSubTotal)
        Me.GroupBox1.Controls.Add(Me.dpFecha_Comp)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblNOMBRE_PROVEEDOR)
        Me.GroupBox1.Controls.Add(Me.lblOC)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(492, 271)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingrese en Número de Comprobante de Compra"
        '
        'chkContado
        '
        Me.chkContado.AutoSize = True
        Me.chkContado.Location = New System.Drawing.Point(401, 227)
        Me.chkContado.Name = "chkContado"
        Me.chkContado.Size = New System.Drawing.Size(73, 20)
        Me.chkContado.TabIndex = 128
        Me.chkContado.Text = "Contado"
        Me.chkContado.UseVisualStyleBackColor = True
        Me.chkContado.Visible = False
        '
        'lblISR
        '
        Me.lblISR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblISR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblISR.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblISR.ForeColor = System.Drawing.Color.DarkCyan
        Me.lblISR.Location = New System.Drawing.Point(401, 178)
        Me.lblISR.Name = "lblISR"
        Me.lblISR.Size = New System.Drawing.Size(84, 22)
        Me.lblISR.TabIndex = 127
        Me.lblISR.Text = "0.00"
        Me.lblISR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "Proveedor:"
        '
        'dtpFechaRecep
        '
        Me.dtpFechaRecep.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaRecep.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFechaRecep.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaRecep.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRecep.Location = New System.Drawing.Point(329, 22)
        Me.dtpFechaRecep.Name = "dtpFechaRecep"
        Me.dtpFechaRecep.Size = New System.Drawing.Size(94, 22)
        Me.dtpFechaRecep.TabIndex = 125
        Me.dtpFechaRecep.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Teal
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(8, 207)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 20)
        Me.Label7.TabIndex = 124
        Me.Label7.Text = "Descuento"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbl_Descto
        '
        Me.Lbl_Descto.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Lbl_Descto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_Descto.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Lbl_Descto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_Descto.Location = New System.Drawing.Point(8, 231)
        Me.Lbl_Descto.Name = "Lbl_Descto"
        Me.Lbl_Descto.Size = New System.Drawing.Size(88, 22)
        Me.Lbl_Descto.TabIndex = 123
        Me.Lbl_Descto.Text = "0.00"
        Me.Lbl_Descto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.BackColor = System.Drawing.Color.White
        Me.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbTipoDocumento.Enabled = False
        Me.cmbTipoDocumento.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDocumento.FormattingEnabled = True
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(107, 89)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(378, 24)
        Me.cmbTipoDocumento.TabIndex = 122
        '
        'chkInv
        '
        Me.chkInv.AutoSize = True
        Me.chkInv.Enabled = False
        Me.chkInv.Location = New System.Drawing.Point(200, 24)
        Me.chkInv.Name = "chkInv"
        Me.chkInv.Size = New System.Drawing.Size(123, 20)
        Me.chkInv.TabIndex = 119
        Me.chkInv.Text = "Afecta Inventarios"
        Me.chkInv.UseVisualStyleBackColor = True
        '
        'txtFACTURA
        '
        Me.txtFACTURA.BackColor = System.Drawing.SystemColors.Window
        Me.txtFACTURA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFACTURA.ForeColor = System.Drawing.Color.Navy
        Me.txtFACTURA.Location = New System.Drawing.Point(107, 123)
        Me.txtFACTURA.MaxLength = 10
        Me.txtFACTURA.Name = "txtFACTURA"
        Me.txtFACTURA.Size = New System.Drawing.Size(111, 22)
        Me.txtFACTURA.TabIndex = 43
        Me.txtFACTURA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalCompra
        '
        Me.lblTotalCompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTotalCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCompra.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCompra.ForeColor = System.Drawing.Color.Navy
        Me.lblTotalCompra.Location = New System.Drawing.Point(200, 227)
        Me.lblTotalCompra.Name = "lblTotalCompra"
        Me.lblTotalCompra.Size = New System.Drawing.Size(102, 27)
        Me.lblTotalCompra.TabIndex = 117
        Me.lblTotalCompra.Text = "0.00"
        Me.lblTotalCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRetencion
        '
        Me.lblRetencion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblRetencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRetencion.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblRetencion.ForeColor = System.Drawing.Color.Red
        Me.lblRetencion.Location = New System.Drawing.Point(307, 178)
        Me.lblRetencion.Name = "lblRetencion"
        Me.lblRetencion.Size = New System.Drawing.Size(88, 22)
        Me.lblRetencion.TabIndex = 117
        Me.lblRetencion.Text = "0.00"
        Me.lblRetencion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCESC
        '
        Me.lblCESC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCESC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCESC.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblCESC.ForeColor = System.Drawing.Color.Blue
        Me.lblCESC.Location = New System.Drawing.Point(200, 178)
        Me.lblCESC.Name = "lblCESC"
        Me.lblCESC.Size = New System.Drawing.Size(102, 22)
        Me.lblCESC.TabIndex = 117
        Me.lblCESC.Text = "0.00"
        Me.lblCESC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIVA
        '
        Me.lblIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIVA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblIVA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblIVA.Location = New System.Drawing.Point(104, 178)
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
        Me.lblSubTotal.Location = New System.Drawing.Point(8, 178)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(88, 22)
        Me.lblSubTotal.TabIndex = 116
        Me.lblSubTotal.Text = "0.00"
        Me.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dpFecha_Comp
        '
        Me.dpFecha_Comp.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFecha_Comp.CustomFormat = "dd-MMM-yyyy"
        Me.dpFecha_Comp.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFecha_Comp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFecha_Comp.Location = New System.Drawing.Point(391, 123)
        Me.dpFecha_Comp.Name = "dpFecha_Comp"
        Me.dpFecha_Comp.Size = New System.Drawing.Size(94, 22)
        Me.dpFecha_Comp.TabIndex = 44
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(278, 125)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(111, 16)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Fecha Comprobante :"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Teal
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(8, 154)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(477, 20)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "      Subtotal                  (+) IVA                    CESC                  " & _
            "   (+) % Percep.            (-) % ISR"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(8, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 16)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Tipo Comprobante.:"
        '
        'lblNOMBRE_PROVEEDOR
        '
        Me.lblNOMBRE_PROVEEDOR.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblNOMBRE_PROVEEDOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNOMBRE_PROVEEDOR.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblNOMBRE_PROVEEDOR.ForeColor = System.Drawing.Color.Navy
        Me.lblNOMBRE_PROVEEDOR.Location = New System.Drawing.Point(107, 56)
        Me.lblNOMBRE_PROVEEDOR.Name = "lblNOMBRE_PROVEEDOR"
        Me.lblNOMBRE_PROVEEDOR.Size = New System.Drawing.Size(378, 22)
        Me.lblNOMBRE_PROVEEDOR.TabIndex = 2
        Me.lblNOMBRE_PROVEEDOR.Text = "999"
        Me.lblNOMBRE_PROVEEDOR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOC
        '
        Me.lblOC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOC.ForeColor = System.Drawing.Color.Red
        Me.lblOC.Location = New System.Drawing.Point(107, 23)
        Me.lblOC.Name = "lblOC"
        Me.lblOC.Size = New System.Drawing.Size(65, 22)
        Me.lblOC.TabIndex = 2
        Me.lblOC.Text = "999"
        Me.lblOC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(7, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "No. Comprobante:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "N° O.C.:"
        '
        'btnAnular
        '
        Me.btnAnular.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnAnular.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnular.Location = New System.Drawing.Point(312, 285)
        Me.btnAnular.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(80, 24)
        Me.btnAnular.TabIndex = 1
        Me.btnAnular.Text = "&Cancelar"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'btnIngresar
        '
        Me.btnIngresar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIngresar.Image = CType(resources.GetObject("btnIngresar.Image"), System.Drawing.Image)
        Me.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresar.Location = New System.Drawing.Point(112, 285)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(80, 24)
        Me.btnIngresar.TabIndex = 0
        Me.btnIngresar.Text = "&Ingresar"
        Me.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(104, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "Total Exento"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblExento
        '
        Me.lblExento.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblExento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExento.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblExento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExento.Location = New System.Drawing.Point(104, 231)
        Me.lblExento.Name = "lblExento"
        Me.lblExento.Size = New System.Drawing.Size(88, 22)
        Me.lblExento.TabIndex = 129
        Me.lblExento.Text = "0.00"
        Me.lblExento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(200, 207)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 20)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Total Compra"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Inventario_ComprasRecibir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 312)
        Me.Controls.Add(Me.btnAnular)
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Inventario_ComprasRecibir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario - Recibir productos Comprados"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFACTURA As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalCompra As System.Windows.Forms.Label
    Friend WithEvents lblRetencion As System.Windows.Forms.Label
    Friend WithEvents lblCESC As System.Windows.Forms.Label
    Friend WithEvents lblIVA As System.Windows.Forms.Label
    Friend WithEvents lblSubTotal As System.Windows.Forms.Label
    Friend WithEvents dpFecha_Comp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblNOMBRE_PROVEEDOR As System.Windows.Forms.Label
    Friend WithEvents lblOC As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents chkInv As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Descto As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaRecep As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblISR As System.Windows.Forms.Label
    Friend WithEvents chkContado As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblExento As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
