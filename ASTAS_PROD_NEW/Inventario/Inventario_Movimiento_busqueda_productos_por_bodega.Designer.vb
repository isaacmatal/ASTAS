<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Movimiento_busqueda_productos_por_bodega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Movimiento_busqueda_productos_por_bodega))
        Me.Datagrid_productos = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_Codigo = New System.Windows.Forms.TextBox
        Me.Txt_Producto_descripcion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtBodega = New System.Windows.Forms.TextBox
        Me.TxtCompañia = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtCompañia_cod = New System.Windows.Forms.TextBox
        Me.TxtBodega_cod = New System.Windows.Forms.TextBox
        CType(Me.Datagrid_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Datagrid_productos
        '
        Me.Datagrid_productos.AllowUserToAddRows = False
        Me.Datagrid_productos.AllowUserToDeleteRows = False
        Me.Datagrid_productos.AllowUserToResizeColumns = False
        Me.Datagrid_productos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Datagrid_productos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Datagrid_productos.BackgroundColor = System.Drawing.Color.White
        Me.Datagrid_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Datagrid_productos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Datagrid_productos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Datagrid_productos.GridColor = System.Drawing.SystemColors.Control
        Me.Datagrid_productos.Location = New System.Drawing.Point(0, 109)
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
        Me.Datagrid_productos.Size = New System.Drawing.Size(482, 295)
        Me.Datagrid_productos.TabIndex = 87
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Txt_Codigo)
        Me.GroupBox1.Controls.Add(Me.Txt_Producto_descripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(480, 59)
        Me.GroupBox1.TabIndex = 86
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Teal
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(109, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(363, 20)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Descripción del producto"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(4, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 20)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Codigo"
        '
        'Txt_Codigo
        '
        Me.Txt_Codigo.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Codigo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Codigo.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Codigo.Location = New System.Drawing.Point(4, 31)
        Me.Txt_Codigo.MaxLength = 100
        Me.Txt_Codigo.Name = "Txt_Codigo"
        Me.Txt_Codigo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Codigo.Size = New System.Drawing.Size(99, 22)
        Me.Txt_Codigo.TabIndex = 1
        '
        'Txt_Producto_descripcion
        '
        Me.Txt_Producto_descripcion.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Producto_descripcion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_descripcion.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_descripcion.Location = New System.Drawing.Point(109, 31)
        Me.Txt_Producto_descripcion.MaxLength = 100
        Me.Txt_Producto_descripcion.Name = "Txt_Producto_descripcion"
        Me.Txt_Producto_descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Producto_descripcion.Size = New System.Drawing.Size(363, 22)
        Me.Txt_Producto_descripcion.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(1, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Compañía"
        '
        'TxtBodega
        '
        Me.TxtBodega.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBodega.Enabled = False
        Me.TxtBodega.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBodega.ForeColor = System.Drawing.Color.Navy
        Me.TxtBodega.Location = New System.Drawing.Point(57, 25)
        Me.TxtBodega.MaxLength = 100
        Me.TxtBodega.Name = "TxtBodega"
        Me.TxtBodega.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtBodega.Size = New System.Drawing.Size(384, 22)
        Me.TxtBodega.TabIndex = 88
        '
        'TxtCompañia
        '
        Me.TxtCompañia.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCompañia.Enabled = False
        Me.TxtCompañia.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCompañia.ForeColor = System.Drawing.Color.Navy
        Me.TxtCompañia.Location = New System.Drawing.Point(57, 3)
        Me.TxtCompañia.MaxLength = 100
        Me.TxtCompañia.Name = "TxtCompañia"
        Me.TxtCompañia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtCompañia.Size = New System.Drawing.Size(384, 22)
        Me.TxtCompañia.TabIndex = 89
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(1, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 16)
        Me.Label5.TabIndex = 90
        Me.Label5.Text = "Bodega"
        '
        'TxtCompañia_cod
        '
        Me.TxtCompañia_cod.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCompañia_cod.Enabled = False
        Me.TxtCompañia_cod.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCompañia_cod.ForeColor = System.Drawing.Color.Navy
        Me.TxtCompañia_cod.Location = New System.Drawing.Point(441, 3)
        Me.TxtCompañia_cod.MaxLength = 100
        Me.TxtCompañia_cod.Name = "TxtCompañia_cod"
        Me.TxtCompañia_cod.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtCompañia_cod.Size = New System.Drawing.Size(33, 22)
        Me.TxtCompañia_cod.TabIndex = 91
        Me.TxtCompañia_cod.Visible = False
        '
        'TxtBodega_cod
        '
        Me.TxtBodega_cod.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBodega_cod.Enabled = False
        Me.TxtBodega_cod.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBodega_cod.ForeColor = System.Drawing.Color.Navy
        Me.TxtBodega_cod.Location = New System.Drawing.Point(441, 25)
        Me.TxtBodega_cod.MaxLength = 100
        Me.TxtBodega_cod.Name = "TxtBodega_cod"
        Me.TxtBodega_cod.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtBodega_cod.Size = New System.Drawing.Size(33, 22)
        Me.TxtBodega_cod.TabIndex = 92
        Me.TxtBodega_cod.Visible = False
        '
        'Inventario_Movimiento_busqueda_productos_por_bodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 404)
        Me.Controls.Add(Me.TxtBodega_cod)
        Me.Controls.Add(Me.TxtCompañia_cod)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtCompañia)
        Me.Controls.Add(Me.TxtBodega)
        Me.Controls.Add(Me.Datagrid_productos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Inventario_Movimiento_busqueda_productos_por_bodega"
        Me.Opacity = 0.75
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario_Movimiento_busqueda_productos_por_bodega"
        CType(Me.Datagrid_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Datagrid_productos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_Producto_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBodega As System.Windows.Forms.TextBox
    Friend WithEvents TxtCompañia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCompañia_cod As System.Windows.Forms.TextBox
    Friend WithEvents TxtBodega_cod As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_Codigo As System.Windows.Forms.TextBox
End Class
