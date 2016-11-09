<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Facturacion_Reportes
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
        Me.btnVer = New System.Windows.Forms.Button
        Me.dpFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.dpFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.cmbTipDoc = New System.Windows.Forms.ComboBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.cmbBodega = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbORIGEN = New System.Windows.Forms.ComboBox
        Me.chkFiltro = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbFPCredito = New System.Windows.Forms.RadioButton
        Me.rbFPContado = New System.Windows.Forms.RadioButton
        Me.rbFPTodos = New System.Windows.Forms.RadioButton
        Me.chkAExtra = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbTiempoComida = New System.Windows.Forms.ComboBox
        Me.cmbCajas = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVer
        '
        Me.btnVer.BackColor = System.Drawing.Color.Transparent
        Me.btnVer.Location = New System.Drawing.Point(506, 78)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(75, 23)
        Me.btnVer.TabIndex = 1
        Me.btnVer.Text = "Generar"
        Me.btnVer.UseVisualStyleBackColor = False
        '
        'dpFechaDesde
        '
        Me.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaDesde.Location = New System.Drawing.Point(73, 12)
        Me.dpFechaDesde.Name = "dpFechaDesde"
        Me.dpFechaDesde.Size = New System.Drawing.Size(88, 20)
        Me.dpFechaDesde.TabIndex = 2
        '
        'dpFechaHasta
        '
        Me.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaHasta.Location = New System.Drawing.Point(209, 12)
        Me.dpFechaHasta.Name = "dpFechaHasta"
        Me.dpFechaHasta.Size = New System.Drawing.Size(89, 20)
        Me.dpFechaHasta.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Desde:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(169, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hasta:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(304, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(94, 92)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(7, 29)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(77, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Resumen"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(8, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(79, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Detallado"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'cmbTipDoc
        '
        Me.cmbTipDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipDoc.FormattingEnabled = True
        Me.cmbTipDoc.Location = New System.Drawing.Point(73, 84)
        Me.cmbTipDoc.Name = "cmbTipDoc"
        Me.cmbTipDoc.Size = New System.Drawing.Size(225, 21)
        Me.cmbTipDoc.TabIndex = 7
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Navy
        Me.CheckBox1.Location = New System.Drawing.Point(506, 32)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(102, 20)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "Ver Anulados"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'cmbBodega
        '
        Me.cmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(73, 34)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(225, 21)
        Me.cmbBodega.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(12, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Bodega:"
        '
        'cmbORIGEN
        '
        Me.cmbORIGEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbORIGEN.Enabled = False
        Me.cmbORIGEN.FormattingEnabled = True
        Me.cmbORIGEN.Location = New System.Drawing.Point(569, 50)
        Me.cmbORIGEN.Name = "cmbORIGEN"
        Me.cmbORIGEN.Size = New System.Drawing.Size(191, 21)
        Me.cmbORIGEN.TabIndex = 11
        '
        'chkFiltro
        '
        Me.chkFiltro.BackColor = System.Drawing.Color.Transparent
        Me.chkFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFiltro.ForeColor = System.Drawing.Color.Navy
        Me.chkFiltro.Location = New System.Drawing.Point(506, 54)
        Me.chkFiltro.Name = "chkFiltro"
        Me.chkFiltro.Size = New System.Drawing.Size(63, 17)
        Me.chkFiltro.TabIndex = 12
        Me.chkFiltro.Text = "Origen"
        Me.chkFiltro.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.rbFPCredito)
        Me.GroupBox2.Controls.Add(Me.rbFPContado)
        Me.GroupBox2.Controls.Add(Me.rbFPTodos)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(404, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(96, 91)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Forma Pago"
        '
        'rbFPCredito
        '
        Me.rbFPCredito.AutoSize = True
        Me.rbFPCredito.Location = New System.Drawing.Point(7, 42)
        Me.rbFPCredito.Name = "rbFPCredito"
        Me.rbFPCredito.Size = New System.Drawing.Size(65, 17)
        Me.rbFPCredito.TabIndex = 2
        Me.rbFPCredito.Text = "Crédito"
        Me.rbFPCredito.UseVisualStyleBackColor = True
        '
        'rbFPContado
        '
        Me.rbFPContado.AutoSize = True
        Me.rbFPContado.Location = New System.Drawing.Point(7, 27)
        Me.rbFPContado.Name = "rbFPContado"
        Me.rbFPContado.Size = New System.Drawing.Size(72, 17)
        Me.rbFPContado.TabIndex = 1
        Me.rbFPContado.Text = "Contado"
        Me.rbFPContado.UseVisualStyleBackColor = True
        '
        'rbFPTodos
        '
        Me.rbFPTodos.AutoSize = True
        Me.rbFPTodos.Checked = True
        Me.rbFPTodos.Location = New System.Drawing.Point(7, 12)
        Me.rbFPTodos.Name = "rbFPTodos"
        Me.rbFPTodos.Size = New System.Drawing.Size(60, 17)
        Me.rbFPTodos.TabIndex = 0
        Me.rbFPTodos.TabStop = True
        Me.rbFPTodos.Text = "Todos"
        Me.rbFPTodos.UseVisualStyleBackColor = True
        '
        'chkAExtra
        '
        Me.chkAExtra.AutoSize = True
        Me.chkAExtra.BackColor = System.Drawing.Color.Transparent
        Me.chkAExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAExtra.Location = New System.Drawing.Point(506, 13)
        Me.chkAExtra.Name = "chkAExtra"
        Me.chkAExtra.Size = New System.Drawing.Size(168, 17)
        Me.chkAExtra.TabIndex = 14
        Me.chkAExtra.Text = "Pagado con Ahorro Extra"
        Me.chkAExtra.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox2)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cmbTiempoComida)
        Me.GroupBox3.Controls.Add(Me.cmbCajas)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.chkAExtra)
        Me.GroupBox3.Controls.Add(Me.btnVer)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.dpFechaDesde)
        Me.GroupBox3.Controls.Add(Me.cmbORIGEN)
        Me.GroupBox3.Controls.Add(Me.dpFechaHasta)
        Me.GroupBox3.Controls.Add(Me.chkFiltro)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.cmbBodega)
        Me.GroupBox3.Controls.Add(Me.cmbTipDoc)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1028, 138)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'CheckBox2
        '
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.Navy
        Me.CheckBox2.Location = New System.Drawing.Point(304, 111)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(63, 17)
        Me.CheckBox2.TabIndex = 157
        Me.CheckBox2.Text = "Todos los Tiempos"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(12, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 156
        Me.Label6.Text = "T. Comida:"
        '
        'cmbTiempoComida
        '
        Me.cmbTiempoComida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiempoComida.FormattingEnabled = True
        Me.cmbTiempoComida.Location = New System.Drawing.Point(73, 109)
        Me.cmbTiempoComida.Name = "cmbTiempoComida"
        Me.cmbTiempoComida.Size = New System.Drawing.Size(225, 21)
        Me.cmbTiempoComida.TabIndex = 155
        '
        'cmbCajas
        '
        Me.cmbCajas.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCajas.ForeColor = System.Drawing.Color.Navy
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.Location = New System.Drawing.Point(73, 57)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(225, 24)
        Me.cmbCajas.TabIndex = 88
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(12, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 16)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "Caja:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(12, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Tipo Doc:"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 138)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1028, 441)
        Me.CrystalReportViewer1.TabIndex = 16
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'Facturacion_Reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 579)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "Facturacion_Reportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Facturacion Reportes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnVer As System.Windows.Forms.Button
    Friend WithEvents dpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipDoc As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbORIGEN As System.Windows.Forms.ComboBox
    Friend WithEvents chkFiltro As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbFPCredito As System.Windows.Forms.RadioButton
    Friend WithEvents rbFPContado As System.Windows.Forms.RadioButton
    Friend WithEvents rbFPTodos As System.Windows.Forms.RadioButton
    Friend WithEvents chkAExtra As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCajas As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTiempoComida As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
End Class
