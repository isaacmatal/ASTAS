<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Regalias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Regalias))
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtFecha = New System.Windows.Forms.TextBox
        Me.txtNombreProveedor = New System.Windows.Forms.TextBox
        Me.txtBodega = New System.Windows.Forms.TextBox
        Me.txtCodProv = New System.Windows.Forms.TextBox
        Me.txtOc = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.bntEliminar = New System.Windows.Forms.Button
        Me.txtPRODUCTO = New System.Windows.Forms.TextBox
        Me.btnBuscarProducto = New System.Windows.Forms.Button
        Me.txtDESCRIPCION_PRODUCTO = New System.Windows.Forms.TextBox
        Me.txtCANTIDAD = New System.Windows.Forms.TextBox
        Me.txtLIBRAS = New System.Windows.Forms.TextBox
        Me.txtCOSTO_UNITARIO = New System.Windows.Forms.TextBox
        Me.cmbUNIDAD_MEDIDA = New System.Windows.Forms.ComboBox
        Me.btnGuardarDetalle = New System.Windows.Forms.Button
        Me.btnLimpiarProducto = New System.Windows.Forms.Button
        Me.dgvDetalleOC = New System.Windows.Forms.DataGridView
        Me.Prod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.numProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescUM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CantidadProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConIVA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miMenu_Eliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvDetalleOC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.txtNombreProveedor)
        Me.GroupBox1.Controls.Add(Me.txtBodega)
        Me.GroupBox1.Controls.Add(Me.txtCodProv)
        Me.GroupBox1.Controls.Add(Me.txtOc)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(556, 127)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Agregar Regalias"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(117, 74)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(280, 20)
        Me.txtFecha.TabIndex = 10
        '
        'txtNombreProveedor
        '
        Me.txtNombreProveedor.Location = New System.Drawing.Point(175, 50)
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.ReadOnly = True
        Me.txtNombreProveedor.Size = New System.Drawing.Size(222, 20)
        Me.txtNombreProveedor.TabIndex = 9
        '
        'txtBodega
        '
        Me.txtBodega.Location = New System.Drawing.Point(117, 98)
        Me.txtBodega.Name = "txtBodega"
        Me.txtBodega.ReadOnly = True
        Me.txtBodega.Size = New System.Drawing.Size(280, 20)
        Me.txtBodega.TabIndex = 8
        '
        'txtCodProv
        '
        Me.txtCodProv.Location = New System.Drawing.Point(117, 49)
        Me.txtCodProv.Name = "txtCodProv"
        Me.txtCodProv.ReadOnly = True
        Me.txtCodProv.Size = New System.Drawing.Size(52, 20)
        Me.txtCodProv.TabIndex = 7
        '
        'txtOc
        '
        Me.txtOc.Location = New System.Drawing.Point(117, 25)
        Me.txtOc.Name = "txtOc"
        Me.txtOc.ReadOnly = True
        Me.txtOc.Size = New System.Drawing.Size(52, 20)
        Me.txtOc.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Bodega"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Proveedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Orden de Compra"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(429, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 22)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Nuevo producto"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.bntEliminar)
        Me.GroupBox2.Controls.Add(Me.txtPRODUCTO)
        Me.GroupBox2.Controls.Add(Me.btnBuscarProducto)
        Me.GroupBox2.Controls.Add(Me.txtDESCRIPCION_PRODUCTO)
        Me.GroupBox2.Controls.Add(Me.txtCANTIDAD)
        Me.GroupBox2.Controls.Add(Me.txtLIBRAS)
        Me.GroupBox2.Controls.Add(Me.txtCOSTO_UNITARIO)
        Me.GroupBox2.Controls.Add(Me.cmbUNIDAD_MEDIDA)
        Me.GroupBox2.Controls.Add(Me.btnGuardarDetalle)
        Me.GroupBox2.Controls.Add(Me.btnLimpiarProducto)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 145)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(759, 70)
        Me.GroupBox2.TabIndex = 46
        Me.GroupBox2.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Navy
        Me.TextBox1.Location = New System.Drawing.Point(631, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(64, 22)
        Me.TextBox1.TabIndex = 38
        Me.TextBox1.Text = "0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Teal
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(6, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(689, 20)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Producto                                            Descripción                  " & _
            "                                 Unidad Medida         Cantidad          Costo U" & _
            "nit.       Costo Total"
        '
        'bntEliminar
        '
        Me.bntEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.bntEliminar.Image = Global.ASTAS.My.Resources.Resources.editdelete
        Me.bntEliminar.Location = New System.Drawing.Point(701, 14)
        Me.bntEliminar.Name = "bntEliminar"
        Me.bntEliminar.Size = New System.Drawing.Size(24, 24)
        Me.bntEliminar.TabIndex = 32
        Me.bntEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bntEliminar.UseVisualStyleBackColor = True
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
        Me.txtDESCRIPCION_PRODUCTO.Size = New System.Drawing.Size(281, 22)
        Me.txtDESCRIPCION_PRODUCTO.TabIndex = 21
        '
        'txtCANTIDAD
        '
        Me.txtCANTIDAD.BackColor = System.Drawing.SystemColors.Window
        Me.txtCANTIDAD.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCANTIDAD.ForeColor = System.Drawing.Color.Navy
        Me.txtCANTIDAD.Location = New System.Drawing.Point(479, 42)
        Me.txtCANTIDAD.Name = "txtCANTIDAD"
        Me.txtCANTIDAD.Size = New System.Drawing.Size(77, 22)
        Me.txtCANTIDAD.TabIndex = 23
        Me.txtCANTIDAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLIBRAS
        '
        Me.txtLIBRAS.BackColor = System.Drawing.SystemColors.Window
        Me.txtLIBRAS.Enabled = False
        Me.txtLIBRAS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLIBRAS.ForeColor = System.Drawing.Color.Navy
        Me.txtLIBRAS.Location = New System.Drawing.Point(494, 42)
        Me.txtLIBRAS.Name = "txtLIBRAS"
        Me.txtLIBRAS.Size = New System.Drawing.Size(64, 22)
        Me.txtLIBRAS.TabIndex = 24
        Me.txtLIBRAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtLIBRAS.Visible = False
        '
        'txtCOSTO_UNITARIO
        '
        Me.txtCOSTO_UNITARIO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCOSTO_UNITARIO.Enabled = False
        Me.txtCOSTO_UNITARIO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOSTO_UNITARIO.ForeColor = System.Drawing.Color.Navy
        Me.txtCOSTO_UNITARIO.Location = New System.Drawing.Point(558, 42)
        Me.txtCOSTO_UNITARIO.Name = "txtCOSTO_UNITARIO"
        Me.txtCOSTO_UNITARIO.Size = New System.Drawing.Size(64, 22)
        Me.txtCOSTO_UNITARIO.TabIndex = 25
        Me.txtCOSTO_UNITARIO.Text = "0"
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
        Me.cmbUNIDAD_MEDIDA.Location = New System.Drawing.Point(375, 42)
        Me.cmbUNIDAD_MEDIDA.Name = "cmbUNIDAD_MEDIDA"
        Me.cmbUNIDAD_MEDIDA.Size = New System.Drawing.Size(104, 24)
        Me.cmbUNIDAD_MEDIDA.TabIndex = 33
        '
        'btnGuardarDetalle
        '
        Me.btnGuardarDetalle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarDetalle.Image = CType(resources.GetObject("btnGuardarDetalle.Image"), System.Drawing.Image)
        Me.btnGuardarDetalle.Location = New System.Drawing.Point(701, 38)
        Me.btnGuardarDetalle.Name = "btnGuardarDetalle"
        Me.btnGuardarDetalle.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardarDetalle.TabIndex = 26
        Me.btnGuardarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardarDetalle.UseVisualStyleBackColor = True
        '
        'btnLimpiarProducto
        '
        Me.btnLimpiarProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiarProducto.Image = CType(resources.GetObject("btnLimpiarProducto.Image"), System.Drawing.Image)
        Me.btnLimpiarProducto.Location = New System.Drawing.Point(725, 38)
        Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
        Me.btnLimpiarProducto.Size = New System.Drawing.Size(24, 24)
        Me.btnLimpiarProducto.TabIndex = 31
        Me.btnLimpiarProducto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiarProducto.UseVisualStyleBackColor = True
        '
        'dgvDetalleOC
        '
        Me.dgvDetalleOC.AllowUserToAddRows = False
        Me.dgvDetalleOC.AllowUserToDeleteRows = False
        Me.dgvDetalleOC.AllowUserToResizeColumns = False
        Me.dgvDetalleOC.AllowUserToResizeRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvDetalleOC.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDetalleOC.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetalleOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleOC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Prod, Me.numProd, Me.DescUM, Me.CantidadProd, Me.CU, Me.CT, Me.ConIVA, Me.Column1})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalleOC.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvDetalleOC.Location = New System.Drawing.Point(12, 221)
        Me.dgvDetalleOC.Name = "dgvDetalleOC"
        Me.dgvDetalleOC.ReadOnly = True
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleOC.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvDetalleOC.RowHeadersVisible = False
        Me.dgvDetalleOC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleOC.Size = New System.Drawing.Size(760, 162)
        Me.dgvDetalleOC.TabIndex = 47
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
        Me.numProd.Width = 175
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CantidadProd.DefaultCellStyle = DataGridViewCellStyle9
        Me.CantidadProd.HeaderText = "Cantidad"
        Me.CantidadProd.Name = "CantidadProd"
        Me.CantidadProd.ReadOnly = True
        Me.CantidadProd.Width = 70
        '
        'CU
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CU.DefaultCellStyle = DataGridViewCellStyle10
        Me.CU.HeaderText = "Costo Unit."
        Me.CU.Name = "CU"
        Me.CU.ReadOnly = True
        Me.CU.Width = 70
        '
        'CT
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.CT.DefaultCellStyle = DataGridViewCellStyle11
        Me.CT.HeaderText = "Sub Total"
        Me.CT.Name = "CT"
        Me.CT.ReadOnly = True
        Me.CT.Width = 70
        '
        'ConIVA
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ConIVA.DefaultCellStyle = DataGridViewCellStyle12
        Me.ConIVA.HeaderText = "Con IVA"
        Me.ConIVA.Name = "ConIVA"
        Me.ConIVA.ReadOnly = True
        Me.ConIVA.Width = 70
        '
        'Column1
        '
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
        'Inventario_Regalias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 389)
        Me.Controls.Add(Me.dgvDetalleOC)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Inventario_Regalias"
        Me.Text = "Inventario_Regalias"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvDetalleOC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents bntEliminar As System.Windows.Forms.Button
    Friend WithEvents txtPRODUCTO As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents txtDESCRIPCION_PRODUCTO As System.Windows.Forms.TextBox
    Friend WithEvents txtCANTIDAD As System.Windows.Forms.TextBox
    Friend WithEvents txtLIBRAS As System.Windows.Forms.TextBox
    Friend WithEvents txtCOSTO_UNITARIO As System.Windows.Forms.TextBox
    Friend WithEvents cmbUNIDAD_MEDIDA As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardarDetalle As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarProducto As System.Windows.Forms.Button
    Friend WithEvents dgvDetalleOC As System.Windows.Forms.DataGridView
    Friend WithEvents Prod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescUM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConIVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtBodega As System.Windows.Forms.TextBox
    Friend WithEvents txtCodProv As System.Windows.Forms.TextBox
    Friend WithEvents txtOc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMenu_Eliminar As System.Windows.Forms.ToolStripMenuItem
End Class
