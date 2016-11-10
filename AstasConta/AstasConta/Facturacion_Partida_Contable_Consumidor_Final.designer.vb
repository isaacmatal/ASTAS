<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Facturacion_Partida_Contable_Consumidor_Final
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Facturacion_Partida_Contable_Consumidor_Final))
        Me.dpFechaContable = New System.Windows.Forms.DateTimePicker
        Me.btnGenerar = New System.Windows.Forms.Button
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbBodega = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTransac = New System.Windows.Forms.Label
        Me.lblTransac2 = New System.Windows.Forms.Label
        Me.btnVer = New System.Windows.Forms.Button
        Me.txtPda = New System.Windows.Forms.TextBox
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dpFechaContable
        '
        Me.dpFechaContable.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaContable.Location = New System.Drawing.Point(135, 7)
        Me.dpFechaContable.Name = "dpFechaContable"
        Me.dpFechaContable.Size = New System.Drawing.Size(92, 22)
        Me.dpFechaContable.TabIndex = 0
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.Transparent
        Me.btnGenerar.Location = New System.Drawing.Point(662, 6)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'dgvPartidas
        '
        Me.dgvPartidas.AllowUserToAddRows = False
        Me.dgvPartidas.AllowUserToDeleteRows = False
        Me.dgvPartidas.AllowUserToOrderColumns = True
        Me.dgvPartidas.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightGray
        Me.dgvPartidas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvPartidas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPartidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPartidas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvPartidas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartidas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Linea, Me.codCuenta, Me.CuentaCompleta, Me.Detalle, Me.DescripcionCuenta, Me.ConceptoL, Me.Cargo, Me.Abono, Me.Transaccion})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPartidas.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgvPartidas.Location = New System.Drawing.Point(14, 84)
        Me.dgvPartidas.Name = "dgvPartidas"
        Me.dgvPartidas.ReadOnly = True
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartidas.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvPartidas.RowHeadersVisible = False
        Me.dgvPartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartidas.Size = New System.Drawing.Size(751, 332)
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
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.Cargo.DefaultCellStyle = DataGridViewCellStyle15
        Me.Cargo.HeaderText = "Cargo"
        Me.Cargo.Name = "Cargo"
        Me.Cargo.ReadOnly = True
        Me.Cargo.Width = 63
        '
        'Abono
        '
        Me.Abono.DataPropertyName = "ABONOS"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.Abono.DefaultCellStyle = DataGridViewCellStyle16
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha Facturación:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(274, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Bodega: "
        '
        'cmbBodega
        '
        Me.cmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(330, 7)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(326, 24)
        Me.cmbBodega.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(32, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Partida No."
        '
        'lblTransac
        '
        Me.lblTransac.AutoSize = True
        Me.lblTransac.Location = New System.Drawing.Point(562, 45)
        Me.lblTransac.Name = "lblTransac"
        Me.lblTransac.Size = New System.Drawing.Size(14, 16)
        Me.lblTransac.TabIndex = 29
        Me.lblTransac.Text = "0"
        Me.lblTransac.Visible = False
        '
        'lblTransac2
        '
        Me.lblTransac2.AutoSize = True
        Me.lblTransac2.Location = New System.Drawing.Point(642, 45)
        Me.lblTransac2.Name = "lblTransac2"
        Me.lblTransac2.Size = New System.Drawing.Size(14, 16)
        Me.lblTransac2.TabIndex = 31
        Me.lblTransac2.Text = "0"
        Me.lblTransac2.Visible = False
        '
        'btnVer
        '
        Me.btnVer.Image = CType(resources.GetObject("btnVer.Image"), System.Drawing.Image)
        Me.btnVer.Location = New System.Drawing.Point(741, 6)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(24, 24)
        Me.btnVer.TabIndex = 30
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'txtPda
        '
        Me.txtPda.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPda.ForeColor = System.Drawing.Color.Navy
        Me.txtPda.Location = New System.Drawing.Point(135, 45)
        Me.txtPda.Name = "txtPda"
        Me.txtPda.Size = New System.Drawing.Size(92, 29)
        Me.txtPda.TabIndex = 33
        Me.txtPda.Text = "0"
        Me.txtPda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Facturacion_Partida_Contable_Consumidor_Final
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 428)
        Me.Controls.Add(Me.txtPda)
        Me.Controls.Add(Me.lblTransac2)
        Me.Controls.Add(Me.btnVer)
        Me.Controls.Add(Me.lblTransac)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbBodega)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvPartidas)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.dpFechaContable)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Facturacion_Partida_Contable_Consumidor_Final"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Partida Contable Facturación"
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dpFechaContable As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents dgvPartidas As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Linea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CuentaCompleta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConceptoL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cargo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transaccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTransac As System.Windows.Forms.Label
    Friend WithEvents btnVer As System.Windows.Forms.Button
    Friend WithEvents lblTransac2 As System.Windows.Forms.Label
    Friend WithEvents txtPda As System.Windows.Forms.TextBox
End Class
