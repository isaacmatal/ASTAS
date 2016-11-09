<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CooperativaReporteEstadoCuentaDeudas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CooperativaReporteEstadoCuentaDeudas))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkTodas = New System.Windows.Forms.CheckBox
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.dpHasta = New System.Windows.Forms.DateTimePicker
        Me.dpDesde = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnLimpiarCampos = New System.Windows.Forms.Button
        Me.lblNombreSocio = New System.Windows.Forms.Label
        Me.txtCodBuxis = New System.Windows.Forms.TextBox
        Me.BtnBuscarSoc = New System.Windows.Forms.Button
        Me.txtCodSocio = New System.Windows.Forms.TextBox
        Me.txtRetiroConcepto = New System.Windows.Forms.TextBox
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.dgvTipoSolicitud = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.tiposoli = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvTipoSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkTodas)
        Me.GroupBox1.Controls.Add(Me.btnGenerar)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dpHasta)
        Me.GroupBox1.Controls.Add(Me.dpDesde)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnLimpiarCampos)
        Me.GroupBox1.Controls.Add(Me.lblNombreSocio)
        Me.GroupBox1.Controls.Add(Me.txtCodBuxis)
        Me.GroupBox1.Controls.Add(Me.BtnBuscarSoc)
        Me.GroupBox1.Controls.Add(Me.txtCodSocio)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(922, 76)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones"
        '
        'chkTodas
        '
        Me.chkTodas.AutoSize = True
        Me.chkTodas.Location = New System.Drawing.Point(384, 50)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(126, 17)
        Me.chkTodas.TabIndex = 41
        Me.chkTodas.Text = "Todas las Solicitudes"
        Me.chkTodas.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(8, 46)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 40
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Codigo Buxis:"
        '
        'dpHasta
        '
        Me.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpHasta.Location = New System.Drawing.Point(277, 48)
        Me.dpHasta.Name = "dpHasta"
        Me.dpHasta.Size = New System.Drawing.Size(94, 20)
        Me.dpHasta.TabIndex = 38
        '
        'dpDesde
        '
        Me.dpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDesde.Location = New System.Drawing.Point(138, 48)
        Me.dpDesde.Name = "dpDesde"
        Me.dpDesde.Size = New System.Drawing.Size(86, 20)
        Me.dpDesde.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(235, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(93, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Desde:"
        '
        'btnLimpiarCampos
        '
        Me.btnLimpiarCampos.BackColor = System.Drawing.Color.Transparent
        Me.btnLimpiarCampos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarCampos.ForeColor = System.Drawing.Color.Black
        Me.btnLimpiarCampos.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.btnLimpiarCampos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarCampos.Location = New System.Drawing.Point(163, 18)
        Me.btnLimpiarCampos.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.btnLimpiarCampos.Name = "btnLimpiarCampos"
        Me.btnLimpiarCampos.Size = New System.Drawing.Size(24, 25)
        Me.btnLimpiarCampos.TabIndex = 32
        Me.btnLimpiarCampos.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnLimpiarCampos.UseVisualStyleBackColor = False
        '
        'lblNombreSocio
        '
        Me.lblNombreSocio.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreSocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreSocio.ForeColor = System.Drawing.Color.Navy
        Me.lblNombreSocio.Location = New System.Drawing.Point(192, 15)
        Me.lblNombreSocio.Name = "lblNombreSocio"
        Me.lblNombreSocio.Size = New System.Drawing.Size(305, 31)
        Me.lblNombreSocio.TabIndex = 31
        Me.lblNombreSocio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodBuxis
        '
        Me.txtCodBuxis.Location = New System.Drawing.Point(81, 20)
        Me.txtCodBuxis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodBuxis.Name = "txtCodBuxis"
        Me.txtCodBuxis.Size = New System.Drawing.Size(56, 20)
        Me.txtCodBuxis.TabIndex = 27
        '
        'BtnBuscarSoc
        '
        Me.BtnBuscarSoc.BackColor = System.Drawing.Color.Transparent
        Me.BtnBuscarSoc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarSoc.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSoc.Image = CType(resources.GetObject("BtnBuscarSoc.Image"), System.Drawing.Image)
        Me.BtnBuscarSoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSoc.Location = New System.Drawing.Point(138, 18)
        Me.BtnBuscarSoc.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.BtnBuscarSoc.Name = "BtnBuscarSoc"
        Me.BtnBuscarSoc.Size = New System.Drawing.Size(24, 25)
        Me.BtnBuscarSoc.TabIndex = 30
        Me.BtnBuscarSoc.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnBuscarSoc.UseVisualStyleBackColor = False
        '
        'txtCodSocio
        '
        Me.txtCodSocio.Location = New System.Drawing.Point(436, 21)
        Me.txtCodSocio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodSocio.Name = "txtCodSocio"
        Me.txtCodSocio.Size = New System.Drawing.Size(78, 20)
        Me.txtCodSocio.TabIndex = 28
        Me.txtCodSocio.Visible = False
        '
        'txtRetiroConcepto
        '
        Me.txtRetiroConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetiroConcepto.ForeColor = System.Drawing.Color.Red
        Me.txtRetiroConcepto.Location = New System.Drawing.Point(519, 13)
        Me.txtRetiroConcepto.Multiline = True
        Me.txtRetiroConcepto.Name = "txtRetiroConcepto"
        Me.txtRetiroConcepto.Size = New System.Drawing.Size(276, 57)
        Me.txtRetiroConcepto.TabIndex = 41
        Me.txtRetiroConcepto.Visible = False
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Location = New System.Drawing.Point(249, 83)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.SelectionFormula = ""
        Me.crvReporte.ShowGotoPageButton = False
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.Size = New System.Drawing.Size(681, 387)
        Me.crvReporte.TabIndex = 1
        Me.crvReporte.ViewTimeSelectionFormula = ""
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
        Me.dgvTipoSolicitud.Location = New System.Drawing.Point(4, 83)
        Me.dgvTipoSolicitud.Name = "dgvTipoSolicitud"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipoSolicitud.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTipoSolicitud.RowHeadersVisible = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipoSolicitud.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTipoSolicitud.Size = New System.Drawing.Size(241, 387)
        Me.dgvTipoSolicitud.TabIndex = 2
        '
        'selec
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.NullValue = False
        Me.selec.DefaultCellStyle = DataGridViewCellStyle1
        Me.selec.HeaderText = "*"
        Me.selec.Name = "selec"
        Me.selec.Width = 30
        '
        'tiposoli
        '
        Me.tiposoli.DataPropertyName = "SOLICITUD"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.tiposoli.DefaultCellStyle = DataGridViewCellStyle2
        Me.tiposoli.HeaderText = "Tipo Solicitud"
        Me.tiposoli.Name = "tiposoli"
        Me.tiposoli.Visible = False
        '
        'descripcion
        '
        Me.descripcion.DataPropertyName = "DESCRIPCION"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        Me.descripcion.DefaultCellStyle = DataGridViewCellStyle3
        Me.descripcion.HeaderText = "Seleccione Tipo de Solicitud"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 190
        '
        'CooperativaReporteEstadoCuentaDeudas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 469)
        Me.Controls.Add(Me.txtRetiroConcepto)
        Me.Controls.Add(Me.dgvTipoSolicitud)
        Me.Controls.Add(Me.crvReporte)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "CooperativaReporteEstadoCuentaDeudas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Estado Cuenta de Socios (Deudas)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvTipoSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarCampos As System.Windows.Forms.Button
    Friend WithEvents lblNombreSocio As System.Windows.Forms.Label
    Friend WithEvents txtCodBuxis As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarSoc As System.Windows.Forms.Button
    Friend WithEvents txtCodSocio As System.Windows.Forms.TextBox
    Friend WithEvents dpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents txtRetiroConcepto As System.Windows.Forms.TextBox
    Friend WithEvents dgvTipoSolicitud As System.Windows.Forms.DataGridView
    Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tiposoli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
