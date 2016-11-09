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
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbAsociacion = New System.Windows.Forms.ComboBox
        Me.dgvTipoSolicitud = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.tiposoli = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvTipoSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(259, 36)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(662, 481)
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
        Me.cmbAsociacion.Size = New System.Drawing.Size(508, 24)
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
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipoSolicitud.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvTipoSolicitud.RowHeadersVisible = False
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipoSolicitud.RowsDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvTipoSolicitud.Size = New System.Drawing.Size(241, 513)
        Me.dgvTipoSolicitud.TabIndex = 9
        '
        'selec
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.NullValue = False
        Me.selec.DefaultCellStyle = DataGridViewCellStyle21
        Me.selec.HeaderText = "*"
        Me.selec.Name = "selec"
        Me.selec.Width = 30
        '
        'tiposoli
        '
        Me.tiposoli.DataPropertyName = "SOLICITUD"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.tiposoli.DefaultCellStyle = DataGridViewCellStyle22
        Me.tiposoli.HeaderText = "Tipo Solicitud"
        Me.tiposoli.Name = "tiposoli"
        Me.tiposoli.Visible = False
        '
        'descripcion
        '
        Me.descripcion.DataPropertyName = "DESCRIPCION"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Navy
        Me.descripcion.DefaultCellStyle = DataGridViewCellStyle23
        Me.descripcion.HeaderText = "Seleccione Tipo de Solicitud"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 190
        '
        'Cooperaitiva_Reporte_Deudas_Agrupado_Anual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 529)
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
End Class
