<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reportes_Antiguedad_Saldos_Proveedores
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtFechaI = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.dgvProveedores = New System.Windows.Forms.DataGridView
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.chkProv = New System.Windows.Forms.CheckBox
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.codprov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombprov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtProvedor = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFechaI
        '
        Me.txtFechaI.Location = New System.Drawing.Point(114, 17)
        Me.txtFechaI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFechaI.Name = "txtFechaI"
        Me.txtFechaI.Size = New System.Drawing.Size(220, 22)
        Me.txtFechaI.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(12, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Fecha del Análisis:"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnBuscar.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(339, 9)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(72, 37)
        Me.BtnBuscar.TabIndex = 4
        Me.BtnBuscar.Text = "Generar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'dgvProveedores
        '
        Me.dgvProveedores.AllowUserToAddRows = False
        Me.dgvProveedores.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvProveedores.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvProveedores.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvProveedores.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvProveedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProveedores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selec, Me.codprov, Me.nombprov})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProveedores.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvProveedores.Location = New System.Drawing.Point(12, 78)
        Me.dgvProveedores.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProveedores.Name = "dgvProveedores"
        Me.dgvProveedores.RowHeadersVisible = False
        Me.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProveedores.Size = New System.Drawing.Size(308, 472)
        Me.dgvProveedores.TabIndex = 146
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crvReporte.Location = New System.Drawing.Point(325, 49)
        Me.crvReporte.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.SelectionFormula = ""
        Me.crvReporte.Size = New System.Drawing.Size(452, 500)
        Me.crvReporte.TabIndex = 147
        Me.crvReporte.ViewTimeSelectionFormula = ""
        '
        'chkProv
        '
        Me.chkProv.AutoSize = True
        Me.chkProv.BackColor = System.Drawing.Color.Transparent
        Me.chkProv.Location = New System.Drawing.Point(425, 17)
        Me.chkProv.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.chkProv.Name = "chkProv"
        Me.chkProv.Size = New System.Drawing.Size(138, 20)
        Me.chkProv.TabIndex = 148
        Me.chkProv.Text = "Todos los Proveedores"
        Me.chkProv.UseVisualStyleBackColor = False
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
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(12, 49)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(61, 22)
        Me.txtCodigo.TabIndex = 149
        Me.txtCodigo.Tag = "PROVEEDOR"
        Me.ToolTip1.SetToolTip(Me.txtCodigo, "Búsqueda por Código")
        '
        'txtProvedor
        '
        Me.txtProvedor.Location = New System.Drawing.Point(79, 49)
        Me.txtProvedor.Name = "txtProvedor"
        Me.txtProvedor.Size = New System.Drawing.Size(241, 22)
        Me.txtProvedor.TabIndex = 150
        Me.txtProvedor.Tag = "NOMBRE_PROVEEDOR"
        Me.ToolTip1.SetToolTip(Me.txtProvedor, "Búsqueda por Nombre")
        '
        'Contabilidad_Reportes_Antiguedad_Saldos_Proveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 556)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.txtProvedor)
        Me.Controls.Add(Me.chkProv)
        Me.Controls.Add(Me.crvReporte)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFechaI)
        Me.Controls.Add(Me.dgvProveedores)
        Me.Controls.Add(Me.BtnBuscar)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Reportes_Antiguedad_Saldos_Proveedores"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Antiguedad Saldos Proveedores"
        CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFechaI As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvProveedores As System.Windows.Forms.DataGridView
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkProv As System.Windows.Forms.CheckBox
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents codprov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombprov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtProvedor As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
