<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Catalogo_Cajas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Catalogo_Cajas))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.gbAperturaCaja = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Print_Fiscal = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Descripcion_3 = New System.Windows.Forms.TextBox
        Me.Descripcion_2 = New System.Windows.Forms.TextBox
        Me.codigoCaja = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.Descripcion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.numeroCaja = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblDineroInicial = New System.Windows.Forms.Label
        Me.cbCafeteria = New System.Windows.Forms.ComboBox
        Me.lblCafeteria = New System.Windows.Forms.Label
        Me.gridCajas = New System.Windows.Forms.DataGridView
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAperturaCaja.SuspendLayout()
        CType(Me.gridCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(6, 19)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(161, 188)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 81
        Me.pbImagen.TabStop = False
        '
        'gbAperturaCaja
        '
        Me.gbAperturaCaja.Controls.Add(Me.Label5)
        Me.gbAperturaCaja.Controls.Add(Me.pbImagen)
        Me.gbAperturaCaja.Controls.Add(Me.Print_Fiscal)
        Me.gbAperturaCaja.Controls.Add(Me.Label4)
        Me.gbAperturaCaja.Controls.Add(Me.Descripcion_3)
        Me.gbAperturaCaja.Controls.Add(Me.Descripcion_2)
        Me.gbAperturaCaja.Controls.Add(Me.codigoCaja)
        Me.gbAperturaCaja.Controls.Add(Me.Label3)
        Me.gbAperturaCaja.Controls.Add(Me.btnLimpiar)
        Me.gbAperturaCaja.Controls.Add(Me.btnGuardar)
        Me.gbAperturaCaja.Controls.Add(Me.btnEliminar)
        Me.gbAperturaCaja.Controls.Add(Me.Descripcion)
        Me.gbAperturaCaja.Controls.Add(Me.Label2)
        Me.gbAperturaCaja.Controls.Add(Me.txtCompañia)
        Me.gbAperturaCaja.Controls.Add(Me.numeroCaja)
        Me.gbAperturaCaja.Controls.Add(Me.Label1)
        Me.gbAperturaCaja.Controls.Add(Me.lblDineroInicial)
        Me.gbAperturaCaja.Controls.Add(Me.cbCafeteria)
        Me.gbAperturaCaja.Controls.Add(Me.lblCafeteria)
        Me.gbAperturaCaja.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbAperturaCaja.Location = New System.Drawing.Point(0, 0)
        Me.gbAperturaCaja.Name = "gbAperturaCaja"
        Me.gbAperturaCaja.Size = New System.Drawing.Size(869, 213)
        Me.gbAperturaCaja.TabIndex = 80
        Me.gbAperturaCaja.TabStop = False
        Me.gbAperturaCaja.Text = "Detalles de Caja"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(187, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 16)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Descripcion:"
        '
        'Print_Fiscal
        '
        Me.Print_Fiscal.AutoSize = True
        Me.Print_Fiscal.Location = New System.Drawing.Point(479, 98)
        Me.Print_Fiscal.Name = "Print_Fiscal"
        Me.Print_Fiscal.Size = New System.Drawing.Size(96, 17)
        Me.Print_Fiscal.TabIndex = 135
        Me.Print_Fiscal.Text = "Impresor Fiscal"
        Me.Print_Fiscal.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(290, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(363, 22)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
        '
        'Descripcion_3
        '
        Me.Descripcion_3.BackColor = System.Drawing.Color.White
        Me.Descripcion_3.Location = New System.Drawing.Point(294, 164)
        Me.Descripcion_3.Name = "Descripcion_3"
        Me.Descripcion_3.Size = New System.Drawing.Size(376, 20)
        Me.Descripcion_3.TabIndex = 6
        '
        'Descripcion_2
        '
        Me.Descripcion_2.BackColor = System.Drawing.Color.White
        Me.Descripcion_2.Location = New System.Drawing.Point(294, 141)
        Me.Descripcion_2.Name = "Descripcion_2"
        Me.Descripcion_2.Size = New System.Drawing.Size(376, 20)
        Me.Descripcion_2.TabIndex = 5
        '
        'codigoCaja
        '
        Me.codigoCaja.Location = New System.Drawing.Point(294, 95)
        Me.codigoCaja.Name = "codigoCaja"
        Me.codigoCaja.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.codigoCaja.Size = New System.Drawing.Size(179, 20)
        Me.codigoCaja.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(187, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Contraseña de Caja:"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(401, 69)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(24, 24)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(425, 69)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(449, 69)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(24, 24)
        Me.btnEliminar.TabIndex = 8
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Descripcion
        '
        Me.Descripcion.BackColor = System.Drawing.Color.White
        Me.Descripcion.Location = New System.Drawing.Point(294, 118)
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Size = New System.Drawing.Size(376, 20)
        Me.Descripcion.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(187, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Dirección:"
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(294, 16)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(376, 20)
        Me.txtCompañia.TabIndex = 87
        Me.txtCompañia.Visible = False
        '
        'numeroCaja
        '
        Me.numeroCaja.Location = New System.Drawing.Point(294, 69)
        Me.numeroCaja.Name = "numeroCaja"
        Me.numeroCaja.Size = New System.Drawing.Size(101, 20)
        Me.numeroCaja.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(187, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Compañía"
        Me.Label1.Visible = False
        '
        'lblDineroInicial
        '
        Me.lblDineroInicial.AutoSize = True
        Me.lblDineroInicial.Location = New System.Drawing.Point(187, 72)
        Me.lblDineroInicial.Name = "lblDineroInicial"
        Me.lblDineroInicial.Size = New System.Drawing.Size(86, 13)
        Me.lblDineroInicial.TabIndex = 16
        Me.lblDineroInicial.Text = "Numero de Caja:"
        '
        'cbCafeteria
        '
        Me.cbCafeteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCafeteria.FormattingEnabled = True
        Me.cbCafeteria.Location = New System.Drawing.Point(294, 42)
        Me.cbCafeteria.Name = "cbCafeteria"
        Me.cbCafeteria.Size = New System.Drawing.Size(376, 21)
        Me.cbCafeteria.TabIndex = 1
        '
        'lblCafeteria
        '
        Me.lblCafeteria.AutoSize = True
        Me.lblCafeteria.Location = New System.Drawing.Point(187, 45)
        Me.lblCafeteria.Name = "lblCafeteria"
        Me.lblCafeteria.Size = New System.Drawing.Size(57, 13)
        Me.lblCafeteria.TabIndex = 0
        Me.lblCafeteria.Text = "Cafetería :"
        '
        'gridCajas
        '
        Me.gridCajas.AllowUserToAddRows = False
        Me.gridCajas.BackgroundColor = System.Drawing.Color.White
        Me.gridCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCajas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridCajas.Location = New System.Drawing.Point(0, 213)
        Me.gridCajas.Name = "gridCajas"
        Me.gridCajas.ReadOnly = True
        Me.gridCajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridCajas.Size = New System.Drawing.Size(869, 215)
        Me.gridCajas.TabIndex = 82
        '
        'Cafeteria_Catalogo_Cajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(869, 428)
        Me.Controls.Add(Me.gridCajas)
        Me.Controls.Add(Me.gbAperturaCaja)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Cafeteria_Catalogo_Cajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria_Catalogo_Cajas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAperturaCaja.ResumeLayout(False)
        Me.gbAperturaCaja.PerformLayout()
        CType(Me.gridCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents gbAperturaCaja As System.Windows.Forms.GroupBox
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents numeroCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDineroInicial As System.Windows.Forms.Label
    Friend WithEvents cbCafeteria As System.Windows.Forms.ComboBox
    Friend WithEvents lblCafeteria As System.Windows.Forms.Label
    Friend WithEvents Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gridCajas As System.Windows.Forms.DataGridView
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents codigoCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Descripcion_3 As System.Windows.Forms.TextBox
    Friend WithEvents Descripcion_2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Print_Fiscal As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
