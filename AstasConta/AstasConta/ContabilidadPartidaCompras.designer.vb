<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadPartidaCompras
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContabilidadPartidaCompras))
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.dpFechaContable1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblMsj = New System.Windows.Forms.Label
        Me.pbAplicar = New System.Windows.Forms.ProgressBar
        Me.btnReporte = New System.Windows.Forms.Button
        Me.bw1 = New System.ComponentModel.BackgroundWorker
        Me.lblPdas = New System.Windows.Forms.Label
        Me.txtTransaccionInicial = New System.Windows.Forms.TextBox
        Me.txtTransaccionFinal = New System.Windows.Forms.TextBox
        Me.txtNumPda = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dpFechaContable2 = New System.Windows.Forms.DateTimePicker
        Me.dgvPartidas = New System.Windows.Forms.DataGridView
        Me.Linea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CuentaCompleta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescripcionCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConceptoL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cargo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Abono = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Transaccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvBodegas = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.bodega = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codbod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.compan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.usuar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkNC = New System.Windows.Forms.CheckBox
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.BackColor = System.Drawing.Color.Transparent
        Me.btnProcesar.Image = Global.AstasConta.My.Resources.Resources.exec
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(681, 26)
        Me.btnProcesar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 36)
        Me.btnProcesar.TabIndex = 1
        Me.btnProcesar.Text = "&Generar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcesar.UseVisualStyleBackColor = False
        '
        'dpFechaContable1
        '
        Me.dpFechaContable1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaContable1.Location = New System.Drawing.Point(55, 34)
        Me.dpFechaContable1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFechaContable1.Name = "dpFechaContable1"
        Me.dpFechaContable1.Size = New System.Drawing.Size(99, 22)
        Me.dpFechaContable1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(4, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Desde:"
        '
        'lblMsj
        '
        Me.lblMsj.AutoSize = True
        Me.lblMsj.BackColor = System.Drawing.Color.Transparent
        Me.lblMsj.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsj.ForeColor = System.Drawing.Color.Red
        Me.lblMsj.Location = New System.Drawing.Point(4, 4)
        Me.lblMsj.Name = "lblMsj"
        Me.lblMsj.Size = New System.Drawing.Size(91, 20)
        Me.lblMsj.TabIndex = 4
        Me.lblMsj.Text = "Procesando..."
        Me.lblMsj.Visible = False
        '
        'pbAplicar
        '
        Me.pbAplicar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbAplicar.Location = New System.Drawing.Point(101, 6)
        Me.pbAplicar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbAplicar.Name = "pbAplicar"
        Me.pbAplicar.Size = New System.Drawing.Size(750, 18)
        Me.pbAplicar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbAplicar.TabIndex = 5
        Me.pbAplicar.Visible = False
        '
        'btnReporte
        '
        Me.btnReporte.BackColor = System.Drawing.Color.Transparent
        Me.btnReporte.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(771, 26)
        Me.btnReporte.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(75, 36)
        Me.btnReporte.TabIndex = 6
        Me.btnReporte.Text = "Imprimir"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReporte.UseVisualStyleBackColor = False
        '
        'bw1
        '
        Me.bw1.WorkerReportsProgress = True
        Me.bw1.WorkerSupportsCancellation = True
        '
        'lblPdas
        '
        Me.lblPdas.AutoSize = True
        Me.lblPdas.BackColor = System.Drawing.Color.Transparent
        Me.lblPdas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPdas.ForeColor = System.Drawing.Color.Navy
        Me.lblPdas.Location = New System.Drawing.Point(320, 37)
        Me.lblPdas.Name = "lblPdas"
        Me.lblPdas.Size = New System.Drawing.Size(83, 16)
        Me.lblPdas.TabIndex = 8
        Me.lblPdas.Text = "Partida No.:"
        '
        'txtTransaccionInicial
        '
        Me.txtTransaccionInicial.Font = New System.Drawing.Font("Modern No. 20", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransaccionInicial.Location = New System.Drawing.Point(-1, 0)
        Me.txtTransaccionInicial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTransaccionInicial.Name = "txtTransaccionInicial"
        Me.txtTransaccionInicial.Size = New System.Drawing.Size(42, 19)
        Me.txtTransaccionInicial.TabIndex = 9
        Me.txtTransaccionInicial.Visible = False
        '
        'txtTransaccionFinal
        '
        Me.txtTransaccionFinal.Font = New System.Drawing.Font("Modern No. 20", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransaccionFinal.Location = New System.Drawing.Point(42, 0)
        Me.txtTransaccionFinal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTransaccionFinal.Name = "txtTransaccionFinal"
        Me.txtTransaccionFinal.Size = New System.Drawing.Size(39, 19)
        Me.txtTransaccionFinal.TabIndex = 10
        Me.txtTransaccionFinal.Visible = False
        '
        'txtNumPda
        '
        Me.txtNumPda.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumPda.ForeColor = System.Drawing.Color.Navy
        Me.txtNumPda.Location = New System.Drawing.Point(406, 34)
        Me.txtNumPda.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNumPda.Name = "txtNumPda"
        Me.txtNumPda.Size = New System.Drawing.Size(49, 22)
        Me.txtNumPda.TabIndex = 14
        Me.txtNumPda.WordWrap = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(160, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Hasta:"
        '
        'dpFechaContable2
        '
        Me.dpFechaContable2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaContable2.Location = New System.Drawing.Point(208, 34)
        Me.dpFechaContable2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFechaContable2.Name = "dpFechaContable2"
        Me.dpFechaContable2.Size = New System.Drawing.Size(101, 22)
        Me.dpFechaContable2.TabIndex = 18
        '
        'dgvPartidas
        '
        Me.dgvPartidas.AllowUserToAddRows = False
        Me.dgvPartidas.AllowUserToDeleteRows = False
        Me.dgvPartidas.AllowUserToOrderColumns = True
        Me.dgvPartidas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvPartidas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPartidas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPartidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPartidas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvPartidas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartidas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Linea, Me.codCuenta, Me.CuentaCompleta, Me.Detalle, Me.DescripcionCuenta, Me.ConceptoL, Me.Cargo, Me.Abono, Me.Transaccion})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPartidas.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPartidas.Location = New System.Drawing.Point(338, 70)
        Me.dgvPartidas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvPartidas.Name = "dgvPartidas"
        Me.dgvPartidas.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartidas.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPartidas.RowHeadersVisible = False
        Me.dgvPartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartidas.Size = New System.Drawing.Size(508, 341)
        Me.dgvPartidas.TabIndex = 28
        '
        'Linea
        '
        Me.Linea.DataPropertyName = "CORRELATIVO"
        Me.Linea.HeaderText = "Linea"
        Me.Linea.Name = "Linea"
        Me.Linea.ReadOnly = True
        Me.Linea.Visible = False
        Me.Linea.Width = 40
        '
        'codCuenta
        '
        Me.codCuenta.DataPropertyName = "CUENTA_CONTABLE"
        Me.codCuenta.HeaderText = "Cod. Cuenta"
        Me.codCuenta.Name = "codCuenta"
        Me.codCuenta.ReadOnly = True
        Me.codCuenta.Visible = False
        Me.codCuenta.Width = 74
        '
        'CuentaCompleta
        '
        Me.CuentaCompleta.DataPropertyName = "CUENTA_COMPLETA"
        Me.CuentaCompleta.HeaderText = "Cuenta"
        Me.CuentaCompleta.Name = "CuentaCompleta"
        Me.CuentaCompleta.ReadOnly = True
        Me.CuentaCompleta.Width = 67
        '
        'Detalle
        '
        Me.Detalle.DataPropertyName = "COD_DETALLE"
        Me.Detalle.HeaderText = "Detalle"
        Me.Detalle.Name = "Detalle"
        Me.Detalle.ReadOnly = True
        Me.Detalle.Width = 65
        '
        'DescripcionCuenta
        '
        Me.DescripcionCuenta.DataPropertyName = "DESCRIPCION_CUENTA"
        Me.DescripcionCuenta.HeaderText = "Descripción Cuenta"
        Me.DescripcionCuenta.Name = "DescripcionCuenta"
        Me.DescripcionCuenta.ReadOnly = True
        Me.DescripcionCuenta.Width = 115
        '
        'ConceptoL
        '
        Me.ConceptoL.DataPropertyName = "CONCEPTO"
        Me.ConceptoL.HeaderText = "Concepto"
        Me.ConceptoL.Name = "ConceptoL"
        Me.ConceptoL.ReadOnly = True
        Me.ConceptoL.Width = 78
        '
        'Cargo
        '
        Me.Cargo.DataPropertyName = "CARGOS"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Cargo.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cargo.HeaderText = "Cargo"
        Me.Cargo.Name = "Cargo"
        Me.Cargo.ReadOnly = True
        Me.Cargo.Width = 63
        '
        'Abono
        '
        Me.Abono.DataPropertyName = "ABONOS"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Abono.DefaultCellStyle = DataGridViewCellStyle4
        Me.Abono.HeaderText = "Abono"
        Me.Abono.Name = "Abono"
        Me.Abono.ReadOnly = True
        Me.Abono.Width = 64
        '
        'Transaccion
        '
        Me.Transaccion.DataPropertyName = "TRANSACCION"
        Me.Transaccion.HeaderText = "Transacción"
        Me.Transaccion.Name = "Transaccion"
        Me.Transaccion.ReadOnly = True
        Me.Transaccion.Visible = False
        Me.Transaccion.Width = 91
        '
        'dgvBodegas
        '
        Me.dgvBodegas.AllowUserToAddRows = False
        Me.dgvBodegas.AllowUserToDeleteRows = False
        Me.dgvBodegas.AllowUserToOrderColumns = True
        Me.dgvBodegas.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray
        Me.dgvBodegas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvBodegas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvBodegas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvBodegas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBodegas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvBodegas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBodegas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selec, Me.bodega, Me.codbod, Me.compan, Me.usuar})
        Me.dgvBodegas.Location = New System.Drawing.Point(7, 70)
        Me.dgvBodegas.Name = "dgvBodegas"
        Me.dgvBodegas.RowHeadersVisible = False
        Me.dgvBodegas.Size = New System.Drawing.Size(325, 341)
        Me.dgvBodegas.TabIndex = 29
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
        Me.bodega.Width = 280
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
        'chkNC
        '
        Me.chkNC.AutoSize = True
        Me.chkNC.BackColor = System.Drawing.Color.Transparent
        Me.chkNC.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkNC.ForeColor = System.Drawing.Color.Navy
        Me.chkNC.Location = New System.Drawing.Point(513, 36)
        Me.chkNC.Name = "chkNC"
        Me.chkNC.Size = New System.Drawing.Size(116, 20)
        Me.chkNC.TabIndex = 30
        Me.chkNC.Text = "Notas de Crédito"
        Me.chkNC.UseVisualStyleBackColor = False
        '
        'ContabilidadPartidaCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 417)
        Me.Controls.Add(Me.chkNC)
        Me.Controls.Add(Me.dgvBodegas)
        Me.Controls.Add(Me.dpFechaContable2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblPdas)
        Me.Controls.Add(Me.txtTransaccionFinal)
        Me.Controls.Add(Me.txtTransaccionInicial)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.pbAplicar)
        Me.Controls.Add(Me.lblMsj)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNumPda)
        Me.Controls.Add(Me.dpFechaContable1)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.dgvPartidas)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ContabilidadPartidaCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Partidas Ordenes de Compra"
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents dpFechaContable1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMsj As System.Windows.Forms.Label
    Friend WithEvents pbAplicar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents bw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblPdas As System.Windows.Forms.Label
    Friend WithEvents txtTransaccionInicial As System.Windows.Forms.TextBox
    Friend WithEvents txtTransaccionFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtNumPda As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dpFechaContable2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvPartidas As System.Windows.Forms.DataGridView
    Friend WithEvents Linea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CuentaCompleta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConceptoL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cargo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transaccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvBodegas As System.Windows.Forms.DataGridView
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents bodega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codbod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents compan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usuar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkNC As System.Windows.Forms.CheckBox
End Class
