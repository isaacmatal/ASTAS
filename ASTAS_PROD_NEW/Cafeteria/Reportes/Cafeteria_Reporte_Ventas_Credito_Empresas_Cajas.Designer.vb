<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Reporte_Ventas_Credito_Empresas_Cajas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Reporte_Ventas_Credito_Empresas_Cajas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.allBodegas = New System.Windows.Forms.CheckBox
        Me.allOrigen = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgvEmpresas = New System.Windows.Forms.DataGridView
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvCajas = New System.Windows.Forms.DataGridView
        Me.SELECCIONAR = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.BODEGA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descuentos = New System.Windows.Forms.GroupBox
        Me.radMensual = New System.Windows.Forms.RadioButton
        Me.radQuincenal = New System.Windows.Forms.RadioButton
        Me.chkCjasSinMov = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Descuentos.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.allBodegas)
        Me.GroupBox1.Controls.Add(Me.allOrigen)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Descuentos)
        Me.GroupBox1.Controls.Add(Me.chkCjasSinMov)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1124, 250)
        Me.GroupBox1.TabIndex = 137
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros del Reporte"
        '
        'allBodegas
        '
        Me.allBodegas.AutoSize = True
        Me.allBodegas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.allBodegas.Location = New System.Drawing.Point(342, 22)
        Me.allBodegas.Name = "allBodegas"
        Me.allBodegas.Size = New System.Drawing.Size(118, 20)
        Me.allBodegas.TabIndex = 155
        Me.allBodegas.Text = "Todas las Cajas"
        Me.allBodegas.UseVisualStyleBackColor = True
        '
        'allOrigen
        '
        Me.allOrigen.AutoSize = True
        Me.allOrigen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.allOrigen.Location = New System.Drawing.Point(8, 22)
        Me.allOrigen.Name = "allOrigen"
        Me.allOrigen.Size = New System.Drawing.Size(137, 20)
        Me.allOrigen.TabIndex = 154
        Me.allOrigen.Text = "Todos los Origenes"
        Me.allOrigen.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvEmpresas)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 39)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(325, 206)
        Me.GroupBox3.TabIndex = 153
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Empresas"
        '
        'dgvEmpresas
        '
        Me.dgvEmpresas.AllowUserToAddRows = False
        Me.dgvEmpresas.AllowUserToDeleteRows = False
        Me.dgvEmpresas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpresas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgvEmpresas.Location = New System.Drawing.Point(5, 21)
        Me.dgvEmpresas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvEmpresas.Name = "dgvEmpresas"
        Me.dgvEmpresas.RowHeadersVisible = False
        Me.dgvEmpresas.Size = New System.Drawing.Size(313, 178)
        Me.dgvEmpresas.TabIndex = 152
        '
        'DataGridViewCheckBoxColumn1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        DataGridViewCellStyle1.NullValue = False
        Me.DataGridViewCheckBoxColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.HeaderText = "Bodega"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 5
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 300
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvCajas)
        Me.GroupBox2.Location = New System.Drawing.Point(342, 39)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(506, 206)
        Me.GroupBox2.TabIndex = 148
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cajas"
        '
        'dgvCajas
        '
        Me.dgvCajas.AllowUserToAddRows = False
        Me.dgvCajas.AllowUserToDeleteRows = False
        Me.dgvCajas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCajas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SELECCIONAR, Me.BODEGA, Me.DESCRIPCION})
        Me.dgvCajas.Location = New System.Drawing.Point(5, 21)
        Me.dgvCajas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvCajas.Name = "dgvCajas"
        Me.dgvCajas.RowHeadersVisible = False
        Me.dgvCajas.Size = New System.Drawing.Size(496, 178)
        Me.dgvCajas.TabIndex = 152
        '
        'SELECCIONAR
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        DataGridViewCellStyle2.NullValue = False
        Me.SELECCIONAR.DefaultCellStyle = DataGridViewCellStyle2
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
        'Descuentos
        '
        Me.Descuentos.Controls.Add(Me.radMensual)
        Me.Descuentos.Controls.Add(Me.radQuincenal)
        Me.Descuentos.Location = New System.Drawing.Point(859, 80)
        Me.Descuentos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Descuentos.Name = "Descuentos"
        Me.Descuentos.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Descuentos.Size = New System.Drawing.Size(110, 90)
        Me.Descuentos.TabIndex = 145
        Me.Descuentos.TabStop = False
        Me.Descuentos.Text = "Descuentos"
        '
        'radMensual
        '
        Me.radMensual.AutoSize = True
        Me.radMensual.Location = New System.Drawing.Point(13, 54)
        Me.radMensual.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.radMensual.Name = "radMensual"
        Me.radMensual.Size = New System.Drawing.Size(73, 20)
        Me.radMensual.TabIndex = 1
        Me.radMensual.Text = "Mensual"
        Me.radMensual.UseVisualStyleBackColor = True
        '
        'radQuincenal
        '
        Me.radQuincenal.AutoSize = True
        Me.radQuincenal.Checked = True
        Me.radQuincenal.Location = New System.Drawing.Point(13, 25)
        Me.radQuincenal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.radQuincenal.Name = "radQuincenal"
        Me.radQuincenal.Size = New System.Drawing.Size(82, 20)
        Me.radQuincenal.TabIndex = 0
        Me.radQuincenal.TabStop = True
        Me.radQuincenal.Text = "Quincenal"
        Me.radQuincenal.UseVisualStyleBackColor = True
        '
        'chkCjasSinMov
        '
        Me.chkCjasSinMov.Location = New System.Drawing.Point(980, 75)
        Me.chkCjasSinMov.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkCjasSinMov.Name = "chkCjasSinMov"
        Me.chkCjasSinMov.Size = New System.Drawing.Size(183, 32)
        Me.chkCjasSinMov.TabIndex = 143
        Me.chkCjasSinMov.Text = "Incluir Ventas de Contado"
        Me.chkCjasSinMov.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(861, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 16)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "Hasta :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(857, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 141
        Me.Label3.Text = "Desde :"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(904, 51)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(179, 22)
        Me.DateTimePicker2.TabIndex = 140
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(905, 23)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(179, 22)
        Me.DateTimePicker1.TabIndex = 139
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(980, 113)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(72, 55)
        Me.BtnBuscar.TabIndex = 5
        Me.BtnBuscar.Text = "Imprimir"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReporte.Location = New System.Drawing.Point(0, 250)
        Me.crvReporte.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.SelectionFormula = ""
        Me.crvReporte.Size = New System.Drawing.Size(1124, 379)
        Me.crvReporte.TabIndex = 139
        Me.crvReporte.ViewTimeSelectionFormula = ""
        '
        'Cafeteria_Reporte_Ventas_Credito_Empresas_Cajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1124, 629)
        Me.Controls.Add(Me.crvReporte)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Cafeteria_Reporte_Ventas_Credito_Empresas_Cajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria - Ventas Empresas Cajas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Descuentos.ResumeLayout(False)
        Me.Descuentos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkCjasSinMov As System.Windows.Forms.CheckBox
    Friend WithEvents Descuentos As System.Windows.Forms.GroupBox
    Friend WithEvents radMensual As System.Windows.Forms.RadioButton
    Friend WithEvents radQuincenal As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCajas As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvEmpresas As System.Windows.Forms.DataGridView
    Friend WithEvents allBodegas As System.Windows.Forms.CheckBox
    Friend WithEvents allOrigen As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECCIONAR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BODEGA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
