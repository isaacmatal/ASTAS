<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscarSolicitudes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscarSolicitudes))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TxtCodigoBuxis = New System.Windows.Forms.TextBox
        Me.GbxCriterioBusq = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtCodigoAs = New System.Windows.Forms.TextBox
        Me.TxtNumSolicitud = New System.Windows.Forms.TextBox
        Me.BtnBuscarSolicitudes = New System.Windows.Forms.Button
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.DgvSolicitudes = New System.Windows.Forms.DataGridView
        Me.GbxCriterioBusq.SuspendLayout()
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCodigoBuxis
        '
        Me.TxtCodigoBuxis.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoBuxis.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtCodigoBuxis.Location = New System.Drawing.Point(198, 43)
        Me.TxtCodigoBuxis.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtCodigoBuxis.Name = "TxtCodigoBuxis"
        Me.TxtCodigoBuxis.Size = New System.Drawing.Size(96, 22)
        Me.TxtCodigoBuxis.TabIndex = 17
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
        Me.GbxCriterioBusq.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCriterioBusq.Name = "GbxCriterioBusq"
        Me.GbxCriterioBusq.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCriterioBusq.Size = New System.Drawing.Size(643, 71)
        Me.GbxCriterioBusq.TabIndex = 17
        Me.GbxCriterioBusq.TabStop = False
        Me.GbxCriterioBusq.Text = "Filtros"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(6, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(608, 20)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "N° Solicitud            Código AS      Código Buxis       Nombre del Socio"
        '
        'TxtCodigoAs
        '
        Me.TxtCodigoAs.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigoAs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtCodigoAs.Location = New System.Drawing.Point(102, 43)
        Me.TxtCodigoAs.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtCodigoAs.Name = "TxtCodigoAs"
        Me.TxtCodigoAs.Size = New System.Drawing.Size(95, 22)
        Me.TxtCodigoAs.TabIndex = 15
        '
        'TxtNumSolicitud
        '
        Me.TxtNumSolicitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumSolicitud.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNumSolicitud.Location = New System.Drawing.Point(5, 43)
        Me.TxtNumSolicitud.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtNumSolicitud.Name = "TxtNumSolicitud"
        Me.TxtNumSolicitud.Size = New System.Drawing.Size(96, 22)
        Me.TxtNumSolicitud.TabIndex = 22
        '
        'BtnBuscarSolicitudes
        '
        Me.BtnBuscarSolicitudes.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarSolicitudes.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSolicitudes.Image = CType(resources.GetObject("BtnBuscarSolicitudes.Image"), System.Drawing.Image)
        Me.BtnBuscarSolicitudes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSolicitudes.Location = New System.Drawing.Point(614, 43)
        Me.BtnBuscarSolicitudes.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnBuscarSolicitudes.Name = "BtnBuscarSolicitudes"
        Me.BtnBuscarSolicitudes.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarSolicitudes.TabIndex = 19
        Me.BtnBuscarSolicitudes.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnBuscarSolicitudes.UseVisualStyleBackColor = True
        '
        'TxtNombre
        '
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtNombre.Location = New System.Drawing.Point(294, 43)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(320, 22)
        Me.TxtNombre.TabIndex = 11
        '
        'DgvSolicitudes
        '
        Me.DgvSolicitudes.AllowUserToAddRows = False
        Me.DgvSolicitudes.AllowUserToDeleteRows = False
        Me.DgvSolicitudes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvSolicitudes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvSolicitudes.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.DgvSolicitudes.Location = New System.Drawing.Point(8, 86)
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
        Me.DgvSolicitudes.Size = New System.Drawing.Size(712, 442)
        Me.DgvSolicitudes.TabIndex = 20
        '
        'FrmBuscarSolicitudes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(727, 533)
        Me.Controls.Add(Me.DgvSolicitudes)
        Me.Controls.Add(Me.GbxCriterioBusq)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBuscarSolicitudes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Búsqueda de Solicitudes"
        Me.GbxCriterioBusq.ResumeLayout(False)
        Me.GbxCriterioBusq.PerformLayout()
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtCodigoBuxis As System.Windows.Forms.TextBox
    Friend WithEvents GbxCriterioBusq As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCodigoAs As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents DgvSolicitudes As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
