<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Facturacion_Reportes_Detallado_Libre
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnVer = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbTipDoc = New System.Windows.Forms.ComboBox
        Me.cmbBodega = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbORIGEN = New System.Windows.Forms.ComboBox
        Me.chkFiltro = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbFPCredito = New System.Windows.Forms.RadioButton
        Me.rbFPContado = New System.Windows.Forms.RadioButton
        Me.rbFPTodos = New System.Windows.Forms.RadioButton
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 87)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(830, 362)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'btnVer
        '
        Me.btnVer.Location = New System.Drawing.Point(0, 59)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(75, 23)
        Me.btnVer.TabIndex = 1
        Me.btnVer.Text = "Generar"
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(47, 9)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(88, 20)
        Me.DateTimePicker1.TabIndex = 2
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(185, 9)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(89, 20)
        Me.DateTimePicker2.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Desde:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(146, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hasta:"
        '
        'cmbTipDoc
        '
        Me.cmbTipDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipDoc.FormattingEnabled = True
        Me.cmbTipDoc.Location = New System.Drawing.Point(81, 60)
        Me.cmbTipDoc.Name = "cmbTipDoc"
        Me.cmbTipDoc.Size = New System.Drawing.Size(193, 21)
        Me.cmbTipDoc.TabIndex = 7
        '
        'cmbBodega
        '
        Me.cmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(49, 35)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(225, 21)
        Me.cmbBodega.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 38)
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
        Me.cmbORIGEN.Location = New System.Drawing.Point(344, 65)
        Me.cmbORIGEN.Name = "cmbORIGEN"
        Me.cmbORIGEN.Size = New System.Drawing.Size(191, 21)
        Me.cmbORIGEN.TabIndex = 11
        Me.cmbORIGEN.Visible = False
        '
        'chkFiltro
        '
        Me.chkFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFiltro.ForeColor = System.Drawing.Color.Navy
        Me.chkFiltro.Location = New System.Drawing.Point(284, 67)
        Me.chkFiltro.Name = "chkFiltro"
        Me.chkFiltro.Size = New System.Drawing.Size(63, 17)
        Me.chkFiltro.TabIndex = 12
        Me.chkFiltro.Text = "Origen"
        Me.chkFiltro.UseVisualStyleBackColor = True
        Me.chkFiltro.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbFPCredito)
        Me.GroupBox2.Controls.Add(Me.rbFPContado)
        Me.GroupBox2.Controls.Add(Me.rbFPTodos)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(278, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(96, 62)
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
        'Facturacion_Reportes_Detallado_Libre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 449)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmbORIGEN)
        Me.Controls.Add(Me.chkFiltro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbBodega)
        Me.Controls.Add(Me.cmbTipDoc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.btnVer)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "Facturacion_Reportes_Detallado_Libre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Facturacion Reportes"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnVer As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTipDoc As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbORIGEN As System.Windows.Forms.ComboBox
    Friend WithEvents chkFiltro As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbFPCredito As System.Windows.Forms.RadioButton
    Friend WithEvents rbFPContado As System.Windows.Forms.RadioButton
    Friend WithEvents rbFPTodos As System.Windows.Forms.RadioButton
End Class
