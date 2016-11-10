<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reportes_Comp_Fact_Cafeteria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Reportes_Comp_Fact_Cafeteria))
        Me.btnVerBC = New System.Windows.Forms.Button
        Me.dpFECHA_HASTA = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbAbonos = New System.Windows.Forms.RadioButton
        Me.rbCargos = New System.Windows.Forms.RadioButton
        Me.chkCafe2 = New System.Windows.Forms.CheckBox
        Me.chkDif = New System.Windows.Forms.CheckBox
        Me.cmbPeriodoPago = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dpFECHA_DESDE = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVerBC
        '
        Me.btnVerBC.Image = CType(resources.GetObject("btnVerBC.Image"), System.Drawing.Image)
        Me.btnVerBC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerBC.Location = New System.Drawing.Point(845, 12)
        Me.btnVerBC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnVerBC.Name = "btnVerBC"
        Me.btnVerBC.Size = New System.Drawing.Size(76, 34)
        Me.btnVerBC.TabIndex = 60
        Me.btnVerBC.Text = "Imprimir"
        Me.btnVerBC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerBC.UseVisualStyleBackColor = True
        '
        'dpFECHA_HASTA
        '
        Me.dpFECHA_HASTA.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_HASTA.Enabled = False
        Me.dpFECHA_HASTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_HASTA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_HASTA.Location = New System.Drawing.Point(182, 18)
        Me.dpFECHA_HASTA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFECHA_HASTA.Name = "dpFECHA_HASTA"
        Me.dpFECHA_HASTA.Size = New System.Drawing.Size(109, 22)
        Me.dpFECHA_HASTA.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(11, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 16)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Fecha de pago:"
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Location = New System.Drawing.Point(12, 56)
        Me.crvReporte.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.SelectionFormula = ""
        Me.crvReporte.Size = New System.Drawing.Size(908, 334)
        Me.crvReporte.TabIndex = 61
        Me.crvReporte.ViewTimeSelectionFormula = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rbAbonos)
        Me.GroupBox1.Controls.Add(Me.rbCargos)
        Me.GroupBox1.Controls.Add(Me.chkCafe2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(531, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(152, 46)
        Me.GroupBox1.TabIndex = 62
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Movimientos a Comparar"
        '
        'rbAbonos
        '
        Me.rbAbonos.AutoSize = True
        Me.rbAbonos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAbonos.Location = New System.Drawing.Point(81, 21)
        Me.rbAbonos.Name = "rbAbonos"
        Me.rbAbonos.Size = New System.Drawing.Size(67, 20)
        Me.rbAbonos.TabIndex = 5
        Me.rbAbonos.Text = "Abonos"
        Me.rbAbonos.UseVisualStyleBackColor = True
        '
        'rbCargos
        '
        Me.rbCargos.AutoSize = True
        Me.rbCargos.Checked = True
        Me.rbCargos.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCargos.Location = New System.Drawing.Point(12, 20)
        Me.rbCargos.Name = "rbCargos"
        Me.rbCargos.Size = New System.Drawing.Size(64, 20)
        Me.rbCargos.TabIndex = 4
        Me.rbCargos.TabStop = True
        Me.rbCargos.Text = "Cargos"
        Me.rbCargos.UseVisualStyleBackColor = True
        '
        'chkCafe2
        '
        Me.chkCafe2.AutoSize = True
        Me.chkCafe2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCafe2.Location = New System.Drawing.Point(256, 18)
        Me.chkCafe2.Name = "chkCafe2"
        Me.chkCafe2.Size = New System.Drawing.Size(85, 20)
        Me.chkCafe2.TabIndex = 3
        Me.chkCafe2.Text = "Cafetería P2"
        Me.chkCafe2.UseVisualStyleBackColor = True
        Me.chkCafe2.Visible = False
        '
        'chkDif
        '
        Me.chkDif.AutoSize = True
        Me.chkDif.BackColor = System.Drawing.Color.Transparent
        Me.chkDif.Checked = True
        Me.chkDif.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDif.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDif.ForeColor = System.Drawing.Color.Navy
        Me.chkDif.Location = New System.Drawing.Point(710, 21)
        Me.chkDif.Name = "chkDif"
        Me.chkDif.Size = New System.Drawing.Size(137, 20)
        Me.chkDif.TabIndex = 63
        Me.chkDif.Text = "Solo con Diferencias"
        Me.chkDif.UseVisualStyleBackColor = False
        '
        'cmbPeriodoPago
        '
        Me.cmbPeriodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoPago.FormattingEnabled = True
        Me.cmbPeriodoPago.Location = New System.Drawing.Point(100, 19)
        Me.cmbPeriodoPago.Name = "cmbPeriodoPago"
        Me.cmbPeriodoPago.Size = New System.Drawing.Size(121, 24)
        Me.cmbPeriodoPago.TabIndex = 64
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dpFECHA_DESDE)
        Me.GroupBox2.Controls.Add(Me.dpFECHA_HASTA)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(227, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(298, 46)
        Me.GroupBox2.TabIndex = 65
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fechas de Corte"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(153, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 16)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "AL:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 16)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "DEL:"
        '
        'dpFECHA_DESDE
        '
        Me.dpFECHA_DESDE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_DESDE.Enabled = False
        Me.dpFECHA_DESDE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_DESDE.Location = New System.Drawing.Point(38, 18)
        Me.dpFECHA_DESDE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFECHA_DESDE.Name = "dpFECHA_DESDE"
        Me.dpFECHA_DESDE.Size = New System.Drawing.Size(109, 22)
        Me.dpFECHA_DESDE.TabIndex = 2
        '
        'Contabilidad_Reportes_Comp_Fact_Cafeteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 405)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmbPeriodoPago)
        Me.Controls.Add(Me.chkDif)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.crvReporte)
        Me.Controls.Add(Me.btnVerBC)
        Me.Controls.Add(Me.Label13)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Reportes_Comp_Fact_Cafeteria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad -Comparativo Cargos-Abonos Facturación en Cafeterías"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVerBC As System.Windows.Forms.Button
    Friend WithEvents dpFECHA_HASTA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDif As System.Windows.Forms.CheckBox
    Friend WithEvents chkCafe2 As System.Windows.Forms.CheckBox
    Friend WithEvents cmbPeriodoPago As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dpFECHA_DESDE As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbCargos As System.Windows.Forms.RadioButton
    Friend WithEvents rbAbonos As System.Windows.Forms.RadioButton
End Class
