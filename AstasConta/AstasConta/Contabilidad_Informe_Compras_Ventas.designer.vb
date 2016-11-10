<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Informe_Compras_Ventas
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Fecha_Fin = New System.Windows.Forms.DateTimePicker
        Me.fecha_Ini = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.RdbPinscrito = New System.Windows.Forms.RadioButton
        Me.RdbExcluido = New System.Windows.Forms.RadioButton
        Me.Rdbclientesmenor = New System.Windows.Forms.RadioButton
        Me.Rdbclientesmayor = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Rdbexentos = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RdbRetencion = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Fecha_Fin)
        Me.GroupBox1.Controls.Add(Me.fecha_Ini)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(451, 80)
        Me.GroupBox1.TabIndex = 104
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FECHAS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(251, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Hasta :"
        '
        'Fecha_Fin
        '
        Me.Fecha_Fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha_Fin.Location = New System.Drawing.Point(301, 37)
        Me.Fecha_Fin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Fecha_Fin.Name = "Fecha_Fin"
        Me.Fecha_Fin.Size = New System.Drawing.Size(112, 22)
        Me.Fecha_Fin.TabIndex = 3
        '
        'fecha_Ini
        '
        Me.fecha_Ini.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha_Ini.CalendarForeColor = System.Drawing.Color.Navy
        Me.fecha_Ini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_Ini.Location = New System.Drawing.Point(118, 37)
        Me.fecha_Ini.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.fecha_Ini.Name = "fecha_Ini"
        Me.fecha_Ini.Size = New System.Drawing.Size(112, 22)
        Me.fecha_Ini.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(22, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 16)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Período Desde :"
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImprimir.Image = Global.AstasConta.My.Resources.Resources.exec
        Me.btnImprimir.Location = New System.Drawing.Point(313, 225)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(70, 74)
        Me.btnImprimir.TabIndex = 5
        Me.btnImprimir.Text = "GENERAR"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(80, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(286, 20)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "INFORMES COMPRAS Y VENTAS"
        '
        'RdbPinscrito
        '
        Me.RdbPinscrito.AutoSize = True
        Me.RdbPinscrito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbPinscrito.Location = New System.Drawing.Point(6, 23)
        Me.RdbPinscrito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RdbPinscrito.Name = "RdbPinscrito"
        Me.RdbPinscrito.Size = New System.Drawing.Size(171, 17)
        Me.RdbPinscrito.TabIndex = 106
        Me.RdbPinscrito.TabStop = True
        Me.RdbPinscrito.Text = "Proveedor Inscrito en IVA"
        Me.RdbPinscrito.UseVisualStyleBackColor = True
        '
        'RdbExcluido
        '
        Me.RdbExcluido.AutoSize = True
        Me.RdbExcluido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbExcluido.Location = New System.Drawing.Point(6, 52)
        Me.RdbExcluido.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RdbExcluido.Name = "RdbExcluido"
        Me.RdbExcluido.Size = New System.Drawing.Size(177, 17)
        Me.RdbExcluido.TabIndex = 107
        Me.RdbExcluido.TabStop = True
        Me.RdbExcluido.Text = "Proveedor Excluido en IVA"
        Me.RdbExcluido.UseVisualStyleBackColor = True
        '
        'Rdbclientesmenor
        '
        Me.Rdbclientesmenor.AutoSize = True
        Me.Rdbclientesmenor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdbclientesmenor.Location = New System.Drawing.Point(6, 80)
        Me.Rdbclientesmenor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rdbclientesmenor.Name = "Rdbclientesmenor"
        Me.Rdbclientesmenor.Size = New System.Drawing.Size(192, 17)
        Me.Rdbclientesmenor.TabIndex = 108
        Me.Rdbclientesmenor.TabStop = True
        Me.Rdbclientesmenor.Text = "Clientes (Facturas < $200.00)"
        Me.Rdbclientesmenor.UseVisualStyleBackColor = True
        '
        'Rdbclientesmayor
        '
        Me.Rdbclientesmayor.AutoSize = True
        Me.Rdbclientesmayor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdbclientesmayor.Location = New System.Drawing.Point(6, 108)
        Me.Rdbclientesmayor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rdbclientesmayor.Name = "Rdbclientesmayor"
        Me.Rdbclientesmayor.Size = New System.Drawing.Size(199, 17)
        Me.Rdbclientesmayor.TabIndex = 109
        Me.Rdbclientesmayor.TabStop = True
        Me.Rdbclientesmayor.Text = "Clientes (Facturas >= $200.00)"
        Me.Rdbclientesmayor.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Rdbexentos)
        Me.GroupBox2.Controls.Add(Me.RdbPinscrito)
        Me.GroupBox2.Controls.Add(Me.Rdbclientesmayor)
        Me.GroupBox2.Controls.Add(Me.RdbExcluido)
        Me.GroupBox2.Controls.Add(Me.Rdbclientesmenor)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(12, 141)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(215, 163)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informes Compras y Ventas"
        '
        'Rdbexentos
        '
        Me.Rdbexentos.AutoSize = True
        Me.Rdbexentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdbexentos.Location = New System.Drawing.Point(6, 137)
        Me.Rdbexentos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Rdbexentos.Name = "Rdbexentos"
        Me.Rdbexentos.Size = New System.Drawing.Size(70, 17)
        Me.Rdbexentos.TabIndex = 110
        Me.Rdbexentos.TabStop = True
        Me.Rdbexentos.Text = "Exentos"
        Me.Rdbexentos.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RdbRetencion)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox3.Location = New System.Drawing.Point(253, 141)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(200, 73)
        Me.GroupBox3.TabIndex = 111
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Percepción"
        '
        'RdbRetencion
        '
        Me.RdbRetencion.AutoSize = True
        Me.RdbRetencion.Checked = True
        Me.RdbRetencion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdbRetencion.Location = New System.Drawing.Point(23, 30)
        Me.RdbRetencion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RdbRetencion.Name = "RdbRetencion"
        Me.RdbRetencion.Size = New System.Drawing.Size(161, 17)
        Me.RdbRetencion.TabIndex = 110
        Me.RdbRetencion.TabStop = True
        Me.RdbRetencion.Text = "Percepción y Retención"
        Me.RdbRetencion.UseVisualStyleBackColor = True
        '
        'Contabilidad_Informe_Compras_Ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 314)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnImprimir)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Informe_Compras_Ventas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Informes Compras y Ventas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Fecha_Fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha_Ini As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RdbPinscrito As System.Windows.Forms.RadioButton
    Friend WithEvents RdbExcluido As System.Windows.Forms.RadioButton
    Friend WithEvents Rdbclientesmenor As System.Windows.Forms.RadioButton
    Friend WithEvents Rdbclientesmayor As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RdbRetencion As System.Windows.Forms.RadioButton
    Friend WithEvents Rdbexentos As System.Windows.Forms.RadioButton
End Class
