<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CooperativaAccesoBloqueoConsumo
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CooperativaAccesoBloqueoConsumo))
        Me.lblEmpleado = New System.Windows.Forms.Label
        Me.cmbTipoSolic = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpVigencia = New System.Windows.Forms.DateTimePicker
        Me.dgvAccesos = New System.Windows.Forms.DataGridView
        Me.descsoli = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MontoMax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.vigencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.solicitud = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMontoMax = New System.Windows.Forms.TextBox
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.txtCodBux = New System.Windows.Forms.TextBox
        Me.btnBuscar = New System.Windows.Forms.Button
        CType(Me.dgvAccesos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEmpleado
        '
        Me.lblEmpleado.AutoSize = True
        Me.lblEmpleado.BackColor = System.Drawing.Color.Transparent
        Me.lblEmpleado.Location = New System.Drawing.Point(89, 13)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(239, 16)
        Me.lblEmpleado.TabIndex = 0
        Me.lblEmpleado.Text = "<- Digite el codigo del empleado o click en buscar"
        '
        'cmbTipoSolic
        '
        Me.cmbTipoSolic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoSolic.DropDownWidth = 300
        Me.cmbTipoSolic.FormattingEnabled = True
        Me.cmbTipoSolic.Location = New System.Drawing.Point(92, 37)
        Me.cmbTipoSolic.Name = "cmbTipoSolic"
        Me.cmbTipoSolic.Size = New System.Drawing.Size(306, 24)
        Me.cmbTipoSolic.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(13, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo Solicitud:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(177, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Vigencia hasta:"
        Me.Label3.Visible = False
        '
        'dtpVigencia
        '
        Me.dtpVigencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVigencia.Location = New System.Drawing.Point(262, 70)
        Me.dtpVigencia.Name = "dtpVigencia"
        Me.dtpVigencia.Size = New System.Drawing.Size(98, 22)
        Me.dtpVigencia.TabIndex = 4
        Me.dtpVigencia.Visible = False
        '
        'dgvAccesos
        '
        Me.dgvAccesos.AllowUserToAddRows = False
        Me.dgvAccesos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvAccesos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAccesos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAccesos.BackgroundColor = System.Drawing.Color.Azure
        Me.dgvAccesos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvAccesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAccesos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.descsoli, Me.MontoMax, Me.vigencia, Me.solicitud})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAccesos.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvAccesos.Location = New System.Drawing.Point(16, 102)
        Me.dgvAccesos.Name = "dgvAccesos"
        Me.dgvAccesos.ReadOnly = True
        Me.dgvAccesos.RowHeadersVisible = False
        Me.dgvAccesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAccesos.Size = New System.Drawing.Size(382, 203)
        Me.dgvAccesos.TabIndex = 5
        '
        'descsoli
        '
        Me.descsoli.DataPropertyName = "DESCRIPCION_SOLICITUD"
        Me.descsoli.HeaderText = "Consumo de:"
        Me.descsoli.Name = "descsoli"
        Me.descsoli.ReadOnly = True
        Me.descsoli.Width = 300
        '
        'MontoMax
        '
        Me.MontoMax.DataPropertyName = "MONTO_MAXIMO"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.MontoMax.DefaultCellStyle = DataGridViewCellStyle2
        Me.MontoMax.HeaderText = "Monto Máximo"
        Me.MontoMax.Name = "MontoMax"
        Me.MontoMax.ReadOnly = True
        Me.MontoMax.Width = 70
        '
        'vigencia
        '
        Me.vigencia.DataPropertyName = "VIGENTE_HASTA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.vigencia.DefaultCellStyle = DataGridViewCellStyle3
        Me.vigencia.HeaderText = "Vigencia"
        Me.vigencia.Name = "vigencia"
        Me.vigencia.ReadOnly = True
        Me.vigencia.Visible = False
        Me.vigencia.Width = 80
        '
        'solicitud
        '
        Me.solicitud.DataPropertyName = "SOLICITUD"
        Me.solicitud.HeaderText = "solicitud"
        Me.solicitud.Name = "solicitud"
        Me.solicitud.ReadOnly = True
        Me.solicitud.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(190, 69)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(13, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Monto Maximo:"
        '
        'txtMontoMax
        '
        Me.txtMontoMax.Location = New System.Drawing.Point(92, 69)
        Me.txtMontoMax.Name = "txtMontoMax"
        Me.txtMontoMax.Size = New System.Drawing.Size(78, 22)
        Me.txtMontoMax.TabIndex = 13
        Me.txtMontoMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEliminar
        '
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Image = Global.ASTAS.My.Resources.Resources.editdelete
        Me.btnEliminar.Location = New System.Drawing.Point(220, 69)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(24, 24)
        Me.btnEliminar.TabIndex = 14
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'txtCodBux
        '
        Me.txtCodBux.Enabled = False
        Me.txtCodBux.Location = New System.Drawing.Point(16, 10)
        Me.txtCodBux.Name = "txtCodBux"
        Me.txtCodBux.Size = New System.Drawing.Size(47, 22)
        Me.txtCodBux.TabIndex = 15
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.ASTAS.My.Resources.Resources.search
        Me.btnBuscar.Location = New System.Drawing.Point(66, 9)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscar.TabIndex = 16
        Me.btnBuscar.UseVisualStyleBackColor = True
        Me.btnBuscar.Visible = False
        '
        'CooperativaAccesoBloqueoConsumo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 317)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtCodBux)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.txtMontoMax)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.dgvAccesos)
        Me.Controls.Add(Me.dtpVigencia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbTipoSolic)
        Me.Controls.Add(Me.lblEmpleado)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CooperativaAccesoBloqueoConsumo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Definir Limite Crédito por Bloqueo de Consumo"
        CType(Me.dgvAccesos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
    Friend WithEvents cmbTipoSolic As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvAccesos As System.Windows.Forms.DataGridView
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMontoMax As System.Windows.Forms.TextBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents descsoli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontoMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vigencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents solicitud As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCodBux As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class
