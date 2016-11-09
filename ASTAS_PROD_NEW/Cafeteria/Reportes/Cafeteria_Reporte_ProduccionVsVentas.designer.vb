<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Reporte_ProduccionVsVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Reporte_ProduccionVsVentas))
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkAllCajas = New System.Windows.Forms.CheckBox
        Me.radNone = New System.Windows.Forms.RadioButton
        Me.dgvCajas = New System.Windows.Forms.DataGridView
        Me.SELECCIONAR = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.BODEGA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rdPlanta2 = New System.Windows.Forms.RadioButton
        Me.rdPlanta1 = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fecha_hasta = New System.Windows.Forms.DateTimePicker
        Me.fecha_desde = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 155)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1026, 527)
        Me.CrystalReportViewer1.TabIndex = 106
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkAllCajas)
        Me.GroupBox1.Controls.Add(Me.radNone)
        Me.GroupBox1.Controls.Add(Me.dgvCajas)
        Me.GroupBox1.Controls.Add(Me.rdPlanta2)
        Me.GroupBox1.Controls.Add(Me.rdPlanta1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.fecha_hasta)
        Me.GroupBox1.Controls.Add(Me.fecha_desde)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1026, 155)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles Genericos"
        '
        'chkAllCajas
        '
        Me.chkAllCajas.AutoSize = True
        Me.chkAllCajas.Location = New System.Drawing.Point(776, 43)
        Me.chkAllCajas.Name = "chkAllCajas"
        Me.chkAllCajas.Size = New System.Drawing.Size(120, 20)
        Me.chkAllCajas.TabIndex = 156
        Me.chkAllCajas.Text = "Todas las Caja"
        Me.chkAllCajas.UseVisualStyleBackColor = True
        '
        'radNone
        '
        Me.radNone.AutoSize = True
        Me.radNone.Checked = True
        Me.radNone.Location = New System.Drawing.Point(160, 20)
        Me.radNone.Name = "radNone"
        Me.radNone.Size = New System.Drawing.Size(14, 13)
        Me.radNone.TabIndex = 154
        Me.radNone.TabStop = True
        Me.radNone.UseVisualStyleBackColor = True
        '
        'dgvCajas
        '
        Me.dgvCajas.AllowUserToAddRows = False
        Me.dgvCajas.AllowUserToDeleteRows = False
        Me.dgvCajas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCajas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SELECCIONAR, Me.BODEGA, Me.DESCRIPCION})
        Me.dgvCajas.Location = New System.Drawing.Point(10, 43)
        Me.dgvCajas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvCajas.Name = "dgvCajas"
        Me.dgvCajas.RowHeadersVisible = False
        Me.dgvCajas.Size = New System.Drawing.Size(760, 107)
        Me.dgvCajas.TabIndex = 153
        '
        'SELECCIONAR
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        DataGridViewCellStyle1.NullValue = False
        Me.SELECCIONAR.DefaultCellStyle = DataGridViewCellStyle1
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
        Me.DESCRIPCION.Width = 600
        '
        'rdPlanta2
        '
        Me.rdPlanta2.AutoSize = True
        Me.rdPlanta2.Location = New System.Drawing.Point(273, 17)
        Me.rdPlanta2.Name = "rdPlanta2"
        Me.rdPlanta2.Size = New System.Drawing.Size(78, 20)
        Me.rdPlanta2.TabIndex = 137
        Me.rdPlanta2.Text = "Planta 2"
        Me.rdPlanta2.UseVisualStyleBackColor = True
        '
        'rdPlanta1
        '
        Me.rdPlanta1.AutoSize = True
        Me.rdPlanta1.Location = New System.Drawing.Point(187, 17)
        Me.rdPlanta1.Name = "rdPlanta1"
        Me.rdPlanta1.Size = New System.Drawing.Size(78, 20)
        Me.rdPlanta1.TabIndex = 136
        Me.rdPlanta1.Text = "Planta 1"
        Me.rdPlanta1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(10, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "Cajas Segun Bodegas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(538, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = "Hasta :"
        '
        'fecha_hasta
        '
        Me.fecha_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_hasta.Location = New System.Drawing.Point(579, 17)
        Me.fecha_hasta.Name = "fecha_hasta"
        Me.fecha_hasta.Size = New System.Drawing.Size(112, 22)
        Me.fecha_hasta.TabIndex = 139
        '
        'fecha_desde
        '
        Me.fecha_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_desde.Location = New System.Drawing.Point(421, 17)
        Me.fecha_desde.Name = "fecha_desde"
        Me.fecha_desde.Size = New System.Drawing.Size(112, 22)
        Me.fecha_desde.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(375, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 16)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Desde :"
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.Location = New System.Drawing.Point(700, 13)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(70, 28)
        Me.btnNuevo.TabIndex = 2
        Me.btnNuevo.Text = "&Imprimir"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Cafeteria_Reporte_ProduccionVsVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1026, 682)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Cafeteria_Reporte_ProduccionVsVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria_Reporte_ProduccionVsVentas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents fecha_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents rdPlanta1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdPlanta2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvCajas As System.Windows.Forms.DataGridView
    Friend WithEvents SELECCIONAR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BODEGA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents radNone As System.Windows.Forms.RadioButton
    Friend WithEvents chkAllCajas As System.Windows.Forms.CheckBox
End Class
