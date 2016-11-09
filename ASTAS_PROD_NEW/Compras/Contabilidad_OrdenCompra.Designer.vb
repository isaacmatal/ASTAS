<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_OrdenCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_OrdenCompra))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gbGral = New System.Windows.Forms.GroupBox
        Me.txtOC = New System.Windows.Forms.TextBox
        Me.btnFinRecepción = New System.Windows.Forms.Button
        Me.btnAnular = New System.Windows.Forms.Button
        Me.LblProcesada = New System.Windows.Forms.Label
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnLimpiarOC = New System.Windows.Forms.Button
        Me.dpFECHA_OC = New System.Windows.Forms.DateTimePicker
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.lblMensaje = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnBuscarOC = New System.Windows.Forms.Button
        Me.btnGuardarEncabezado = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabDatos = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtOBSERVACIONES = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.dgvDetalleOC = New System.Windows.Forms.DataGridView
        Me.Prod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.numProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescUM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CantidadProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descuento = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConIVA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miMenu_Eliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtSubTotal = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.txtExento = New System.Windows.Forms.TextBox
        Me.TxtCESC = New System.Windows.Forms.TextBox
        Me.txtPercepcion = New System.Windows.Forms.TextBox
        Me.txtIVA = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtTotalFact = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.dgvProductos = New System.Windows.Forms.DataGridView
        Me.TxtNombreB = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblDescuento = New System.Windows.Forms.Label
        Me.lblPorcentajeDescuento = New System.Windows.Forms.Label
        Me.lblCostoTotal = New System.Windows.Forms.Label
        Me.lblStock = New System.Windows.Forms.Label
        Me.lblCostoUnit = New System.Windows.Forms.Label
        Me.lblCantidad = New System.Windows.Forms.Label
        Me.lblUnidadMedida = New System.Windows.Forms.Label
        Me.lblDescripcion = New System.Windows.Forms.Label
        Me.lblProducto = New System.Windows.Forms.Label
        Me.chkBono = New System.Windows.Forms.CheckBox
        Me.Txt_ValDescto = New System.Windows.Forms.TextBox
        Me.Txt_PorDescto = New System.Windows.Forms.TextBox
        Me.txtCOSTO_TOTAL = New System.Windows.Forms.TextBox
        Me.bntEliminar = New System.Windows.Forms.Button
        Me.txtPRODUCTO = New System.Windows.Forms.TextBox
        Me.btnBuscarProducto = New System.Windows.Forms.Button
        Me.txtDESCRIPCION_PRODUCTO = New System.Windows.Forms.TextBox
        Me.chkSERVICIO = New System.Windows.Forms.CheckBox
        Me.txtCANTIDAD = New System.Windows.Forms.TextBox
        Me.txtLIBRAS = New System.Windows.Forms.TextBox
        Me.txtCOSTO_UNITARIO = New System.Windows.Forms.TextBox
        Me.cmbUNIDAD_MEDIDA = New System.Windows.Forms.ComboBox
        Me.btnGuardarDetalle = New System.Windows.Forms.Button
        Me.btnLimpiarProducto = New System.Windows.Forms.Button
        Me.GrbProveedor = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmbTipoDocumento = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbProveedor_FormaPago = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmbProveedor_CondicionPago = New System.Windows.Forms.ComboBox
        Me.ChkQuitarPerc = New System.Windows.Forms.CheckBox
        Me.TxtProveedor_NombreComercial = New System.Windows.Forms.TextBox
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.lblPORCENTAJE_PERCEPCION = New System.Windows.Forms.Label
        Me.BtnLimpiar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtProveedor_Direccion = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbProveedor_TipoProveedor = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtProveedor_Nit = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtProveedor_RegistroFiscal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtProveedor_NombreLegal = New System.Windows.Forms.TextBox
        Me.TxtProveedor_Codigo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbGral.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvDetalleOC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmMenu.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GrbProveedor.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbGral
        '
        Me.gbGral.BackColor = System.Drawing.Color.Transparent
        Me.gbGral.Controls.Add(Me.txtOC)
        Me.gbGral.Controls.Add(Me.btnFinRecepción)
        Me.gbGral.Controls.Add(Me.btnAnular)
        Me.gbGral.Controls.Add(Me.LblProcesada)
        Me.gbGral.Controls.Add(Me.btnImprimir)
        Me.gbGral.Controls.Add(Me.btnLimpiarOC)
        Me.gbGral.Controls.Add(Me.dpFECHA_OC)
        Me.gbGral.Controls.Add(Me.cmbCOMPAÑIA)
        Me.gbGral.Controls.Add(Me.btnProcesar)
        Me.gbGral.Controls.Add(Me.lblMensaje)
        Me.gbGral.Controls.Add(Me.Label15)
        Me.gbGral.Controls.Add(Me.cmbBODEGA)
        Me.gbGral.Controls.Add(Me.Label13)
        Me.gbGral.Controls.Add(Me.Label1)
        Me.gbGral.Controls.Add(Me.btnBuscarOC)
        Me.gbGral.Controls.Add(Me.btnGuardarEncabezado)
        Me.gbGral.Controls.Add(Me.Label5)
        Me.gbGral.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbGral.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGral.ForeColor = System.Drawing.Color.Navy
        Me.gbGral.Location = New System.Drawing.Point(0, 0)
        Me.gbGral.Name = "gbGral"
        Me.gbGral.Size = New System.Drawing.Size(1071, 74)
        Me.gbGral.TabIndex = 1
        Me.gbGral.TabStop = False
        Me.gbGral.Text = "Datos Generales"
        '
        'txtOC
        '
        Me.txtOC.BackColor = System.Drawing.Color.Yellow
        Me.txtOC.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtOC.ForeColor = System.Drawing.Color.Red
        Me.txtOC.Location = New System.Drawing.Point(559, 16)
        Me.txtOC.Name = "txtOC"
        Me.txtOC.Size = New System.Drawing.Size(84, 26)
        Me.txtOC.TabIndex = 65
        Me.txtOC.Text = "0"
        Me.txtOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnFinRecepción
        '
        Me.btnFinRecepción.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinRecepción.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFinRecepción.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFinRecepción.Location = New System.Drawing.Point(878, 16)
        Me.btnFinRecepción.Name = "btnFinRecepción"
        Me.btnFinRecepción.Size = New System.Drawing.Size(70, 52)
        Me.btnFinRecepción.TabIndex = 64
        Me.btnFinRecepción.Text = "&Finalizar Recepción Inventario"
        Me.btnFinRecepción.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnFinRecepción, "Dar por Finalizada la Recepción de Productos")
        Me.btnFinRecepción.UseVisualStyleBackColor = True
        '
        'btnAnular
        '
        Me.btnAnular.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.btnAnular.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAnular.Image = Global.ASTAS.My.Resources.Resources.button_cancel
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAnular.Location = New System.Drawing.Point(992, 16)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(64, 35)
        Me.btnAnular.TabIndex = 63
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnAnular, "Anular Orden de Compra")
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'LblProcesada
        '
        Me.LblProcesada.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblProcesada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblProcesada.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProcesada.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.LblProcesada.Location = New System.Drawing.Point(345, 41)
        Me.LblProcesada.Name = "LblProcesada"
        Me.LblProcesada.Size = New System.Drawing.Size(153, 24)
        Me.LblProcesada.TabIndex = 62
        Me.LblProcesada.Text = "OC FINALIZADA"
        Me.LblProcesada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblProcesada.Visible = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(765, 16)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(33, 35)
        Me.btnImprimir.TabIndex = 61
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Emitir Impresa Orden de Compra")
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnLimpiarOC
        '
        Me.btnLimpiarOC.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnLimpiarOC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiarOC.Image = CType(resources.GetObject("btnLimpiarOC.Image"), System.Drawing.Image)
        Me.btnLimpiarOC.Location = New System.Drawing.Point(648, 16)
        Me.btnLimpiarOC.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnLimpiarOC.Name = "btnLimpiarOC"
        Me.btnLimpiarOC.Size = New System.Drawing.Size(33, 35)
        Me.btnLimpiarOC.TabIndex = 16
        Me.btnLimpiarOC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiarOC, "Nueva Orden de Compra")
        Me.btnLimpiarOC.UseVisualStyleBackColor = True
        '
        'dpFECHA_OC
        '
        Me.dpFECHA_OC.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_OC.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_OC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_OC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFECHA_OC.Location = New System.Drawing.Point(557, 46)
        Me.dpFECHA_OC.Name = "dpFECHA_OC"
        Me.dpFECHA_OC.Size = New System.Drawing.Size(87, 22)
        Me.dpFECHA_OC.TabIndex = 2
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Items.AddRange(New Object() {"ASTAS - Asociación de Trabajadores de Avícola Salvadoreña"})
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(74, 16)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(424, 24)
        Me.cmbCOMPAÑIA.TabIndex = 0
        '
        'btnProcesar
        '
        Me.btnProcesar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesar.Location = New System.Drawing.Point(804, 16)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(68, 35)
        Me.btnProcesar.TabIndex = 10
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnProcesar, "Dar por Finalizada la Orden de Compra y pasar para Autorización")
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'lblMensaje
        '
        Me.lblMensaje.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMensaje.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.Yellow
        Me.lblMensaje.Location = New System.Drawing.Point(344, 40)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(153, 24)
        Me.lblMensaje.TabIndex = 8
        Me.lblMensaje.Text = "OC PROCESADA"
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMensaje.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(501, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 14)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Fecha OC"
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Items.AddRange(New Object() {"ASTAS - Asociación de Trabajadores de Avícola Salvadoreña"})
        Me.cmbBODEGA.Location = New System.Drawing.Point(74, 40)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(272, 24)
        Me.cmbBODEGA.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(8, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 14)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Bodega :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Compañía :"
        '
        'btnBuscarOC
        '
        Me.btnBuscarOC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarOC.Image = CType(resources.GetObject("btnBuscarOC.Image"), System.Drawing.Image)
        Me.btnBuscarOC.Location = New System.Drawing.Point(687, 16)
        Me.btnBuscarOC.Name = "btnBuscarOC"
        Me.btnBuscarOC.Size = New System.Drawing.Size(33, 35)
        Me.btnBuscarOC.TabIndex = 3
        Me.btnBuscarOC.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnBuscarOC, "Busca Ordenes de Compra registradas")
        Me.btnBuscarOC.UseVisualStyleBackColor = True
        '
        'btnGuardarEncabezado
        '
        Me.btnGuardarEncabezado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarEncabezado.Image = CType(resources.GetObject("btnGuardarEncabezado.Image"), System.Drawing.Image)
        Me.btnGuardarEncabezado.Location = New System.Drawing.Point(726, 16)
        Me.btnGuardarEncabezado.Name = "btnGuardarEncabezado"
        Me.btnGuardarEncabezado.Size = New System.Drawing.Size(33, 35)
        Me.btnGuardarEncabezado.TabIndex = 10
        Me.btnGuardarEncabezado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnGuardarEncabezado, "Guarda Orden de Compra")
        Me.btnGuardarEncabezado.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(501, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "N° OC :"
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.tabDatos)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Location = New System.Drawing.Point(0, 74)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1071, 568)
        Me.TabControl1.TabIndex = 2
        '
        'tabDatos
        '
        Me.tabDatos.BackColor = System.Drawing.Color.Transparent
        Me.tabDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabDatos.Controls.Add(Me.GroupBox3)
        Me.tabDatos.Controls.Add(Me.GroupBox2)
        Me.tabDatos.Controls.Add(Me.GroupBox1)
        Me.tabDatos.Controls.Add(Me.GrbProveedor)
        Me.tabDatos.Location = New System.Drawing.Point(4, 28)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDatos.Size = New System.Drawing.Size(1063, 536)
        Me.tabDatos.TabIndex = 0
        Me.tabDatos.Text = "Datos"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtOBSERVACIONES)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 482)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1053, 43)
        Me.GroupBox3.TabIndex = 47
        Me.GroupBox3.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(14, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Observaciones :"
        '
        'txtOBSERVACIONES
        '
        Me.txtOBSERVACIONES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOBSERVACIONES.BackColor = System.Drawing.SystemColors.Window
        Me.txtOBSERVACIONES.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOBSERVACIONES.ForeColor = System.Drawing.Color.Navy
        Me.txtOBSERVACIONES.Location = New System.Drawing.Point(107, 13)
        Me.txtOBSERVACIONES.MaxLength = 500
        Me.txtOBSERVACIONES.Name = "txtOBSERVACIONES"
        Me.txtOBSERVACIONES.Size = New System.Drawing.Size(932, 22)
        Me.txtOBSERVACIONES.TabIndex = 44
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 219)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1053, 270)
        Me.GroupBox2.TabIndex = 46
        Me.GroupBox2.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.dgvDetalleOC)
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1022, 264)
        Me.GroupBox5.TabIndex = 59
        Me.GroupBox5.TabStop = False
        '
        'dgvDetalleOC
        '
        Me.dgvDetalleOC.AllowUserToAddRows = False
        Me.dgvDetalleOC.AllowUserToDeleteRows = False
        Me.dgvDetalleOC.AllowUserToResizeColumns = False
        Me.dgvDetalleOC.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvDetalleOC.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvDetalleOC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleOC.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvDetalleOC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDetalleOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleOC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Prod, Me.numProd, Me.DescUM, Me.CantidadProd, Me.CU, Me.Descuento, Me.CT, Me.ConIVA, Me.Column1})
        Me.dgvDetalleOC.ContextMenuStrip = Me.cmMenu
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalleOC.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgvDetalleOC.Location = New System.Drawing.Point(3, 18)
        Me.dgvDetalleOC.Name = "dgvDetalleOC"
        Me.dgvDetalleOC.ReadOnly = True
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleOC.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvDetalleOC.RowHeadersVisible = False
        Me.dgvDetalleOC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleOC.Size = New System.Drawing.Size(800, 241)
        Me.dgvDetalleOC.TabIndex = 59
        '
        'Prod
        '
        Me.Prod.HeaderText = "Producto"
        Me.Prod.Name = "Prod"
        Me.Prod.ReadOnly = True
        Me.Prod.Width = 80
        '
        'numProd
        '
        Me.numProd.HeaderText = "Descripción Producto"
        Me.numProd.Name = "numProd"
        Me.numProd.ReadOnly = True
        Me.numProd.Width = 225
        '
        'DescUM
        '
        Me.DescUM.HeaderText = "Unidad Medida"
        Me.DescUM.Name = "DescUM"
        Me.DescUM.ReadOnly = True
        Me.DescUM.Width = 80
        '
        'CantidadProd
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CantidadProd.DefaultCellStyle = DataGridViewCellStyle14
        Me.CantidadProd.HeaderText = "Cantidad"
        Me.CantidadProd.Name = "CantidadProd"
        Me.CantidadProd.ReadOnly = True
        Me.CantidadProd.Width = 70
        '
        'CU
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N6"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.CU.DefaultCellStyle = DataGridViewCellStyle15
        Me.CU.HeaderText = "Costo Unit."
        Me.CU.Name = "CU"
        Me.CU.ReadOnly = True
        Me.CU.Width = 70
        '
        'Descuento
        '
        DataGridViewCellStyle16.Format = "N6"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.Descuento.DefaultCellStyle = DataGridViewCellStyle16
        Me.Descuento.HeaderText = "Descuento"
        Me.Descuento.Name = "Descuento"
        Me.Descuento.ReadOnly = True
        Me.Descuento.Visible = False
        '
        'CT
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N6"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.CT.DefaultCellStyle = DataGridViewCellStyle17
        Me.CT.HeaderText = "Sub Total"
        Me.CT.Name = "CT"
        Me.CT.ReadOnly = True
        Me.CT.Width = 70
        '
        'ConIVA
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "N6"
        DataGridViewCellStyle18.NullValue = Nothing
        Me.ConIVA.DefaultCellStyle = DataGridViewCellStyle18
        Me.ConIVA.HeaderText = "Con IVA"
        Me.ConIVA.Name = "ConIVA"
        Me.ConIVA.ReadOnly = True
        Me.ConIVA.Width = 70
        '
        'Column1
        '
        DataGridViewCellStyle19.Format = "N6"
        DataGridViewCellStyle19.NullValue = Nothing
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle19
        Me.Column1.HeaderText = "Percepcion"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 70
        '
        'cmMenu
        '
        Me.cmMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miMenu_Eliminar})
        Me.cmMenu.Name = "cmMenu"
        Me.cmMenu.Size = New System.Drawing.Size(118, 26)
        '
        'miMenu_Eliminar
        '
        Me.miMenu_Eliminar.Name = "miMenu_Eliminar"
        Me.miMenu_Eliminar.Size = New System.Drawing.Size(117, 22)
        Me.miMenu_Eliminar.Text = "Eliminar"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.Label19)
        Me.GroupBox6.Controls.Add(Me.txtSubTotal)
        Me.GroupBox6.Controls.Add(Me.Label25)
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Controls.Add(Me.txtTotal)
        Me.GroupBox6.Controls.Add(Me.txtExento)
        Me.GroupBox6.Controls.Add(Me.TxtCESC)
        Me.GroupBox6.Controls.Add(Me.txtPercepcion)
        Me.GroupBox6.Controls.Add(Me.txtIVA)
        Me.GroupBox6.Controls.Add(Me.Label23)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.txtTotalFact)
        Me.GroupBox6.Location = New System.Drawing.Point(803, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(216, 254)
        Me.GroupBox6.TabIndex = 58
        Me.GroupBox6.TabStop = False
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Teal
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Yellow
        Me.Label19.Location = New System.Drawing.Point(8, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 22)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "Sub Total"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSubTotal
        '
        Me.txtSubTotal.BackColor = System.Drawing.Color.White
        Me.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.ForeColor = System.Drawing.Color.Navy
        Me.txtSubTotal.Location = New System.Drawing.Point(112, 21)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(96, 22)
        Me.txtSubTotal.TabIndex = 0
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Yellow
        Me.Label25.Location = New System.Drawing.Point(8, 185)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(100, 22)
        Me.Label25.TabIndex = 57
        Me.Label25.Text = "(+) Valor Exento"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Teal
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Yellow
        Me.Label20.Location = New System.Drawing.Point(8, 62)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 22)
        Me.Label20.TabIndex = 48
        Me.Label20.Text = "(+) IVA"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Yellow
        Me.Label24.Location = New System.Drawing.Point(8, 144)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 22)
        Me.Label24.TabIndex = 55
        Me.Label24.Text = "(+) C.E.S.C."
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Red
        Me.txtTotal.Location = New System.Drawing.Point(112, 83)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotal.Size = New System.Drawing.Size(96, 20)
        Me.txtTotal.TabIndex = 34
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.Visible = False
        '
        'txtExento
        '
        Me.txtExento.BackColor = System.Drawing.Color.White
        Me.txtExento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExento.ForeColor = System.Drawing.Color.Navy
        Me.txtExento.Location = New System.Drawing.Point(112, 185)
        Me.txtExento.Name = "txtExento"
        Me.txtExento.Size = New System.Drawing.Size(96, 22)
        Me.txtExento.TabIndex = 4
        Me.txtExento.Text = "0.00"
        Me.txtExento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCESC
        '
        Me.TxtCESC.BackColor = System.Drawing.Color.White
        Me.TxtCESC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCESC.ForeColor = System.Drawing.Color.Navy
        Me.TxtCESC.Location = New System.Drawing.Point(112, 144)
        Me.TxtCESC.Name = "TxtCESC"
        Me.TxtCESC.Size = New System.Drawing.Size(96, 22)
        Me.TxtCESC.TabIndex = 3
        Me.TxtCESC.Text = "0.00"
        Me.TxtCESC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPercepcion
        '
        Me.txtPercepcion.BackColor = System.Drawing.Color.White
        Me.txtPercepcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPercepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPercepcion.ForeColor = System.Drawing.Color.Navy
        Me.txtPercepcion.Location = New System.Drawing.Point(112, 103)
        Me.txtPercepcion.Name = "txtPercepcion"
        Me.txtPercepcion.Size = New System.Drawing.Size(96, 22)
        Me.txtPercepcion.TabIndex = 2
        Me.txtPercepcion.Text = "0.00"
        Me.txtPercepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA
        '
        Me.txtIVA.BackColor = System.Drawing.Color.White
        Me.txtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA.ForeColor = System.Drawing.Color.Navy
        Me.txtIVA.Location = New System.Drawing.Point(112, 62)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.Size = New System.Drawing.Size(96, 22)
        Me.txtIVA.TabIndex = 1
        Me.txtIVA.Text = "0.00"
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Teal
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Yellow
        Me.Label23.Location = New System.Drawing.Point(8, 226)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 22)
        Me.Label23.TabIndex = 51
        Me.Label23.Text = "Total O.C."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Teal
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Yellow
        Me.Label22.Location = New System.Drawing.Point(8, 103)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 22)
        Me.Label22.TabIndex = 50
        Me.Label22.Text = "(+) Percepción"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalFact
        '
        Me.txtTotalFact.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTotalFact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFact.ForeColor = System.Drawing.Color.Red
        Me.txtTotalFact.Location = New System.Drawing.Point(112, 226)
        Me.txtTotalFact.Name = "txtTotalFact"
        Me.txtTotalFact.ReadOnly = True
        Me.txtTotalFact.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalFact.Size = New System.Drawing.Size(96, 22)
        Me.txtTotalFact.TabIndex = 5
        Me.txtTotalFact.Text = "0.00"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.dgvProductos)
        Me.GroupBox4.Controls.Add(Me.TxtNombreB)
        Me.GroupBox4.Location = New System.Drawing.Point(1024, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(27, 264)
        Me.GroupBox4.TabIndex = 58
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Visible = False
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.AllowUserToResizeColumns = False
        Me.dgvProductos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvProductos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvProductos.BackgroundColor = System.Drawing.Color.White
        Me.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductos.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvProductos.Location = New System.Drawing.Point(3, 40)
        Me.dgvProductos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductos.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductos.Size = New System.Drawing.Size(20, 219)
        Me.dgvProductos.TabIndex = 118
        '
        'TxtNombreB
        '
        Me.TxtNombreB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombreB.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtNombreB.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombreB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNombreB.Location = New System.Drawing.Point(3, 18)
        Me.TxtNombreB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNombreB.MaxLength = 100
        Me.TxtNombreB.Name = "TxtNombreB"
        Me.TxtNombreB.Size = New System.Drawing.Size(21, 22)
        Me.TxtNombreB.TabIndex = 117
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblDescuento)
        Me.GroupBox1.Controls.Add(Me.lblPorcentajeDescuento)
        Me.GroupBox1.Controls.Add(Me.lblCostoTotal)
        Me.GroupBox1.Controls.Add(Me.lblStock)
        Me.GroupBox1.Controls.Add(Me.lblCostoUnit)
        Me.GroupBox1.Controls.Add(Me.lblCantidad)
        Me.GroupBox1.Controls.Add(Me.lblUnidadMedida)
        Me.GroupBox1.Controls.Add(Me.lblDescripcion)
        Me.GroupBox1.Controls.Add(Me.lblProducto)
        Me.GroupBox1.Controls.Add(Me.chkBono)
        Me.GroupBox1.Controls.Add(Me.Txt_ValDescto)
        Me.GroupBox1.Controls.Add(Me.Txt_PorDescto)
        Me.GroupBox1.Controls.Add(Me.txtCOSTO_TOTAL)
        Me.GroupBox1.Controls.Add(Me.bntEliminar)
        Me.GroupBox1.Controls.Add(Me.txtPRODUCTO)
        Me.GroupBox1.Controls.Add(Me.btnBuscarProducto)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION_PRODUCTO)
        Me.GroupBox1.Controls.Add(Me.chkSERVICIO)
        Me.GroupBox1.Controls.Add(Me.txtCANTIDAD)
        Me.GroupBox1.Controls.Add(Me.txtLIBRAS)
        Me.GroupBox1.Controls.Add(Me.txtCOSTO_UNITARIO)
        Me.GroupBox1.Controls.Add(Me.cmbUNIDAD_MEDIDA)
        Me.GroupBox1.Controls.Add(Me.btnGuardarDetalle)
        Me.GroupBox1.Controls.Add(Me.btnLimpiarProducto)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(3, 149)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1053, 70)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        '
        'lblDescuento
        '
        Me.lblDescuento.BackColor = System.Drawing.Color.Teal
        Me.lblDescuento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.ForeColor = System.Drawing.Color.White
        Me.lblDescuento.Location = New System.Drawing.Point(985, 17)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(58, 20)
        Me.lblDescuento.TabIndex = 50
        Me.lblDescuento.Text = "Desc"
        Me.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDescuento.Visible = False
        '
        'lblPorcentajeDescuento
        '
        Me.lblPorcentajeDescuento.BackColor = System.Drawing.Color.Teal
        Me.lblPorcentajeDescuento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeDescuento.ForeColor = System.Drawing.Color.White
        Me.lblPorcentajeDescuento.Location = New System.Drawing.Point(925, 17)
        Me.lblPorcentajeDescuento.Name = "lblPorcentajeDescuento"
        Me.lblPorcentajeDescuento.Size = New System.Drawing.Size(58, 20)
        Me.lblPorcentajeDescuento.TabIndex = 49
        Me.lblPorcentajeDescuento.Text = "% Dscto"
        Me.lblPorcentajeDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPorcentajeDescuento.Visible = False
        '
        'lblCostoTotal
        '
        Me.lblCostoTotal.BackColor = System.Drawing.Color.Teal
        Me.lblCostoTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTotal.ForeColor = System.Drawing.Color.White
        Me.lblCostoTotal.Location = New System.Drawing.Point(625, 17)
        Me.lblCostoTotal.Name = "lblCostoTotal"
        Me.lblCostoTotal.Size = New System.Drawing.Size(64, 20)
        Me.lblCostoTotal.TabIndex = 48
        Me.lblCostoTotal.Text = "Costo Total"
        Me.lblCostoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStock
        '
        Me.lblStock.BackColor = System.Drawing.Color.Teal
        Me.lblStock.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStock.ForeColor = System.Drawing.Color.White
        Me.lblStock.Location = New System.Drawing.Point(585, 17)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(42, 20)
        Me.lblStock.TabIndex = 47
        Me.lblStock.Text = "Stock"
        Me.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCostoUnit
        '
        Me.lblCostoUnit.BackColor = System.Drawing.Color.Teal
        Me.lblCostoUnit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoUnit.ForeColor = System.Drawing.Color.White
        Me.lblCostoUnit.Location = New System.Drawing.Point(519, 17)
        Me.lblCostoUnit.Name = "lblCostoUnit"
        Me.lblCostoUnit.Size = New System.Drawing.Size(72, 20)
        Me.lblCostoUnit.TabIndex = 46
        Me.lblCostoUnit.Text = "Costo Unit."
        Me.lblCostoUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCantidad
        '
        Me.lblCantidad.BackColor = System.Drawing.Color.Teal
        Me.lblCantidad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.ForeColor = System.Drawing.Color.White
        Me.lblCantidad.Location = New System.Drawing.Point(447, 17)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(79, 20)
        Me.lblCantidad.TabIndex = 45
        Me.lblCantidad.Text = "Cantidad"
        Me.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUnidadMedida
        '
        Me.lblUnidadMedida.BackColor = System.Drawing.Color.Teal
        Me.lblUnidadMedida.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadMedida.ForeColor = System.Drawing.Color.White
        Me.lblUnidadMedida.Location = New System.Drawing.Point(352, 17)
        Me.lblUnidadMedida.Name = "lblUnidadMedida"
        Me.lblUnidadMedida.Size = New System.Drawing.Size(102, 20)
        Me.lblUnidadMedida.TabIndex = 44
        Me.lblUnidadMedida.Text = "Unidad Medida"
        Me.lblUnidadMedida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDescripcion
        '
        Me.lblDescripcion.BackColor = System.Drawing.Color.Teal
        Me.lblDescripcion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.Color.White
        Me.lblDescripcion.Location = New System.Drawing.Point(70, 17)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(287, 20)
        Me.lblDescripcion.TabIndex = 43
        Me.lblDescripcion.Text = "Descripción"
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProducto
        '
        Me.lblProducto.BackColor = System.Drawing.Color.Teal
        Me.lblProducto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.ForeColor = System.Drawing.Color.White
        Me.lblProducto.Location = New System.Drawing.Point(6, 17)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(75, 20)
        Me.lblProducto.TabIndex = 42
        Me.lblProducto.Text = "Producto"
        Me.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkBono
        '
        Me.chkBono.AutoSize = True
        Me.chkBono.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBono.Location = New System.Drawing.Point(695, 46)
        Me.chkBono.Name = "chkBono"
        Me.chkBono.Size = New System.Drawing.Size(85, 18)
        Me.chkBono.TabIndex = 41
        Me.chkBono.Text = "Bonificacion"
        Me.chkBono.UseVisualStyleBackColor = True
        '
        'Txt_ValDescto
        '
        Me.Txt_ValDescto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ValDescto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ValDescto.ForeColor = System.Drawing.Color.Navy
        Me.Txt_ValDescto.Location = New System.Drawing.Point(979, 41)
        Me.Txt_ValDescto.Name = "Txt_ValDescto"
        Me.Txt_ValDescto.Size = New System.Drawing.Size(64, 22)
        Me.Txt_ValDescto.TabIndex = 40
        Me.Txt_ValDescto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_ValDescto.Visible = False
        '
        'Txt_PorDescto
        '
        Me.Txt_PorDescto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_PorDescto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PorDescto.ForeColor = System.Drawing.Color.Navy
        Me.Txt_PorDescto.Location = New System.Drawing.Point(928, 42)
        Me.Txt_PorDescto.Name = "Txt_PorDescto"
        Me.Txt_PorDescto.Size = New System.Drawing.Size(43, 22)
        Me.Txt_PorDescto.TabIndex = 39
        Me.Txt_PorDescto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_PorDescto.Visible = False
        '
        'txtCOSTO_TOTAL
        '
        Me.txtCOSTO_TOTAL.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOSTO_TOTAL.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOSTO_TOTAL.ForeColor = System.Drawing.Color.Navy
        Me.txtCOSTO_TOTAL.Location = New System.Drawing.Point(625, 42)
        Me.txtCOSTO_TOTAL.Name = "txtCOSTO_TOTAL"
        Me.txtCOSTO_TOTAL.Size = New System.Drawing.Size(64, 22)
        Me.txtCOSTO_TOTAL.TabIndex = 38
        Me.txtCOSTO_TOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bntEliminar
        '
        Me.bntEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bntEliminar.Image = Global.ASTAS.My.Resources.Resources.editdelete
        Me.bntEliminar.Location = New System.Drawing.Point(756, 15)
        Me.bntEliminar.Name = "bntEliminar"
        Me.bntEliminar.Size = New System.Drawing.Size(31, 29)
        Me.bntEliminar.TabIndex = 32
        Me.bntEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.bntEliminar, "Eliminar producto de la Orden de Compra")
        Me.bntEliminar.UseVisualStyleBackColor = True
        Me.bntEliminar.Visible = False
        '
        'txtPRODUCTO
        '
        Me.txtPRODUCTO.BackColor = System.Drawing.Color.White
        Me.txtPRODUCTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRODUCTO.ForeColor = System.Drawing.Color.Red
        Me.txtPRODUCTO.Location = New System.Drawing.Point(6, 42)
        Me.txtPRODUCTO.Name = "txtPRODUCTO"
        Me.txtPRODUCTO.Size = New System.Drawing.Size(64, 22)
        Me.txtPRODUCTO.TabIndex = 19
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.Location = New System.Drawing.Point(70, 42)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto.TabIndex = 30
        Me.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'txtDESCRIPCION_PRODUCTO
        '
        Me.txtDESCRIPCION_PRODUCTO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDESCRIPCION_PRODUCTO.Enabled = False
        Me.txtDESCRIPCION_PRODUCTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_PRODUCTO.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_PRODUCTO.Location = New System.Drawing.Point(94, 42)
        Me.txtDESCRIPCION_PRODUCTO.Name = "txtDESCRIPCION_PRODUCTO"
        Me.txtDESCRIPCION_PRODUCTO.Size = New System.Drawing.Size(266, 22)
        Me.txtDESCRIPCION_PRODUCTO.TabIndex = 21
        '
        'chkSERVICIO
        '
        Me.chkSERVICIO.AutoSize = True
        Me.chkSERVICIO.Checked = True
        Me.chkSERVICIO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSERVICIO.Enabled = False
        Me.chkSERVICIO.Location = New System.Drawing.Point(602, 46)
        Me.chkSERVICIO.Name = "chkSERVICIO"
        Me.chkSERVICIO.Size = New System.Drawing.Size(15, 14)
        Me.chkSERVICIO.TabIndex = 37
        Me.chkSERVICIO.UseVisualStyleBackColor = True
        '
        'txtCANTIDAD
        '
        Me.txtCANTIDAD.BackColor = System.Drawing.SystemColors.Window
        Me.txtCANTIDAD.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCANTIDAD.ForeColor = System.Drawing.Color.Navy
        Me.txtCANTIDAD.Location = New System.Drawing.Point(455, 42)
        Me.txtCANTIDAD.Name = "txtCANTIDAD"
        Me.txtCANTIDAD.Size = New System.Drawing.Size(71, 22)
        Me.txtCANTIDAD.TabIndex = 23
        Me.txtCANTIDAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLIBRAS
        '
        Me.txtLIBRAS.BackColor = System.Drawing.SystemColors.Window
        Me.txtLIBRAS.Enabled = False
        Me.txtLIBRAS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIBRAS.ForeColor = System.Drawing.Color.Navy
        Me.txtLIBRAS.Location = New System.Drawing.Point(459, 42)
        Me.txtLIBRAS.Name = "txtLIBRAS"
        Me.txtLIBRAS.Size = New System.Drawing.Size(64, 22)
        Me.txtLIBRAS.TabIndex = 24
        Me.txtLIBRAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLIBRAS.Visible = False
        '
        'txtCOSTO_UNITARIO
        '
        Me.txtCOSTO_UNITARIO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOSTO_UNITARIO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOSTO_UNITARIO.ForeColor = System.Drawing.Color.Navy
        Me.txtCOSTO_UNITARIO.Location = New System.Drawing.Point(527, 42)
        Me.txtCOSTO_UNITARIO.Name = "txtCOSTO_UNITARIO"
        Me.txtCOSTO_UNITARIO.Size = New System.Drawing.Size(64, 22)
        Me.txtCOSTO_UNITARIO.TabIndex = 25
        Me.txtCOSTO_UNITARIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbUNIDAD_MEDIDA
        '
        Me.cmbUNIDAD_MEDIDA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUNIDAD_MEDIDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUNIDAD_MEDIDA.Enabled = False
        Me.cmbUNIDAD_MEDIDA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUNIDAD_MEDIDA.ForeColor = System.Drawing.Color.Black
        Me.cmbUNIDAD_MEDIDA.FormattingEnabled = True
        Me.cmbUNIDAD_MEDIDA.Items.AddRange(New Object() {"Crédito 30 días", "Crédito 60 días", "Crédito 90 días"})
        Me.cmbUNIDAD_MEDIDA.Location = New System.Drawing.Point(360, 42)
        Me.cmbUNIDAD_MEDIDA.Name = "cmbUNIDAD_MEDIDA"
        Me.cmbUNIDAD_MEDIDA.Size = New System.Drawing.Size(94, 24)
        Me.cmbUNIDAD_MEDIDA.TabIndex = 33
        '
        'btnGuardarDetalle
        '
        Me.btnGuardarDetalle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarDetalle.Image = CType(resources.GetObject("btnGuardarDetalle.Image"), System.Drawing.Image)
        Me.btnGuardarDetalle.Location = New System.Drawing.Point(694, 15)
        Me.btnGuardarDetalle.Name = "btnGuardarDetalle"
        Me.btnGuardarDetalle.Size = New System.Drawing.Size(31, 29)
        Me.btnGuardarDetalle.TabIndex = 26
        Me.btnGuardarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnGuardarDetalle, "Agregar producto a la Orden de Compra")
        Me.btnGuardarDetalle.UseVisualStyleBackColor = True
        '
        'btnLimpiarProducto
        '
        Me.btnLimpiarProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiarProducto.Image = CType(resources.GetObject("btnLimpiarProducto.Image"), System.Drawing.Image)
        Me.btnLimpiarProducto.Location = New System.Drawing.Point(725, 15)
        Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
        Me.btnLimpiarProducto.Size = New System.Drawing.Size(31, 29)
        Me.btnLimpiarProducto.TabIndex = 31
        Me.btnLimpiarProducto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnLimpiarProducto, "Limpia los campos del Producto")
        Me.btnLimpiarProducto.UseVisualStyleBackColor = True
        '
        'GrbProveedor
        '
        Me.GrbProveedor.BackColor = System.Drawing.Color.Transparent
        Me.GrbProveedor.Controls.Add(Me.Panel1)
        Me.GrbProveedor.Controls.Add(Me.ChkQuitarPerc)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_NombreComercial)
        Me.GrbProveedor.Controls.Add(Me.BtnBuscar)
        Me.GrbProveedor.Controls.Add(Me.lblPORCENTAJE_PERCEPCION)
        Me.GrbProveedor.Controls.Add(Me.BtnLimpiar)
        Me.GrbProveedor.Controls.Add(Me.Label2)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_Direccion)
        Me.GrbProveedor.Controls.Add(Me.Label10)
        Me.GrbProveedor.Controls.Add(Me.CmbProveedor_TipoProveedor)
        Me.GrbProveedor.Controls.Add(Me.Label4)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_Nit)
        Me.GrbProveedor.Controls.Add(Me.Label3)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_RegistroFiscal)
        Me.GrbProveedor.Controls.Add(Me.Label8)
        Me.GrbProveedor.Controls.Add(Me.Label11)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_NombreLegal)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_Codigo)
        Me.GrbProveedor.Controls.Add(Me.Label12)
        Me.GrbProveedor.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrbProveedor.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrbProveedor.ForeColor = System.Drawing.Color.Navy
        Me.GrbProveedor.Location = New System.Drawing.Point(3, 3)
        Me.GrbProveedor.Name = "GrbProveedor"
        Me.GrbProveedor.Size = New System.Drawing.Size(1053, 146)
        Me.GrbProveedor.TabIndex = 7
        Me.GrbProveedor.TabStop = False
        Me.GrbProveedor.Text = "Seleccionar Proveedor"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Yellow
        Me.Panel1.Controls.Add(Me.cmbTipoDocumento)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.CmbProveedor_FormaPago)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.CmbProveedor_CondicionPago)
        Me.Panel1.Location = New System.Drawing.Point(412, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(269, 96)
        Me.Panel1.TabIndex = 45
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocumento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDocumento.FormattingEnabled = True
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(120, 6)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(144, 24)
        Me.cmbTipoDocumento.TabIndex = 44
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(6, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 14)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Forma de Pago"
        '
        'CmbProveedor_FormaPago
        '
        Me.CmbProveedor_FormaPago.BackColor = System.Drawing.SystemColors.Window
        Me.CmbProveedor_FormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProveedor_FormaPago.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbProveedor_FormaPago.ForeColor = System.Drawing.Color.Navy
        Me.CmbProveedor_FormaPago.FormattingEnabled = True
        Me.CmbProveedor_FormaPago.Location = New System.Drawing.Point(120, 36)
        Me.CmbProveedor_FormaPago.Name = "CmbProveedor_FormaPago"
        Me.CmbProveedor_FormaPago.Size = New System.Drawing.Size(144, 24)
        Me.CmbProveedor_FormaPago.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(6, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 14)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Tipo Documento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(7, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 14)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Condición de Pago"
        '
        'CmbProveedor_CondicionPago
        '
        Me.CmbProveedor_CondicionPago.BackColor = System.Drawing.SystemColors.Window
        Me.CmbProveedor_CondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProveedor_CondicionPago.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbProveedor_CondicionPago.ForeColor = System.Drawing.Color.Navy
        Me.CmbProveedor_CondicionPago.FormattingEnabled = True
        Me.CmbProveedor_CondicionPago.Location = New System.Drawing.Point(120, 66)
        Me.CmbProveedor_CondicionPago.Name = "CmbProveedor_CondicionPago"
        Me.CmbProveedor_CondicionPago.Size = New System.Drawing.Size(144, 24)
        Me.CmbProveedor_CondicionPago.TabIndex = 8
        '
        'ChkQuitarPerc
        '
        Me.ChkQuitarPerc.AutoSize = True
        Me.ChkQuitarPerc.Checked = True
        Me.ChkQuitarPerc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkQuitarPerc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkQuitarPerc.ForeColor = System.Drawing.Color.Red
        Me.ChkQuitarPerc.Location = New System.Drawing.Point(694, 77)
        Me.ChkQuitarPerc.Name = "ChkQuitarPerc"
        Me.ChkQuitarPerc.Size = New System.Drawing.Size(112, 18)
        Me.ChkQuitarPerc.TabIndex = 39
        Me.ChkQuitarPerc.Text = "Quitar Percepción"
        Me.ChkQuitarPerc.UseVisualStyleBackColor = True
        '
        'TxtProveedor_NombreComercial
        '
        Me.TxtProveedor_NombreComercial.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_NombreComercial.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_NombreComercial.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_NombreComercial.Location = New System.Drawing.Point(104, 66)
        Me.TxtProveedor_NombreComercial.Name = "TxtProveedor_NombreComercial"
        Me.TxtProveedor_NombreComercial.ReadOnly = True
        Me.TxtProveedor_NombreComercial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtProveedor_NombreComercial.Size = New System.Drawing.Size(303, 22)
        Me.TxtProveedor_NombreComercial.TabIndex = 2
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(200, 18)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscar.TabIndex = 0
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'lblPORCENTAJE_PERCEPCION
        '
        Me.lblPORCENTAJE_PERCEPCION.AutoSize = True
        Me.lblPORCENTAJE_PERCEPCION.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPORCENTAJE_PERCEPCION.Location = New System.Drawing.Point(253, 18)
        Me.lblPORCENTAJE_PERCEPCION.Name = "lblPORCENTAJE_PERCEPCION"
        Me.lblPORCENTAJE_PERCEPCION.Size = New System.Drawing.Size(19, 23)
        Me.lblPORCENTAJE_PERCEPCION.TabIndex = 38
        Me.lblPORCENTAJE_PERCEPCION.Text = "0"
        Me.lblPORCENTAJE_PERCEPCION.Visible = False
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnLimpiar.Image = CType(resources.GetObject("BtnLimpiar.Image"), System.Drawing.Image)
        Me.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLimpiar.Location = New System.Drawing.Point(224, 18)
        Me.BtnLimpiar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(24, 24)
        Me.BtnLimpiar.TabIndex = 15
        Me.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 14)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Direccion"
        '
        'TxtProveedor_Direccion
        '
        Me.TxtProveedor_Direccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_Direccion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Direccion.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_Direccion.Location = New System.Drawing.Point(104, 114)
        Me.TxtProveedor_Direccion.Name = "TxtProveedor_Direccion"
        Me.TxtProveedor_Direccion.ReadOnly = True
        Me.TxtProveedor_Direccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtProveedor_Direccion.Size = New System.Drawing.Size(734, 22)
        Me.TxtProveedor_Direccion.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 14)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Nombre Comercial"
        '
        'CmbProveedor_TipoProveedor
        '
        Me.CmbProveedor_TipoProveedor.BackColor = System.Drawing.SystemColors.Window
        Me.CmbProveedor_TipoProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.CmbProveedor_TipoProveedor.Enabled = False
        Me.CmbProveedor_TipoProveedor.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbProveedor_TipoProveedor.ForeColor = System.Drawing.Color.Navy
        Me.CmbProveedor_TipoProveedor.FormattingEnabled = True
        Me.CmbProveedor_TipoProveedor.Location = New System.Drawing.Point(694, 44)
        Me.CmbProveedor_TipoProveedor.Name = "CmbProveedor_TipoProveedor"
        Me.CmbProveedor_TipoProveedor.Size = New System.Drawing.Size(144, 24)
        Me.CmbProveedor_TipoProveedor.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(695, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 14)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Tipo Contribuyente"
        '
        'TxtProveedor_Nit
        '
        Me.TxtProveedor_Nit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_Nit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Nit.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_Nit.Location = New System.Drawing.Point(294, 90)
        Me.TxtProveedor_Nit.MaxLength = 17
        Me.TxtProveedor_Nit.Name = "TxtProveedor_Nit"
        Me.TxtProveedor_Nit.ReadOnly = True
        Me.TxtProveedor_Nit.Size = New System.Drawing.Size(113, 22)
        Me.TxtProveedor_Nit.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(264, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 16)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "NIT"
        '
        'TxtProveedor_RegistroFiscal
        '
        Me.TxtProveedor_RegistroFiscal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_RegistroFiscal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_RegistroFiscal.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_RegistroFiscal.Location = New System.Drawing.Point(104, 90)
        Me.TxtProveedor_RegistroFiscal.MaxLength = 20
        Me.TxtProveedor_RegistroFiscal.Name = "TxtProveedor_RegistroFiscal"
        Me.TxtProveedor_RegistroFiscal.ReadOnly = True
        Me.TxtProveedor_RegistroFiscal.Size = New System.Drawing.Size(111, 22)
        Me.TxtProveedor_RegistroFiscal.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 14)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Registro Fiscal"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 14)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Nombre Legal"
        '
        'TxtProveedor_NombreLegal
        '
        Me.TxtProveedor_NombreLegal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_NombreLegal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_NombreLegal.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_NombreLegal.Location = New System.Drawing.Point(104, 42)
        Me.TxtProveedor_NombreLegal.Name = "TxtProveedor_NombreLegal"
        Me.TxtProveedor_NombreLegal.ReadOnly = True
        Me.TxtProveedor_NombreLegal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtProveedor_NombreLegal.Size = New System.Drawing.Size(303, 22)
        Me.TxtProveedor_NombreLegal.TabIndex = 1
        '
        'TxtProveedor_Codigo
        '
        Me.TxtProveedor_Codigo.BackColor = System.Drawing.Color.White
        Me.TxtProveedor_Codigo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Codigo.ForeColor = System.Drawing.Color.Red
        Me.TxtProveedor_Codigo.Location = New System.Drawing.Point(104, 18)
        Me.TxtProveedor_Codigo.Name = "TxtProveedor_Codigo"
        Me.TxtProveedor_Codigo.Size = New System.Drawing.Size(94, 22)
        Me.TxtProveedor_Codigo.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(8, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 14)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Proveedor"
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Información"
        '
        'Contabilidad_OrdenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1071, 642)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gbGral)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_OrdenCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compras - Registro de Ordenes de Compra"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbGral.ResumeLayout(False)
        Me.gbGral.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.dgvDetalleOC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmMenu.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrbProveedor.ResumeLayout(False)
        Me.GrbProveedor.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbGral As System.Windows.Forms.GroupBox
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents dpFECHA_OC As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarOC As System.Windows.Forms.Button
    Friend WithEvents btnGuardarEncabezado As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabDatos As System.Windows.Forms.TabPage
    Friend WithEvents GrbProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents TxtProveedor_NombreComercial As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_Direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbProveedor_CondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents CmbProveedor_FormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents CmbProveedor_TipoProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_Nit As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_RegistroFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_NombreLegal As System.Windows.Forms.TextBox
    Friend WithEvents TxtProveedor_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTotalFact As System.Windows.Forms.TextBox
    Friend WithEvents txtPercepcion As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnLimpiarOC As System.Windows.Forms.Button
    Friend WithEvents lblPORCENTAJE_PERCEPCION As System.Windows.Forms.Label
    Friend WithEvents cmMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMenu_Eliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtOBSERVACIONES As System.Windows.Forms.TextBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkQuitarPerc As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents LblProcesada As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCOSTO_TOTAL As System.Windows.Forms.TextBox
    Friend WithEvents bntEliminar As System.Windows.Forms.Button
    Friend WithEvents txtPRODUCTO As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents txtDESCRIPCION_PRODUCTO As System.Windows.Forms.TextBox
    Friend WithEvents chkSERVICIO As System.Windows.Forms.CheckBox
    Friend WithEvents txtCANTIDAD As System.Windows.Forms.TextBox
    Friend WithEvents txtLIBRAS As System.Windows.Forms.TextBox
    Friend WithEvents txtCOSTO_UNITARIO As System.Windows.Forms.TextBox
    Friend WithEvents cmbUNIDAD_MEDIDA As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardarDetalle As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarProducto As System.Windows.Forms.Button
    Friend WithEvents Txt_PorDescto As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ValDescto As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtExento As System.Windows.Forms.TextBox
    Friend WithEvents chkBono As System.Windows.Forms.CheckBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtCESC As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblCostoTotal As System.Windows.Forms.Label
    Friend WithEvents lblStock As System.Windows.Forms.Label
    Friend WithEvents lblCostoUnit As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents lblUnidadMedida As System.Windows.Forms.Label
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetalleOC As System.Windows.Forms.DataGridView
    Friend WithEvents dgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents TxtNombreB As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Prod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescUM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConIVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblPorcentajeDescuento As System.Windows.Forms.Label
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnFinRecepción As System.Windows.Forms.Button
    Friend WithEvents txtOC As System.Windows.Forms.TextBox
End Class
