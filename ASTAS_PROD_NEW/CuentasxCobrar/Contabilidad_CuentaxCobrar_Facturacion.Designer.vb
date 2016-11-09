<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_CuentaxCobrar_Facturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_CuentaxCobrar_Facturacion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tbContFact = New System.Windows.Forms.TabControl
        Me.tbDatos = New System.Windows.Forms.TabPage
        Me.lblMaxLineas = New System.Windows.Forms.Label
        Me.lblMsjMaxLineas = New System.Windows.Forms.Label
        Me.btnLimpiarDetalle = New System.Windows.Forms.Button
        Me.btnEliminarDetFact = New System.Windows.Forms.Button
        Me.txtLibras = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTotalFact = New System.Windows.Forms.TextBox
        Me.txtPercepcion = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.txtIVA = New System.Windows.Forms.TextBox
        Me.txtSubTotal = New System.Windows.Forms.TextBox
        Me.btnGuardarDetalle = New System.Windows.Forms.Button
        Me.cmbUNIDAD_MEDIDA = New System.Windows.Forms.ComboBox
        Me.txtPrecio = New System.Windows.Forms.TextBox
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.btnBuscarProducto = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtProducto = New System.Windows.Forms.TextBox
        Me.dgvDetalleFact = New System.Windows.Forms.DataGridView
        Me.CodProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nomProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnidadMedida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CantidadProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineaDetalle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbDC = New System.Windows.Forms.GroupBox
        Me.txtSaldoPend = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtValRemesa = New System.Windows.Forms.TextBox
        Me.chkSocio = New System.Windows.Forms.CheckBox
        Me.Label62 = New System.Windows.Forms.Label
        Me.Label63 = New System.Windows.Forms.Label
        Me.btnActualizarCliente = New System.Windows.Forms.Button
        Me.txtNoRemesa = New System.Windows.Forms.TextBox
        Me.txtNitCliente = New System.Windows.Forms.MaskedTextBox
        Me.cmbBancos = New System.Windows.Forms.ComboBox
        Me.txtDuiCliente = New System.Windows.Forms.MaskedTextBox
        Me.txtConcepto = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtGiro = New System.Windows.Forms.TextBox
        Me.txtFaxCliente = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cmbTIPO_CLIENTE = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtDireccionCliente = New System.Windows.Forms.TextBox
        Me.chkExento = New System.Windows.Forms.CheckBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmbCONTRIBUYENTE = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtTelCliente = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtNombreFactura = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtRegFiscal = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbFORMA_PAGO = New System.Windows.Forms.ComboBox
        Me.cmbTIPO_DOCUMENTO = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.cmbCONDICION_PAGO = New System.Windows.Forms.ComboBox
        Me.btnBuscarCliente = New System.Windows.Forms.Button
        Me.txtNombreCliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.chkModif = New System.Windows.Forms.CheckBox
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.txtLinea = New System.Windows.Forms.Label
        Me.gbGral = New System.Windows.Forms.GroupBox
        Me.btnElimFact = New System.Windows.Forms.Button
        Me.bntImprimir = New System.Windows.Forms.Button
        Me.txtNumFact = New System.Windows.Forms.TextBox
        Me.txtNumDocumentoOV1 = New System.Windows.Forms.Label
        Me.lblFactSiNo = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.dpFECHA_OV = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label59 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.MaskedTextBox1 = New System.Windows.Forms.MaskedTextBox
        Me.MaskedTextBox2 = New System.Windows.Forms.MaskedTextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.ComboBox5 = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.cmbCtasBanco = New System.Windows.Forms.ComboBox
        Me.tbContFact.SuspendLayout()
        Me.tbDatos.SuspendLayout()
        CType(Me.dgvDetalleFact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDC.SuspendLayout()
        Me.gbGral.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbContFact
        '
        Me.tbContFact.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbContFact.Controls.Add(Me.tbDatos)
        Me.tbContFact.Location = New System.Drawing.Point(0, 79)
        Me.tbContFact.Name = "tbContFact"
        Me.tbContFact.SelectedIndex = 0
        Me.tbContFact.Size = New System.Drawing.Size(738, 550)
        Me.tbContFact.TabIndex = 1
        '
        'tbDatos
        '
        Me.tbDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tbDatos.Controls.Add(Me.lblMaxLineas)
        Me.tbDatos.Controls.Add(Me.lblMsjMaxLineas)
        Me.tbDatos.Controls.Add(Me.btnLimpiarDetalle)
        Me.tbDatos.Controls.Add(Me.btnEliminarDetFact)
        Me.tbDatos.Controls.Add(Me.txtLibras)
        Me.tbDatos.Controls.Add(Me.Label17)
        Me.tbDatos.Controls.Add(Me.txtTotalFact)
        Me.tbDatos.Controls.Add(Me.txtPercepcion)
        Me.tbDatos.Controls.Add(Me.txtTotal)
        Me.tbDatos.Controls.Add(Me.txtIVA)
        Me.tbDatos.Controls.Add(Me.txtSubTotal)
        Me.tbDatos.Controls.Add(Me.btnGuardarDetalle)
        Me.tbDatos.Controls.Add(Me.cmbUNIDAD_MEDIDA)
        Me.tbDatos.Controls.Add(Me.txtPrecio)
        Me.tbDatos.Controls.Add(Me.txtCantidad)
        Me.tbDatos.Controls.Add(Me.txtDescripcion)
        Me.tbDatos.Controls.Add(Me.btnBuscarProducto)
        Me.tbDatos.Controls.Add(Me.Label14)
        Me.tbDatos.Controls.Add(Me.txtProducto)
        Me.tbDatos.Controls.Add(Me.dgvDetalleFact)
        Me.tbDatos.Controls.Add(Me.gbDC)
        Me.tbDatos.Controls.Add(Me.chkModif)
        Me.tbDatos.Location = New System.Drawing.Point(4, 28)
        Me.tbDatos.Name = "tbDatos"
        Me.tbDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDatos.Size = New System.Drawing.Size(730, 518)
        Me.tbDatos.TabIndex = 0
        Me.tbDatos.Text = "Datos"
        Me.tbDatos.UseVisualStyleBackColor = True
        '
        'lblMaxLineas
        '
        Me.lblMaxLineas.AutoSize = True
        Me.lblMaxLineas.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaxLineas.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lblMaxLineas.Location = New System.Drawing.Point(136, 462)
        Me.lblMaxLineas.Name = "lblMaxLineas"
        Me.lblMaxLineas.Size = New System.Drawing.Size(32, 37)
        Me.lblMaxLineas.TabIndex = 20
        Me.lblMaxLineas.Text = "0"
        Me.lblMaxLineas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMaxLineas.Visible = False
        '
        'lblMsjMaxLineas
        '
        Me.lblMsjMaxLineas.AutoSize = True
        Me.lblMsjMaxLineas.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsjMaxLineas.ForeColor = System.Drawing.Color.Navy
        Me.lblMsjMaxLineas.Location = New System.Drawing.Point(8, 462)
        Me.lblMsjMaxLineas.Name = "lblMsjMaxLineas"
        Me.lblMsjMaxLineas.Size = New System.Drawing.Size(125, 40)
        Me.lblMsjMaxLineas.TabIndex = 19
        Me.lblMsjMaxLineas.Text = "Número máximo de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "detalles admitidos:"
        Me.lblMsjMaxLineas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMsjMaxLineas.Visible = False
        '
        'btnLimpiarDetalle
        '
        Me.btnLimpiarDetalle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiarDetalle.Image = CType(resources.GetObject("btnLimpiarDetalle.Image"), System.Drawing.Image)
        Me.btnLimpiarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarDetalle.Location = New System.Drawing.Point(668, 251)
        Me.btnLimpiarDetalle.Name = "btnLimpiarDetalle"
        Me.btnLimpiarDetalle.Size = New System.Drawing.Size(24, 24)
        Me.btnLimpiarDetalle.TabIndex = 11
        Me.btnLimpiarDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiarDetalle, "Reestablece los campos para ingresar un nuevo detalle")
        Me.btnLimpiarDetalle.UseVisualStyleBackColor = True
        '
        'btnEliminarDetFact
        '
        Me.btnEliminarDetFact.Image = CType(resources.GetObject("btnEliminarDetFact.Image"), System.Drawing.Image)
        Me.btnEliminarDetFact.Location = New System.Drawing.Point(645, 251)
        Me.btnEliminarDetFact.Name = "btnEliminarDetFact"
        Me.btnEliminarDetFact.Size = New System.Drawing.Size(24, 24)
        Me.btnEliminarDetFact.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.btnEliminarDetFact, "Elimina un detalle previamente seleccionado")
        Me.btnEliminarDetFact.UseVisualStyleBackColor = True
        '
        'txtLibras
        '
        Me.txtLibras.BackColor = System.Drawing.SystemColors.Window
        Me.txtLibras.Enabled = False
        Me.txtLibras.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLibras.ForeColor = System.Drawing.Color.Navy
        Me.txtLibras.Location = New System.Drawing.Point(675, 251)
        Me.txtLibras.Name = "txtLibras"
        Me.txtLibras.Size = New System.Drawing.Size(47, 22)
        Me.txtLibras.TabIndex = 7
        Me.txtLibras.Visible = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Teal
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(418, 462)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(305, 20)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "        Subtotal                    (+) IVA                         Total Factura" & _
            ""
        '
        'txtTotalFact
        '
        Me.txtTotalFact.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotalFact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalFact.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFact.ForeColor = System.Drawing.Color.Red
        Me.txtTotalFact.Location = New System.Drawing.Point(627, 483)
        Me.txtTotalFact.Name = "txtTotalFact"
        Me.txtTotalFact.ReadOnly = True
        Me.txtTotalFact.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalFact.Size = New System.Drawing.Size(96, 25)
        Me.txtTotalFact.TabIndex = 18
        Me.txtTotalFact.Text = "0.00"
        '
        'txtPercepcion
        '
        Me.txtPercepcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPercepcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPercepcion.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPercepcion.ForeColor = System.Drawing.Color.Navy
        Me.txtPercepcion.Location = New System.Drawing.Point(223, 483)
        Me.txtPercepcion.Name = "txtPercepcion"
        Me.txtPercepcion.ReadOnly = True
        Me.txtPercepcion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPercepcion.Size = New System.Drawing.Size(96, 25)
        Me.txtPercepcion.TabIndex = 17
        Me.txtPercepcion.Text = "0.00"
        Me.txtPercepcion.Visible = False
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Red
        Me.txtTotal.Location = New System.Drawing.Point(319, 483)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotal.Size = New System.Drawing.Size(96, 25)
        Me.txtTotal.TabIndex = 16
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.Visible = False
        '
        'txtIVA
        '
        Me.txtIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIVA.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA.ForeColor = System.Drawing.Color.Navy
        Me.txtIVA.Location = New System.Drawing.Point(523, 483)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtIVA.Size = New System.Drawing.Size(96, 25)
        Me.txtIVA.TabIndex = 15
        Me.txtIVA.Text = "0.00"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubTotal.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.ForeColor = System.Drawing.Color.Navy
        Me.txtSubTotal.Location = New System.Drawing.Point(418, 483)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSubTotal.Size = New System.Drawing.Size(96, 25)
        Me.txtSubTotal.TabIndex = 14
        Me.txtSubTotal.Text = "0.00"
        '
        'btnGuardarDetalle
        '
        Me.btnGuardarDetalle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarDetalle.Image = CType(resources.GetObject("btnGuardarDetalle.Image"), System.Drawing.Image)
        Me.btnGuardarDetalle.Location = New System.Drawing.Point(622, 251)
        Me.btnGuardarDetalle.Name = "btnGuardarDetalle"
        Me.btnGuardarDetalle.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardarDetalle.TabIndex = 9
        Me.btnGuardarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnGuardarDetalle, "Hecha una orden de venta, guarda los detalles de la orden")
        Me.btnGuardarDetalle.UseVisualStyleBackColor = True
        '
        'cmbUNIDAD_MEDIDA
        '
        Me.cmbUNIDAD_MEDIDA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUNIDAD_MEDIDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUNIDAD_MEDIDA.DropDownWidth = 150
        Me.cmbUNIDAD_MEDIDA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUNIDAD_MEDIDA.ForeColor = System.Drawing.Color.Navy
        Me.cmbUNIDAD_MEDIDA.FormattingEnabled = True
        Me.cmbUNIDAD_MEDIDA.Items.AddRange(New Object() {"Crédito 30 días", "Crédito 60 días", "Crédito 90 días"})
        Me.cmbUNIDAD_MEDIDA.Location = New System.Drawing.Point(380, 251)
        Me.cmbUNIDAD_MEDIDA.MaxDropDownItems = 10
        Me.cmbUNIDAD_MEDIDA.Name = "cmbUNIDAD_MEDIDA"
        Me.cmbUNIDAD_MEDIDA.Size = New System.Drawing.Size(107, 24)
        Me.cmbUNIDAD_MEDIDA.TabIndex = 5
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.SystemColors.Window
        Me.txtPrecio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.ForeColor = System.Drawing.Color.Navy
        Me.txtPrecio.Location = New System.Drawing.Point(551, 252)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(67, 22)
        Me.txtPrecio.TabIndex = 8
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.SystemColors.Window
        Me.txtCantidad.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.Navy
        Me.txtCantidad.Location = New System.Drawing.Point(485, 252)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(67, 22)
        Me.txtCantidad.TabIndex = 6
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.ForeColor = System.Drawing.Color.Navy
        Me.txtDescripcion.Location = New System.Drawing.Point(160, 252)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(221, 22)
        Me.txtDescripcion.TabIndex = 4
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.Location = New System.Drawing.Point(136, 251)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto.TabIndex = 3
        Me.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnBuscarProducto, "Abre una ventana nueva para buscar un producto")
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Teal
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Yellow
        Me.Label14.Location = New System.Drawing.Point(32, 230)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(663, 20)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = " Producto/Servicio                                  Descripción                  " & _
            "            Unidad Medida         Cantidad    Precio Unit.     Acciones"
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.SystemColors.Window
        Me.txtProducto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.Navy
        Me.txtProducto.Location = New System.Drawing.Point(32, 252)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(104, 22)
        Me.txtProducto.TabIndex = 2
        Me.txtProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvDetalleFact
        '
        Me.dgvDetalleFact.AllowUserToAddRows = False
        Me.dgvDetalleFact.AllowUserToDeleteRows = False
        Me.dgvDetalleFact.AllowUserToResizeColumns = False
        Me.dgvDetalleFact.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvDetalleFact.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetalleFact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDetalleFact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleFact.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodProd, Me.nomProd, Me.UnidadMedida, Me.CantidadProd, Me.PU, Me.VT, Me.LineaDetalle, Me.UM})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalleFact.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDetalleFact.Location = New System.Drawing.Point(2, 279)
        Me.dgvDetalleFact.Name = "dgvDetalleFact"
        Me.dgvDetalleFact.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleFact.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDetalleFact.RowHeadersWidth = 30
        Me.dgvDetalleFact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleFact.Size = New System.Drawing.Size(721, 181)
        Me.dgvDetalleFact.TabIndex = 12
        '
        'CodProd
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CodProd.DefaultCellStyle = DataGridViewCellStyle2
        Me.CodProd.HeaderText = "Código Producto"
        Me.CodProd.Name = "CodProd"
        Me.CodProd.ReadOnly = True
        Me.CodProd.Width = 60
        '
        'nomProd
        '
        Me.nomProd.HeaderText = "Nombre Producto"
        Me.nomProd.Name = "nomProd"
        Me.nomProd.ReadOnly = True
        Me.nomProd.Width = 200
        '
        'UnidadMedida
        '
        Me.UnidadMedida.HeaderText = "Unidad Medida"
        Me.UnidadMedida.Name = "UnidadMedida"
        Me.UnidadMedida.ReadOnly = True
        Me.UnidadMedida.Width = 150
        '
        'CantidadProd
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantidadProd.DefaultCellStyle = DataGridViewCellStyle3
        Me.CantidadProd.HeaderText = "Cantidad"
        Me.CantidadProd.Name = "CantidadProd"
        Me.CantidadProd.ReadOnly = True
        Me.CantidadProd.Width = 70
        '
        'PU
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.PU.DefaultCellStyle = DataGridViewCellStyle4
        Me.PU.HeaderText = "Precio Unitario"
        Me.PU.Name = "PU"
        Me.PU.ReadOnly = True
        Me.PU.Width = 70
        '
        'VT
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.VT.DefaultCellStyle = DataGridViewCellStyle5
        Me.VT.HeaderText = "Venta Total"
        Me.VT.Name = "VT"
        Me.VT.ReadOnly = True
        Me.VT.Width = 70
        '
        'LineaDetalle
        '
        Me.LineaDetalle.HeaderText = "Línea"
        Me.LineaDetalle.Name = "LineaDetalle"
        Me.LineaDetalle.ReadOnly = True
        Me.LineaDetalle.Visible = False
        Me.LineaDetalle.Width = 20
        '
        'UM
        '
        Me.UM.HeaderText = "UM"
        Me.UM.Name = "UM"
        Me.UM.ReadOnly = True
        Me.UM.Visible = False
        Me.UM.Width = 20
        '
        'gbDC
        '
        Me.gbDC.Controls.Add(Me.txtSaldoPend)
        Me.gbDC.Controls.Add(Me.Label5)
        Me.gbDC.Controls.Add(Me.Label1)
        Me.gbDC.Controls.Add(Me.txtValRemesa)
        Me.gbDC.Controls.Add(Me.chkSocio)
        Me.gbDC.Controls.Add(Me.Label62)
        Me.gbDC.Controls.Add(Me.Label63)
        Me.gbDC.Controls.Add(Me.btnActualizarCliente)
        Me.gbDC.Controls.Add(Me.txtNoRemesa)
        Me.gbDC.Controls.Add(Me.txtNitCliente)
        Me.gbDC.Controls.Add(Me.cmbBancos)
        Me.gbDC.Controls.Add(Me.txtDuiCliente)
        Me.gbDC.Controls.Add(Me.txtConcepto)
        Me.gbDC.Controls.Add(Me.Label21)
        Me.gbDC.Controls.Add(Me.txtGiro)
        Me.gbDC.Controls.Add(Me.txtFaxCliente)
        Me.gbDC.Controls.Add(Me.Label20)
        Me.gbDC.Controls.Add(Me.cmbTIPO_CLIENTE)
        Me.gbDC.Controls.Add(Me.Label19)
        Me.gbDC.Controls.Add(Me.txtDireccionCliente)
        Me.gbDC.Controls.Add(Me.chkExento)
        Me.gbDC.Controls.Add(Me.Label18)
        Me.gbDC.Controls.Add(Me.cmbCONTRIBUYENTE)
        Me.gbDC.Controls.Add(Me.Label16)
        Me.gbDC.Controls.Add(Me.Label12)
        Me.gbDC.Controls.Add(Me.txtTelCliente)
        Me.gbDC.Controls.Add(Me.Label11)
        Me.gbDC.Controls.Add(Me.txtNombreFactura)
        Me.gbDC.Controls.Add(Me.Label10)
        Me.gbDC.Controls.Add(Me.txtRegFiscal)
        Me.gbDC.Controls.Add(Me.Label7)
        Me.gbDC.Controls.Add(Me.Label6)
        Me.gbDC.Controls.Add(Me.cmbFORMA_PAGO)
        Me.gbDC.Controls.Add(Me.cmbTIPO_DOCUMENTO)
        Me.gbDC.Controls.Add(Me.Label4)
        Me.gbDC.Controls.Add(Me.Label3)
        Me.gbDC.Controls.Add(Me.Label9)
        Me.gbDC.Controls.Add(Me.txtCliente)
        Me.gbDC.Controls.Add(Me.cmbCONDICION_PAGO)
        Me.gbDC.Controls.Add(Me.btnBuscarCliente)
        Me.gbDC.Controls.Add(Me.txtNombreCliente)
        Me.gbDC.Controls.Add(Me.Label2)
        Me.gbDC.Controls.Add(Me.Label8)
        Me.gbDC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDC.ForeColor = System.Drawing.Color.Navy
        Me.gbDC.Location = New System.Drawing.Point(2, 1)
        Me.gbDC.Name = "gbDC"
        Me.gbDC.Size = New System.Drawing.Size(721, 227)
        Me.gbDC.TabIndex = 0
        Me.gbDC.TabStop = False
        Me.gbDC.Text = "Datos Cliente"
        '
        'txtSaldoPend
        '
        Me.txtSaldoPend.BackColor = System.Drawing.Color.White
        Me.txtSaldoPend.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoPend.ForeColor = System.Drawing.Color.Navy
        Me.txtSaldoPend.Location = New System.Drawing.Point(560, 117)
        Me.txtSaldoPend.Name = "txtSaldoPend"
        Me.txtSaldoPend.ReadOnly = True
        Me.txtSaldoPend.Size = New System.Drawing.Size(76, 22)
        Me.txtSaldoPend.TabIndex = 112
        Me.txtSaldoPend.Text = "0.00"
        Me.txtSaldoPend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSaldoPend.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(471, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 16)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "Saldo pendiente :"
        Me.Label5.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(215, 195)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Valor Remesa :"
        '
        'txtValRemesa
        '
        Me.txtValRemesa.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValRemesa.Location = New System.Drawing.Point(299, 192)
        Me.txtValRemesa.Name = "txtValRemesa"
        Me.txtValRemesa.Size = New System.Drawing.Size(95, 22)
        Me.txtValRemesa.TabIndex = 105
        Me.txtValRemesa.Text = "0.00"
        Me.txtValRemesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkSocio
        '
        Me.chkSocio.AutoSize = True
        Me.chkSocio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSocio.ForeColor = System.Drawing.Color.Red
        Me.chkSocio.Location = New System.Drawing.Point(175, 18)
        Me.chkSocio.Name = "chkSocio"
        Me.chkSocio.Size = New System.Drawing.Size(58, 20)
        Me.chkSocio.TabIndex = 37
        Me.chkSocio.Text = "Socio"
        Me.chkSocio.UseVisualStyleBackColor = True
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.Black
        Me.Label62.Location = New System.Drawing.Point(452, 169)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(49, 16)
        Me.Label62.TabIndex = 108
        Me.Label62.Text = "Bancos :"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.Black
        Me.Label63.Location = New System.Drawing.Point(11, 195)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(63, 16)
        Me.Label63.TabIndex = 105
        Me.Label63.Text = "# Remesa :"
        '
        'btnActualizarCliente
        '
        Me.btnActualizarCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnActualizarCliente.Image = CType(resources.GetObject("btnActualizarCliente.Image"), System.Drawing.Image)
        Me.btnActualizarCliente.Location = New System.Drawing.Point(257, 15)
        Me.btnActualizarCliente.Name = "btnActualizarCliente"
        Me.btnActualizarCliente.Size = New System.Drawing.Size(24, 24)
        Me.btnActualizarCliente.TabIndex = 1
        Me.btnActualizarCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnActualizarCliente, "Actualiza los cambios del cliente, no guarda ninguno nuevo")
        Me.btnActualizarCliente.UseVisualStyleBackColor = True
        Me.btnActualizarCliente.Visible = False
        '
        'txtNoRemesa
        '
        Me.txtNoRemesa.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoRemesa.Location = New System.Drawing.Point(76, 192)
        Me.txtNoRemesa.MaxLength = 50
        Me.txtNoRemesa.Name = "txtNoRemesa"
        Me.txtNoRemesa.Size = New System.Drawing.Size(110, 22)
        Me.txtNoRemesa.TabIndex = 104
        '
        'txtNitCliente
        '
        Me.txtNitCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtNitCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtNitCliente.Location = New System.Drawing.Point(76, 141)
        Me.txtNitCliente.Mask = "0000-000000-000-0"
        Me.txtNitCliente.Name = "txtNitCliente"
        Me.txtNitCliente.Size = New System.Drawing.Size(158, 22)
        Me.txtNitCliente.TabIndex = 6
        '
        'cmbBancos
        '
        Me.cmbBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBancos.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBancos.FormattingEnabled = True
        Me.cmbBancos.Location = New System.Drawing.Point(503, 165)
        Me.cmbBancos.Name = "cmbBancos"
        Me.cmbBancos.Size = New System.Drawing.Size(201, 23)
        Me.cmbBancos.TabIndex = 106
        '
        'txtDuiCliente
        '
        Me.txtDuiCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtDuiCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtDuiCliente.Location = New System.Drawing.Point(76, 116)
        Me.txtDuiCliente.Mask = "00000000-0"
        Me.txtDuiCliente.Name = "txtDuiCliente"
        Me.txtDuiCliente.Size = New System.Drawing.Size(158, 22)
        Me.txtDuiCliente.TabIndex = 5
        '
        'txtConcepto
        '
        Me.txtConcepto.BackColor = System.Drawing.SystemColors.Window
        Me.txtConcepto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConcepto.ForeColor = System.Drawing.Color.Navy
        Me.txtConcepto.Location = New System.Drawing.Point(59, 94)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConcepto.Size = New System.Drawing.Size(14, 32)
        Me.txtConcepto.TabIndex = 16
        Me.txtConcepto.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(234, 144)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(34, 16)
        Me.Label21.TabIndex = 30
        Me.Label21.Text = "Giro :"
        '
        'txtGiro
        '
        Me.txtGiro.BackColor = System.Drawing.SystemColors.Window
        Me.txtGiro.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGiro.ForeColor = System.Drawing.Color.Navy
        Me.txtGiro.Location = New System.Drawing.Point(313, 141)
        Me.txtGiro.Name = "txtGiro"
        Me.txtGiro.Size = New System.Drawing.Size(402, 22)
        Me.txtGiro.TabIndex = 10
        '
        'txtFaxCliente
        '
        Me.txtFaxCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtFaxCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaxCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtFaxCliente.Location = New System.Drawing.Point(76, 91)
        Me.txtFaxCliente.Name = "txtFaxCliente"
        Me.txtFaxCliente.Size = New System.Drawing.Size(158, 22)
        Me.txtFaxCliente.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(1, 94)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(33, 16)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Fax :"
        '
        'cmbTIPO_CLIENTE
        '
        Me.cmbTIPO_CLIENTE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_CLIENTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_CLIENTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_CLIENTE.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_CLIENTE.FormattingEnabled = True
        Me.cmbTIPO_CLIENTE.Items.AddRange(New Object() {"Persona Natural", "Jurídica"})
        Me.cmbTIPO_CLIENTE.Location = New System.Drawing.Point(313, 66)
        Me.cmbTIPO_CLIENTE.Name = "cmbTIPO_CLIENTE"
        Me.cmbTIPO_CLIENTE.Size = New System.Drawing.Size(158, 24)
        Me.cmbTIPO_CLIENTE.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(234, 69)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 16)
        Me.Label19.TabIndex = 27
        Me.Label19.Text = "Tipo Cliente :"
        '
        'txtDireccionCliente
        '
        Me.txtDireccionCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtDireccionCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccionCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtDireccionCliente.Location = New System.Drawing.Point(76, 41)
        Me.txtDireccionCliente.Name = "txtDireccionCliente"
        Me.txtDireccionCliente.Size = New System.Drawing.Size(639, 22)
        Me.txtDireccionCliente.TabIndex = 2
        '
        'chkExento
        '
        Me.chkExento.AutoSize = True
        Me.chkExento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExento.ForeColor = System.Drawing.Color.Red
        Me.chkExento.Location = New System.Drawing.Point(640, 15)
        Me.chkExento.Name = "chkExento"
        Me.chkExento.Size = New System.Drawing.Size(75, 20)
        Me.chkExento.TabIndex = 17
        Me.chkExento.Text = "Es Exento"
        Me.chkExento.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(1, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 16)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Dirección :"
        '
        'cmbCONTRIBUYENTE
        '
        Me.cmbCONTRIBUYENTE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCONTRIBUYENTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCONTRIBUYENTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCONTRIBUYENTE.ForeColor = System.Drawing.Color.Navy
        Me.cmbCONTRIBUYENTE.FormattingEnabled = True
        Me.cmbCONTRIBUYENTE.Items.AddRange(New Object() {"Pequeño", "Mediano", "Grande"})
        Me.cmbCONTRIBUYENTE.Location = New System.Drawing.Point(313, 91)
        Me.cmbCONTRIBUYENTE.Name = "cmbCONTRIBUYENTE"
        Me.cmbCONTRIBUYENTE.Size = New System.Drawing.Size(158, 24)
        Me.cmbCONTRIBUYENTE.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(234, 94)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 16)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Contribuyente :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(1, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 16)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Concepto :"
        Me.Label12.Visible = False
        '
        'txtTelCliente
        '
        Me.txtTelCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtTelCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtTelCliente.Location = New System.Drawing.Point(76, 66)
        Me.txtTelCliente.Name = "txtTelCliente"
        Me.txtTelCliente.Size = New System.Drawing.Size(158, 22)
        Me.txtTelCliente.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(1, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 16)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Teléfono :"
        '
        'txtNombreFactura
        '
        Me.txtNombreFactura.BackColor = System.Drawing.SystemColors.Window
        Me.txtNombreFactura.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreFactura.ForeColor = System.Drawing.Color.Navy
        Me.txtNombreFactura.Location = New System.Drawing.Point(76, 166)
        Me.txtNombreFactura.Name = "txtNombreFactura"
        Me.txtNombreFactura.Size = New System.Drawing.Size(370, 22)
        Me.txtNombreFactura.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(1, 167)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 16)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Nombre Fact. :"
        '
        'txtRegFiscal
        '
        Me.txtRegFiscal.BackColor = System.Drawing.SystemColors.Window
        Me.txtRegFiscal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegFiscal.ForeColor = System.Drawing.Color.Navy
        Me.txtRegFiscal.Location = New System.Drawing.Point(313, 116)
        Me.txtRegFiscal.Name = "txtRegFiscal"
        Me.txtRegFiscal.Size = New System.Drawing.Size(158, 22)
        Me.txtRegFiscal.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(234, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 16)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Registro Fiscal :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(1, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 16)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "DUI :"
        '
        'cmbFORMA_PAGO
        '
        Me.cmbFORMA_PAGO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFORMA_PAGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFORMA_PAGO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFORMA_PAGO.ForeColor = System.Drawing.Color.Navy
        Me.cmbFORMA_PAGO.FormattingEnabled = True
        Me.cmbFORMA_PAGO.Items.AddRange(New Object() {"Contado", "Crédito", "Cheque", "Tarjeta de Crédito"})
        Me.cmbFORMA_PAGO.Location = New System.Drawing.Point(557, 91)
        Me.cmbFORMA_PAGO.Name = "cmbFORMA_PAGO"
        Me.cmbFORMA_PAGO.Size = New System.Drawing.Size(158, 24)
        Me.cmbFORMA_PAGO.TabIndex = 13
        '
        'cmbTIPO_DOCUMENTO
        '
        Me.cmbTIPO_DOCUMENTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_DOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_DOCUMENTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_DOCUMENTO.FormattingEnabled = True
        Me.cmbTIPO_DOCUMENTO.Items.AddRange(New Object() {"Consumidor Final", "Crédito Fiscal"})
        Me.cmbTIPO_DOCUMENTO.Location = New System.Drawing.Point(557, 66)
        Me.cmbTIPO_DOCUMENTO.Name = "cmbTIPO_DOCUMENTO"
        Me.cmbTIPO_DOCUMENTO.Size = New System.Drawing.Size(158, 24)
        Me.cmbTIPO_DOCUMENTO.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(471, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Tipo Documento :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(471, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Forma Pago :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(1, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 16)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "NIT :"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.Color.Red
        Me.txtCliente.Location = New System.Drawing.Point(76, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(93, 22)
        Me.txtCliente.TabIndex = 35
        '
        'cmbCONDICION_PAGO
        '
        Me.cmbCONDICION_PAGO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCONDICION_PAGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCONDICION_PAGO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCONDICION_PAGO.ForeColor = System.Drawing.Color.Navy
        Me.cmbCONDICION_PAGO.FormattingEnabled = True
        Me.cmbCONDICION_PAGO.Items.AddRange(New Object() {"Crédito 30 días", "Crédito 60 días", "Crédito 90 días"})
        Me.cmbCONDICION_PAGO.Location = New System.Drawing.Point(557, 116)
        Me.cmbCONDICION_PAGO.Name = "cmbCONDICION_PAGO"
        Me.cmbCONDICION_PAGO.Size = New System.Drawing.Size(158, 24)
        Me.cmbCONDICION_PAGO.TabIndex = 14
        Me.cmbCONDICION_PAGO.Visible = False
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(234, 15)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarCliente.TabIndex = 0
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnBuscarCliente, "Abre una ventana nueva para buscar un Cliente")
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtNombreCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtNombreCliente.Location = New System.Drawing.Point(281, 16)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombreCliente.Size = New System.Drawing.Size(353, 22)
        Me.txtNombreCliente.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(471, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Condición Pago :"
        Me.Label2.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(1, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 16)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Cliente :"
        '
        'chkModif
        '
        Me.chkModif.AutoSize = True
        Me.chkModif.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkModif.ForeColor = System.Drawing.Color.Red
        Me.chkModif.Location = New System.Drawing.Point(15, 254)
        Me.chkModif.Name = "chkModif"
        Me.chkModif.Size = New System.Drawing.Size(63, 20)
        Me.chkModif.TabIndex = 18
        Me.chkModif.Text = "Modify"
        Me.chkModif.UseVisualStyleBackColor = True
        Me.chkModif.Visible = False
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnGenerar.ForeColor = System.Drawing.Color.Navy
        Me.btnGenerar.Image = Global.ASTAS.My.Resources.Resources.filesave
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(564, 46)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(84, 25)
        Me.btnGenerar.TabIndex = 2
        Me.btnGenerar.Text = "&Guardar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGenerar, "Genera una factura con los datos de la orden de venta con sus detalles respectivo" & _
                "s")
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(657, 19)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtLinea
        '
        Me.txtLinea.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtLinea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtLinea.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLinea.ForeColor = System.Drawing.Color.Red
        Me.txtLinea.Location = New System.Drawing.Point(687, 19)
        Me.txtLinea.Name = "txtLinea"
        Me.txtLinea.Size = New System.Drawing.Size(34, 24)
        Me.txtLinea.TabIndex = 9
        Me.txtLinea.Text = "0"
        Me.txtLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.txtLinea.Visible = False
        '
        'gbGral
        '
        Me.gbGral.Controls.Add(Me.btnElimFact)
        Me.gbGral.Controls.Add(Me.bntImprimir)
        Me.gbGral.Controls.Add(Me.txtNumFact)
        Me.gbGral.Controls.Add(Me.txtNumDocumentoOV1)
        Me.gbGral.Controls.Add(Me.btnNuevo)
        Me.gbGral.Controls.Add(Me.lblFactSiNo)
        Me.gbGral.Controls.Add(Me.Label15)
        Me.gbGral.Controls.Add(Me.cmbBODEGA)
        Me.gbGral.Controls.Add(Me.dpFECHA_OV)
        Me.gbGral.Controls.Add(Me.Label13)
        Me.gbGral.Controls.Add(Me.txtLinea)
        Me.gbGral.Controls.Add(Me.btnGenerar)
        Me.gbGral.Controls.Add(Me.Label59)
        Me.gbGral.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGral.ForeColor = System.Drawing.Color.Navy
        Me.gbGral.Location = New System.Drawing.Point(2, -2)
        Me.gbGral.Name = "gbGral"
        Me.gbGral.Size = New System.Drawing.Size(733, 78)
        Me.gbGral.TabIndex = 0
        Me.gbGral.TabStop = False
        Me.gbGral.Text = "Datos Generales"
        '
        'btnElimFact
        '
        Me.btnElimFact.Image = Global.ASTAS.My.Resources.Resources.editdelete
        Me.btnElimFact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnElimFact.Location = New System.Drawing.Point(482, 47)
        Me.btnElimFact.Name = "btnElimFact"
        Me.btnElimFact.Size = New System.Drawing.Size(79, 25)
        Me.btnElimFact.TabIndex = 111
        Me.btnElimFact.Text = "Eliminar"
        Me.btnElimFact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnElimFact.UseVisualStyleBackColor = True
        '
        'bntImprimir
        '
        Me.bntImprimir.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.bntImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bntImprimir.Location = New System.Drawing.Point(650, 46)
        Me.bntImprimir.Name = "bntImprimir"
        Me.bntImprimir.Size = New System.Drawing.Size(79, 25)
        Me.bntImprimir.TabIndex = 110
        Me.bntImprimir.Text = "Imprimir"
        Me.bntImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bntImprimir.UseVisualStyleBackColor = True
        '
        'txtNumFact
        '
        Me.txtNumFact.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtNumFact.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumFact.Location = New System.Drawing.Point(563, 17)
        Me.txtNumFact.Name = "txtNumFact"
        Me.txtNumFact.Size = New System.Drawing.Size(92, 26)
        Me.txtNumFact.TabIndex = 14
        '
        'txtNumDocumentoOV1
        '
        Me.txtNumDocumentoOV1.BackColor = System.Drawing.Color.Blue
        Me.txtNumDocumentoOV1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtNumDocumentoOV1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDocumentoOV1.ForeColor = System.Drawing.Color.Yellow
        Me.txtNumDocumentoOV1.Location = New System.Drawing.Point(586, 18)
        Me.txtNumDocumentoOV1.Name = "txtNumDocumentoOV1"
        Me.txtNumDocumentoOV1.Size = New System.Drawing.Size(62, 24)
        Me.txtNumDocumentoOV1.TabIndex = 13
        Me.txtNumDocumentoOV1.Text = "0"
        Me.txtNumDocumentoOV1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFactSiNo
        '
        Me.lblFactSiNo.BackColor = System.Drawing.Color.Blue
        Me.lblFactSiNo.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactSiNo.ForeColor = System.Drawing.Color.Yellow
        Me.lblFactSiNo.Location = New System.Drawing.Point(58, 46)
        Me.lblFactSiNo.Name = "lblFactSiNo"
        Me.lblFactSiNo.Size = New System.Drawing.Size(419, 24)
        Me.lblFactSiNo.TabIndex = 9
        Me.lblFactSiNo.Text = "MENSAJE"
        Me.lblFactSiNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lblFactSiNo, "Muestra un mensaje indicando si la orden de venta ya fue procesada o no")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(339, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 16)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Fecha:"
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.DropDownWidth = 272
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Items.AddRange(New Object() {"ASTAS - Asociación de Trabajadores de Avícola Salvadoreña"})
        Me.cmbBODEGA.Location = New System.Drawing.Point(58, 19)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(272, 24)
        Me.cmbBODEGA.TabIndex = 1
        '
        'dpFECHA_OV
        '
        Me.dpFECHA_OV.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_OV.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_OV.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_OV.Location = New System.Drawing.Point(384, 19)
        Me.dpFECHA_OV.Name = "dpFECHA_OV"
        Me.dpFECHA_OV.Size = New System.Drawing.Size(111, 22)
        Me.dpFECHA_OV.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(1, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Bodega :"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.Navy
        Me.Label59.Location = New System.Drawing.Point(495, 20)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(66, 20)
        Me.Label59.TabIndex = 13
        Me.Label59.Text = "N° FACT:"
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Información"
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(229, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 46
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MaskedTextBox1
        '
        Me.MaskedTextBox1.Location = New System.Drawing.Point(100, 131)
        Me.MaskedTextBox1.Mask = "0000-000000-000-0"
        Me.MaskedTextBox1.Name = "MaskedTextBox1"
        Me.MaskedTextBox1.Size = New System.Drawing.Size(104, 20)
        Me.MaskedTextBox1.TabIndex = 44
        '
        'MaskedTextBox2
        '
        Me.MaskedTextBox2.Location = New System.Drawing.Point(100, 108)
        Me.MaskedTextBox2.Mask = "00000000-0"
        Me.MaskedTextBox2.Name = "MaskedTextBox2"
        Me.MaskedTextBox2.Size = New System.Drawing.Size(104, 20)
        Me.MaskedTextBox2.TabIndex = 43
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Navy
        Me.TextBox1.Location = New System.Drawing.Point(100, 200)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(592, 32)
        Me.TextBox1.TabIndex = 18
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(12, 157)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 16)
        Me.Label22.TabIndex = 28
        Me.Label22.Text = "Giro :"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Navy
        Me.TextBox2.Location = New System.Drawing.Point(100, 154)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(344, 22)
        Me.TextBox2.TabIndex = 16
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Navy
        Me.TextBox3.Location = New System.Drawing.Point(100, 85)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(104, 22)
        Me.TextBox3.TabIndex = 5
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(12, 88)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(33, 16)
        Me.Label23.TabIndex = 25
        Me.Label23.Text = "Fax :"
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.Navy
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Persona Natural", "Jurídica"})
        Me.ComboBox1.Location = New System.Drawing.Point(299, 67)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(145, 24)
        Me.ComboBox1.TabIndex = 8
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(210, 70)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 16)
        Me.Label25.TabIndex = 31
        Me.Label25.Text = "Tipo Cliente :"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.Navy
        Me.TextBox4.Location = New System.Drawing.Point(100, 39)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(591, 22)
        Me.TextBox4.TabIndex = 3
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBox1.Location = New System.Drawing.Point(457, 155)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(75, 20)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Es Exento"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(12, 42)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(58, 16)
        Me.Label26.TabIndex = 23
        Me.Label26.Text = "Dirección :"
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.ForeColor = System.Drawing.Color.Navy
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Pequeño", "Mediano", "Grande"})
        Me.ComboBox2.Location = New System.Drawing.Point(299, 97)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(145, 24)
        Me.ComboBox2.TabIndex = 9
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(210, 100)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(80, 16)
        Me.Label27.TabIndex = 32
        Me.Label27.Text = "Contribuyente :"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.Red
        Me.CheckBox2.Location = New System.Drawing.Point(550, 155)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(112, 20)
        Me.CheckBox2.TabIndex = 19
        Me.CheckBox2.Text = "Imprimir Concepto"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(12, 203)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(59, 16)
        Me.Label28.TabIndex = 30
        Me.Label28.Text = "Concepto :"
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.ForeColor = System.Drawing.Color.Navy
        Me.TextBox5.Location = New System.Drawing.Point(100, 62)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(104, 22)
        Me.TextBox5.TabIndex = 4
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(12, 65)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(55, 16)
        Me.Label29.TabIndex = 24
        Me.Label29.Text = "Teléfono :"
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.ForeColor = System.Drawing.Color.Navy
        Me.TextBox6.Location = New System.Drawing.Point(100, 177)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(592, 22)
        Me.TextBox6.TabIndex = 17
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(12, 180)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(91, 16)
        Me.Label30.TabIndex = 29
        Me.Label30.Text = "Nombre Factura :"
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.ForeColor = System.Drawing.Color.Navy
        Me.TextBox7.Location = New System.Drawing.Point(299, 127)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(145, 22)
        Me.TextBox7.TabIndex = 10
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(210, 130)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(83, 16)
        Me.Label31.TabIndex = 33
        Me.Label31.Text = "Registro Fiscal :"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(12, 111)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(33, 16)
        Me.Label32.TabIndex = 26
        Me.Label32.Text = "DUI :"
        '
        'ComboBox3
        '
        Me.ComboBox3.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.ForeColor = System.Drawing.Color.Navy
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"Contado", "Crédito", "Cheque", "Tarjeta de Crédito"})
        Me.ComboBox3.Location = New System.Drawing.Point(546, 97)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(145, 24)
        Me.ComboBox3.TabIndex = 13
        '
        'ComboBox4
        '
        Me.ComboBox4.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.ForeColor = System.Drawing.Color.Navy
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"Consumidor Final", "Crédito Fiscal"})
        Me.ComboBox4.Location = New System.Drawing.Point(546, 67)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(145, 24)
        Me.ComboBox4.TabIndex = 12
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(450, 70)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(91, 16)
        Me.Label33.TabIndex = 34
        Me.Label33.Text = "Tipo Documento :"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(450, 100)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(73, 16)
        Me.Label34.TabIndex = 35
        Me.Label34.Text = "Forma Pago :"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(12, 134)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(32, 16)
        Me.Label35.TabIndex = 27
        Me.Label35.Text = "NIT :"
        '
        'TextBox8
        '
        Me.TextBox8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.ForeColor = System.Drawing.Color.Red
        Me.TextBox8.Location = New System.Drawing.Point(100, 16)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(104, 22)
        Me.TextBox8.TabIndex = 40
        '
        'ComboBox5
        '
        Me.ComboBox5.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox5.ForeColor = System.Drawing.Color.Navy
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Items.AddRange(New Object() {"Crédito 30 días", "Crédito 60 días", "Crédito 90 días"})
        Me.ComboBox5.Location = New System.Drawing.Point(546, 127)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(145, 24)
        Me.ComboBox5.TabIndex = 14
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(204, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(25, 24)
        Me.Button2.TabIndex = 1
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox9
        '
        Me.TextBox9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.ForeColor = System.Drawing.Color.Navy
        Me.TextBox9.Location = New System.Drawing.Point(255, 16)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox9.Size = New System.Drawing.Size(436, 22)
        Me.TextBox9.TabIndex = 41
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(450, 130)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(89, 16)
        Me.Label36.TabIndex = 36
        Me.Label36.Text = "Condición Pago :"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(12, 19)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(46, 16)
        Me.Label37.TabIndex = 22
        Me.Label37.Text = "Cliente :"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.Black
        Me.Label61.Location = New System.Drawing.Point(428, 304)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(81, 16)
        Me.Label61.TabIndex = 109
        Me.Label61.Text = "Cuenta Banco :"
        '
        'cmbCtasBanco
        '
        Me.cmbCtasBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCtasBanco.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCtasBanco.FormattingEnabled = True
        Me.cmbCtasBanco.Location = New System.Drawing.Point(511, 301)
        Me.cmbCtasBanco.Name = "cmbCtasBanco"
        Me.cmbCtasBanco.Size = New System.Drawing.Size(201, 22)
        Me.cmbCtasBanco.TabIndex = 107
        '
        'Contabilidad_CuentaxCobrar_Facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 630)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.cmbCtasBanco)
        Me.Controls.Add(Me.gbGral)
        Me.Controls.Add(Me.tbContFact)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_CuentaxCobrar_Facturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturación Libre"
        Me.tbContFact.ResumeLayout(False)
        Me.tbDatos.ResumeLayout(False)
        Me.tbDatos.PerformLayout()
        CType(Me.dgvDetalleFact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDC.ResumeLayout(False)
        Me.gbDC.PerformLayout()
        Me.gbGral.ResumeLayout(False)
        Me.gbGral.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbContFact As System.Windows.Forms.TabControl
    Friend WithEvents tbDatos As System.Windows.Forms.TabPage
    Friend WithEvents btnGuardarDetalle As System.Windows.Forms.Button
    Friend WithEvents cmbUNIDAD_MEDIDA As System.Windows.Forms.ComboBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalleFact As System.Windows.Forms.DataGridView
    Friend WithEvents gbDC As System.Windows.Forms.GroupBox
    Friend WithEvents cmbCONTRIBUYENTE As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtLinea As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents chkModif As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTelCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNombreFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRegFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbFORMA_PAGO As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTIPO_DOCUMENTO As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents cmbCONDICION_PAGO As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkExento As System.Windows.Forms.CheckBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotalFact As System.Windows.Forms.TextBox
    Friend WithEvents txtPercepcion As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccionCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbTIPO_CLIENTE As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtFaxCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtGiro As System.Windows.Forms.TextBox
    Friend WithEvents txtNitCliente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDuiCliente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents gbGral As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents dpFECHA_OV As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblFactSiNo As System.Windows.Forms.Label
    Friend WithEvents btnActualizarCliente As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MaskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents MaskedTextBox2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents txtLibras As System.Windows.Forms.TextBox
    Friend WithEvents btnEliminarDetFact As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarDetalle As System.Windows.Forms.Button
    Friend WithEvents lblMsjMaxLineas As System.Windows.Forms.Label
    Friend WithEvents lblMaxLineas As System.Windows.Forms.Label
    Friend WithEvents txtNumDocumentoOV1 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents txtNumFact As System.Windows.Forms.TextBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents cmbCtasBanco As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBancos As System.Windows.Forms.ComboBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents txtNoRemesa As System.Windows.Forms.TextBox
    Friend WithEvents bntImprimir As System.Windows.Forms.Button
    Friend WithEvents CodProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nomProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnidadMedida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineaDetalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkSocio As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtValRemesa As System.Windows.Forms.TextBox
    Friend WithEvents btnElimFact As System.Windows.Forms.Button
    Friend WithEvents txtSaldoPend As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
