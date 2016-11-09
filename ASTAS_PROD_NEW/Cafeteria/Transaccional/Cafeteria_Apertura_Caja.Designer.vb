<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Apertura_Caja
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Apertura_Caja))
        Me.txtDineroInicial = New System.Windows.Forms.TextBox
        Me.lblDineroInicial = New System.Windows.Forms.Label
        Me.gbAperturaCaja = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.rbCorteZZ = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFechaTrabajo = New System.Windows.Forms.DateTimePicker
        Me.cbSeleccioneCaja = New System.Windows.Forms.ComboBox
        Me.cbTiempoComida = New System.Windows.Forms.ComboBox
        Me.cbCafeteria = New System.Windows.Forms.ComboBox
        Me.lblSeleccioneCaja = New System.Windows.Forms.Label
        Me.lblFechaTrabajo = New System.Windows.Forms.Label
        Me.lblTiempoComida = New System.Windows.Forms.Label
        Me.lblCafeteria = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Cierre_Apertura_Grid = New System.Windows.Forms.DataGridView
        Me.Button4 = New System.Windows.Forms.Button
        Me.txtFecheo = New System.Windows.Forms.TextBox
        Me.gbAperturaCaja.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Cierre_Apertura_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDineroInicial
        '
        Me.txtDineroInicial.Location = New System.Drawing.Point(621, 82)
        Me.txtDineroInicial.Name = "txtDineroInicial"
        Me.txtDineroInicial.Size = New System.Drawing.Size(101, 20)
        Me.txtDineroInicial.TabIndex = 4
        '
        'lblDineroInicial
        '
        Me.lblDineroInicial.AutoSize = True
        Me.lblDineroInicial.Location = New System.Drawing.Point(426, 86)
        Me.lblDineroInicial.Name = "lblDineroInicial"
        Me.lblDineroInicial.Size = New System.Drawing.Size(74, 13)
        Me.lblDineroInicial.TabIndex = 16
        Me.lblDineroInicial.Text = "Dinero Inicial :"
        '
        'gbAperturaCaja
        '
        Me.gbAperturaCaja.BackColor = System.Drawing.Color.Transparent
        Me.gbAperturaCaja.Controls.Add(Me.txtFecheo)
        Me.gbAperturaCaja.Controls.Add(Me.Button4)
        Me.gbAperturaCaja.Controls.Add(Me.Label6)
        Me.gbAperturaCaja.Controls.Add(Me.Label5)
        Me.gbAperturaCaja.Controls.Add(Me.Label4)
        Me.gbAperturaCaja.Controls.Add(Me.Label3)
        Me.gbAperturaCaja.Controls.Add(Me.Label2)
        Me.gbAperturaCaja.Controls.Add(Me.pbImagen)
        Me.gbAperturaCaja.Controls.Add(Me.rbCorteZZ)
        Me.gbAperturaCaja.Controls.Add(Me.Button1)
        Me.gbAperturaCaja.Controls.Add(Me.btnGuardar)
        Me.gbAperturaCaja.Controls.Add(Me.txtCompañia)
        Me.gbAperturaCaja.Controls.Add(Me.txtDineroInicial)
        Me.gbAperturaCaja.Controls.Add(Me.Label1)
        Me.gbAperturaCaja.Controls.Add(Me.lblDineroInicial)
        Me.gbAperturaCaja.Controls.Add(Me.dtpFechaTrabajo)
        Me.gbAperturaCaja.Controls.Add(Me.cbSeleccioneCaja)
        Me.gbAperturaCaja.Controls.Add(Me.cbTiempoComida)
        Me.gbAperturaCaja.Controls.Add(Me.cbCafeteria)
        Me.gbAperturaCaja.Controls.Add(Me.lblSeleccioneCaja)
        Me.gbAperturaCaja.Controls.Add(Me.lblFechaTrabajo)
        Me.gbAperturaCaja.Controls.Add(Me.lblTiempoComida)
        Me.gbAperturaCaja.Controls.Add(Me.lblCafeteria)
        Me.gbAperturaCaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbAperturaCaja.Location = New System.Drawing.Point(3, 16)
        Me.gbAperturaCaja.Name = "gbAperturaCaja"
        Me.gbAperturaCaja.Size = New System.Drawing.Size(1034, 214)
        Me.gbAperturaCaja.TabIndex = 14
        Me.gbAperturaCaja.TabStop = False
        Me.gbAperturaCaja.Text = "Apertura de Caja"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(176, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(394, 13)
        Me.Label6.TabIndex = 137
        Me.Label6.Text = "NO HAY TIEMPO ABIERTO; POR TANTO, NO SE PUEDE CERRAR."
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(331, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 13)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "- Agoto los tiempos del dia."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(176, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 13)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "- No tiene caja asignada"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(176, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(347, 13)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Si no aparece la caja, puede ser por las siguientes razones:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(268, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(393, 22)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(9, 16)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(161, 171)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 79
        Me.pbImagen.TabStop = False
        '
        'rbCorteZZ
        '
        Me.rbCorteZZ.AutoSize = True
        Me.rbCorteZZ.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbCorteZZ.Location = New System.Drawing.Point(613, 105)
        Me.rbCorteZZ.Name = "rbCorteZZ"
        Me.rbCorteZZ.Size = New System.Drawing.Size(109, 17)
        Me.rbCorteZZ.TabIndex = 5
        Me.rbCorteZZ.Text = "Realizar Corte ZZ"
        Me.ToolTip1.SetToolTip(Me.rbCorteZZ, "Permite realizar el Corte ZZ antes de ser el último día del mes")
        Me.rbCorteZZ.UseVisualStyleBackColor = True
        Me.rbCorteZZ.Visible = False
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(334, 107)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 46)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Cerrar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip2.SetToolTip(Me.Button1, "Cerrar Caja")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(267, 107)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(63, 46)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Abrir"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(267, 16)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(376, 20)
        Me.txtCompañia.TabIndex = 87
        Me.txtCompañia.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(176, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Compañía"
        Me.Label1.Visible = False
        '
        'dtpFechaTrabajo
        '
        Me.dtpFechaTrabajo.Enabled = False
        Me.dtpFechaTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaTrabajo.Location = New System.Drawing.Point(621, 61)
        Me.dtpFechaTrabajo.Name = "dtpFechaTrabajo"
        Me.dtpFechaTrabajo.Size = New System.Drawing.Size(101, 20)
        Me.dtpFechaTrabajo.TabIndex = 2
        '
        'cbSeleccioneCaja
        '
        Me.cbSeleccioneCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSeleccioneCaja.FormattingEnabled = True
        Me.cbSeleccioneCaja.Location = New System.Drawing.Point(267, 61)
        Me.cbSeleccioneCaja.Name = "cbSeleccioneCaja"
        Me.cbSeleccioneCaja.Size = New System.Drawing.Size(153, 21)
        Me.cbSeleccioneCaja.TabIndex = 3
        '
        'cbTiempoComida
        '
        Me.cbTiempoComida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTiempoComida.FormattingEnabled = True
        Me.cbTiempoComida.Location = New System.Drawing.Point(267, 83)
        Me.cbTiempoComida.Name = "cbTiempoComida"
        Me.cbTiempoComida.Size = New System.Drawing.Size(153, 21)
        Me.cbTiempoComida.TabIndex = 1
        '
        'cbCafeteria
        '
        Me.cbCafeteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCafeteria.FormattingEnabled = True
        Me.cbCafeteria.Location = New System.Drawing.Point(267, 39)
        Me.cbCafeteria.Name = "cbCafeteria"
        Me.cbCafeteria.Size = New System.Drawing.Size(455, 21)
        Me.cbCafeteria.TabIndex = 0
        '
        'lblSeleccioneCaja
        '
        Me.lblSeleccioneCaja.AutoSize = True
        Me.lblSeleccioneCaja.Location = New System.Drawing.Point(176, 64)
        Me.lblSeleccioneCaja.Name = "lblSeleccioneCaja"
        Me.lblSeleccioneCaja.Size = New System.Drawing.Size(31, 13)
        Me.lblSeleccioneCaja.TabIndex = 3
        Me.lblSeleccioneCaja.Text = "Caja:"
        '
        'lblFechaTrabajo
        '
        Me.lblFechaTrabajo.AutoSize = True
        Me.lblFechaTrabajo.Location = New System.Drawing.Point(426, 64)
        Me.lblFechaTrabajo.Name = "lblFechaTrabajo"
        Me.lblFechaTrabajo.Size = New System.Drawing.Size(176, 13)
        Me.lblFechaTrabajo.TabIndex = 2
        Me.lblFechaTrabajo.Text = "Fecha de Trabajo (Segun Servidor):"
        '
        'lblTiempoComida
        '
        Me.lblTiempoComida.AutoSize = True
        Me.lblTiempoComida.Location = New System.Drawing.Point(176, 86)
        Me.lblTiempoComida.Name = "lblTiempoComida"
        Me.lblTiempoComida.Size = New System.Drawing.Size(86, 13)
        Me.lblTiempoComida.TabIndex = 1
        Me.lblTiempoComida.Text = "Tiempo Comida :"
        '
        'lblCafeteria
        '
        Me.lblCafeteria.AutoSize = True
        Me.lblCafeteria.Location = New System.Drawing.Point(176, 42)
        Me.lblCafeteria.Name = "lblCafeteria"
        Me.lblCafeteria.Size = New System.Drawing.Size(57, 13)
        Me.lblCafeteria.TabIndex = 0
        Me.lblCafeteria.Text = "Cafetería :"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 200
        '
        'ToolTip2
        '
        Me.ToolTip2.AutomaticDelay = 200
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.gbAperturaCaja)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1040, 233)
        Me.GroupBox2.TabIndex = 81
        Me.GroupBox2.TabStop = False
        '
        'Cierre_Apertura_Grid
        '
        Me.Cierre_Apertura_Grid.AllowUserToAddRows = False
        Me.Cierre_Apertura_Grid.BackgroundColor = System.Drawing.Color.White
        Me.Cierre_Apertura_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Cierre_Apertura_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cierre_Apertura_Grid.Location = New System.Drawing.Point(0, 233)
        Me.Cierre_Apertura_Grid.Name = "Cierre_Apertura_Grid"
        Me.Cierre_Apertura_Grid.ReadOnly = True
        Me.Cierre_Apertura_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Cierre_Apertura_Grid.Size = New System.Drawing.Size(1040, 262)
        Me.Cierre_Apertura_Grid.TabIndex = 82
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(729, 62)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(90, 24)
        Me.Button4.TabIndex = 138
        Me.Button4.Text = "Fecheo"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtFecheo
        '
        Me.txtFecheo.Location = New System.Drawing.Point(728, 40)
        Me.txtFecheo.Name = "txtFecheo"
        Me.txtFecheo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtFecheo.Size = New System.Drawing.Size(100, 20)
        Me.txtFecheo.TabIndex = 139
        '
        'Cafeteria_Apertura_Caja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1040, 495)
        Me.Controls.Add(Me.Cierre_Apertura_Grid)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Cafeteria_Apertura_Caja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria_Apertura_Caja"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbAperturaCaja.ResumeLayout(False)
        Me.gbAperturaCaja.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Cierre_Apertura_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtDineroInicial As System.Windows.Forms.TextBox
    Friend WithEvents lblDineroInicial As System.Windows.Forms.Label
    Friend WithEvents gbAperturaCaja As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaTrabajo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbSeleccioneCaja As System.Windows.Forms.ComboBox
    Friend WithEvents cbTiempoComida As System.Windows.Forms.ComboBox
    Friend WithEvents cbCafeteria As System.Windows.Forms.ComboBox
    Friend WithEvents lblSeleccioneCaja As System.Windows.Forms.Label
    Friend WithEvents lblFechaTrabajo As System.Windows.Forms.Label
    Friend WithEvents lblTiempoComida As System.Windows.Forms.Label
    Friend WithEvents lblCafeteria As System.Windows.Forms.Label
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents rbCorteZZ As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Cierre_Apertura_Grid As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtFecheo As System.Windows.Forms.TextBox
End Class
