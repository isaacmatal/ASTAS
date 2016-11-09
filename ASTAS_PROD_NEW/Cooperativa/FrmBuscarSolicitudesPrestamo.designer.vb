<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscarSolicitudesPrestamo
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscarSolicitudesPrestamo))
        Me.Label7 = New System.Windows.Forms.Label
        Me.DgvSolicitudes = New System.Windows.Forms.DataGridView
        Me.TxtNumSolicitud = New System.Windows.Forms.TextBox
        Me.GbxCriterioBusq = New System.Windows.Forms.GroupBox
        Me.TxtCodigoAs = New System.Windows.Forms.TextBox
        Me.BtnBuscarSolicitudes = New System.Windows.Forms.Button
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.TxtCodigoBuxis = New System.Windows.Forms.TextBox
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxCriterioBusq.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SkyBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(8, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(608, 22)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "N° Solicitud            Código AS      Código Buxis       Nombre del Socio"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.DgvSolicitudes.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSolicitudes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSolicitudes.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvSolicitudes.Location = New System.Drawing.Point(8, 96)
        Me.DgvSolicitudes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DgvSolicitudes.MultiSelect = False
        Me.DgvSolicitudes.Name = "DgvSolicitudes"
        Me.DgvSolicitudes.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSolicitudes.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSolicitudes.Size = New System.Drawing.Size(792, 552)
        Me.DgvSolicitudes.TabIndex = 32
        '
        'TxtNumSolicitud
        '
        Me.TxtNumSolicitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumSolicitud.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNumSolicitud.Location = New System.Drawing.Point(8, 46)
        Me.TxtNumSolicitud.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.TxtNumSolicitud.Name = "TxtNumSolicitud"
        Me.TxtNumSolicitud.Size = New System.Drawing.Size(96, 22)
        Me.TxtNumSolicitud.TabIndex = 33
        '
        'GbxCriterioBusq
        '
        Me.GbxCriterioBusq.BackColor = System.Drawing.Color.Transparent
        Me.GbxCriterioBusq.Controls.Add(Me.Label7)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtCodigoAs)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtNumSolicitud)
        Me.GbxCriterioBusq.Controls.Add(Me.BtnBuscarSolicitudes)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtNombre)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtCodigoBuxis)
        Me.GbxCriterioBusq.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCriterioBusq.ForeColor = System.Drawing.Color.Navy
        Me.GbxCriterioBusq.Location = New System.Drawing.Point(8, 8)
        Me.GbxCriterioBusq.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GbxCriterioBusq.Name = "GbxCriterioBusq"
        Me.GbxCriterioBusq.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GbxCriterioBusq.Size = New System.Drawing.Size(650, 79)
        Me.GbxCriterioBusq.TabIndex = 30
        Me.GbxCriterioBusq.TabStop = False
        Me.GbxCriterioBusq.Text = "Filtros"
        '
        'TxtCodigoAs
        '
        Me.TxtCodigoAs.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoAs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtCodigoAs.Location = New System.Drawing.Point(104, 46)
        Me.TxtCodigoAs.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.TxtCodigoAs.Name = "TxtCodigoAs"
        Me.TxtCodigoAs.Size = New System.Drawing.Size(96, 22)
        Me.TxtCodigoAs.TabIndex = 28
        '
        'BtnBuscarSolicitudes
        '
        Me.BtnBuscarSolicitudes.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarSolicitudes.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSolicitudes.Image = CType(resources.GetObject("BtnBuscarSolicitudes.Image"), System.Drawing.Image)
        Me.BtnBuscarSolicitudes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSolicitudes.Location = New System.Drawing.Point(616, 46)
        Me.BtnBuscarSolicitudes.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
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
        Me.TxtNombre.Location = New System.Drawing.Point(296, 46)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(320, 22)
        Me.TxtNombre.TabIndex = 27
        '
        'TxtCodigoBuxis
        '
        Me.TxtCodigoBuxis.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoBuxis.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtCodigoBuxis.Location = New System.Drawing.Point(200, 46)
        Me.TxtCodigoBuxis.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.TxtCodigoBuxis.Name = "TxtCodigoBuxis"
        Me.TxtCodigoBuxis.Size = New System.Drawing.Size(96, 22)
        Me.TxtCodigoBuxis.TabIndex = 29
        '
        'FrmBuscarSolicitudesPrestamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(804, 655)
        Me.Controls.Add(Me.DgvSolicitudes)
        Me.Controls.Add(Me.GbxCriterioBusq)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmBuscarSolicitudesPrestamo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Búsqueda de Solicitudes de Préstamos"
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxCriterioBusq.ResumeLayout(False)
        Me.GbxCriterioBusq.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DgvSolicitudes As System.Windows.Forms.DataGridView
    Friend WithEvents TxtNumSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents GbxCriterioBusq As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCodigoBuxis As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents TxtCodigoAs As System.Windows.Forms.TextBox
End Class
