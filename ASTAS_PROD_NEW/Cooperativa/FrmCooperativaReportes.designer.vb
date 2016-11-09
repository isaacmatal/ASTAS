<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCooperativaReportes
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
        Me.CrvCooReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'CrvCooReporte
        '
        Me.CrvCooReporte.ActiveViewIndex = -1
        Me.CrvCooReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CrvCooReporte.DisplayGroupTree = False
        Me.CrvCooReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrvCooReporte.Location = New System.Drawing.Point(0, 0)
        Me.CrvCooReporte.Name = "CrvCooReporte"
        Me.CrvCooReporte.SelectionFormula = ""
        Me.CrvCooReporte.ShowRefreshButton = False
        Me.CrvCooReporte.Size = New System.Drawing.Size(747, 503)
        Me.CrvCooReporte.TabIndex = 1
        Me.CrvCooReporte.ViewTimeSelectionFormula = ""
        '
        'FrmCooperativaReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 503)
        Me.Controls.Add(Me.CrvCooReporte)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmCooperativaReportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Reportes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrvCooReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
