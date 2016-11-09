<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_OrdenCompra_Requisicion_browser
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_OrdenCompra_Requisicion_browser))
        Me.gbFiltros = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtOrdenCompra = New System.Windows.Forms.TextBox
        Me.dtpSolicitadasHasta = New System.Windows.Forms.DateTimePicker
        Me.dtpSolicitadasDesde = New System.Windows.Forms.DateTimePicker
        Me.dtpCreadasHasta = New System.Windows.Forms.DateTimePicker
        Me.dtpCreadasDesde = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rad2 = New System.Windows.Forms.RadioButton
        Me.rad1 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnFilter = New System.Windows.Forms.Button
        Me.cmbBodegas = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbEstatus = New System.Windows.Forms.ComboBox
        Me.gvRequisiciones = New System.Windows.Forms.DataGridView
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnModificar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnConsultar = New System.Windows.Forms.Button
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.gbFiltros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gvRequisiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbFiltros
        '
        Me.gbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbFiltros.BackColor = System.Drawing.Color.Transparent
        Me.gbFiltros.Controls.Add(Me.Label5)
        Me.gbFiltros.Controls.Add(Me.txtOrdenCompra)
        Me.gbFiltros.Controls.Add(Me.dtpSolicitadasHasta)
        Me.gbFiltros.Controls.Add(Me.dtpSolicitadasDesde)
        Me.gbFiltros.Controls.Add(Me.dtpCreadasHasta)
        Me.gbFiltros.Controls.Add(Me.dtpCreadasDesde)
        Me.gbFiltros.Controls.Add(Me.GroupBox1)
        Me.gbFiltros.Controls.Add(Me.btnFilter)
        Me.gbFiltros.Controls.Add(Me.cmbBodegas)
        Me.gbFiltros.Controls.Add(Me.Label4)
        Me.gbFiltros.Controls.Add(Me.Label3)
        Me.gbFiltros.Controls.Add(Me.cmbEstatus)
        Me.gbFiltros.Location = New System.Drawing.Point(12, 9)
        Me.gbFiltros.Name = "gbFiltros"
        Me.gbFiltros.Size = New System.Drawing.Size(1089, 82)
        Me.gbFiltros.TabIndex = 0
        Me.gbFiltros.TabStop = False
        Me.gbFiltros.Text = "Filtros"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(660, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 167
        Me.Label5.Text = "No. Orden Compra:"
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.Location = New System.Drawing.Point(764, 22)
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(175, 20)
        Me.txtOrdenCompra.TabIndex = 166
        '
        'dtpSolicitadasHasta
        '
        Me.dtpSolicitadasHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSolicitadasHasta.Location = New System.Drawing.Point(236, 47)
        Me.dtpSolicitadasHasta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpSolicitadasHasta.Name = "dtpSolicitadasHasta"
        Me.dtpSolicitadasHasta.Size = New System.Drawing.Size(114, 20)
        Me.dtpSolicitadasHasta.TabIndex = 165
        '
        'dtpSolicitadasDesde
        '
        Me.dtpSolicitadasDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSolicitadasDesde.Location = New System.Drawing.Point(110, 47)
        Me.dtpSolicitadasDesde.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpSolicitadasDesde.Name = "dtpSolicitadasDesde"
        Me.dtpSolicitadasDesde.Size = New System.Drawing.Size(114, 20)
        Me.dtpSolicitadasDesde.TabIndex = 164
        '
        'dtpCreadasHasta
        '
        Me.dtpCreadasHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCreadasHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCreadasHasta.Location = New System.Drawing.Point(236, 22)
        Me.dtpCreadasHasta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpCreadasHasta.Name = "dtpCreadasHasta"
        Me.dtpCreadasHasta.Size = New System.Drawing.Size(114, 20)
        Me.dtpCreadasHasta.TabIndex = 163
        '
        'dtpCreadasDesde
        '
        Me.dtpCreadasDesde.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText
        Me.dtpCreadasDesde.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.dtpCreadasDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCreadasDesde.Location = New System.Drawing.Point(110, 22)
        Me.dtpCreadasDesde.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpCreadasDesde.Name = "dtpCreadasDesde"
        Me.dtpCreadasDesde.Size = New System.Drawing.Size(114, 20)
        Me.dtpCreadasDesde.TabIndex = 162
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rad2)
        Me.GroupBox1.Controls.Add(Me.rad1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(98, 54)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'rad2
        '
        Me.rad2.AutoSize = True
        Me.rad2.Location = New System.Drawing.Point(78, 34)
        Me.rad2.Name = "rad2"
        Me.rad2.Size = New System.Drawing.Size(14, 13)
        Me.rad2.TabIndex = 13
        Me.rad2.UseVisualStyleBackColor = True
        '
        'rad1
        '
        Me.rad1.AutoSize = True
        Me.rad1.Checked = True
        Me.rad1.Location = New System.Drawing.Point(78, 14)
        Me.rad1.Name = "rad1"
        Me.rad1.Size = New System.Drawing.Size(14, 13)
        Me.rad1.TabIndex = 12
        Me.rad1.TabStop = True
        Me.rad1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Creadas:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Solicitadas:"
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(663, 47)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(83, 23)
        Me.btnFilter.TabIndex = 11
        Me.btnFilter.Text = "Filtrar"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'cmbBodegas
        '
        Me.cmbBodegas.FormattingEnabled = True
        Me.cmbBodegas.Location = New System.Drawing.Point(439, 45)
        Me.cmbBodegas.Name = "cmbBodegas"
        Me.cmbBodegas.Size = New System.Drawing.Size(215, 21)
        Me.cmbBodegas.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(355, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "De la Bodega:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(355, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Estatus:"
        '
        'cmbEstatus
        '
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(439, 22)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(215, 21)
        Me.cmbEstatus.TabIndex = 2
        '
        'gvRequisiciones
        '
        Me.gvRequisiciones.AllowUserToAddRows = False
        Me.gvRequisiciones.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.gvRequisiciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gvRequisiciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvRequisiciones.BackgroundColor = System.Drawing.Color.MintCream
        Me.gvRequisiciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gvRequisiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvRequisiciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.gvRequisiciones.Location = New System.Drawing.Point(12, 95)
        Me.gvRequisiciones.Name = "gvRequisiciones"
        Me.gvRequisiciones.ReadOnly = True
        Me.gvRequisiciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvRequisiciones.Size = New System.Drawing.Size(1089, 361)
        Me.gvRequisiciones.TabIndex = 1
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(12, 468)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(98, 40)
        Me.btnNuevo.TabIndex = 2
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.Location = New System.Drawing.Point(116, 468)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(98, 40)
        Me.btnModificar.TabIndex = 3
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(430, 468)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(98, 40)
        Me.btnEliminar.TabIndex = 4
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(220, 468)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(98, 40)
        Me.btnConsultar.TabIndex = 5
        Me.btnConsultar.Text = "Con&sultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(324, 468)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(98, 40)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Contabilidad_OrdenCompra_Requisicion_browser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1113, 515)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.gvRequisiciones)
        Me.Controls.Add(Me.gbFiltros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Contabilidad_OrdenCompra_Requisicion_browser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Requisiciones que Afectan Inventario"
        Me.gbFiltros.ResumeLayout(False)
        Me.gbFiltros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gvRequisiciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents gvRequisiciones As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBodegas As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rad2 As System.Windows.Forms.RadioButton
    Friend WithEvents rad1 As System.Windows.Forms.RadioButton
    Friend WithEvents dtpSolicitadasHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpSolicitadasDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCreadasHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCreadasDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOrdenCompra As System.Windows.Forms.TextBox
End Class
