<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reportes_Comp_Facturacion_Rpt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Reportes_Comp_Facturacion_Rpt))
        Me.btnVerBC = New System.Windows.Forms.Button
        Me.dpFECHA_CONTABLE = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkCafe2 = New System.Windows.Forms.CheckBox
        Me.chkCafe1 = New System.Windows.Forms.CheckBox
        Me.chkAlm = New System.Windows.Forms.CheckBox
        Me.chkDesp = New System.Windows.Forms.CheckBox
        Me.chkDif = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVerBC
        '
        Me.btnVerBC.Image = CType(resources.GetObject("btnVerBC.Image"), System.Drawing.Image)
        Me.btnVerBC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerBC.Location = New System.Drawing.Point(646, 11)
        Me.btnVerBC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnVerBC.Name = "btnVerBC"
        Me.btnVerBC.Size = New System.Drawing.Size(76, 34)
        Me.btnVerBC.TabIndex = 60
        Me.btnVerBC.Text = "Imprimir"
        Me.btnVerBC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerBC.UseVisualStyleBackColor = True
        '
        'dpFECHA_CONTABLE
        '
        Me.dpFECHA_CONTABLE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CONTABLE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CONTABLE.Location = New System.Drawing.Point(106, 14)
        Me.dpFECHA_CONTABLE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFECHA_CONTABLE.Name = "dpFECHA_CONTABLE"
        Me.dpFECHA_CONTABLE.Size = New System.Drawing.Size(114, 22)
        Me.dpFECHA_CONTABLE.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(11, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 16)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Hasta la Fecha:"
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Location = New System.Drawing.Point(12, 50)
        Me.crvReporte.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.SelectionFormula = ""
        Me.crvReporte.Size = New System.Drawing.Size(806, 340)
        Me.crvReporte.TabIndex = 61
        Me.crvReporte.ViewTimeSelectionFormula = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkCafe2)
        Me.GroupBox1.Controls.Add(Me.chkCafe1)
        Me.GroupBox1.Controls.Add(Me.chkAlm)
        Me.GroupBox1.Controls.Add(Me.chkDesp)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(226, 1)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(245, 46)
        Me.GroupBox1.TabIndex = 62
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rubros a Comparar"
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
        'chkCafe1
        '
        Me.chkCafe1.AutoSize = True
        Me.chkCafe1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCafe1.Location = New System.Drawing.Point(165, 18)
        Me.chkCafe1.Name = "chkCafe1"
        Me.chkCafe1.Size = New System.Drawing.Size(74, 20)
        Me.chkCafe1.TabIndex = 2
        Me.chkCafe1.Text = "Cafetería"
        Me.chkCafe1.UseVisualStyleBackColor = True
        '
        'chkAlm
        '
        Me.chkAlm.AutoSize = True
        Me.chkAlm.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAlm.Location = New System.Drawing.Point(90, 18)
        Me.chkAlm.Name = "chkAlm"
        Me.chkAlm.Size = New System.Drawing.Size(71, 20)
        Me.chkAlm.TabIndex = 1
        Me.chkAlm.Text = "Almacén"
        Me.chkAlm.UseVisualStyleBackColor = True
        '
        'chkDesp
        '
        Me.chkDesp.AutoSize = True
        Me.chkDesp.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDesp.Location = New System.Drawing.Point(7, 18)
        Me.chkDesp.Name = "chkDesp"
        Me.chkDesp.Size = New System.Drawing.Size(79, 20)
        Me.chkDesp.TabIndex = 0
        Me.chkDesp.Text = "Despensa"
        Me.chkDesp.UseVisualStyleBackColor = True
        '
        'chkDif
        '
        Me.chkDif.AutoSize = True
        Me.chkDif.BackColor = System.Drawing.Color.Transparent
        Me.chkDif.Checked = True
        Me.chkDif.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDif.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDif.ForeColor = System.Drawing.Color.Navy
        Me.chkDif.Location = New System.Drawing.Point(501, 19)
        Me.chkDif.Name = "chkDif"
        Me.chkDif.Size = New System.Drawing.Size(137, 20)
        Me.chkDif.TabIndex = 63
        Me.chkDif.Text = "Solo con Diferencias"
        Me.chkDif.UseVisualStyleBackColor = False
        '
        'Contabilidad_Reportes_Comp_Facturacion_Rpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 405)
        Me.Controls.Add(Me.chkDif)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.crvReporte)
        Me.Controls.Add(Me.btnVerBC)
        Me.Controls.Add(Me.dpFECHA_CONTABLE)
        Me.Controls.Add(Me.Label13)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Reportes_Comp_Facturacion_Rpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad -Comparativo Cargos-Abonos Facturación"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVerBC As System.Windows.Forms.Button
    Friend WithEvents dpFECHA_CONTABLE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCafe1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkAlm As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesp As System.Windows.Forms.CheckBox
    Friend WithEvents chkDif As System.Windows.Forms.CheckBox
    Friend WithEvents chkCafe2 As System.Windows.Forms.CheckBox
End Class
