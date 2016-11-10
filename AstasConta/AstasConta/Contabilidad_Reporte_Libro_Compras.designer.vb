<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CONTABILIDAD_REPORTE_LIBRO_COMPRAS
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvBodegas = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.bodega = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codbod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.compan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.usuar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label3 = New System.Windows.Forms.Label
        Me.ChkConsolida = New System.Windows.Forms.CheckBox
        Me.Fecha_Fin = New System.Windows.Forms.DateTimePicker
        Me.fecha_Ini = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dgvBodegas)
        Me.GroupBox1.Controls.Add(Me.crvReporte)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ChkConsolida)
        Me.GroupBox1.Controls.Add(Me.Fecha_Fin)
        Me.GroupBox1.Controls.Add(Me.fecha_Ini)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(905, 572)
        Me.GroupBox1.TabIndex = 103
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'dgvBodegas
        '
        Me.dgvBodegas.AllowUserToAddRows = False
        Me.dgvBodegas.AllowUserToDeleteRows = False
        Me.dgvBodegas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvBodegas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBodegas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvBodegas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvBodegas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBodegas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBodegas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBodegas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selec, Me.bodega, Me.codbod, Me.compan, Me.usuar})
        Me.dgvBodegas.Location = New System.Drawing.Point(6, 80)
        Me.dgvBodegas.Name = "dgvBodegas"
        Me.dgvBodegas.RowHeadersVisible = False
        Me.dgvBodegas.Size = New System.Drawing.Size(337, 485)
        Me.dgvBodegas.TabIndex = 106
        '
        'selec
        '
        Me.selec.HeaderText = ""
        Me.selec.Name = "selec"
        Me.selec.Width = 30
        '
        'bodega
        '
        Me.bodega.DataPropertyName = "DESCRIPCION_BODEGA"
        Me.bodega.HeaderText = "BODEGA"
        Me.bodega.Name = "bodega"
        Me.bodega.Width = 285
        '
        'codbod
        '
        Me.codbod.DataPropertyName = "BODEGA"
        Me.codbod.HeaderText = "Codigo Bodega"
        Me.codbod.Name = "codbod"
        Me.codbod.Visible = False
        '
        'compan
        '
        Me.compan.DataPropertyName = "COMPAÑIA"
        Me.compan.HeaderText = "compañia"
        Me.compan.Name = "compan"
        Me.compan.Visible = False
        '
        'usuar
        '
        Me.usuar.DataPropertyName = "USUARIO"
        Me.usuar.HeaderText = "usuario"
        Me.usuar.Name = "usuar"
        Me.usuar.Visible = False
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Location = New System.Drawing.Point(349, 80)
        Me.crvReporte.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.SelectionFormula = ""
        Me.crvReporte.ShowGroupTreeButton = False
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.Size = New System.Drawing.Size(547, 484)
        Me.crvReporte.TabIndex = 105
        Me.crvReporte.ViewTimeSelectionFormula = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(223, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Hasta :"
        '
        'ChkConsolida
        '
        Me.ChkConsolida.AutoSize = True
        Me.ChkConsolida.Location = New System.Drawing.Point(13, 53)
        Me.ChkConsolida.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ChkConsolida.Name = "ChkConsolida"
        Me.ChkConsolida.Size = New System.Drawing.Size(146, 20)
        Me.ChkConsolida.TabIndex = 4
        Me.ChkConsolida.Text = "Todas las Bodegas"
        Me.ChkConsolida.UseVisualStyleBackColor = True
        '
        'Fecha_Fin
        '
        Me.Fecha_Fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha_Fin.Location = New System.Drawing.Point(272, 18)
        Me.Fecha_Fin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Fecha_Fin.Name = "Fecha_Fin"
        Me.Fecha_Fin.Size = New System.Drawing.Size(112, 22)
        Me.Fecha_Fin.TabIndex = 3
        '
        'fecha_Ini
        '
        Me.fecha_Ini.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha_Ini.CalendarForeColor = System.Drawing.Color.Navy
        Me.fecha_Ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_Ini.Location = New System.Drawing.Point(104, 18)
        Me.fecha_Ini.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.fecha_Ini.Name = "fecha_Ini"
        Me.fecha_Ini.Size = New System.Drawing.Size(112, 22)
        Me.fecha_Ini.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(10, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Período Desde :"
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImprimir.Image = Global.AstasConta.My.Resources.Resources.exec
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(390, 18)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(77, 44)
        Me.btnImprimir.TabIndex = 5
        Me.btnImprimir.Text = "&Generar"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'CONTABILIDAD_REPORTE_LIBRO_COMPRAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 588)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "CONTABILIDAD_REPORTE_LIBRO_COMPRAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Libro de Compras"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents fecha_Ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Fecha_Fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkConsolida As System.Windows.Forms.CheckBox
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvBodegas As System.Windows.Forms.DataGridView
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents bodega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codbod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents compan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usuar As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
