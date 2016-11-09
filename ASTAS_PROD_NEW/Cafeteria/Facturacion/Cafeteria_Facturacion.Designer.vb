<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Facturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Facturacion))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtTotalPagar = New System.Windows.Forms.TextBox
        Me.lblTotalNeto = New System.Windows.Forms.Label
        Me.btnEliminarProducto = New System.Windows.Forms.Button
        Me.btnReimprimir = New System.Windows.Forms.Button
        Me.btnPassw = New System.Windows.Forms.Button
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnCobrar = New System.Windows.Forms.Button
        Me.txtExistencias = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.lblTotal = New System.Windows.Forms.Label
        Me.txtPrecio = New System.Windows.Forms.TextBox
        Me.lblPrecio = New System.Windows.Forms.Label
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.lblCantidad = New System.Windows.Forms.Label
        Me.lblDescripcion = New System.Windows.Forms.Label
        Me.btnBuscarProducto = New System.Windows.Forms.Button
        Me.lblProducto = New System.Windows.Forms.Label
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.txtProducto = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.progressIdentify = New System.Windows.Forms.ProgressBar
        Me.lblDispoCred = New System.Windows.Forms.Label
        Me.btnHuella = New System.Windows.Forms.Button
        Me.btnBuscarCliente = New System.Windows.Forms.Button
        Me.txtDisponible = New System.Windows.Forms.TextBox
        Me.txtNombreEmpleado = New System.Windows.Forms.TextBox
        Me.txtCodigoEmpleado = New System.Windows.Forms.TextBox
        Me.lblCodigoEmpleado = New System.Windows.Forms.Label
        Me.rbEfectivo = New System.Windows.Forms.RadioButton
        Me.rbCredito = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lb_notificacion2 = New System.Windows.Forms.Label
        Me.lb_notificacion1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCaja = New System.Windows.Forms.TextBox
        Me.txtTiempoComida = New System.Windows.Forms.TextBox
        Me.txtCodigoCajero = New System.Windows.Forms.TextBox
        Me.lblCaja = New System.Windows.Forms.Label
        Me.lblTiempoComida = New System.Windows.Forms.Label
        Me.lblCodigoCajero = New System.Windows.Forms.Label
        Me.dtpFechaTrabajo = New System.Windows.Forms.DateTimePicker
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lblPayWay = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_correlativo = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtMotivoBloqueo = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgvDetalleVenta = New System.Windows.Forms.DataGridView
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCargar = New System.Windows.Forms.Button
        Me.lblNumTicket = New System.Windows.Forms.Label
        Me.txtNumTicket = New System.Windows.Forms.TextBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblEtiquetaAnulado = New System.Windows.Forms.Label
        Me.txtComentario = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvDetalleVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagar.Location = New System.Drawing.Point(556, 9)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.Size = New System.Drawing.Size(123, 31)
        Me.txtTotalPagar.TabIndex = 26
        Me.txtTotalPagar.Text = "0.00"
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.AutoSize = True
        Me.lblTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNeto.ForeColor = System.Drawing.Color.Red
        Me.lblTotalNeto.Location = New System.Drawing.Point(438, 15)
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.Size = New System.Drawing.Size(117, 18)
        Me.lblTotalNeto.TabIndex = 25
        Me.lblTotalNeto.Text = "Total  Venta: $"
        Me.lblTotalNeto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEliminarProducto
        '
        Me.btnEliminarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarProducto.ForeColor = System.Drawing.Color.Maroon
        Me.btnEliminarProducto.Location = New System.Drawing.Point(224, 9)
        Me.btnEliminarProducto.Name = "btnEliminarProducto"
        Me.btnEliminarProducto.Size = New System.Drawing.Size(101, 24)
        Me.btnEliminarProducto.TabIndex = 22
        Me.btnEliminarProducto.Text = "F10 Eliminar T."
        Me.btnEliminarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminarProducto.UseVisualStyleBackColor = True
        '
        'btnReimprimir
        '
        Me.btnReimprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimprimir.ForeColor = System.Drawing.Color.Maroon
        Me.btnReimprimir.Image = CType(resources.GetObject("btnReimprimir.Image"), System.Drawing.Image)
        Me.btnReimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReimprimir.Location = New System.Drawing.Point(330, 9)
        Me.btnReimprimir.Name = "btnReimprimir"
        Me.btnReimprimir.Size = New System.Drawing.Size(100, 24)
        Me.btnReimprimir.TabIndex = 20
        Me.btnReimprimir.Text = "F6  Imprimir"
        Me.btnReimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReimprimir.UseVisualStyleBackColor = True
        '
        'btnPassw
        '
        Me.btnPassw.Enabled = False
        Me.btnPassw.Image = CType(resources.GetObject("btnPassw.Image"), System.Drawing.Image)
        Me.btnPassw.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPassw.Location = New System.Drawing.Point(10, 37)
        Me.btnPassw.Name = "btnPassw"
        Me.btnPassw.Size = New System.Drawing.Size(10, 10)
        Me.btnPassw.TabIndex = 19
        Me.btnPassw.Text = "F9 Empleado"
        Me.btnPassw.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPassw.UseVisualStyleBackColor = True
        Me.btnPassw.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.ForeColor = System.Drawing.Color.Blue
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(9, 9)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(94, 24)
        Me.btnNuevo.TabIndex = 17
        Me.btnNuevo.Text = "F3  &Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnCobrar
        '
        Me.btnCobrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCobrar.ForeColor = System.Drawing.Color.Blue
        Me.btnCobrar.Image = CType(resources.GetObject("btnCobrar.Image"), System.Drawing.Image)
        Me.btnCobrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCobrar.Location = New System.Drawing.Point(108, 9)
        Me.btnCobrar.Name = "btnCobrar"
        Me.btnCobrar.Size = New System.Drawing.Size(100, 24)
        Me.btnCobrar.TabIndex = 16
        Me.btnCobrar.Text = "F2  &Cobrar"
        Me.btnCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCobrar.UseVisualStyleBackColor = True
        '
        'txtExistencias
        '
        Me.txtExistencias.BackColor = System.Drawing.Color.Cyan
        Me.txtExistencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExistencias.Location = New System.Drawing.Point(617, 29)
        Me.txtExistencias.Name = "txtExistencias"
        Me.txtExistencias.ReadOnly = True
        Me.txtExistencias.Size = New System.Drawing.Size(65, 22)
        Me.txtExistencias.TabIndex = 16
        Me.txtExistencias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(616, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Existencias :"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Cyan
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(549, 29)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(65, 22)
        Me.txtTotal.TabIndex = 14
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(554, 12)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(37, 13)
        Me.lblTotal.TabIndex = 13
        Me.lblTotal.Text = "Total :"
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.Color.Cyan
        Me.txtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Location = New System.Drawing.Point(481, 29)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.ReadOnly = True
        Me.txtPrecio.Size = New System.Drawing.Size(65, 22)
        Me.txtPrecio.TabIndex = 12
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Location = New System.Drawing.Point(489, 12)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(43, 13)
        Me.lblPrecio.TabIndex = 11
        Me.lblPrecio.Text = "Precio :"
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.Yellow
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.Red
        Me.txtCantidad.Location = New System.Drawing.Point(413, 29)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(65, 22)
        Me.txtCantidad.TabIndex = 1
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(420, 12)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(55, 13)
        Me.lblCantidad.TabIndex = 9
        Me.lblCantidad.Text = "Cantidad :"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(198, 12)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(69, 13)
        Me.lblDescripcion.TabIndex = 8
        Me.lblDescripcion.Text = "Descripción :"
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarProducto.FlatAppearance.BorderSize = 0
        Me.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.Location = New System.Drawing.Point(161, 28)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(26, 20)
        Me.btnBuscarProducto.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btnBuscarProducto, "Búsqueda de productos a facturar.")
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(92, 11)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(81, 13)
        Me.lblProducto.TabIndex = 2
        Me.lblProducto.Text = "Codigo Nuevo :"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.Cyan
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.ForeColor = System.Drawing.Color.Maroon
        Me.txtDescripcion.Location = New System.Drawing.Point(188, 29)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(219, 22)
        Me.txtDescripcion.TabIndex = 1
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.Cyan
        Me.txtProducto.Location = New System.Drawing.Point(94, 29)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(70, 20)
        Me.txtProducto.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.lblDispoCred)
        Me.GroupBox2.Controls.Add(Me.btnBuscarCliente)
        Me.GroupBox2.Controls.Add(Me.txtDisponible)
        Me.GroupBox2.Controls.Add(Me.txtNombreEmpleado)
        Me.GroupBox2.Controls.Add(Me.txtCodigoEmpleado)
        Me.GroupBox2.Controls.Add(Me.lblCodigoEmpleado)
        Me.GroupBox2.Controls.Add(Me.progressIdentify)
        Me.GroupBox2.Controls.Add(Me.btnHuella)
        Me.GroupBox2.Location = New System.Drawing.Point(281, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 72)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'progressIdentify
        '
        Me.progressIdentify.Location = New System.Drawing.Point(155, 17)
        Me.progressIdentify.Name = "progressIdentify"
        Me.progressIdentify.Size = New System.Drawing.Size(134, 18)
        Me.progressIdentify.TabIndex = 19
        Me.progressIdentify.Visible = False
        '
        'lblDispoCred
        '
        Me.lblDispoCred.AutoSize = True
        Me.lblDispoCred.Location = New System.Drawing.Point(142, 26)
        Me.lblDispoCred.Name = "lblDispoCred"
        Me.lblDispoCred.Size = New System.Drawing.Size(104, 13)
        Me.lblDispoCred.TabIndex = 8
        Me.lblDispoCred.Text = "Crédito Disponible: $"
        Me.lblDispoCred.Visible = False
        '
        'btnHuella
        '
        Me.btnHuella.Font = New System.Drawing.Font("OCR A Extended", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHuella.Location = New System.Drawing.Point(6, 12)
        Me.btnHuella.Name = "btnHuella"
        Me.btnHuella.Size = New System.Drawing.Size(143, 27)
        Me.btnHuella.TabIndex = 20
        Me.btnHuella.Text = "Capturar Huella"
        Me.btnHuella.UseVisualStyleBackColor = True
        Me.btnHuella.Visible = False
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(111, 17)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarCliente.TabIndex = 7
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnBuscarCliente, "Buscar Socios")
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtDisponible
        '
        Me.txtDisponible.BackColor = System.Drawing.Color.White
        Me.txtDisponible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDisponible.ForeColor = System.Drawing.Color.Black
        Me.txtDisponible.Location = New System.Drawing.Point(247, 23)
        Me.txtDisponible.Name = "txtDisponible"
        Me.txtDisponible.ReadOnly = True
        Me.txtDisponible.Size = New System.Drawing.Size(43, 20)
        Me.txtDisponible.TabIndex = 6
        Me.txtDisponible.Text = "0.00"
        Me.txtDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDisponible.Visible = False
        '
        'txtNombreEmpleado
        '
        Me.txtNombreEmpleado.BackColor = System.Drawing.Color.Cyan
        Me.txtNombreEmpleado.Location = New System.Drawing.Point(5, 48)
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.ReadOnly = True
        Me.txtNombreEmpleado.Size = New System.Drawing.Size(284, 20)
        Me.txtNombreEmpleado.TabIndex = 5
        '
        'txtCodigoEmpleado
        '
        Me.txtCodigoEmpleado.BackColor = System.Drawing.Color.Yellow
        Me.txtCodigoEmpleado.ForeColor = System.Drawing.Color.Blue
        Me.txtCodigoEmpleado.Location = New System.Drawing.Point(6, 25)
        Me.txtCodigoEmpleado.Name = "txtCodigoEmpleado"
        Me.txtCodigoEmpleado.Size = New System.Drawing.Size(102, 20)
        Me.txtCodigoEmpleado.TabIndex = 0
        '
        'lblCodigoEmpleado
        '
        Me.lblCodigoEmpleado.AutoSize = True
        Me.lblCodigoEmpleado.Location = New System.Drawing.Point(3, 9)
        Me.lblCodigoEmpleado.Name = "lblCodigoEmpleado"
        Me.lblCodigoEmpleado.Size = New System.Drawing.Size(46, 13)
        Me.lblCodigoEmpleado.TabIndex = 2
        Me.lblCodigoEmpleado.Text = "Codigo :"
        '
        'rbEfectivo
        '
        Me.rbEfectivo.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbEfectivo.BackColor = System.Drawing.Color.Lime
        Me.rbEfectivo.Checked = True
        Me.rbEfectivo.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.rbEfectivo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rbEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbEfectivo.Font = New System.Drawing.Font("Consolas", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEfectivo.ForeColor = System.Drawing.Color.Blue
        Me.rbEfectivo.Location = New System.Drawing.Point(830, 11)
        Me.rbEfectivo.Name = "rbEfectivo"
        Me.rbEfectivo.Size = New System.Drawing.Size(136, 69)
        Me.rbEfectivo.TabIndex = 1
        Me.rbEfectivo.TabStop = True
        Me.rbEfectivo.Text = "[F5] EFECTIVO"
        Me.rbEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbEfectivo.UseVisualStyleBackColor = True
        '
        'rbCredito
        '
        Me.rbCredito.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbCredito.BackColor = System.Drawing.Color.Red
        Me.rbCredito.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick
        Me.rbCredito.FlatAppearance.CheckedBackColor = System.Drawing.Color.Fuchsia
        Me.rbCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbCredito.Font = New System.Drawing.Font("Consolas", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCredito.ForeColor = System.Drawing.Color.White
        Me.rbCredito.Location = New System.Drawing.Point(687, 10)
        Me.rbCredito.Name = "rbCredito"
        Me.rbCredito.Size = New System.Drawing.Size(137, 69)
        Me.rbCredito.TabIndex = 0
        Me.rbCredito.Text = "[F1] CREDITO"
        Me.rbCredito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbCredito.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lb_notificacion2)
        Me.GroupBox1.Controls.Add(Me.lb_notificacion1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCaja)
        Me.GroupBox1.Controls.Add(Me.txtTiempoComida)
        Me.GroupBox1.Controls.Add(Me.txtCodigoCajero)
        Me.GroupBox1.Controls.Add(Me.lblCaja)
        Me.GroupBox1.Controls.Add(Me.lblTiempoComida)
        Me.GroupBox1.Controls.Add(Me.lblCodigoCajero)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 71)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'lb_notificacion2
        '
        Me.lb_notificacion2.BackColor = System.Drawing.Color.YellowGreen
        Me.lb_notificacion2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_notificacion2.ForeColor = System.Drawing.Color.Red
        Me.lb_notificacion2.Location = New System.Drawing.Point(180, 49)
        Me.lb_notificacion2.Name = "lb_notificacion2"
        Me.lb_notificacion2.Size = New System.Drawing.Size(90, 23)
        Me.lb_notificacion2.TabIndex = 25
        Me.lb_notificacion2.Text = "TICKETS DISPONIBLES:"
        Me.lb_notificacion2.Visible = False
        '
        'lb_notificacion1
        '
        Me.lb_notificacion1.BackColor = System.Drawing.Color.YellowGreen
        Me.lb_notificacion1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_notificacion1.ForeColor = System.Drawing.Color.Red
        Me.lb_notificacion1.Location = New System.Drawing.Point(-5, 49)
        Me.lb_notificacion1.Name = "lb_notificacion1"
        Me.lb_notificacion1.Size = New System.Drawing.Size(275, 23)
        Me.lb_notificacion1.TabIndex = 8
        Me.lb_notificacion1.Text = "TICKETS DISPONIBLES:"
        Me.lb_notificacion1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(3, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 24
        '
        'txtCaja
        '
        Me.txtCaja.BackColor = System.Drawing.Color.Cyan
        Me.txtCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCaja.ForeColor = System.Drawing.Color.Blue
        Me.txtCaja.Location = New System.Drawing.Point(106, 24)
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.ReadOnly = True
        Me.txtCaja.Size = New System.Drawing.Size(53, 22)
        Me.txtCaja.TabIndex = 5
        '
        'txtTiempoComida
        '
        Me.txtTiempoComida.BackColor = System.Drawing.Color.Cyan
        Me.txtTiempoComida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTiempoComida.ForeColor = System.Drawing.Color.Red
        Me.txtTiempoComida.Location = New System.Drawing.Point(162, 24)
        Me.txtTiempoComida.Name = "txtTiempoComida"
        Me.txtTiempoComida.ReadOnly = True
        Me.txtTiempoComida.Size = New System.Drawing.Size(100, 22)
        Me.txtTiempoComida.TabIndex = 4
        '
        'txtCodigoCajero
        '
        Me.txtCodigoCajero.BackColor = System.Drawing.Color.Cyan
        Me.txtCodigoCajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoCajero.ForeColor = System.Drawing.Color.Red
        Me.txtCodigoCajero.Location = New System.Drawing.Point(5, 24)
        Me.txtCodigoCajero.Name = "txtCodigoCajero"
        Me.txtCodigoCajero.ReadOnly = True
        Me.txtCodigoCajero.Size = New System.Drawing.Size(100, 22)
        Me.txtCodigoCajero.TabIndex = 3
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.Location = New System.Drawing.Point(103, 8)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(34, 13)
        Me.lblCaja.TabIndex = 2
        Me.lblCaja.Text = "Caja :"
        '
        'lblTiempoComida
        '
        Me.lblTiempoComida.AutoSize = True
        Me.lblTiempoComida.Location = New System.Drawing.Point(159, 9)
        Me.lblTiempoComida.Name = "lblTiempoComida"
        Me.lblTiempoComida.Size = New System.Drawing.Size(86, 13)
        Me.lblTiempoComida.TabIndex = 1
        Me.lblTiempoComida.Text = "Tiempo Comida :"
        '
        'lblCodigoCajero
        '
        Me.lblCodigoCajero.AutoSize = True
        Me.lblCodigoCajero.Location = New System.Drawing.Point(2, 9)
        Me.lblCodigoCajero.Name = "lblCodigoCajero"
        Me.lblCodigoCajero.Size = New System.Drawing.Size(79, 13)
        Me.lblCodigoCajero.TabIndex = 0
        Me.lblCodigoCajero.Text = "Código Cajero :"
        '
        'dtpFechaTrabajo
        '
        Me.dtpFechaTrabajo.Enabled = False
        Me.dtpFechaTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaTrabajo.Location = New System.Drawing.Point(583, 15)
        Me.dtpFechaTrabajo.Name = "dtpFechaTrabajo"
        Me.dtpFechaTrabajo.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaTrabajo.TabIndex = 30
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.lblPayWay)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.txt_correlativo)
        Me.GroupBox5.Controls.Add(Me.GroupBox2)
        Me.GroupBox5.Controls.Add(Me.dtpFechaTrabajo)
        Me.GroupBox5.Controls.Add(Me.GroupBox1)
        Me.GroupBox5.Controls.Add(Me.rbEfectivo)
        Me.GroupBox5.Controls.Add(Me.rbCredito)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1026, 92)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Detalles Generales"
        '
        'lblPayWay
        '
        Me.lblPayWay.BackColor = System.Drawing.Color.Transparent
        Me.lblPayWay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPayWay.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayWay.ForeColor = System.Drawing.Color.Maroon
        Me.lblPayWay.Location = New System.Drawing.Point(972, 35)
        Me.lblPayWay.Name = "lblPayWay"
        Me.lblPayWay.Size = New System.Drawing.Size(279, 21)
        Me.lblPayWay.TabIndex = 26
        Me.lblPayWay.Text = "[F1] CREDITO   [F5] EFECTIVO"
        Me.lblPayWay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPayWay.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(583, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Ticket :"
        '
        'txt_correlativo
        '
        Me.txt_correlativo.BackColor = System.Drawing.Color.Cyan
        Me.txt_correlativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_correlativo.ForeColor = System.Drawing.Color.Red
        Me.txt_correlativo.Location = New System.Drawing.Point(583, 55)
        Me.txt_correlativo.Name = "txt_correlativo"
        Me.txt_correlativo.ReadOnly = True
        Me.txt_correlativo.Size = New System.Drawing.Size(96, 22)
        Me.txt_correlativo.TabIndex = 31
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.txtMotivoBloqueo)
        Me.GroupBox6.Controls.Add(Me.TextBox2)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.txtExistencias)
        Me.GroupBox6.Controls.Add(Me.txtProducto)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.txtDescripcion)
        Me.GroupBox6.Controls.Add(Me.txtTotal)
        Me.GroupBox6.Controls.Add(Me.lblProducto)
        Me.GroupBox6.Controls.Add(Me.lblTotal)
        Me.GroupBox6.Controls.Add(Me.btnBuscarProducto)
        Me.GroupBox6.Controls.Add(Me.txtPrecio)
        Me.GroupBox6.Controls.Add(Me.lblDescripcion)
        Me.GroupBox6.Controls.Add(Me.lblPrecio)
        Me.GroupBox6.Controls.Add(Me.lblCantidad)
        Me.GroupBox6.Controls.Add(Me.txtCantidad)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox6.Location = New System.Drawing.Point(0, 92)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1026, 60)
        Me.GroupBox6.TabIndex = 32
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Detalles"
        '
        'txtMotivoBloqueo
        '
        Me.txtMotivoBloqueo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtMotivoBloqueo.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivoBloqueo.ForeColor = System.Drawing.Color.Teal
        Me.txtMotivoBloqueo.Location = New System.Drawing.Point(688, 11)
        Me.txtMotivoBloqueo.Multiline = True
        Me.txtMotivoBloqueo.Name = "txtMotivoBloqueo"
        Me.txtMotivoBloqueo.ReadOnly = True
        Me.txtMotivoBloqueo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMotivoBloqueo.Size = New System.Drawing.Size(332, 42)
        Me.txtMotivoBloqueo.TabIndex = 38
        Me.txtMotivoBloqueo.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Yellow
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Blue
        Me.TextBox2.Location = New System.Drawing.Point(10, 29)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(70, 22)
        Me.TextBox2.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Codigo Antiguo :"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dgvDetalleVenta)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 152)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1026, 264)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle de Cobro"
        '
        'dgvDetalleVenta
        '
        Me.dgvDetalleVenta.AllowUserToAddRows = False
        Me.dgvDetalleVenta.AllowUserToDeleteRows = False
        Me.dgvDetalleVenta.AllowUserToResizeColumns = False
        Me.dgvDetalleVenta.AllowUserToResizeRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvDetalleVenta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvDetalleVenta.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleVenta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalleVenta.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvDetalleVenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalleVenta.Location = New System.Drawing.Point(3, 16)
        Me.dgvDetalleVenta.MultiSelect = False
        Me.dgvDetalleVenta.Name = "dgvDetalleVenta"
        Me.dgvDetalleVenta.ReadOnly = True
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleVenta.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvDetalleVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleVenta.Size = New System.Drawing.Size(1020, 245)
        Me.dgvDetalleVenta.TabIndex = 32
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.btnCobrar)
        Me.GroupBox7.Controls.Add(Me.txtTotalPagar)
        Me.GroupBox7.Controls.Add(Me.btnNuevo)
        Me.GroupBox7.Controls.Add(Me.lblTotalNeto)
        Me.GroupBox7.Controls.Add(Me.btnPassw)
        Me.GroupBox7.Controls.Add(Me.btnReimprimir)
        Me.GroupBox7.Controls.Add(Me.btnEliminarProducto)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox7.Location = New System.Drawing.Point(0, 416)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(1026, 61)
        Me.GroupBox7.TabIndex = 34
        Me.GroupBox7.TabStop = False
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(234, 13)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(64, 23)
        Me.btnCargar.TabIndex = 1
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'lblNumTicket
        '
        Me.lblNumTicket.AutoSize = True
        Me.lblNumTicket.Location = New System.Drawing.Point(8, 15)
        Me.lblNumTicket.Name = "lblNumTicket"
        Me.lblNumTicket.Size = New System.Drawing.Size(77, 15)
        Me.lblNumTicket.TabIndex = 0
        Me.lblNumTicket.Text = "# de Ticket"
        '
        'txtNumTicket
        '
        Me.txtNumTicket.BackColor = System.Drawing.Color.Yellow
        Me.txtNumTicket.Location = New System.Drawing.Point(95, 14)
        Me.txtNumTicket.Name = "txtNumTicket"
        Me.txtNumTicket.Size = New System.Drawing.Size(123, 21)
        Me.txtNumTicket.TabIndex = 2
        Me.txtNumTicket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(325, 13)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(64, 23)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.lblEtiquetaAnulado)
        Me.GroupBox4.Controls.Add(Me.txtComentario)
        Me.GroupBox4.Controls.Add(Me.txtNumTicket)
        Me.GroupBox4.Controls.Add(Me.lblNumTicket)
        Me.GroupBox4.Controls.Add(Me.btnCargar)
        Me.GroupBox4.Controls.Add(Me.btnSalir)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(0, 477)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1026, 45)
        Me.GroupBox4.TabIndex = 35
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Venta anterior"
        '
        'lblEtiquetaAnulado
        '
        Me.lblEtiquetaAnulado.AutoSize = True
        Me.lblEtiquetaAnulado.BackColor = System.Drawing.Color.Transparent
        Me.lblEtiquetaAnulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaAnulado.Location = New System.Drawing.Point(410, 17)
        Me.lblEtiquetaAnulado.Name = "lblEtiquetaAnulado"
        Me.lblEtiquetaAnulado.Size = New System.Drawing.Size(104, 13)
        Me.lblEtiquetaAnulado.TabIndex = 37
        Me.lblEtiquetaAnulado.Text = "Motivo anulación"
        Me.lblEtiquetaAnulado.Visible = False
        '
        'txtComentario
        '
        Me.txtComentario.Location = New System.Drawing.Point(528, 13)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(445, 21)
        Me.txtComentario.TabIndex = 36
        Me.txtComentario.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 650
        '
        'Cafeteria_Facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1026, 540)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Cafeteria_Facturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Facturación con Tickets"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvDetalleVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtTotalPagar As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalNeto As System.Windows.Forms.Label
    Friend WithEvents btnEliminarProducto As System.Windows.Forms.Button
    Friend WithEvents btnReimprimir As System.Windows.Forms.Button
    Friend WithEvents btnPassw As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnCobrar As System.Windows.Forms.Button
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoEmpleado As System.Windows.Forms.Label
    Friend WithEvents rbCredito As System.Windows.Forms.RadioButton
    Friend WithEvents rbEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCaja As System.Windows.Forms.TextBox
    Friend WithEvents txtTiempoComida As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCajero As System.Windows.Forms.TextBox
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents lblTiempoComida As System.Windows.Forms.Label
    Friend WithEvents lblCodigoCajero As System.Windows.Forms.Label
    Friend WithEvents dtpFechaTrabajo As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtExistencias As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDisponible As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_correlativo As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents lblNumTicket As System.Windows.Forms.Label
    Friend WithEvents txtNumTicket As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetalleVenta As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents lb_notificacion1 As System.Windows.Forms.Label
    Friend WithEvents lb_notificacion2 As System.Windows.Forms.Label
    Friend WithEvents lblPayWay As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents lblEtiquetaAnulado As System.Windows.Forms.Label
    Friend WithEvents lblDispoCred As System.Windows.Forms.Label
    Friend WithEvents progressIdentify As System.Windows.Forms.ProgressBar
    Friend WithEvents btnHuella As System.Windows.Forms.Button
    Friend WithEvents txtMotivoBloqueo As System.Windows.Forms.TextBox
End Class
