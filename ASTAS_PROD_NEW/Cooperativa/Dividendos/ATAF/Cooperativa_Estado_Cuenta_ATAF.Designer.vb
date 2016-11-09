<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cooperativa_Estado_Cuenta_ATAF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cooperativa_Estado_Cuenta_ATAF))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.NumericUpDown11 = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnBuscarCliente = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnReporteGral = New System.Windows.Forms.Button
        Me.btnConstanciaISRAnual = New System.Windows.Forms.Button
        Me.btnDetGral = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cmbGerencias = New System.Windows.Forms.ComboBox
        Me.cmbCargos = New System.Windows.Forms.ComboBox
        Me.cmbSecciones = New System.Windows.Forms.ComboBox
        Me.cmbDivisiones = New System.Windows.Forms.ComboBox
        Me.cmbDepartamentos = New System.Windows.Forms.ComboBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.RadioButton6 = New System.Windows.Forms.RadioButton
        Me.RadioButton9 = New System.Windows.Forms.RadioButton
        Me.RadioButton7 = New System.Windows.Forms.RadioButton
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cantidadEmpleados = New System.Windows.Forms.Label
        Me.cmbGeneral = New System.Windows.Forms.CheckBox
        Me.chkDetalle = New System.Windows.Forms.CheckBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.bBw1 = New System.ComponentModel.BackgroundWorker
        Me.bBw2 = New System.ComponentModel.BackgroundWorker
        Me.pB2 = New System.Windows.Forms.ProgressBar
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.aBw2 = New System.ComponentModel.BackgroundWorker
        Me.aBw1 = New System.ComponentModel.BackgroundWorker
        Me.eBw1 = New System.ComponentModel.BackgroundWorker
        Me.eBw2 = New System.ComponentModel.BackgroundWorker
        Me.bwCreatePDF = New System.ComponentModel.BackgroundWorker
        Me.BwRepDetGral = New System.ComponentModel.BackgroundWorker
        Me.Button13 = New System.Windows.Forms.Button
        Me.GroupBox4.SuspendLayout()
        CType(Me.NumericUpDown11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label39)
        Me.GroupBox4.Controls.Add(Me.NumericUpDown11)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.btnBuscarCliente)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.TextBox2)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.TextBox1)
        Me.GroupBox4.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox4.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(317, 222)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Individual"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(85, 158)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(52, 13)
        Me.Label39.TabIndex = 112
        Me.Label39.Text = "Reparto"
        '
        'NumericUpDown11
        '
        Me.NumericUpDown11.Location = New System.Drawing.Point(88, 175)
        Me.NumericUpDown11.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.NumericUpDown11.Name = "NumericUpDown11"
        Me.NumericUpDown11.Size = New System.Drawing.Size(57, 20)
        Me.NumericUpDown11.TabIndex = 111
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(22, 198)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(185, 16)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Espere un momento.........."
        Me.Label2.Visible = False
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarCliente.ForeColor = System.Drawing.Color.White
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(288, 99)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarCliente.TabIndex = 21
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(22, 123)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Nombre"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(87, 120)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(200, 36)
        Me.TextBox2.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(27, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Codigo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(311, 61)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha de dividendos"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(85, 18)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(85, 39)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Desde:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Hasta:"
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(185, 171)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Cargar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(3, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Fecha deuda:"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(87, 99)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(200, 20)
        Me.TextBox1.TabIndex = 2
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker3.Location = New System.Drawing.Point(87, 77)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker3.TabIndex = 16
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button13)
        Me.GroupBox3.Controls.Add(Me.btnReporteGral)
        Me.GroupBox3.Controls.Add(Me.btnConstanciaISRAnual)
        Me.GroupBox3.Controls.Add(Me.btnDetGral)
        Me.GroupBox3.Controls.Add(Me.Button12)
        Me.GroupBox3.Controls.Add(Me.Button11)
        Me.GroupBox3.Controls.Add(Me.Button10)
        Me.GroupBox3.Controls.Add(Me.Button9)
        Me.GroupBox3.Controls.Add(Me.Button8)
        Me.GroupBox3.Controls.Add(Me.Button7)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(320, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(705, 222)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Grupal"
        '
        'btnReporteGral
        '
        Me.btnReporteGral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReporteGral.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReporteGral.Location = New System.Drawing.Point(122, 196)
        Me.btnReporteGral.Name = "btnReporteGral"
        Me.btnReporteGral.Size = New System.Drawing.Size(117, 23)
        Me.btnReporteGral.TabIndex = 41
        Me.btnReporteGral.Text = "Resumen General"
        Me.btnReporteGral.UseVisualStyleBackColor = True
        '
        'btnConstanciaISRAnual
        '
        Me.btnConstanciaISRAnual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConstanciaISRAnual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConstanciaISRAnual.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConstanciaISRAnual.Location = New System.Drawing.Point(540, 171)
        Me.btnConstanciaISRAnual.Name = "btnConstanciaISRAnual"
        Me.btnConstanciaISRAnual.Size = New System.Drawing.Size(188, 23)
        Me.btnConstanciaISRAnual.TabIndex = 40
        Me.btnConstanciaISRAnual.Text = "Constancia ISR Anual"
        Me.btnConstanciaISRAnual.UseVisualStyleBackColor = True
        '
        'btnDetGral
        '
        Me.btnDetGral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDetGral.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDetGral.Location = New System.Drawing.Point(368, 196)
        Me.btnDetGral.Name = "btnDetGral"
        Me.btnDetGral.Size = New System.Drawing.Size(171, 23)
        Me.btnDetGral.TabIndex = 39
        Me.btnDetGral.Text = "Detalle General Ord. Ext."
        Me.btnDetGral.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Location = New System.Drawing.Point(368, 172)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(171, 23)
        Me.Button12.TabIndex = 38
        Me.Button12.Text = "Estado de Cuenta sin Ayuda"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(368, 147)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(171, 23)
        Me.Button11.TabIndex = 37
        Me.Button11.Text = "Estado de Cuenta"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Location = New System.Drawing.Point(241, 196)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(126, 23)
        Me.Button10.TabIndex = 36
        Me.Button10.Text = "Detalle General"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(241, 172)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(126, 23)
        Me.Button9.TabIndex = 35
        Me.Button9.Text = "Detalle Extraordinario"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Location = New System.Drawing.Point(241, 147)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(126, 23)
        Me.Button8.TabIndex = 34
        Me.Button8.Text = "Detalle Ordinario"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Location = New System.Drawing.Point(122, 172)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(117, 23)
        Me.Button7.TabIndex = 33
        Me.Button7.Text = "Resumen Bancos"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(540, 194)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(188, 23)
        Me.Button6.TabIndex = 32
        Me.Button6.Text = "Exportar a Disco en PDF"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Button5
        '
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(3, 147)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(117, 23)
        Me.Button5.TabIndex = 31
        Me.Button5.Text = "Listado Entrega"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmbGerencias)
        Me.GroupBox5.Controls.Add(Me.cmbCargos)
        Me.GroupBox5.Controls.Add(Me.cmbSecciones)
        Me.GroupBox5.Controls.Add(Me.cmbDivisiones)
        Me.GroupBox5.Controls.Add(Me.cmbDepartamentos)
        Me.GroupBox5.Controls.Add(Me.CheckBox1)
        Me.GroupBox5.Controls.Add(Me.GroupBox7)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Controls.Add(Me.TextBox3)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.cantidadEmpleados)
        Me.GroupBox5.Controls.Add(Me.cmbGeneral)
        Me.GroupBox5.Controls.Add(Me.chkDetalle)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(699, 131)
        Me.GroupBox5.TabIndex = 18
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Estado de Cuenta Grupal"
        '
        'cmbGerencias
        '
        Me.cmbGerencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGerencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbGerencias.FormattingEnabled = True
        Me.cmbGerencias.Location = New System.Drawing.Point(116, 15)
        Me.cmbGerencias.Name = "cmbGerencias"
        Me.cmbGerencias.Size = New System.Drawing.Size(244, 21)
        Me.cmbGerencias.TabIndex = 44
        '
        'cmbCargos
        '
        Me.cmbCargos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCargos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCargos.FormattingEnabled = True
        Me.cmbCargos.Location = New System.Drawing.Point(116, 107)
        Me.cmbCargos.Name = "cmbCargos"
        Me.cmbCargos.Size = New System.Drawing.Size(244, 21)
        Me.cmbCargos.TabIndex = 43
        '
        'cmbSecciones
        '
        Me.cmbSecciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSecciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSecciones.FormattingEnabled = True
        Me.cmbSecciones.Location = New System.Drawing.Point(116, 84)
        Me.cmbSecciones.Name = "cmbSecciones"
        Me.cmbSecciones.Size = New System.Drawing.Size(244, 21)
        Me.cmbSecciones.TabIndex = 42
        '
        'cmbDivisiones
        '
        Me.cmbDivisiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDivisiones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDivisiones.FormattingEnabled = True
        Me.cmbDivisiones.Location = New System.Drawing.Point(116, 38)
        Me.cmbDivisiones.Name = "cmbDivisiones"
        Me.cmbDivisiones.Size = New System.Drawing.Size(244, 21)
        Me.cmbDivisiones.TabIndex = 41
        '
        'cmbDepartamentos
        '
        Me.cmbDepartamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDepartamentos.FormattingEnabled = True
        Me.cmbDepartamentos.Location = New System.Drawing.Point(116, 61)
        Me.cmbDepartamentos.Name = "cmbDepartamentos"
        Me.cmbDepartamentos.Size = New System.Drawing.Size(244, 21)
        Me.cmbDepartamentos.TabIndex = 40
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(549, 115)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(135, 17)
        Me.CheckBox1.TabIndex = 39
        Me.CheckBox1.Text = "Habilitar Jerarquias"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.RadioButton1)
        Me.GroupBox7.Controls.Add(Me.RadioButton2)
        Me.GroupBox7.Controls.Add(Me.RadioButton5)
        Me.GroupBox7.Controls.Add(Me.RadioButton4)
        Me.GroupBox7.Controls.Add(Me.RadioButton3)
        Me.GroupBox7.Enabled = False
        Me.GroupBox7.Location = New System.Drawing.Point(6, 9)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(107, 120)
        Me.GroupBox7.TabIndex = 38
        Me.GroupBox7.TabStop = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.ForeColor = System.Drawing.Color.White
        Me.RadioButton1.Location = New System.Drawing.Point(4, 31)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(83, 17)
        Me.RadioButton1.TabIndex = 22
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Divisiones"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.ForeColor = System.Drawing.Color.White
        Me.RadioButton2.Location = New System.Drawing.Point(4, 55)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(110, 17)
        Me.RadioButton2.TabIndex = 23
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Departamentos"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.ForeColor = System.Drawing.Color.White
        Me.RadioButton5.Location = New System.Drawing.Point(4, 9)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(82, 17)
        Me.RadioButton5.TabIndex = 28
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "Gerencias"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.ForeColor = System.Drawing.Color.White
        Me.RadioButton4.Location = New System.Drawing.Point(4, 99)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(64, 17)
        Me.RadioButton4.TabIndex = 24
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Cargos"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.ForeColor = System.Drawing.Color.White
        Me.RadioButton3.Location = New System.Drawing.Point(4, 77)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(84, 17)
        Me.RadioButton3.TabIndex = 25
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Secciones"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(546, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Mayor al codigo:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.RadioButton6)
        Me.GroupBox6.Controls.Add(Me.RadioButton9)
        Me.GroupBox6.Controls.Add(Me.RadioButton7)
        Me.GroupBox6.Location = New System.Drawing.Point(369, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(174, 117)
        Me.GroupBox6.TabIndex = 37
        Me.GroupBox6.TabStop = False
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(6, 32)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(169, 17)
        Me.RadioButton6.TabIndex = 33
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "Todos los Departamentos"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton9
        '
        Me.RadioButton9.AutoSize = True
        Me.RadioButton9.Location = New System.Drawing.Point(6, 99)
        Me.RadioButton9.Name = "RadioButton9"
        Me.RadioButton9.Size = New System.Drawing.Size(123, 17)
        Me.RadioButton9.TabIndex = 36
        Me.RadioButton9.TabStop = True
        Me.RadioButton9.Text = "Todos los Cargos"
        Me.RadioButton9.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Location = New System.Drawing.Point(6, 54)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(143, 17)
        Me.RadioButton7.TabIndex = 34
        Me.RadioButton7.TabStop = True
        Me.RadioButton7.Text = "Todas las Secciones"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Location = New System.Drawing.Point(549, 95)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(98, 20)
        Me.TextBox3.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(579, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Empleados"
        '
        'cantidadEmpleados
        '
        Me.cantidadEmpleados.AutoSize = True
        Me.cantidadEmpleados.ForeColor = System.Drawing.Color.Red
        Me.cantidadEmpleados.Location = New System.Drawing.Point(546, 62)
        Me.cantidadEmpleados.Name = "cantidadEmpleados"
        Me.cantidadEmpleados.Size = New System.Drawing.Size(14, 13)
        Me.cantidadEmpleados.TabIndex = 20
        Me.cantidadEmpleados.Text = "0"
        '
        'cmbGeneral
        '
        Me.cmbGeneral.AutoSize = True
        Me.cmbGeneral.Location = New System.Drawing.Point(549, 15)
        Me.cmbGeneral.Name = "cmbGeneral"
        Me.cmbGeneral.Size = New System.Drawing.Size(119, 17)
        Me.cmbGeneral.TabIndex = 14
        Me.cmbGeneral.Text = "Reporte General"
        Me.cmbGeneral.UseVisualStyleBackColor = True
        '
        'chkDetalle
        '
        Me.chkDetalle.AutoSize = True
        Me.chkDetalle.Location = New System.Drawing.Point(549, 36)
        Me.chkDetalle.Name = "chkDetalle"
        Me.chkDetalle.Size = New System.Drawing.Size(129, 17)
        Me.chkDetalle.TabIndex = 15
        Me.chkDetalle.Text = "Reporte Detallado"
        Me.chkDetalle.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(122, 147)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(117, 23)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "Constancia ISR"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(3, 172)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(117, 23)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "Boletas de Pago"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(540, 147)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(188, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Imprimir los Estados de Cuenta"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1028, 241)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles"
        '
        'bBw1
        '
        Me.bBw1.WorkerReportsProgress = True
        Me.bBw1.WorkerSupportsCancellation = True
        '
        'bBw2
        '
        Me.bBw2.WorkerReportsProgress = True
        Me.bBw2.WorkerSupportsCancellation = True
        '
        'pB2
        '
        Me.pB2.Dock = System.Windows.Forms.DockStyle.Top
        Me.pB2.Location = New System.Drawing.Point(0, 241)
        Me.pB2.Name = "pB2"
        Me.pB2.Size = New System.Drawing.Size(1028, 10)
        Me.pB2.TabIndex = 109
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 251)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1028, 355)
        Me.CrystalReportViewer1.TabIndex = 110
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'aBw2
        '
        Me.aBw2.WorkerReportsProgress = True
        Me.aBw2.WorkerSupportsCancellation = True
        '
        'aBw1
        '
        Me.aBw1.WorkerReportsProgress = True
        Me.aBw1.WorkerSupportsCancellation = True
        '
        'eBw1
        '
        Me.eBw1.WorkerReportsProgress = True
        Me.eBw1.WorkerSupportsCancellation = True
        '
        'eBw2
        '
        Me.eBw2.WorkerReportsProgress = True
        Me.eBw2.WorkerSupportsCancellation = True
        '
        'bwCreatePDF
        '
        Me.bwCreatePDF.WorkerReportsProgress = True
        Me.bwCreatePDF.WorkerSupportsCancellation = True
        '
        'BwRepDetGral
        '
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.Brown
        Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.Location = New System.Drawing.Point(3, 196)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(117, 23)
        Me.Button13.TabIndex = 42
        Me.Button13.Text = "CANCELAR"
        Me.Button13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button13.UseVisualStyleBackColor = False
        Me.Button13.Visible = False
        '
        'Cooperativa_Estado_Cuenta_ATAF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1028, 606)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.pB2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Cooperativa_Estado_Cuenta_ATAF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes Reparto Dividendos ATAF"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.NumericUpDown11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton9 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cantidadEmpleados As System.Windows.Forms.Label
    Friend WithEvents cmbGeneral As System.Windows.Forms.CheckBox
    Friend WithEvents chkDetalle As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown11 As System.Windows.Forms.NumericUpDown
    Friend WithEvents bBw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bBw2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents pB2 As System.Windows.Forms.ProgressBar
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents aBw2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents aBw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents eBw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents eBw2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwCreatePDF As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnDetGral As System.Windows.Forms.Button
    Friend WithEvents BwRepDetGral As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmbGerencias As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCargos As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSecciones As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDivisiones As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDepartamentos As System.Windows.Forms.ComboBox
    Friend WithEvents btnConstanciaISRAnual As System.Windows.Forms.Button
    Friend WithEvents btnReporteGral As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
End Class
