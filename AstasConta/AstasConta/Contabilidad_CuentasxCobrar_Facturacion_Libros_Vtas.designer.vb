<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_CuentasxCobrar_Facturacion_Libros_Vtas
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
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.gbGral = New System.Windows.Forms.GroupBox
        Me.dgvBodegas = New System.Windows.Forms.DataGridView
        Me.Chk_Todas_Bodegas = New System.Windows.Forms.CheckBox
        Me.chkSimple = New System.Windows.Forms.CheckBox
        Me.chkExtraContable = New System.Windows.Forms.CheckBox
        Me.chkImprimirResumen = New System.Windows.Forms.CheckBox
        Me.btnReporte = New System.Windows.Forms.Button
        Me.gbFiltro = New System.Windows.Forms.GroupBox
        Me.dpFECHA_HASTA = New System.Windows.Forms.DateTimePicker
        Me.dpFECHA_DESDE = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbTIPO_DOCUMENTO = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.bodega = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codbod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.compan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.usuar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbGral.SuspendLayout()
        CType(Me.dgvBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFiltro.SuspendLayout()
        Me.SuspendLayout()
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvReporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crvReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Location = New System.Drawing.Point(343, 85)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.SelectionFormula = ""
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.Size = New System.Drawing.Size(619, 427)
        Me.crvReporte.TabIndex = 1
        Me.crvReporte.ViewTimeSelectionFormula = ""
        '
        'gbGral
        '
        Me.gbGral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbGral.BackColor = System.Drawing.Color.Transparent
        Me.gbGral.Controls.Add(Me.dgvBodegas)
        Me.gbGral.Controls.Add(Me.Chk_Todas_Bodegas)
        Me.gbGral.Controls.Add(Me.chkSimple)
        Me.gbGral.Controls.Add(Me.crvReporte)
        Me.gbGral.Controls.Add(Me.chkExtraContable)
        Me.gbGral.Controls.Add(Me.chkImprimirResumen)
        Me.gbGral.Controls.Add(Me.btnReporte)
        Me.gbGral.Controls.Add(Me.gbFiltro)
        Me.gbGral.Controls.Add(Me.cmbTIPO_DOCUMENTO)
        Me.gbGral.Controls.Add(Me.Label4)
        Me.gbGral.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGral.ForeColor = System.Drawing.Color.Navy
        Me.gbGral.Location = New System.Drawing.Point(12, 8)
        Me.gbGral.Name = "gbGral"
        Me.gbGral.Size = New System.Drawing.Size(968, 518)
        Me.gbGral.TabIndex = 0
        Me.gbGral.TabStop = False
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
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBodegas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBodegas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBodegas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selec, Me.bodega, Me.codbod, Me.compan, Me.usuar})
        Me.dgvBodegas.Location = New System.Drawing.Point(0, 85)
        Me.dgvBodegas.Name = "dgvBodegas"
        Me.dgvBodegas.RowHeadersVisible = False
        Me.dgvBodegas.Size = New System.Drawing.Size(337, 427)
        Me.dgvBodegas.TabIndex = 30
        '
        'Chk_Todas_Bodegas
        '
        Me.Chk_Todas_Bodegas.AutoSize = True
        Me.Chk_Todas_Bodegas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Todas_Bodegas.ForeColor = System.Drawing.Color.Navy
        Me.Chk_Todas_Bodegas.Location = New System.Drawing.Point(10, 60)
        Me.Chk_Todas_Bodegas.Name = "Chk_Todas_Bodegas"
        Me.Chk_Todas_Bodegas.Size = New System.Drawing.Size(127, 20)
        Me.Chk_Todas_Bodegas.TabIndex = 5
        Me.Chk_Todas_Bodegas.Text = "&Todas las Bodegas"
        Me.Chk_Todas_Bodegas.UseVisualStyleBackColor = True
        '
        'chkSimple
        '
        Me.chkSimple.AutoSize = True
        Me.chkSimple.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSimple.ForeColor = System.Drawing.Color.Navy
        Me.chkSimple.Location = New System.Drawing.Point(648, 38)
        Me.chkSimple.Name = "chkSimple"
        Me.chkSimple.Size = New System.Drawing.Size(144, 20)
        Me.chkSimple.TabIndex = 6
        Me.chkSimple.Text = "&Simple Extra Contable"
        Me.chkSimple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkSimple.UseVisualStyleBackColor = True
        '
        'chkExtraContable
        '
        Me.chkExtraContable.AutoSize = True
        Me.chkExtraContable.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExtraContable.ForeColor = System.Drawing.Color.Navy
        Me.chkExtraContable.Location = New System.Drawing.Point(648, 20)
        Me.chkExtraContable.Name = "chkExtraContable"
        Me.chkExtraContable.Size = New System.Drawing.Size(105, 20)
        Me.chkExtraContable.TabIndex = 5
        Me.chkExtraContable.Text = "&Extra Contable"
        Me.chkExtraContable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkExtraContable.UseVisualStyleBackColor = True
        '
        'chkImprimirResumen
        '
        Me.chkImprimirResumen.AutoSize = True
        Me.chkImprimirResumen.Checked = True
        Me.chkImprimirResumen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImprimirResumen.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImprimirResumen.ForeColor = System.Drawing.Color.Navy
        Me.chkImprimirResumen.Location = New System.Drawing.Point(648, 56)
        Me.chkImprimirResumen.Name = "chkImprimirResumen"
        Me.chkImprimirResumen.Size = New System.Drawing.Size(119, 20)
        Me.chkImprimirResumen.TabIndex = 7
        Me.chkImprimirResumen.Text = "&Mostrar Resumen"
        Me.chkImprimirResumen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkImprimirResumen.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnReporte.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnReporte.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnReporte.Image = Global.AstasConta.My.Resources.Resources.exec
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnReporte.Location = New System.Drawing.Point(354, 23)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(89, 49)
        Me.btnReporte.TabIndex = 8
        Me.btnReporte.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Libro Ventas"
        Me.btnReporte.UseVisualStyleBackColor = False
        '
        'gbFiltro
        '
        Me.gbFiltro.Controls.Add(Me.dpFECHA_HASTA)
        Me.gbFiltro.Controls.Add(Me.dpFECHA_DESDE)
        Me.gbFiltro.Controls.Add(Me.Label10)
        Me.gbFiltro.Controls.Add(Me.Label16)
        Me.gbFiltro.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFiltro.ForeColor = System.Drawing.Color.Navy
        Me.gbFiltro.Location = New System.Drawing.Point(467, 11)
        Me.gbFiltro.Name = "gbFiltro"
        Me.gbFiltro.Size = New System.Drawing.Size(158, 69)
        Me.gbFiltro.TabIndex = 4
        Me.gbFiltro.TabStop = False
        Me.gbFiltro.Text = "Fechas"
        '
        'dpFECHA_HASTA
        '
        Me.dpFECHA_HASTA.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_HASTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_HASTA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_HASTA.Location = New System.Drawing.Point(49, 41)
        Me.dpFECHA_HASTA.Name = "dpFECHA_HASTA"
        Me.dpFECHA_HASTA.Size = New System.Drawing.Size(104, 22)
        Me.dpFECHA_HASTA.TabIndex = 2
        '
        'dpFECHA_DESDE
        '
        Me.dpFECHA_DESDE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_DESDE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_DESDE.Location = New System.Drawing.Point(49, 16)
        Me.dpFECHA_DESDE.Name = "dpFECHA_DESDE"
        Me.dpFECHA_DESDE.Size = New System.Drawing.Size(104, 22)
        Me.dpFECHA_DESDE.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(2, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 16)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Desde :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Navy
        Me.Label16.Location = New System.Drawing.Point(2, 44)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 16)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Hasta :"
        '
        'cmbTIPO_DOCUMENTO
        '
        Me.cmbTIPO_DOCUMENTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_DOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_DOCUMENTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_DOCUMENTO.FormattingEnabled = True
        Me.cmbTIPO_DOCUMENTO.Items.AddRange(New Object() {"Consumidor Final", "Crédito Fiscal"})
        Me.cmbTIPO_DOCUMENTO.Location = New System.Drawing.Point(104, 26)
        Me.cmbTIPO_DOCUMENTO.Name = "cmbTIPO_DOCUMENTO"
        Me.cmbTIPO_DOCUMENTO.Size = New System.Drawing.Size(240, 24)
        Me.cmbTIPO_DOCUMENTO.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(7, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Tipo Documento :"
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
        'Contabilidad_CuentasxCobrar_Facturacion_Libros_Vtas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 538)
        Me.Controls.Add(Me.gbGral)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_CuentasxCobrar_Facturacion_Libros_Vtas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Libros de Ventas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbGral.ResumeLayout(False)
        Me.gbGral.PerformLayout()
        CType(Me.dgvBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFiltro.ResumeLayout(False)
        Me.gbFiltro.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents gbGral As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTIPO_DOCUMENTO As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents dpFECHA_HASTA As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpFECHA_DESDE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkImprimirResumen As System.Windows.Forms.CheckBox
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents chkExtraContable As System.Windows.Forms.CheckBox
    Friend WithEvents chkSimple As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Todas_Bodegas As System.Windows.Forms.CheckBox
    Friend WithEvents dgvBodegas As System.Windows.Forms.DataGridView
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents bodega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codbod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents compan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usuar As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
