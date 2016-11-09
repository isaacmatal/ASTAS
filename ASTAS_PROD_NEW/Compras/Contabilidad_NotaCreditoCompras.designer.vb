<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_NotaCreditoCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_NotaCreditoCompras))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gbGral = New System.Windows.Forms.GroupBox
        Me.txtNC = New System.Windows.Forms.TextBox
        Me.lblCompañia = New System.Windows.Forms.Label
        Me.btnLimpiarOC = New System.Windows.Forms.Button
        Me.dpFECHA_NC = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabDatos = New System.Windows.Forms.TabPage
        Me.bntEliminar = New System.Windows.Forms.Button
        Me.txtOBSERVACIONES = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.chkSERVICIO = New System.Windows.Forms.CheckBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtTotalFact = New System.Windows.Forms.TextBox
        Me.txtPercepcion = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.txtIVA = New System.Windows.Forms.TextBox
        Me.txtSubTotal = New System.Windows.Forms.TextBox
        Me.btnLimpiarProducto = New System.Windows.Forms.Button
        Me.btnGuardarDetalle = New System.Windows.Forms.Button
        Me.cmbUNIDAD_MEDIDA = New System.Windows.Forms.ComboBox
        Me.txtCOSTO_UNITARIO = New System.Windows.Forms.TextBox
        Me.txtCANTIDAD = New System.Windows.Forms.TextBox
        Me.txtDESCRIPCION_PRODUCTO = New System.Windows.Forms.TextBox
        Me.btnBuscarProducto = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtPRODUCTO = New System.Windows.Forms.TextBox
        Me.dgvDetalleOC = New System.Windows.Forms.DataGridView
        Me.cmMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miMenu_Eliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.GrbProveedor = New System.Windows.Forms.GroupBox
        Me.lblMensaje = New System.Windows.Forms.Label
        Me.chkPercep = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkAjustarInv = New System.Windows.Forms.CheckBox
        Me.txtOC = New System.Windows.Forms.Label
        Me.txtCCF = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtProveedor_NombreComercial = New System.Windows.Forms.TextBox
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.lblPORCENTAJE_PERCEPCION = New System.Windows.Forms.Label
        Me.BtnLimpiar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtProveedor_Direccion = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
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
        CType(Me.dgvDetalleOC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmMenu.SuspendLayout()
        Me.GrbProveedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbGral
        '
        Me.gbGral.BackColor = System.Drawing.Color.Transparent
        Me.gbGral.Controls.Add(Me.txtNC)
        Me.gbGral.Controls.Add(Me.lblCompañia)
        Me.gbGral.Controls.Add(Me.btnLimpiarOC)
        Me.gbGral.Controls.Add(Me.dpFECHA_NC)
        Me.gbGral.Controls.Add(Me.Label15)
        Me.gbGral.Controls.Add(Me.cmbBODEGA)
        Me.gbGral.Controls.Add(Me.Label13)
        Me.gbGral.Controls.Add(Me.Label1)
        Me.gbGral.Controls.Add(Me.Label5)
        Me.gbGral.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGral.ForeColor = System.Drawing.Color.Navy
        Me.gbGral.Location = New System.Drawing.Point(8, 8)
        Me.gbGral.Name = "gbGral"
        Me.gbGral.Size = New System.Drawing.Size(736, 80)
        Me.gbGral.TabIndex = 1
        Me.gbGral.TabStop = False
        Me.gbGral.Text = "Datos Generales"
        '
        'txtNC
        '
        Me.txtNC.BackColor = System.Drawing.Color.Yellow
        Me.txtNC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNC.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNC.ForeColor = System.Drawing.Color.Red
        Me.txtNC.Location = New System.Drawing.Point(591, 20)
        Me.txtNC.Name = "txtNC"
        Me.txtNC.Size = New System.Drawing.Size(87, 26)
        Me.txtNC.TabIndex = 63
        '
        'lblCompañia
        '
        Me.lblCompañia.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompañia.Location = New System.Drawing.Point(74, 24)
        Me.lblCompañia.Name = "lblCompañia"
        Me.lblCompañia.Size = New System.Drawing.Size(448, 19)
        Me.lblCompañia.TabIndex = 62
        Me.lblCompañia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLimpiarOC
        '
        Me.btnLimpiarOC.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnLimpiarOC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiarOC.Image = CType(resources.GetObject("btnLimpiarOC.Image"), System.Drawing.Image)
        Me.btnLimpiarOC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarOC.Location = New System.Drawing.Point(682, 20)
        Me.btnLimpiarOC.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnLimpiarOC.Name = "btnLimpiarOC"
        Me.btnLimpiarOC.Size = New System.Drawing.Size(24, 24)
        Me.btnLimpiarOC.TabIndex = 16
        Me.btnLimpiarOC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarOC.UseVisualStyleBackColor = True
        '
        'dpFECHA_NC
        '
        Me.dpFECHA_NC.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_NC.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_NC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_NC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFECHA_NC.Location = New System.Drawing.Point(591, 48)
        Me.dpFECHA_NC.Name = "dpFECHA_NC"
        Me.dpFECHA_NC.Size = New System.Drawing.Size(87, 22)
        Me.dpFECHA_NC.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(528, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 16)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Fecha NC :"
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Enabled = False
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Items.AddRange(New Object() {"ASTAS - Asociación de Trabajadores de Avícola Salvadoreña"})
        Me.cmbBODEGA.Location = New System.Drawing.Point(74, 48)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(448, 24)
        Me.cmbBODEGA.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(8, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 16)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Bodega :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Compañía :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(528, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "N° NC :"
        '
        'btnProcesar
        '
        Me.btnProcesar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesar.Location = New System.Drawing.Point(88, 427)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(64, 40)
        Me.btnProcesar.TabIndex = 10
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnProcesar, "Procesa Orden de Compra")
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.tabDatos)
        Me.TabControl1.Location = New System.Drawing.Point(8, 96)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(736, 512)
        Me.TabControl1.TabIndex = 2
        '
        'tabDatos
        '
        Me.tabDatos.BackColor = System.Drawing.Color.Transparent
        Me.tabDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabDatos.Controls.Add(Me.bntEliminar)
        Me.tabDatos.Controls.Add(Me.txtOBSERVACIONES)
        Me.tabDatos.Controls.Add(Me.Label9)
        Me.tabDatos.Controls.Add(Me.chkSERVICIO)
        Me.tabDatos.Controls.Add(Me.btnProcesar)
        Me.tabDatos.Controls.Add(Me.Label17)
        Me.tabDatos.Controls.Add(Me.txtTotalFact)
        Me.tabDatos.Controls.Add(Me.txtPercepcion)
        Me.tabDatos.Controls.Add(Me.txtTotal)
        Me.tabDatos.Controls.Add(Me.txtIVA)
        Me.tabDatos.Controls.Add(Me.txtSubTotal)
        Me.tabDatos.Controls.Add(Me.btnLimpiarProducto)
        Me.tabDatos.Controls.Add(Me.btnGuardarDetalle)
        Me.tabDatos.Controls.Add(Me.cmbUNIDAD_MEDIDA)
        Me.tabDatos.Controls.Add(Me.txtCOSTO_UNITARIO)
        Me.tabDatos.Controls.Add(Me.txtCANTIDAD)
        Me.tabDatos.Controls.Add(Me.txtDESCRIPCION_PRODUCTO)
        Me.tabDatos.Controls.Add(Me.btnBuscarProducto)
        Me.tabDatos.Controls.Add(Me.Label14)
        Me.tabDatos.Controls.Add(Me.txtPRODUCTO)
        Me.tabDatos.Controls.Add(Me.dgvDetalleOC)
        Me.tabDatos.Controls.Add(Me.GrbProveedor)
        Me.tabDatos.Location = New System.Drawing.Point(4, 28)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDatos.Size = New System.Drawing.Size(728, 480)
        Me.tabDatos.TabIndex = 0
        Me.tabDatos.Text = "Datos"
        '
        'bntEliminar
        '
        Me.bntEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bntEliminar.Image = Global.ASTAS.My.Resources.Resources.editdelete
        Me.bntEliminar.Location = New System.Drawing.Point(696, 166)
        Me.bntEliminar.Name = "bntEliminar"
        Me.bntEliminar.Size = New System.Drawing.Size(24, 24)
        Me.bntEliminar.TabIndex = 8
        Me.bntEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.bntEliminar, "Agregar producto a la Orden de Compra")
        Me.bntEliminar.UseVisualStyleBackColor = True
        '
        'txtOBSERVACIONES
        '
        Me.txtOBSERVACIONES.BackColor = System.Drawing.SystemColors.Window
        Me.txtOBSERVACIONES.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOBSERVACIONES.ForeColor = System.Drawing.Color.Navy
        Me.txtOBSERVACIONES.Location = New System.Drawing.Point(88, 400)
        Me.txtOBSERVACIONES.MaxLength = 300
        Me.txtOBSERVACIONES.Name = "txtOBSERVACIONES"
        Me.txtOBSERVACIONES.ReadOnly = True
        Me.txtOBSERVACIONES.Size = New System.Drawing.Size(632, 22)
        Me.txtOBSERVACIONES.TabIndex = 44
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(8, 400)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Observaciones :"
        '
        'chkSERVICIO
        '
        Me.chkSERVICIO.AutoSize = True
        Me.chkSERVICIO.Enabled = False
        Me.chkSERVICIO.Location = New System.Drawing.Point(643, 196)
        Me.chkSERVICIO.Name = "chkSERVICIO"
        Me.chkSERVICIO.Size = New System.Drawing.Size(15, 14)
        Me.chkSERVICIO.TabIndex = 5
        Me.chkSERVICIO.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Teal
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(205, 424)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(512, 20)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "        Subtotal                    (+) IVA                        Total         " & _
            "           (+)   Percep.                Total OC"
        '
        'txtTotalFact
        '
        Me.txtTotalFact.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTotalFact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalFact.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFact.ForeColor = System.Drawing.Color.Red
        Me.txtTotalFact.Location = New System.Drawing.Point(621, 445)
        Me.txtTotalFact.Name = "txtTotalFact"
        Me.txtTotalFact.ReadOnly = True
        Me.txtTotalFact.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalFact.Size = New System.Drawing.Size(96, 26)
        Me.txtTotalFact.TabIndex = 36
        Me.txtTotalFact.Text = "0.00"
        '
        'txtPercepcion
        '
        Me.txtPercepcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtPercepcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPercepcion.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPercepcion.ForeColor = System.Drawing.Color.Navy
        Me.txtPercepcion.Location = New System.Drawing.Point(517, 445)
        Me.txtPercepcion.Name = "txtPercepcion"
        Me.txtPercepcion.ReadOnly = True
        Me.txtPercepcion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPercepcion.Size = New System.Drawing.Size(96, 26)
        Me.txtPercepcion.TabIndex = 35
        Me.txtPercepcion.Text = "0.00"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Red
        Me.txtTotal.Location = New System.Drawing.Point(413, 445)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotal.Size = New System.Drawing.Size(96, 26)
        Me.txtTotal.TabIndex = 34
        Me.txtTotal.Text = "0.00"
        '
        'txtIVA
        '
        Me.txtIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIVA.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA.ForeColor = System.Drawing.Color.Navy
        Me.txtIVA.Location = New System.Drawing.Point(309, 445)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtIVA.Size = New System.Drawing.Size(96, 26)
        Me.txtIVA.TabIndex = 33
        Me.txtIVA.Text = "0.00"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubTotal.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.ForeColor = System.Drawing.Color.Navy
        Me.txtSubTotal.Location = New System.Drawing.Point(205, 445)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSubTotal.Size = New System.Drawing.Size(96, 26)
        Me.txtSubTotal.TabIndex = 32
        Me.txtSubTotal.Text = "0.00"
        '
        'btnLimpiarProducto
        '
        Me.btnLimpiarProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiarProducto.Image = CType(resources.GetObject("btnLimpiarProducto.Image"), System.Drawing.Image)
        Me.btnLimpiarProducto.Location = New System.Drawing.Point(696, 192)
        Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
        Me.btnLimpiarProducto.Size = New System.Drawing.Size(24, 24)
        Me.btnLimpiarProducto.TabIndex = 7
        Me.btnLimpiarProducto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnLimpiarProducto, "Limpia los campos del Producto")
        Me.btnLimpiarProducto.UseVisualStyleBackColor = True
        '
        'btnGuardarDetalle
        '
        Me.btnGuardarDetalle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarDetalle.Image = CType(resources.GetObject("btnGuardarDetalle.Image"), System.Drawing.Image)
        Me.btnGuardarDetalle.Location = New System.Drawing.Point(672, 192)
        Me.btnGuardarDetalle.Name = "btnGuardarDetalle"
        Me.btnGuardarDetalle.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardarDetalle.TabIndex = 6
        Me.btnGuardarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnGuardarDetalle, "Agregar producto a la Orden de Compra")
        Me.btnGuardarDetalle.UseVisualStyleBackColor = True
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
        Me.cmbUNIDAD_MEDIDA.Location = New System.Drawing.Point(377, 192)
        Me.cmbUNIDAD_MEDIDA.Name = "cmbUNIDAD_MEDIDA"
        Me.cmbUNIDAD_MEDIDA.Size = New System.Drawing.Size(104, 24)
        Me.cmbUNIDAD_MEDIDA.TabIndex = 2
        '
        'txtCOSTO_UNITARIO
        '
        Me.txtCOSTO_UNITARIO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCOSTO_UNITARIO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOSTO_UNITARIO.ForeColor = System.Drawing.Color.Navy
        Me.txtCOSTO_UNITARIO.Location = New System.Drawing.Point(560, 192)
        Me.txtCOSTO_UNITARIO.Name = "txtCOSTO_UNITARIO"
        Me.txtCOSTO_UNITARIO.Size = New System.Drawing.Size(64, 22)
        Me.txtCOSTO_UNITARIO.TabIndex = 4
        Me.txtCOSTO_UNITARIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCANTIDAD
        '
        Me.txtCANTIDAD.BackColor = System.Drawing.SystemColors.Window
        Me.txtCANTIDAD.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCANTIDAD.ForeColor = System.Drawing.Color.Navy
        Me.txtCANTIDAD.Location = New System.Drawing.Point(481, 192)
        Me.txtCANTIDAD.Name = "txtCANTIDAD"
        Me.txtCANTIDAD.Size = New System.Drawing.Size(77, 22)
        Me.txtCANTIDAD.TabIndex = 3
        Me.txtCANTIDAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDESCRIPCION_PRODUCTO
        '
        Me.txtDESCRIPCION_PRODUCTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION_PRODUCTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_PRODUCTO.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_PRODUCTO.Location = New System.Drawing.Point(96, 192)
        Me.txtDESCRIPCION_PRODUCTO.Name = "txtDESCRIPCION_PRODUCTO"
        Me.txtDESCRIPCION_PRODUCTO.Size = New System.Drawing.Size(281, 22)
        Me.txtDESCRIPCION_PRODUCTO.TabIndex = 1
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.Location = New System.Drawing.Point(72, 192)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto.TabIndex = 20
        Me.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Teal
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(8, 168)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(679, 20)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Producto                                            Descripción                  " & _
            "                                 Unidad Medida         Cantidad          Costo U" & _
            "nit.      Servicio"
        '
        'txtPRODUCTO
        '
        Me.txtPRODUCTO.BackColor = System.Drawing.Color.White
        Me.txtPRODUCTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRODUCTO.ForeColor = System.Drawing.Color.Red
        Me.txtPRODUCTO.Location = New System.Drawing.Point(8, 192)
        Me.txtPRODUCTO.Name = "txtPRODUCTO"
        Me.txtPRODUCTO.Size = New System.Drawing.Size(64, 22)
        Me.txtPRODUCTO.TabIndex = 0
        '
        'dgvDetalleOC
        '
        Me.dgvDetalleOC.AllowUserToAddRows = False
        Me.dgvDetalleOC.AllowUserToDeleteRows = False
        Me.dgvDetalleOC.AllowUserToResizeColumns = False
        Me.dgvDetalleOC.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvDetalleOC.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetalleOC.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvDetalleOC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleOC.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetalleOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleOC.ContextMenuStrip = Me.cmMenu
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalleOC.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDetalleOC.Location = New System.Drawing.Point(8, 218)
        Me.dgvDetalleOC.Name = "dgvDetalleOC"
        Me.dgvDetalleOC.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleOC.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDetalleOC.RowHeadersVisible = False
        Me.dgvDetalleOC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleOC.Size = New System.Drawing.Size(709, 174)
        Me.dgvDetalleOC.TabIndex = 9
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
        'GrbProveedor
        '
        Me.GrbProveedor.BackColor = System.Drawing.Color.Transparent
        Me.GrbProveedor.Controls.Add(Me.lblMensaje)
        Me.GrbProveedor.Controls.Add(Me.chkPercep)
        Me.GrbProveedor.Controls.Add(Me.Label6)
        Me.GrbProveedor.Controls.Add(Me.chkAjustarInv)
        Me.GrbProveedor.Controls.Add(Me.txtOC)
        Me.GrbProveedor.Controls.Add(Me.txtCCF)
        Me.GrbProveedor.Controls.Add(Me.Label4)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_NombreComercial)
        Me.GrbProveedor.Controls.Add(Me.BtnBuscar)
        Me.GrbProveedor.Controls.Add(Me.lblPORCENTAJE_PERCEPCION)
        Me.GrbProveedor.Controls.Add(Me.BtnLimpiar)
        Me.GrbProveedor.Controls.Add(Me.Label2)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_Direccion)
        Me.GrbProveedor.Controls.Add(Me.Label10)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_Nit)
        Me.GrbProveedor.Controls.Add(Me.Label3)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_RegistroFiscal)
        Me.GrbProveedor.Controls.Add(Me.Label8)
        Me.GrbProveedor.Controls.Add(Me.Label11)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_NombreLegal)
        Me.GrbProveedor.Controls.Add(Me.TxtProveedor_Codigo)
        Me.GrbProveedor.Controls.Add(Me.Label12)
        Me.GrbProveedor.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrbProveedor.ForeColor = System.Drawing.Color.Navy
        Me.GrbProveedor.Location = New System.Drawing.Point(8, 8)
        Me.GrbProveedor.Name = "GrbProveedor"
        Me.GrbProveedor.Size = New System.Drawing.Size(712, 152)
        Me.GrbProveedor.TabIndex = 0
        Me.GrbProveedor.TabStop = False
        Me.GrbProveedor.Text = "Seleccionar Proveedor"
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.BackColor = System.Drawing.Color.Transparent
        Me.lblMensaje.Font = New System.Drawing.Font("Arial Black", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.Firebrick
        Me.lblMensaje.Location = New System.Drawing.Point(431, 75)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(271, 17)
        Me.lblMensaje.TabIndex = 48
        Me.lblMensaje.Text = "NOTA DE CREDITO YA FUE PROCESADA"
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMensaje.Visible = False
        '
        'chkPercep
        '
        Me.chkPercep.AutoSize = True
        Me.chkPercep.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPercep.ForeColor = System.Drawing.Color.Red
        Me.chkPercep.Location = New System.Drawing.Point(430, 96)
        Me.chkPercep.Name = "chkPercep"
        Me.chkPercep.Size = New System.Drawing.Size(121, 20)
        Me.chkPercep.TabIndex = 47
        Me.chkPercep.Text = "Quitar Percepción"
        Me.chkPercep.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(431, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 16)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Orden Compra #"
        '
        'chkAjustarInv
        '
        Me.chkAjustarInv.AutoSize = True
        Me.chkAjustarInv.Checked = True
        Me.chkAjustarInv.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAjustarInv.Location = New System.Drawing.Point(431, 25)
        Me.chkAjustarInv.Name = "chkAjustarInv"
        Me.chkAjustarInv.Size = New System.Drawing.Size(127, 20)
        Me.chkAjustarInv.TabIndex = 2
        Me.chkAjustarInv.Text = "Afectar Inventarios"
        Me.chkAjustarInv.UseVisualStyleBackColor = True
        '
        'txtOC
        '
        Me.txtOC.AutoSize = True
        Me.txtOC.BackColor = System.Drawing.Color.Transparent
        Me.txtOC.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOC.ForeColor = System.Drawing.Color.Navy
        Me.txtOC.Location = New System.Drawing.Point(521, 51)
        Me.txtOC.Name = "txtOC"
        Me.txtOC.Size = New System.Drawing.Size(16, 20)
        Me.txtOC.TabIndex = 45
        Me.txtOC.Text = "0"
        Me.txtOC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCCF
        '
        Me.txtCCF.Location = New System.Drawing.Point(314, 24)
        Me.txtCCF.Name = "txtCCF"
        Me.txtCCF.Size = New System.Drawing.Size(110, 22)
        Me.txtCCF.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(254, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "No. C.C.F.:"
        '
        'TxtProveedor_NombreComercial
        '
        Me.TxtProveedor_NombreComercial.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_NombreComercial.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_NombreComercial.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_NombreComercial.Location = New System.Drawing.Point(106, 72)
        Me.TxtProveedor_NombreComercial.Name = "TxtProveedor_NombreComercial"
        Me.TxtProveedor_NombreComercial.ReadOnly = True
        Me.TxtProveedor_NombreComercial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtProveedor_NombreComercial.Size = New System.Drawing.Size(318, 22)
        Me.TxtProveedor_NombreComercial.TabIndex = 4
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(200, 24)
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
        Me.lblPORCENTAJE_PERCEPCION.Location = New System.Drawing.Point(684, 17)
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
        Me.BtnLimpiar.Location = New System.Drawing.Point(224, 24)
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
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Direccion"
        '
        'TxtProveedor_Direccion
        '
        Me.TxtProveedor_Direccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_Direccion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Direccion.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_Direccion.Location = New System.Drawing.Point(104, 120)
        Me.TxtProveedor_Direccion.Name = "TxtProveedor_Direccion"
        Me.TxtProveedor_Direccion.ReadOnly = True
        Me.TxtProveedor_Direccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtProveedor_Direccion.Size = New System.Drawing.Size(592, 22)
        Me.TxtProveedor_Direccion.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 16)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Nombre Comercial"
        '
        'TxtProveedor_Nit
        '
        Me.TxtProveedor_Nit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_Nit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Nit.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_Nit.Location = New System.Drawing.Point(296, 96)
        Me.TxtProveedor_Nit.MaxLength = 17
        Me.TxtProveedor_Nit.Name = "TxtProveedor_Nit"
        Me.TxtProveedor_Nit.ReadOnly = True
        Me.TxtProveedor_Nit.Size = New System.Drawing.Size(128, 22)
        Me.TxtProveedor_Nit.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(264, 96)
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
        Me.TxtProveedor_RegistroFiscal.Location = New System.Drawing.Point(106, 96)
        Me.TxtProveedor_RegistroFiscal.MaxLength = 20
        Me.TxtProveedor_RegistroFiscal.Name = "TxtProveedor_RegistroFiscal"
        Me.TxtProveedor_RegistroFiscal.ReadOnly = True
        Me.TxtProveedor_RegistroFiscal.Size = New System.Drawing.Size(126, 22)
        Me.TxtProveedor_RegistroFiscal.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 16)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Registro Fiscal"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Nombre Legal"
        '
        'TxtProveedor_NombreLegal
        '
        Me.TxtProveedor_NombreLegal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtProveedor_NombreLegal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_NombreLegal.ForeColor = System.Drawing.Color.Navy
        Me.TxtProveedor_NombreLegal.Location = New System.Drawing.Point(106, 48)
        Me.TxtProveedor_NombreLegal.Name = "TxtProveedor_NombreLegal"
        Me.TxtProveedor_NombreLegal.ReadOnly = True
        Me.TxtProveedor_NombreLegal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtProveedor_NombreLegal.Size = New System.Drawing.Size(318, 22)
        Me.TxtProveedor_NombreLegal.TabIndex = 3
        '
        'TxtProveedor_Codigo
        '
        Me.TxtProveedor_Codigo.BackColor = System.Drawing.Color.White
        Me.TxtProveedor_Codigo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor_Codigo.ForeColor = System.Drawing.Color.Red
        Me.TxtProveedor_Codigo.Location = New System.Drawing.Point(106, 24)
        Me.TxtProveedor_Codigo.Name = "TxtProveedor_Codigo"
        Me.TxtProveedor_Codigo.Size = New System.Drawing.Size(94, 22)
        Me.TxtProveedor_Codigo.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(8, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 16)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Proveedor"
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Información"
        '
        'Contabilidad_NotaCreditoCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 610)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gbGral)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_NotaCreditoCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notas de Crédito Por Compras"
        Me.gbGral.ResumeLayout(False)
        Me.gbGral.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.tabDatos.PerformLayout()
        CType(Me.dgvDetalleOC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmMenu.ResumeLayout(False)
        Me.GrbProveedor.ResumeLayout(False)
        Me.GrbProveedor.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbGral As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents dpFECHA_NC As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents TxtProveedor_Nit As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_RegistroFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtProveedor_NombreLegal As System.Windows.Forms.TextBox
    Friend WithEvents TxtProveedor_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotalFact As System.Windows.Forms.TextBox
    Friend WithEvents txtPercepcion As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardarDetalle As System.Windows.Forms.Button
    Friend WithEvents cmbUNIDAD_MEDIDA As System.Windows.Forms.ComboBox
    Friend WithEvents txtCOSTO_UNITARIO As System.Windows.Forms.TextBox
    Friend WithEvents txtCANTIDAD As System.Windows.Forms.TextBox
    Friend WithEvents txtDESCRIPCION_PRODUCTO As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPRODUCTO As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalleOC As System.Windows.Forms.DataGridView
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkSERVICIO As System.Windows.Forms.CheckBox
    Friend WithEvents btnLimpiarProducto As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarOC As System.Windows.Forms.Button
    Friend WithEvents lblPORCENTAJE_PERCEPCION As System.Windows.Forms.Label
    Friend WithEvents cmMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMenu_Eliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtOBSERVACIONES As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents bntEliminar As System.Windows.Forms.Button
    Friend WithEvents lblCompañia As System.Windows.Forms.Label
    Friend WithEvents txtNC As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCCF As System.Windows.Forms.TextBox
    Friend WithEvents txtOC As System.Windows.Forms.Label
    Friend WithEvents chkAjustarInv As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkPercep As System.Windows.Forms.CheckBox
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
End Class
