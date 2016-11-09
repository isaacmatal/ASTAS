<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Traslado_Bodega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Traslado_Bodega))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BtnLimpiar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnGuardarLinea = New System.Windows.Forms.Button
        Me.Txt_Producto_descripcion = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnBuscarProducto = New System.Windows.Forms.Button
        Me.Txt_Producto_codigo = New System.Windows.Forms.TextBox
        Me.Txt_Producto_cantidad = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_Nota = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.numeroSalida = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.numeroEntrada = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TxtBodega = New System.Windows.Forms.TextBox
        Me.Txt_Tipo_Movimiento_requiere = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Btn_Buscar_Movimiento = New System.Windows.Forms.Button
        Me.Txt_tipo_movimiento_numero = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.dpFECHA_CONTABLE = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.txtFecheo = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Txt_Existencias2 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Txt_Existencias = New System.Windows.Forms.Label
        Me.cmbBODEGA2 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbBODEGA1 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnProcesarPartida = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.lblProcesado = New System.Windows.Forms.Label
        Me.txtDIFERENCIA = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_Unidades = New System.Windows.Forms.TextBox
        Me.BtnEliminar = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgvMovtos = New System.Windows.Forms.DataGridView
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvMovtos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnLimpiar.Image = CType(resources.GetObject("BtnLimpiar.Image"), System.Drawing.Image)
        Me.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLimpiar.Location = New System.Drawing.Point(724, 35)
        Me.BtnLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(24, 24)
        Me.BtnLimpiar.TabIndex = 5
        Me.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Teal
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(108, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(376, 25)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "Descripción de productos"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Teal
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(484, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 25)
        Me.Label10.TabIndex = 108
        '
        'btnGuardarLinea
        '
        Me.btnGuardarLinea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarLinea.Image = CType(resources.GetObject("btnGuardarLinea.Image"), System.Drawing.Image)
        Me.btnGuardarLinea.Location = New System.Drawing.Point(700, 35)
        Me.btnGuardarLinea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGuardarLinea.Name = "btnGuardarLinea"
        Me.btnGuardarLinea.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardarLinea.TabIndex = 3
        Me.btnGuardarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardarLinea.UseVisualStyleBackColor = True
        '
        'Txt_Producto_descripcion
        '
        Me.Txt_Producto_descripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Txt_Producto_descripcion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_descripcion.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_descripcion.Location = New System.Drawing.Point(109, 37)
        Me.Txt_Producto_descripcion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Txt_Producto_descripcion.MaxLength = 100
        Me.Txt_Producto_descripcion.Name = "Txt_Producto_descripcion"
        Me.Txt_Producto_descripcion.ReadOnly = True
        Me.Txt_Producto_descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Producto_descripcion.Size = New System.Drawing.Size(450, 22)
        Me.Txt_Producto_descripcion.TabIndex = 99
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(6, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 25)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Código"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.Location = New System.Drawing.Point(85, 36)
        Me.btnBuscarProducto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto.TabIndex = 1
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'Txt_Producto_codigo
        '
        Me.Txt_Producto_codigo.BackColor = System.Drawing.Color.White
        Me.Txt_Producto_codigo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_codigo.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_codigo.Location = New System.Drawing.Point(6, 37)
        Me.Txt_Producto_codigo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Txt_Producto_codigo.Name = "Txt_Producto_codigo"
        Me.Txt_Producto_codigo.Size = New System.Drawing.Size(80, 22)
        Me.Txt_Producto_codigo.TabIndex = 0
        '
        'Txt_Producto_cantidad
        '
        Me.Txt_Producto_cantidad.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Producto_cantidad.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_cantidad.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_cantidad.Location = New System.Drawing.Point(560, 37)
        Me.Txt_Producto_cantidad.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Txt_Producto_cantidad.Name = "Txt_Producto_cantidad"
        Me.Txt_Producto_cantidad.Size = New System.Drawing.Size(70, 22)
        Me.Txt_Producto_cantidad.TabIndex = 2
        Me.Txt_Producto_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txt_Nota)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.txtCompañia)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Btn_Nuevo)
        Me.GroupBox2.Controls.Add(Me.numeroSalida)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.numeroEntrada)
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Controls.Add(Me.TxtBodega)
        Me.GroupBox2.Controls.Add(Me.Txt_Tipo_Movimiento_requiere)
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Btn_Buscar_Movimiento)
        Me.GroupBox2.Controls.Add(Me.Txt_tipo_movimiento_numero)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.dpFECHA_CONTABLE)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(161, 19)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(990, 148)
        Me.GroupBox2.TabIndex = 95
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalles Generales"
        '
        'txt_Nota
        '
        Me.txt_Nota.BackColor = System.Drawing.Color.Yellow
        Me.txt_Nota.Location = New System.Drawing.Point(632, 17)
        Me.txt_Nota.Multiline = True
        Me.txt_Nota.Name = "txt_Nota"
        Me.txt_Nota.Size = New System.Drawing.Size(199, 121)
        Me.txt_Nota.TabIndex = 105
        Me.txt_Nota.Text = "Nota:                                         . Recuerde que cada bodega debe ten" & _
            "er su catalogo de Notas de Remision. (Una numeracion para cada bodega)"
        '
        'Button1
        '
        Me.Button1.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(487, 85)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 25)
        Me.Button1.TabIndex = 104
        Me.Button1.Text = "Reporte"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(88, 26)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(393, 23)
        Me.txtCompañia.TabIndex = 103
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(232, 85)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 24)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Anular"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btn_Nuevo.Image = CType(resources.GetObject("Btn_Nuevo.Image"), System.Drawing.Image)
        Me.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Nuevo.Location = New System.Drawing.Point(303, 85)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(65, 24)
        Me.Btn_Nuevo.TabIndex = 0
        Me.Btn_Nuevo.Text = "Nuevo"
        Me.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        '
        'numeroSalida
        '
        Me.numeroSalida.BackColor = System.Drawing.SystemColors.Window
        Me.numeroSalida.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numeroSalida.ForeColor = System.Drawing.Color.Navy
        Me.numeroSalida.Location = New System.Drawing.Point(521, 116)
        Me.numeroSalida.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numeroSalida.Name = "numeroSalida"
        Me.numeroSalida.Size = New System.Drawing.Size(26, 22)
        Me.numeroSalida.TabIndex = 102
        Me.numeroSalida.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Navy
        Me.TextBox1.Location = New System.Drawing.Point(583, 116)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(24, 22)
        Me.TextBox1.TabIndex = 74
        Me.TextBox1.Visible = False
        '
        'numeroEntrada
        '
        Me.numeroEntrada.BackColor = System.Drawing.SystemColors.Window
        Me.numeroEntrada.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numeroEntrada.ForeColor = System.Drawing.Color.Navy
        Me.numeroEntrada.Location = New System.Drawing.Point(481, 117)
        Me.numeroEntrada.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numeroEntrada.Name = "numeroEntrada"
        Me.numeroEntrada.Size = New System.Drawing.Size(26, 22)
        Me.numeroEntrada.TabIndex = 101
        Me.numeroEntrada.Visible = False
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.Navy
        Me.TextBox4.Location = New System.Drawing.Point(88, 116)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(393, 22)
        Me.TextBox4.TabIndex = 100
        Me.TextBox4.Text = "No aplica"
        Me.TextBox4.Visible = False
        '
        'TxtBodega
        '
        Me.TxtBodega.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBodega.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBodega.ForeColor = System.Drawing.Color.Navy
        Me.TxtBodega.Location = New System.Drawing.Point(553, 116)
        Me.TxtBodega.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtBodega.Name = "TxtBodega"
        Me.TxtBodega.Size = New System.Drawing.Size(24, 22)
        Me.TxtBodega.TabIndex = 71
        Me.TxtBodega.Visible = False
        '
        'Txt_Tipo_Movimiento_requiere
        '
        Me.Txt_Tipo_Movimiento_requiere.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Tipo_Movimiento_requiere.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Tipo_Movimiento_requiere.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Tipo_Movimiento_requiere.Location = New System.Drawing.Point(481, 56)
        Me.Txt_Tipo_Movimiento_requiere.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Txt_Tipo_Movimiento_requiere.Name = "Txt_Tipo_Movimiento_requiere"
        Me.Txt_Tipo_Movimiento_requiere.Size = New System.Drawing.Size(38, 22)
        Me.Txt_Tipo_Movimiento_requiere.TabIndex = 99
        Me.Txt_Tipo_Movimiento_requiere.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Navy
        Me.TextBox3.Location = New System.Drawing.Point(481, 24)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(24, 22)
        Me.TextBox3.TabIndex = 98
        Me.TextBox3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(5, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Compañia"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Navy
        Me.TextBox2.Location = New System.Drawing.Point(88, 56)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(393, 22)
        Me.TextBox2.TabIndex = 95
        Me.TextBox2.Text = "Transferencia entre Bodegas"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(5, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 16)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Tipo Movimiento"
        '
        'Btn_Buscar_Movimiento
        '
        Me.Btn_Buscar_Movimiento.Image = CType(resources.GetObject("Btn_Buscar_Movimiento.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Movimiento.Location = New System.Drawing.Point(202, 85)
        Me.Btn_Buscar_Movimiento.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Btn_Buscar_Movimiento.Name = "Btn_Buscar_Movimiento"
        Me.Btn_Buscar_Movimiento.Size = New System.Drawing.Size(24, 24)
        Me.Btn_Buscar_Movimiento.TabIndex = 2
        Me.Btn_Buscar_Movimiento.UseVisualStyleBackColor = True
        '
        'Txt_tipo_movimiento_numero
        '
        Me.Txt_tipo_movimiento_numero.BackColor = System.Drawing.Color.Yellow
        Me.Txt_tipo_movimiento_numero.Enabled = False
        Me.Txt_tipo_movimiento_numero.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_tipo_movimiento_numero.ForeColor = System.Drawing.Color.Navy
        Me.Txt_tipo_movimiento_numero.Location = New System.Drawing.Point(88, 86)
        Me.Txt_tipo_movimiento_numero.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Txt_tipo_movimiento_numero.Name = "Txt_tipo_movimiento_numero"
        Me.Txt_tipo_movimiento_numero.Size = New System.Drawing.Size(112, 22)
        Me.Txt_tipo_movimiento_numero.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(5, 116)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 16)
        Me.Label15.TabIndex = 77
        Me.Label15.Text = "Tipo Documento"
        Me.Label15.Visible = False
        '
        'dpFECHA_CONTABLE
        '
        Me.dpFECHA_CONTABLE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CONTABLE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CONTABLE.Location = New System.Drawing.Point(374, 86)
        Me.dpFECHA_CONTABLE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFECHA_CONTABLE.Name = "dpFECHA_CONTABLE"
        Me.dpFECHA_CONTABLE.Size = New System.Drawing.Size(107, 22)
        Me.dpFECHA_CONTABLE.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(5, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 16)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "N° Remision"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.txtFecheo)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Txt_Existencias2)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Txt_Existencias)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(161, 167)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(990, 90)
        Me.GroupBox1.TabIndex = 94
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transferencias entre Bodegas"
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(613, 52)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(239, 24)
        Me.Button4.TabIndex = 144
        Me.Button4.Text = "Cambiar Numero de Movimiento"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtFecheo
        '
        Me.txtFecheo.Location = New System.Drawing.Point(709, 25)
        Me.txtFecheo.Name = "txtFecheo"
        Me.txtFecheo.Size = New System.Drawing.Size(100, 23)
        Me.txtFecheo.TabIndex = 143
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(613, 23)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 24)
        Me.Button3.TabIndex = 142
        Me.Button3.Text = "Fecheo"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Teal
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Yellow
        Me.Label11.Location = New System.Drawing.Point(463, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 23)
        Me.Label11.TabIndex = 141
        Me.Label11.Text = "Existencias:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_Existencias2
        '
        Me.Txt_Existencias2.BackColor = System.Drawing.Color.Teal
        Me.Txt_Existencias2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Existencias2.ForeColor = System.Drawing.Color.Yellow
        Me.Txt_Existencias2.Location = New System.Drawing.Point(535, 56)
        Me.Txt_Existencias2.Name = "Txt_Existencias2"
        Me.Txt_Existencias2.Size = New System.Drawing.Size(72, 23)
        Me.Txt_Existencias2.TabIndex = 140
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Teal
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Yellow
        Me.Label20.Location = New System.Drawing.Point(463, 24)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 23)
        Me.Label20.TabIndex = 139
        Me.Label20.Text = "Existencias:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_Existencias
        '
        Me.Txt_Existencias.BackColor = System.Drawing.Color.Teal
        Me.Txt_Existencias.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Existencias.ForeColor = System.Drawing.Color.Yellow
        Me.Txt_Existencias.Location = New System.Drawing.Point(535, 24)
        Me.Txt_Existencias.Name = "Txt_Existencias"
        Me.Txt_Existencias.Size = New System.Drawing.Size(72, 23)
        Me.Txt_Existencias.TabIndex = 138
        '
        'cmbBODEGA2
        '
        Me.cmbBODEGA2.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA2.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA2.FormattingEnabled = True
        Me.cmbBODEGA2.Location = New System.Drawing.Point(88, 56)
        Me.cmbBODEGA2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbBODEGA2.Name = "cmbBODEGA2"
        Me.cmbBODEGA2.Size = New System.Drawing.Size(369, 24)
        Me.cmbBODEGA2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(5, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 16)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Bodega Entrada"
        '
        'cmbBODEGA1
        '
        Me.cmbBODEGA1.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA1.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA1.FormattingEnabled = True
        Me.cmbBODEGA1.Location = New System.Drawing.Point(88, 24)
        Me.cmbBODEGA1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbBODEGA1.Name = "cmbBODEGA1"
        Me.cmbBODEGA1.Size = New System.Drawing.Size(369, 24)
        Me.cmbBODEGA1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(5, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Bodega Salida"
        '
        'btnProcesarPartida
        '
        Me.btnProcesarPartida.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnProcesarPartida.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesarPartida.Image = CType(resources.GetObject("btnProcesarPartida.Image"), System.Drawing.Image)
        Me.btnProcesarPartida.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesarPartida.Location = New System.Drawing.Point(6, 22)
        Me.btnProcesarPartida.Name = "btnProcesarPartida"
        Me.btnProcesarPartida.Size = New System.Drawing.Size(64, 40)
        Me.btnProcesarPartida.TabIndex = 4
        Me.btnProcesarPartida.Text = "&Procesar"
        Me.btnProcesarPartida.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesarPartida.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Teal
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Yellow
        Me.Label9.Location = New System.Drawing.Point(558, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 25)
        Me.Label9.TabIndex = 112
        Me.Label9.Text = "Cantidad"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pbImagen
        '
        Me.pbImagen.Dock = System.Windows.Forms.DockStyle.Left
        Me.pbImagen.Location = New System.Drawing.Point(3, 19)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(158, 238)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 113
        Me.pbImagen.TabStop = False
        '
        'lblProcesado
        '
        Me.lblProcesado.BackColor = System.Drawing.Color.Yellow
        Me.lblProcesado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcesado.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblProcesado.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcesado.ForeColor = System.Drawing.Color.Red
        Me.lblProcesado.Location = New System.Drawing.Point(0, 0)
        Me.lblProcesado.Name = "lblProcesado"
        Me.lblProcesado.Size = New System.Drawing.Size(1154, 22)
        Me.lblProcesado.TabIndex = 114
        Me.lblProcesado.Text = "NUEVO DOCUMENTO"
        Me.lblProcesado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDIFERENCIA
        '
        Me.txtDIFERENCIA.BackColor = System.Drawing.SystemColors.Window
        Me.txtDIFERENCIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIFERENCIA.ForeColor = System.Drawing.Color.Red
        Me.txtDIFERENCIA.Location = New System.Drawing.Point(143, 22)
        Me.txtDIFERENCIA.Name = "txtDIFERENCIA"
        Me.txtDIFERENCIA.ReadOnly = True
        Me.txtDIFERENCIA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDIFERENCIA.Size = New System.Drawing.Size(104, 22)
        Me.txtDIFERENCIA.TabIndex = 115
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(76, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 16)
        Me.Label12.TabIndex = 116
        Me.Label12.Text = "Costo Total"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(629, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 25)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Medida"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txt_Unidades
        '
        Me.txt_Unidades.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_Unidades.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Unidades.ForeColor = System.Drawing.Color.Navy
        Me.txt_Unidades.Location = New System.Drawing.Point(632, 37)
        Me.txt_Unidades.Name = "txt_Unidades"
        Me.txt_Unidades.ReadOnly = True
        Me.txt_Unidades.Size = New System.Drawing.Size(70, 22)
        Me.txt_Unidades.TabIndex = 124
        Me.txt_Unidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnEliminar
        '
        Me.BtnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(747, 35)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(24, 24)
        Me.BtnEliminar.TabIndex = 131
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.pbImagen)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(0, 22)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1154, 260)
        Me.GroupBox4.TabIndex = 133
        Me.GroupBox4.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Txt_Producto_cantidad)
        Me.GroupBox3.Controls.Add(Me.btnGuardarLinea)
        Me.GroupBox3.Controls.Add(Me.Txt_Producto_codigo)
        Me.GroupBox3.Controls.Add(Me.BtnEliminar)
        Me.GroupBox3.Controls.Add(Me.btnBuscarProducto)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Txt_Producto_descripcion)
        Me.GroupBox3.Controls.Add(Me.txt_Unidades)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.BtnLimpiar)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 282)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1154, 64)
        Me.GroupBox3.TabIndex = 134
        Me.GroupBox3.TabStop = False
        '
        'dgvMovtos
        '
        Me.dgvMovtos.AllowUserToAddRows = False
        Me.dgvMovtos.AllowUserToDeleteRows = False
        Me.dgvMovtos.AllowUserToResizeColumns = False
        Me.dgvMovtos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvMovtos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMovtos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMovtos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMovtos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMovtos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMovtos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvMovtos.Location = New System.Drawing.Point(0, 346)
        Me.dgvMovtos.MultiSelect = False
        Me.dgvMovtos.Name = "dgvMovtos"
        Me.dgvMovtos.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMovtos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMovtos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovtos.Size = New System.Drawing.Size(1154, 222)
        Me.dgvMovtos.TabIndex = 135
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.btnProcesarPartida)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.txtDIFERENCIA)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(0, 568)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1154, 66)
        Me.GroupBox5.TabIndex = 136
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Proceso final"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(775, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 17)
        Me.Label13.TabIndex = 111
        Me.Label13.Text = "Revisado 13/05/2014"
        '
        'Inventario_Traslado_Bodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1154, 634)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.dgvMovtos)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.lblProcesado)
        Me.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Inventario_Traslado_Bodega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario_Traslado_Bodega"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvMovtos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnGuardarLinea As System.Windows.Forms.Button
    Friend WithEvents Txt_Producto_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents Txt_Producto_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Producto_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Btn_Buscar_Movimiento As System.Windows.Forms.Button
    Friend WithEvents Txt_tipo_movimiento_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dpFECHA_CONTABLE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmbBODEGA2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtBodega As System.Windows.Forms.TextBox
    Friend WithEvents cmbBODEGA1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Tipo_Movimiento_requiere As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents btnProcesarPartida As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents numeroEntrada As System.Windows.Forms.TextBox
    Friend WithEvents numeroSalida As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents lblProcesado As System.Windows.Forms.Label
    Friend WithEvents txtDIFERENCIA As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Unidades As System.Windows.Forms.TextBox
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Txt_Existencias As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_Existencias2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMovtos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_Nota As System.Windows.Forms.TextBox
    Friend WithEvents txtFecheo As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
