<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscarSocios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscarSocios))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GbxCriterioBusq = New System.Windows.Forms.GroupBox
        Me.TxtNit = New System.Windows.Forms.TextBox
        Me.CbxDepartamento = New System.Windows.Forms.ComboBox
        Me.TxtBuxi = New System.Windows.Forms.TextBox
        Me.TxtAs = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDui = New System.Windows.Forms.TextBox
        Me.BtnBuscarSoc = New System.Windows.Forms.Button
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        Me.DgvSocios = New System.Windows.Forms.DataGridView
        Me.GbxCriterioBusq.SuspendLayout()
        CType(Me.DgvSocios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GbxCriterioBusq
        '
        Me.GbxCriterioBusq.BackColor = System.Drawing.Color.Transparent
        Me.GbxCriterioBusq.Controls.Add(Me.TxtNit)
        Me.GbxCriterioBusq.Controls.Add(Me.CbxDepartamento)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtBuxi)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtAs)
        Me.GbxCriterioBusq.Controls.Add(Me.Label3)
        Me.GbxCriterioBusq.Controls.Add(Me.Label4)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtDui)
        Me.GbxCriterioBusq.Controls.Add(Me.BtnBuscarSoc)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtNombre)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtTelefono)
        Me.GbxCriterioBusq.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCriterioBusq.ForeColor = System.Drawing.Color.Navy
        Me.GbxCriterioBusq.Location = New System.Drawing.Point(8, 8)
        Me.GbxCriterioBusq.Name = "GbxCriterioBusq"
        Me.GbxCriterioBusq.Size = New System.Drawing.Size(767, 101)
        Me.GbxCriterioBusq.TabIndex = 3
        Me.GbxCriterioBusq.TabStop = False
        Me.GbxCriterioBusq.Text = "Filtros"
        '
        'TxtNit
        '
        Me.TxtNit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNit.Location = New System.Drawing.Point(564, 72)
        Me.TxtNit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNit.Name = "TxtNit"
        Me.TxtNit.Size = New System.Drawing.Size(82, 22)
        Me.TxtNit.TabIndex = 4
        '
        'CbxDepartamento
        '
        Me.CbxDepartamento.DisplayMember = "999"
        Me.CbxDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxDepartamento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxDepartamento.ForeColor = System.Drawing.Color.Navy
        Me.CbxDepartamento.FormattingEnabled = True
        Me.CbxDepartamento.Location = New System.Drawing.Point(88, 17)
        Me.CbxDepartamento.Name = "CbxDepartamento"
        Me.CbxDepartamento.Size = New System.Drawing.Size(376, 24)
        Me.CbxDepartamento.TabIndex = 16
        Me.CbxDepartamento.ValueMember = "999"
        '
        'TxtBuxi
        '
        Me.TxtBuxi.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuxi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtBuxi.Location = New System.Drawing.Point(6, 72)
        Me.TxtBuxi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtBuxi.Name = "TxtBuxi"
        Me.TxtBuxi.Size = New System.Drawing.Size(82, 22)
        Me.TxtBuxi.TabIndex = 0
        '
        'TxtAs
        '
        Me.TxtAs.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtAs.Location = New System.Drawing.Point(93, 72)
        Me.TxtAs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtAs.Name = "TxtAs"
        Me.TxtAs.Size = New System.Drawing.Size(82, 22)
        Me.TxtAs.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Departamento:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(6, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(728, 20)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Codigo Buxi        Codigo AS          Nombre del Socio                           " & _
            "                     DUI               NIT            Teléfono"
        '
        'TxtDui
        '
        Me.TxtDui.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDui.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtDui.Location = New System.Drawing.Point(476, 72)
        Me.TxtDui.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtDui.Name = "TxtDui"
        Me.TxtDui.Size = New System.Drawing.Size(82, 22)
        Me.TxtDui.TabIndex = 3
        '
        'BtnBuscarSoc
        '
        Me.BtnBuscarSoc.BackColor = System.Drawing.Color.Transparent
        Me.BtnBuscarSoc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarSoc.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSoc.Image = CType(resources.GetObject("BtnBuscarSoc.Image"), System.Drawing.Image)
        Me.BtnBuscarSoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSoc.Location = New System.Drawing.Point(738, 70)
        Me.BtnBuscarSoc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscarSoc.Name = "BtnBuscarSoc"
        Me.BtnBuscarSoc.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarSoc.TabIndex = 6
        Me.BtnBuscarSoc.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnBuscarSoc.UseVisualStyleBackColor = False
        '
        'TxtNombre
        '
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNombre.Location = New System.Drawing.Point(182, 72)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(288, 22)
        Me.TxtNombre.TabIndex = 2
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTelefono.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtTelefono.Location = New System.Drawing.Point(652, 72)
        Me.TxtTelefono.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(82, 22)
        Me.TxtTelefono.TabIndex = 5
        '
        'DgvSocios
        '
        Me.DgvSocios.AllowUserToAddRows = False
        Me.DgvSocios.AllowUserToDeleteRows = False
        Me.DgvSocios.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvSocios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvSocios.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSocios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSocios.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvSocios.Location = New System.Drawing.Point(8, 113)
        Me.DgvSocios.MultiSelect = False
        Me.DgvSocios.Name = "DgvSocios"
        Me.DgvSocios.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSocios.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvSocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSocios.Size = New System.Drawing.Size(776, 416)
        Me.DgvSocios.TabIndex = 0
        '
        'FrmBuscarSocios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 533)
        Me.Controls.Add(Me.DgvSocios)
        Me.Controls.Add(Me.GbxCriterioBusq)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmBuscarSocios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Búsqueda de Socios"
        Me.GbxCriterioBusq.ResumeLayout(False)
        Me.GbxCriterioBusq.PerformLayout()
        CType(Me.DgvSocios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GbxCriterioBusq As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscarSoc As System.Windows.Forms.Button
    Friend WithEvents CbxDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents TxtDui As System.Windows.Forms.TextBox
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents DgvSocios As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtAs As System.Windows.Forms.TextBox
    Friend WithEvents TxtBuxi As System.Windows.Forms.TextBox
    Friend WithEvents TxtNit As System.Windows.Forms.TextBox
End Class
