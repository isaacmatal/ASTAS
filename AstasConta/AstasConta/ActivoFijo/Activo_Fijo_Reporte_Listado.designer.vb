<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Activo_Fijo_Reporte_Listado
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
        Me.btnPrint = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radAlta = New System.Windows.Forms.RadioButton
        Me.radBaja = New System.Windows.Forms.RadioButton
        Me.radAmbos = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(416, 203)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 47)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Imprimir"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radAmbos)
        Me.GroupBox1.Controls.Add(Me.radBaja)
        Me.GroupBox1.Controls.Add(Me.radAlta)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(261, 53)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de Movimiento"
        '
        'radAlta
        '
        Me.radAlta.AutoSize = True
        Me.radAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radAlta.Location = New System.Drawing.Point(113, 19)
        Me.radAlta.Name = "radAlta"
        Me.radAlta.Size = New System.Drawing.Size(54, 21)
        Me.radAlta.TabIndex = 0
        Me.radAlta.Text = "Alta"
        Me.radAlta.UseVisualStyleBackColor = True
        '
        'radBaja
        '
        Me.radBaja.AutoSize = True
        Me.radBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radBaja.Location = New System.Drawing.Point(186, 19)
        Me.radBaja.Name = "radBaja"
        Me.radBaja.Size = New System.Drawing.Size(58, 21)
        Me.radBaja.TabIndex = 1
        Me.radBaja.Text = "Baja"
        Me.radBaja.UseVisualStyleBackColor = True
        '
        'radAmbos
        '
        Me.radAmbos.AutoSize = True
        Me.radAmbos.Checked = True
        Me.radAmbos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radAmbos.Location = New System.Drawing.Point(21, 19)
        Me.radAmbos.Name = "radAmbos"
        Me.radAmbos.Size = New System.Drawing.Size(74, 21)
        Me.radAmbos.TabIndex = 2
        Me.radAmbos.TabStop = True
        Me.radAmbos.Text = "Ambas"
        Me.radAmbos.UseVisualStyleBackColor = True
        '
        'Activo_Fijo_Reporte_Listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 262)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPrint)
        Me.Name = "Activo_Fijo_Reporte_Listado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activo Fijo -Listado de Bienes "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radBaja As System.Windows.Forms.RadioButton
    Friend WithEvents radAlta As System.Windows.Forms.RadioButton
    Friend WithEvents radAmbos As System.Windows.Forms.RadioButton
End Class
