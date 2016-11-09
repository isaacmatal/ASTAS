<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Productos_Lotes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Productos_Lotes))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblPRODUCTO = New System.Windows.Forms.TextBox
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.cmbUNIDAD_MEDIDA = New System.Windows.Forms.ComboBox
        Me.dpFECHA_VENCIMIENTO = New System.Windows.Forms.DateTimePicker
        Me.chkTieneVencimiento = New System.Windows.Forms.CheckBox
        Me.txtDESCRIPCION_LOTE = New System.Windows.Forms.TextBox
        Me.txtLOTE = New System.Windows.Forms.TextBox
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.lblDESCRIPCION_PRODUCTO = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblLoteVencido = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.dgvLotes = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Usuario_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblPRODUCTO)
        Me.GroupBox3.Controls.Add(Me.txtCompañia)
        Me.GroupBox3.Controls.Add(Me.cmbUNIDAD_MEDIDA)
        Me.GroupBox3.Controls.Add(Me.dpFECHA_VENCIMIENTO)
        Me.GroupBox3.Controls.Add(Me.chkTieneVencimiento)
        Me.GroupBox3.Controls.Add(Me.txtDESCRIPCION_LOTE)
        Me.GroupBox3.Controls.Add(Me.txtLOTE)
        Me.GroupBox3.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox3.Controls.Add(Me.btnNuevo)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.btnBuscar)
        Me.GroupBox3.Controls.Add(Me.btnGuardar)
        Me.GroupBox3.Controls.Add(Me.btnEliminar)
        Me.GroupBox3.Controls.Add(Me.lblDESCRIPCION_PRODUCTO)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.lblLoteVencido)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox3.Location = New System.Drawing.Point(112, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(536, 176)
        Me.GroupBox3.TabIndex = 45
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Asignar Lotes /  Fechas de vencimiento a Productos por Bodega"
        '
        'lblPRODUCTO
        '
        Me.lblPRODUCTO.Location = New System.Drawing.Point(96, 74)
        Me.lblPRODUCTO.Name = "lblPRODUCTO"
        Me.lblPRODUCTO.Size = New System.Drawing.Size(100, 22)
        Me.lblPRODUCTO.TabIndex = 1
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(96, 24)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(431, 22)
        Me.txtCompañia.TabIndex = 92
        '
        'cmbUNIDAD_MEDIDA
        '
        Me.cmbUNIDAD_MEDIDA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUNIDAD_MEDIDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbUNIDAD_MEDIDA.Enabled = False
        Me.cmbUNIDAD_MEDIDA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUNIDAD_MEDIDA.ForeColor = System.Drawing.Color.Navy
        Me.cmbUNIDAD_MEDIDA.FormattingEnabled = True
        Me.cmbUNIDAD_MEDIDA.Items.AddRange(New Object() {"Crédito 30 días", "Crédito 60 días", "Crédito 90 días"})
        Me.cmbUNIDAD_MEDIDA.Location = New System.Drawing.Point(417, 96)
        Me.cmbUNIDAD_MEDIDA.Name = "cmbUNIDAD_MEDIDA"
        Me.cmbUNIDAD_MEDIDA.Size = New System.Drawing.Size(110, 21)
        Me.cmbUNIDAD_MEDIDA.TabIndex = 91
        '
        'dpFECHA_VENCIMIENTO
        '
        Me.dpFECHA_VENCIMIENTO.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_VENCIMIENTO.Enabled = False
        Me.dpFECHA_VENCIMIENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.dpFECHA_VENCIMIENTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_VENCIMIENTO.Location = New System.Drawing.Point(416, 120)
        Me.dpFECHA_VENCIMIENTO.Name = "dpFECHA_VENCIMIENTO"
        Me.dpFECHA_VENCIMIENTO.Size = New System.Drawing.Size(112, 22)
        Me.dpFECHA_VENCIMIENTO.TabIndex = 4
        '
        'chkTieneVencimiento
        '
        Me.chkTieneVencimiento.AutoSize = True
        Me.chkTieneVencimiento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTieneVencimiento.ForeColor = System.Drawing.Color.Red
        Me.chkTieneVencimiento.Location = New System.Drawing.Point(304, 120)
        Me.chkTieneVencimiento.Name = "chkTieneVencimiento"
        Me.chkTieneVencimiento.Size = New System.Drawing.Size(113, 20)
        Me.chkTieneVencimiento.TabIndex = 89
        Me.chkTieneVencimiento.Text = "Tiene Vencimiento"
        Me.chkTieneVencimiento.UseVisualStyleBackColor = True
        '
        'txtDESCRIPCION_LOTE
        '
        Me.txtDESCRIPCION_LOTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION_LOTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_LOTE.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_LOTE.Location = New System.Drawing.Point(96, 144)
        Me.txtDESCRIPCION_LOTE.MaxLength = 100
        Me.txtDESCRIPCION_LOTE.Name = "txtDESCRIPCION_LOTE"
        Me.txtDESCRIPCION_LOTE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION_LOTE.Size = New System.Drawing.Size(432, 22)
        Me.txtDESCRIPCION_LOTE.TabIndex = 5
        '
        'txtLOTE
        '
        Me.txtLOTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtLOTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLOTE.ForeColor = System.Drawing.Color.Navy
        Me.txtLOTE.Location = New System.Drawing.Point(96, 120)
        Me.txtLOTE.MaxLength = 25
        Me.txtLOTE.Name = "txtLOTE"
        Me.txtLOTE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLOTE.Size = New System.Drawing.Size(120, 22)
        Me.txtLOTE.TabIndex = 3
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Items.AddRange(New Object() {"Despensa Planta #1", "Despensa Zapotitán", "Almacén Planta #1"})
        Me.cmbBODEGA.Location = New System.Drawing.Point(96, 48)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(264, 24)
        Me.cmbBODEGA.TabIndex = 0
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(216, 120)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnNuevo.TabIndex = 87
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 16)
        Me.Label10.TabIndex = 82
        Me.Label10.Text = "Bodega :"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(202, 72)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(240, 120)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(264, 120)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(24, 24)
        Me.btnEliminar.TabIndex = 73
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblDESCRIPCION_PRODUCTO
        '
        Me.lblDESCRIPCION_PRODUCTO.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDESCRIPCION_PRODUCTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDESCRIPCION_PRODUCTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDESCRIPCION_PRODUCTO.ForeColor = System.Drawing.Color.Navy
        Me.lblDESCRIPCION_PRODUCTO.Location = New System.Drawing.Point(96, 96)
        Me.lblDESCRIPCION_PRODUCTO.Name = "lblDESCRIPCION_PRODUCTO"
        Me.lblDESCRIPCION_PRODUCTO.Size = New System.Drawing.Size(320, 22)
        Me.lblDESCRIPCION_PRODUCTO.TabIndex = 6
        Me.lblDESCRIPCION_PRODUCTO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Descripción :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(416, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Unidad Medida"
        '
        'lblLoteVencido
        '
        Me.lblLoteVencido.AutoSize = True
        Me.lblLoteVencido.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoteVencido.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoteVencido.Location = New System.Drawing.Point(8, 120)
        Me.lblLoteVencido.Name = "lblLoteVencido"
        Me.lblLoteVencido.Size = New System.Drawing.Size(34, 16)
        Me.lblLoteVencido.TabIndex = 2
        Me.lblLoteVencido.Text = "Lote :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Descripción :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(8, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 16)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "Producto :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(8, 24)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 16)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Compañía :"
        '
        'dgvLotes
        '
        Me.dgvLotes.AllowUserToAddRows = False
        Me.dgvLotes.AllowUserToDeleteRows = False
        Me.dgvLotes.AllowUserToResizeColumns = False
        Me.dgvLotes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvLotes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Usuario_Creacion, Me.Fecha_Creacion})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLotes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLotes.Location = New System.Drawing.Point(8, 184)
        Me.dgvLotes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvLotes.Name = "dgvLotes"
        Me.dgvLotes.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLotes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLotes.Size = New System.Drawing.Size(640, 240)
        Me.dgvLotes.TabIndex = 94
        '
        'Column1
        '
        Me.Column1.HeaderText = "Lote"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripción Lote"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Vencimiento"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Unidad Medida"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Existencia"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Libras"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Usuario_Creacion
        '
        Me.Usuario_Creacion.HeaderText = "Usuario Creación"
        Me.Usuario_Creacion.Name = "Usuario_Creacion"
        Me.Usuario_Creacion.ReadOnly = True
        '
        'Fecha_Creacion
        '
        Me.Fecha_Creacion.HeaderText = "Fecha Creación"
        Me.Fecha_Creacion.Name = "Fecha_Creacion"
        Me.Fecha_Creacion.ReadOnly = True
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(0, 8)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(112, 168)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 95
        Me.pbImagen.TabStop = False
        '
        'Inventario_Productos_Lotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 428)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.dgvLotes)
        Me.Controls.Add(Me.GroupBox3)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Inventario_Productos_Lotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario - Catálogo de Lotes por Producto / Bodega"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblDESCRIPCION_PRODUCTO As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtLOTE As System.Windows.Forms.TextBox
    Friend WithEvents chkTieneVencimiento As System.Windows.Forms.CheckBox
    Friend WithEvents dpFECHA_VENCIMIENTO As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvLotes As System.Windows.Forms.DataGridView
    Friend WithEvents txtDESCRIPCION_LOTE As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents cmbUNIDAD_MEDIDA As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoteVencido As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Creacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Creacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents lblPRODUCTO As System.Windows.Forms.TextBox
End Class
