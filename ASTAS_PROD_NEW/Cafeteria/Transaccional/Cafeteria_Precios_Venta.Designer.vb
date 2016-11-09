<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Precios_Venta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Precios_Venta))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFecha = New System.Windows.Forms.DateTimePicker
        Me.TxtDia = New System.Windows.Forms.TextBox
        Me.cmbTiempo = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.txtDESCRIPCION1 = New System.Windows.Forms.TextBox
        Me.txtProducto = New System.Windows.Forms.TextBox
        Me.txtMedida = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DgvProductos = New System.Windows.Forms.DataGridView
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.btnGuardarCB = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtPorcentaje = New System.Windows.Forms.TextBox
        Me.btnPrecios = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.TxtDia)
        Me.GroupBox1.Controls.Add(Me.cmbTiempo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(978, 153)
        Me.GroupBox1.TabIndex = 107
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Precios de Venta"
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(570, 11)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(152, 140)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 130
        Me.pbImagen.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(121, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(393, 22)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(125, 73)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(220, 22)
        Me.txtFecha.TabIndex = 1
        '
        'TxtDia
        '
        Me.TxtDia.BackColor = System.Drawing.SystemColors.Control
        Me.TxtDia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDia.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDia.ForeColor = System.Drawing.Color.Navy
        Me.TxtDia.Location = New System.Drawing.Point(416, 80)
        Me.TxtDia.MaxLength = 100
        Me.TxtDia.Name = "TxtDia"
        Me.TxtDia.ReadOnly = True
        Me.TxtDia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtDia.Size = New System.Drawing.Size(182, 15)
        Me.TxtDia.TabIndex = 122
        Me.TxtDia.Visible = False
        '
        'cmbTiempo
        '
        Me.cmbTiempo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiempo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiempo.ForeColor = System.Drawing.Color.Navy
        Me.cmbTiempo.FormattingEnabled = True
        Me.cmbTiempo.Location = New System.Drawing.Point(125, 96)
        Me.cmbTiempo.Name = "cmbTiempo"
        Me.cmbTiempo.Size = New System.Drawing.Size(220, 24)
        Me.cmbTiempo.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(17, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "Tiempo de Comida:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(17, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 16)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Fecha:"
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(125, 48)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(439, 24)
        Me.cmbBODEGA.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(17, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "Bodega:"
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(125, 23)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(439, 24)
        Me.cmbCOMPAÑIA.TabIndex = 0
        Me.cmbCOMPAÑIA.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Compañía :"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(350, 95)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(72, 24)
        Me.BtnBuscar.TabIndex = 3
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnBuscar, "Buscar el tiempo de comida.")
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'txtDESCRIPCION1
        '
        Me.txtDESCRIPCION1.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION1.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION1.Location = New System.Drawing.Point(75, 40)
        Me.txtDESCRIPCION1.MaxLength = 100
        Me.txtDESCRIPCION1.Name = "txtDESCRIPCION1"
        Me.txtDESCRIPCION1.ReadOnly = True
        Me.txtDESCRIPCION1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION1.Size = New System.Drawing.Size(370, 22)
        Me.txtDESCRIPCION1.TabIndex = 1
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txtProducto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.ForeColor = System.Drawing.Color.Navy
        Me.txtProducto.Location = New System.Drawing.Point(8, 40)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(63, 22)
        Me.txtProducto.TabIndex = 0
        '
        'txtMedida
        '
        Me.txtMedida.BackColor = System.Drawing.SystemColors.Window
        Me.txtMedida.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMedida.ForeColor = System.Drawing.Color.Navy
        Me.txtMedida.Location = New System.Drawing.Point(449, 40)
        Me.txtMedida.Name = "txtMedida"
        Me.txtMedida.ReadOnly = True
        Me.txtMedida.Size = New System.Drawing.Size(117, 22)
        Me.txtMedida.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 22)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Menú"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DgvProductos
        '
        Me.DgvProductos.AllowUserToAddRows = False
        Me.DgvProductos.AllowUserToDeleteRows = False
        Me.DgvProductos.AllowUserToOrderColumns = True
        Me.DgvProductos.AllowUserToResizeColumns = False
        Me.DgvProductos.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvProductos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvProductos.BackgroundColor = System.Drawing.Color.White
        Me.DgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvProductos.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgvProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvProductos.Location = New System.Drawing.Point(3, 16)
        Me.DgvProductos.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.DgvProductos.MultiSelect = False
        Me.DgvProductos.Name = "DgvProductos"
        Me.DgvProductos.ReadOnly = True
        Me.DgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProductos.Size = New System.Drawing.Size(972, 224)
        Me.DgvProductos.TabIndex = 125
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.LightGray
        Me.txtCantidad.Enabled = False
        Me.txtCantidad.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.Navy
        Me.txtCantidad.Location = New System.Drawing.Point(569, 40)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(116, 22)
        Me.txtCantidad.TabIndex = 3
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnGuardarCB
        '
        Me.btnGuardarCB.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardarCB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarCB.Image = CType(resources.GetObject("btnGuardarCB.Image"), System.Drawing.Image)
        Me.btnGuardarCB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarCB.Location = New System.Drawing.Point(817, 36)
        Me.btnGuardarCB.Name = "btnGuardarCB"
        Me.btnGuardarCB.Size = New System.Drawing.Size(72, 24)
        Me.btnGuardarCB.TabIndex = 4
        Me.btnGuardarCB.Text = "Guardar"
        Me.btnGuardarCB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardarCB, "Guardar el precio de venta del produdcto.")
        Me.btnGuardarCB.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtPorcentaje)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.btnPrecios)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtCantidad)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtMedida)
        Me.GroupBox3.Controls.Add(Me.txtProducto)
        Me.GroupBox3.Controls.Add(Me.btnGuardarCB)
        Me.GroupBox3.Controls.Add(Me.txtDESCRIPCION1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 153)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(978, 71)
        Me.GroupBox3.TabIndex = 132
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle de precios de Menus"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.BackColor = System.Drawing.SystemColors.Control
        Me.txtPorcentaje.Enabled = False
        Me.txtPorcentaje.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentaje.ForeColor = System.Drawing.Color.Navy
        Me.txtPorcentaje.Location = New System.Drawing.Point(689, 40)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(116, 22)
        Me.txtPorcentaje.TabIndex = 128
        Me.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPrecios
        '
        Me.btnPrecios.Location = New System.Drawing.Point(897, 35)
        Me.btnPrecios.Name = "btnPrecios"
        Me.btnPrecios.Size = New System.Drawing.Size(97, 23)
        Me.btnPrecios.TabIndex = 127
        Me.btnPrecios.Text = "Asignar Precio"
        Me.btnPrecios.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DgvProductos)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(978, 243)
        Me.GroupBox2.TabIndex = 133
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Menus Programados"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Teal
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(72, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(386, 22)
        Me.Label7.TabIndex = 129
        Me.Label7.Text = "Descripción"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Teal
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(451, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 22)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Medida"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Teal
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(567, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 22)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "Precio"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Teal
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(688, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 22)
        Me.Label10.TabIndex = 131
        Me.Label10.Text = "% Ganancia"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cafeteria_Precios_Venta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(978, 467)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Cafeteria_Precios_Venta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria_Precios_Venta"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtDia As System.Windows.Forms.TextBox
    Friend WithEvents cmbTiempo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtDESCRIPCION1 As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtMedida As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardarCB As System.Windows.Forms.Button
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrecios As System.Windows.Forms.Button
    Friend WithEvents txtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
