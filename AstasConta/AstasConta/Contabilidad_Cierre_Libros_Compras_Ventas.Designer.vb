<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Cierre_Libros_Compras_Ventas
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
        Me.cmbMeses = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.nudYear = New System.Windows.Forms.NumericUpDown
        Me.gbAccion = New System.Windows.Forms.GroupBox
        Me.rbRevertir = New System.Windows.Forms.RadioButton
        Me.rbCerrar = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbVentas = New System.Windows.Forms.RadioButton
        Me.rbCompras = New System.Windows.Forms.RadioButton
        Me.btnEjecutar = New System.Windows.Forms.Button
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAccion.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mes:"
        '
        'cmbMeses
        '
        Me.cmbMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMeses.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMeses.FormattingEnabled = True
        Me.cmbMeses.Location = New System.Drawing.Point(61, 18)
        Me.cmbMeses.Name = "cmbMeses"
        Me.cmbMeses.Size = New System.Drawing.Size(178, 31)
        Me.cmbMeses.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(251, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Año:"
        '
        'nudYear
        '
        Me.nudYear.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudYear.ForeColor = System.Drawing.Color.Navy
        Me.nudYear.Location = New System.Drawing.Point(300, 17)
        Me.nudYear.Maximum = New Decimal(New Integer() {2500, 0, 0, 0})
        Me.nudYear.Minimum = New Decimal(New Integer() {2014, 0, 0, 0})
        Me.nudYear.Name = "nudYear"
        Me.nudYear.Size = New System.Drawing.Size(75, 29)
        Me.nudYear.TabIndex = 3
        Me.nudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudYear.Value = New Decimal(New Integer() {2014, 0, 0, 0})
        '
        'gbAccion
        '
        Me.gbAccion.BackColor = System.Drawing.Color.Transparent
        Me.gbAccion.Controls.Add(Me.rbRevertir)
        Me.gbAccion.Controls.Add(Me.rbCerrar)
        Me.gbAccion.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAccion.ForeColor = System.Drawing.Color.Navy
        Me.gbAccion.Location = New System.Drawing.Point(61, 56)
        Me.gbAccion.Name = "gbAccion"
        Me.gbAccion.Size = New System.Drawing.Size(131, 100)
        Me.gbAccion.TabIndex = 4
        Me.gbAccion.TabStop = False
        Me.gbAccion.Text = "Acción"
        '
        'rbRevertir
        '
        Me.rbRevertir.AutoSize = True
        Me.rbRevertir.Location = New System.Drawing.Point(9, 59)
        Me.rbRevertir.Name = "rbRevertir"
        Me.rbRevertir.Size = New System.Drawing.Size(116, 24)
        Me.rbRevertir.TabIndex = 1
        Me.rbRevertir.Text = "Revertir Cierre"
        Me.rbRevertir.UseVisualStyleBackColor = True
        '
        'rbCerrar
        '
        Me.rbCerrar.AutoSize = True
        Me.rbCerrar.Checked = True
        Me.rbCerrar.Location = New System.Drawing.Point(9, 26)
        Me.rbCerrar.Name = "rbCerrar"
        Me.rbCerrar.Size = New System.Drawing.Size(94, 24)
        Me.rbCerrar.TabIndex = 0
        Me.rbCerrar.TabStop = True
        Me.rbCerrar.Text = "Cerrar Mes"
        Me.rbCerrar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.rbVentas)
        Me.GroupBox2.Controls.Add(Me.rbCompras)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(213, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(131, 100)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Libro"
        '
        'rbVentas
        '
        Me.rbVentas.AutoSize = True
        Me.rbVentas.Location = New System.Drawing.Point(9, 59)
        Me.rbVentas.Name = "rbVentas"
        Me.rbVentas.Size = New System.Drawing.Size(89, 24)
        Me.rbVentas.TabIndex = 1
        Me.rbVentas.Text = "De Ventas"
        Me.rbVentas.UseVisualStyleBackColor = True
        '
        'rbCompras
        '
        Me.rbCompras.AutoSize = True
        Me.rbCompras.Checked = True
        Me.rbCompras.Location = New System.Drawing.Point(9, 26)
        Me.rbCompras.Name = "rbCompras"
        Me.rbCompras.Size = New System.Drawing.Size(103, 24)
        Me.rbCompras.TabIndex = 0
        Me.rbCompras.TabStop = True
        Me.rbCompras.Text = "De Compras"
        Me.rbCompras.UseVisualStyleBackColor = True
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.Color.LightCyan
        Me.btnEjecutar.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ForeColor = System.Drawing.Color.Navy
        Me.btnEjecutar.Location = New System.Drawing.Point(61, 163)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(283, 69)
        Me.btnEjecutar.TabIndex = 6
        Me.btnEjecutar.Text = "Ejecutar"
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'Contabilidad_Cierre_Libros_Compras_Ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 248)
        Me.Controls.Add(Me.btnEjecutar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gbAccion)
        Me.Controls.Add(Me.nudYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbMeses)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Cierre_Libros_Compras_Ventas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Cierre Libros de Compras y Ventas"
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAccion.ResumeLayout(False)
        Me.gbAccion.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMeses As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents gbAccion As System.Windows.Forms.GroupBox
    Friend WithEvents rbRevertir As System.Windows.Forms.RadioButton
    Friend WithEvents rbCerrar As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbVentas As System.Windows.Forms.RadioButton
    Friend WithEvents rbCompras As System.Windows.Forms.RadioButton
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
End Class
