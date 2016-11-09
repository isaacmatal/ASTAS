<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_ProgramarPorFechas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_ProgramarPorFechas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbTiempoComida = New System.Windows.Forms.ComboBox
        Me.cmbBodega = New System.Windows.Forms.ComboBox
        Me.CustomCalendar1 = New ASTAS.CustomCalendar
        Me.lblMenu = New System.Windows.Forms.Label
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkSelectAllMonth = New System.Windows.Forms.CheckBox
        Me.dgvRecetas = New System.Windows.Forms.DataGridView
        Me.Seleccionar = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtBuscar = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvRecetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 27)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Tiempo de Comida:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Bodega:"
        '
        'cmbTiempoComida
        '
        Me.cmbTiempoComida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiempoComida.FormattingEnabled = True
        Me.cmbTiempoComida.Location = New System.Drawing.Point(80, 32)
        Me.cmbTiempoComida.Name = "cmbTiempoComida"
        Me.cmbTiempoComida.Size = New System.Drawing.Size(238, 21)
        Me.cmbTiempoComida.TabIndex = 33
        '
        'cmbBodega
        '
        Me.cmbBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodega.FormattingEnabled = True
        Me.cmbBodega.Location = New System.Drawing.Point(80, 7)
        Me.cmbBodega.Name = "cmbBodega"
        Me.cmbBodega.Size = New System.Drawing.Size(238, 21)
        Me.cmbBodega.TabIndex = 32
        '
        'CustomCalendar1
        '
        Me.CustomCalendar1.BackColor = System.Drawing.Color.White
        Me.CustomCalendar1.BackgroundImage = CType(resources.GetObject("CustomCalendar1.BackgroundImage"), System.Drawing.Image)
        Me.CustomCalendar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CustomCalendar1.Location = New System.Drawing.Point(67, 15)
        Me.CustomCalendar1.Name = "CustomCalendar1"
        Me.CustomCalendar1.Size = New System.Drawing.Size(218, 207)
        Me.CustomCalendar1.TabIndex = 30
        '
        'lblMenu
        '
        Me.lblMenu.AutoSize = True
        Me.lblMenu.Location = New System.Drawing.Point(37, 61)
        Me.lblMenu.Name = "lblMenu"
        Me.lblMenu.Size = New System.Drawing.Size(37, 13)
        Me.lblMenu.TabIndex = 26
        Me.lblMenu.Text = "Menu:"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(11, 565)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 27)
        Me.btnGuardar.TabIndex = 37
        Me.btnGuardar.Text = "&Aplicar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(301, 565)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 27)
        Me.btnCancelar.TabIndex = 38
        Me.btnCancelar.Text = "&Cerrar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkSelectAllMonth)
        Me.GroupBox1.Controls.Add(Me.CustomCalendar1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 312)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 231)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccionar Fechas"
        '
        'chkSelectAllMonth
        '
        Me.chkSelectAllMonth.Location = New System.Drawing.Point(289, 19)
        Me.chkSelectAllMonth.Name = "chkSelectAllMonth"
        Me.chkSelectAllMonth.Size = New System.Drawing.Size(85, 33)
        Me.chkSelectAllMonth.TabIndex = 32
        Me.chkSelectAllMonth.Text = "Seleccionar Todo el Mes"
        Me.chkSelectAllMonth.UseVisualStyleBackColor = True
        '
        'dgvRecetas
        '
        Me.dgvRecetas.AllowUserToAddRows = False
        Me.dgvRecetas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvRecetas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRecetas.BackgroundColor = System.Drawing.Color.White
        Me.dgvRecetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecetas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccionar, Me.CODIGO, Me.Descripcion, Me.Unidad, Me.Cantidad})
        Me.dgvRecetas.Location = New System.Drawing.Point(3, 84)
        Me.dgvRecetas.Name = "dgvRecetas"
        Me.dgvRecetas.RowHeadersVisible = False
        Me.dgvRecetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecetas.Size = New System.Drawing.Size(376, 223)
        Me.dgvRecetas.TabIndex = 41
        '
        'Seleccionar
        '
        Me.Seleccionar.HeaderText = ""
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Width = 30
        '
        'CODIGO
        '
        Me.CODIGO.HeaderText = "Codigo Producto"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.Width = 68
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción de Producto"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 125
        '
        'Unidad
        '
        Me.Unidad.HeaderText = "Unidad de Medida"
        Me.Unidad.Name = "Unidad"
        Me.Unidad.ReadOnly = True
        Me.Unidad.Width = 90
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 60
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(80, 58)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(238, 20)
        Me.txtBuscar.TabIndex = 42
        '
        'Cafeteria_ProgramarPorFechas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(382, 601)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.dgvRecetas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbTiempoComida)
        Me.Controls.Add(Me.cmbBodega)
        Me.Controls.Add(Me.lblMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Cafeteria_ProgramarPorFechas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Programar Receta Varias Fechas"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvRecetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTiempoComida As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBodega As System.Windows.Forms.ComboBox
    Friend WithEvents CustomCalendar1 As ASTAS.CustomCalendar
    Friend WithEvents lblMenu As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvRecetas As System.Windows.Forms.DataGridView
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Seleccionar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkSelectAllMonth As System.Windows.Forms.CheckBox
End Class
