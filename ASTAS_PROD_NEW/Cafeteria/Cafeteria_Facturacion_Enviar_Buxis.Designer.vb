<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Facturacion_Enviar_Buxis
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
        Me.cmbPeriodoPago = New System.Windows.Forms.ComboBox
        Me.cbSeleccioneCaja = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbCafeteria = New System.Windows.Forms.ComboBox
        Me.lblCafeteria = New System.Windows.Forms.Label
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.PB = New System.Windows.Forms.ProgressBar
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.bw1 = New System.ComponentModel.BackgroundWorker
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
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(1, 66)
        Me.CrystalReportViewer1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(947, 568)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'cmbPeriodoPago
        '
        Me.cmbPeriodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodoPago.FormattingEnabled = True
        Me.cmbPeriodoPago.Location = New System.Drawing.Point(99, 36)
        Me.cmbPeriodoPago.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbPeriodoPago.Name = "cmbPeriodoPago"
        Me.cmbPeriodoPago.Size = New System.Drawing.Size(88, 24)
        Me.cmbPeriodoPago.TabIndex = 0
        '
        'cbSeleccioneCaja
        '
        Me.cbSeleccioneCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSeleccioneCaja.FormattingEnabled = True
        Me.cbSeleccioneCaja.Location = New System.Drawing.Point(344, 7)
        Me.cbSeleccioneCaja.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbSeleccioneCaja.Name = "cbSeleccioneCaja"
        Me.cbSeleccioneCaja.Size = New System.Drawing.Size(150, 24)
        Me.cbSeleccioneCaja.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 40)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Periodos de Pago:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(310, 13)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Caja:"
        '
        'cbCafeteria
        '
        Me.cbCafeteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCafeteria.FormattingEnabled = True
        Me.cbCafeteria.Location = New System.Drawing.Point(99, 6)
        Me.cbCafeteria.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbCafeteria.Name = "cbCafeteria"
        Me.cbCafeteria.Size = New System.Drawing.Size(206, 24)
        Me.cbCafeteria.TabIndex = 1
        '
        'lblCafeteria
        '
        Me.lblCafeteria.AutoSize = True
        Me.lblCafeteria.Location = New System.Drawing.Point(2, 9)
        Me.lblCafeteria.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCafeteria.Name = "lblCafeteria"
        Me.lblCafeteria.Size = New System.Drawing.Size(56, 16)
        Me.lblCafeteria.TabIndex = 5
        Me.lblCafeteria.Text = "Cafetería :"
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(509, 6)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(98, 42)
        Me.btnGenerar.TabIndex = 3
        Me.btnGenerar.Text = "Generar Programación"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'PB
        '
        Me.PB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PB.Location = New System.Drawing.Point(611, 13)
        Me.PB.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(334, 23)
        Me.PB.Step = 1
        Me.PB.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB.TabIndex = 8
        Me.PB.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(192, 40)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(145, 20)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Todas las plantas y cajas"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'bw1
        '
        Me.bw1.WorkerReportsProgress = True
        '
        'Cafeteria_Facturacion_Enviar_Buxis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 635)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.PB)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.cbCafeteria)
        Me.Controls.Add(Me.lblCafeteria)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbSeleccioneCaja)
        Me.Controls.Add(Me.cmbPeriodoPago)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "Cafeteria_Facturacion_Enviar_Buxis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Descuentos para Buxis"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmbPeriodoPago As System.Windows.Forms.ComboBox
    Friend WithEvents cbSeleccioneCaja As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbCafeteria As System.Windows.Forms.ComboBox
    Friend WithEvents lblCafeteria As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents PB As System.Windows.Forms.ProgressBar
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents bw1 As System.ComponentModel.BackgroundWorker
End Class
