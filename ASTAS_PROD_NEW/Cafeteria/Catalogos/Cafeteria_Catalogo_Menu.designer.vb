<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Catalogo_Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Catalogo_Menu))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDescuentos = New System.Windows.Forms.TextBox
        Me.txtTotalPagar = New System.Windows.Forms.TextBox
        Me.lblDescuento = New System.Windows.Forms.Label
        Me.lblTotalPagar = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.BtnBuscarCodigo1 = New System.Windows.Forms.Button
        Me.Btn_Eliminar = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Btn_Agregar = New System.Windows.Forms.Button
        Me.BtnBuscarCodigo2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblMargenOperativo = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DgvProductos = New System.Windows.Forms.DataGridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Grid_Ingredientes = New System.Windows.Forms.DataGridView
        Me.Grid_Recetas = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.TextMedida1 = New System.Windows.Forms.TextBox
        Me.txtCODIGO_PRODUCTO = New System.Windows.Forms.TextBox
        Me.txtDESCRIPCION1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpBeneficiarios = New System.Windows.Forms.GroupBox
        Me.dtpFechaTrabajo = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.TxtCODIGO_MENU = New System.Windows.Forms.TextBox
        Me.cmbBODEGA2 = New System.Windows.Forms.ComboBox
        Me.TextMedida2 = New System.Windows.Forms.TextBox
        Me.TxtDESCRIPCION2 = New System.Windows.Forms.TextBox
        Me.chkESTADO = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Grid_Ingredientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid_Recetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GrpBeneficiarios.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(0, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Producto a Elaborar :"
        '
        'txtDescuentos
        '
        Me.txtDescuentos.BackColor = System.Drawing.Color.White
        Me.txtDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuentos.ForeColor = System.Drawing.Color.Blue
        Me.txtDescuentos.Location = New System.Drawing.Point(548, 71)
        Me.txtDescuentos.Name = "txtDescuentos"
        Me.txtDescuentos.ReadOnly = True
        Me.txtDescuentos.Size = New System.Drawing.Size(58, 22)
        Me.txtDescuentos.TabIndex = 119
        Me.txtDescuentos.Text = "0.0"
        Me.txtDescuentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip2.SetToolTip(Me.txtDescuentos, "Precio de Venta Sugerido por Sistema Sin IVA")
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackColor = System.Drawing.Color.White
        Me.txtTotalPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagar.ForeColor = System.Drawing.Color.Blue
        Me.txtTotalPagar.Location = New System.Drawing.Point(307, 17)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.Size = New System.Drawing.Size(58, 22)
        Me.txtTotalPagar.TabIndex = 118
        Me.txtTotalPagar.Text = "0.0"
        Me.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip2.SetToolTip(Me.txtTotalPagar, "Sumatoria de Costos Unitarios de los ingredientes SIN IVA")
        '
        'lblDescuento
        '
        Me.lblDescuento.AutoSize = True
        Me.lblDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.Location = New System.Drawing.Point(371, 78)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(156, 13)
        Me.lblDescuento.TabIndex = 117
        Me.lblDescuento.Text = "Precio de Venta Sugerido:"
        '
        'lblTotalPagar
        '
        Me.lblTotalPagar.AutoSize = True
        Me.lblTotalPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPagar.Location = New System.Drawing.Point(161, 22)
        Me.lblTotalPagar.Name = "lblTotalPagar"
        Me.lblTotalPagar.Size = New System.Drawing.Size(118, 13)
        Me.lblTotalPagar.TabIndex = 116
        Me.lblTotalPagar.Text = "Costo Neto sin IVA:"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(533, 48)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 26)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Nuevo"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button1, "Limpiar los campos para ingresar una nueva receta.")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnBuscarCodigo1
        '
        Me.BtnBuscarCodigo1.Image = CType(resources.GetObject("BtnBuscarCodigo1.Image"), System.Drawing.Image)
        Me.BtnBuscarCodigo1.Location = New System.Drawing.Point(506, 75)
        Me.BtnBuscarCodigo1.Name = "BtnBuscarCodigo1"
        Me.BtnBuscarCodigo1.Size = New System.Drawing.Size(22, 22)
        Me.BtnBuscarCodigo1.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.BtnBuscarCodigo1, "Busqueda de Productos a Producir.")
        Me.BtnBuscarCodigo1.UseVisualStyleBackColor = True
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Btn_Eliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btn_Eliminar.Image = CType(resources.GetObject("Btn_Eliminar.Image"), System.Drawing.Image)
        Me.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Eliminar.Location = New System.Drawing.Point(533, 75)
        Me.Btn_Eliminar.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(85, 26)
        Me.Btn_Eliminar.TabIndex = 2
        Me.Btn_Eliminar.Text = "El&iminar"
        Me.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Btn_Eliminar, "Eliminar una materia prima de la receta en pantalla.")
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(533, 17)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 26)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Nuevo"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button2, "Limpiar los campos para ingresar materia prima.")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Btn_Agregar
        '
        Me.Btn_Agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Btn_Agregar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btn_Agregar.Image = CType(resources.GetObject("Btn_Agregar.Image"), System.Drawing.Image)
        Me.Btn_Agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Agregar.Location = New System.Drawing.Point(533, 46)
        Me.Btn_Agregar.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Btn_Agregar.Name = "Btn_Agregar"
        Me.Btn_Agregar.Size = New System.Drawing.Size(85, 26)
        Me.Btn_Agregar.TabIndex = 1
        Me.Btn_Agregar.Text = "&Guardar"
        Me.Btn_Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Btn_Agregar, "Guardar los cambios o nuevo item de una receta.")
        Me.Btn_Agregar.UseVisualStyleBackColor = True
        '
        'BtnBuscarCodigo2
        '
        Me.BtnBuscarCodigo2.Image = CType(resources.GetObject("BtnBuscarCodigo2.Image"), System.Drawing.Image)
        Me.BtnBuscarCodigo2.Location = New System.Drawing.Point(506, 41)
        Me.BtnBuscarCodigo2.Name = "BtnBuscarCodigo2"
        Me.BtnBuscarCodigo2.Size = New System.Drawing.Size(22, 22)
        Me.BtnBuscarCodigo2.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.BtnBuscarCodigo2, "Búsqueda de Materia prima del prducto a producir o elaborar.")
        Me.BtnBuscarCodigo2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Blue
        Me.TextBox1.Location = New System.Drawing.Point(307, 43)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(58, 22)
        Me.TextBox1.TabIndex = 124
        Me.TextBox1.Text = "0.0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip2.SetToolTip(Me.TextBox1, "Costo Neto sin IVA por El Margen Operativo")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(161, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(149, 13)
        Me.Label11.TabIndex = 123
        Me.Label11.Text = "Monto Operativo sin IVA:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblMargenOperativo)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.PictureBox1)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.lblTotalPagar)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.lblDescuento)
        Me.GroupBox3.Controls.Add(Me.txtTotalPagar)
        Me.GroupBox3.Controls.Add(Me.txtDescuentos)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 433)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1001, 120)
        Me.GroupBox3.TabIndex = 125
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Totales"
        '
        'lblMargenOperativo
        '
        Me.lblMargenOperativo.AutoSize = True
        Me.lblMargenOperativo.Location = New System.Drawing.Point(5, 22)
        Me.lblMargenOperativo.Name = "lblMargenOperativo"
        Me.lblMargenOperativo.Size = New System.Drawing.Size(112, 13)
        Me.lblMargenOperativo.TabIndex = 142
        Me.lblMargenOperativo.Text = "Margen Operativo:"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.White
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Blue
        Me.TextBox3.Location = New System.Drawing.Point(548, 92)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(58, 22)
        Me.TextBox3.TabIndex = 141
        Me.TextBox3.Text = "0.0"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip2.SetToolTip(Me.TextBox3, "Precio  de venta asignado por usuario")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(371, 99)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(168, 13)
        Me.Label14.TabIndex = 140
        Me.Label14.Text = "Precio de Venta Modificado:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(569, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 16)
        Me.Label13.TabIndex = 130
        Me.Label13.Text = "13%"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(114, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 16)
        Me.Label12.TabIndex = 129
        Me.Label12.Text = "%"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(371, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 127
        Me.Label15.Text = "% IVA:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(371, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 33)
        Me.Label9.TabIndex = 127
        Me.Label9.Text = "IVA del Costo Neto + Monto Operativo:"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Blue
        Me.TextBox2.Location = New System.Drawing.Point(548, 50)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(58, 22)
        Me.TextBox2.TabIndex = 128
        Me.TextBox2.Text = "0.0"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip2.SetToolTip(Me.TextBox2, "Iva del Costo Neto + Monto Operativo")
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(644, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(457, 87)
        Me.PictureBox1.TabIndex = 126
        Me.PictureBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(0, 83)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(149, 23)
        Me.Button3.TabIndex = 125
        Me.Button3.Text = "Ajustar Precio de Venta"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DgvProductos)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 246)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1001, 187)
        Me.GroupBox2.TabIndex = 127
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de Ingredientes"
        '
        'DgvProductos
        '
        Me.DgvProductos.AllowUserToAddRows = False
        Me.DgvProductos.AllowUserToDeleteRows = False
        Me.DgvProductos.AllowUserToOrderColumns = True
        Me.DgvProductos.AllowUserToResizeColumns = False
        Me.DgvProductos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvProductos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvProductos.BackgroundColor = System.Drawing.Color.White
        Me.DgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvProductos.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvProductos.Location = New System.Drawing.Point(3, 16)
        Me.DgvProductos.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.DgvProductos.MultiSelect = False
        Me.DgvProductos.Name = "DgvProductos"
        Me.DgvProductos.ReadOnly = True
        Me.DgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProductos.Size = New System.Drawing.Size(995, 168)
        Me.DgvProductos.TabIndex = 55
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Grid_Ingredientes)
        Me.GroupBox4.Controls.Add(Me.Grid_Recetas)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox4.Location = New System.Drawing.Point(831, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(170, 246)
        Me.GroupBox4.TabIndex = 128
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Visible = False
        '
        'Grid_Ingredientes
        '
        Me.Grid_Ingredientes.AllowUserToAddRows = False
        Me.Grid_Ingredientes.BackgroundColor = System.Drawing.Color.White
        Me.Grid_Ingredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_Ingredientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_Ingredientes.Location = New System.Drawing.Point(3, 110)
        Me.Grid_Ingredientes.Name = "Grid_Ingredientes"
        Me.Grid_Ingredientes.ReadOnly = True
        Me.Grid_Ingredientes.RowHeadersVisible = False
        Me.Grid_Ingredientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid_Ingredientes.Size = New System.Drawing.Size(164, 133)
        Me.Grid_Ingredientes.TabIndex = 136
        '
        'Grid_Recetas
        '
        Me.Grid_Recetas.AllowUserToAddRows = False
        Me.Grid_Recetas.BackgroundColor = System.Drawing.Color.White
        Me.Grid_Recetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_Recetas.Dock = System.Windows.Forms.DockStyle.Top
        Me.Grid_Recetas.Location = New System.Drawing.Point(3, 16)
        Me.Grid_Recetas.Name = "Grid_Recetas"
        Me.Grid_Recetas.ReadOnly = True
        Me.Grid_Recetas.RowHeadersVisible = False
        Me.Grid_Recetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid_Recetas.Size = New System.Drawing.Size(164, 94)
        Me.Grid_Recetas.TabIndex = 135
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.TextMedida1)
        Me.GroupBox1.Controls.Add(Me.txtCODIGO_PRODUCTO)
        Me.GroupBox1.Controls.Add(Me.BtnBuscarCodigo1)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(831, 116)
        Me.GroupBox1.TabIndex = 129
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Catálogo de Menú"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(0, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 16)
        Me.Label10.TabIndex = 135
        Me.Label10.Text = "Menu:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(99, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(461, 20)
        Me.Label8.TabIndex = 134
        Me.Label8.Text = "ASTAS DEPARTAMENTO GENERAL DE ALIMENTOS"
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(96, 50)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(430, 24)
        Me.cmbBODEGA.TabIndex = 2
        '
        'TextMedida1
        '
        Me.TextMedida1.BackColor = System.Drawing.SystemColors.Control
        Me.TextMedida1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextMedida1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMedida1.ForeColor = System.Drawing.Color.Navy
        Me.TextMedida1.Location = New System.Drawing.Point(644, 79)
        Me.TextMedida1.MaxLength = 100
        Me.TextMedida1.Name = "TextMedida1"
        Me.TextMedida1.ReadOnly = True
        Me.TextMedida1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextMedida1.Size = New System.Drawing.Size(139, 15)
        Me.TextMedida1.TabIndex = 110
        Me.TextMedida1.Visible = False
        '
        'txtCODIGO_PRODUCTO
        '
        Me.txtCODIGO_PRODUCTO.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCODIGO_PRODUCTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCODIGO_PRODUCTO.ForeColor = System.Drawing.Color.Navy
        Me.txtCODIGO_PRODUCTO.Location = New System.Drawing.Point(96, 75)
        Me.txtCODIGO_PRODUCTO.Name = "txtCODIGO_PRODUCTO"
        Me.txtCODIGO_PRODUCTO.Size = New System.Drawing.Size(63, 22)
        Me.txtCODIGO_PRODUCTO.TabIndex = 0
        '
        'txtDESCRIPCION1
        '
        Me.txtDESCRIPCION1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDESCRIPCION1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDESCRIPCION1.BackColor = System.Drawing.SystemColors.Window
        Me.txtDESCRIPCION1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION1.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION1.Location = New System.Drawing.Point(161, 75)
        Me.txtDESCRIPCION1.MaxLength = 100
        Me.txtDESCRIPCION1.Name = "txtDESCRIPCION1"
        Me.txtDESCRIPCION1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION1.Size = New System.Drawing.Size(343, 22)
        Me.txtDESCRIPCION1.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(0, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 16)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "Bodega"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(0, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Compañía :"
        Me.Label1.Visible = False
        '
        'GrpBeneficiarios
        '
        Me.GrpBeneficiarios.AutoSize = True
        Me.GrpBeneficiarios.Controls.Add(Me.Btn_Eliminar)
        Me.GrpBeneficiarios.Controls.Add(Me.dtpFechaTrabajo)
        Me.GrpBeneficiarios.Controls.Add(Me.Button2)
        Me.GrpBeneficiarios.Controls.Add(Me.Btn_Agregar)
        Me.GrpBeneficiarios.Controls.Add(Me.Label7)
        Me.GrpBeneficiarios.Controls.Add(Me.txtCantidad)
        Me.GrpBeneficiarios.Controls.Add(Me.TxtCODIGO_MENU)
        Me.GrpBeneficiarios.Controls.Add(Me.cmbBODEGA2)
        Me.GrpBeneficiarios.Controls.Add(Me.TextMedida2)
        Me.GrpBeneficiarios.Controls.Add(Me.BtnBuscarCodigo2)
        Me.GrpBeneficiarios.Controls.Add(Me.TxtDESCRIPCION2)
        Me.GrpBeneficiarios.Controls.Add(Me.chkESTADO)
        Me.GrpBeneficiarios.Controls.Add(Me.Label5)
        Me.GrpBeneficiarios.Controls.Add(Me.Label3)
        Me.GrpBeneficiarios.Controls.Add(Me.Label4)
        Me.GrpBeneficiarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpBeneficiarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GrpBeneficiarios.ForeColor = System.Drawing.Color.Black
        Me.GrpBeneficiarios.Location = New System.Drawing.Point(0, 116)
        Me.GrpBeneficiarios.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GrpBeneficiarios.Name = "GrpBeneficiarios"
        Me.GrpBeneficiarios.Padding = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GrpBeneficiarios.Size = New System.Drawing.Size(831, 130)
        Me.GrpBeneficiarios.TabIndex = 130
        Me.GrpBeneficiarios.TabStop = False
        Me.GrpBeneficiarios.Text = "Registro de Detalle de la Receta"
        '
        'dtpFechaTrabajo
        '
        Me.dtpFechaTrabajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaTrabajo.Location = New System.Drawing.Point(439, 74)
        Me.dtpFechaTrabajo.Name = "dtpFechaTrabajo"
        Me.dtpFechaTrabajo.Size = New System.Drawing.Size(87, 24)
        Me.dtpFechaTrabajo.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(0, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 16)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "Bodega:"
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.SystemColors.Window
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.Navy
        Me.txtCantidad.Location = New System.Drawing.Point(96, 64)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(95, 22)
        Me.txtCantidad.TabIndex = 7
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCODIGO_MENU
        '
        Me.TxtCODIGO_MENU.BackColor = System.Drawing.Color.Gainsboro
        Me.TxtCODIGO_MENU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCODIGO_MENU.ForeColor = System.Drawing.Color.Navy
        Me.TxtCODIGO_MENU.Location = New System.Drawing.Point(96, 41)
        Me.TxtCODIGO_MENU.Name = "TxtCODIGO_MENU"
        Me.TxtCODIGO_MENU.Size = New System.Drawing.Size(63, 22)
        Me.TxtCODIGO_MENU.TabIndex = 4
        '
        'cmbBODEGA2
        '
        Me.cmbBODEGA2.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA2.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA2.FormattingEnabled = True
        Me.cmbBODEGA2.Location = New System.Drawing.Point(96, 16)
        Me.cmbBODEGA2.Name = "cmbBODEGA2"
        Me.cmbBODEGA2.Size = New System.Drawing.Size(430, 24)
        Me.cmbBODEGA2.TabIndex = 3
        '
        'TextMedida2
        '
        Me.TextMedida2.BackColor = System.Drawing.Color.White
        Me.TextMedida2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextMedida2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TextMedida2.ForeColor = System.Drawing.Color.Black
        Me.TextMedida2.Location = New System.Drawing.Point(197, 73)
        Me.TextMedida2.MaxLength = 100
        Me.TextMedida2.Name = "TextMedida2"
        Me.TextMedida2.ReadOnly = True
        Me.TextMedida2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextMedida2.Size = New System.Drawing.Size(122, 13)
        Me.TextMedida2.TabIndex = 111
        '
        'TxtDESCRIPCION2
        '
        Me.TxtDESCRIPCION2.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDESCRIPCION2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDESCRIPCION2.ForeColor = System.Drawing.Color.Navy
        Me.TxtDESCRIPCION2.Location = New System.Drawing.Point(161, 41)
        Me.TxtDESCRIPCION2.MaxLength = 100
        Me.TxtDESCRIPCION2.Name = "TxtDESCRIPCION2"
        Me.TxtDESCRIPCION2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtDESCRIPCION2.Size = New System.Drawing.Size(343, 22)
        Me.TxtDESCRIPCION2.TabIndex = 5
        '
        'chkESTADO
        '
        Me.chkESTADO.AutoSize = True
        Me.chkESTADO.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.chkESTADO.ForeColor = System.Drawing.Color.Red
        Me.chkESTADO.Location = New System.Drawing.Point(96, 87)
        Me.chkESTADO.Name = "chkESTADO"
        Me.chkESTADO.Size = New System.Drawing.Size(15, 14)
        Me.chkESTADO.TabIndex = 6
        Me.chkESTADO.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(0, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 16)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Fuera de Uso:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(0, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 16)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Materia Prima:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(0, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Cantidad:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(669, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 13)
        Me.Label16.TabIndex = 136
        Me.Label16.Text = "Revision 12/05/2014"
        '
        'Cafeteria_Catalogo_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1001, 553)
        Me.Controls.Add(Me.GrpBeneficiarios)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Cafeteria_Catalogo_Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria Catalogo Menu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.Grid_Ingredientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid_Recetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpBeneficiarios.ResumeLayout(False)
        Me.GrpBeneficiarios.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescuentos As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPagar As System.Windows.Forms.TextBox
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents lblTotalPagar As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DgvProductos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Grid_Ingredientes As System.Windows.Forms.DataGridView
    Friend WithEvents Grid_Recetas As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents TextMedida1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCODIGO_PRODUCTO As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarCodigo1 As System.Windows.Forms.Button
    Friend WithEvents txtDESCRIPCION1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpBeneficiarios As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents dtpFechaTrabajo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TxtCODIGO_MENU As System.Windows.Forms.TextBox
    Friend WithEvents cmbBODEGA2 As System.Windows.Forms.ComboBox
    Friend WithEvents TextMedida2 As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarCodigo2 As System.Windows.Forms.Button
    Friend WithEvents TxtDESCRIPCION2 As System.Windows.Forms.TextBox
    Friend WithEvents chkESTADO As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents lblMargenOperativo As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
