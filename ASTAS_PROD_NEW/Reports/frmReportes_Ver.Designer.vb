<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportes_Ver
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
        Me.Bw1 = New System.ComponentModel.BackgroundWorker
        Me.pB1 = New System.Windows.Forms.ProgressBar
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Bw2 = New System.ComponentModel.BackgroundWorker
        Me.SuspendLayout()
        '
        'Bw1
        '
        Me.Bw1.WorkerReportsProgress = True
        '
        'pB1
        '
        Me.pB1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pB1.Location = New System.Drawing.Point(0, 507)
        Me.pB1.Name = "pB1"
        Me.pB1.Size = New System.Drawing.Size(844, 23)
        Me.pB1.TabIndex = 1
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crvReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReporte.Location = New System.Drawing.Point(0, 0)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.SelectionFormula = ""
        Me.crvReporte.ShowGroupTreeButton = False
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.Size = New System.Drawing.Size(844, 507)
        Me.crvReporte.TabIndex = 83
        Me.crvReporte.ViewTimeSelectionFormula = ""
        '
        'Bw2
        '
        Me.Bw2.WorkerReportsProgress = True
        Me.Bw2.WorkerSupportsCancellation = True
        '
        'frmReportes_Ver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 530)
        Me.Controls.Add(Me.crvReporte)
        Me.Controls.Add(Me.pB1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmReportes_Ver"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents pB1 As System.Windows.Forms.ProgressBar
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Bw2 As System.ComponentModel.BackgroundWorker
End Class
