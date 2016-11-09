<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_BusquedaProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_BusquedaProductos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.cmbGRUPO = New System.Windows.Forms.ComboBox
        Me.txtDescripProducto = New System.Windows.Forms.TextBox
        Me.dgvProductos = New System.Windows.Forms.DataGridView
        Me.ProductoNum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion_ProductoNum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unidad_Medida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unidad_Libra = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Servicio = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Tipo_Costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Margen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Usuario_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkServicio = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCompañia)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(528, 56)
        Me.GroupBox1.TabIndex = 83
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(76, 22)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(428, 22)
        Me.txtCompañia.TabIndex = 24
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
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(14, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(528, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Grupo                                                   Descripción Producto"
        '
        'btnBuscar
        '
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(595, 94)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbGRUPO
        '
        Me.cmbGRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGRUPO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGRUPO.ForeColor = System.Drawing.Color.Navy
        Me.cmbGRUPO.FormattingEnabled = True
        Me.cmbGRUPO.Location = New System.Drawing.Point(14, 96)
        Me.cmbGRUPO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbGRUPO.Name = "cmbGRUPO"
        Me.cmbGRUPO.Size = New System.Drawing.Size(184, 24)
        Me.cmbGRUPO.TabIndex = 0
        '
        'txtDescripProducto
        '
        Me.txtDescripProducto.Location = New System.Drawing.Point(198, 96)
        Me.txtDescripProducto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDescripProducto.MaxLength = 200
        Me.txtDescripProducto.Name = "txtDescripProducto"
        Me.txtDescripProducto.Size = New System.Drawing.Size(320, 22)
        Me.txtDescripProducto.TabIndex = 1
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.AllowUserToResizeColumns = False
        Me.dgvProductos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvProductos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductoNum, Me.Descripcion_ProductoNum, Me.Unidad_Medida, Me.Unidad_Libra, Me.Servicio, Me.Tipo_Costo, Me.Margen, Me.Usuario_Creacion, Me.Fecha_Creacion})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProductos.Location = New System.Drawing.Point(16, 120)
        Me.dgvProductos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProductos.RowHeadersVisible = False
        Me.dgvProductos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductos.Size = New System.Drawing.Size(739, 408)
        Me.dgvProductos.TabIndex = 87
        '
        'ProductoNum
        '
        Me.ProductoNum.HeaderText = "Producto"
        Me.ProductoNum.Name = "ProductoNum"
        Me.ProductoNum.ReadOnly = True
        '
        'Descripcion_ProductoNum
        '
        Me.Descripcion_ProductoNum.HeaderText = "Descripción Producto"
        Me.Descripcion_ProductoNum.Name = "Descripcion_ProductoNum"
        Me.Descripcion_ProductoNum.ReadOnly = True
        '
        'Unidad_Medida
        '
        Me.Unidad_Medida.HeaderText = "Unidad Medida"
        Me.Unidad_Medida.Name = "Unidad_Medida"
        Me.Unidad_Medida.ReadOnly = True
        '
        'Unidad_Libra
        '
        Me.Unidad_Libra.HeaderText = "Unidad Libra"
        Me.Unidad_Libra.Name = "Unidad_Libra"
        Me.Unidad_Libra.ReadOnly = True
        '
        'Servicio
        '
        Me.Servicio.HeaderText = "Servicio"
        Me.Servicio.Name = "Servicio"
        Me.Servicio.ReadOnly = True
        '
        'Tipo_Costo
        '
        Me.Tipo_Costo.HeaderText = "Tipo Costo"
        Me.Tipo_Costo.Name = "Tipo_Costo"
        Me.Tipo_Costo.ReadOnly = True
        '
        'Margen
        '
        Me.Margen.HeaderText = "Margen"
        Me.Margen.Name = "Margen"
        Me.Margen.ReadOnly = True
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
        'chkServicio
        '
        Me.chkServicio.AutoSize = True
        Me.chkServicio.Location = New System.Drawing.Point(524, 98)
        Me.chkServicio.Name = "chkServicio"
        Me.chkServicio.Size = New System.Drawing.Size(65, 20)
        Me.chkServicio.TabIndex = 88
        Me.chkServicio.Text = "Servicio"
        Me.chkServicio.UseVisualStyleBackColor = True
        '
        'Inventario_BusquedaProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 533)
        Me.Controls.Add(Me.chkServicio)
        Me.Controls.Add(Me.dgvProductos)
        Me.Controls.Add(Me.txtDescripProducto)
        Me.Controls.Add(Me.cmbGRUPO)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Inventario_BusquedaProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario - Búsqueda de Productos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cmbGRUPO As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescripProducto As System.Windows.Forms.TextBox
    Friend WithEvents dgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents ProductoNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion_ProductoNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad_Medida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad_Libra As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Servicio As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Tipo_Costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Margen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Creacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Creacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents chkServicio As System.Windows.Forms.CheckBox
End Class
