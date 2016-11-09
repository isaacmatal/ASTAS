<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguridad_Pos_Ante_Fecheo_Autorizacion
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lb_Item = New System.Windows.Forms.Label
        Me.txt_Codigos = New System.Windows.Forms.TextBox
        Me.lb_fecha = New System.Windows.Forms.Label
        Me.lb_bodega = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.lb_ventana = New System.Windows.Forms.Label
        Me.chk_pos = New System.Windows.Forms.CheckBox
        Me.lb_usuario = New System.Windows.Forms.Label
        Me.chk_ante = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.dgvFecheo = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvFecheo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lb_Item)
        Me.GroupBox1.Controls.Add(Me.txt_Codigos)
        Me.GroupBox1.Controls.Add(Me.lb_fecha)
        Me.GroupBox1.Controls.Add(Me.lb_bodega)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.lb_ventana)
        Me.GroupBox1.Controls.Add(Me.chk_pos)
        Me.GroupBox1.Controls.Add(Me.lb_usuario)
        Me.GroupBox1.Controls.Add(Me.chk_ante)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(837, 246)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Solicitud"
        '
        'lb_Item
        '
        Me.lb_Item.AutoSize = True
        Me.lb_Item.Location = New System.Drawing.Point(184, 16)
        Me.lb_Item.Name = "lb_Item"
        Me.lb_Item.Size = New System.Drawing.Size(27, 13)
        Me.lb_Item.TabIndex = 15
        Me.lb_Item.Text = "Item"
        '
        'txt_Codigos
        '
        Me.txt_Codigos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Codigos.ForeColor = System.Drawing.Color.Black
        Me.txt_Codigos.Location = New System.Drawing.Point(310, 111)
        Me.txt_Codigos.Multiline = True
        Me.txt_Codigos.Name = "txt_Codigos"
        Me.txt_Codigos.ReadOnly = True
        Me.txt_Codigos.Size = New System.Drawing.Size(97, 25)
        Me.txt_Codigos.TabIndex = 14
        '
        'lb_fecha
        '
        Me.lb_fecha.AutoSize = True
        Me.lb_fecha.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_fecha.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lb_fecha.Location = New System.Drawing.Point(17, 63)
        Me.lb_fecha.Name = "lb_fecha"
        Me.lb_fecha.Size = New System.Drawing.Size(41, 16)
        Me.lb_fecha.TabIndex = 13
        Me.lb_fecha.Text = "Fecha "
        '
        'lb_bodega
        '
        Me.lb_bodega.AutoSize = True
        Me.lb_bodega.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_bodega.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lb_bodega.Location = New System.Drawing.Point(17, 38)
        Me.lb_bodega.Name = "lb_bodega"
        Me.lb_bodega.Size = New System.Drawing.Size(45, 16)
        Me.lb_bodega.TabIndex = 12
        Me.lb_bodega.Text = "Bodega"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.Location = New System.Drawing.Point(128, 216)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(20, 142)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(387, 68)
        Me.TextBox1.TabIndex = 9
        '
        'lb_ventana
        '
        Me.lb_ventana.AutoSize = True
        Me.lb_ventana.Location = New System.Drawing.Point(17, 90)
        Me.lb_ventana.Name = "lb_ventana"
        Me.lb_ventana.Size = New System.Drawing.Size(47, 13)
        Me.lb_ventana.TabIndex = 3
        Me.lb_ventana.Text = "Ventana"
        '
        'chk_pos
        '
        Me.chk_pos.AutoSize = True
        Me.chk_pos.BackColor = System.Drawing.Color.Transparent
        Me.chk_pos.Enabled = False
        Me.chk_pos.Location = New System.Drawing.Point(119, 119)
        Me.chk_pos.Name = "chk_pos"
        Me.chk_pos.Size = New System.Drawing.Size(80, 17)
        Me.chk_pos.TabIndex = 8
        Me.chk_pos.Text = "PosFecheo"
        Me.chk_pos.UseVisualStyleBackColor = False
        '
        'lb_usuario
        '
        Me.lb_usuario.AutoSize = True
        Me.lb_usuario.Location = New System.Drawing.Point(17, 16)
        Me.lb_usuario.Name = "lb_usuario"
        Me.lb_usuario.Size = New System.Drawing.Size(43, 13)
        Me.lb_usuario.TabIndex = 1
        Me.lb_usuario.Text = "Usuario"
        '
        'chk_ante
        '
        Me.chk_ante.AutoSize = True
        Me.chk_ante.BackColor = System.Drawing.Color.Transparent
        Me.chk_ante.Enabled = False
        Me.chk_ante.Location = New System.Drawing.Point(20, 119)
        Me.chk_ante.Name = "chk_ante"
        Me.chk_ante.Size = New System.Drawing.Size(84, 17)
        Me.chk_ante.TabIndex = 7
        Me.chk_ante.Text = "AnteFecheo"
        Me.chk_ante.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(20, 216)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Autorizar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dgvFecheo
        '
        Me.dgvFecheo.AllowUserToAddRows = False
        Me.dgvFecheo.AllowUserToDeleteRows = False
        Me.dgvFecheo.AllowUserToResizeColumns = False
        Me.dgvFecheo.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvFecheo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFecheo.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFecheo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvFecheo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFecheo.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvFecheo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFecheo.Location = New System.Drawing.Point(0, 246)
        Me.dgvFecheo.MultiSelect = False
        Me.dgvFecheo.Name = "dgvFecheo"
        Me.dgvFecheo.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFecheo.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvFecheo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFecheo.Size = New System.Drawing.Size(837, 176)
        Me.dgvFecheo.TabIndex = 36
        '
        'Seguridad_Pos_Ante_Fecheo_Autorizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 422)
        Me.Controls.Add(Me.dgvFecheo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Seguridad_Pos_Ante_Fecheo_Autorizacion"
        Me.Text = "Seguridad_Pos_Ante_Fecheo_Autorizacion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvFecheo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lb_ventana As System.Windows.Forms.Label
    Friend WithEvents lb_usuario As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chk_pos As System.Windows.Forms.CheckBox
    Friend WithEvents chk_ante As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvFecheo As System.Windows.Forms.DataGridView
    Friend WithEvents lb_fecha As System.Windows.Forms.Label
    Friend WithEvents lb_bodega As System.Windows.Forms.Label
    Friend WithEvents txt_Codigos As System.Windows.Forms.TextBox
    Friend WithEvents lb_Item As System.Windows.Forms.Label
End Class
