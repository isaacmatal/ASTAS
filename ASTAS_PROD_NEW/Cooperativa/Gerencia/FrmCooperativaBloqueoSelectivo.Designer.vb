<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCooperativaBloqueoSelectivo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtNOMBRE = New System.Windows.Forms.TextBox
        Me.TxtCodigoEmpleado = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.dgvSeleccion = New System.Windows.Forms.DataGridView
        Me.blocked = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.solic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descsolic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.blockedreason = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.autorizedlimit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.modified = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtEmpresa = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtCargo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDepto = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnHistorial = New System.Windows.Forms.Button
        CType(Me.dgvSeleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNOMBRE
        '
        Me.txtNOMBRE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtNOMBRE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNOMBRE.ForeColor = System.Drawing.Color.Navy
        Me.txtNOMBRE.Location = New System.Drawing.Point(170, 15)
        Me.txtNOMBRE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNOMBRE.MaxLength = 75
        Me.txtNOMBRE.Name = "txtNOMBRE"
        Me.txtNOMBRE.ReadOnly = True
        Me.txtNOMBRE.Size = New System.Drawing.Size(387, 22)
        Me.txtNOMBRE.TabIndex = 120
        '
        'TxtCodigoEmpleado
        '
        Me.TxtCodigoEmpleado.Location = New System.Drawing.Point(103, 15)
        Me.TxtCodigoEmpleado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoEmpleado.Name = "TxtCodigoEmpleado"
        Me.TxtCodigoEmpleado.Size = New System.Drawing.Size(63, 22)
        Me.TxtCodigoEmpleado.TabIndex = 118
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(7, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Codigo Empleado:"
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGenerar.Image = Global.ASTAS.My.Resources.Resources.filesave
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(18, 526)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(73, 27)
        Me.btnGenerar.TabIndex = 127
        Me.btnGenerar.Text = "&Guardar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'dgvSeleccion
        '
        Me.dgvSeleccion.AllowUserToAddRows = False
        Me.dgvSeleccion.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvSeleccion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSeleccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSeleccion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvSeleccion.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvSeleccion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSeleccion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSeleccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.blocked, Me.solic, Me.descsolic, Me.blockedreason, Me.autorizedlimit, Me.modified})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSeleccion.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvSeleccion.Location = New System.Drawing.Point(10, 134)
        Me.dgvSeleccion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvSeleccion.Name = "dgvSeleccion"
        Me.dgvSeleccion.RowHeadersVisible = False
        Me.dgvSeleccion.Size = New System.Drawing.Size(638, 384)
        Me.dgvSeleccion.TabIndex = 128
        '
        'blocked
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.NullValue = False
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.blocked.DefaultCellStyle = DataGridViewCellStyle3
        Me.blocked.HeaderText = "Bloqueado"
        Me.blocked.Name = "blocked"
        Me.blocked.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.blocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.blocked.Width = 70
        '
        'solic
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.solic.DefaultCellStyle = DataGridViewCellStyle4
        Me.solic.HeaderText = "Tipo Solicitud"
        Me.solic.Name = "solic"
        Me.solic.ReadOnly = True
        Me.solic.Visible = False
        Me.solic.Width = 50
        '
        'descsolic
        '
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.descsolic.DefaultCellStyle = DataGridViewCellStyle5
        Me.descsolic.HeaderText = "Descripción Solicitud"
        Me.descsolic.Name = "descsolic"
        Me.descsolic.ReadOnly = True
        Me.descsolic.Width = 180
        '
        'blockedreason
        '
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.blockedreason.DefaultCellStyle = DataGridViewCellStyle6
        Me.blockedreason.HeaderText = "Motivo Bloqueo"
        Me.blockedreason.MaxInputLength = 500
        Me.blockedreason.Name = "blockedreason"
        Me.blockedreason.Width = 300
        '
        'autorizedlimit
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "0.00"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.autorizedlimit.DefaultCellStyle = DataGridViewCellStyle7
        Me.autorizedlimit.HeaderText = "Limite Autorizado"
        Me.autorizedlimit.Name = "autorizedlimit"
        Me.autorizedlimit.Width = 70
        '
        'modified
        '
        Me.modified.HeaderText = "Modificado"
        Me.modified.Name = "modified"
        Me.modified.ReadOnly = True
        Me.modified.Visible = False
        '
        'txtEmpresa
        '
        Me.txtEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtEmpresa.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtEmpresa.ForeColor = System.Drawing.Color.Navy
        Me.txtEmpresa.Location = New System.Drawing.Point(103, 44)
        Me.txtEmpresa.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(545, 22)
        Me.txtEmpresa.TabIndex = 134
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(7, 49)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 16)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "Empresa"
        '
        'TxtCargo
        '
        Me.TxtCargo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCargo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCargo.ForeColor = System.Drawing.Color.Navy
        Me.TxtCargo.Location = New System.Drawing.Point(103, 104)
        Me.TxtCargo.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.TxtCargo.Name = "TxtCargo"
        Me.TxtCargo.ReadOnly = True
        Me.TxtCargo.Size = New System.Drawing.Size(545, 22)
        Me.TxtCargo.TabIndex = 132
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(7, 105)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 16)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Cargo"
        '
        'TxtDepto
        '
        Me.TxtDepto.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtDepto.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtDepto.ForeColor = System.Drawing.Color.Navy
        Me.TxtDepto.Location = New System.Drawing.Point(103, 74)
        Me.TxtDepto.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.TxtDepto.Name = "TxtDepto"
        Me.TxtDepto.ReadOnly = True
        Me.TxtDepto.Size = New System.Drawing.Size(545, 22)
        Me.TxtDepto.TabIndex = 130
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(7, 79)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 16)
        Me.Label9.TabIndex = 129
        Me.Label9.Text = "Departamento"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(573, 12)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(65, 25)
        Me.btnNuevo.TabIndex = 135
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn1.HeaderText = "Tipo Solicitud"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción Solicitud"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn3.HeaderText = "Motivo Bloqueo"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 500
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 300
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "0.00"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn4.HeaderText = "Limite Autorizado"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Modificado"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'btnHistorial
        '
        Me.btnHistorial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHistorial.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.btnHistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHistorial.Location = New System.Drawing.Point(467, 526)
        Me.btnHistorial.Name = "btnHistorial"
        Me.btnHistorial.Size = New System.Drawing.Size(181, 27)
        Me.btnHistorial.TabIndex = 136
        Me.btnHistorial.Text = "Histórico Bloqueos Selectivos"
        Me.btnHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHistorial.UseVisualStyleBackColor = True
        '
        'FrmCooperativaBloqueoSelectivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 567)
        Me.Controls.Add(Me.btnHistorial)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.txtEmpresa)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtCargo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtDepto)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgvSeleccion)
        Me.Controls.Add(Me.txtNOMBRE)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.TxtCodigoEmpleado)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmCooperativaBloqueoSelectivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Bloqueo Selectivo"
        CType(Me.dgvSeleccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNOMBRE As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents dgvSeleccion As System.Windows.Forms.DataGridView
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCargo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDepto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents blocked As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents solic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descsolic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents blockedreason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents autorizedlimit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents modified As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnHistorial As System.Windows.Forms.Button
End Class
