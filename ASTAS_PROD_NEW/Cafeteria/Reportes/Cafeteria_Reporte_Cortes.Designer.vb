<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Reporte_Cortes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Reporte_Cortes))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbCorteZ = New System.Windows.Forms.RadioButton
        Me.rbCorteX = New System.Windows.Forms.RadioButton
        Me.rbCorteZZ = New System.Windows.Forms.RadioButton
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.cmbCajas = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpFechaInicioTrabajo = New System.Windows.Forms.DateTimePicker
        Me.cbTiempoComida = New System.Windows.Forms.ComboBox
        Me.lblFechaTrabajo = New System.Windows.Forms.Label
        Me.lblTiempoComida = New System.Windows.Forms.Label
        Me.btnImprimirCorte = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbCorteZZ)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(3, 71)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(830, 55)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cortes de Mes"
        '
        'rbCorteZ
        '
        Me.rbCorteZ.AutoSize = True
        Me.rbCorteZ.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.rbCorteZ.ForeColor = System.Drawing.Color.Black
        Me.rbCorteZ.Location = New System.Drawing.Point(77, 22)
        Me.rbCorteZ.Name = "rbCorteZ"
        Me.rbCorteZ.Size = New System.Drawing.Size(62, 20)
        Me.rbCorteZ.TabIndex = 1
        Me.rbCorteZ.Text = "Corte Z"
        Me.rbCorteZ.UseVisualStyleBackColor = True
        '
        'rbCorteX
        '
        Me.rbCorteX.AutoSize = True
        Me.rbCorteX.Checked = True
        Me.rbCorteX.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.rbCorteX.ForeColor = System.Drawing.Color.Black
        Me.rbCorteX.Location = New System.Drawing.Point(9, 22)
        Me.rbCorteX.Name = "rbCorteX"
        Me.rbCorteX.Size = New System.Drawing.Size(62, 20)
        Me.rbCorteX.TabIndex = 0
        Me.rbCorteX.TabStop = True
        Me.rbCorteX.Text = "Corte X"
        Me.rbCorteX.UseVisualStyleBackColor = True
        '
        'rbCorteZZ
        '
        Me.rbCorteZZ.AutoSize = True
        Me.rbCorteZZ.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.rbCorteZZ.ForeColor = System.Drawing.Color.Black
        Me.rbCorteZZ.Location = New System.Drawing.Point(6, 22)
        Me.rbCorteZZ.Name = "rbCorteZZ"
        Me.rbCorteZZ.Size = New System.Drawing.Size(69, 20)
        Me.rbCorteZZ.TabIndex = 2
        Me.rbCorteZZ.Text = "Corte ZZ"
        Me.rbCorteZZ.UseVisualStyleBackColor = True
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(230, 19)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(456, 20)
        Me.txtCompañia.TabIndex = 87
        Me.txtCompañia.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(139, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "Compañía"
        Me.Label2.Visible = False
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(6, 19)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(127, 177)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 88
        Me.pbImagen.TabStop = False
        '
        'cmbCajas
        '
        Me.cmbCajas.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCajas.ForeColor = System.Drawing.Color.Navy
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.Location = New System.Drawing.Point(230, 75)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(456, 24)
        Me.cmbCajas.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(139, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 16)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "Caja"
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(230, 45)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(456, 24)
        Me.cmbBODEGA.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(139, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Cafeteria"
        '
        'dtpFechaInicioTrabajo
        '
        Me.dtpFechaInicioTrabajo.CustomFormat = "MMMM"
        Me.dtpFechaInicioTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicioTrabajo.Location = New System.Drawing.Point(274, 132)
        Me.dtpFechaInicioTrabajo.Name = "dtpFechaInicioTrabajo"
        Me.dtpFechaInicioTrabajo.Size = New System.Drawing.Size(109, 20)
        Me.dtpFechaInicioTrabajo.TabIndex = 3
        '
        'cbTiempoComida
        '
        Me.cbTiempoComida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTiempoComida.FormattingEnabled = True
        Me.cbTiempoComida.Location = New System.Drawing.Point(230, 105)
        Me.cbTiempoComida.Name = "cbTiempoComida"
        Me.cbTiempoComida.Size = New System.Drawing.Size(153, 21)
        Me.cbTiempoComida.TabIndex = 2
        '
        'lblFechaTrabajo
        '
        Me.lblFechaTrabajo.AutoSize = True
        Me.lblFechaTrabajo.Location = New System.Drawing.Point(139, 132)
        Me.lblFechaTrabajo.Name = "lblFechaTrabajo"
        Me.lblFechaTrabajo.Size = New System.Drawing.Size(122, 13)
        Me.lblFechaTrabajo.TabIndex = 94
        Me.lblFechaTrabajo.Text = "Fecha Inicio de Trabajo:"
        '
        'lblTiempoComida
        '
        Me.lblTiempoComida.AutoSize = True
        Me.lblTiempoComida.Location = New System.Drawing.Point(138, 108)
        Me.lblTiempoComida.Name = "lblTiempoComida"
        Me.lblTiempoComida.Size = New System.Drawing.Size(86, 13)
        Me.lblTiempoComida.TabIndex = 93
        Me.lblTiempoComida.Text = "Tiempo Comida :"
        '
        'btnImprimirCorte
        '
        Me.btnImprimirCorte.Image = CType(resources.GetObject("btnImprimirCorte.Image"), System.Drawing.Image)
        Me.btnImprimirCorte.Location = New System.Drawing.Point(626, 105)
        Me.btnImprimirCorte.Name = "btnImprimirCorte"
        Me.btnImprimirCorte.Size = New System.Drawing.Size(60, 47)
        Me.btnImprimirCorte.TabIndex = 4
        Me.btnImprimirCorte.Text = "Imprimir"
        Me.btnImprimirCorte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimirCorte.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(226, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(393, 22)
        Me.Label1.TabIndex = 134
        Me.Label1.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbCorteX)
        Me.GroupBox2.Controls.Add(Me.rbCorteZ)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(830, 55)
        Me.GroupBox2.TabIndex = 135
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cortes Diarios"
        '
        'Button1
        '
        Me.Button1.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.Button1.Location = New System.Drawing.Point(560, 105)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 47)
        Me.Button1.TabIndex = 136
        Me.Button1.Text = ".txt"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(138, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(257, 13)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Es necesario hacer primero el cierre de caja"
        Me.Label5.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 214)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(836, 343)
        Me.GroupBox3.TabIndex = 138
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.pbImagen)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.txtCompañia)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox4.Controls.Add(Me.btnImprimirCorte)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.dtpFechaInicioTrabajo)
        Me.GroupBox4.Controls.Add(Me.cmbCajas)
        Me.GroupBox4.Controls.Add(Me.cbTiempoComida)
        Me.GroupBox4.Controls.Add(Me.lblTiempoComida)
        Me.GroupBox4.Controls.Add(Me.lblFechaTrabajo)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(836, 214)
        Me.GroupBox4.TabIndex = 139
        Me.GroupBox4.TabStop = False
        '
        'Cafeteria_Reporte_Cortes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(836, 557)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Cafeteria_Reporte_Cortes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria_Reporte_Cortes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCorteZZ As System.Windows.Forms.RadioButton
    Friend WithEvents rbCorteZ As System.Windows.Forms.RadioButton
    Friend WithEvents rbCorteX As System.Windows.Forms.RadioButton
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents cmbCajas As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicioTrabajo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbTiempoComida As System.Windows.Forms.ComboBox
    Friend WithEvents lblFechaTrabajo As System.Windows.Forms.Label
    Friend WithEvents lblTiempoComida As System.Windows.Forms.Label
    Friend WithEvents btnImprimirCorte As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
End Class
