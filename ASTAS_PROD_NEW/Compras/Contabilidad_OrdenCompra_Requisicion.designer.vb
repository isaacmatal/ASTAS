<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_OrdenCompra_Requisicion
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_OrdenCompra_Requisicion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpFechaSolicitadas = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaCrea = New System.Windows.Forms.DateTimePicker
        Me.cmbBodegas = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRequisicion = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpFechaReviso = New System.Windows.Forms.DateTimePicker
        Me.txtUsuarioReviso = New System.Windows.Forms.TextBox
        Me.txtUsuarioSolicita = New System.Windows.Forms.TextBox
        Me.txtOCGenerada = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rad1 = New System.Windows.Forms.RadioButton
        Me.radRechazar = New System.Windows.Forms.RadioButton
        Me.radAutorizar = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbEstatus = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtComentarios = New System.Windows.Forms.TextBox
        Me.dgvDetalle = New System.Windows.Forms.DataGridView
        Me.brnGuardar = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(321, 477)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(98, 40)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(617, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Fecha Emisión:"
        '
        'dtpFechaSolicitadas
        '
        Me.dtpFechaSolicitadas.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaSolicitadas.Location = New System.Drawing.Point(292, 19)
        Me.dtpFechaSolicitadas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpFechaSolicitadas.Name = "dtpFechaSolicitadas"
        Me.dtpFechaSolicitadas.Size = New System.Drawing.Size(114, 22)
        Me.dtpFechaSolicitadas.TabIndex = 169
        '
        'dtpFechaCrea
        '
        Me.dtpFechaCrea.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCrea.Location = New System.Drawing.Point(712, 19)
        Me.dtpFechaCrea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpFechaCrea.Name = "dtpFechaCrea"
        Me.dtpFechaCrea.Size = New System.Drawing.Size(114, 22)
        Me.dtpFechaCrea.TabIndex = 168
        '
        'cmbBodegas
        '
        Me.cmbBodegas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbBodegas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBodegas.FormattingEnabled = True
        Me.cmbBodegas.Location = New System.Drawing.Point(122, 47)
        Me.cmbBodegas.Name = "cmbBodegas"
        Me.cmbBodegas.Size = New System.Drawing.Size(196, 24)
        Me.cmbBodegas.TabIndex = 167
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(7, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 16)
        Me.Label4.TabIndex = 166
        Me.Label4.Text = "Bodega Solicitante:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(223, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Solicitada:"
        '
        'txtRequisicion
        '
        Me.txtRequisicion.Enabled = False
        Me.txtRequisicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequisicion.ForeColor = System.Drawing.Color.Red
        Me.txtRequisicion.Location = New System.Drawing.Point(122, 19)
        Me.txtRequisicion.Name = "txtRequisicion"
        Me.txtRequisicion.Size = New System.Drawing.Size(88, 23)
        Me.txtRequisicion.TabIndex = 171
        Me.txtRequisicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 172
        Me.Label2.Text = "No. Requisición:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtpFechaReviso)
        Me.GroupBox1.Controls.Add(Me.txtUsuarioReviso)
        Me.GroupBox1.Controls.Add(Me.txtUsuarioSolicita)
        Me.GroupBox1.Controls.Add(Me.txtOCGenerada)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbEstatus)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtComentarios)
        Me.GroupBox1.Controls.Add(Me.txtRequisicion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbBodegas)
        Me.GroupBox1.Controls.Add(Me.dtpFechaCrea)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFechaSolicitadas)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1102, 130)
        Me.GroupBox1.TabIndex = 175
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Encabezado"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.Navy
        Me.Label11.Location = New System.Drawing.Point(838, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(121, 16)
        Me.Label11.TabIndex = 190
        Me.Label11.Text = "Fecha de la Revisión:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(838, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 16)
        Me.Label10.TabIndex = 189
        Me.Label10.Text = "Usuario Reviso:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(838, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 16)
        Me.Label5.TabIndex = 188
        Me.Label5.Text = "Usuario Solicito:"
        '
        'dtpFechaReviso
        '
        Me.dtpFechaReviso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaReviso.Location = New System.Drawing.Point(963, 78)
        Me.dtpFechaReviso.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpFechaReviso.Name = "dtpFechaReviso"
        Me.dtpFechaReviso.Size = New System.Drawing.Size(100, 22)
        Me.dtpFechaReviso.TabIndex = 187
        '
        'txtUsuarioReviso
        '
        Me.txtUsuarioReviso.Location = New System.Drawing.Point(963, 50)
        Me.txtUsuarioReviso.Name = "txtUsuarioReviso"
        Me.txtUsuarioReviso.Size = New System.Drawing.Size(100, 22)
        Me.txtUsuarioReviso.TabIndex = 186
        '
        'txtUsuarioSolicita
        '
        Me.txtUsuarioSolicita.Location = New System.Drawing.Point(963, 21)
        Me.txtUsuarioSolicita.Name = "txtUsuarioSolicita"
        Me.txtUsuarioSolicita.Size = New System.Drawing.Size(100, 22)
        Me.txtUsuarioSolicita.TabIndex = 185
        '
        'txtOCGenerada
        '
        Me.txtOCGenerada.Enabled = False
        Me.txtOCGenerada.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOCGenerada.ForeColor = System.Drawing.Color.Red
        Me.txtOCGenerada.Location = New System.Drawing.Point(451, 48)
        Me.txtOCGenerada.Name = "txtOCGenerada"
        Me.txtOCGenerada.Size = New System.Drawing.Size(168, 23)
        Me.txtOCGenerada.TabIndex = 183
        Me.txtOCGenerada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(327, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 16)
        Me.Label8.TabIndex = 184
        Me.Label8.Text = "No. Orden Generada:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rad1)
        Me.GroupBox2.Controls.Add(Me.radRechazar)
        Me.GroupBox2.Controls.Add(Me.radAutorizar)
        Me.GroupBox2.Location = New System.Drawing.Point(678, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(148, 69)
        Me.GroupBox2.TabIndex = 182
        Me.GroupBox2.TabStop = False
        '
        'rad1
        '
        Me.rad1.AutoSize = True
        Me.rad1.Checked = True
        Me.rad1.Location = New System.Drawing.Point(153, 19)
        Me.rad1.Name = "rad1"
        Me.rad1.Size = New System.Drawing.Size(14, 13)
        Me.rad1.TabIndex = 2
        Me.rad1.TabStop = True
        Me.rad1.UseVisualStyleBackColor = True
        Me.rad1.Visible = False
        '
        'radRechazar
        '
        Me.radRechazar.AutoSize = True
        Me.radRechazar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.radRechazar.ForeColor = System.Drawing.Color.Navy
        Me.radRechazar.Location = New System.Drawing.Point(9, 39)
        Me.radRechazar.Name = "radRechazar"
        Me.radRechazar.Size = New System.Drawing.Size(140, 20)
        Me.radRechazar.TabIndex = 1
        Me.radRechazar.Text = "Rechazar Requisición"
        Me.radRechazar.UseVisualStyleBackColor = True
        '
        'radAutorizar
        '
        Me.radAutorizar.AutoSize = True
        Me.radAutorizar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.radAutorizar.ForeColor = System.Drawing.Color.Navy
        Me.radAutorizar.Location = New System.Drawing.Point(9, 15)
        Me.radAutorizar.Name = "radAutorizar"
        Me.radAutorizar.Size = New System.Drawing.Size(139, 20)
        Me.radAutorizar.TabIndex = 0
        Me.radAutorizar.Text = "Autorizar Requisición"
        Me.radAutorizar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(422, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 16)
        Me.Label7.TabIndex = 179
        Me.Label7.Text = "Estatus:"
        '
        'cmbEstatus
        '
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(475, 19)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(138, 24)
        Me.cmbEstatus.TabIndex = 178
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(7, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 16)
        Me.Label6.TabIndex = 176
        Me.Label6.Text = "Comentarios:"
        '
        'txtComentarios
        '
        Me.txtComentarios.Location = New System.Drawing.Point(122, 76)
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(497, 44)
        Me.txtComentarios.TabIndex = 175
        '
        'dgvDetalle
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalle.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetalle.Location = New System.Drawing.Point(12, 145)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(1102, 322)
        Me.dgvDetalle.TabIndex = 176
        '
        'brnGuardar
        '
        Me.brnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.brnGuardar.Image = Global.ASTAS.My.Resources.Resources.filesave
        Me.brnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.brnGuardar.Location = New System.Drawing.Point(12, 477)
        Me.brnGuardar.Name = "brnGuardar"
        Me.brnGuardar.Size = New System.Drawing.Size(98, 40)
        Me.brnGuardar.TabIndex = 177
        Me.brnGuardar.Text = "&Guardar"
        Me.brnGuardar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(116, 477)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(98, 40)
        Me.btnImprimir.TabIndex = 178
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(219, 477)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(98, 40)
        Me.btnProcesar.TabIndex = 179
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'errorProvider
        '
        Me.errorProvider.ContainerControl = Me
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(787, 470)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(327, 15)
        Me.Label9.TabIndex = 185
        Me.Label9.Text = "Para eliminar un registro seleccione la fila y precione Supr."
        '
        'Contabilidad_OrdenCompra_Requisicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1126, 532)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.brnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Contabilidad_OrdenCompra_Requisicion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad_OrdenCompra_Requisicion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaSolicitadas As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaCrea As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbBodegas As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRequisicion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtComentarios As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents brnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents errorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radRechazar As System.Windows.Forms.RadioButton
    Friend WithEvents radAutorizar As System.Windows.Forms.RadioButton
    Friend WithEvents rad1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOCGenerada As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaReviso As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtUsuarioReviso As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioSolicita As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
