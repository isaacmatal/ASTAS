<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_cooperativa_retiro_ahorro_recibo
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.lblBuxis = New System.Windows.Forms.Label
        Me.lblSocio = New System.Windows.Forms.Label
        Me.lblRetiro = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(511, 471)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'lblBuxis
        '
        Me.lblBuxis.AutoSize = True
        Me.lblBuxis.Location = New System.Drawing.Point(358, 9)
        Me.lblBuxis.Name = "lblBuxis"
        Me.lblBuxis.Size = New System.Drawing.Size(0, 13)
        Me.lblBuxis.TabIndex = 1
        '
        'lblSocio
        '
        Me.lblSocio.AutoSize = True
        Me.lblSocio.Location = New System.Drawing.Point(403, 9)
        Me.lblSocio.Name = "lblSocio"
        Me.lblSocio.Size = New System.Drawing.Size(0, 13)
        Me.lblSocio.TabIndex = 2
        '
        'lblRetiro
        '
        Me.lblRetiro.AutoSize = True
        Me.lblRetiro.Location = New System.Drawing.Point(448, 9)
        Me.lblRetiro.Name = "lblRetiro"
        Me.lblRetiro.Size = New System.Drawing.Size(0, 13)
        Me.lblRetiro.TabIndex = 3
        '
        'frm_reporte_cooperativa_retiro_ahorro_recibo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 471)
        Me.Controls.Add(Me.lblRetiro)
        Me.Controls.Add(Me.lblSocio)
        Me.Controls.Add(Me.lblBuxis)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "frm_reporte_cooperativa_retiro_ahorro_recibo"
        Me.Text = "Reporte Cooperativa Retiro Ahorro Recibo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lblBuxis As System.Windows.Forms.Label
    Friend WithEvents lblSocio As System.Windows.Forms.Label
    Friend WithEvents lblRetiro As System.Windows.Forms.Label
End Class
