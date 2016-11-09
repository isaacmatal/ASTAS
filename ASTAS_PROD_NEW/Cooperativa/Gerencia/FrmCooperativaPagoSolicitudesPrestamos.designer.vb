<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCooperativaPagoSolicitudesPrestamos
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCooperativaPagoSolicitudesPrestamos))
        Me.DgvProgramaciones = New System.Windows.Forms.DataGridView
        Me.procesa = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.numsoli = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codbuxis = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bancosocio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CtaSocio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.monto_pendiente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.observ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.origen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.interes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.segurodeuda = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.periodo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsPagoPrestamo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiCheques = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiRemesas = New System.Windows.Forms.ToolStripMenuItem
        Me.dpFechaProceso = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblProc = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbCuentaBancoAsociacion = New System.Windows.Forms.ComboBox
        Me.lblSelecciona = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.btnProcesar = New System.Windows.Forms.Button
        CType(Me.DgvProgramaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPagoPrestamo.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvProgramaciones
        '
        Me.DgvProgramaciones.AllowUserToAddRows = False
        Me.DgvProgramaciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvProgramaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvProgramaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvProgramaciones.BackgroundColor = System.Drawing.Color.MintCream
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvProgramaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvProgramaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvProgramaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.procesa, Me.numsoli, Me.codas, Me.codbuxis, Me.nombre, Me.bancosocio, Me.CtaSocio, Me.monto_pendiente, Me.Fecha, Me.observ, Me.origen, Me.interes, Me.segurodeuda, Me.periodo})
        Me.DgvProgramaciones.ContextMenuStrip = Me.cmsPagoPrestamo
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvProgramaciones.DefaultCellStyle = DataGridViewCellStyle14
        Me.DgvProgramaciones.Location = New System.Drawing.Point(4, 120)
        Me.DgvProgramaciones.MultiSelect = False
        Me.DgvProgramaciones.Name = "DgvProgramaciones"
        Me.DgvProgramaciones.RowHeadersVisible = False
        Me.DgvProgramaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProgramaciones.Size = New System.Drawing.Size(886, 351)
        Me.DgvProgramaciones.TabIndex = 127
        '
        'procesa
        '
        Me.procesa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.procesa.HeaderText = ""
        Me.procesa.Name = "procesa"
        Me.procesa.ReadOnly = True
        Me.procesa.Width = 5
        '
        'numsoli
        '
        Me.numsoli.DataPropertyName = "CORRELATIVO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.numsoli.DefaultCellStyle = DataGridViewCellStyle3
        Me.numsoli.HeaderText = "Número Solicitud"
        Me.numsoli.Name = "numsoli"
        Me.numsoli.ReadOnly = True
        Me.numsoli.Width = 60
        '
        'codas
        '
        Me.codas.DataPropertyName = "CODIGO_AS"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codas.DefaultCellStyle = DataGridViewCellStyle4
        Me.codas.HeaderText = "Código AS"
        Me.codas.Name = "codas"
        Me.codas.ReadOnly = True
        Me.codas.Width = 60
        '
        'codbuxis
        '
        Me.codbuxis.DataPropertyName = "CODIGO_BUXIS"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codbuxis.DefaultCellStyle = DataGridViewCellStyle5
        Me.codbuxis.HeaderText = "Código Buxis"
        Me.codbuxis.Name = "codbuxis"
        Me.codbuxis.ReadOnly = True
        Me.codbuxis.Width = 50
        '
        'nombre
        '
        Me.nombre.DataPropertyName = "NOMBRE_COMPLETO"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.nombre.DefaultCellStyle = DataGridViewCellStyle6
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 220
        '
        'bancosocio
        '
        Me.bancosocio.DataPropertyName = "BANCO_SOCIO"
        Me.bancosocio.HeaderText = "Banco del Socio"
        Me.bancosocio.Name = "bancosocio"
        Me.bancosocio.ReadOnly = True
        Me.bancosocio.Width = 120
        '
        'CtaSocio
        '
        Me.CtaSocio.DataPropertyName = "CUENTA_BANCO_SOCIO"
        Me.CtaSocio.HeaderText = "Cuenta Socio"
        Me.CtaSocio.Name = "CtaSocio"
        Me.CtaSocio.ReadOnly = True
        '
        'monto_pendiente
        '
        Me.monto_pendiente.DataPropertyName = "Monto_Pendiente"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.monto_pendiente.DefaultCellStyle = DataGridViewCellStyle7
        Me.monto_pendiente.HeaderText = "Monto"
        Me.monto_pendiente.Name = "monto_pendiente"
        Me.monto_pendiente.ReadOnly = True
        Me.monto_pendiente.Width = 70
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "FECHA_SOLICITUD"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle8
        Me.Fecha.HeaderText = "Fecha Solicitud"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 80
        '
        'observ
        '
        Me.observ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.observ.DataPropertyName = "RAZON"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.observ.DefaultCellStyle = DataGridViewCellStyle9
        Me.observ.HeaderText = "Motivo Prestamo"
        Me.observ.Name = "observ"
        Me.observ.ReadOnly = True
        Me.observ.Width = 111
        '
        'origen
        '
        Me.origen.DataPropertyName = "ORIGEN"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.origen.DefaultCellStyle = DataGridViewCellStyle10
        Me.origen.HeaderText = "Origen"
        Me.origen.Name = "origen"
        Me.origen.Visible = False
        Me.origen.Width = 50
        '
        'interes
        '
        Me.interes.DataPropertyName = "INTERES"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.interes.DefaultCellStyle = DataGridViewCellStyle11
        Me.interes.HeaderText = "Interes"
        Me.interes.Name = "interes"
        Me.interes.Visible = False
        '
        'segurodeuda
        '
        Me.segurodeuda.DataPropertyName = "SEGURO"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.segurodeuda.DefaultCellStyle = DataGridViewCellStyle12
        Me.segurodeuda.HeaderText = "Seguro"
        Me.segurodeuda.Name = "segurodeuda"
        Me.segurodeuda.Visible = False
        '
        'periodo
        '
        Me.periodo.DataPropertyName = "PERIODO"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.periodo.DefaultCellStyle = DataGridViewCellStyle13
        Me.periodo.HeaderText = "Periodo"
        Me.periodo.Name = "periodo"
        Me.periodo.Visible = False
        '
        'cmsPagoPrestamo
        '
        Me.cmsPagoPrestamo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCheques, Me.tsmiRemesas})
        Me.cmsPagoPrestamo.Name = "cmsPagoPrestamo"
        Me.cmsPagoPrestamo.Size = New System.Drawing.Size(121, 48)
        '
        'tsmiCheques
        '
        Me.tsmiCheques.Image = CType(resources.GetObject("tsmiCheques.Image"), System.Drawing.Image)
        Me.tsmiCheques.Name = "tsmiCheques"
        Me.tsmiCheques.Size = New System.Drawing.Size(120, 22)
        Me.tsmiCheques.Text = "&Cheques"
        '
        'tsmiRemesas
        '
        Me.tsmiRemesas.Image = CType(resources.GetObject("tsmiRemesas.Image"), System.Drawing.Image)
        Me.tsmiRemesas.Name = "tsmiRemesas"
        Me.tsmiRemesas.Size = New System.Drawing.Size(120, 22)
        Me.tsmiRemesas.Text = "&Remesas"
        '
        'dpFechaProceso
        '
        Me.dpFechaProceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaProceso.Location = New System.Drawing.Point(172, 6)
        Me.dpFechaProceso.Name = "dpFechaProceso"
        Me.dpFechaProceso.Size = New System.Drawing.Size(97, 22)
        Me.dpFechaProceso.TabIndex = 130
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Fecha Proceso:"
        '
        'lblProc
        '
        Me.lblProc.AutoSize = True
        Me.lblProc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProc.ForeColor = System.Drawing.Color.Red
        Me.lblProc.Location = New System.Drawing.Point(466, 12)
        Me.lblProc.Name = "lblProc"
        Me.lblProc.Size = New System.Drawing.Size(71, 16)
        Me.lblProc.TabIndex = 132
        Me.lblProc.Text = "Procesando"
        Me.lblProc.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 16)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "Cuenta Bancaria Asociación:"
        '
        'cmbCuentaBancoAsociacion
        '
        Me.cmbCuentaBancoAsociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuentaBancoAsociacion.FormattingEnabled = True
        Me.cmbCuentaBancoAsociacion.Location = New System.Drawing.Point(172, 48)
        Me.cmbCuentaBancoAsociacion.Name = "cmbCuentaBancoAsociacion"
        Me.cmbCuentaBancoAsociacion.Size = New System.Drawing.Size(404, 24)
        Me.cmbCuentaBancoAsociacion.TabIndex = 136
        '
        'lblSelecciona
        '
        Me.lblSelecciona.AutoSize = True
        Me.lblSelecciona.BackColor = System.Drawing.Color.Transparent
        Me.lblSelecciona.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblSelecciona.Location = New System.Drawing.Point(12, 94)
        Me.lblSelecciona.Name = "lblSelecciona"
        Me.lblSelecciona.Size = New System.Drawing.Size(136, 16)
        Me.lblSelecciona.TabIndex = 139
        Me.lblSelecciona.Text = "Marcar / Desmarcar Todos"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Navy
        Me.Label14.Location = New System.Drawing.Point(197, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 20)
        Me.Label14.TabIndex = 140
        Me.Label14.Text = "Total: $ 0.00"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.Color.Transparent
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscar.Image = Global.ASTAS.My.Resources.Resources.search
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(662, 8)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(75, 37)
        Me.BtnBuscar.TabIndex = 124
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'btnProcesar
        '
        Me.btnProcesar.BackColor = System.Drawing.Color.Transparent
        Me.btnProcesar.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(662, 65)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 37)
        Me.btnProcesar.TabIndex = 128
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcesar.UseVisualStyleBackColor = False
        '
        'FrmCooperativaPagoSolicitudesPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 473)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblSelecciona)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblProc)
        Me.Controls.Add(Me.cmbCuentaBancoAsociacion)
        Me.Controls.Add(Me.dpFechaProceso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DgvProgramaciones)
        Me.Controls.Add(Me.BtnBuscar)
        Me.Controls.Add(Me.btnProcesar)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmCooperativaPagoSolicitudesPrestamos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Remesas Solicitudes Préstamos"
        CType(Me.DgvProgramaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPagoPrestamo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvProgramaciones As System.Windows.Forms.DataGridView
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents cmsPagoPrestamo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiCheques As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiRemesas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents dpFechaProceso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblProc As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCuentaBancoAsociacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblSelecciona As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents procesa As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents numsoli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codbuxis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bancosocio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CtaSocio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents monto_pendiente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents observ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents origen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents interes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents segurodeuda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents periodo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
