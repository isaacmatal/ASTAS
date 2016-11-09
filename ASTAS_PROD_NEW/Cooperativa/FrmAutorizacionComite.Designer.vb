<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAutorizacionComite
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAutorizacionComite))
        Me.CmsAutorizacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TsmiAutorizacion = New System.Windows.Forms.ToolStripMenuItem
        Me.DgvSolicitudes = New System.Windows.Forms.DataGridView
        Me.DpFechaFin = New System.Windows.Forms.DateTimePicker
        Me.GbxCriterioBusq = New System.Windows.Forms.GroupBox
        Me.DpFechaIni = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.CbxCompania = New System.Windows.Forms.ComboBox
        Me.CbxTipoSolicitudes = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtNumSol = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnAutorizar = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmsAutorizacion.SuspendLayout()
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxCriterioBusq.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmsAutorizacion
        '
        Me.CmsAutorizacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmiAutorizacion})
        Me.CmsAutorizacion.Name = "CmsAutorizacion"
        Me.CmsAutorizacion.Size = New System.Drawing.Size(142, 26)
        '
        'TsmiAutorizacion
        '
        Me.TsmiAutorizacion.Name = "TsmiAutorizacion"
        Me.TsmiAutorizacion.Size = New System.Drawing.Size(141, 22)
        Me.TsmiAutorizacion.Text = "Autorizacion"
        '
        'DgvSolicitudes
        '
        Me.DgvSolicitudes.AllowUserToAddRows = False
        Me.DgvSolicitudes.AllowUserToDeleteRows = False
        Me.DgvSolicitudes.AllowUserToResizeColumns = False
        Me.DgvSolicitudes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.DgvSolicitudes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSolicitudes.ContextMenuStrip = Me.CmsAutorizacion
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSolicitudes.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvSolicitudes.Location = New System.Drawing.Point(4, 87)
        Me.DgvSolicitudes.MultiSelect = False
        Me.DgvSolicitudes.Name = "DgvSolicitudes"
        Me.DgvSolicitudes.ReadOnly = True
        Me.DgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSolicitudes.Size = New System.Drawing.Size(936, 496)
        Me.DgvSolicitudes.TabIndex = 28
        '
        'DpFechaFin
        '
        Me.DpFechaFin.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaFin.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaFin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaFin.Location = New System.Drawing.Point(616, 48)
        Me.DpFechaFin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DpFechaFin.Name = "DpFechaFin"
        Me.DpFechaFin.Size = New System.Drawing.Size(112, 22)
        Me.DpFechaFin.TabIndex = 27
        '
        'GbxCriterioBusq
        '
        Me.GbxCriterioBusq.Controls.Add(Me.DpFechaFin)
        Me.GbxCriterioBusq.Controls.Add(Me.DpFechaIni)
        Me.GbxCriterioBusq.Controls.Add(Me.Label1)
        Me.GbxCriterioBusq.Controls.Add(Me.BtnBuscar)
        Me.GbxCriterioBusq.Controls.Add(Me.Label14)
        Me.GbxCriterioBusq.Controls.Add(Me.CbxCompania)
        Me.GbxCriterioBusq.Controls.Add(Me.CbxTipoSolicitudes)
        Me.GbxCriterioBusq.Controls.Add(Me.Label3)
        Me.GbxCriterioBusq.Controls.Add(Me.TxtNumSol)
        Me.GbxCriterioBusq.Controls.Add(Me.Label12)
        Me.GbxCriterioBusq.Controls.Add(Me.Label2)
        Me.GbxCriterioBusq.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCriterioBusq.ForeColor = System.Drawing.Color.Navy
        Me.GbxCriterioBusq.Location = New System.Drawing.Point(4, 2)
        Me.GbxCriterioBusq.Name = "GbxCriterioBusq"
        Me.GbxCriterioBusq.Size = New System.Drawing.Size(816, 80)
        Me.GbxCriterioBusq.TabIndex = 27
        Me.GbxCriterioBusq.TabStop = False
        Me.GbxCriterioBusq.Text = "Filtros"
        '
        'DpFechaIni
        '
        Me.DpFechaIni.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaIni.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaIni.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DpFechaIni.Location = New System.Drawing.Point(616, 24)
        Me.DpFechaIni.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DpFechaIni.Name = "DpFechaIni"
        Me.DpFechaIni.Size = New System.Drawing.Size(112, 22)
        Me.DpFechaIni.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(576, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 16)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Hasta:"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscar.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(736, 28)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(72, 38)
        Me.BtnBuscar.TabIndex = 25
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnBuscar, "Realiza la búsqueda de solicitudes pendientes de autorizar para el rango de fecha" & _
                "s.")
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(416, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 16)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "N° Solicitud:"
        '
        'CbxCompania
        '
        Me.CbxCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCompania.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CbxCompania.ForeColor = System.Drawing.Color.Navy
        Me.CbxCompania.FormattingEnabled = True
        Me.CbxCompania.Location = New System.Drawing.Point(96, 24)
        Me.CbxCompania.Name = "CbxCompania"
        Me.CbxCompania.Size = New System.Drawing.Size(471, 24)
        Me.CbxCompania.TabIndex = 21
        '
        'CbxTipoSolicitudes
        '
        Me.CbxTipoSolicitudes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoSolicitudes.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.CbxTipoSolicitudes.ForeColor = System.Drawing.Color.Navy
        Me.CbxTipoSolicitudes.FormattingEnabled = True
        Me.CbxTipoSolicitudes.Location = New System.Drawing.Point(96, 48)
        Me.CbxTipoSolicitudes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbxTipoSolicitudes.Name = "CbxTipoSolicitudes"
        Me.CbxTipoSolicitudes.Size = New System.Drawing.Size(315, 24)
        Me.CbxTipoSolicitudes.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Compañia:"
        '
        'TxtNumSol
        '
        Me.TxtNumSol.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtNumSol.ForeColor = System.Drawing.Color.Navy
        Me.TxtNumSol.Location = New System.Drawing.Point(488, 48)
        Me.TxtNumSol.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNumSol.Name = "TxtNumSol"
        Me.TxtNumSol.Size = New System.Drawing.Size(80, 22)
        Me.TxtNumSol.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(8, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Tipo de Solicitud:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(576, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Desde:"
        '
        'BtnAutorizar
        '
        Me.BtnAutorizar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnAutorizar.ForeColor = System.Drawing.Color.Black
        Me.BtnAutorizar.Image = Global.ASTAS.My.Resources.Resources.todo
        Me.BtnAutorizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAutorizar.Location = New System.Drawing.Point(844, 30)
        Me.BtnAutorizar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnAutorizar.Name = "BtnAutorizar"
        Me.BtnAutorizar.Size = New System.Drawing.Size(72, 38)
        Me.BtnAutorizar.TabIndex = 29
        Me.BtnAutorizar.Text = "Autorizar"
        Me.BtnAutorizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnAutorizar, "Autorizar las solicitudes pendiente de autorizar por el comite.")
        Me.BtnAutorizar.UseVisualStyleBackColor = True
        '
        'FrmAutorizacionComite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 602)
        Me.Controls.Add(Me.BtnAutorizar)
        Me.Controls.Add(Me.GbxCriterioBusq)
        Me.Controls.Add(Me.DgvSolicitudes)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmAutorizacionComite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Gerencia - Autorización del Comité"
        Me.CmsAutorizacion.ResumeLayout(False)
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxCriterioBusq.ResumeLayout(False)
        Me.GbxCriterioBusq.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmsAutorizacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TsmiAutorizacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DgvSolicitudes As System.Windows.Forms.DataGridView
    Friend WithEvents DpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents GbxCriterioBusq As System.Windows.Forms.GroupBox
    Friend WithEvents DpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CbxCompania As System.Windows.Forms.ComboBox
    Friend WithEvents CbxTipoSolicitudes As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNumSol As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnAutorizar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
