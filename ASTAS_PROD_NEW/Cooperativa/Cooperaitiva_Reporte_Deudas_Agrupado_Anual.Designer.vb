<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cooperaitiva_Reporte_Deudas_Agrupado_Anual
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbAsociacion = New System.Windows.Forms.ComboBox
        Me.dgvTipoSolicitud = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.chkTodasSolicitudes = New System.Windows.Forms.CheckBox
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tiposoli = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpFechaRep = New System.Windows.Forms.DateTimePicker
        CType(Me.dgvTipoSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(259, 36)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(784, 481)
        Me.CrystalReportViewer1.TabIndex = 5
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(259, 7)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 6
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(350, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Asociación:"
        '
        'cmbAsociacion
        '
        Me.cmbAsociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAsociacion.DropDownWidth = 500
        Me.cmbAsociacion.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAsociacion.FormattingEnabled = True
        Me.cmbAsociacion.Location = New System.Drawing.Point(413, 6)
        Me.cmbAsociacion.Name = "cmbAsociacion"
        Me.cmbAsociacion.Size = New System.Drawing.Size(403, 24)
        Me.cmbAsociacion.TabIndex = 7
        '
        'dgvTipoSolicitud
        '
        Me.dgvTipoSolicitud.AllowUserToAddRows = False
        Me.dgvTipoSolicitud.AllowUserToDeleteRows = False
        Me.dgvTipoSolicitud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvTipoSolicitud.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvTipoSolicitud.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.dgvTipoSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTipoSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipoSolicitud.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selec, Me.tiposoli, Me.descripcion})
        Me.dgvTipoSolicitud.GridColor = System.Drawing.Color.AliceBlue
        Me.dgvTipoSolicitud.Location = New System.Drawing.Point(12, 6)
        Me.dgvTipoSolicitud.Name = "dgvTipoSolicitud"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipoSolicitud.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvTipoSolicitud.RowHeadersVisible = False
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipoSolicitud.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvTipoSolicitud.Size = New System.Drawing.Size(241, 513)
        Me.dgvTipoSolicitud.TabIndex = 9
        '
        'selec
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.NullValue = False
        Me.selec.DefaultCellStyle = DataGridViewCellStyle8
        Me.selec.HeaderText = "*"
        Me.selec.Name = "selec"
        Me.selec.Width = 30
        '
        'chkTodasSolicitudes
        '
        Me.chkTodasSolicitudes.AutoSize = True
        Me.chkTodasSolicitudes.Location = New System.Drawing.Point(21, 12)
        Me.chkTodasSolicitudes.Name = "chkTodasSolicitudes"
        Me.chkTodasSolicitudes.Size = New System.Drawing.Size(15, 14)
        Me.chkTodasSolicitudes.TabIndex = 10
        Me.chkTodasSolicitudes.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "SOLICITUD"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn1.HeaderText = "Tipo Solicitud"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DESCRIPCION"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Navy
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn2.HeaderText = "Seleccione Tipo de Solicitud"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 190
        '
        'tiposoli
        '
        Me.tiposoli.DataPropertyName = "SOLICITUD"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.tiposoli.DefaultCellStyle = DataGridViewCellStyle9
        Me.tiposoli.HeaderText = "Tipo Solicitud"
        Me.tiposoli.Name = "tiposoli"
        Me.tiposoli.Visible = False
        '
        'descripcion
        '
        Me.descripcion.DataPropertyName = "DESCRIPCION"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Navy
        Me.descripcion.DefaultCellStyle = DataGridViewCellStyle10
        Me.descripcion.HeaderText = "Seleccione Tipo de Solicitud"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 190
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(832, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Hasta:"
        '
        'dtpFechaRep
        '
        Me.dtpFechaRep.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRep.Location = New System.Drawing.Point(873, 7)
        Me.dtpFechaRep.Name = "dtpFechaRep"
        Me.dtpFechaRep.Size = New System.Drawing.Size(100, 22)
        Me.dtpFechaRep.TabIndex = 12
        '
        'Cooperaitiva_Reporte_Deudas_Agrupado_Anual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1055, 529)
        Me.Controls.Add(Me.dtpFechaRep)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkTodasSolicitudes)
        Me.Controls.Add(Me.dgvTipoSolicitud)
        Me.Controls.Add(Me.cmbAsociacion)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Cooperaitiva_Reporte_Deudas_Agrupado_Anual"
        Me.Text = "Cooperaitiva - Reporte Deudas Agrupado por Año"
        CType(Me.dgvTipoSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAsociacion As System.Windows.Forms.ComboBox
    Friend WithEvents dgvTipoSolicitud As System.Windows.Forms.DataGridView
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tiposoli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkTodasSolicitudes As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaRep As System.Windows.Forms.DateTimePicker
End Class
