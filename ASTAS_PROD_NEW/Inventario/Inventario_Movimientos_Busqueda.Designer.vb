<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventario_Movimientos_Busqueda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventario_Movimientos_Busqueda))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_Producto_descripcion = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_Producto_codigo = New System.Windows.Forms.TextBox
        Me.cmbGRUPO = New System.Windows.Forms.ComboBox
        Me.cmbSUBGRUPO = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnBuscarProducto = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Datagrid_productos = New System.Windows.Forms.DataGridView
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCompañia = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.Datagrid_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Compañía"
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
        Me.Txt_Producto_descripcion.Size = New System.Drawing.Size(270, 22)
        Me.Txt_Producto_descripcion.TabIndex = 57
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
        'Txt_Producto_codigo
        '
        Me.Txt_Producto_codigo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto_codigo.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Producto_codigo.Location = New System.Drawing.Point(5, 32)
        Me.Txt_Producto_codigo.Name = "Txt_Producto_codigo"
        Me.Txt_Producto_codigo.ReadOnly = True
        Me.Txt_Producto_codigo.Size = New System.Drawing.Size(50, 22)
        Me.Txt_Producto_codigo.TabIndex = 56
        '
        'cmbGRUPO
        '
        Me.cmbGRUPO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGRUPO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGRUPO.ForeColor = System.Drawing.Color.Navy
        Me.cmbGRUPO.FormattingEnabled = True
        Me.cmbGRUPO.Items.AddRange(New Object() {"POLLO", "HUEVO", "ROPA CABALLEROS"})
        Me.cmbGRUPO.Location = New System.Drawing.Point(377, 31)
        Me.cmbGRUPO.Name = "cmbGRUPO"
        Me.cmbGRUPO.Size = New System.Drawing.Size(200, 24)
        Me.cmbGRUPO.TabIndex = 59
        '
        'cmbSUBGRUPO
        '
        Me.cmbSUBGRUPO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSUBGRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSUBGRUPO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSUBGRUPO.ForeColor = System.Drawing.Color.Navy
        Me.cmbSUBGRUPO.FormattingEnabled = True
        Me.cmbSUBGRUPO.Location = New System.Drawing.Point(576, 31)
        Me.cmbSUBGRUPO.Name = "cmbSUBGRUPO"
        Me.cmbSUBGRUPO.Size = New System.Drawing.Size(200, 24)
        Me.cmbSUBGRUPO.TabIndex = 60
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.btnBuscarProducto)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbGRUPO)
        Me.GroupBox1.Controls.Add(Me.Txt_Producto_codigo)
        Me.GroupBox1.Controls.Add(Me.cmbSUBGRUPO)
        Me.GroupBox1.Controls.Add(Me.Txt_Producto_descripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(781, 59)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(352, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 84
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button1, "Limpiar caja de texto")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarProducto.Location = New System.Drawing.Point(326, 31)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarProducto.TabIndex = 81
        Me.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscarProducto, "Buscar productos")
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(573, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(203, 20)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Sub Grupo"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(374, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(203, 20)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Grupo"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Teal
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(52, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(325, 20)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Descripción del producto"
        '
        'Datagrid_productos
        '
        Me.Datagrid_productos.AllowUserToAddRows = False
        Me.Datagrid_productos.AllowUserToDeleteRows = False
        Me.Datagrid_productos.AllowUserToResizeColumns = False
        Me.Datagrid_productos.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Datagrid_productos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Datagrid_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Datagrid_productos.DefaultCellStyle = DataGridViewCellStyle5
        Me.Datagrid_productos.Location = New System.Drawing.Point(4, 93)
        Me.Datagrid_productos.Name = "Datagrid_productos"
        Me.Datagrid_productos.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Datagrid_productos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.Datagrid_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Datagrid_productos.Size = New System.Drawing.Size(781, 283)
        Me.Datagrid_productos.TabIndex = 83
        '
        'txtCompañia
        '
        Me.txtCompañia.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCompañia.Location = New System.Drawing.Point(59, 9)
        Me.txtCompañia.Name = "txtCompañia"
        Me.txtCompañia.ReadOnly = True
        Me.txtCompañia.Size = New System.Drawing.Size(473, 20)
        Me.txtCompañia.TabIndex = 85
        '
        'Inventario_Movimientos_Busqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 378)
        Me.Controls.Add(Me.txtCompañia)
        Me.Controls.Add(Me.Datagrid_productos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Inventario_Movimientos_Busqueda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Movimientos de Inventarios - Busqueda"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Datagrid_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Producto_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_Producto_codigo As System.Windows.Forms.TextBox
    Friend WithEvents cmbGRUPO As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSUBGRUPO As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents Datagrid_productos As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtCompañia As System.Windows.Forms.TextBox
End Class
