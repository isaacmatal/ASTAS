<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnviarProgramaciones
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEnviarProgramaciones))
        Me.dgvProgramaciones = New System.Windows.Forms.DataGridView
        Me.BtnEnviar = New System.Windows.Forms.Button
        Me.dpFechaPago = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkBoni = New System.Windows.Forms.CheckBox
        Me.chkAguin = New System.Windows.Forms.CheckBox
        Me.SelectAll = New System.Windows.Forms.CheckBox
        Me.pbBuxis = New System.Windows.Forms.ProgressBar
        Me.lblEnviando = New System.Windows.Forms.Label
        Me.chkIndemnizados = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbMensual = New System.Windows.Forms.RadioButton
        Me.rbQna = New System.Windows.Forms.RadioButton
        Me.btnVer = New System.Windows.Forms.Button
        Me.lblTotalEnviado = New System.Windows.Forms.Label
        Me.lblIndemnizados = New System.Windows.Forms.Label
        Me.chkResumen = New System.Windows.Forms.CheckBox
        Me.bw1 = New System.ComponentModel.BackgroundWorker
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbCodDeduc = New System.Windows.Forms.RadioButton
        Me.rbCodEmpleado = New System.Windows.Forms.RadioButton
        Me.btnCapital = New System.Windows.Forms.Button
        Me.btnCalculo = New System.Windows.Forms.Button
        CType(Me.dgvProgramaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProgramaciones
        '
        Me.dgvProgramaciones.AllowUserToAddRows = False
        Me.dgvProgramaciones.AllowUserToDeleteRows = False
        Me.dgvProgramaciones.AllowUserToResizeColumns = False
        Me.dgvProgramaciones.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvProgramaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvProgramaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProgramaciones.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvProgramaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProgramaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvProgramaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProgramaciones.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvProgramaciones.Location = New System.Drawing.Point(7, 78)
        Me.dgvProgramaciones.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProgramaciones.Name = "dgvProgramaciones"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProgramaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvProgramaciones.RowHeadersVisible = False
        Me.dgvProgramaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProgramaciones.Size = New System.Drawing.Size(942, 556)
        Me.dgvProgramaciones.TabIndex = 104
        '
        'BtnEnviar
        '
        Me.BtnEnviar.BackColor = System.Drawing.Color.Transparent
        Me.BtnEnviar.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.BtnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEnviar.Location = New System.Drawing.Point(524, 18)
        Me.BtnEnviar.Name = "BtnEnviar"
        Me.BtnEnviar.Size = New System.Drawing.Size(75, 24)
        Me.BtnEnviar.TabIndex = 106
        Me.BtnEnviar.Text = "Procesar"
        Me.BtnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEnviar.UseVisualStyleBackColor = False
        '
        'dpFechaPago
        '
        Me.dpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaPago.Location = New System.Drawing.Point(111, 15)
        Me.dpFechaPago.Name = "dpFechaPago"
        Me.dpFechaPago.Size = New System.Drawing.Size(90, 22)
        Me.dpFechaPago.TabIndex = 107
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(5, 18)
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
        Me.GroupBox1.Location = New System.Drawing.Point(352, 8)
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
        'SelectAll
        '
        Me.SelectAll.AutoSize = True
        Me.SelectAll.BackColor = System.Drawing.Color.Transparent
        Me.SelectAll.Location = New System.Drawing.Point(125, 53)
        Me.SelectAll.Name = "SelectAll"
        Me.SelectAll.Size = New System.Drawing.Size(115, 20)
        Me.SelectAll.TabIndex = 110
        Me.SelectAll.Text = "Seleccionar Todos"
        Me.SelectAll.UseVisualStyleBackColor = False
        '
        'pbBuxis
        '
        Me.pbBuxis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbBuxis.Location = New System.Drawing.Point(671, 11)
        Me.pbBuxis.Name = "pbBuxis"
        Me.pbBuxis.Size = New System.Drawing.Size(278, 16)
        Me.pbBuxis.Step = 1
        Me.pbBuxis.TabIndex = 111
        Me.pbBuxis.Visible = False
        '
        'lblEnviando
        '
        Me.lblEnviando.AutoSize = True
        Me.lblEnviando.BackColor = System.Drawing.Color.Transparent
        Me.lblEnviando.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnviando.ForeColor = System.Drawing.Color.Red
        Me.lblEnviando.Location = New System.Drawing.Point(600, 9)
        Me.lblEnviando.Name = "lblEnviando"
        Me.lblEnviando.Size = New System.Drawing.Size(59, 15)
        Me.lblEnviando.TabIndex = 112
        Me.lblEnviando.Text = "Enviando..."
        Me.lblEnviando.Visible = False
        '
        'chkIndemnizados
        '
        Me.chkIndemnizados.AutoSize = True
        Me.chkIndemnizados.BackColor = System.Drawing.Color.Transparent
        Me.chkIndemnizados.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIndemnizados.ForeColor = System.Drawing.Color.Navy
        Me.chkIndemnizados.Location = New System.Drawing.Point(11, 55)
        Me.chkIndemnizados.Name = "chkIndemnizados"
        Me.chkIndemnizados.Size = New System.Drawing.Size(15, 14)
        Me.chkIndemnizados.TabIndex = 113
        Me.chkIndemnizados.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.rbMensual)
        Me.GroupBox2.Controls.Add(Me.rbQna)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox2.Location = New System.Drawing.Point(203, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(147, 42)
        Me.GroupBox2.TabIndex = 114
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo Periodo"
        '
        'rbMensual
        '
        Me.rbMensual.AutoSize = True
        Me.rbMensual.Location = New System.Drawing.Point(78, 18)
        Me.rbMensual.Name = "rbMensual"
        Me.rbMensual.Size = New System.Drawing.Size(66, 20)
        Me.rbMensual.TabIndex = 1
        Me.rbMensual.TabStop = True
        Me.rbMensual.Text = "Mensual"
        Me.rbMensual.UseVisualStyleBackColor = True
        '
        'rbQna
        '
        Me.rbQna.AutoSize = True
        Me.rbQna.Checked = True
        Me.rbQna.Location = New System.Drawing.Point(5, 18)
        Me.rbQna.Name = "rbQna"
        Me.rbQna.Size = New System.Drawing.Size(73, 20)
        Me.rbQna.TabIndex = 0
        Me.rbQna.TabStop = True
        Me.rbQna.Text = "Quincenal"
        Me.rbQna.UseVisualStyleBackColor = True
        '
        'btnVer
        '
        Me.btnVer.BackColor = System.Drawing.Color.Transparent
        Me.btnVer.Image = CType(resources.GetObject("btnVer.Image"), System.Drawing.Image)
        Me.btnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVer.Location = New System.Drawing.Point(524, 48)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(75, 24)
        Me.btnVer.TabIndex = 115
        Me.btnVer.Text = "   Imprimir"
        Me.btnVer.UseVisualStyleBackColor = False
        '
        'lblTotalEnviado
        '
        Me.lblTotalEnviado.AutoSize = True
        Me.lblTotalEnviado.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalEnviado.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEnviado.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalEnviado.Location = New System.Drawing.Point(603, 16)
        Me.lblTotalEnviado.Name = "lblTotalEnviado"
        Me.lblTotalEnviado.Size = New System.Drawing.Size(0, 16)
        Me.lblTotalEnviado.TabIndex = 116
        '
        'lblIndemnizados
        '
        Me.lblIndemnizados.AutoSize = True
        Me.lblIndemnizados.BackColor = System.Drawing.Color.Transparent
        Me.lblIndemnizados.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIndemnizados.ForeColor = System.Drawing.Color.Navy
        Me.lblIndemnizados.Location = New System.Drawing.Point(28, 53)
        Me.lblIndemnizados.Name = "lblIndemnizados"
        Me.lblIndemnizados.Size = New System.Drawing.Size(82, 16)
        Me.lblIndemnizados.TabIndex = 117
        Me.lblIndemnizados.Text = "Indemnizados"
        '
        'chkResumen
        '
        Me.chkResumen.AutoSize = True
        Me.chkResumen.BackColor = System.Drawing.Color.Transparent
        Me.chkResumen.Location = New System.Drawing.Point(435, 53)
        Me.chkResumen.Name = "chkResumen"
        Me.chkResumen.Size = New System.Drawing.Size(72, 20)
        Me.chkResumen.TabIndex = 118
        Me.chkResumen.Text = "Resumen"
        Me.chkResumen.UseVisualStyleBackColor = False
        '
        'bw1
        '
        Me.bw1.WorkerReportsProgress = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.rbCodDeduc)
        Me.GroupBox3.Controls.Add(Me.rbCodEmpleado)
        Me.GroupBox3.Location = New System.Drawing.Point(610, 27)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(263, 48)
        Me.GroupBox3.TabIndex = 119
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Agrupar Reporte por:"
        '
        'rbCodDeduc
        '
        Me.rbCodDeduc.AutoSize = True
        Me.rbCodDeduc.Location = New System.Drawing.Point(136, 20)
        Me.rbCodDeduc.Name = "rbCodDeduc"
        Me.rbCodDeduc.Size = New System.Drawing.Size(113, 20)
        Me.rbCodDeduc.TabIndex = 1
        Me.rbCodDeduc.Text = "Código Deducción"
        Me.rbCodDeduc.UseVisualStyleBackColor = True
        '
        'rbCodEmpleado
        '
        Me.rbCodEmpleado.AutoSize = True
        Me.rbCodEmpleado.Checked = True
        Me.rbCodEmpleado.Location = New System.Drawing.Point(7, 21)
        Me.rbCodEmpleado.Name = "rbCodEmpleado"
        Me.rbCodEmpleado.Size = New System.Drawing.Size(110, 20)
        Me.rbCodEmpleado.TabIndex = 0
        Me.rbCodEmpleado.TabStop = True
        Me.rbCodEmpleado.Text = "Código Empleado"
        Me.rbCodEmpleado.UseVisualStyleBackColor = True
        '
        'btnCapital
        '
        Me.btnCapital.BackColor = System.Drawing.Color.Transparent
        Me.btnCapital.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapital.ForeColor = System.Drawing.Color.Navy
        Me.btnCapital.Image = CType(resources.GetObject("btnCapital.Image"), System.Drawing.Image)
        Me.btnCapital.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCapital.Location = New System.Drawing.Point(240, 51)
        Me.btnCapital.Name = "btnCapital"
        Me.btnCapital.Size = New System.Drawing.Size(183, 24)
        Me.btnCapital.TabIndex = 120
        Me.btnCapital.Text = "Reporte Capital NO Enviado"
        Me.btnCapital.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCapital.UseVisualStyleBackColor = False
        Me.btnCapital.Visible = False
        '
        'btnCalculo
        '
        Me.btnCalculo.Enabled = False
        Me.btnCalculo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalculo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCalculo.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.btnCalculo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCalculo.Location = New System.Drawing.Point(876, 33)
        Me.btnCalculo.Name = "btnCalculo"
        Me.btnCalculo.Size = New System.Drawing.Size(73, 44)
        Me.btnCalculo.TabIndex = 121
        Me.btnCalculo.Text = "Calculo Intereses"
        Me.btnCalculo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCalculo.UseVisualStyleBackColor = False
        '
        'FrmEnviarProgramaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 638)
        Me.Controls.Add(Me.btnCalculo)
        Me.Controls.Add(Me.btnCapital)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.chkResumen)
        Me.Controls.Add(Me.lblIndemnizados)
        Me.Controls.Add(Me.lblTotalEnviado)
        Me.Controls.Add(Me.pbBuxis)
        Me.Controls.Add(Me.btnVer)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chkIndemnizados)
        Me.Controls.Add(Me.lblEnviando)
        Me.Controls.Add(Me.SelectAll)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dpFechaPago)
        Me.Controls.Add(Me.BtnEnviar)
        Me.Controls.Add(Me.dgvProgramaciones)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmEnviarProgramaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa – Programación Enviar a Buxis"
        CType(Me.dgvProgramaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProgramaciones As System.Windows.Forms.DataGridView
    Friend WithEvents BtnEnviar As System.Windows.Forms.Button
    Friend WithEvents dpFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkBoni As System.Windows.Forms.CheckBox
    Friend WithEvents chkAguin As System.Windows.Forms.CheckBox
    Friend WithEvents SelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents pbBuxis As System.Windows.Forms.ProgressBar
    Friend WithEvents lblEnviando As System.Windows.Forms.Label
    Friend WithEvents chkIndemnizados As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMensual As System.Windows.Forms.RadioButton
    Friend WithEvents rbQna As System.Windows.Forms.RadioButton
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnVer As System.Windows.Forms.Button
    Friend WithEvents lblTotalEnviado As System.Windows.Forms.Label
    Friend WithEvents lblIndemnizados As System.Windows.Forms.Label
    Friend WithEvents chkResumen As System.Windows.Forms.CheckBox
    Friend WithEvents bw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCodEmpleado As System.Windows.Forms.RadioButton
    Friend WithEvents rbCodDeduc As System.Windows.Forms.RadioButton
    Friend WithEvents btnCapital As System.Windows.Forms.Button
    Friend WithEvents btnCalculo As System.Windows.Forms.Button
End Class
