<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Movimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Movimientos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtFecheo = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.CmbProveedor_CondicionPago = New System.Windows.Forms.ComboBox
        Me.CmbProveedor_FormaPago = New System.Windows.Forms.ComboBox
        Me.ChkLote = New System.Windows.Forms.CheckBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.CmbProveedor_TipoProveedor = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtOC = New System.Windows.Forms.TextBox
        Me.ChkHabilitar = New System.Windows.Forms.CheckBox
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.cmbMultiBodega = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TxtProveedor_Item = New System.Windows.Forms.TextBox
        Me.Txt_Proveedores = New System.Windows.Forms.TextBox
        Me.Txt_Tipo_Documento_requiere = New System.Windows.Forms.TextBox
        Me.Txt_Tipo_Movimiento_requiere = New System.Windows.Forms.TextBox
        Me.TxtBodega = New System.Windows.Forms.TextBox
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.Btn_Buscar_Movimiento = New System.Windows.Forms.Button
        Me.Btn_Buscar_Proveedor = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.Txt_tipo_movimiento_numero = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Cmb_tipo_documento = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.dpFECHA_CONTABLE = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Txt_tipo_documento_numero = New System.Windows.Forms.TextBox
        Me.btnProcesarPartida = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbTIPO_MOVIMIENTO = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblProcesado = New System.Windows.Forms.Label
        Me.Txt_Producto_cantidad = New System.Windows.Forms.TextBox
        Me.Txt_Producto_codigo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_Producto_descripcion = New System.Windows.Forms.TextBox
        Me.Txt_Producto_costo_total = New System.Windows.Forms.TextBox
        Me.Txt_Producto_costo_unitario = New System.Windows.Forms.TextBox
        Me.btnGuardarLinea = New System.Windows.Forms.Button
        Me.btnBuscarProducto = New System.Windows.Forms.Button
        Me.BtnLimpiar = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.lblCuenta = New System.Windows.Forms.Label
        Me.txtDIFERENCIA = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_Unidades = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtIVA = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSubTotal = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Txt_Existencias = New System.Windows.Forms.TextBox
        Me.txt_Renta = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvMovtos = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvMovtos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtFecheo)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.CmbProveedor_CondicionPago)
        Me.GroupBox1.Controls.Add(Me.CmbProveedor_FormaPago)
        Me.GroupBox1.Controls.Add(Me.ChkLote)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.CmbProveedor_TipoProveedor)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtOC)
        Me.GroupBox1.Controls.Add(Me.ChkHabilitar)
        Me.GroupBox1.Controls.Add(Me.txtCompañia)
        Me.GroupBox1.Controls.Add(Me.cmbMultiBodega)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TxtProveedor_Item)
        Me.GroupBox1.Controls.Add(Me.Txt_Proveedores)
        Me.GroupBox1.Controls.Add(Me.Txt_Tipo_Documento_requiere)
        Me.GroupBox1.Controls.Add(Me.Txt_Tipo_Movimiento_requiere)
        Me.GroupBox1.Controls.Add(Me.TxtBodega)
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Controls.Add(Me.Btn_Buscar_Movimiento)
        Me.GroupBox1.Controls.Add(Me.Btn_Buscar_Proveedor)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Txt_tipo_movimiento_numero)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Cmb_tipo_documento)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.dpFECHA_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Txt_tipo_documento_numero)
        Me.GroupBox1.Controls.Add(Me.btnProcesarPartida)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmbTIPO_MOVIMIENTO)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(3, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1104, 225)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Entradas / Salidas"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(825, 198)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(114, 16)
        Me.Label19.TabIndex = 135
        Me.Label19.Text = "Revisado 15/07/2015"
        '
        'txtFecheo
        '
        Me.txtFecheo.Location = New System.Drawing.Point(781, 166)
        Me.txtFecheo.Name = "txtFecheo"
        Me.txtFecheo.Size = New System.Drawing.Size(100, 22)
        Me.txtFecheo.TabIndex = 134
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(685, 164)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(90, 24)
        Me.Button4.TabIndex = 133
        Me.Button4.Text = "Fecheo"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'CmbProveedor_CondicionPago
        '
        Me.CmbProveedor_CondicionPago.BackColor = System.Drawing.SystemColors.Window
        Me.CmbProveedor_CondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProveedor_CondicionPago.Enabled = False
        Me.CmbProveedor_CondicionPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbProveedor_CondicionPago.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbProveedor_CondicionPago.ForeColor = System.Drawing.Color.Navy
        Me.CmbProveedor_CondicionPago.FormattingEnabled = True
        Me.CmbProveedor_CondicionPago.Location = New System.Drawing.Point(775, 132)
        Me.CmbProveedor_CondicionPago.Name = "CmbProveedor_CondicionPago"
        Me.CmbProveedor_CondicionPago.Size = New System.Drawing.Size(144, 24)
        Me.CmbProveedor_CondicionPago.TabIndex = 82
        '
        'CmbProveedor_FormaPago
        '
        Me.CmbProveedor_FormaPago.BackColor = System.Drawing.SystemColors.Window
        Me.CmbProveedor_FormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProveedor_FormaPago.Enabled = False
        Me.CmbProveedor_FormaPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbProveedor_FormaPago.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbProveedor_FormaPago.ForeColor = System.Drawing.Color.Navy
        Me.CmbProveedor_FormaPago.FormattingEnabled = True
        Me.CmbProveedor_FormaPago.Location = New System.Drawing.Point(775, 86)
        Me.CmbProveedor_FormaPago.Name = "CmbProveedor_FormaPago"
        Me.CmbProveedor_FormaPago.Size = New System.Drawing.Size(144, 24)
        Me.CmbProveedor_FormaPago.TabIndex = 81
        '
        'ChkLote
        '
        Me.ChkLote.AutoSize = True
        Me.ChkLote.Location = New System.Drawing.Point(684, 194)
        Me.ChkLote.Name = "ChkLote"
        Me.ChkLote.Size = New System.Drawing.Size(104, 20)
        Me.ChkLote.TabIndex = 5
        Me.ChkLote.Text = "Habilitar Lotes"
        Me.ToolTip1.SetToolTip(Me.ChkLote, "Permite Deshabilitar datos de Lotes.")
        Me.ChkLote.UseVisualStyleBackColor = True
        Me.ChkLote.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(821, 118)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(98, 16)
        Me.Label23.TabIndex = 84
        Me.Label23.Text = "Condición de Pago"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(837, 72)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(82, 16)
        Me.Label24.TabIndex = 83
        Me.Label24.Text = "Forma de Pago"
        '
        'CmbProveedor_TipoProveedor
        '
        Me.CmbProveedor_TipoProveedor.BackColor = System.Drawing.SystemColors.Window
        Me.CmbProveedor_TipoProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProveedor_TipoProveedor.Enabled = False
        Me.CmbProveedor_TipoProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbProveedor_TipoProveedor.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbProveedor_TipoProveedor.ForeColor = System.Drawing.Color.Navy
        Me.CmbProveedor_TipoProveedor.FormattingEnabled = True
        Me.CmbProveedor_TipoProveedor.Location = New System.Drawing.Point(775, 44)
        Me.CmbProveedor_TipoProveedor.Name = "CmbProveedor_TipoProveedor"
        Me.CmbProveedor_TipoProveedor.Size = New System.Drawing.Size(144, 24)
        Me.CmbProveedor_TipoProveedor.TabIndex = 79
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(821, 30)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 16)
        Me.Label22.TabIndex = 80
        Me.Label22.Text = "Tipo Contribuyente"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(475, 117)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 16)
        Me.Label21.TabIndex = 78
        Me.Label21.Text = "N° OC"
        '
        'txtOC
        '
        Me.txtOC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtOC.Enabled = False
        Me.txtOC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOC.ForeColor = System.Drawing.Color.Navy
        Me.txtOC.Location = New System.Drawing.Point(521, 114)
        Me.txtOC.Name = "txtOC"
        Me.txtOC.Size = New System.Drawing.Size(112, 22)
        Me.txtOC.TabIndex = 77
        Me.ToolTip1.SetToolTip(Me.txtOC, "Numero de Orden de Compra Asociada")
        '
        'ChkHabilitar
        '
        Me.ChkHabilitar.AutoSize = True
        Me.ChkHabilitar.Location = New System.Drawing.Point(156, 194)
        Me.ChkHabilitar.Name = "ChkHabilitar"
        Me.ChkHabilitar.Size = New System.Drawing.Size(15, 14)
        Me.ChkHabilitar.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ChkHabilitar, "Habilitar Múltiples Bodegas")
        Me.ChkHabilitar.UseVisualStyleBackColor = True
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(250, 18)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(383, 22)
        Me.txtCompañia.TabIndex = 0
        '
        'cmbMultiBodega
        '
        Me.cmbMultiBodega.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMultiBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMultiBodega.Enabled = False
        Me.cmbMultiBodega.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMultiBodega.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMultiBodega.ForeColor = System.Drawing.Color.Navy
        Me.cmbMultiBodega.FormattingEnabled = True
        Me.cmbMultiBodega.Location = New System.Drawing.Point(250, 190)
        Me.cmbMultiBodega.Name = "cmbMultiBodega"
        Me.cmbMultiBodega.Size = New System.Drawing.Size(384, 24)
        Me.cmbMultiBodega.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(167, 193)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 16)
        Me.Label18.TabIndex = 132
        Me.Label18.Text = "Multiple Bodega"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(684, 59)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 24)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Anular"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button1, "Clic para anular el documento actual")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(684, 18)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 24)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Nuevo"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button2, "Clic para crear un nuevo documento")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtProveedor_Item
        '
        Me.TxtProveedor_Item.BackColor = System.Drawing.SystemColors.Window
        Me.TxtProveedor_Item.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Item.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_Item.Location = New System.Drawing.Point(636, 92)
        Me.TxtProveedor_Item.Name = "TxtProveedor_Item"
        Me.TxtProveedor_Item.Size = New System.Drawing.Size(19, 22)
        Me.TxtProveedor_Item.TabIndex = 76
        Me.TxtProveedor_Item.Visible = False
        '
        'Txt_Proveedores
        '
        Me.Txt_Proveedores.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Proveedores.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Proveedores.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Proveedores.Location = New System.Drawing.Point(250, 90)
        Me.Txt_Proveedores.Name = "Txt_Proveedores"
        Me.Txt_Proveedores.ReadOnly = True
        Me.Txt_Proveedores.Size = New System.Drawing.Size(360, 22)
        Me.Txt_Proveedores.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.Txt_Proveedores, "Clic en la Lupa para buscar proveedor")
        '
        'Txt_Tipo_Documento_requiere
        '
        Me.Txt_Tipo_Documento_requiere.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Tipo_Documento_requiere.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Tipo_Documento_requiere.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Tipo_Documento_requiere.Location = New System.Drawing.Point(635, 140)
        Me.Txt_Tipo_Documento_requiere.Name = "Txt_Tipo_Documento_requiere"
        Me.Txt_Tipo_Documento_requiere.Size = New System.Drawing.Size(19, 22)
        Me.Txt_Tipo_Documento_requiere.TabIndex = 73
        Me.Txt_Tipo_Documento_requiere.Visible = False
        '
        'Txt_Tipo_Movimiento_requiere
        '
        Me.Txt_Tipo_Movimiento_requiere.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Tipo_Movimiento_requiere.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Tipo_Movimiento_requiere.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Tipo_Movimiento_requiere.Location = New System.Drawing.Point(636, 65)
        Me.Txt_Tipo_Movimiento_requiere.Name = "Txt_Tipo_Movimiento_requiere"
        Me.Txt_Tipo_Movimiento_requiere.Size = New System.Drawing.Size(19, 22)
        Me.Txt_Tipo_Movimiento_requiere.TabIndex = 72
        Me.Txt_Tipo_Movimiento_requiere.Visible = False
        '
        'TxtBodega
        '
        Me.TxtBodega.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBodega.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBodega.ForeColor = System.Drawing.Color.Navy
        Me.TxtBodega.Location = New System.Drawing.Point(635, 40)
        Me.TxtBodega.Name = "TxtBodega"
        Me.TxtBodega.Size = New System.Drawing.Size(19, 22)
        Me.TxtBodega.TabIndex = 71
        Me.TxtBodega.Visible = False
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(6, 22)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(143, 197)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 78
        Me.pbImagen.TabStop = False
        '
        'Btn_Buscar_Movimiento
        '
        Me.Btn_Buscar_Movimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Buscar_Movimiento.Image = CType(resources.GetObject("Btn_Buscar_Movimiento.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Movimiento.Location = New System.Drawing.Point(364, 113)
        Me.Btn_Buscar_Movimiento.Name = "Btn_Buscar_Movimiento"
        Me.Btn_Buscar_Movimiento.Size = New System.Drawing.Size(24, 24)
        Me.Btn_Buscar_Movimiento.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.Btn_Buscar_Movimiento, "Clic para buscar el documento")
        Me.Btn_Buscar_Movimiento.UseVisualStyleBackColor = True
        '
        'Btn_Buscar_Proveedor
        '
        Me.Btn_Buscar_Proveedor.Enabled = False
        Me.Btn_Buscar_Proveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Buscar_Proveedor.Image = CType(resources.GetObject("Btn_Buscar_Proveedor.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Proveedor.Location = New System.Drawing.Point(610, 90)
        Me.Btn_Buscar_Proveedor.Name = "Btn_Buscar_Proveedor"
        Me.Btn_Buscar_Proveedor.Size = New System.Drawing.Size(24, 24)
        Me.Btn_Buscar_Proveedor.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.Btn_Buscar_Proveedor, "Clic para desplegar catalogo de Proveedores")
        Me.Btn_Buscar_Proveedor.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(157, 92)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 16)
        Me.Label16.TabIndex = 66
        Me.Label16.Text = "Proveedor"
        '
        'Txt_tipo_movimiento_numero
        '
        Me.Txt_tipo_movimiento_numero.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_tipo_movimiento_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_tipo_movimiento_numero.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_tipo_movimiento_numero.ForeColor = System.Drawing.Color.Navy
        Me.Txt_tipo_movimiento_numero.Location = New System.Drawing.Point(250, 114)
        Me.Txt_tipo_movimiento_numero.Name = "Txt_tipo_movimiento_numero"
        Me.Txt_tipo_movimiento_numero.Size = New System.Drawing.Size(112, 22)
        Me.Txt_tipo_movimiento_numero.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.Txt_tipo_movimiento_numero, "No cambien el numero, a menos que desee buscar un documento")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(155, 165)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 16)
        Me.Label14.TabIndex = 64
        Me.Label14.Text = "N° Documento"
        '
        'Cmb_tipo_documento
        '
        Me.Cmb_tipo_documento.BackColor = System.Drawing.SystemColors.Window
        Me.Cmb_tipo_documento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_tipo_documento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmb_tipo_documento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_tipo_documento.ForeColor = System.Drawing.Color.Navy
        Me.Cmb_tipo_documento.FormattingEnabled = True
        Me.Cmb_tipo_documento.Location = New System.Drawing.Point(250, 138)
        Me.Cmb_tipo_documento.Name = "Cmb_tipo_documento"
        Me.Cmb_tipo_documento.Size = New System.Drawing.Size(384, 24)
        Me.Cmb_tipo_documento.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.Cmb_tipo_documento, "Seleccione el tipo de documento a realizar")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(155, 140)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 16)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "Tipo Documento"
        '
        'dpFECHA_CONTABLE
        '
        Me.dpFECHA_CONTABLE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CONTABLE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CONTABLE.Location = New System.Drawing.Point(523, 162)
        Me.dpFECHA_CONTABLE.Name = "dpFECHA_CONTABLE"
        Me.dpFECHA_CONTABLE.Size = New System.Drawing.Size(112, 22)
        Me.dpFECHA_CONTABLE.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.dpFECHA_CONTABLE, "Seleccione la fecha del movimiento")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(479, 165)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 16)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Fecha"
        '
        'Txt_tipo_documento_numero
        '
        Me.Txt_tipo_documento_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_tipo_documento_numero.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_tipo_documento_numero.ForeColor = System.Drawing.Color.Navy
        Me.Txt_tipo_documento_numero.Location = New System.Drawing.Point(250, 162)
        Me.Txt_tipo_documento_numero.Name = "Txt_tipo_documento_numero"
        Me.Txt_tipo_documento_numero.Size = New System.Drawing.Size(112, 22)
        Me.Txt_tipo_documento_numero.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.Txt_tipo_documento_numero, "Ingrese el numero del documento")
        '
        'btnProcesarPartida
        '
        Me.btnProcesarPartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcesarPartida.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnProcesarPartida.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesarPartida.Image = CType(resources.GetObject("btnProcesarPartida.Image"), System.Drawing.Image)
        Me.btnProcesarPartida.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesarPartida.Location = New System.Drawing.Point(685, 113)
        Me.btnProcesarPartida.Name = "btnProcesarPartida"
        Me.btnProcesarPartida.Size = New System.Drawing.Size(64, 40)
        Me.btnProcesarPartida.TabIndex = 8
        Me.btnProcesarPartida.Text = "&Procesar"
        Me.btnProcesarPartida.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnProcesarPartida, "Clic para procesar el movimiento")
        Me.btnProcesarPartida.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(155, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 16)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "N° Movimiento"
        '
        'cmbTIPO_MOVIMIENTO
        '
        Me.cmbTIPO_MOVIMIENTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_MOVIMIENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_MOVIMIENTO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTIPO_MOVIMIENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_MOVIMIENTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_MOVIMIENTO.FormattingEnabled = True
        Me.cmbTIPO_MOVIMIENTO.Location = New System.Drawing.Point(250, 65)
        Me.cmbTIPO_MOVIMIENTO.Name = "cmbTIPO_MOVIMIENTO"
        Me.cmbTIPO_MOVIMIENTO.Size = New System.Drawing.Size(383, 24)
        Me.cmbTIPO_MOVIMIENTO.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmbTIPO_MOVIMIENTO, "Seleccione el tipo de movimiento a realizar")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(155, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 16)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Tipo Movimiento"
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(250, 40)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(383, 24)
        Me.cmbBODEGA.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cmbBODEGA, "Seleccione la bodega de donde se realizara el movimiento")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(155, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Bodega"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(155, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía"
        '
        'lblProcesado
        '
        Me.lblProcesado.BackColor = System.Drawing.Color.Yellow
        Me.lblProcesado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcesado.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblProcesado.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcesado.ForeColor = System.Drawing.Color.Red
        Me.lblProcesado.Location = New System.Drawing.Point(0, 0)
        Me.lblProcesado.Name = "lblProcesado"
        Me.lblProcesado.Size = New System.Drawing.Size(1110, 22)
        Me.lblProcesado.TabIndex = 80
        Me.lblProcesado.Text = "NUEVO DOCUMENTO"
        Me.lblProcesado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Txt_Producto_cantidad
        '
        Me.Txt_Producto_cantidad.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Producto_cantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Producto_cantidad.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_cantidad.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_cantidad.Location = New System.Drawing.Point(455, 270)
        Me.Txt_Producto_cantidad.Name = "Txt_Producto_cantidad"
        Me.Txt_Producto_cantidad.Size = New System.Drawing.Size(70, 22)
        Me.Txt_Producto_cantidad.TabIndex = 2
        Me.Txt_Producto_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.Txt_Producto_cantidad, "Digite la cantidad a ingresar")
        '
        'Txt_Producto_codigo
        '
        Me.Txt_Producto_codigo.BackColor = System.Drawing.Color.White
        Me.Txt_Producto_codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Producto_codigo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_codigo.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_codigo.Location = New System.Drawing.Point(6, 270)
        Me.Txt_Producto_codigo.Name = "Txt_Producto_codigo"
        Me.Txt_Producto_codigo.Size = New System.Drawing.Size(80, 22)
        Me.Txt_Producto_codigo.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.Txt_Producto_codigo, "Digite el codigo del producto y de Enter")
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(6, 247)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 20)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Código"
        '
        'Txt_Producto_descripcion
        '
        Me.Txt_Producto_descripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Txt_Producto_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Producto_descripcion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_descripcion.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_descripcion.Location = New System.Drawing.Point(110, 270)
        Me.Txt_Producto_descripcion.MaxLength = 100
        Me.Txt_Producto_descripcion.Name = "Txt_Producto_descripcion"
        Me.Txt_Producto_descripcion.ReadOnly = True
        Me.Txt_Producto_descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Producto_descripcion.Size = New System.Drawing.Size(342, 22)
        Me.Txt_Producto_descripcion.TabIndex = 3
        '
        'Txt_Producto_costo_total
        '
        Me.Txt_Producto_costo_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Producto_costo_total.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_costo_total.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_costo_total.Location = New System.Drawing.Point(750, 270)
        Me.Txt_Producto_costo_total.Name = "Txt_Producto_costo_total"
        Me.Txt_Producto_costo_total.Size = New System.Drawing.Size(70, 22)
        Me.Txt_Producto_costo_total.TabIndex = 4
        Me.Txt_Producto_costo_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Producto_costo_unitario
        '
        Me.Txt_Producto_costo_unitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Producto_costo_unitario.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_costo_unitario.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_costo_unitario.Location = New System.Drawing.Point(678, 270)
        Me.Txt_Producto_costo_unitario.Name = "Txt_Producto_costo_unitario"
        Me.Txt_Producto_costo_unitario.Size = New System.Drawing.Size(70, 22)
        Me.Txt_Producto_costo_unitario.TabIndex = 3
        Me.Txt_Producto_costo_unitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.Txt_Producto_costo_unitario, "Digite el costo unitario")
        '
        'btnGuardarLinea
        '
        Me.btnGuardarLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardarLinea.ForeColor = System.Drawing.Color.White
        Me.btnGuardarLinea.Image = CType(resources.GetObject("btnGuardarLinea.Image"), System.Drawing.Image)
        Me.btnGuardarLinea.Location = New System.Drawing.Point(831, 263)
        Me.btnGuardarLinea.Name = "btnGuardarLinea"
        Me.btnGuardarLinea.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardarLinea.TabIndex = 6
        Me.btnGuardarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardarLinea, "Ingresar el registro a la base de datos.")
        Me.btnGuardarLinea.UseVisualStyleBackColor = True
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.Location = New System.Drawing.Point(86, 270)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.btnBuscarProducto, "Clic para desplegar el catalogo de Productos")
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLimpiar.ForeColor = System.Drawing.Color.White
        Me.BtnLimpiar.Image = CType(resources.GetObject("BtnLimpiar.Image"), System.Drawing.Image)
        Me.BtnLimpiar.Location = New System.Drawing.Point(864, 263)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(28, 28)
        Me.BtnLimpiar.TabIndex = 7
        Me.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnLimpiar, "Clic para limpiar ")
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(896, 262)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 28)
        Me.Button3.TabIndex = 8
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button3, "Clic para eliminar un registro")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuenta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCuenta.Location = New System.Drawing.Point(85, 247)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(14, 16)
        Me.lblCuenta.TabIndex = 57
        Me.lblCuenta.Text = "0"
        Me.lblCuenta.Visible = False
        '
        'txtDIFERENCIA
        '
        Me.txtDIFERENCIA.BackColor = System.Drawing.SystemColors.Window
        Me.txtDIFERENCIA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDIFERENCIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIFERENCIA.ForeColor = System.Drawing.Color.Red
        Me.txtDIFERENCIA.Location = New System.Drawing.Point(659, 22)
        Me.txtDIFERENCIA.Name = "txtDIFERENCIA"
        Me.txtDIFERENCIA.ReadOnly = True
        Me.txtDIFERENCIA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDIFERENCIA.Size = New System.Drawing.Size(104, 22)
        Me.txtDIFERENCIA.TabIndex = 35
        Me.txtDIFERENCIA.Text = "0.00"
        Me.txtDIFERENCIA.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(732, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 16)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Total"
        Me.Label12.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Teal
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(114, 247)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(375, 20)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Descripción de productos"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Teal
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(473, 247)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 20)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Cantidad"
        '
        'txt_Unidades
        '
        Me.txt_Unidades.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_Unidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Unidades.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Unidades.ForeColor = System.Drawing.Color.Navy
        Me.txt_Unidades.Location = New System.Drawing.Point(527, 270)
        Me.txt_Unidades.Name = "txt_Unidades"
        Me.txt_Unidades.ReadOnly = True
        Me.txt_Unidades.Size = New System.Drawing.Size(70, 22)
        Me.txt_Unidades.TabIndex = 122
        Me.txt_Unidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(555, 247)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 20)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Unidad"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Teal
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(639, 247)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 20)
        Me.Label10.TabIndex = 124
        Me.Label10.Text = "Costo U."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Teal
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Yellow
        Me.Label11.Location = New System.Drawing.Point(669, 247)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(152, 20)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "Costo Total"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtIVA
        '
        Me.txtIVA.BackColor = System.Drawing.SystemColors.Window
        Me.txtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIVA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA.ForeColor = System.Drawing.Color.Red
        Me.txtIVA.Location = New System.Drawing.Point(329, 22)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtIVA.Size = New System.Drawing.Size(104, 22)
        Me.txtIVA.TabIndex = 126
        Me.txtIVA.Text = "0.00"
        Me.txtIVA.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(411, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 16)
        Me.Label5.TabIndex = 127
        Me.Label5.Text = "IVA"
        Me.Label5.Visible = False
        '
        'txtSubTotal
        '
        Me.txtSubTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubTotal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.ForeColor = System.Drawing.Color.Red
        Me.txtSubTotal.Location = New System.Drawing.Point(215, 22)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSubTotal.Size = New System.Drawing.Size(104, 22)
        Me.txtSubTotal.TabIndex = 128
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(286, 44)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 16)
        Me.Label17.TabIndex = 129
        Me.Label17.Text = "Costo"
        Me.Label17.Visible = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Teal
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Yellow
        Me.Label20.Location = New System.Drawing.Point(618, 247)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 20)
        Me.Label20.TabIndex = 137
        Me.Label20.Text = "Existencia"
        '
        'Txt_Existencias
        '
        Me.Txt_Existencias.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Existencias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Existencias.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Existencias.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Existencias.Location = New System.Drawing.Point(599, 270)
        Me.Txt_Existencias.Name = "Txt_Existencias"
        Me.Txt_Existencias.Size = New System.Drawing.Size(77, 22)
        Me.Txt_Existencias.TabIndex = 142
        Me.Txt_Existencias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.Txt_Existencias, "Digite la cantidad a ingresar")
        '
        'txt_Renta
        '
        Me.txt_Renta.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Renta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Renta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Renta.ForeColor = System.Drawing.Color.Red
        Me.txt_Renta.Location = New System.Drawing.Point(549, 22)
        Me.txt_Renta.Name = "txt_Renta"
        Me.txt_Renta.ReadOnly = True
        Me.txt_Renta.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Renta.Size = New System.Drawing.Size(104, 22)
        Me.txt_Renta.TabIndex = 138
        Me.txt_Renta.Text = "0.00"
        Me.txt_Renta.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(553, 43)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(103, 16)
        Me.Label25.TabIndex = 139
        Me.Label25.Text = " (+/-) Retencion/ISR"
        Me.Label25.Visible = False
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Red
        Me.txtTotal.Location = New System.Drawing.Point(439, 22)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotal.Size = New System.Drawing.Size(104, 22)
        Me.txtTotal.TabIndex = 140
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(491, 43)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(53, 16)
        Me.Label26.TabIndex = 141
        Me.Label26.Text = "Sub Total"
        Me.Label26.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Txt_Existencias)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.btnBuscarProducto)
        Me.GroupBox2.Controls.Add(Me.Txt_Producto_cantidad)
        Me.GroupBox2.Controls.Add(Me.Txt_Producto_codigo)
        Me.GroupBox2.Controls.Add(Me.btnGuardarLinea)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Txt_Producto_costo_total)
        Me.GroupBox2.Controls.Add(Me.Txt_Producto_descripcion)
        Me.GroupBox2.Controls.Add(Me.Txt_Producto_costo_unitario)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.lblCuenta)
        Me.GroupBox2.Controls.Add(Me.BtnLimpiar)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txt_Unidades)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1110, 300)
        Me.GroupBox2.TabIndex = 143
        Me.GroupBox2.TabStop = False
        '
        'dgvMovtos
        '
        Me.dgvMovtos.AllowUserToAddRows = False
        Me.dgvMovtos.AllowUserToDeleteRows = False
        Me.dgvMovtos.AllowUserToResizeColumns = False
        Me.dgvMovtos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvMovtos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMovtos.BackgroundColor = System.Drawing.Color.Beige
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMovtos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMovtos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMovtos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMovtos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvMovtos.Location = New System.Drawing.Point(0, 322)
        Me.dgvMovtos.MultiSelect = False
        Me.dgvMovtos.Name = "dgvMovtos"
        Me.dgvMovtos.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.GrayText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.GrayText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMovtos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMovtos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovtos.Size = New System.Drawing.Size(1110, 222)
        Me.dgvMovtos.TabIndex = 144
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtDIFERENCIA)
        Me.GroupBox3.Controls.Add(Me.txtTotal)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txt_Renta)
        Me.GroupBox3.Controls.Add(Me.txtIVA)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.txtSubTotal)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox3.Location = New System.Drawing.Point(0, 544)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1110, 81)
        Me.GroupBox3.TabIndex = 145
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Totales"
        '
        'Inventario_Movimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1110, 625)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dgvMovtos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblProcesado)
        Me.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Inventario_Movimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventarios Movimientos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvMovtos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dpFECHA_CONTABLE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Txt_tipo_documento_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTIPO_MOVIMIENTO As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_Producto_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_Producto_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents btnGuardarLinea As System.Windows.Forms.Button
    Friend WithEvents Txt_Producto_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtDIFERENCIA As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Txt_Producto_costo_total As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Producto_costo_unitario As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_tipo_movimiento_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cmb_tipo_documento As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Btn_Buscar_Proveedor As System.Windows.Forms.Button
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Btn_Buscar_Movimiento As System.Windows.Forms.Button
    Friend WithEvents TxtBodega As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Tipo_Movimiento_requiere As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Tipo_Documento_requiere As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Proveedores As System.Windows.Forms.TextBox
    Friend WithEvents TxtProveedor_Item As System.Windows.Forms.TextBox
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnProcesarPartida As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblProcesado As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_Unidades As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cmbMultiBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ChkHabilitar As System.Windows.Forms.CheckBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtOC As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CmbProveedor_TipoProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CmbProveedor_CondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents CmbProveedor_FormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_Renta As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ChkLote As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_Existencias As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMovtos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecheo As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
