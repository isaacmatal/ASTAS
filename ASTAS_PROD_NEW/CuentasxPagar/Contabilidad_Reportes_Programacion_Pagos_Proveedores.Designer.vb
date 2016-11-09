<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reportes_Programacion_Pagos_Proveedores
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.chkProv = New System.Windows.Forms.CheckBox
        Me.dpFechaF = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.dgvProveedores = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.codprov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombprov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkBancos = New System.Windows.Forms.CheckBox
        Me.chkPagoChq = New System.Windows.Forms.CheckBox
        Me.dgvBancos = New System.Windows.Forms.DataGridView
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtProvedor = New System.Windows.Forms.TextBox
        CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBancos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkProv
        '
        Me.chkProv.AutoSize = True
        Me.chkProv.BackColor = System.Drawing.Color.Transparent
        Me.chkProv.Location = New System.Drawing.Point(17, 47)
        Me.chkProv.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkProv.Name = "chkProv"
        Me.chkProv.Size = New System.Drawing.Size(138, 20)
        Me.chkProv.TabIndex = 127
        Me.chkProv.Text = "Todos los Proveedores"
        Me.chkProv.UseVisualStyleBackColor = False
        '
        'dpFechaF
        '
        Me.dpFechaF.Location = New System.Drawing.Point(80, 13)
        Me.dpFechaF.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFechaF.Name = "dpFechaF"
        Me.dpFechaF.Size = New System.Drawing.Size(220, 22)
        Me.dpFechaF.TabIndex = 122
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(14, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Fecha Final:"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnBuscar.Image = Global.ASTAS.My.Resources.Resources.exec1
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(310, 13)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(78, 44)
        Me.BtnBuscar.TabIndex = 4
        Me.BtnBuscar.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Reporte"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crvReporte.Location = New System.Drawing.Point(325, 75)
        Me.crvReporte.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.SelectionFormula = ""
        Me.crvReporte.Size = New System.Drawing.Size(448, 452)
        Me.crvReporte.TabIndex = 149
        Me.crvReporte.ViewTimeSelectionFormula = ""
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProveedores.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProveedores.Location = New System.Drawing.Point(12, 98)
        Me.dgvProveedores.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProveedores.Name = "dgvProveedores"
        Me.dgvProveedores.RowHeadersVisible = False
        Me.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProveedores.Size = New System.Drawing.Size(308, 429)
        Me.dgvProveedores.TabIndex = 148
        '
        'selec
        '
        Me.selec.HeaderText = "*"
        Me.selec.Name = "selec"
        Me.selec.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.selec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.selec.Width = 25
        '
        'codprov
        '
        Me.codprov.DataPropertyName = "PROVEEDOR"
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
        Me.nombprov.Width = 225
        '
        'chkBancos
        '
        Me.chkBancos.AutoSize = True
        Me.chkBancos.BackColor = System.Drawing.Color.Transparent
        Me.chkBancos.Checked = True
        Me.chkBancos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBancos.Location = New System.Drawing.Point(662, 11)
        Me.chkBancos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkBancos.Name = "chkBancos"
        Me.chkBancos.Size = New System.Drawing.Size(111, 20)
        Me.chkBancos.TabIndex = 151
        Me.chkBancos.Text = "Todos los Bancos"
        Me.chkBancos.UseVisualStyleBackColor = False
        '
        'chkPagoChq
        '
        Me.chkPagoChq.AutoSize = True
        Me.chkPagoChq.BackColor = System.Drawing.Color.Transparent
        Me.chkPagoChq.Checked = True
        Me.chkPagoChq.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPagoChq.Location = New System.Drawing.Point(662, 39)
        Me.chkPagoChq.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkPagoChq.Name = "chkPagoChq"
        Me.chkPagoChq.Size = New System.Drawing.Size(118, 20)
        Me.chkPagoChq.TabIndex = 152
        Me.chkPagoChq.Text = "Pagos con Cheque"
        Me.chkPagoChq.UseVisualStyleBackColor = False
        '
        'dgvBancos
        '
        Me.dgvBancos.AllowUserToAddRows = False
        Me.dgvBancos.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvBancos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBancos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvBancos.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvBancos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvBancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBancos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBancos.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvBancos.Location = New System.Drawing.Point(398, 0)
        Me.dgvBancos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvBancos.Name = "dgvBancos"
        Me.dgvBancos.RowHeadersVisible = False
        Me.dgvBancos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBancos.Size = New System.Drawing.Size(247, 73)
        Me.dgvBancos.TabIndex = 153
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "*"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn1.Width = 25
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DESCRIPCION_BANCO"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Depósitos a Cuenta:"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "BANCO"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(12, 74)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(61, 22)
        Me.txtCodigo.TabIndex = 154
        Me.txtCodigo.Tag = "PROVEEDOR"
        Me.ToolTip1.SetToolTip(Me.txtCodigo, "Búsqueda por Código")
        '
        'txtProvedor
        '
        Me.txtProvedor.Location = New System.Drawing.Point(79, 74)
        Me.txtProvedor.Name = "txtProvedor"
        Me.txtProvedor.Size = New System.Drawing.Size(241, 22)
        Me.txtProvedor.TabIndex = 155
        Me.txtProvedor.Tag = "NOMBRE_PROVEEDOR"
        Me.ToolTip1.SetToolTip(Me.txtProvedor, "Búsqueda por Nombre")
        '
        'Contabilidad_Reportes_Programacion_Pagos_Proveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 531)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.txtProvedor)
        Me.Controls.Add(Me.dgvBancos)
        Me.Controls.Add(Me.chkPagoChq)
        Me.Controls.Add(Me.chkBancos)
        Me.Controls.Add(Me.crvReporte)
        Me.Controls.Add(Me.dgvProveedores)
        Me.Controls.Add(Me.dpFechaF)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkProv)
        Me.Controls.Add(Me.BtnBuscar)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Reportes_Programacion_Pagos_Proveedores"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagos Pendientes a Proveedores"
        CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBancos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents dpFechaF As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkProv As System.Windows.Forms.CheckBox
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents dgvProveedores As System.Windows.Forms.DataGridView
    Friend WithEvents chkBancos As System.Windows.Forms.CheckBox
    Friend WithEvents chkPagoChq As System.Windows.Forms.CheckBox
    Friend WithEvents dgvBancos As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents codprov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombprov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtProvedor As System.Windows.Forms.TextBox
End Class
