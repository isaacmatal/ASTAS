<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCancelaDeudasNoBuxis
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
        Me.dgvProgramaciones = New System.Windows.Forms.DataGridView
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkBoni = New System.Windows.Forms.CheckBox
        Me.chkAguin = New System.Windows.Forms.CheckBox
        Me.cmbOrigenes = New System.Windows.Forms.ComboBox
        Me.SelectAll = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbTodos = New System.Windows.Forms.RadioButton
        Me.rbNoPagado = New System.Windows.Forms.RadioButton
        Me.rbPagado = New System.Windows.Forms.RadioButton
        CType(Me.dgvProgramaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProgramaciones
        '
        Me.dgvProgramaciones.AllowUserToAddRows = False
        Me.dgvProgramaciones.AllowUserToDeleteRows = False
        Me.dgvProgramaciones.AllowUserToResizeColumns = False
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
        Me.dgvProgramaciones.Location = New System.Drawing.Point(7, 43)
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
        Me.dgvProgramaciones.Size = New System.Drawing.Size(942, 592)
        Me.dgvProgramaciones.TabIndex = 104
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardar.Image = Global.ASTAS.My.Resources.Resources.filesave
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(507, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 24)
        Me.btnGuardar.TabIndex = 106
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(111, 6)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(90, 22)
        Me.DateTimePicker1.TabIndex = 107
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Periodo a Procesar:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkBoni)
        Me.GroupBox1.Controls.Add(Me.chkAguin)
        Me.GroupBox1.Location = New System.Drawing.Point(207, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(170, 42)
        Me.GroupBox1.TabIndex = 109
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodos Especiales"
        '
        'chkBoni
        '
        Me.chkBoni.AutoSize = True
        Me.chkBoni.Location = New System.Drawing.Point(83, 17)
        Me.chkBoni.Name = "chkBoni"
        Me.chkBoni.Size = New System.Drawing.Size(82, 20)
        Me.chkBoni.TabIndex = 1
        Me.chkBoni.Text = "Bonificación"
        Me.chkBoni.UseVisualStyleBackColor = True
        '
        'chkAguin
        '
        Me.chkAguin.AutoSize = True
        Me.chkAguin.Location = New System.Drawing.Point(7, 17)
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
        Me.cmbOrigenes.Location = New System.Drawing.Point(380, 9)
        Me.cmbOrigenes.Name = "cmbOrigenes"
        Me.cmbOrigenes.Size = New System.Drawing.Size(121, 24)
        Me.cmbOrigenes.TabIndex = 110
        '
        'SelectAll
        '
        Me.SelectAll.AutoSize = True
        Me.SelectAll.BackColor = System.Drawing.Color.Transparent
        Me.SelectAll.Location = New System.Drawing.Point(599, 13)
        Me.SelectAll.Name = "SelectAll"
        Me.SelectAll.Size = New System.Drawing.Size(115, 20)
        Me.SelectAll.TabIndex = 111
        Me.SelectAll.Text = "Seleccionar Todos"
        Me.SelectAll.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.rbTodos)
        Me.GroupBox2.Controls.Add(Me.rbNoPagado)
        Me.GroupBox2.Controls.Add(Me.rbPagado)
        Me.GroupBox2.Location = New System.Drawing.Point(720, -1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(229, 42)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estado"
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Checked = True
        Me.rbTodos.Location = New System.Drawing.Point(167, 15)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(56, 20)
        Me.rbTodos.TabIndex = 5
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbNoPagado
        '
        Me.rbNoPagado.AutoSize = True
        Me.rbNoPagado.Location = New System.Drawing.Point(81, 15)
        Me.rbNoPagado.Name = "rbNoPagado"
        Me.rbNoPagado.Size = New System.Drawing.Size(80, 20)
        Me.rbNoPagado.TabIndex = 4
        Me.rbNoPagado.Text = "No Pagado"
        Me.rbNoPagado.UseVisualStyleBackColor = True
        '
        'rbPagado
        '
        Me.rbPagado.AutoSize = True
        Me.rbPagado.Location = New System.Drawing.Point(7, 15)
        Me.rbPagado.Name = "rbPagado"
        Me.rbPagado.Size = New System.Drawing.Size(63, 20)
        Me.rbPagado.TabIndex = 3
        Me.rbPagado.Text = "Pagado"
        Me.rbPagado.UseVisualStyleBackColor = True
        '
        'FrmCancelaDeudasNoBuxis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 638)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.SelectAll)
        Me.Controls.Add(Me.cmbOrigenes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.dgvProgramaciones)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmCancelaDeudasNoBuxis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa – Cancelar Deudas de Terceros"
        CType(Me.dgvProgramaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProgramaciones As System.Windows.Forms.DataGridView
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkBoni As System.Windows.Forms.CheckBox
    Friend WithEvents chkAguin As System.Windows.Forms.CheckBox
    Friend WithEvents cmbOrigenes As System.Windows.Forms.ComboBox
    Friend WithEvents SelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbNoPagado As System.Windows.Forms.RadioButton
    Friend WithEvents rbPagado As System.Windows.Forms.RadioButton
End Class
