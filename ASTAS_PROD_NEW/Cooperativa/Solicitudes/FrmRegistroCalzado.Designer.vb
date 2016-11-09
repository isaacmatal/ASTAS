<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroCalzado
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistroCalzado))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GbxDatos = New System.Windows.Forms.GroupBox
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.dgvValesSolicitud = New System.Windows.Forms.DataGridView
        Me.codtipovale = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fechaentrega = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tipovale = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cantidadvales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.corre_ini = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.corre_fin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.totalvale = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fechaemision = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fechavenc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmbTipoVale = New System.Windows.Forms.ComboBox
        Me.DpFechaVencimiento = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.DpFechaEmision = New System.Windows.Forms.DateTimePicker
        Me.Label21 = New System.Windows.Forms.Label
        Me.TxtCodigoBuxis = New System.Windows.Forms.TextBox
        Me.TxtTotalVale = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtDivision = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtCorrelativoFin = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtDepartamento = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtCorrelativoIni = New System.Windows.Forms.TextBox
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtCodigoAs = New System.Windows.Forms.TextBox
        Me.Cantidad = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.BtnBuscarSol = New System.Windows.Forms.Button
        Me.TxtNumeroSol = New System.Windows.Forms.TextBox
        Me.DpFechaEntrega = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.BtnNueva = New System.Windows.Forms.Button
        Me.lblTipoSolicitud = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxDatos.SuspendLayout()
        CType(Me.dgvValesSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(3, 11)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(140, 344)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbImagen.TabIndex = 7
        Me.pbImagen.TabStop = False
        '
        'GbxDatos
        '
        Me.GbxDatos.Controls.Add(Me.btnLimpiar)
        Me.GbxDatos.Controls.Add(Me.btnEliminar)
        Me.GbxDatos.Controls.Add(Me.dgvValesSolicitud)
        Me.GbxDatos.Controls.Add(Me.cmbTipoVale)
        Me.GbxDatos.Controls.Add(Me.DpFechaVencimiento)
        Me.GbxDatos.Controls.Add(Me.Label3)
        Me.GbxDatos.Controls.Add(Me.Label20)
        Me.GbxDatos.Controls.Add(Me.DpFechaEmision)
        Me.GbxDatos.Controls.Add(Me.Label21)
        Me.GbxDatos.Controls.Add(Me.TxtCodigoBuxis)
        Me.GbxDatos.Controls.Add(Me.TxtTotalVale)
        Me.GbxDatos.Controls.Add(Me.Label10)
        Me.GbxDatos.Controls.Add(Me.TxtDivision)
        Me.GbxDatos.Controls.Add(Me.Label8)
        Me.GbxDatos.Controls.Add(Me.TxtCorrelativoFin)
        Me.GbxDatos.Controls.Add(Me.Label11)
        Me.GbxDatos.Controls.Add(Me.TxtDepartamento)
        Me.GbxDatos.Controls.Add(Me.Label9)
        Me.GbxDatos.Controls.Add(Me.TxtCorrelativoIni)
        Me.GbxDatos.Controls.Add(Me.TxtNombre)
        Me.GbxDatos.Controls.Add(Me.Label1)
        Me.GbxDatos.Controls.Add(Me.Label12)
        Me.GbxDatos.Controls.Add(Me.TxtCodigoAs)
        Me.GbxDatos.Controls.Add(Me.Cantidad)
        Me.GbxDatos.Controls.Add(Me.Label2)
        Me.GbxDatos.Controls.Add(Me.BtnGuardar)
        Me.GbxDatos.Controls.Add(Me.Label15)
        Me.GbxDatos.ForeColor = System.Drawing.Color.Navy
        Me.GbxDatos.Location = New System.Drawing.Point(144, 70)
        Me.GbxDatos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxDatos.Name = "GbxDatos"
        Me.GbxDatos.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GbxDatos.Size = New System.Drawing.Size(690, 361)
        Me.GbxDatos.TabIndex = 3
        Me.GbxDatos.TabStop = False
        Me.GbxDatos.Text = "Datos Generales"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.btnLimpiar.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(83, 134)
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(25, 25)
        Me.btnLimpiar.TabIndex = 42
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Prepara los campos para un nuevo detalle")
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnEliminar.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar.Image = Global.ASTAS.My.Resources.Resources.editdelete
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(47, 134)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(25, 25)
        Me.btnEliminar.TabIndex = 41
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Elimina el detalle del vale")
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'dgvValesSolicitud
        '
        Me.dgvValesSolicitud.AllowUserToAddRows = False
        Me.dgvValesSolicitud.AllowUserToDeleteRows = False
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvValesSolicitud.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvValesSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvValesSolicitud.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codtipovale, Me.fechaentrega, Me.tipovale, Me.cantidadvales, Me.corre_ini, Me.corre_fin, Me.totalvale, Me.fechaemision, Me.fechavenc})
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvValesSolicitud.DefaultCellStyle = DataGridViewCellStyle21
        Me.dgvValesSolicitud.Location = New System.Drawing.Point(11, 194)
        Me.dgvValesSolicitud.Name = "dgvValesSolicitud"
        Me.dgvValesSolicitud.ReadOnly = True
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvValesSolicitud.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvValesSolicitud.RowHeadersVisible = False
        Me.dgvValesSolicitud.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvValesSolicitud.Size = New System.Drawing.Size(675, 160)
        Me.dgvValesSolicitud.TabIndex = 7
        '
        'codtipovale
        '
        Me.codtipovale.DataPropertyName = "TIPO_VALE"
        Me.codtipovale.HeaderText = "Codigo Tipo Vale"
        Me.codtipovale.Name = "codtipovale"
        Me.codtipovale.ReadOnly = True
        Me.codtipovale.Visible = False
        '
        'fechaentrega
        '
        Me.fechaentrega.DataPropertyName = "FECHA_ENTREGA"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Format = "d"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.fechaentrega.DefaultCellStyle = DataGridViewCellStyle13
        Me.fechaentrega.HeaderText = "Fecha Entrega"
        Me.fechaentrega.Name = "fechaentrega"
        Me.fechaentrega.ReadOnly = True
        Me.fechaentrega.Width = 70
        '
        'tipovale
        '
        Me.tipovale.DataPropertyName = "DESCRIPCION"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.NullValue = Nothing
        Me.tipovale.DefaultCellStyle = DataGridViewCellStyle14
        Me.tipovale.HeaderText = "Tipo Vale"
        Me.tipovale.Name = "tipovale"
        Me.tipovale.ReadOnly = True
        Me.tipovale.Width = 170
        '
        'cantidadvales
        '
        Me.cantidadvales.DataPropertyName = "CANTIDAD_VALES"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N0"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.cantidadvales.DefaultCellStyle = DataGridViewCellStyle15
        Me.cantidadvales.HeaderText = "Cantidad"
        Me.cantidadvales.Name = "cantidadvales"
        Me.cantidadvales.ReadOnly = True
        Me.cantidadvales.Width = 60
        '
        'corre_ini
        '
        Me.corre_ini.DataPropertyName = "CORRELATIVO_INI"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N0"
        Me.corre_ini.DefaultCellStyle = DataGridViewCellStyle16
        Me.corre_ini.HeaderText = "Correlativo Inicial"
        Me.corre_ini.Name = "corre_ini"
        Me.corre_ini.ReadOnly = True
        Me.corre_ini.Width = 80
        '
        'corre_fin
        '
        Me.corre_fin.DataPropertyName = "CORRELATIVO_FIN"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N0"
        Me.corre_fin.DefaultCellStyle = DataGridViewCellStyle17
        Me.corre_fin.HeaderText = "Correlativo Final"
        Me.corre_fin.Name = "corre_fin"
        Me.corre_fin.ReadOnly = True
        Me.corre_fin.Width = 80
        '
        'totalvale
        '
        Me.totalvale.DataPropertyName = "TOTAL_VALE"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = Nothing
        Me.totalvale.DefaultCellStyle = DataGridViewCellStyle18
        Me.totalvale.HeaderText = "Valor Total"
        Me.totalvale.Name = "totalvale"
        Me.totalvale.ReadOnly = True
        Me.totalvale.Width = 70
        '
        'fechaemision
        '
        Me.fechaemision.DataPropertyName = "FECHA_EMISION"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.Format = "d"
        Me.fechaemision.DefaultCellStyle = DataGridViewCellStyle19
        Me.fechaemision.HeaderText = "Fecha Emisión"
        Me.fechaemision.Name = "fechaemision"
        Me.fechaemision.ReadOnly = True
        Me.fechaemision.Width = 70
        '
        'fechavenc
        '
        Me.fechavenc.DataPropertyName = "FECHA_VENCIMIENTO"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle20.Format = "d"
        Me.fechavenc.DefaultCellStyle = DataGridViewCellStyle20
        Me.fechavenc.HeaderText = "Fecha Vencmto."
        Me.fechavenc.Name = "fechavenc"
        Me.fechavenc.ReadOnly = True
        Me.fechavenc.Width = 70
        '
        'cmbTipoVale
        '
        Me.cmbTipoVale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoVale.FormattingEnabled = True
        Me.cmbTipoVale.Location = New System.Drawing.Point(11, 163)
        Me.cmbTipoVale.Name = "cmbTipoVale"
        Me.cmbTipoVale.Size = New System.Drawing.Size(195, 24)
        Me.cmbTipoVale.TabIndex = 0
        '
        'DpFechaVencimiento
        '
        Me.DpFechaVencimiento.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaVencimiento.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.DpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DpFechaVencimiento.Location = New System.Drawing.Point(514, 163)
        Me.DpFechaVencimiento.Name = "DpFechaVencimiento"
        Me.DpFechaVencimiento.Size = New System.Drawing.Size(77, 22)
        Me.DpFechaVencimiento.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(225, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Codigo Buxis:"
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(514, 132)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 32)
        Me.Label20.TabIndex = 38
        Me.Label20.Text = "Fecha Vencimiento:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DpFechaEmision
        '
        Me.DpFechaEmision.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaEmision.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.DpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DpFechaEmision.Location = New System.Drawing.Point(432, 163)
        Me.DpFechaEmision.Name = "DpFechaEmision"
        Me.DpFechaEmision.Size = New System.Drawing.Size(76, 22)
        Me.DpFechaEmision.TabIndex = 5
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(429, 132)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(79, 32)
        Me.Label21.TabIndex = 37
        Me.Label21.Text = "Fecha Emisión:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCodigoBuxis
        '
        Me.TxtCodigoBuxis.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCodigoBuxis.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCodigoBuxis.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoBuxis.Location = New System.Drawing.Point(319, 28)
        Me.TxtCodigoBuxis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoBuxis.Name = "TxtCodigoBuxis"
        Me.TxtCodigoBuxis.ReadOnly = True
        Me.TxtCodigoBuxis.Size = New System.Drawing.Size(104, 22)
        Me.TxtCodigoBuxis.TabIndex = 17
        '
        'TxtTotalVale
        '
        Me.TxtTotalVale.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtTotalVale.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtTotalVale.ForeColor = System.Drawing.Color.Navy
        Me.TxtTotalVale.Location = New System.Drawing.Point(378, 163)
        Me.TxtTotalVale.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTotalVale.Name = "TxtTotalVale"
        Me.TxtTotalVale.ReadOnly = True
        Me.TxtTotalVale.Size = New System.Drawing.Size(48, 22)
        Me.TxtTotalVale.TabIndex = 4
        Me.TxtTotalVale.Text = "0"
        Me.TxtTotalVale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "División:"
        '
        'TxtDivision
        '
        Me.TxtDivision.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDivision.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtDivision.ForeColor = System.Drawing.Color.Navy
        Me.TxtDivision.Location = New System.Drawing.Point(102, 100)
        Me.TxtDivision.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtDivision.Name = "TxtDivision"
        Me.TxtDivision.ReadOnly = True
        Me.TxtDivision.Size = New System.Drawing.Size(368, 22)
        Me.TxtDivision.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(378, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 32)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Total en Vales:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCorrelativoFin
        '
        Me.TxtCorrelativoFin.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCorrelativoFin.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCorrelativoFin.ForeColor = System.Drawing.Color.Navy
        Me.TxtCorrelativoFin.Location = New System.Drawing.Point(314, 163)
        Me.TxtCorrelativoFin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCorrelativoFin.Name = "TxtCorrelativoFin"
        Me.TxtCorrelativoFin.Size = New System.Drawing.Size(58, 22)
        Me.TxtCorrelativoFin.TabIndex = 3
        Me.TxtCorrelativoFin.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Departamento:"
        '
        'TxtDepartamento
        '
        Me.TxtDepartamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TxtDepartamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDepartamento.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtDepartamento.ForeColor = System.Drawing.Color.Navy
        Me.TxtDepartamento.Location = New System.Drawing.Point(102, 76)
        Me.TxtDepartamento.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtDepartamento.Name = "TxtDepartamento"
        Me.TxtDepartamento.ReadOnly = True
        Me.TxtDepartamento.Size = New System.Drawing.Size(368, 22)
        Me.TxtDepartamento.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(312, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 32)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Correlativo Final:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCorrelativoIni
        '
        Me.TxtCorrelativoIni.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCorrelativoIni.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCorrelativoIni.ForeColor = System.Drawing.Color.Navy
        Me.TxtCorrelativoIni.Location = New System.Drawing.Point(258, 163)
        Me.TxtCorrelativoIni.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCorrelativoIni.Name = "TxtCorrelativoIni"
        Me.TxtCorrelativoIni.Size = New System.Drawing.Size(50, 22)
        Me.TxtCorrelativoIni.TabIndex = 2
        Me.TxtCorrelativoIni.Text = "0"
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtNombre.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtNombre.ForeColor = System.Drawing.Color.Navy
        Me.TxtNombre.Location = New System.Drawing.Point(102, 52)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(368, 22)
        Me.TxtNombre.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo AS:"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(253, 132)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 32)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Correlativo Inicial:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCodigoAs
        '
        Me.TxtCodigoAs.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCodigoAs.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.TxtCodigoAs.ForeColor = System.Drawing.Color.Navy
        Me.TxtCodigoAs.Location = New System.Drawing.Point(102, 28)
        Me.TxtCodigoAs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCodigoAs.Name = "TxtCodigoAs"
        Me.TxtCodigoAs.ReadOnly = True
        Me.TxtCodigoAs.Size = New System.Drawing.Size(104, 22)
        Me.TxtCodigoAs.TabIndex = 20
        '
        'Cantidad
        '
        Me.Cantidad.BackColor = System.Drawing.SystemColors.Window
        Me.Cantidad.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Cantidad.ForeColor = System.Drawing.Color.Navy
        Me.Cantidad.Location = New System.Drawing.Point(212, 163)
        Me.Cantidad.Maximum = New Decimal(New Integer() {25, 0, 0, 0})
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Size = New System.Drawing.Size(44, 22)
        Me.Cantidad.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre del Socio:"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnGuardar.ForeColor = System.Drawing.Color.Black
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(11, 134)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(25, 25)
        Me.BtnGuardar.TabIndex = 23
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnGuardar, "Guarda el detalle del vale")
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(206, 144)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Cantidad"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnBuscarSol
        '
        Me.BtnBuscarSol.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscarSol.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSol.Image = CType(resources.GetObject("BtnBuscarSol.Image"), System.Drawing.Image)
        Me.BtnBuscarSol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSol.Location = New System.Drawing.Point(315, 37)
        Me.BtnBuscarSol.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscarSol.Name = "BtnBuscarSol"
        Me.BtnBuscarSol.Size = New System.Drawing.Size(72, 25)
        Me.BtnBuscarSol.TabIndex = 2
        Me.BtnBuscarSol.Text = "Buscar"
        Me.BtnBuscarSol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnBuscarSol, "Buscar solicitudes para agregar vales")
        Me.BtnBuscarSol.UseVisualStyleBackColor = True
        '
        'TxtNumeroSol
        '
        Me.TxtNumeroSol.BackColor = System.Drawing.Color.White
        Me.TxtNumeroSol.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumeroSol.ForeColor = System.Drawing.Color.Red
        Me.TxtNumeroSol.Location = New System.Drawing.Point(241, 37)
        Me.TxtNumeroSol.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNumeroSol.Name = "TxtNumeroSol"
        Me.TxtNumeroSol.Size = New System.Drawing.Size(74, 22)
        Me.TxtNumeroSol.TabIndex = 1
        Me.TxtNumeroSol.Tag = ""
        Me.TxtNumeroSol.Text = "0"
        Me.TxtNumeroSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DpFechaEntrega
        '
        Me.DpFechaEntrega.CustomFormat = "dd-MMM-yyyy"
        Me.DpFechaEntrega.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.DpFechaEntrega.Location = New System.Drawing.Point(241, 13)
        Me.DpFechaEntrega.Name = "DpFechaEntrega"
        Me.DpFechaEntrega.Size = New System.Drawing.Size(225, 22)
        Me.DpFechaEntrega.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(149, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 16)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Fecha de Entrega:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(149, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 16)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "N° Solicitud:"
        '
        'BtnNueva
        '
        Me.BtnNueva.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnNueva.ForeColor = System.Drawing.Color.Black
        Me.BtnNueva.Image = CType(resources.GetObject("BtnNueva.Image"), System.Drawing.Image)
        Me.BtnNueva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNueva.Location = New System.Drawing.Point(389, 38)
        Me.BtnNueva.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnNueva.Name = "BtnNueva"
        Me.BtnNueva.Size = New System.Drawing.Size(72, 24)
        Me.BtnNueva.TabIndex = 25
        Me.BtnNueva.Text = "&Nueva"
        Me.BtnNueva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnNueva, "Limpia los campos de la ventana")
        Me.BtnNueva.UseVisualStyleBackColor = True
        '
        'lblTipoSolicitud
        '
        Me.lblTipoSolicitud.AutoSize = True
        Me.lblTipoSolicitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoSolicitud.ForeColor = System.Drawing.Color.Navy
        Me.lblTipoSolicitud.Location = New System.Drawing.Point(393, 42)
        Me.lblTipoSolicitud.Name = "lblTipoSolicitud"
        Me.lblTipoSolicitud.Size = New System.Drawing.Size(0, 16)
        Me.lblTipoSolicitud.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Teal
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(467, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 26)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Valor solicitud:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Navy
        Me.txtTotal.Location = New System.Drawing.Point(565, 37)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotal.Size = New System.Drawing.Size(83, 26)
        Me.txtTotal.TabIndex = 34
        Me.txtTotal.Text = "0.00"
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnImprimir.ForeColor = System.Drawing.Color.Black
        Me.btnImprimir.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(658, 38)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(72, 24)
        Me.btnImprimir.TabIndex = 35
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprime el detalle de vales de la solicitud actual")
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'FrmRegistroCalzado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 436)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GbxDatos)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.BtnBuscarSol)
        Me.Controls.Add(Me.TxtNumeroSol)
        Me.Controls.Add(Me.DpFechaEntrega)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblTipoSolicitud)
        Me.Controls.Add(Me.BtnNueva)
        Me.Controls.Add(Me.pbImagen)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmRegistroCalzado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Solicitudes - Registro Vales Calzado"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxDatos.ResumeLayout(False)
        Me.GbxDatos.PerformLayout()
        CType(Me.dgvValesSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GbxDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoBuxis As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtDivision As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoAs As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscarSol As System.Windows.Forms.Button
    Friend WithEvents TxtNumeroSol As System.Windows.Forms.TextBox
    Friend WithEvents DpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnNueva As System.Windows.Forms.Button
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalVale As System.Windows.Forms.TextBox
    Friend WithEvents TxtCorrelativoFin As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtCorrelativoIni As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Cantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTipoSolicitud As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents DpFechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents DpFechaEmision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoVale As System.Windows.Forms.ComboBox
    Friend WithEvents dgvValesSolicitud As System.Windows.Forms.DataGridView
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents codtipovale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fechaentrega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipovale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidadvales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents corre_ini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents corre_fin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalvale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fechaemision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fechavenc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
