<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Productos_PrecioEspecial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Productos_PrecioEspecial))
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblid = New System.Windows.Forms.Label
        Me.lblregistro = New System.Windows.Forms.Label
        Me.lblDESCRIPCION_PRODUCTO_PB = New System.Windows.Forms.Label
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.lblPRODUCTO_PB = New System.Windows.Forms.TextBox
        Me.btnBuscar_PB = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtcantidad = New System.Windows.Forms.TextBox
        Me.lblprecioespecial = New System.Windows.Forms.Label
        Me.txtprecio = New System.Windows.Forms.TextBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.dgvproductos = New System.Windows.Forms.DataGridView
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.lblExistencias = New System.Windows.Forms.Label
        Me.bntNuevo = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblExistencias_PE = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvproductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Items.AddRange(New Object() {"Despensa Planta #1", "Despensa Zapotitán", "Almacén Planta #1"})
        Me.cmbBODEGA.Location = New System.Drawing.Point(71, 42)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(264, 24)
        Me.cmbBODEGA.TabIndex = 91
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(9, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 16)
        Me.Label10.TabIndex = 92
        Me.Label10.Text = "Bodega :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(9, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 16)
        Me.Label18.TabIndex = 90
        Me.Label18.Text = "Compañía :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblid)
        Me.GroupBox1.Controls.Add(Me.lblregistro)
        Me.GroupBox1.Controls.Add(Me.lblDESCRIPCION_PRODUCTO_PB)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.lblPRODUCTO_PB)
        Me.GroupBox1.Controls.Add(Me.btnBuscar_PB)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(4, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(609, 104)
        Me.GroupBox1.TabIndex = 94
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos "
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(357, 46)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(11, 13)
        Me.lblid.TabIndex = 109
        Me.lblid.Text = "-"
        Me.lblid.Visible = False
        '
        'lblregistro
        '
        Me.lblregistro.AutoSize = True
        Me.lblregistro.Location = New System.Drawing.Point(467, 46)
        Me.lblregistro.Name = "lblregistro"
        Me.lblregistro.Size = New System.Drawing.Size(16, 13)
        Me.lblregistro.TabIndex = 108
        Me.lblregistro.Text = "N"
        Me.lblregistro.Visible = False
        '
        'lblDESCRIPCION_PRODUCTO_PB
        '
        Me.lblDESCRIPCION_PRODUCTO_PB.BackColor = System.Drawing.Color.LightBlue
        Me.lblDESCRIPCION_PRODUCTO_PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDESCRIPCION_PRODUCTO_PB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDESCRIPCION_PRODUCTO_PB.ForeColor = System.Drawing.Color.Black
        Me.lblDESCRIPCION_PRODUCTO_PB.Location = New System.Drawing.Point(170, 71)
        Me.lblDESCRIPCION_PRODUCTO_PB.Name = "lblDESCRIPCION_PRODUCTO_PB"
        Me.lblDESCRIPCION_PRODUCTO_PB.Size = New System.Drawing.Size(344, 20)
        Me.lblDESCRIPCION_PRODUCTO_PB.TabIndex = 0
        Me.lblDESCRIPCION_PRODUCTO_PB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(71, 15)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(529, 21)
        Me.cmbCOMPAÑIA.TabIndex = 98
        '
        'lblPRODUCTO_PB
        '
        Me.lblPRODUCTO_PB.BackColor = System.Drawing.SystemColors.Window
        Me.lblPRODUCTO_PB.Enabled = False
        Me.lblPRODUCTO_PB.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPRODUCTO_PB.ForeColor = System.Drawing.Color.Navy
        Me.lblPRODUCTO_PB.Location = New System.Drawing.Point(71, 70)
        Me.lblPRODUCTO_PB.Name = "lblPRODUCTO_PB"
        Me.lblPRODUCTO_PB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lblPRODUCTO_PB.Size = New System.Drawing.Size(92, 22)
        Me.lblPRODUCTO_PB.TabIndex = 95
        '
        'btnBuscar_PB
        '
        Me.btnBuscar_PB.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnBuscar_PB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar_PB.Image = CType(resources.GetObject("btnBuscar_PB.Image"), System.Drawing.Image)
        Me.btnBuscar_PB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar_PB.Location = New System.Drawing.Point(527, 69)
        Me.btnBuscar_PB.Name = "btnBuscar_PB"
        Me.btnBuscar_PB.Size = New System.Drawing.Size(72, 24)
        Me.btnBuscar_PB.TabIndex = 96
        Me.btnBuscar_PB.Text = "Buscar"
        Me.btnBuscar_PB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar_PB.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(9, 69)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 16)
        Me.Label17.TabIndex = 94
        Me.Label17.Text = "Producto :"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 28)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Existencias con precio normal: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label2.Location = New System.Drawing.Point(131, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 96
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(276, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Cantidad: "
        '
        'txtcantidad
        '
        Me.txtcantidad.Location = New System.Drawing.Point(327, 134)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(52, 20)
        Me.txtcantidad.TabIndex = 100
        '
        'lblprecioespecial
        '
        Me.lblprecioespecial.AutoSize = True
        Me.lblprecioespecial.Location = New System.Drawing.Point(384, 138)
        Me.lblprecioespecial.Name = "lblprecioespecial"
        Me.lblprecioespecial.Size = New System.Drawing.Size(82, 13)
        Me.lblprecioespecial.TabIndex = 101
        Me.lblprecioespecial.Text = "Precio especial:"
        '
        'txtprecio
        '
        Me.txtprecio.Location = New System.Drawing.Point(466, 134)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.Size = New System.Drawing.Size(49, 20)
        Me.txtprecio.TabIndex = 102
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(552, 132)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(27, 24)
        Me.btnGuardar.TabIndex = 103
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'dgvproductos
        '
        Me.dgvproductos.AllowUserToAddRows = False
        Me.dgvproductos.AllowUserToDeleteRows = False
        Me.dgvproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvproductos.Location = New System.Drawing.Point(9, 170)
        Me.dgvproductos.MultiSelect = False
        Me.dgvproductos.Name = "dgvproductos"
        Me.dgvproductos.ReadOnly = True
        Me.dgvproductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvproductos.Size = New System.Drawing.Size(595, 175)
        Me.dgvproductos.TabIndex = 104
        '
        'BtnDelete
        '
        Me.BtnDelete.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelete.Location = New System.Drawing.Point(583, 132)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(24, 24)
        Me.BtnDelete.TabIndex = 105
        Me.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'lblExistencias
        '
        Me.lblExistencias.BackColor = System.Drawing.Color.LightBlue
        Me.lblExistencias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExistencias.ForeColor = System.Drawing.Color.Black
        Me.lblExistencias.Location = New System.Drawing.Point(95, 133)
        Me.lblExistencias.Name = "lblExistencias"
        Me.lblExistencias.Size = New System.Drawing.Size(48, 20)
        Me.lblExistencias.TabIndex = 106
        Me.lblExistencias.Text = "0.00"
        Me.lblExistencias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bntNuevo
        '
        Me.bntNuevo.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.bntNuevo.Location = New System.Drawing.Point(522, 131)
        Me.bntNuevo.Name = "bntNuevo"
        Me.bntNuevo.Size = New System.Drawing.Size(25, 25)
        Me.bntNuevo.TabIndex = 107
        Me.bntNuevo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(146, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 36)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Existencias a precio especial:"
        '
        'lblExistencias_PE
        '
        Me.lblExistencias_PE.BackColor = System.Drawing.Color.LightBlue
        Me.lblExistencias_PE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExistencias_PE.ForeColor = System.Drawing.Color.Black
        Me.lblExistencias_PE.Location = New System.Drawing.Point(227, 134)
        Me.lblExistencias_PE.Name = "lblExistencias_PE"
        Me.lblExistencias_PE.Size = New System.Drawing.Size(44, 20)
        Me.lblExistencias_PE.TabIndex = 109
        Me.lblExistencias_PE.Text = "0.00"
        Me.lblExistencias_PE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Inventario_Productos_PrecioEspecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 357)
        Me.Controls.Add(Me.lblExistencias_PE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.bntNuevo)
        Me.Controls.Add(Me.lblExistencias)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.dgvproductos)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtprecio)
        Me.Controls.Add(Me.lblprecioespecial)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "Inventario_Productos_PrecioEspecial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Establecer productos con precio especial"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvproductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPRODUCTO_PB As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar_PB As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents lblprecioespecial As System.Windows.Forms.Label
    Friend WithEvents txtprecio As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents dgvproductos As System.Windows.Forms.DataGridView
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents lblDESCRIPCION_PRODUCTO_PB As System.Windows.Forms.Label
    Friend WithEvents lblExistencias As System.Windows.Forms.Label
    Friend WithEvents bntNuevo As System.Windows.Forms.Button
    Friend WithEvents lblregistro As System.Windows.Forms.Label
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblExistencias_PE As System.Windows.Forms.Label
End Class
