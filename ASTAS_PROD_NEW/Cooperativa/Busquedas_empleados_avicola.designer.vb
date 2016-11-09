<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Busquedas_empleados_avicola
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Busquedas_empleados_avicola))
        Me.CbxDepartamento = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CbxCompania = New System.Windows.Forms.ComboBox
        Me.DgvSocios = New System.Windows.Forms.DataGridView
        Me.GbxCriterioBusq = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.TxtDui = New System.Windows.Forms.TextBox
        Me.BtnBuscarSoc = New System.Windows.Forms.Button
        Me.TxtTelefono = New System.Windows.Forms.TextBox
        CType(Me.DgvSocios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxCriterioBusq.SuspendLayout()
        Me.SuspendLayout()
        '
        'CbxDepartamento
        '
        Me.CbxDepartamento.DisplayMember = "999"
        Me.CbxDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxDepartamento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxDepartamento.ForeColor = System.Drawing.Color.Navy
        Me.CbxDepartamento.FormattingEnabled = True
        Me.CbxDepartamento.Location = New System.Drawing.Point(81, 48)
        Me.CbxDepartamento.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxDepartamento.Name = "CbxDepartamento"
        Me.CbxDepartamento.Size = New System.Drawing.Size(295, 24)
        Me.CbxDepartamento.TabIndex = 16
        Me.CbxDepartamento.ValueMember = "999"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Departamento"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(8, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(501, 20)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Nombre del Socio                                                                 " & _
            "DUI                         Teléfono"
        '
        'CbxCompania
        '
        Me.CbxCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCompania.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbxCompania.ForeColor = System.Drawing.Color.Navy
        Me.CbxCompania.FormattingEnabled = True
        Me.CbxCompania.Location = New System.Drawing.Point(81, 24)
        Me.CbxCompania.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxCompania.Name = "CbxCompania"
        Me.CbxCompania.Size = New System.Drawing.Size(414, 24)
        Me.CbxCompania.TabIndex = 19
        '
        'DgvSocios
        '
        Me.DgvSocios.AllowUserToAddRows = False
        Me.DgvSocios.AllowUserToDeleteRows = False
        Me.DgvSocios.AllowUserToResizeColumns = False
        Me.DgvSocios.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvSocios.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvSocios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSocios.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvSocios.Location = New System.Drawing.Point(8, 144)
        Me.DgvSocios.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DgvSocios.MultiSelect = False
        Me.DgvSocios.Name = "DgvSocios"
        Me.DgvSocios.ReadOnly = True
        Me.DgvSocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSocios.Size = New System.Drawing.Size(724, 344)
        Me.DgvSocios.TabIndex = 19
        '
        'GbxCriterioBusq
        '
        Me.GbxCriterioBusq.Controls.Add(Me.CbxCompania)
        Me.GbxCriterioBusq.Controls.Add(Me.Label2)
        Me.GbxCriterioBusq.Controls.Add(Me.CbxDepartamento)
        Me.GbxCriterioBusq.Controls.Add(Me.Label3)
        Me.GbxCriterioBusq.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCriterioBusq.ForeColor = System.Drawing.Color.Navy
        Me.GbxCriterioBusq.Location = New System.Drawing.Point(8, 8)
        Me.GbxCriterioBusq.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCriterioBusq.Name = "GbxCriterioBusq"
        Me.GbxCriterioBusq.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCriterioBusq.Size = New System.Drawing.Size(501, 80)
        Me.GbxCriterioBusq.TabIndex = 20
        Me.GbxCriterioBusq.TabStop = False
        Me.GbxCriterioBusq.Text = "Filtros"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Compañia"
        '
        'TxtNombre
        '
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.ForeColor = System.Drawing.Color.Navy
        Me.TxtNombre.Location = New System.Drawing.Point(8, 120)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(288, 22)
        Me.TxtNombre.TabIndex = 21
        '
        'TxtDui
        '
        Me.TxtDui.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDui.ForeColor = System.Drawing.Color.Navy
        Me.TxtDui.Location = New System.Drawing.Point(296, 120)
        Me.TxtDui.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtDui.Name = "TxtDui"
        Me.TxtDui.Size = New System.Drawing.Size(96, 22)
        Me.TxtDui.TabIndex = 23
        '
        'BtnBuscarSoc
        '
        Me.BtnBuscarSoc.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarSoc.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSoc.Image = CType(resources.GetObject("BtnBuscarSoc.Image"), System.Drawing.Image)
        Me.BtnBuscarSoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSoc.Location = New System.Drawing.Point(488, 120)
        Me.BtnBuscarSoc.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnBuscarSoc.Name = "BtnBuscarSoc"
        Me.BtnBuscarSoc.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarSoc.TabIndex = 22
        Me.BtnBuscarSoc.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnBuscarSoc.UseVisualStyleBackColor = True
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTelefono.ForeColor = System.Drawing.Color.Navy
        Me.TxtTelefono.Location = New System.Drawing.Point(392, 120)
        Me.TxtTelefono.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(96, 22)
        Me.TxtTelefono.TabIndex = 24
        '
        'Busquedas_empleados_avicola
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 490)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DgvSocios)
        Me.Controls.Add(Me.GbxCriterioBusq)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.TxtDui)
        Me.Controls.Add(Me.BtnBuscarSoc)
        Me.Controls.Add(Me.TxtTelefono)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Busquedas_empleados_avicola"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Búsqueda  de Empleados"
        CType(Me.DgvSocios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxCriterioBusq.ResumeLayout(False)
        Me.GbxCriterioBusq.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CbxDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CbxCompania As System.Windows.Forms.ComboBox
    Friend WithEvents DgvSocios As System.Windows.Forms.DataGridView
    Friend WithEvents GbxCriterioBusq As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtDui As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarSoc As System.Windows.Forms.Button
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
End Class
