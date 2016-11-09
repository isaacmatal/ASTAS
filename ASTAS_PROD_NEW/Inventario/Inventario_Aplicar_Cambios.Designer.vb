<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Aplicar_Cambios
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Public Sub New(ByVal pOC As Integer, ByVal PIDcompania As Integer)
        intpOC = pOC
        intpCompania = PIDcompania

        InitializeComponent()

    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtLibras = New System.Windows.Forms.TextBox
        Me.dtsOC = New System.Data.DataSet
        Me.tbldetoc = New System.Data.DataTable
        Me.DataColumn1 = New System.Data.DataColumn
        Me.DataColumn2 = New System.Data.DataColumn
        Me.DataColumn3 = New System.Data.DataColumn
        Me.DataColumn4 = New System.Data.DataColumn
        Me.DataColumn5 = New System.Data.DataColumn
        Me.DataColumn6 = New System.Data.DataColumn
        Me.DataColumn7 = New System.Data.DataColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtLinea = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnSalir = New System.Windows.Forms.Button
        Me.txtNuevoCostoUnitario = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCostoUnitario = New System.Windows.Forms.TextBox
        Me.txtNuevaCantidad = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtproducto = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.btnAplicar = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dtgOCdet = New System.Windows.Forms.DataGridView
        Me.LineaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProductoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescripcionProductoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CantidadDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostoUniDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibrasDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtsOC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbldetoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dtgOCdet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtLibras)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(768, 50)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Numero de Orden de Compra"
        '
        'txtLibras
        '
        Me.txtLibras.BackColor = System.Drawing.SystemColors.Control
        Me.txtLibras.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dtsOC, "tbldetoc.Libras", True))
        Me.txtLibras.ForeColor = System.Drawing.SystemColors.Control
        Me.txtLibras.Location = New System.Drawing.Point(697, 17)
        Me.txtLibras.Name = "txtLibras"
        Me.txtLibras.Size = New System.Drawing.Size(64, 20)
        Me.txtLibras.TabIndex = 8
        '
        'dtsOC
        '
        Me.dtsOC.DataSetName = "dtsOC"
        Me.dtsOC.Tables.AddRange(New System.Data.DataTable() {Me.tbldetoc})
        '
        'tbldetoc
        '
        Me.tbldetoc.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7})
        Me.tbldetoc.TableName = "tbldetoc"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "Linea"
        Me.DataColumn1.DataType = GetType(Integer)
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "Producto"
        Me.DataColumn2.DataType = GetType(Integer)
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "DescripcionProducto"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "Cantidad"
        Me.DataColumn4.DataType = GetType(Double)
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "CostoUni"
        Me.DataColumn5.DataType = GetType(Double)
        '
        'DataColumn6
        '
        Me.DataColumn6.ColumnName = "SubTotal"
        Me.DataColumn6.DataType = GetType(Double)
        '
        'DataColumn7
        '
        Me.DataColumn7.ColumnName = "Libras"
        Me.DataColumn7.DataType = GetType(Double)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(203, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 0
        '
        'txtLinea
        '
        Me.txtLinea.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dtsOC, "tbldetoc.Linea", True))
        Me.txtLinea.Location = New System.Drawing.Point(2, 34)
        Me.txtLinea.Name = "txtLinea"
        Me.txtLinea.ReadOnly = True
        Me.txtLinea.Size = New System.Drawing.Size(23, 20)
        Me.txtLinea.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtLinea)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.btnSalir)
        Me.GroupBox2.Controls.Add(Me.txtNuevoCostoUnitario)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtCostoUnitario)
        Me.GroupBox2.Controls.Add(Me.txtNuevaCantidad)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtCantidad)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtproducto)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtCodigo)
        Me.GroupBox2.Controls.Add(Me.btnAplicar)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(761, 64)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Location = New System.Drawing.Point(640, 19)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(51, 23)
        Me.btnEliminar.TabIndex = 55
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        Me.btnEliminar.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Teal
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Control
        Me.Label9.Location = New System.Drawing.Point(525, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "CostoUni"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(439, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Nueva Cant"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Teal
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(589, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "NuevoCosto"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(722, 33)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(37, 23)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtNuevoCostoUnitario
        '
        Me.txtNuevoCostoUnitario.Location = New System.Drawing.Point(596, 34)
        Me.txtNuevoCostoUnitario.Name = "txtNuevoCostoUnitario"
        Me.txtNuevoCostoUnitario.Size = New System.Drawing.Size(74, 20)
        Me.txtNuevoCostoUnitario.TabIndex = 1
        Me.txtNuevoCostoUnitario.Text = "0.00"
        Me.txtNuevoCostoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(368, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Cantidad"
        '
        'txtCostoUnitario
        '
        Me.txtCostoUnitario.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dtsOC, "tbldetoc.CostoUni", True))
        Me.txtCostoUnitario.Location = New System.Drawing.Point(527, 34)
        Me.txtCostoUnitario.Name = "txtCostoUnitario"
        Me.txtCostoUnitario.ReadOnly = True
        Me.txtCostoUnitario.Size = New System.Drawing.Size(68, 20)
        Me.txtCostoUnitario.TabIndex = 5
        '
        'txtNuevaCantidad
        '
        Me.txtNuevaCantidad.Location = New System.Drawing.Point(454, 34)
        Me.txtNuevaCantidad.Name = "txtNuevaCantidad"
        Me.txtNuevaCantidad.Size = New System.Drawing.Size(70, 20)
        Me.txtNuevaCantidad.TabIndex = 0
        Me.txtNuevaCantidad.Text = "0.00"
        Me.txtNuevaCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(183, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Producto"
        '
        'txtCantidad
        '
        Me.txtCantidad.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dtsOC, "tbldetoc.Cantidad", True))
        Me.txtCantidad.Location = New System.Drawing.Point(376, 34)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(77, 20)
        Me.txtCantidad.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Teal
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(32, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Codigo"
        '
        'txtproducto
        '
        Me.txtproducto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dtsOC, "tbldetoc.DescripcionProducto", True))
        Me.txtproducto.Location = New System.Drawing.Point(90, 34)
        Me.txtproducto.Name = "txtproducto"
        Me.txtproducto.ReadOnly = True
        Me.txtproducto.Size = New System.Drawing.Size(284, 20)
        Me.txtproducto.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Teal
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(-1, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(752, 20)
        Me.Label14.TabIndex = 46
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCodigo
        '
        Me.txtCodigo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dtsOC, "tbldetoc.Producto", True))
        Me.txtCodigo.Location = New System.Drawing.Point(27, 34)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(62, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(673, 33)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(47, 23)
        Me.btnAplicar.TabIndex = 0
        Me.btnAplicar.Text = "Aplicar"
        Me.btnAplicar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtgOCdet)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 148)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(768, 244)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'dtgOCdet
        '
        Me.dtgOCdet.AllowUserToAddRows = False
        Me.dtgOCdet.AllowUserToDeleteRows = False
        Me.dtgOCdet.AutoGenerateColumns = False
        Me.dtgOCdet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgOCdet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LineaDataGridViewTextBoxColumn, Me.ProductoDataGridViewTextBoxColumn, Me.DescripcionProductoDataGridViewTextBoxColumn, Me.CantidadDataGridViewTextBoxColumn, Me.CostoUniDataGridViewTextBoxColumn, Me.SubTotalDataGridViewTextBoxColumn, Me.LibrasDataGridViewTextBoxColumn})
        Me.dtgOCdet.DataMember = "tbldetoc"
        Me.dtgOCdet.DataSource = Me.dtsOC
        Me.dtgOCdet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgOCdet.Location = New System.Drawing.Point(3, 16)
        Me.dtgOCdet.Name = "dtgOCdet"
        Me.dtgOCdet.ReadOnly = True
        Me.dtgOCdet.Size = New System.Drawing.Size(762, 225)
        Me.dtgOCdet.TabIndex = 0
        '
        'LineaDataGridViewTextBoxColumn
        '
        Me.LineaDataGridViewTextBoxColumn.DataPropertyName = "Linea"
        Me.LineaDataGridViewTextBoxColumn.HeaderText = "Linea"
        Me.LineaDataGridViewTextBoxColumn.Name = "LineaDataGridViewTextBoxColumn"
        Me.LineaDataGridViewTextBoxColumn.ReadOnly = True
        Me.LineaDataGridViewTextBoxColumn.Visible = False
        '
        'ProductoDataGridViewTextBoxColumn
        '
        Me.ProductoDataGridViewTextBoxColumn.DataPropertyName = "Producto"
        Me.ProductoDataGridViewTextBoxColumn.HeaderText = "Producto"
        Me.ProductoDataGridViewTextBoxColumn.Name = "ProductoDataGridViewTextBoxColumn"
        Me.ProductoDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProductoDataGridViewTextBoxColumn.Width = 80
        '
        'DescripcionProductoDataGridViewTextBoxColumn
        '
        Me.DescripcionProductoDataGridViewTextBoxColumn.DataPropertyName = "DescripcionProducto"
        Me.DescripcionProductoDataGridViewTextBoxColumn.HeaderText = "DescripcionProducto"
        Me.DescripcionProductoDataGridViewTextBoxColumn.Name = "DescripcionProductoDataGridViewTextBoxColumn"
        Me.DescripcionProductoDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescripcionProductoDataGridViewTextBoxColumn.Width = 250
        '
        'CantidadDataGridViewTextBoxColumn
        '
        Me.CantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantidadDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.CantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad"
        Me.CantidadDataGridViewTextBoxColumn.Name = "CantidadDataGridViewTextBoxColumn"
        Me.CantidadDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CostoUniDataGridViewTextBoxColumn
        '
        Me.CostoUniDataGridViewTextBoxColumn.DataPropertyName = "CostoUni"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C6"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.CostoUniDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.CostoUniDataGridViewTextBoxColumn.HeaderText = "CostoUni"
        Me.CostoUniDataGridViewTextBoxColumn.Name = "CostoUniDataGridViewTextBoxColumn"
        Me.CostoUniDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SubTotalDataGridViewTextBoxColumn
        '
        Me.SubTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.SubTotalDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.SubTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal"
        Me.SubTotalDataGridViewTextBoxColumn.Name = "SubTotalDataGridViewTextBoxColumn"
        Me.SubTotalDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LibrasDataGridViewTextBoxColumn
        '
        Me.LibrasDataGridViewTextBoxColumn.DataPropertyName = "Libras"
        Me.LibrasDataGridViewTextBoxColumn.HeaderText = "Libras"
        Me.LibrasDataGridViewTextBoxColumn.Name = "LibrasDataGridViewTextBoxColumn"
        Me.LibrasDataGridViewTextBoxColumn.ReadOnly = True
        Me.LibrasDataGridViewTextBoxColumn.Visible = False
        '
        'Inventario_Aplicar_Cambios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 406)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Inventario_Aplicar_Cambios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Aplicar Cambios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtsOC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbldetoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dtgOCdet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtproducto As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNuevoCostoUnitario As System.Windows.Forms.TextBox
    Friend WithEvents txtCostoUnitario As System.Windows.Forms.TextBox
    Friend WithEvents txtNuevaCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtLinea As System.Windows.Forms.TextBox
    Friend WithEvents txtLibras As System.Windows.Forms.TextBox
    Friend WithEvents dtsOC As System.Data.DataSet
    Friend WithEvents tbldetoc As System.Data.DataTable
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents dtgOCdet As System.Windows.Forms.DataGridView
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents LineaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionProductoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CantidadDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostoUniDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibrasDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
End Class
