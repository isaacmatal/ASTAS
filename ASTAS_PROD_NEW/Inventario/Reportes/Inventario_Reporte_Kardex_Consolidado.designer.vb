<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Reporte_Kardex_Consolidado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Reporte_Kardex_Consolidado))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBuscarProducto2 = New System.Windows.Forms.Button
        Me.btnBuscarProducto1 = New System.Windows.Forms.Button
        Me.txtMedida1 = New System.Windows.Forms.TextBox
        Me.txtProducto2 = New System.Windows.Forms.TextBox
        Me.txtDESCRIPCION2 = New System.Windows.Forms.TextBox
        Me.txtDESCRIPCION1 = New System.Windows.Forms.TextBox
        Me.txtMedida2 = New System.Windows.Forms.TextBox
        Me.txtProducto1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.txtFecha = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(653, 23)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(158, 169)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 104
        Me.pbImagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscarProducto2)
        Me.GroupBox1.Controls.Add(Me.btnBuscarProducto1)
        Me.GroupBox1.Controls.Add(Me.txtMedida1)
        Me.GroupBox1.Controls.Add(Me.txtProducto2)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION2)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION1)
        Me.GroupBox1.Controls.Add(Me.txtMedida2)
        Me.GroupBox1.Controls.Add(Me.txtProducto1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCompañia)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(638, 175)
        Me.GroupBox1.TabIndex = 103
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles Kardex Consolidado"
        '
        'btnBuscarProducto2
        '
        Me.btnBuscarProducto2.Image = CType(resources.GetObject("btnBuscarProducto2.Image"), System.Drawing.Image)
        Me.btnBuscarProducto2.Location = New System.Drawing.Point(149, 110)
        Me.btnBuscarProducto2.Name = "btnBuscarProducto2"
        Me.btnBuscarProducto2.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto2.TabIndex = 5
        Me.btnBuscarProducto2.UseVisualStyleBackColor = True
        '
        'btnBuscarProducto1
        '
        Me.btnBuscarProducto1.Image = CType(resources.GetObject("btnBuscarProducto1.Image"), System.Drawing.Image)
        Me.btnBuscarProducto1.Location = New System.Drawing.Point(149, 83)
        Me.btnBuscarProducto1.Name = "btnBuscarProducto1"
        Me.btnBuscarProducto1.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto1.TabIndex = 2
        Me.btnBuscarProducto1.UseVisualStyleBackColor = True
        '
        'txtMedida1
        '
        Me.txtMedida1.BackColor = System.Drawing.SystemColors.Control
        Me.txtMedida1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMedida1.ForeColor = System.Drawing.Color.Navy
        Me.txtMedida1.Location = New System.Drawing.Point(497, 84)
        Me.txtMedida1.Name = "txtMedida1"
        Me.txtMedida1.ReadOnly = True
        Me.txtMedida1.Size = New System.Drawing.Size(117, 22)
        Me.txtMedida1.TabIndex = 134
        '
        'txtProducto2
        '
        Me.txtProducto2.BackColor = System.Drawing.Color.White
        Me.txtProducto2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto2.ForeColor = System.Drawing.Color.Navy
        Me.txtProducto2.Location = New System.Drawing.Point(84, 110)
        Me.txtProducto2.Name = "txtProducto2"
        Me.txtProducto2.Size = New System.Drawing.Size(63, 22)
        Me.txtProducto2.TabIndex = 4
        '
        'txtDESCRIPCION2
        '
        Me.txtDESCRIPCION2.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION2.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION2.Location = New System.Drawing.Point(176, 110)
        Me.txtDESCRIPCION2.MaxLength = 100
        Me.txtDESCRIPCION2.Name = "txtDESCRIPCION2"
        Me.txtDESCRIPCION2.ReadOnly = True
        Me.txtDESCRIPCION2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION2.Size = New System.Drawing.Size(316, 22)
        Me.txtDESCRIPCION2.TabIndex = 6
        '
        'txtDESCRIPCION1
        '
        Me.txtDESCRIPCION1.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION1.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION1.Location = New System.Drawing.Point(176, 84)
        Me.txtDESCRIPCION1.MaxLength = 100
        Me.txtDESCRIPCION1.Name = "txtDESCRIPCION1"
        Me.txtDESCRIPCION1.ReadOnly = True
        Me.txtDESCRIPCION1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION1.Size = New System.Drawing.Size(316, 22)
        Me.txtDESCRIPCION1.TabIndex = 3
        '
        'txtMedida2
        '
        Me.txtMedida2.BackColor = System.Drawing.SystemColors.Control
        Me.txtMedida2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMedida2.ForeColor = System.Drawing.Color.Navy
        Me.txtMedida2.Location = New System.Drawing.Point(497, 110)
        Me.txtMedida2.Name = "txtMedida2"
        Me.txtMedida2.ReadOnly = True
        Me.txtMedida2.Size = New System.Drawing.Size(117, 22)
        Me.txtMedida2.TabIndex = 137
        '
        'txtProducto1
        '
        Me.txtProducto1.BackColor = System.Drawing.Color.White
        Me.txtProducto1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto1.ForeColor = System.Drawing.Color.Navy
        Me.txtProducto1.Location = New System.Drawing.Point(84, 84)
        Me.txtProducto1.Name = "txtProducto1"
        Me.txtProducto1.Size = New System.Drawing.Size(63, 22)
        Me.txtProducto1.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(7, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Código Inicial:"
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(84, 21)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(431, 22)
        Me.txtCompañia.TabIndex = 97
        '
        'txtFecha
        '
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecha.Location = New System.Drawing.Point(84, 143)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(112, 22)
        Me.txtFecha.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "A que Fecha :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(6, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Código Inicial:"
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(552, 19)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 60)
        Me.btnNuevo.TabIndex = 8
        Me.btnNuevo.Text = "&Imprimir"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(84, 49)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(432, 24)
        Me.cmbBODEGA.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Bodega :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Compañía :"
        '
        'Inventario_Reporte_Kardex_Consolidado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 208)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Inventario_Reporte_Kardex_Consolidado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario_Reporte_Kardex_Consolidado"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProducto2 As System.Windows.Forms.Button
    Friend WithEvents btnBuscarProducto1 As System.Windows.Forms.Button
    Friend WithEvents txtMedida1 As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDESCRIPCION2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDESCRIPCION1 As System.Windows.Forms.TextBox
    Friend WithEvents txtMedida2 As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto1 As System.Windows.Forms.TextBox
End Class
