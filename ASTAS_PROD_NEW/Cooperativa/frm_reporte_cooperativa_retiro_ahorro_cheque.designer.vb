<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_cooperativa_retiro_ahorro_cheque
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
        Me.Banco = New System.Windows.Forms.Label
        Me.CtaBanco = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
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
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(601, 434)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'lblBuxis
        '
        Me.lblBuxis.AutoSize = True
        Me.lblBuxis.Location = New System.Drawing.Point(301, 9)
        Me.lblBuxis.Name = "lblBuxis"
        Me.lblBuxis.Size = New System.Drawing.Size(13, 13)
        Me.lblBuxis.TabIndex = 1
        Me.lblBuxis.Text = "0"
        Me.lblBuxis.Visible = False
        '
        'lblSocio
        '
        Me.lblSocio.AutoSize = True
        Me.lblSocio.Location = New System.Drawing.Point(358, 9)
        Me.lblSocio.Name = "lblSocio"
        Me.lblSocio.Size = New System.Drawing.Size(41, 13)
        Me.lblSocio.TabIndex = 2
        Me.lblSocio.Text = "#Socio"
        Me.lblSocio.Visible = False
        '
        'lblRetiro
        '
        Me.lblRetiro.AutoSize = True
        Me.lblRetiro.Location = New System.Drawing.Point(413, 9)
        Me.lblRetiro.Name = "lblRetiro"
        Me.lblRetiro.Size = New System.Drawing.Size(13, 13)
        Me.lblRetiro.TabIndex = 3
        Me.lblRetiro.Text = "0"
        Me.lblRetiro.Visible = False
        '
        'Banco
        '
        Me.Banco.AutoSize = True
        Me.Banco.Location = New System.Drawing.Point(472, 9)
        Me.Banco.Name = "Banco"
        Me.Banco.Size = New System.Drawing.Size(13, 13)
        Me.Banco.TabIndex = 4
        Me.Banco.Text = "0"
        Me.Banco.Visible = False
        '
        'CtaBanco
        '
        Me.CtaBanco.AutoSize = True
        Me.CtaBanco.Location = New System.Drawing.Point(528, 9)
        Me.CtaBanco.Name = "CtaBanco"
        Me.CtaBanco.Size = New System.Drawing.Size(13, 13)
        Me.CtaBanco.TabIndex = 5
        Me.CtaBanco.Text = "0"
        Me.CtaBanco.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(432, 7)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(113, 17)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "NO NEGOCIABLE"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frm_reporte_cooperativa_retiro_ahorro_cheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 434)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.CtaBanco)
        Me.Controls.Add(Me.Banco)
        Me.Controls.Add(Me.lblRetiro)
        Me.Controls.Add(Me.lblSocio)
        Me.Controls.Add(Me.lblBuxis)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frm_reporte_cooperativa_retiro_ahorro_cheque"
        Me.Text = "Reporte cooperativa retiro ahorro cheque"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lblBuxis As System.Windows.Forms.Label
    Friend WithEvents lblSocio As System.Windows.Forms.Label
    Friend WithEvents lblRetiro As System.Windows.Forms.Label
    Friend WithEvents Banco As System.Windows.Forms.Label
    Friend WithEvents CtaBanco As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
