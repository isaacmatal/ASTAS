<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Ingreso_Fisico_y_Ajuste
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Ingreso_Fisico_y_Ajuste))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtFecheo = New System.Windows.Forms.TextBox
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.Btn_Buscar_Movimiento = New System.Windows.Forms.Button
        Me.Txt_tipo_movimiento_numero = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Txt_Producto_cantidad = New System.Windows.Forms.TextBox
        Me.BtnLimpiar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Txt_Exist_Fisicas = New System.Windows.Forms.TextBox
        Me.Txt_Producto_costo_total = New System.Windows.Forms.TextBox
        Me.btnGuardarLinea = New System.Windows.Forms.Button
        Me.Txt_Producto_descripcion = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnBuscarProducto = New System.Windows.Forms.Button
        Me.Txt_Producto_codigo = New System.Windows.Forms.TextBox
        Me.txt_Unidades = New System.Windows.Forms.TextBox
        Me.lblProcesado = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgvMovtos = New System.Windows.Forms.DataGridView
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvMovtos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(612, 13)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(174, 132)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 106
        Me.pbImagen.TabStop = False
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(333, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 24)
        Me.Button1.TabIndex = 112
        Me.Button1.Text = "Fecheo"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(9, 21)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(80, 24)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnProcesar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(100, 21)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 1
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFecheo)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.btnProcesar)
        Me.GroupBox1.Controls.Add(Me.txtCompañia)
        Me.GroupBox1.Controls.Add(Me.Btn_Buscar_Movimiento)
        Me.GroupBox1.Controls.Add(Me.Txt_tipo_movimiento_numero)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Txt_Producto_cantidad)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(956, 157)
        Me.GroupBox1.TabIndex = 104
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles"
        '
        'txtFecheo
        '
        Me.txtFecheo.Location = New System.Drawing.Point(429, 23)
        Me.txtFecheo.Name = "txtFecheo"
        Me.txtFecheo.Size = New System.Drawing.Size(100, 22)
        Me.txtFecheo.TabIndex = 113
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(100, 66)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(432, 22)
        Me.txtCompañia.TabIndex = 85
        '
        'Btn_Buscar_Movimiento
        '
        Me.Btn_Buscar_Movimiento.Image = CType(resources.GetObject("Btn_Buscar_Movimiento.Image"), System.Drawing.Image)
        Me.Btn_Buscar_Movimiento.Location = New System.Drawing.Point(214, 115)
        Me.Btn_Buscar_Movimiento.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Btn_Buscar_Movimiento.Name = "Btn_Buscar_Movimiento"
        Me.Btn_Buscar_Movimiento.Size = New System.Drawing.Size(24, 30)
        Me.Btn_Buscar_Movimiento.TabIndex = 2
        Me.Btn_Buscar_Movimiento.UseVisualStyleBackColor = True
        '
        'Txt_tipo_movimiento_numero
        '
        Me.Txt_tipo_movimiento_numero.BackColor = System.Drawing.Color.White
        Me.Txt_tipo_movimiento_numero.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_tipo_movimiento_numero.ForeColor = System.Drawing.Color.Navy
        Me.Txt_tipo_movimiento_numero.Location = New System.Drawing.Point(100, 116)
        Me.Txt_tipo_movimiento_numero.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Txt_tipo_movimiento_numero.Name = "Txt_tipo_movimiento_numero"
        Me.Txt_tipo_movimiento_numero.Size = New System.Drawing.Size(112, 22)
        Me.Txt_tipo_movimiento_numero.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(4, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "N° Movimiento:"
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(100, 90)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(432, 24)
        Me.cmbBODEGA.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(4, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Bodega :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(4, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Compañía :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(329, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Fecha de Corte :"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(420, 116)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(112, 22)
        Me.DateTimePicker1.TabIndex = 2
        '
        'Txt_Producto_cantidad
        '
        Me.Txt_Producto_cantidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Txt_Producto_cantidad.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_cantidad.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_cantidad.Location = New System.Drawing.Point(538, 90)
        Me.Txt_Producto_cantidad.Name = "Txt_Producto_cantidad"
        Me.Txt_Producto_cantidad.ReadOnly = True
        Me.Txt_Producto_cantidad.Size = New System.Drawing.Size(45, 22)
        Me.Txt_Producto_cantidad.TabIndex = 111
        Me.Txt_Producto_cantidad.Text = "0"
        Me.Txt_Producto_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_Producto_cantidad.Visible = False
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnLimpiar.Image = CType(resources.GetObject("BtnLimpiar.Image"), System.Drawing.Image)
        Me.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLimpiar.Location = New System.Drawing.Point(787, 199)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(24, 24)
        Me.BtnLimpiar.TabIndex = 3
        Me.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Teal
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(117, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(469, 20)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "Descripción de productos"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Teal
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(583, 176)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(252, 20)
        Me.Label10.TabIndex = 118
        Me.Label10.Text = "   Exist. FÍsicas  Un.Medida"
        '
        'Txt_Exist_Fisicas
        '
        Me.Txt_Exist_Fisicas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Exist_Fisicas.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Exist_Fisicas.Location = New System.Drawing.Point(583, 199)
        Me.Txt_Exist_Fisicas.Name = "Txt_Exist_Fisicas"
        Me.Txt_Exist_Fisicas.Size = New System.Drawing.Size(84, 22)
        Me.Txt_Exist_Fisicas.TabIndex = 1
        Me.Txt_Exist_Fisicas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Producto_costo_total
        '
        Me.Txt_Producto_costo_total.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Txt_Producto_costo_total.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_costo_total.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_costo_total.Location = New System.Drawing.Point(787, 141)
        Me.Txt_Producto_costo_total.Name = "Txt_Producto_costo_total"
        Me.Txt_Producto_costo_total.ReadOnly = True
        Me.Txt_Producto_costo_total.Size = New System.Drawing.Size(15, 22)
        Me.Txt_Producto_costo_total.TabIndex = 114
        Me.Txt_Producto_costo_total.Text = "0"
        Me.Txt_Producto_costo_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_Producto_costo_total.Visible = False
        '
        'btnGuardarLinea
        '
        Me.btnGuardarLinea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarLinea.Image = CType(resources.GetObject("btnGuardarLinea.Image"), System.Drawing.Image)
        Me.btnGuardarLinea.Location = New System.Drawing.Point(813, 199)
        Me.btnGuardarLinea.Name = "btnGuardarLinea"
        Me.btnGuardarLinea.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardarLinea.TabIndex = 2
        Me.btnGuardarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardarLinea.UseVisualStyleBackColor = True
        '
        'Txt_Producto_descripcion
        '
        Me.Txt_Producto_descripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Txt_Producto_descripcion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_descripcion.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_descripcion.Location = New System.Drawing.Point(118, 199)
        Me.Txt_Producto_descripcion.MaxLength = 100
        Me.Txt_Producto_descripcion.Name = "Txt_Producto_descripcion"
        Me.Txt_Producto_descripcion.ReadOnly = True
        Me.Txt_Producto_descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Producto_descripcion.Size = New System.Drawing.Size(459, 22)
        Me.Txt_Producto_descripcion.TabIndex = 110
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(6, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 20)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Código"
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.Location = New System.Drawing.Point(91, 199)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto.TabIndex = 4
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'Txt_Producto_codigo
        '
        Me.Txt_Producto_codigo.BackColor = System.Drawing.Color.White
        Me.Txt_Producto_codigo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_codigo.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_codigo.Location = New System.Drawing.Point(9, 199)
        Me.Txt_Producto_codigo.Name = "Txt_Producto_codigo"
        Me.Txt_Producto_codigo.Size = New System.Drawing.Size(80, 22)
        Me.Txt_Producto_codigo.TabIndex = 0
        '
        'txt_Unidades
        '
        Me.txt_Unidades.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_Unidades.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Unidades.ForeColor = System.Drawing.Color.Navy
        Me.txt_Unidades.Location = New System.Drawing.Point(669, 199)
        Me.txt_Unidades.Name = "txt_Unidades"
        Me.txt_Unidades.ReadOnly = True
        Me.txt_Unidades.Size = New System.Drawing.Size(84, 22)
        Me.txt_Unidades.TabIndex = 121
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
        Me.lblProcesado.Size = New System.Drawing.Size(962, 22)
        Me.lblProcesado.TabIndex = 122
        Me.lblProcesado.Text = "AJUSTE DE INVENTARIO FISICO"
        Me.lblProcesado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(760, 199)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(24, 24)
        Me.Button3.TabIndex = 123
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.txt_Unidades)
        Me.GroupBox3.Controls.Add(Me.Txt_Producto_codigo)
        Me.GroupBox3.Controls.Add(Me.BtnLimpiar)
        Me.GroupBox3.Controls.Add(Me.btnBuscarProducto)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Txt_Producto_descripcion)
        Me.GroupBox3.Controls.Add(Me.Txt_Exist_Fisicas)
        Me.GroupBox3.Controls.Add(Me.btnGuardarLinea)
        Me.GroupBox3.Controls.Add(Me.Txt_Producto_costo_total)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 22)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(962, 231)
        Me.GroupBox3.TabIndex = 124
        Me.GroupBox3.TabStop = False
        '
        'dgvMovtos
        '
        Me.dgvMovtos.AllowUserToAddRows = False
        Me.dgvMovtos.AllowUserToDeleteRows = False
        Me.dgvMovtos.AllowUserToResizeColumns = False
        Me.dgvMovtos.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvMovtos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMovtos.BackgroundColor = System.Drawing.Color.White
        Me.dgvMovtos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMovtos.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvMovtos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMovtos.Location = New System.Drawing.Point(0, 253)
        Me.dgvMovtos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvMovtos.MultiSelect = False
        Me.dgvMovtos.Name = "dgvMovtos"
        Me.dgvMovtos.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 10.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMovtos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvMovtos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovtos.Size = New System.Drawing.Size(962, 235)
        Me.dgvMovtos.TabIndex = 125
        '
        'Inventario_Ingreso_Fisico_y_Ajuste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(962, 488)
        Me.Controls.Add(Me.dgvMovtos)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblProcesado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Inventario_Ingreso_Fisico_y_Ajuste"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario_Ingreso_Fisico_y_Ajuste"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvMovtos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Buscar_Movimiento As System.Windows.Forms.Button
    Friend WithEvents Txt_tipo_movimiento_numero As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_Exist_Fisicas As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Producto_costo_total As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardarLinea As System.Windows.Forms.Button
    Friend WithEvents Txt_Producto_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents Txt_Producto_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Producto_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents txt_Unidades As System.Windows.Forms.TextBox
    Friend WithEvents lblProcesado As System.Windows.Forms.Label
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMovtos As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtFecheo As System.Windows.Forms.TextBox
End Class
