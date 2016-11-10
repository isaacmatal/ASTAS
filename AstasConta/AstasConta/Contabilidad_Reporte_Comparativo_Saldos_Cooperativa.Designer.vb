<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reporte_Comparativo_Saldos_Cooperativa
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
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFechaContable = New System.Windows.Forms.DateTimePicker
        Me.chkSoloDif = New System.Windows.Forms.CheckBox
        Me.dgvEmpresas = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.descempresa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.origen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvTipoSol = New System.Windows.Forms.DataGridView
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkEmpresasTodas = New System.Windows.Forms.CheckBox
        Me.chkRubrosTodos = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbAhorros = New System.Windows.Forms.RadioButton
        Me.rbDeudas = New System.Windows.Forms.RadioButton
        Me.chkRptGuardado = New System.Windows.Forms.CheckBox
        Me.gbTipoAh = New System.Windows.Forms.GroupBox
        Me.chkOrdin = New System.Windows.Forms.CheckBox
        Me.chkExtra = New System.Windows.Forms.CheckBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnGenerar = New System.Windows.Forms.Button
        CType(Me.dgvEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipoSol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbTipoAh.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Reporte al:"
        '
        'dtpFechaContable
        '
        Me.dtpFechaContable.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaContable.Location = New System.Drawing.Point(81, 6)
        Me.dtpFechaContable.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpFechaContable.Name = "dtpFechaContable"
        Me.dtpFechaContable.Size = New System.Drawing.Size(107, 22)
        Me.dtpFechaContable.TabIndex = 1
        '
        'chkSoloDif
        '
        Me.chkSoloDif.AutoSize = True
        Me.chkSoloDif.BackColor = System.Drawing.Color.Transparent
        Me.chkSoloDif.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSoloDif.ForeColor = System.Drawing.Color.Navy
        Me.chkSoloDif.Location = New System.Drawing.Point(15, 42)
        Me.chkSoloDif.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkSoloDif.Name = "chkSoloDif"
        Me.chkSoloDif.Size = New System.Drawing.Size(139, 20)
        Me.chkSoloDif.TabIndex = 4
        Me.chkSoloDif.Text = "Solo Con Diferencias"
        Me.chkSoloDif.UseVisualStyleBackColor = False
        '
        'dgvEmpresas
        '
        Me.dgvEmpresas.AllowUserToAddRows = False
        Me.dgvEmpresas.AllowUserToDeleteRows = False
        Me.dgvEmpresas.AllowUserToOrderColumns = True
        DataGridViewCellStyle33.BackColor = System.Drawing.Color.LightGray
        Me.dgvEmpresas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle33
        Me.dgvEmpresas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvEmpresas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvEmpresas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpresas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selec, Me.descempresa, Me.origen})
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEmpresas.DefaultCellStyle = DataGridViewCellStyle34
        Me.dgvEmpresas.Location = New System.Drawing.Point(15, 98)
        Me.dgvEmpresas.Name = "dgvEmpresas"
        Me.dgvEmpresas.RowHeadersVisible = False
        Me.dgvEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmpresas.Size = New System.Drawing.Size(282, 410)
        Me.dgvEmpresas.TabIndex = 21
        '
        'selec
        '
        Me.selec.HeaderText = ""
        Me.selec.Name = "selec"
        Me.selec.Width = 30
        '
        'descempresa
        '
        Me.descempresa.DataPropertyName = "DESCRIPCION_ORIGEN"
        Me.descempresa.HeaderText = "Seleccionar Empresas"
        Me.descempresa.Name = "descempresa"
        Me.descempresa.ReadOnly = True
        Me.descempresa.Width = 240
        '
        'origen
        '
        Me.origen.DataPropertyName = "ORIGEN"
        Me.origen.HeaderText = "Origen"
        Me.origen.Name = "origen"
        Me.origen.ReadOnly = True
        Me.origen.Visible = False
        Me.origen.Width = 65
        '
        'dgvTipoSol
        '
        Me.dgvTipoSol.AllowUserToAddRows = False
        Me.dgvTipoSol.AllowUserToDeleteRows = False
        Me.dgvTipoSol.AllowUserToOrderColumns = True
        DataGridViewCellStyle35.BackColor = System.Drawing.Color.LightGray
        Me.dgvTipoSol.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle35
        Me.dgvTipoSol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvTipoSol.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvTipoSol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTipoSol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipoSol.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle36.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTipoSol.DefaultCellStyle = DataGridViewCellStyle36
        Me.dgvTipoSol.Location = New System.Drawing.Point(303, 98)
        Me.dgvTipoSol.Name = "dgvTipoSol"
        Me.dgvTipoSol.RowHeadersVisible = False
        Me.dgvTipoSol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTipoSol.Size = New System.Drawing.Size(282, 410)
        Me.dgvTipoSol.TabIndex = 22
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 30
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DESCRIPCION_SOLICITUD"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Seleccionar Rubros"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 240
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "SOLICITUD"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Solicitud"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 65
        '
        'chkEmpresasTodas
        '
        Me.chkEmpresasTodas.AutoSize = True
        Me.chkEmpresasTodas.BackColor = System.Drawing.Color.Transparent
        Me.chkEmpresasTodas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmpresasTodas.ForeColor = System.Drawing.Color.Navy
        Me.chkEmpresasTodas.Location = New System.Drawing.Point(15, 75)
        Me.chkEmpresasTodas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkEmpresasTodas.Name = "chkEmpresasTodas"
        Me.chkEmpresasTodas.Size = New System.Drawing.Size(130, 20)
        Me.chkEmpresasTodas.TabIndex = 23
        Me.chkEmpresasTodas.Text = "Todas las empresas"
        Me.chkEmpresasTodas.UseVisualStyleBackColor = False
        '
        'chkRubrosTodos
        '
        Me.chkRubrosTodos.AutoSize = True
        Me.chkRubrosTodos.BackColor = System.Drawing.Color.Transparent
        Me.chkRubrosTodos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRubrosTodos.ForeColor = System.Drawing.Color.Navy
        Me.chkRubrosTodos.Location = New System.Drawing.Point(303, 75)
        Me.chkRubrosTodos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkRubrosTodos.Name = "chkRubrosTodos"
        Me.chkRubrosTodos.Size = New System.Drawing.Size(121, 20)
        Me.chkRubrosTodos.TabIndex = 24
        Me.chkRubrosTodos.Text = "Todos los Rubros"
        Me.chkRubrosTodos.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.gbTipoAh)
        Me.GroupBox1.Controls.Add(Me.rbAhorros)
        Me.GroupBox1.Controls.Add(Me.rbDeudas)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(194, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(267, 66)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Comparación de:"
        '
        'rbAhorros
        '
        Me.rbAhorros.AutoSize = True
        Me.rbAhorros.Location = New System.Drawing.Point(7, 40)
        Me.rbAhorros.Name = "rbAhorros"
        Me.rbAhorros.Size = New System.Drawing.Size(68, 20)
        Me.rbAhorros.TabIndex = 1
        Me.rbAhorros.TabStop = True
        Me.rbAhorros.Text = "Ahorros"
        Me.rbAhorros.UseVisualStyleBackColor = True
        '
        'rbDeudas
        '
        Me.rbDeudas.AutoSize = True
        Me.rbDeudas.Checked = True
        Me.rbDeudas.Location = New System.Drawing.Point(7, 16)
        Me.rbDeudas.Name = "rbDeudas"
        Me.rbDeudas.Size = New System.Drawing.Size(66, 20)
        Me.rbDeudas.TabIndex = 0
        Me.rbDeudas.TabStop = True
        Me.rbDeudas.Text = "Deudas"
        Me.rbDeudas.UseVisualStyleBackColor = True
        '
        'chkRptGuardado
        '
        Me.chkRptGuardado.AutoSize = True
        Me.chkRptGuardado.BackColor = System.Drawing.Color.Transparent
        Me.chkRptGuardado.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRptGuardado.ForeColor = System.Drawing.Color.Navy
        Me.chkRptGuardado.Location = New System.Drawing.Point(425, 74)
        Me.chkRptGuardado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkRptGuardado.Name = "chkRptGuardado"
        Me.chkRptGuardado.Size = New System.Drawing.Size(137, 20)
        Me.chkRptGuardado.TabIndex = 27
        Me.chkRptGuardado.Text = "Ver datos guardados"
        Me.chkRptGuardado.UseVisualStyleBackColor = False
        Me.chkRptGuardado.Visible = False
        '
        'gbTipoAh
        '
        Me.gbTipoAh.Controls.Add(Me.chkExtra)
        Me.gbTipoAh.Controls.Add(Me.chkOrdin)
        Me.gbTipoAh.Enabled = False
        Me.gbTipoAh.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoAh.ForeColor = System.Drawing.Color.Navy
        Me.gbTipoAh.Location = New System.Drawing.Point(71, 32)
        Me.gbTipoAh.Name = "gbTipoAh"
        Me.gbTipoAh.Size = New System.Drawing.Size(191, 31)
        Me.gbTipoAh.TabIndex = 2
        Me.gbTipoAh.TabStop = False
        '
        'chkOrdin
        '
        Me.chkOrdin.AutoSize = True
        Me.chkOrdin.Checked = True
        Me.chkOrdin.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOrdin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOrdin.Location = New System.Drawing.Point(8, 9)
        Me.chkOrdin.Name = "chkOrdin"
        Me.chkOrdin.Size = New System.Drawing.Size(76, 20)
        Me.chkOrdin.TabIndex = 0
        Me.chkOrdin.Text = "Ordinario"
        Me.chkOrdin.UseVisualStyleBackColor = True
        '
        'chkExtra
        '
        Me.chkExtra.AutoSize = True
        Me.chkExtra.Checked = True
        Me.chkExtra.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExtra.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExtra.Location = New System.Drawing.Point(86, 9)
        Me.chkExtra.Name = "chkExtra"
        Me.chkExtra.Size = New System.Drawing.Size(102, 20)
        Me.chkExtra.TabIndex = 1
        Me.chkExtra.Text = "Extraordinario"
        Me.chkExtra.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.AstasConta.My.Resources.Resources.filesaveas
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(523, 70)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 28)
        Me.btnGuardar.TabIndex = 26
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        Me.btnGuardar.Visible = False
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.Transparent
        Me.btnGenerar.Font = New System.Drawing.Font("Bauhaus 93", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ForeColor = System.Drawing.Color.Navy
        Me.btnGenerar.Image = Global.AstasConta.My.Resources.Resources.make_kdevelop
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(467, 11)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(118, 61)
        Me.btnGenerar.TabIndex = 3
        Me.btnGenerar.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Reporte"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'Contabilidad_Reporte_Comparativo_Saldos_Cooperativa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 520)
        Me.Controls.Add(Me.chkRptGuardado)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkRubrosTodos)
        Me.Controls.Add(Me.chkEmpresasTodas)
        Me.Controls.Add(Me.dgvTipoSol)
        Me.Controls.Add(Me.dgvEmpresas)
        Me.Controls.Add(Me.chkSoloDif)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.dtpFechaContable)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Reporte_Comparativo_Saldos_Cooperativa"
        Me.Text = "Contabilidad - Reporte Comparativo Saldos Cooperativa"
        CType(Me.dgvEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipoSol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbTipoAh.ResumeLayout(False)
        Me.gbTipoAh.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaContable As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents chkSoloDif As System.Windows.Forms.CheckBox
    Friend WithEvents dgvEmpresas As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTipoSol As System.Windows.Forms.DataGridView
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents descempresa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents origen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkEmpresasTodas As System.Windows.Forms.CheckBox
    Friend WithEvents chkRubrosTodos As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAhorros As System.Windows.Forms.RadioButton
    Friend WithEvents rbDeudas As System.Windows.Forms.RadioButton
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents chkRptGuardado As System.Windows.Forms.CheckBox
    Friend WithEvents gbTipoAh As System.Windows.Forms.GroupBox
    Friend WithEvents chkOrdin As System.Windows.Forms.CheckBox
    Friend WithEvents chkExtra As System.Windows.Forms.CheckBox
End Class
