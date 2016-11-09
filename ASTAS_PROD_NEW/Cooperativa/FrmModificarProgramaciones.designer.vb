<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificarProgramaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModificarProgramaciones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TxtCodigoAs = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GbxCotizacion = New System.Windows.Forms.GroupBox
        Me.chkAll = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCodigoBuxis = New System.Windows.Forms.TextBox
        Me.BtnBuscarSocio = New System.Windows.Forms.Button
        Me.DgvProgramaciones = New System.Windows.Forms.DataGridView
        Me.CmsProgramar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TsmProgramar = New System.Windows.Forms.ToolStripMenuItem
        Me.btnConsolidar = New System.Windows.Forms.Button
        Me.btnAbonoEfectivo = New System.Windows.Forms.Button
        Me.btnAnular = New System.Windows.Forms.Button
        Me.btnReprogramar = New System.Windows.Forms.Button
        Me.btnSeparar = New System.Windows.Forms.Button
        Me.btnConsultarDetalle = New System.Windows.Forms.Button
        Me.btnConsultar = New System.Windows.Forms.Button
        Me.GbxCotizacion.SuspendLayout()
        CType(Me.DgvProgramaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CmsProgramar.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtCodigoAs
        '
        Me.TxtCodigoAs.BackColor = System.Drawing.Color.White
        Me.TxtCodigoAs.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCodigoAs.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoAs.Location = New System.Drawing.Point(345, 22)
        Me.TxtCodigoAs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoAs.Name = "TxtCodigoAs"
        Me.TxtCodigoAs.Size = New System.Drawing.Size(104, 22)
        Me.TxtCodigoAs.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(286, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Codigo AS:"
        '
        'GbxCotizacion
        '
        Me.GbxCotizacion.BackColor = System.Drawing.Color.Transparent
        Me.GbxCotizacion.Controls.Add(Me.chkAll)
        Me.GbxCotizacion.Controls.Add(Me.Button1)
        Me.GbxCotizacion.Controls.Add(Me.TxtNombre)
        Me.GbxCotizacion.Controls.Add(Me.Label9)
        Me.GbxCotizacion.Controls.Add(Me.Label1)
        Me.GbxCotizacion.Controls.Add(Me.TxtCodigoBuxis)
        Me.GbxCotizacion.Controls.Add(Me.BtnBuscarSocio)
        Me.GbxCotizacion.Controls.Add(Me.TxtCodigoAs)
        Me.GbxCotizacion.Controls.Add(Me.Label2)
        Me.GbxCotizacion.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxCotizacion.ForeColor = System.Drawing.Color.Navy
        Me.GbxCotizacion.Location = New System.Drawing.Point(4, 3)
        Me.GbxCotizacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCotizacion.Name = "GbxCotizacion"
        Me.GbxCotizacion.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxCotizacion.Size = New System.Drawing.Size(717, 100)
        Me.GbxCotizacion.TabIndex = 124
        Me.GbxCotizacion.TabStop = False
        Me.GbxCotizacion.Text = "Datos del Socio:"
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(586, 69)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(125, 20)
        Me.chkAll.TabIndex = 130
        Me.chkAll.Text = "Seleccionar Todos"
        Me.chkAll.UseVisualStyleBackColor = True
        Me.chkAll.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(455, 60)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 25)
        Me.Button1.TabIndex = 129
        Me.Button1.Text = "Nuevo"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombre.ForeColor = System.Drawing.Color.Navy
        Me.TxtNombre.Location = New System.Drawing.Point(95, 58)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(355, 22)
        Me.TxtNombre.TabIndex = 127
        Me.TxtNombre.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(3, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 16)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "Nombre del Socio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(19, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Codigo Buxis:"
        '
        'TxtCodigoBuxis
        '
        Me.TxtCodigoBuxis.BackColor = System.Drawing.Color.White
        Me.TxtCodigoBuxis.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCodigoBuxis.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoBuxis.Location = New System.Drawing.Point(95, 23)
        Me.TxtCodigoBuxis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoBuxis.Name = "TxtCodigoBuxis"
        Me.TxtCodigoBuxis.Size = New System.Drawing.Size(107, 22)
        Me.TxtCodigoBuxis.TabIndex = 0
        Me.TxtCodigoBuxis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnBuscarSocio
        '
        Me.BtnBuscarSocio.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscarSocio.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSocio.Image = CType(resources.GetObject("BtnBuscarSocio.Image"), System.Drawing.Image)
        Me.BtnBuscarSocio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSocio.Location = New System.Drawing.Point(455, 21)
        Me.BtnBuscarSocio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscarSocio.Name = "BtnBuscarSocio"
        Me.BtnBuscarSocio.Size = New System.Drawing.Size(72, 25)
        Me.BtnBuscarSocio.TabIndex = 1
        Me.BtnBuscarSocio.Text = "Buscar"
        Me.BtnBuscarSocio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarSocio.UseVisualStyleBackColor = True
        '
        'DgvProgramaciones
        '
        Me.DgvProgramaciones.AllowUserToAddRows = False
        Me.DgvProgramaciones.AllowUserToDeleteRows = False
        Me.DgvProgramaciones.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvProgramaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvProgramaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvProgramaciones.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvProgramaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvProgramaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvProgramaciones.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvProgramaciones.Location = New System.Drawing.Point(4, 106)
        Me.DgvProgramaciones.MultiSelect = False
        Me.DgvProgramaciones.Name = "DgvProgramaciones"
        Me.DgvProgramaciones.ReadOnly = True
        Me.DgvProgramaciones.RowHeadersVisible = False
        Me.DgvProgramaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvProgramaciones.Size = New System.Drawing.Size(717, 195)
        Me.DgvProgramaciones.TabIndex = 125
        '
        'CmsProgramar
        '
        Me.CmsProgramar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsmProgramar})
        Me.CmsProgramar.Name = "CmsProgramar"
        Me.CmsProgramar.Size = New System.Drawing.Size(150, 26)
        '
        'TsmProgramar
        '
        Me.TsmProgramar.Image = CType(resources.GetObject("TsmProgramar.Image"), System.Drawing.Image)
        Me.TsmProgramar.Name = "TsmProgramar"
        Me.TsmProgramar.Size = New System.Drawing.Size(149, 22)
        Me.TsmProgramar.Text = "Programación"
        '
        'btnConsolidar
        '
        Me.btnConsolidar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsolidar.BackColor = System.Drawing.Color.Transparent
        Me.btnConsolidar.Image = CType(resources.GetObject("btnConsolidar.Image"), System.Drawing.Image)
        Me.btnConsolidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsolidar.Location = New System.Drawing.Point(739, 120)
        Me.btnConsolidar.Name = "btnConsolidar"
        Me.btnConsolidar.Size = New System.Drawing.Size(100, 25)
        Me.btnConsolidar.TabIndex = 128
        Me.btnConsolidar.Text = "Consolidar"
        Me.btnConsolidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsolidar.UseVisualStyleBackColor = False
        '
        'btnAbonoEfectivo
        '
        Me.btnAbonoEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbonoEfectivo.BackColor = System.Drawing.Color.Transparent
        Me.btnAbonoEfectivo.Image = CType(resources.GetObject("btnAbonoEfectivo.Image"), System.Drawing.Image)
        Me.btnAbonoEfectivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbonoEfectivo.Location = New System.Drawing.Point(739, 152)
        Me.btnAbonoEfectivo.Name = "btnAbonoEfectivo"
        Me.btnAbonoEfectivo.Size = New System.Drawing.Size(100, 23)
        Me.btnAbonoEfectivo.TabIndex = 130
        Me.btnAbonoEfectivo.Text = "Abonar"
        Me.btnAbonoEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAbonoEfectivo.UseVisualStyleBackColor = False
        '
        'btnAnular
        '
        Me.btnAnular.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnular.BackColor = System.Drawing.Color.Transparent
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnular.Location = New System.Drawing.Point(739, 41)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(100, 25)
        Me.btnAnular.TabIndex = 131
        Me.btnAnular.Text = "Anular Prog."
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnular.UseVisualStyleBackColor = False
        '
        'btnReprogramar
        '
        Me.btnReprogramar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReprogramar.BackColor = System.Drawing.Color.Transparent
        Me.btnReprogramar.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.btnReprogramar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReprogramar.Location = New System.Drawing.Point(739, 180)
        Me.btnReprogramar.Name = "btnReprogramar"
        Me.btnReprogramar.Size = New System.Drawing.Size(100, 25)
        Me.btnReprogramar.TabIndex = 127
        Me.btnReprogramar.Text = "Reprogramar"
        Me.btnReprogramar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReprogramar.UseVisualStyleBackColor = False
        '
        'btnSeparar
        '
        Me.btnSeparar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSeparar.BackColor = System.Drawing.Color.Transparent
        Me.btnSeparar.Enabled = False
        Me.btnSeparar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSeparar.Location = New System.Drawing.Point(739, 72)
        Me.btnSeparar.Name = "btnSeparar"
        Me.btnSeparar.Size = New System.Drawing.Size(100, 42)
        Me.btnSeparar.TabIndex = 132
        Me.btnSeparar.Text = "Separar Cuotas Especiales"
        Me.btnSeparar.UseVisualStyleBackColor = False
        '
        'btnConsultarDetalle
        '
        Me.btnConsultarDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultarDetalle.BackColor = System.Drawing.Color.Transparent
        Me.btnConsultarDetalle.Enabled = False
        Me.btnConsultarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultarDetalle.Location = New System.Drawing.Point(739, 212)
        Me.btnConsultarDetalle.Name = "btnConsultarDetalle"
        Me.btnConsultarDetalle.Size = New System.Drawing.Size(100, 42)
        Me.btnConsultarDetalle.TabIndex = 133
        Me.btnConsultarDetalle.Text = "Consultar Saldos Detallado"
        Me.btnConsultarDetalle.UseVisualStyleBackColor = False
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.BackColor = System.Drawing.Color.Transparent
        Me.btnConsultar.Enabled = False
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(739, 259)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 42)
        Me.btnConsultar.TabIndex = 134
        Me.btnConsultar.Text = "Consultar Saldos Varias Solicitudes"
        Me.btnConsultar.UseVisualStyleBackColor = False
        '
        'FrmModificarProgramaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 304)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.btnConsultarDetalle)
        Me.Controls.Add(Me.btnSeparar)
        Me.Controls.Add(Me.btnConsolidar)
        Me.Controls.Add(Me.btnAnular)
        Me.Controls.Add(Me.btnReprogramar)
        Me.Controls.Add(Me.DgvProgramaciones)
        Me.Controls.Add(Me.btnAbonoEfectivo)
        Me.Controls.Add(Me.GbxCotizacion)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmModificarProgramaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Reprogramación, Abonos y Consolidaciones de Cuotas"
        Me.GbxCotizacion.ResumeLayout(False)
        Me.GbxCotizacion.PerformLayout()
        CType(Me.DgvProgramaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CmsProgramar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TxtCodigoAs As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GbxCotizacion As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBuscarSocio As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoBuxis As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DgvProgramaciones As System.Windows.Forms.DataGridView
    Friend WithEvents CmsProgramar As System.Windows.Forms.ContextMenuStrip

    Friend WithEvents TsmProgramar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnReprogramar As System.Windows.Forms.Button
    Friend WithEvents btnConsolidar As System.Windows.Forms.Button
    Friend WithEvents btnAbonoEfectivo As System.Windows.Forms.Button
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnSeparar As System.Windows.Forms.Button
    Friend WithEvents btnConsultarDetalle As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
End Class
