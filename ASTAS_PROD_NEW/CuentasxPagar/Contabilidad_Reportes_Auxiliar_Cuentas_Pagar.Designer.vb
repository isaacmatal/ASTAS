<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reportes_Auxiliar_Cuentas_Pagar
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkProv = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dpFechaF = New System.Windows.Forms.DateTimePicker
        Me.dpFechaI = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.crvEstadoCuenta = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.dgvProveedores = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.codprov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombprov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pb1 = New System.Windows.Forms.ProgressBar
        Me.BW1 = New System.ComponentModel.BackgroundWorker
        Me.txtProvedor = New System.Windows.Forms.TextBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(631, 11)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(60, 95)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 143
        Me.pbImagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkProv)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dpFechaF)
        Me.GroupBox1.Controls.Add(Me.dpFechaI)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnGenerar)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(617, 93)
        Me.GroupBox1.TabIndex = 142
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado Cuenta"
        '
        'chkProv
        '
        Me.chkProv.AutoSize = True
        Me.chkProv.Location = New System.Drawing.Point(315, 60)
        Me.chkProv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkProv.Name = "chkProv"
        Me.chkProv.Size = New System.Drawing.Size(159, 20)
        Me.chkProv.TabIndex = 124
        Me.chkProv.Text = "Todos los Proveedores"
        Me.chkProv.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(11, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Fecha Final:"
        '
        'dpFechaF
        '
        Me.dpFechaF.Location = New System.Drawing.Point(79, 59)
        Me.dpFechaF.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFechaF.Name = "dpFechaF"
        Me.dpFechaF.Size = New System.Drawing.Size(220, 22)
        Me.dpFechaF.TabIndex = 122
        '
        'dpFechaI
        '
        Me.dpFechaI.Location = New System.Drawing.Point(79, 27)
        Me.dpFechaI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFechaI.Name = "dpFechaI"
        Me.dpFechaI.Size = New System.Drawing.Size(220, 22)
        Me.dpFechaI.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(11, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Fecha Inicio:"
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGenerar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGenerar.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(315, 24)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(82, 27)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'crvEstadoCuenta
        '
        Me.crvEstadoCuenta.ActiveViewIndex = -1
        Me.crvEstadoCuenta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvEstadoCuenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crvEstadoCuenta.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvEstadoCuenta.Location = New System.Drawing.Point(313, 113)
        Me.crvEstadoCuenta.Name = "crvEstadoCuenta"
        Me.crvEstadoCuenta.SelectionFormula = ""
        Me.crvEstadoCuenta.Size = New System.Drawing.Size(533, 380)
        Me.crvEstadoCuenta.TabIndex = 144
        Me.crvEstadoCuenta.ViewTimeSelectionFormula = ""
        '
        'dgvProveedores
        '
        Me.dgvProveedores.AllowUserToAddRows = False
        Me.dgvProveedores.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvProveedores.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProveedores.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvProveedores.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvProveedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProveedores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selec, Me.codprov, Me.nombprov})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProveedores.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProveedores.Location = New System.Drawing.Point(8, 141)
        Me.dgvProveedores.Name = "dgvProveedores"
        Me.dgvProveedores.RowHeadersVisible = False
        Me.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProveedores.Size = New System.Drawing.Size(299, 352)
        Me.dgvProveedores.TabIndex = 145
        '
        'selec
        '
        Me.selec.HeaderText = "*"
        Me.selec.Name = "selec"
        Me.selec.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.selec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.selec.Width = 20
        '
        'codprov
        '
        Me.codprov.DataPropertyName = "PROVEEDOR"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codprov.DefaultCellStyle = DataGridViewCellStyle2
        Me.codprov.HeaderText = "Cod."
        Me.codprov.Name = "codprov"
        Me.codprov.ReadOnly = True
        Me.codprov.Width = 35
        '
        'nombprov
        '
        Me.nombprov.DataPropertyName = "NOMBRE_PROVEEDOR"
        Me.nombprov.HeaderText = "Proveedor"
        Me.nombprov.Name = "nombprov"
        Me.nombprov.ReadOnly = True
        Me.nombprov.Width = 220
        '
        'pb1
        '
        Me.pb1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb1.Location = New System.Drawing.Point(698, 38)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(148, 23)
        Me.pb1.TabIndex = 146
        Me.pb1.Visible = False
        '
        'BW1
        '
        Me.BW1.WorkerReportsProgress = True
        Me.BW1.WorkerSupportsCancellation = True
        '
        'txtProvedor
        '
        Me.txtProvedor.Location = New System.Drawing.Point(65, 113)
        Me.txtProvedor.Name = "txtProvedor"
        Me.txtProvedor.Size = New System.Drawing.Size(242, 22)
        Me.txtProvedor.TabIndex = 148
        Me.txtProvedor.Tag = "NOMBRE_PROVEEDOR"
        Me.ToolTip1.SetToolTip(Me.txtProvedor, "Búsqueda por Nombre")
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(8, 113)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(51, 22)
        Me.txtCodigo.TabIndex = 147
        Me.txtCodigo.Tag = "PROVEEDOR"
        Me.ToolTip1.SetToolTip(Me.txtCodigo, "Búsqueda por Código")
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "NOMBRE_PROVEEDOR"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn1.HeaderText = "Proveedor"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 220
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PROVEEDOR"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn2.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 40
        '
        'Contabilidad_Reportes_Auxiliar_Cuentas_Pagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 505)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.txtProvedor)
        Me.Controls.Add(Me.pb1)
        Me.Controls.Add(Me.dgvProveedores)
        Me.Controls.Add(Me.crvEstadoCuenta)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Reportes_Auxiliar_Cuentas_Pagar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas por Pagar - Reportes Estado Cuenta Proveedores"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dpFechaI As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dpFechaF As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkProv As System.Windows.Forms.CheckBox
    Friend WithEvents crvEstadoCuenta As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents dgvProveedores As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BW1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtProvedor As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents codprov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombprov As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
