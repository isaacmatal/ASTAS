<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Reporte_Compra_Venta_X_Bodegas_Params
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Reporte_Compra_Venta_X_Bodegas_Params))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.allBodegas = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvBodegas = New System.Windows.Forms.DataGridView
        Me.SELECCIONAR = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.BODEGA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnPrint = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvSubGrupos = New System.Windows.Forms.DataGridView
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubGrupo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grpFilters = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.radConExistencias = New System.Windows.Forms.RadioButton
        Me.radSinExistencias = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtFinderProducts = New System.Windows.Forms.TextBox
        Me.dgvProductos = New System.Windows.Forms.DataGridView
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.allProducts = New System.Windows.Forms.CheckBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvSubGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilters.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'allBodegas
        '
        Me.allBodegas.AutoSize = True
        Me.allBodegas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.allBodegas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.allBodegas.ForeColor = System.Drawing.Color.Navy
        Me.allBodegas.Location = New System.Drawing.Point(285, 14)
        Me.allBodegas.Name = "allBodegas"
        Me.allBodegas.Size = New System.Drawing.Size(127, 20)
        Me.allBodegas.TabIndex = 161
        Me.allBodegas.Text = "Todas las Bodegas"
        Me.allBodegas.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(8, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 158
        Me.Label4.Text = "Hasta :"
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(57, 22)
        Me.dtpHasta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(113, 22)
        Me.dtpHasta.TabIndex = 157
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvBodegas)
        Me.GroupBox2.Controls.Add(Me.allBodegas)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(5, 56)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(425, 226)
        Me.GroupBox2.TabIndex = 160
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Bodegas"
        '
        'dgvBodegas
        '
        Me.dgvBodegas.AllowUserToAddRows = False
        Me.dgvBodegas.AllowUserToDeleteRows = False
        Me.dgvBodegas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvBodegas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBodegas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SELECCIONAR, Me.BODEGA, Me.DESCRIPCION})
        Me.dgvBodegas.Location = New System.Drawing.Point(5, 41)
        Me.dgvBodegas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvBodegas.Name = "dgvBodegas"
        Me.dgvBodegas.RowHeadersVisible = False
        Me.dgvBodegas.Size = New System.Drawing.Size(414, 178)
        Me.dgvBodegas.TabIndex = 152
        '
        'SELECCIONAR
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        DataGridViewCellStyle4.NullValue = False
        Me.SELECCIONAR.DefaultCellStyle = DataGridViewCellStyle4
        Me.SELECCIONAR.HeaderText = ""
        Me.SELECCIONAR.Name = "SELECCIONAR"
        Me.SELECCIONAR.Width = 5
        '
        'BODEGA
        '
        Me.BODEGA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.BODEGA.HeaderText = "Bodega"
        Me.BODEGA.Name = "BODEGA"
        Me.BODEGA.ReadOnly = True
        Me.BODEGA.Width = 5
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DESCRIPCION.HeaderText = "Descripción"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        Me.DESCRIPCION.Width = 500
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnPrint.ForeColor = System.Drawing.Color.Navy
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(175, 13)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 41)
        Me.btnPrint.TabIndex = 156
        Me.btnPrint.Text = "Imprimir"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CheckBox1.ForeColor = System.Drawing.Color.Navy
        Me.CheckBox1.Location = New System.Drawing.Point(249, 13)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(197, 20)
        Me.CheckBox1.TabIndex = 163
        Me.CheckBox1.Text = "Todos los Grupos y Sub Grupos"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvSubGrupos)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(439, 56)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(464, 226)
        Me.GroupBox1.TabIndex = 162
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Grupos y Sub Grupos"
        '
        'dgvSubGrupos
        '
        Me.dgvSubGrupos.AllowUserToAddRows = False
        Me.dgvSubGrupos.AllowUserToDeleteRows = False
        Me.dgvSubGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSubGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSubGrupos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.SubGrupo, Me.DataGridViewTextBoxColumn2})
        Me.dgvSubGrupos.Location = New System.Drawing.Point(5, 40)
        Me.dgvSubGrupos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvSubGrupos.Name = "dgvSubGrupos"
        Me.dgvSubGrupos.RowHeadersVisible = False
        Me.dgvSubGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSubGrupos.Size = New System.Drawing.Size(454, 178)
        Me.dgvSubGrupos.TabIndex = 152
        '
        'DataGridViewCheckBoxColumn1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        DataGridViewCellStyle5.NullValue = False
        Me.DataGridViewCheckBoxColumn1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.HeaderText = "Grupo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 5
        '
        'SubGrupo
        '
        Me.SubGrupo.HeaderText = "Sub Grupo"
        Me.SubGrupo.Name = "SubGrupo"
        Me.SubGrupo.Visible = False
        Me.SubGrupo.Width = 75
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 500
        '
        'grpFilters
        '
        Me.grpFilters.Controls.Add(Me.GroupBox4)
        Me.grpFilters.Controls.Add(Me.GroupBox3)
        Me.grpFilters.Controls.Add(Me.ProgressBar1)
        Me.grpFilters.Controls.Add(Me.Label4)
        Me.grpFilters.Controls.Add(Me.btnPrint)
        Me.grpFilters.Controls.Add(Me.GroupBox2)
        Me.grpFilters.Controls.Add(Me.GroupBox1)
        Me.grpFilters.Controls.Add(Me.dtpHasta)
        Me.grpFilters.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.grpFilters.ForeColor = System.Drawing.Color.Navy
        Me.grpFilters.Location = New System.Drawing.Point(4, 3)
        Me.grpFilters.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grpFilters.Size = New System.Drawing.Size(912, 541)
        Me.grpFilters.TabIndex = 164
        Me.grpFilters.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.radConExistencias)
        Me.GroupBox4.Controls.Add(Me.radSinExistencias)
        Me.GroupBox4.Location = New System.Drawing.Point(439, 286)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(261, 49)
        Me.GroupBox4.TabIndex = 168
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Existencias"
        '
        'radConExistencias
        '
        Me.radConExistencias.AutoSize = True
        Me.radConExistencias.Checked = True
        Me.radConExistencias.Location = New System.Drawing.Point(14, 21)
        Me.radConExistencias.Name = "radConExistencias"
        Me.radConExistencias.Size = New System.Drawing.Size(111, 20)
        Me.radConExistencias.TabIndex = 166
        Me.radConExistencias.TabStop = True
        Me.radConExistencias.Text = "Con Existencias"
        Me.radConExistencias.UseVisualStyleBackColor = True
        '
        'radSinExistencias
        '
        Me.radSinExistencias.AutoSize = True
        Me.radSinExistencias.Location = New System.Drawing.Point(144, 21)
        Me.radSinExistencias.Name = "radSinExistencias"
        Me.radSinExistencias.Size = New System.Drawing.Size(107, 20)
        Me.radSinExistencias.TabIndex = 167
        Me.radSinExistencias.Text = "Sin Existencias"
        Me.radSinExistencias.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtFinderProducts)
        Me.GroupBox3.Controls.Add(Me.dgvProductos)
        Me.GroupBox3.Controls.Add(Me.allProducts)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox3.Location = New System.Drawing.Point(6, 285)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(425, 249)
        Me.GroupBox3.TabIndex = 162
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Productos"
        '
        'txtFinderProducts
        '
        Me.txtFinderProducts.Location = New System.Drawing.Point(6, 27)
        Me.txtFinderProducts.Name = "txtFinderProducts"
        Me.txtFinderProducts.Size = New System.Drawing.Size(219, 22)
        Me.txtFinderProducts.TabIndex = 164
        '
        'dgvProductos
        '
        Me.dgvProductos.AllowUserToAddRows = False
        Me.dgvProductos.AllowUserToDeleteRows = False
        Me.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dgvProductos.Location = New System.Drawing.Point(5, 58)
        Me.dgvProductos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.RowHeadersVisible = False
        Me.dgvProductos.Size = New System.Drawing.Size(414, 183)
        Me.dgvProductos.TabIndex = 152
        '
        'DataGridViewCheckBoxColumn2
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        DataGridViewCellStyle6.NullValue = False
        Me.DataGridViewCheckBoxColumn2.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewCheckBoxColumn2.HeaderText = ""
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Width = 5
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn3.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 5
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn4.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 500
        '
        'allProducts
        '
        Me.allProducts.AutoSize = True
        Me.allProducts.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.allProducts.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.allProducts.ForeColor = System.Drawing.Color.Navy
        Me.allProducts.Location = New System.Drawing.Point(228, 28)
        Me.allProducts.Name = "allProducts"
        Me.allProducts.Size = New System.Drawing.Size(137, 20)
        Me.allProducts.TabIndex = 163
        Me.allProducts.Text = "Todos los Productos"
        Me.allProducts.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(428, 22)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(475, 23)
        Me.ProgressBar1.Step = 2
        Me.ProgressBar1.TabIndex = 165
        '
        'BackgroundWorker1
        '
        '
        'Inventario_Reporte_Compra_Venta_X_Bodegas_Params
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 568)
        Me.Controls.Add(Me.grpFilters)
        Me.Name = "Inventario_Reporte_Compra_Venta_X_Bodegas_Params"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Entradas y Salidas por Bodegas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvSubGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents allBodegas As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvBodegas As System.Windows.Forms.DataGridView
    Friend WithEvents SELECCIONAR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BODEGA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvSubGrupos As System.Windows.Forms.DataGridView
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubGrupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents allProducts As System.Windows.Forms.CheckBox
    Friend WithEvents txtFinderProducts As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents radConExistencias As System.Windows.Forms.RadioButton
    Friend WithEvents radSinExistencias As System.Windows.Forms.RadioButton
End Class
