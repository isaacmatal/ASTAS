<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Reporte_Empleados_Bloqueados
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvOrigenes = New System.Windows.Forms.DataGridView
        Me.btnPrint = New System.Windows.Forms.Button
        Me.chkOrigen = New System.Windows.Forms.CheckBox
        CType(Me.dgvOrigenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "Empresas"
        '
        'dgvOrigenes
        '
        Me.dgvOrigenes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvOrigenes.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvOrigenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrigenes.Location = New System.Drawing.Point(12, 31)
        Me.dgvOrigenes.Name = "dgvOrigenes"
        Me.dgvOrigenes.Size = New System.Drawing.Size(536, 237)
        Me.dgvOrigenes.TabIndex = 127
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        Me.btnPrint.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(554, 32)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 46)
        Me.btnPrint.TabIndex = 141
        Me.btnPrint.Text = "Imprimir"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'chkOrigen
        '
        Me.chkOrigen.AutoSize = True
        Me.chkOrigen.Location = New System.Drawing.Point(409, 8)
        Me.chkOrigen.Name = "chkOrigen"
        Me.chkOrigen.Size = New System.Drawing.Size(175, 17)
        Me.chkOrigen.TabIndex = 142
        Me.chkOrigen.Text = "Seleccionar todas las empresas"
        Me.chkOrigen.UseVisualStyleBackColor = True
        '
        'Cafeteria_Reporte_Empleados_Bloqueados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 280)
        Me.Controls.Add(Me.chkOrigen)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvOrigenes)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Cafeteria_Reporte_Empleados_Bloqueados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir"
        CType(Me.dgvOrigenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvOrigenes As System.Windows.Forms.DataGridView
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkOrigen As System.Windows.Forms.CheckBox
End Class
