<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Procesar_Partidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Procesar_Partidas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.lblNumRegs = New System.Windows.Forms.Label
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.chkSelec = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dpPeriodo = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtFECHACONTABLE = New System.Windows.Forms.TextBox
        Me.txtPARTIDA = New System.Windows.Forms.TextBox
        Me.txtESTADO = New System.Windows.Forms.TextBox
        Me.txtCONCEPTO = New System.Windows.Forms.TextBox
        Me.dgvTransacciones = New System.Windows.Forms.DataGridView
        Me.Transaccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Partida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaContable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Concepto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DIFERENCIA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ANULADA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PROCESADO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Usuario_CR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvTransacciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtUsuario)
        Me.GroupBox1.Controls.Add(Me.lblNumRegs)
        Me.GroupBox1.Controls.Add(Me.btnProcesar)
        Me.GroupBox1.Controls.Add(Me.chkSelec)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dpPeriodo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtFECHACONTABLE)
        Me.GroupBox1.Controls.Add(Me.txtPARTIDA)
        Me.GroupBox1.Controls.Add(Me.txtESTADO)
        Me.GroupBox1.Controls.Add(Me.txtCONCEPTO)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(834, 109)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(719, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 20)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Usuario"
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtUsuario.Location = New System.Drawing.Point(718, 79)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(105, 22)
        Me.txtUsuario.TabIndex = 80
        Me.txtUsuario.Tag = "USUARIO"
        '
        'lblNumRegs
        '
        Me.lblNumRegs.AutoSize = True
        Me.lblNumRegs.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumRegs.ForeColor = System.Drawing.Color.Maroon
        Me.lblNumRegs.Location = New System.Drawing.Point(2, 90)
        Me.lblNumRegs.Name = "lblNumRegs"
        Me.lblNumRegs.Size = New System.Drawing.Size(65, 15)
        Me.lblNumRegs.TabIndex = 79
        Me.lblNumRegs.Text = "0 Registros"
        '
        'btnProcesar
        '
        Me.btnProcesar.Image = Global.AstasConta.My.Resources.Resources.exec
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnProcesar.Location = New System.Drawing.Point(283, 11)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(104, 41)
        Me.btnProcesar.TabIndex = 78
        Me.btnProcesar.Text = "Procesar Seleccionadas"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'chkSelec
        '
        Me.chkSelec.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkSelec.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkSelec.Location = New System.Drawing.Point(13, 56)
        Me.chkSelec.Name = "chkSelec"
        Me.chkSelec.Size = New System.Drawing.Size(69, 40)
        Me.chkSelec.TabIndex = 77
        Me.chkSelec.Text = "Marcar Todas"
        Me.chkSelec.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkSelec.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(612, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 20)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Estado"
        '
        'btnBuscar
        '
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(252, 23)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(250, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(359, 20)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Concepto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(10, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Período Contable :"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(155, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 20)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Fecha"
        '
        'dpPeriodo
        '
        Me.dpPeriodo.CalendarForeColor = System.Drawing.Color.Navy
        Me.dpPeriodo.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.dpPeriodo.CustomFormat = "MMMM-yyyy"
        Me.dpPeriodo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpPeriodo.Location = New System.Drawing.Point(123, 23)
        Me.dpPeriodo.Name = "dpPeriodo"
        Me.dpPeriodo.Size = New System.Drawing.Size(123, 22)
        Me.dpPeriodo.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(80, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 20)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "N° Partida"
        '
        'txtFECHACONTABLE
        '
        Me.txtFECHACONTABLE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFECHACONTABLE.Location = New System.Drawing.Point(153, 79)
        Me.txtFECHACONTABLE.Name = "txtFECHACONTABLE"
        Me.txtFECHACONTABLE.Size = New System.Drawing.Size(95, 22)
        Me.txtFECHACONTABLE.TabIndex = 2
        Me.txtFECHACONTABLE.Tag = "FECHA_CONTABLE"
        Me.txtFECHACONTABLE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPARTIDA
        '
        Me.txtPARTIDA.BackColor = System.Drawing.SystemColors.Window
        Me.txtPARTIDA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPARTIDA.ForeColor = System.Drawing.Color.Navy
        Me.txtPARTIDA.Location = New System.Drawing.Point(80, 79)
        Me.txtPARTIDA.MaxLength = 8
        Me.txtPARTIDA.Name = "txtPARTIDA"
        Me.txtPARTIDA.Size = New System.Drawing.Size(72, 22)
        Me.txtPARTIDA.TabIndex = 1
        Me.txtPARTIDA.Tag = "Partida"
        Me.txtPARTIDA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtESTADO
        '
        Me.txtESTADO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtESTADO.Location = New System.Drawing.Point(611, 79)
        Me.txtESTADO.Name = "txtESTADO"
        Me.txtESTADO.Size = New System.Drawing.Size(105, 22)
        Me.txtESTADO.TabIndex = 4
        Me.txtESTADO.Tag = "ESTADO"
        '
        'txtCONCEPTO
        '
        Me.txtCONCEPTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONCEPTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONCEPTO.ForeColor = System.Drawing.Color.Navy
        Me.txtCONCEPTO.Location = New System.Drawing.Point(249, 79)
        Me.txtCONCEPTO.MaxLength = 50
        Me.txtCONCEPTO.Name = "txtCONCEPTO"
        Me.txtCONCEPTO.Size = New System.Drawing.Size(361, 22)
        Me.txtCONCEPTO.TabIndex = 3
        Me.txtCONCEPTO.Tag = "Concepto"
        '
        'dgvTransacciones
        '
        Me.dgvTransacciones.AllowUserToAddRows = False
        Me.dgvTransacciones.AllowUserToDeleteRows = False
        Me.dgvTransacciones.AllowUserToResizeRows = False
        Me.dgvTransacciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTransacciones.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvTransacciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTransacciones.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransacciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransacciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Transaccion, Me.selec, Me.Partida, Me.FechaContable, Me.Concepto, Me.ESTADO, Me.DIFERENCIA, Me.ANULADA, Me.PROCESADO, Me.Usuario_CR})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTransacciones.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvTransacciones.Location = New System.Drawing.Point(12, 112)
        Me.dgvTransacciones.Name = "dgvTransacciones"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransacciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvTransacciones.RowHeadersWidth = 20
        Me.dgvTransacciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransacciones.Size = New System.Drawing.Size(834, 321)
        Me.dgvTransacciones.TabIndex = 5
        '
        'Transaccion
        '
        Me.Transaccion.DataPropertyName = "TRANSACCION"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Transaccion.DefaultCellStyle = DataGridViewCellStyle2
        Me.Transaccion.HeaderText = "N° Trans"
        Me.Transaccion.Name = "Transaccion"
        Me.Transaccion.Visible = False
        Me.Transaccion.Width = 60
        '
        'selec
        '
        Me.selec.HeaderText = ""
        Me.selec.Name = "selec"
        Me.selec.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.selec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.selec.Width = 30
        '
        'Partida
        '
        Me.Partida.DataPropertyName = "PARTIDA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Partida.DefaultCellStyle = DataGridViewCellStyle3
        Me.Partida.HeaderText = "Partida"
        Me.Partida.Name = "Partida"
        Me.Partida.ReadOnly = True
        Me.Partida.Width = 50
        '
        'FechaContable
        '
        Me.FechaContable.DataPropertyName = "FECHA_CONTABLE"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FechaContable.DefaultCellStyle = DataGridViewCellStyle4
        Me.FechaContable.HeaderText = "Fecha Contable"
        Me.FechaContable.Name = "FechaContable"
        Me.FechaContable.ReadOnly = True
        Me.FechaContable.Width = 80
        '
        'Concepto
        '
        Me.Concepto.DataPropertyName = "CONCEPTO"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Concepto.DefaultCellStyle = DataGridViewCellStyle5
        Me.Concepto.HeaderText = "Concepto"
        Me.Concepto.Name = "Concepto"
        Me.Concepto.ReadOnly = True
        Me.Concepto.Width = 380
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ESTADO.DefaultCellStyle = DataGridViewCellStyle6
        Me.ESTADO.HeaderText = "Estado"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Width = 120
        '
        'DIFERENCIA
        '
        Me.DIFERENCIA.DataPropertyName = "DIFERENCIA"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.NullValue = "0"
        Me.DIFERENCIA.DefaultCellStyle = DataGridViewCellStyle7
        Me.DIFERENCIA.HeaderText = "Diferencia"
        Me.DIFERENCIA.Name = "DIFERENCIA"
        Me.DIFERENCIA.ReadOnly = True
        Me.DIFERENCIA.Width = 60
        '
        'ANULADA
        '
        Me.ANULADA.DataPropertyName = "ANULADA"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ANULADA.DefaultCellStyle = DataGridViewCellStyle8
        Me.ANULADA.HeaderText = "ANULADA"
        Me.ANULADA.Name = "ANULADA"
        Me.ANULADA.ReadOnly = True
        Me.ANULADA.Visible = False
        Me.ANULADA.Width = 70
        '
        'PROCESADO
        '
        Me.PROCESADO.DataPropertyName = "PROCESADO"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PROCESADO.DefaultCellStyle = DataGridViewCellStyle9
        Me.PROCESADO.HeaderText = "PROCESADO"
        Me.PROCESADO.Name = "PROCESADO"
        Me.PROCESADO.ReadOnly = True
        Me.PROCESADO.Visible = False
        Me.PROCESADO.Width = 80
        '
        'Usuario_CR
        '
        Me.Usuario_CR.DataPropertyName = "USUARIO"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Usuario_CR.DefaultCellStyle = DataGridViewCellStyle10
        Me.Usuario_CR.HeaderText = "Usuario Creación"
        Me.Usuario_CR.Name = "Usuario_CR"
        Me.Usuario_CR.ReadOnly = True
        Me.Usuario_CR.Width = 70
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(394, 11)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 42)
        Me.btnImprimir.TabIndex = 82
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Contabilidad_Procesar_Partidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 444)
        Me.Controls.Add(Me.dgvTransacciones)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Procesar_Partidas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Listado de Partidas Contables"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvTransacciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvTransacciones As System.Windows.Forms.DataGridView
    Friend WithEvents txtPARTIDA As System.Windows.Forms.TextBox
    Friend WithEvents txtCONCEPTO As System.Windows.Forms.TextBox
    Friend WithEvents dpPeriodo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtESTADO As System.Windows.Forms.TextBox
    Friend WithEvents txtFECHACONTABLE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents chkSelec As System.Windows.Forms.CheckBox
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents lblNumRegs As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Transaccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Partida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaContable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Concepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIFERENCIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ANULADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROCESADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario_CR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
End Class
