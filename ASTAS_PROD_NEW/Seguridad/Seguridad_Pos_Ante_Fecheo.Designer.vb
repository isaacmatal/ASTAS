<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguridad_Pos_Ante_Fecheo
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.lb_ventana = New System.Windows.Forms.Label
        Me.lb_usuario = New System.Windows.Forms.Label
        Me.lb_bodega = New System.Windows.Forms.Label
        Me.chk_ante = New System.Windows.Forms.CheckBox
        Me.chk_pos = New System.Windows.Forms.CheckBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(20, 224)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Solicitar Permiso"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.lb_ventana)
        Me.GroupBox1.Controls.Add(Me.lb_usuario)
        Me.GroupBox1.Controls.Add(Me.lb_bodega)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(423, 121)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Solicitud"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker1.Location = New System.Drawing.Point(20, 63)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 4
        '
        'lb_ventana
        '
        Me.lb_ventana.AutoSize = True
        Me.lb_ventana.Location = New System.Drawing.Point(17, 90)
        Me.lb_ventana.Name = "lb_ventana"
        Me.lb_ventana.Size = New System.Drawing.Size(39, 13)
        Me.lb_ventana.TabIndex = 3
        Me.lb_ventana.Text = "Label2"
        '
        'lb_usuario
        '
        Me.lb_usuario.AutoSize = True
        Me.lb_usuario.Location = New System.Drawing.Point(17, 16)
        Me.lb_usuario.Name = "lb_usuario"
        Me.lb_usuario.Size = New System.Drawing.Size(39, 13)
        Me.lb_usuario.TabIndex = 1
        Me.lb_usuario.Text = "Label2"
        '
        'lb_bodega
        '
        Me.lb_bodega.AutoSize = True
        Me.lb_bodega.Location = New System.Drawing.Point(17, 40)
        Me.lb_bodega.Name = "lb_bodega"
        Me.lb_bodega.Size = New System.Drawing.Size(39, 13)
        Me.lb_bodega.TabIndex = 0
        Me.lb_bodega.Text = "Label1"
        '
        'chk_ante
        '
        Me.chk_ante.AutoSize = True
        Me.chk_ante.BackColor = System.Drawing.Color.Transparent
        Me.chk_ante.Location = New System.Drawing.Point(20, 127)
        Me.chk_ante.Name = "chk_ante"
        Me.chk_ante.Size = New System.Drawing.Size(84, 17)
        Me.chk_ante.TabIndex = 2
        Me.chk_ante.Text = "AnteFecheo"
        Me.chk_ante.UseVisualStyleBackColor = False
        '
        'chk_pos
        '
        Me.chk_pos.AutoSize = True
        Me.chk_pos.BackColor = System.Drawing.Color.Transparent
        Me.chk_pos.Location = New System.Drawing.Point(119, 127)
        Me.chk_pos.Name = "chk_pos"
        Me.chk_pos.Size = New System.Drawing.Size(80, 17)
        Me.chk_pos.TabIndex = 3
        Me.chk_pos.Text = "PosFecheo"
        Me.chk_pos.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(20, 150)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(387, 68)
        Me.TextBox1.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.Location = New System.Drawing.Point(305, 224)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Seguridad_Pos_Ante_Fecheo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 249)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.chk_pos)
        Me.Controls.Add(Me.chk_ante)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Seguridad_Pos_Ante_Fecheo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguridad_Pos_Ante_Fecheo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lb_ventana As System.Windows.Forms.Label
    Friend WithEvents lb_usuario As System.Windows.Forms.Label
    Friend WithEvents lb_bodega As System.Windows.Forms.Label
    Friend WithEvents chk_ante As System.Windows.Forms.CheckBox
    Friend WithEvents chk_pos As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
