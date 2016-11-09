<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Reporte_Resumen_ES_Por_Periodos_Show
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
        Me.dgvResumenES = New System.Windows.Forms.DataGridView
        Me.btnExportToExcel = New System.Windows.Forms.Button
        CType(Me.dgvResumenES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvResumenES
        '
        Me.dgvResumenES.AllowUserToAddRows = False
        Me.dgvResumenES.AllowUserToDeleteRows = False
        Me.dgvResumenES.AllowUserToOrderColumns = True
        Me.dgvResumenES.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResumenES.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvResumenES.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders
        Me.dgvResumenES.GridColor = System.Drawing.Color.White
        Me.dgvResumenES.Location = New System.Drawing.Point(7, 7)
        Me.dgvResumenES.Name = "dgvResumenES"
        Me.dgvResumenES.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResumenES.Size = New System.Drawing.Size(941, 399)
        Me.dgvResumenES.TabIndex = 0
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportToExcel.Image = Global.ASTAS.My.Resources.Resources.excel16
        Me.btnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportToExcel.Location = New System.Drawing.Point(874, 415)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(74, 27)
        Me.btnExportToExcel.TabIndex = 1
        Me.btnExportToExcel.Text = "Exportar"
        Me.btnExportToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportToExcel.UseVisualStyleBackColor = True
        '
        'Inventario_Reporte_Resumen_ES_Por_Periodos_Show
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 451)
        Me.Controls.Add(Me.btnExportToExcel)
        Me.Controls.Add(Me.dgvResumenES)
        Me.Name = "Inventario_Reporte_Resumen_ES_Por_Periodos_Show"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario_Reporte_Resumen_ES_Por_Periodos_Show"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvResumenES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvResumenES As System.Windows.Forms.DataGridView
    Friend WithEvents btnExportToExcel As System.Windows.Forms.Button
End Class
