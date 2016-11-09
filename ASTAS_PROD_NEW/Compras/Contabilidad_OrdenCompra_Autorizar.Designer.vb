<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_OrdenCompra_Autorizar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_OrdenCompra_Autorizar))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.chkFechas = New System.Windows.Forms.CheckBox
        Me.dpFechaHasta = New System.Windows.Forms.DateTimePicker
        Me.dpFechaDesde = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbBODEGA = New System.Windows.Forms.ComboBox
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvOrdenesCompra = New System.Windows.Forms.DataGridView
        Me.Autorizar = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.OC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaOC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion_Prov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Percepcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FormaPago = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CondicionPago = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Usuario_Procesado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha_Procesado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Btn_Todas = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnAnular = New System.Windows.Forms.Button
        Me.btnAutorizar = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvOrdenesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.chkFechas)
        Me.GroupBox1.Controls.Add(Me.dpFechaHasta)
        Me.GroupBox1.Controls.Add(Me.dpFechaDesde)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbBODEGA)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(683, 96)
        Me.GroupBox1.TabIndex = 85
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(400, 48)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(72, 24)
        Me.btnBuscar.TabIndex = 101
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFechas.Checked = True
        Me.chkFechas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFechas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chkFechas.ForeColor = System.Drawing.Color.Red
        Me.chkFechas.Location = New System.Drawing.Point(458, 74)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(214, 20)
        Me.chkFechas.TabIndex = 56
        Me.chkFechas.Text = "No considerar Fechas en búsqueda"
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'dpFechaHasta
        '
        Me.dpFechaHasta.CustomFormat = "dd-MMM-yyyy"
        Me.dpFechaHasta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaHasta.Location = New System.Drawing.Point(552, 48)
        Me.dpFechaHasta.Name = "dpFechaHasta"
        Me.dpFechaHasta.Size = New System.Drawing.Size(120, 22)
        Me.dpFechaHasta.TabIndex = 55
        '
        'dpFechaDesde
        '
        Me.dpFechaDesde.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFechaDesde.CustomFormat = "dd-MMM-yyyy"
        Me.dpFechaDesde.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFechaDesde.Location = New System.Drawing.Point(552, 24)
        Me.dpFechaDesde.Name = "dpFechaDesde"
        Me.dpFechaDesde.Size = New System.Drawing.Size(120, 22)
        Me.dpFechaDesde.TabIndex = 54
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(472, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 16)
        Me.Label17.TabIndex = 53
        Me.Label17.Text = "Hasta :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(472, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 16)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Desde :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Bodega :"
        '
        'cmbBODEGA
        '
        Me.cmbBODEGA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBODEGA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBODEGA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBODEGA.ForeColor = System.Drawing.Color.Navy
        Me.cmbBODEGA.FormattingEnabled = True
        Me.cmbBODEGA.Location = New System.Drawing.Point(71, 48)
        Me.cmbBODEGA.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbBODEGA.Name = "cmbBODEGA"
        Me.cmbBODEGA.Size = New System.Drawing.Size(265, 24)
        Me.cmbBODEGA.TabIndex = 1
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(72, 24)
        Me.cmbCOMPAÑIA.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(400, 24)
        Me.cmbCOMPAÑIA.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía :"
        '
        'dgvOrdenesCompra
        '
        Me.dgvOrdenesCompra.AllowUserToAddRows = False
        Me.dgvOrdenesCompra.AllowUserToDeleteRows = False
        Me.dgvOrdenesCompra.AllowUserToResizeColumns = False
        Me.dgvOrdenesCompra.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.dgvOrdenesCompra.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOrdenesCompra.BackgroundColor = System.Drawing.Color.MintCream
        Me.dgvOrdenesCompra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvOrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrdenesCompra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Autorizar, Me.OC, Me.FechaOC, Me.Descripcion_Prov, Me.SubTotal, Me.IVA, Me.Total, Me.Percepcion, Me.TotalC, Me.FormaPago, Me.CondicionPago, Me.Usuario_Procesado, Me.Fecha_Procesado})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOrdenesCompra.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOrdenesCompra.Location = New System.Drawing.Point(8, 112)
        Me.dgvOrdenesCompra.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvOrdenesCompra.Name = "dgvOrdenesCompra"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOrdenesCompra.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvOrdenesCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrdenesCompra.Size = New System.Drawing.Size(903, 424)
        Me.dgvOrdenesCompra.TabIndex = 100
        '
        'Autorizar
        '
        Me.Autorizar.HeaderText = "Seleccionar"
        Me.Autorizar.Name = "Autorizar"
        Me.Autorizar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Autorizar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'OC
        '
        Me.OC.HeaderText = "Orden Compra"
        Me.OC.Name = "OC"
        '
        'FechaOC
        '
        Me.FechaOC.HeaderText = "Fecha OC"
        Me.FechaOC.Name = "FechaOC"
        '
        'Descripcion_Prov
        '
        Me.Descripcion_Prov.HeaderText = "Nombre Proveedor"
        Me.Descripcion_Prov.Name = "Descripcion_Prov"
        '
        'SubTotal
        '
        Me.SubTotal.HeaderText = "Sub Total"
        Me.SubTotal.Name = "SubTotal"
        '
        'IVA
        '
        Me.IVA.HeaderText = "IVA"
        Me.IVA.Name = "IVA"
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        '
        'Percepcion
        '
        Me.Percepcion.HeaderText = "% Perc."
        Me.Percepcion.Name = "Percepcion"
        '
        'TotalC
        '
        Me.TotalC.HeaderText = "Total Compra"
        Me.TotalC.Name = "TotalC"
        '
        'FormaPago
        '
        Me.FormaPago.HeaderText = "Forma Pago"
        Me.FormaPago.Name = "FormaPago"
        '
        'CondicionPago
        '
        Me.CondicionPago.HeaderText = "Condición Pago"
        Me.CondicionPago.Name = "CondicionPago"
        '
        'Usuario_Procesado
        '
        Me.Usuario_Procesado.HeaderText = "Usuario Procesado"
        Me.Usuario_Procesado.Name = "Usuario_Procesado"
        '
        'Fecha_Procesado
        '
        Me.Fecha_Procesado.HeaderText = "Fecha Procesado"
        Me.Fecha_Procesado.Name = "Fecha_Procesado"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Btn_Todas)
        Me.GroupBox2.Controls.Add(Me.btnImprimir)
        Me.GroupBox2.Controls.Add(Me.btnAnular)
        Me.GroupBox2.Controls.Add(Me.btnAutorizar)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(697, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(214, 96)
        Me.GroupBox2.TabIndex = 101
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Autorizar / Anular / Ver"
        '
        'Btn_Todas
        '
        Me.Btn_Todas.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Btn_Todas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btn_Todas.Image = Global.ASTAS.My.Resources.Resources.todo
        Me.Btn_Todas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Todas.Location = New System.Drawing.Point(108, 54)
        Me.Btn_Todas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Btn_Todas.Name = "Btn_Todas"
        Me.Btn_Todas.Size = New System.Drawing.Size(96, 24)
        Me.Btn_Todas.TabIndex = 105
        Me.Btn_Todas.Text = "&Marcar Todas"
        Me.Btn_Todas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Btn_Todas, "Marcar o Desmarcar las OdC para Autorización.")
        Me.Btn_Todas.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(108, 22)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(96, 24)
        Me.btnImprimir.TabIndex = 104
        Me.btnImprimir.Text = "&Ver OC"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnAnular
        '
        Me.btnAnular.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnAnular.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnular.Location = New System.Drawing.Point(6, 54)
        Me.btnAnular.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(96, 24)
        Me.btnAnular.TabIndex = 103
        Me.btnAnular.Text = "&No Autorizar"
        Me.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnular.UseVisualStyleBackColor = True
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnAutorizar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAutorizar.Image = CType(resources.GetObject("btnAutorizar.Image"), System.Drawing.Image)
        Me.btnAutorizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAutorizar.Location = New System.Drawing.Point(6, 22)
        Me.btnAutorizar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(96, 24)
        Me.btnAutorizar.TabIndex = 102
        Me.btnAutorizar.Text = "&Autorizar"
        Me.btnAutorizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'Contabilidad_OrdenCompra_Autorizar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 538)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvOrdenesCompra)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_OrdenCompra_Autorizar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas x Pagar - Autorización de Ordenes de Compra"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvOrdenesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkFechas As System.Windows.Forms.CheckBox
    Friend WithEvents dpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbBODEGA As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvOrdenesCompra As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents btnAnular As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Autorizar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents OC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaOC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion_Prov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Percepcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormaPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CondicionPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Procesado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Procesado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Btn_Todas As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
