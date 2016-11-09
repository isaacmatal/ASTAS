<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCooperativaDesbloqueoSocios
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCooperativaDesbloqueoSocios))
        Me.dgvNoAplicados = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.dtpFechaPago = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.btmDesbloqueo = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtmonto = New System.Windows.Forms.TextBox
        Me.chkcompleto = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblNombre = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Lblmensaje = New System.Windows.Forms.TextBox
        Me.txtCodBuxis = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnBloquear = New System.Windows.Forms.Button
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnReporte = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtMotivo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnRep = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAplic = New System.Windows.Forms.TextBox
        Me.txtNoAplic = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTotalDesc = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.dgvNoAplicados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvNoAplicados
        '
        Me.dgvNoAplicados.AllowUserToAddRows = False
        Me.dgvNoAplicados.AllowUserToDeleteRows = False
        Me.dgvNoAplicados.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvNoAplicados.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvNoAplicados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNoAplicados.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvNoAplicados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNoAplicados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvNoAplicados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNoAplicados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvNoAplicados.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvNoAplicados.Location = New System.Drawing.Point(2, 164)
        Me.dgvNoAplicados.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgvNoAplicados.Name = "dgvNoAplicados"
        Me.dgvNoAplicados.ReadOnly = True
        Me.dgvNoAplicados.RowHeadersVisible = False
        Me.dgvNoAplicados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNoAplicados.Size = New System.Drawing.Size(1045, 401)
        Me.dgvNoAplicados.TabIndex = 0
        '
        'Column1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.FillWeight = 15.17956!
        Me.Column1.HeaderText = "Periodo Descuento"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 80
        '
        'Column2
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column2.FillWeight = 93.41265!
        Me.Column2.HeaderText = "Codigo Deduccion"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 64
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column3.FillWeight = 15.17956!
        Me.Column3.HeaderText = "Descripcion Deduccion"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 129
        '
        'Column4
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column4.FillWeight = 146.9054!
        Me.Column4.HeaderText = "Nº Solicitud"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 102
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column5.FillWeight = 15.17956!
        Me.Column5.HeaderText = "Solicitud"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 71
        '
        'Column6
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column6.FillWeight = 355.33!
        Me.Column6.HeaderText = "Codigo Buxis"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 70
        '
        'Column7
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column7.FillWeight = 313.2747!
        Me.Column7.HeaderText = "Codigo AS"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 70
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column8.FillWeight = 15.17956!
        Me.Column8.HeaderText = "Nombre Socio"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 92
        '
        'Column9
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column9.FillWeight = 15.17956!
        Me.Column9.HeaderText = "Valor Descuento"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 80
        '
        'Column10
        '
        Me.Column10.FillWeight = 15.17956!
        Me.Column10.HeaderText = "Aplicado"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 50
        '
        'Column11
        '
        Me.Column11.HeaderText = "Deduccion Solicitud"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Visible = False
        Me.Column11.Width = 80
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(262, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Codigo AS:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCodigo.Location = New System.Drawing.Point(328, 7)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(71, 22)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpFechaPago
        '
        Me.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPago.Location = New System.Drawing.Point(118, 134)
        Me.dtpFechaPago.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFechaPago.Name = "dtpFechaPago"
        Me.dtpFechaPago.Size = New System.Drawing.Size(100, 22)
        Me.dtpFechaPago.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(7, 137)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Fecha Ultimo Pago:"
        '
        'btmDesbloqueo
        '
        Me.btmDesbloqueo.BackColor = System.Drawing.Color.Transparent
        Me.btmDesbloqueo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btmDesbloqueo.Location = New System.Drawing.Point(422, 49)
        Me.btmDesbloqueo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btmDesbloqueo.Name = "btmDesbloqueo"
        Me.btmDesbloqueo.Size = New System.Drawing.Size(96, 43)
        Me.btmDesbloqueo.TabIndex = 6
        Me.btmDesbloqueo.Text = "Desbloquear"
        Me.btmDesbloqueo.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(622, 49)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Mónto máximo:"
        Me.Label3.Visible = False
        '
        'txtmonto
        '
        Me.txtmonto.Location = New System.Drawing.Point(622, 68)
        Me.txtmonto.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(96, 22)
        Me.txtmonto.TabIndex = 3
        Me.txtmonto.Visible = False
        '
        'chkcompleto
        '
        Me.chkcompleto.AutoSize = True
        Me.chkcompleto.BackColor = System.Drawing.Color.Transparent
        Me.chkcompleto.Checked = True
        Me.chkcompleto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkcompleto.Location = New System.Drawing.Point(265, 138)
        Me.chkcompleto.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.chkcompleto.Name = "chkcompleto"
        Me.chkcompleto.Size = New System.Drawing.Size(128, 20)
        Me.chkcompleto.TabIndex = 4
        Me.chkcompleto.Text = "Desbloqueo completo"
        Me.chkcompleto.UseVisualStyleBackColor = False
        Me.chkcompleto.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(12, 74)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Estatus del bloqueo: "
        '
        'lblNombre
        '
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Navy
        Me.lblNombre.Location = New System.Drawing.Point(118, 32)
        Me.lblNombre.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.ReadOnly = True
        Me.lblNombre.Size = New System.Drawing.Size(281, 20)
        Me.lblNombre.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(12, 34)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Nombre socio:"
        '
        'Lblmensaje
        '
        Me.Lblmensaje.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Lblmensaje.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblmensaje.ForeColor = System.Drawing.Color.Navy
        Me.Lblmensaje.Location = New System.Drawing.Point(118, 57)
        Me.Lblmensaje.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Lblmensaje.Multiline = True
        Me.Lblmensaje.Name = "Lblmensaje"
        Me.Lblmensaje.ReadOnly = True
        Me.Lblmensaje.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Lblmensaje.Size = New System.Drawing.Size(281, 73)
        Me.Lblmensaje.TabIndex = 19
        '
        'txtCodBuxis
        '
        Me.txtCodBuxis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBuxis.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCodBuxis.Location = New System.Drawing.Point(118, 7)
        Me.txtCodBuxis.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtCodBuxis.Name = "txtCodBuxis"
        Me.txtCodBuxis.Size = New System.Drawing.Size(71, 20)
        Me.txtCodBuxis.TabIndex = 0
        Me.txtCodBuxis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(12, 9)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Codigo BUXIS:"
        '
        'btnBloquear
        '
        Me.btnBloquear.BackColor = System.Drawing.Color.Transparent
        Me.btnBloquear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBloquear.Location = New System.Drawing.Point(522, 49)
        Me.btnBloquear.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnBloquear.Name = "btnBloquear"
        Me.btnBloquear.Size = New System.Drawing.Size(96, 43)
        Me.btnBloquear.TabIndex = 21
        Me.btnBloquear.Text = "Bloquear"
        Me.btnBloquear.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.Transparent
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(522, 4)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(96, 43)
        Me.btnNuevo.TabIndex = 22
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'btnReporte
        '
        Me.btnReporte.BackColor = System.Drawing.Color.Transparent
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(422, 4)
        Me.btnReporte.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(96, 43)
        Me.btnReporte.TabIndex = 5
        Me.btnReporte.Text = "Imprimir"
        Me.btnReporte.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(622, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 43)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Accesos " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Consumo"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtMotivo
        '
        Me.txtMotivo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivo.ForeColor = System.Drawing.Color.Navy
        Me.txtMotivo.Location = New System.Drawing.Point(426, 111)
        Me.txtMotivo.MaxLength = 500
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(292, 50)
        Me.txtMotivo.TabIndex = 24
        Me.txtMotivo.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(423, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 16)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Motivo Bloqueo:"
        Me.Label7.Visible = False
        '
        'btnRep
        '
        Me.btnRep.BackColor = System.Drawing.Color.Transparent
        Me.btnRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRep.Location = New System.Drawing.Point(622, 49)
        Me.btnRep.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnRep.Name = "btnRep"
        Me.btnRep.Size = New System.Drawing.Size(96, 43)
        Me.btnRep.TabIndex = 27
        Me.btnRep.Text = "Reporte Bloqueados"
        Me.btnRep.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(28, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(155, 16)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "DESCUENTOS APLICADOS:"
        '
        'txtAplic
        '
        Me.txtAplic.BackColor = System.Drawing.Color.White
        Me.txtAplic.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAplic.ForeColor = System.Drawing.Color.Navy
        Me.txtAplic.Location = New System.Drawing.Point(189, 20)
        Me.txtAplic.Name = "txtAplic"
        Me.txtAplic.ReadOnly = True
        Me.txtAplic.Size = New System.Drawing.Size(102, 24)
        Me.txtAplic.TabIndex = 29
        Me.txtAplic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoAplic
        '
        Me.txtNoAplic.BackColor = System.Drawing.Color.White
        Me.txtNoAplic.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoAplic.ForeColor = System.Drawing.Color.Red
        Me.txtNoAplic.Location = New System.Drawing.Point(189, 51)
        Me.txtNoAplic.Name = "txtNoAplic"
        Me.txtNoAplic.ReadOnly = True
        Me.txtNoAplic.Size = New System.Drawing.Size(102, 24)
        Me.txtNoAplic.TabIndex = 31
        Me.txtNoAplic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(9, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(174, 16)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "DESCUENTOS NO APLICADOS:"
        '
        'txtTotalDesc
        '
        Me.txtTotalDesc.BackColor = System.Drawing.Color.White
        Me.txtTotalDesc.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDesc.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDesc.Location = New System.Drawing.Point(189, 82)
        Me.txtTotalDesc.Name = "txtTotalDesc"
        Me.txtTotalDesc.ReadOnly = True
        Me.txtTotalDesc.Size = New System.Drawing.Size(102, 24)
        Me.txtTotalDesc.TabIndex = 33
        Me.txtTotalDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(58, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 16)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "TOTAL DESCUENTOS:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtTotalDesc)
        Me.GroupBox1.Controls.Add(Me.txtAplic)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtNoAplic)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(727, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 116)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Resumen"
        '
        'frmCooperativaDesbloqueoSocios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 572)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnRep)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtMotivo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnBloquear)
        Me.Controls.Add(Me.txtCodBuxis)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Lblmensaje)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkcompleto)
        Me.Controls.Add(Me.txtmonto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btmDesbloqueo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFechaPago)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvNoAplicados)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "frmCooperativaDesbloqueoSocios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Desbloqueo de Usuarios"
        CType(Me.dgvNoAplicados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvNoAplicados As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btmDesbloqueo As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtmonto As System.Windows.Forms.TextBox
    Friend WithEvents chkcompleto As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Lblmensaje As System.Windows.Forms.TextBox
    Friend WithEvents txtCodBuxis As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnBloquear As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnRep As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAplic As System.Windows.Forms.TextBox
    Friend WithEvents txtNoAplic As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
