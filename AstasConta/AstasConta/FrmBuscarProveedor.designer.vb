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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BtnBuscarProv = New System.Windows.Forms.Button
        Me.GbxCriterioBusq = New System.Windows.Forms.GroupBox
        Me.TxtCodigoAsta = New System.Windows.Forms.TextBox
        Me.TxtCodigoProv = New System.Windows.Forms.TextBox
        Me.TxtNrc = New System.Windows.Forms.TextBox
        Me.TxtNit = New System.Windows.Forms.TextBox
        Me.TxtProveedor = New System.Windows.Forms.TextBox
        Me.DgvProveedor = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtComercial = New System.Windows.Forms.TextBox
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
        Me.BtnBuscarProv.Location = New System.Drawing.Point(881, 42)
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
        Me.GbxCriterioBusq.Controls.Add(Me.txtComercial)
        Me.GbxCriterioBusq.Controls.Add(Me.Label7)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtProveedor)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtNit)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtCodigoAsta)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtCodigoProv)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtNrc)
        Me.GbxCriterioBusq.Controls.Add(Me.BtnBuscarProv)
        Me.GbxCriterioBusq.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCriterioBusq.ForeColor = System.Drawing.Color.Navy
        Me.GbxCriterioBusq.Location = New System.Drawing.Point(8, 8)
        Me.GbxCriterioBusq.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCriterioBusq.Name = "GbxCriterioBusq"
        Me.GbxCriterioBusq.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCriterioBusq.Size = New System.Drawing.Size(912, 73)
        Me.GbxCriterioBusq.TabIndex = 13
        Me.GbxCriterioBusq.TabStop = False
        Me.GbxCriterioBusq.Text = "Filtros"
        '
        'TxtCodigoAsta
        '
        Me.TxtCodigoAsta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodigoAsta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoAsta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtCodigoAsta.Location = New System.Drawing.Point(798, 43)
        Me.TxtCodigoAsta.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtCodigoAsta.Name = "TxtCodigoAsta"
        Me.TxtCodigoAsta.Size = New System.Drawing.Size(83, 22)
        Me.TxtCodigoAsta.TabIndex = 24
        '
        'TxtCodigoProv
        '
        Me.TxtCodigoProv.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoProv.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtCodigoProv.Location = New System.Drawing.Point(5, 43)
        Me.TxtCodigoProv.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtCodigoProv.Name = "TxtCodigoProv"
        Me.TxtCodigoProv.Size = New System.Drawing.Size(72, 22)
        Me.TxtCodigoProv.TabIndex = 22
        '
        'TxtNrc
        '
        Me.TxtNrc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNrc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNrc.Location = New System.Drawing.Point(708, 43)
        Me.TxtNrc.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtNrc.Name = "TxtNrc"
        Me.TxtNrc.Size = New System.Drawing.Size(88, 22)
        Me.TxtNrc.TabIndex = 23
        '
        'TxtNit
        '
        Me.TxtNit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNit.Location = New System.Drawing.Point(608, 43)
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
        Me.TxtProveedor.Location = New System.Drawing.Point(77, 43)
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
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvProveedor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvProveedor.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvProveedor.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgvProveedor.Location = New System.Drawing.Point(13, 88)
        Me.DgvProveedor.MultiSelect = False
        Me.DgvProveedor.Name = "DgvProveedor"
        Me.DgvProveedor.ReadOnly = True
        Me.DgvProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProveedor.Size = New System.Drawing.Size(901, 432)
        Me.DgvProveedor.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(5, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(875, 20)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = resources.GetString("Label7.Text")
        '
        'txtComercial
        '
        Me.txtComercial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComercial.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComercial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtComercial.Location = New System.Drawing.Point(343, 43)
        Me.txtComercial.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtComercial.Name = "txtComercial"
        Me.txtComercial.Size = New System.Drawing.Size(264, 22)
        Me.txtComercial.TabIndex = 26
        '
        'FrmBuscarProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 532)
        Me.Controls.Add(Me.DgvProveedor)
        Me.Controls.Add(Me.GbxCriterioBusq)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmBuscarProveedor"
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
    Friend WithEvents DgvProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtComercial As System.Windows.Forms.TextBox
End Class
