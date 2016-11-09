<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaSolicitudesCalzado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusquedaSolicitudesCalzado))
        Me.Label7 = New System.Windows.Forms.Label
        Me.DgvSolicitudes = New System.Windows.Forms.DataGridView
        Me.TxtNumSolicitud = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GbxCriterioBusq = New System.Windows.Forms.GroupBox
        Me.CbxCompañia = New System.Windows.Forms.ComboBox
        Me.TxtCodigoBuxis = New System.Windows.Forms.TextBox
        Me.BtnBuscarSolicitudes = New System.Windows.Forms.Button
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.TxtCodigoAs = New System.Windows.Forms.TextBox
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxCriterioBusq.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Teal
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(4, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(608, 20)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "N° Solicitud            Código AS             Código Buxis       Nombre del Socio" & _
            ""
        '
        'DgvSolicitudes
        '
        Me.DgvSolicitudes.AllowUserToAddRows = False
        Me.DgvSolicitudes.AllowUserToDeleteRows = False
        Me.DgvSolicitudes.AllowUserToResizeColumns = False
        Me.DgvSolicitudes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvSolicitudes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSolicitudes.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvSolicitudes.Location = New System.Drawing.Point(4, 112)
        Me.DgvSolicitudes.MultiSelect = False
        Me.DgvSolicitudes.Name = "DgvSolicitudes"
        Me.DgvSolicitudes.ReadOnly = True
        Me.DgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSolicitudes.Size = New System.Drawing.Size(712, 408)
        Me.DgvSolicitudes.TabIndex = 32
        '
        'TxtNumSolicitud
        '
        Me.TxtNumSolicitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumSolicitud.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNumSolicitud.Location = New System.Drawing.Point(3, 88)
        Me.TxtNumSolicitud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtNumSolicitud.Name = "TxtNumSolicitud"
        Me.TxtNumSolicitud.Size = New System.Drawing.Size(99, 22)
        Me.TxtNumSolicitud.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Compañia:"
        '
        'GbxCriterioBusq
        '
        Me.GbxCriterioBusq.Controls.Add(Me.CbxCompañia)
        Me.GbxCriterioBusq.Controls.Add(Me.Label3)
        Me.GbxCriterioBusq.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCriterioBusq.ForeColor = System.Drawing.Color.Navy
        Me.GbxCriterioBusq.Location = New System.Drawing.Point(4, 0)
        Me.GbxCriterioBusq.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCriterioBusq.Name = "GbxCriterioBusq"
        Me.GbxCriterioBusq.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCriterioBusq.Size = New System.Drawing.Size(480, 56)
        Me.GbxCriterioBusq.TabIndex = 30
        Me.GbxCriterioBusq.TabStop = False
        Me.GbxCriterioBusq.Text = "Filtros"
        '
        'CbxCompañia
        '
        Me.CbxCompañia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCompañia.FormattingEnabled = True
        Me.CbxCompañia.Location = New System.Drawing.Point(88, 24)
        Me.CbxCompañia.Name = "CbxCompañia"
        Me.CbxCompañia.Size = New System.Drawing.Size(384, 24)
        Me.CbxCompañia.TabIndex = 22
        '
        'TxtCodigoBuxis
        '
        Me.TxtCodigoBuxis.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoBuxis.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtCodigoBuxis.Location = New System.Drawing.Point(196, 88)
        Me.TxtCodigoBuxis.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtCodigoBuxis.Name = "TxtCodigoBuxis"
        Me.TxtCodigoBuxis.Size = New System.Drawing.Size(96, 22)
        Me.TxtCodigoBuxis.TabIndex = 29
        '
        'BtnBuscarSolicitudes
        '
        Me.BtnBuscarSolicitudes.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarSolicitudes.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSolicitudes.Image = CType(resources.GetObject("BtnBuscarSolicitudes.Image"), System.Drawing.Image)
        Me.BtnBuscarSolicitudes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSolicitudes.Location = New System.Drawing.Point(612, 88)
        Me.BtnBuscarSolicitudes.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnBuscarSolicitudes.Name = "BtnBuscarSolicitudes"
        Me.BtnBuscarSolicitudes.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarSolicitudes.TabIndex = 31
        Me.BtnBuscarSolicitudes.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnBuscarSolicitudes.UseVisualStyleBackColor = True
        '
        'TxtNombre
        '
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNombre.Location = New System.Drawing.Point(292, 88)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(320, 22)
        Me.TxtNombre.TabIndex = 27
        '
        'TxtCodigoAs
        '
        Me.TxtCodigoAs.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoAs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtCodigoAs.Location = New System.Drawing.Point(100, 88)
        Me.TxtCodigoAs.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtCodigoAs.Name = "TxtCodigoAs"
        Me.TxtCodigoAs.Size = New System.Drawing.Size(99, 22)
        Me.TxtCodigoAs.TabIndex = 28
        '
        'FrmBusquedaSolicitudesCalzado
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(730, 534)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DgvSolicitudes)
        Me.Controls.Add(Me.TxtNumSolicitud)
        Me.Controls.Add(Me.GbxCriterioBusq)
        Me.Controls.Add(Me.TxtCodigoBuxis)
        Me.Controls.Add(Me.BtnBuscarSolicitudes)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.TxtCodigoAs)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmBusquedaSolicitudesCalzado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Búsqueda de Solicitudes"
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxCriterioBusq.ResumeLayout(False)
        Me.GbxCriterioBusq.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DgvSolicitudes As System.Windows.Forms.DataGridView
    Friend WithEvents TxtNumSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GbxCriterioBusq As System.Windows.Forms.GroupBox
    Friend WithEvents CbxCompañia As System.Windows.Forms.ComboBox
    Friend WithEvents TxtCodigoBuxis As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoAs As System.Windows.Forms.TextBox
End Class
