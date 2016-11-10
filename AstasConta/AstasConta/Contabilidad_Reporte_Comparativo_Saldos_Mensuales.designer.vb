<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reporte_Comparativo_Saldos_Mensuales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbMeses = New System.Windows.Forms.ComboBox
        Me.nudYear = New System.Windows.Forms.NumericUpDown
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.chkGober = New System.Windows.Forms.CheckBox
        Me.Contabilidad_Reporte_Comparativo_Saldos_Mensuales_rpt1 = New AstasConta.Contabilidad_Reporte_Comparativo_Saldos_Mensuales_rpt
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Location = New System.Drawing.Point(3, 33)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.ShowCloseButton = False
        Me.crvReporte.ShowGroupTreeButton = False
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.Size = New System.Drawing.Size(848, 446)
        Me.crvReporte.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Periodo Final:"
        '
        'cmbMeses
        '
        Me.cmbMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMeses.ForeColor = System.Drawing.Color.Navy
        Me.cmbMeses.FormattingEnabled = True
        Me.cmbMeses.Location = New System.Drawing.Point(95, 6)
        Me.cmbMeses.Name = "cmbMeses"
        Me.cmbMeses.Size = New System.Drawing.Size(134, 24)
        Me.cmbMeses.TabIndex = 2
        '
        'nudYear
        '
        Me.nudYear.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudYear.ForeColor = System.Drawing.Color.Navy
        Me.nudYear.Location = New System.Drawing.Point(232, 7)
        Me.nudYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.nudYear.Minimum = New Decimal(New Integer() {2014, 0, 0, 0})
        Me.nudYear.Name = "nudYear"
        Me.nudYear.Size = New System.Drawing.Size(60, 22)
        Me.nudYear.TabIndex = 3
        Me.nudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudYear.Value = New Decimal(New Integer() {2014, 0, 0, 0})
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = Global.AstasConta.My.Resources.Resources.exec
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(298, 7)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'chkGober
        '
        Me.chkGober.AutoSize = True
        Me.chkGober.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGober.ForeColor = System.Drawing.Color.Navy
        Me.chkGober.Location = New System.Drawing.Point(389, 9)
        Me.chkGober.Name = "chkGober"
        Me.chkGober.Size = New System.Drawing.Size(146, 20)
        Me.chkGober.TabIndex = 5
        Me.chkGober.Text = "Catálogo Gobernación"
        Me.chkGober.UseVisualStyleBackColor = True
        Me.chkGober.Visible = False
        '
        'Contabilidad_Reporte_Comparativo_Saldos_Mensuales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 482)
        Me.Controls.Add(Me.chkGober)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.nudYear)
        Me.Controls.Add(Me.cmbMeses)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.crvReporte)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Reporte_Comparativo_Saldos_Mensuales"
        Me.Text = "Contabilidad - Reporte Comparativo Saldos Mensuales"
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMeses As System.Windows.Forms.ComboBox
    Friend WithEvents nudYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents chkGober As System.Windows.Forms.CheckBox
    Friend WithEvents Contabilidad_Reporte_Comparativo_Saldos_Mensuales_rpt1 As AstasConta.Contabilidad_Reporte_Comparativo_Saldos_Mensuales_rpt
End Class
