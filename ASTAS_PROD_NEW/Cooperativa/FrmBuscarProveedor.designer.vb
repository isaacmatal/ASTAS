<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscarProveedor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscarProveedor))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BtnBuscarProv = New System.Windows.Forms.Button
        Me.GbxCriterioBusq = New System.Windows.Forms.GroupBox
        Me.CbxCompania = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtCodigoAsta = New System.Windows.Forms.TextBox
        Me.TxtCodigoProv = New System.Windows.Forms.TextBox
        Me.TxtNrc = New System.Windows.Forms.TextBox
        Me.TxtNit = New System.Windows.Forms.TextBox
        Me.TxtProveedor = New System.Windows.Forms.TextBox
        Me.DgvProveedor = New System.Windows.Forms.DataGridView
        Me.txtComercial = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.GbxCriterioBusq.SuspendLayout()
        CType(Me.DgvProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnBuscarProv
        '
        Me.BtnBuscarProv.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarProv.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarProv.Image = CType(resources.GetObject("BtnBuscarProv.Image"), System.Drawing.Image)
        Me.BtnBuscarProv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarProv.Location = New System.Drawing.Point(890, 74)
        Me.BtnBuscarProv.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnBuscarProv.Name = "BtnBuscarProv"
        Me.BtnBuscarProv.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarProv.TabIndex = 15
        Me.BtnBuscarProv.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnBuscarProv.UseVisualStyleBackColor = True
        '
        'GbxCriterioBusq
        '
        Me.GbxCriterioBusq.BackColor = System.Drawing.Color.Transparent
        Me.GbxCriterioBusq.Controls.Add(Me.Label14)
        Me.GbxCriterioBusq.Controls.Add(Me.Label7)
        Me.GbxCriterioBusq.Controls.Add(Me.Label6)
        Me.GbxCriterioBusq.Controls.Add(Me.Label5)
        Me.GbxCriterioBusq.Controls.Add(Me.Label3)
        Me.GbxCriterioBusq.Controls.Add(Me.Label2)
        Me.GbxCriterioBusq.Controls.Add(Me.Label1)
        Me.GbxCriterioBusq.Controls.Add(Me.txtComercial)
        Me.GbxCriterioBusq.Controls.Add(Me.CbxCompania)
        Me.GbxCriterioBusq.Controls.Add(Me.Label4)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtCodigoAsta)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtProveedor)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtNrc)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtNit)
        Me.GbxCriterioBusq.Controls.Add(Me.BtnBuscarProv)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtCodigoProv)
        Me.GbxCriterioBusq.Dock = System.Windows.Forms.DockStyle.Top
        Me.GbxCriterioBusq.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCriterioBusq.ForeColor = System.Drawing.Color.Navy
        Me.GbxCriterioBusq.Location = New System.Drawing.Point(0, 0)
        Me.GbxCriterioBusq.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCriterioBusq.Name = "GbxCriterioBusq"
        Me.GbxCriterioBusq.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCriterioBusq.Size = New System.Drawing.Size(915, 101)
        Me.GbxCriterioBusq.TabIndex = 13
        Me.GbxCriterioBusq.TabStop = False
        Me.GbxCriterioBusq.Text = "Filtros"
        '
        'CbxCompania
        '
        Me.CbxCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCompania.FormattingEnabled = True
        Me.CbxCompania.Location = New System.Drawing.Point(88, 24)
        Me.CbxCompania.Name = "CbxCompania"
        Me.CbxCompania.Size = New System.Drawing.Size(532, 24)
        Me.CbxCompania.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Compañia:"
        '
        'TxtCodigoAsta
        '
        Me.TxtCodigoAsta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodigoAsta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoAsta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtCodigoAsta.Location = New System.Drawing.Point(801, 75)
        Me.TxtCodigoAsta.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtCodigoAsta.Name = "TxtCodigoAsta"
        Me.TxtCodigoAsta.Size = New System.Drawing.Size(88, 22)
        Me.TxtCodigoAsta.TabIndex = 24
        '
        'TxtCodigoProv
        '
        Me.TxtCodigoProv.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoProv.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtCodigoProv.Location = New System.Drawing.Point(8, 75)
        Me.TxtCodigoProv.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtCodigoProv.Name = "TxtCodigoProv"
        Me.TxtCodigoProv.Size = New System.Drawing.Size(72, 22)
        Me.TxtCodigoProv.TabIndex = 22
        '
        'TxtNrc
        '
        Me.TxtNrc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNrc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNrc.Location = New System.Drawing.Point(711, 75)
        Me.TxtNrc.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtNrc.Name = "TxtNrc"
        Me.TxtNrc.Size = New System.Drawing.Size(88, 22)
        Me.TxtNrc.TabIndex = 23
        '
        'TxtNit
        '
        Me.TxtNit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNit.Location = New System.Drawing.Point(611, 75)
        Me.TxtNit.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtNit.Name = "TxtNit"
        Me.TxtNit.Size = New System.Drawing.Size(99, 22)
        Me.TxtNit.TabIndex = 21
        '
        'TxtProveedor
        '
        Me.TxtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtProveedor.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtProveedor.Location = New System.Drawing.Point(80, 75)
        Me.TxtProveedor.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.Size = New System.Drawing.Size(264, 22)
        Me.TxtProveedor.TabIndex = 9
        '
        'DgvProveedor
        '
        Me.DgvProveedor.AllowUserToAddRows = False
        Me.DgvProveedor.AllowUserToDeleteRows = False
        Me.DgvProveedor.AllowUserToResizeColumns = False
        Me.DgvProveedor.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvProveedor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvProveedor.BackgroundColor = System.Drawing.Color.White
        Me.DgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvProveedor.DefaultCellStyle = DataGridViewCellStyle6
        Me.DgvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvProveedor.Location = New System.Drawing.Point(0, 101)
        Me.DgvProveedor.MultiSelect = False
        Me.DgvProveedor.Name = "DgvProveedor"
        Me.DgvProveedor.ReadOnly = True
        Me.DgvProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProveedor.Size = New System.Drawing.Size(915, 431)
        Me.DgvProveedor.TabIndex = 16
        '
        'txtComercial
        '
        Me.txtComercial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComercial.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComercial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtComercial.Location = New System.Drawing.Point(346, 75)
        Me.txtComercial.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtComercial.Name = "txtComercial"
        Me.txtComercial.Size = New System.Drawing.Size(264, 22)
        Me.txtComercial.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Teal
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(8, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Código"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Teal
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(77, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(277, 20)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Nombre del Proveedor"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(343, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(267, 20)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Nombre Comercial"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(608, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 20)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "NIT"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Teal
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(708, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 20)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "NRC"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Teal
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(798, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 20)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "COD ASTAS"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(626, 27)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(129, 16)
        Me.Label14.TabIndex = 112
        Me.Label14.Text = "Revisado 20/05/2014"
        '
        'FrmBuscarProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 532)
        Me.Controls.Add(Me.DgvProveedor)
        Me.Controls.Add(Me.GbxCriterioBusq)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmBuscarProveedor"
        Me.Opacity = 0.8
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Cooperativa - Búsqueda de Proveedores"
        Me.GbxCriterioBusq.ResumeLayout(False)
        Me.GbxCriterioBusq.PerformLayout()
        CType(Me.DgvProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnBuscarProv As System.Windows.Forms.Button
    Friend WithEvents GbxCriterioBusq As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCodigoAsta As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoProv As System.Windows.Forms.TextBox
    Friend WithEvents TxtNrc As System.Windows.Forms.TextBox
    Friend WithEvents TxtNit As System.Windows.Forms.TextBox
    Friend WithEvents TxtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents CbxCompania As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DgvProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents txtComercial As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
