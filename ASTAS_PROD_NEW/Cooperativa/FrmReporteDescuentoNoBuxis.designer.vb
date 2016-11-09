<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporteDescuentoNoBuxis
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkBoni = New System.Windows.Forms.CheckBox
        Me.chkAguin = New System.Windows.Forms.CheckBox
        Me.cmbOrigenes = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbtTodos = New System.Windows.Forms.RadioButton
        Me.rbtNoAplic = New System.Windows.Forms.RadioButton
        Me.rbtAplic = New System.Windows.Forms.RadioButton
        Me.BtnEnviar = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.dgvProgramaciones = New System.Windows.Forms.DataGridView
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvProgramaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(88, 18)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(90, 22)
        Me.DateTimePicker1.TabIndex = 107
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Periodo Pago:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkBoni)
        Me.GroupBox1.Controls.Add(Me.chkAguin)
        Me.GroupBox1.Location = New System.Drawing.Point(185, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(170, 42)
        Me.GroupBox1.TabIndex = 109
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodos Especiales"
        '
        'chkBoni
        '
        Me.chkBoni.AutoSize = True
        Me.chkBoni.Location = New System.Drawing.Point(82, 17)
        Me.chkBoni.Name = "chkBoni"
        Me.chkBoni.Size = New System.Drawing.Size(82, 20)
        Me.chkBoni.TabIndex = 1
        Me.chkBoni.Text = "Bonificación"
        Me.chkBoni.UseVisualStyleBackColor = True
        '
        'chkAguin
        '
        Me.chkAguin.AutoSize = True
        Me.chkAguin.Location = New System.Drawing.Point(6, 15)
        Me.chkAguin.Name = "chkAguin"
        Me.chkAguin.Size = New System.Drawing.Size(74, 20)
        Me.chkAguin.TabIndex = 0
        Me.chkAguin.Text = "Aguinaldo"
        Me.chkAguin.UseVisualStyleBackColor = True
        '
        'cmbOrigenes
        '
        Me.cmbOrigenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenes.FormattingEnabled = True
        Me.cmbOrigenes.Location = New System.Drawing.Point(361, 18)
        Me.cmbOrigenes.Name = "cmbOrigenes"
        Me.cmbOrigenes.Size = New System.Drawing.Size(121, 24)
        Me.cmbOrigenes.TabIndex = 110
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtTodos)
        Me.GroupBox2.Controls.Add(Me.rbtNoAplic)
        Me.GroupBox2.Controls.Add(Me.rbtAplic)
        Me.GroupBox2.Location = New System.Drawing.Point(488, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(236, 42)
        Me.GroupBox2.TabIndex = 111
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones"
        '
        'rbtTodos
        '
        Me.rbtTodos.AutoSize = True
        Me.rbtTodos.Checked = True
        Me.rbtTodos.Location = New System.Drawing.Point(7, 16)
        Me.rbtTodos.Name = "rbtTodos"
        Me.rbtTodos.Size = New System.Drawing.Size(56, 20)
        Me.rbtTodos.TabIndex = 2
        Me.rbtTodos.TabStop = True
        Me.rbtTodos.Text = "Todos"
        Me.rbtTodos.UseVisualStyleBackColor = True
        '
        'rbtNoAplic
        '
        Me.rbtNoAplic.AutoSize = True
        Me.rbtNoAplic.Location = New System.Drawing.Point(143, 17)
        Me.rbtNoAplic.Name = "rbtNoAplic"
        Me.rbtNoAplic.Size = New System.Drawing.Size(85, 20)
        Me.rbtNoAplic.TabIndex = 1
        Me.rbtNoAplic.Text = "No Pagados"
        Me.rbtNoAplic.UseVisualStyleBackColor = True
        '
        'rbtAplic
        '
        Me.rbtAplic.AutoSize = True
        Me.rbtAplic.Location = New System.Drawing.Point(69, 17)
        Me.rbtAplic.Name = "rbtAplic"
        Me.rbtAplic.Size = New System.Drawing.Size(68, 20)
        Me.rbtAplic.TabIndex = 0
        Me.rbtAplic.Text = "Pagados"
        Me.rbtAplic.UseVisualStyleBackColor = True
        '
        'BtnEnviar
        '
        Me.BtnEnviar.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.BtnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEnviar.Location = New System.Drawing.Point(488, 55)
        Me.BtnEnviar.Name = "BtnEnviar"
        Me.BtnEnviar.Size = New System.Drawing.Size(75, 24)
        Me.BtnEnviar.TabIndex = 106
        Me.BtnEnviar.Text = "Imprimir"
        Me.BtnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEnviar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.BtnEnviar)
        Me.GroupBox3.Controls.Add(Me.cmbOrigenes)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(955, 81)
        Me.GroupBox3.TabIndex = 112
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalles Reporte"
        '
        'Button1
        '
        Me.Button1.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(613, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 24)
        Me.Button1.TabIndex = 107
        Me.Button1.Text = "Generar (.txt)"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvProgramaciones
        '
        Me.dgvProgramaciones.AllowUserToAddRows = False
        Me.dgvProgramaciones.AllowUserToDeleteRows = False
        Me.dgvProgramaciones.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvProgramaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProgramaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProgramaciones.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvProgramaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProgramaciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProgramaciones.Location = New System.Drawing.Point(0, 81)
        Me.dgvProgramaciones.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProgramaciones.Name = "dgvProgramaciones"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProgramaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProgramaciones.RowHeadersVisible = False
        Me.dgvProgramaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProgramaciones.Size = New System.Drawing.Size(955, 557)
        Me.dgvProgramaciones.TabIndex = 114
        '
        'FrmReporteDescuentoNoBuxis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 638)
        Me.Controls.Add(Me.dgvProgramaciones)
        Me.Controls.Add(Me.GroupBox3)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmReporteDescuentoNoBuxis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa – Reporte de descuentos a Terceros"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvProgramaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnEnviar As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkBoni As System.Windows.Forms.CheckBox
    Friend WithEvents chkAguin As System.Windows.Forms.CheckBox
    Friend WithEvents cmbOrigenes As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtNoAplic As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAplic As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvProgramaciones As System.Windows.Forms.DataGridView
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
