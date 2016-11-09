<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificarProgramacionesVisualizarDetalles
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
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSolicitud = New System.Windows.Forms.TextBox
        Me.dgvDetalle = New System.Windows.Forms.DataGridView
        Me.btnConsultar = New System.Windows.Forms.Button
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSaldoNormal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtInteresNormal = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSeguroNormal = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTotalNormal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTotalEspecial = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSeguroEspecial = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtInteresEspecial = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtSaldoEspecial = New System.Windows.Forms.TextBox
        Me.Normal = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtGranTotal = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox
        Me.dtpOtorgado = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Normal.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.SystemColors.Menu
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Font = New System.Drawing.Font("Arial Narrow", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.ForeColor = System.Drawing.Color.Navy
        Me.TxtNombre.Location = New System.Drawing.Point(398, 12)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(287, 24)
        Me.TxtNombre.TabIndex = 131
        Me.TxtNombre.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(364, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 16)
        Me.Label9.TabIndex = 132
        Me.Label9.Text = "Socio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Codigo Buxis:"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.TxtCodigo.Enabled = False
        Me.TxtCodigo.Font = New System.Drawing.Font("Arial Narrow", 11.0!, System.Drawing.FontStyle.Bold)
        Me.TxtCodigo.ForeColor = System.Drawing.Color.Red
        Me.TxtCodigo.Location = New System.Drawing.Point(87, 12)
        Me.TxtCodigo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(96, 24)
        Me.TxtCodigo.TabIndex = 129
        Me.TxtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(217, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Solicitud:"
        '
        'txtSolicitud
        '
        Me.txtSolicitud.BackColor = System.Drawing.SystemColors.Menu
        Me.txtSolicitud.Enabled = False
        Me.txtSolicitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtSolicitud.ForeColor = System.Drawing.Color.Navy
        Me.txtSolicitud.Location = New System.Drawing.Point(268, 13)
        Me.txtSolicitud.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSolicitud.Name = "txtSolicitud"
        Me.txtSolicitud.Size = New System.Drawing.Size(92, 22)
        Me.txtSolicitud.TabIndex = 133
        Me.txtSolicitud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Location = New System.Drawing.Point(15, 91)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(518, 368)
        Me.dgvDetalle.TabIndex = 135
        '
        'btnConsultar
        '
        Me.btnConsultar.Enabled = False
        Me.btnConsultar.Location = New System.Drawing.Point(398, 40)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(91, 26)
        Me.btnConsultar.TabIndex = 139
        Me.btnConsultar.Text = "Calcular"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(268, 40)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(92, 22)
        Me.dtpFecha.TabIndex = 142
        Me.dtpFecha.Value = New Date(2016, 7, 13, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(187, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 141
        Me.Label6.Text = "Calcular Hasta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(17, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 16)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "Saldo:"
        '
        'txtSaldoNormal
        '
        Me.txtSaldoNormal.BackColor = System.Drawing.Color.White
        Me.txtSaldoNormal.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtSaldoNormal.ForeColor = System.Drawing.Color.Navy
        Me.txtSaldoNormal.Location = New System.Drawing.Point(72, 20)
        Me.txtSaldoNormal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSaldoNormal.Name = "txtSaldoNormal"
        Me.txtSaldoNormal.ReadOnly = True
        Me.txtSaldoNormal.Size = New System.Drawing.Size(107, 22)
        Me.txtSaldoNormal.TabIndex = 143
        Me.txtSaldoNormal.Text = "0.00"
        Me.txtSaldoNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(17, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 16)
        Me.Label4.TabIndex = 146
        Me.Label4.Text = "Interes:"
        '
        'txtInteresNormal
        '
        Me.txtInteresNormal.BackColor = System.Drawing.Color.White
        Me.txtInteresNormal.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtInteresNormal.ForeColor = System.Drawing.Color.Navy
        Me.txtInteresNormal.Location = New System.Drawing.Point(72, 46)
        Me.txtInteresNormal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtInteresNormal.Name = "txtInteresNormal"
        Me.txtInteresNormal.ReadOnly = True
        Me.txtInteresNormal.Size = New System.Drawing.Size(107, 22)
        Me.txtInteresNormal.TabIndex = 145
        Me.txtInteresNormal.Text = "0.00"
        Me.txtInteresNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(17, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 16)
        Me.Label5.TabIndex = 148
        Me.Label5.Text = "Seguro:"
        '
        'txtSeguroNormal
        '
        Me.txtSeguroNormal.BackColor = System.Drawing.Color.White
        Me.txtSeguroNormal.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtSeguroNormal.ForeColor = System.Drawing.Color.Navy
        Me.txtSeguroNormal.Location = New System.Drawing.Point(72, 72)
        Me.txtSeguroNormal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSeguroNormal.Name = "txtSeguroNormal"
        Me.txtSeguroNormal.ReadOnly = True
        Me.txtSeguroNormal.Size = New System.Drawing.Size(107, 22)
        Me.txtSeguroNormal.TabIndex = 147
        Me.txtSeguroNormal.Text = "0.00"
        Me.txtSeguroNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(17, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 16)
        Me.Label7.TabIndex = 150
        Me.Label7.Text = "Total:"
        '
        'txtTotalNormal
        '
        Me.txtTotalNormal.BackColor = System.Drawing.Color.White
        Me.txtTotalNormal.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtTotalNormal.ForeColor = System.Drawing.Color.Navy
        Me.txtTotalNormal.Location = New System.Drawing.Point(72, 97)
        Me.txtTotalNormal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotalNormal.Name = "txtTotalNormal"
        Me.txtTotalNormal.ReadOnly = True
        Me.txtTotalNormal.Size = New System.Drawing.Size(107, 22)
        Me.txtTotalNormal.TabIndex = 149
        Me.txtTotalNormal.Text = "0.00"
        Me.txtTotalNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(17, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 16)
        Me.Label8.TabIndex = 158
        Me.Label8.Text = "Total:"
        '
        'txtTotalEspecial
        '
        Me.txtTotalEspecial.BackColor = System.Drawing.Color.White
        Me.txtTotalEspecial.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtTotalEspecial.ForeColor = System.Drawing.Color.Navy
        Me.txtTotalEspecial.Location = New System.Drawing.Point(72, 95)
        Me.txtTotalEspecial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTotalEspecial.Name = "txtTotalEspecial"
        Me.txtTotalEspecial.ReadOnly = True
        Me.txtTotalEspecial.Size = New System.Drawing.Size(107, 22)
        Me.txtTotalEspecial.TabIndex = 157
        Me.txtTotalEspecial.Text = "0.00"
        Me.txtTotalEspecial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(17, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 16)
        Me.Label10.TabIndex = 156
        Me.Label10.Text = "Seguro:"
        '
        'txtSeguroEspecial
        '
        Me.txtSeguroEspecial.BackColor = System.Drawing.Color.White
        Me.txtSeguroEspecial.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtSeguroEspecial.ForeColor = System.Drawing.Color.Navy
        Me.txtSeguroEspecial.Location = New System.Drawing.Point(72, 70)
        Me.txtSeguroEspecial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSeguroEspecial.Name = "txtSeguroEspecial"
        Me.txtSeguroEspecial.ReadOnly = True
        Me.txtSeguroEspecial.Size = New System.Drawing.Size(107, 22)
        Me.txtSeguroEspecial.TabIndex = 155
        Me.txtSeguroEspecial.Text = "0.00"
        Me.txtSeguroEspecial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(17, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 16)
        Me.Label11.TabIndex = 154
        Me.Label11.Text = "Interes:"
        '
        'txtInteresEspecial
        '
        Me.txtInteresEspecial.BackColor = System.Drawing.Color.White
        Me.txtInteresEspecial.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtInteresEspecial.ForeColor = System.Drawing.Color.Navy
        Me.txtInteresEspecial.Location = New System.Drawing.Point(72, 45)
        Me.txtInteresEspecial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtInteresEspecial.Name = "txtInteresEspecial"
        Me.txtInteresEspecial.ReadOnly = True
        Me.txtInteresEspecial.Size = New System.Drawing.Size(107, 22)
        Me.txtInteresEspecial.TabIndex = 153
        Me.txtInteresEspecial.Text = "0.00"
        Me.txtInteresEspecial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(17, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 16)
        Me.Label12.TabIndex = 152
        Me.Label12.Text = "Especial:"
        '
        'txtSaldoEspecial
        '
        Me.txtSaldoEspecial.BackColor = System.Drawing.Color.White
        Me.txtSaldoEspecial.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtSaldoEspecial.ForeColor = System.Drawing.Color.Navy
        Me.txtSaldoEspecial.Location = New System.Drawing.Point(72, 20)
        Me.txtSaldoEspecial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSaldoEspecial.Name = "txtSaldoEspecial"
        Me.txtSaldoEspecial.ReadOnly = True
        Me.txtSaldoEspecial.Size = New System.Drawing.Size(107, 22)
        Me.txtSaldoEspecial.TabIndex = 151
        Me.txtSaldoEspecial.Text = "0.00"
        Me.txtSaldoEspecial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Normal
        '
        Me.Normal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Normal.BackColor = System.Drawing.Color.Transparent
        Me.Normal.Controls.Add(Me.txtSaldoNormal)
        Me.Normal.Controls.Add(Me.Label3)
        Me.Normal.Controls.Add(Me.txtInteresNormal)
        Me.Normal.Controls.Add(Me.Label4)
        Me.Normal.Controls.Add(Me.txtSeguroNormal)
        Me.Normal.Controls.Add(Me.Label5)
        Me.Normal.Controls.Add(Me.txtTotalNormal)
        Me.Normal.Controls.Add(Me.Label7)
        Me.Normal.Location = New System.Drawing.Point(541, 85)
        Me.Normal.Name = "Normal"
        Me.Normal.Size = New System.Drawing.Size(187, 128)
        Me.Normal.TabIndex = 159
        Me.Normal.TabStop = False
        Me.Normal.Text = "Normal"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtSaldoEspecial)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtInteresEspecial)
        Me.GroupBox2.Controls.Add(Me.txtTotalEspecial)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtSeguroEspecial)
        Me.GroupBox2.Location = New System.Drawing.Point(541, 241)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(187, 126)
        Me.GroupBox2.TabIndex = 160
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Especial"
        '
        'txtGranTotal
        '
        Me.txtGranTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGranTotal.BackColor = System.Drawing.Color.White
        Me.txtGranTotal.Font = New System.Drawing.Font("Arial Narrow", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtGranTotal.ForeColor = System.Drawing.Color.Black
        Me.txtGranTotal.Location = New System.Drawing.Point(615, 398)
        Me.txtGranTotal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtGranTotal.Name = "txtGranTotal"
        Me.txtGranTotal.ReadOnly = True
        Me.txtGranTotal.Size = New System.Drawing.Size(105, 24)
        Me.txtGranTotal.TabIndex = 161
        Me.txtGranTotal.Text = "0.00"
        Me.txtGranTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(539, 401)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 16)
        Me.Label13.TabIndex = 162
        Me.Label13.Text = "Total a Pagar:"
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(15, 68)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(162, 17)
        Me.chkSeleccionarTodo.TabIndex = 164
        Me.chkSeleccionarTodo.Text = "Seleccionar todas las cuotas"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'dtpOtorgado
        '
        Me.dtpOtorgado.CustomFormat = ""
        Me.dtpOtorgado.Enabled = False
        Me.dtpOtorgado.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpOtorgado.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOtorgado.Location = New System.Drawing.Point(87, 40)
        Me.dtpOtorgado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpOtorgado.Name = "dtpOtorgado"
        Me.dtpOtorgado.Size = New System.Drawing.Size(96, 22)
        Me.dtpOtorgado.TabIndex = 166
        Me.dtpOtorgado.Value = New Date(2016, 7, 13, 0, 0, 0, 0)
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(31, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 16)
        Me.Label14.TabIndex = 165
        Me.Label14.Text = "Otorgado:"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(653, 429)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 30)
        Me.btnPrint.TabIndex = 167
        Me.btnPrint.Text = "&Imprimir"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'FrmModificarProgramacionesVisualizarDetalles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 473)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dtpOtorgado)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.chkSeleccionarTodo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtGranTotal)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Normal)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSolicitud)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCodigo)
        Me.Name = "FrmModificarProgramacionesVisualizarDetalles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmModificarProgramacionesVisualizarDetalles"
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Normal.ResumeLayout(False)
        Me.Normal.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoNormal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInteresNormal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSeguroNormal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalNormal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalEspecial As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSeguroEspecial As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtInteresEspecial As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoEspecial As System.Windows.Forms.TextBox
    Friend WithEvents Normal As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtGranTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents dtpOtorgado As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
