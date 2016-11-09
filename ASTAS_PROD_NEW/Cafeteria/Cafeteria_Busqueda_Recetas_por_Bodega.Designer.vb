<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Busqueda_Recetas_por_Bodega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Busqueda_Recetas_por_Bodega))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtBodega_cod = New System.Windows.Forms.TextBox
        Me.Txt_Producto_codigo = New System.Windows.Forms.TextBox
        Me.Txt_Producto_descripcion = New System.Windows.Forms.TextBox
        Me.TxtCompañia_cod = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtCompañia = New System.Windows.Forms.TextBox
        Me.TxtBodega = New System.Windows.Forms.TextBox
        Me.btnBuscarProducto = New System.Windows.Forms.Button
        Me.Datagrid_productos = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Btn_limpiar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.Datagrid_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(5, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 20)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Código"
        '
        'TxtBodega_cod
        '
        Me.TxtBodega_cod.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBodega_cod.Enabled = False
        Me.TxtBodega_cod.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBodega_cod.ForeColor = System.Drawing.Color.Navy
        Me.TxtBodega_cod.Location = New System.Drawing.Point(442, 28)
        Me.TxtBodega_cod.MaxLength = 100
        Me.TxtBodega_cod.Name = "TxtBodega_cod"
        Me.TxtBodega_cod.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtBodega_cod.Size = New System.Drawing.Size(33, 22)
        Me.TxtBodega_cod.TabIndex = 100
        Me.TxtBodega_cod.Visible = False
        '
        'Txt_Producto_codigo
        '
        Me.Txt_Producto_codigo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_codigo.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_codigo.Location = New System.Drawing.Point(5, 32)
        Me.Txt_Producto_codigo.Name = "Txt_Producto_codigo"
        Me.Txt_Producto_codigo.Size = New System.Drawing.Size(50, 22)
        Me.Txt_Producto_codigo.TabIndex = 0
        '
        'Txt_Producto_descripcion
        '
        Me.Txt_Producto_descripcion.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Producto_descripcion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_descripcion.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_descripcion.Location = New System.Drawing.Point(55, 32)
        Me.Txt_Producto_descripcion.MaxLength = 100
        Me.Txt_Producto_descripcion.Name = "Txt_Producto_descripcion"
        Me.Txt_Producto_descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Producto_descripcion.Size = New System.Drawing.Size(365, 22)
        Me.Txt_Producto_descripcion.TabIndex = 1
        '
        'TxtCompañia_cod
        '
        Me.TxtCompañia_cod.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCompañia_cod.Enabled = False
        Me.TxtCompañia_cod.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCompañia_cod.ForeColor = System.Drawing.Color.Navy
        Me.TxtCompañia_cod.Location = New System.Drawing.Point(442, 6)
        Me.TxtCompañia_cod.MaxLength = 100
        Me.TxtCompañia_cod.Name = "TxtCompañia_cod"
        Me.TxtCompañia_cod.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtCompañia_cod.Size = New System.Drawing.Size(33, 22)
        Me.TxtCompañia_cod.TabIndex = 99
        Me.TxtCompañia_cod.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(2, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 16)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Bodega"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Teal
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(52, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(420, 20)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Descripción del producto"
        '
        'TxtCompañia
        '
        Me.TxtCompañia.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCompañia.Enabled = False
        Me.TxtCompañia.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCompañia.ForeColor = System.Drawing.Color.Navy
        Me.TxtCompañia.Location = New System.Drawing.Point(58, 6)
        Me.TxtCompañia.MaxLength = 100
        Me.TxtCompañia.Name = "TxtCompañia"
        Me.TxtCompañia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtCompañia.Size = New System.Drawing.Size(384, 22)
        Me.TxtCompañia.TabIndex = 97
        Me.TxtCompañia.Visible = False
        '
        'TxtBodega
        '
        Me.TxtBodega.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBodega.Enabled = False
        Me.TxtBodega.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBodega.ForeColor = System.Drawing.Color.Navy
        Me.TxtBodega.Location = New System.Drawing.Point(58, 28)
        Me.TxtBodega.MaxLength = 100
        Me.TxtBodega.Name = "TxtBodega"
        Me.TxtBodega.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtBodega.Size = New System.Drawing.Size(384, 22)
        Me.TxtBodega.TabIndex = 96
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarProducto.Location = New System.Drawing.Point(422, 32)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto.TabIndex = 2
        Me.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'Datagrid_productos
        '
        Me.Datagrid_productos.AllowUserToAddRows = False
        Me.Datagrid_productos.AllowUserToDeleteRows = False
        Me.Datagrid_productos.AllowUserToResizeColumns = False
        Me.Datagrid_productos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Datagrid_productos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Datagrid_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Datagrid_productos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Datagrid_productos.Location = New System.Drawing.Point(3, 118)
        Me.Datagrid_productos.Name = "Datagrid_productos"
        Me.Datagrid_productos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_productos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Datagrid_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datagrid_productos.Size = New System.Drawing.Size(478, 283)
        Me.Datagrid_productos.TabIndex = 95
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Btn_limpiar)
        Me.GroupBox1.Controls.Add(Me.btnBuscarProducto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Txt_Producto_codigo)
        Me.GroupBox1.Controls.Add(Me.Txt_Producto_descripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(478, 59)
        Me.GroupBox1.TabIndex = 94
        Me.GroupBox1.TabStop = False
        '
        'Btn_limpiar
        '
        Me.Btn_limpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btn_limpiar.Image = CType(resources.GetObject("Btn_limpiar.Image"), System.Drawing.Image)
        Me.Btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_limpiar.Location = New System.Drawing.Point(448, 32)
        Me.Btn_limpiar.Name = "Btn_limpiar"
        Me.Btn_limpiar.Size = New System.Drawing.Size(24, 24)
        Me.Btn_limpiar.TabIndex = 3
        Me.Btn_limpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_limpiar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Compañía"
        Me.Label1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(59, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(189, 25)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "C  A  F  E  T  E  R  I  A"
        '
        'Cafeteria_Busqueda_Recetas_por_Bodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 406)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtBodega_cod)
        Me.Controls.Add(Me.TxtCompañia_cod)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtCompañia)
        Me.Controls.Add(Me.TxtBodega)
        Me.Controls.Add(Me.Datagrid_productos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Cafeteria_Busqueda_Recetas_por_Bodega"
        Me.Text = "Cafeteria_Busqueda_Recetas_por_Bodega"
        CType(Me.Datagrid_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtBodega_cod As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Producto_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Producto_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents TxtCompañia_cod As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents TxtBodega As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents Datagrid_productos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_limpiar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
