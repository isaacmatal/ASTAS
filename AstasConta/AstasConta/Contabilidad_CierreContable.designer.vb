<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_CierreContable
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_CierreContable))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbLIBRO_CONTABLE = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblPROCESADO = New System.Windows.Forms.Label
        Me.chkCIERRE_FINAL = New System.Windows.Forms.CheckBox
        Me.chkPRE_CIERRE = New System.Windows.Forms.CheckBox
        Me.nudAÑO = New System.Windows.Forms.NumericUpDown
        Me.cmbMES = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgvCierres = New System.Windows.Forms.DataGridView
        Me.Año = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Mes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PreCierre = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CierreFinal = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Procesado = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UsuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsuarioModificaion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.btnRegeneraSaldos = New System.Windows.Forms.Button
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAÑO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCierres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnRegeneraSaldos)
        Me.GroupBox1.Controls.Add(Me.cmbLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.lblPROCESADO)
        Me.GroupBox1.Controls.Add(Me.chkCIERRE_FINAL)
        Me.GroupBox1.Controls.Add(Me.chkPRE_CIERRE)
        Me.GroupBox1.Controls.Add(Me.btnProcesar)
        Me.GroupBox1.Controls.Add(Me.nudAÑO)
        Me.GroupBox1.Controls.Add(Me.cmbMES)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(555, 152)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cierres Contables"
        '
        'cmbLIBRO_CONTABLE
        '
        Me.cmbLIBRO_CONTABLE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLIBRO_CONTABLE.Enabled = False
        Me.cmbLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE.Location = New System.Drawing.Point(114, 23)
        Me.cmbLIBRO_CONTABLE.Name = "cmbLIBRO_CONTABLE"
        Me.cmbLIBRO_CONTABLE.Size = New System.Drawing.Size(344, 24)
        Me.cmbLIBRO_CONTABLE.TabIndex = 64
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(8, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Libro Contable :"
        '
        'lblPROCESADO
        '
        Me.lblPROCESADO.BackColor = System.Drawing.Color.Yellow
        Me.lblPROCESADO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPROCESADO.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPROCESADO.ForeColor = System.Drawing.Color.Red
        Me.lblPROCESADO.Location = New System.Drawing.Point(378, 104)
        Me.lblPROCESADO.Name = "lblPROCESADO"
        Me.lblPROCESADO.Size = New System.Drawing.Size(168, 32)
        Me.lblPROCESADO.TabIndex = 61
        Me.lblPROCESADO.Text = "PROCESADO"
        Me.lblPROCESADO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPROCESADO.Visible = False
        '
        'chkCIERRE_FINAL
        '
        Me.chkCIERRE_FINAL.AutoSize = True
        Me.chkCIERRE_FINAL.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCIERRE_FINAL.ForeColor = System.Drawing.Color.Navy
        Me.chkCIERRE_FINAL.Location = New System.Drawing.Point(114, 123)
        Me.chkCIERRE_FINAL.Name = "chkCIERRE_FINAL"
        Me.chkCIERRE_FINAL.Size = New System.Drawing.Size(149, 20)
        Me.chkCIERRE_FINAL.TabIndex = 60
        Me.chkCIERRE_FINAL.Text = "Cierre Contable Final"
        Me.chkCIERRE_FINAL.UseVisualStyleBackColor = True
        '
        'chkPRE_CIERRE
        '
        Me.chkPRE_CIERRE.AutoSize = True
        Me.chkPRE_CIERRE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPRE_CIERRE.ForeColor = System.Drawing.Color.Navy
        Me.chkPRE_CIERRE.Location = New System.Drawing.Point(114, 94)
        Me.chkPRE_CIERRE.Name = "chkPRE_CIERRE"
        Me.chkPRE_CIERRE.Size = New System.Drawing.Size(142, 20)
        Me.chkPRE_CIERRE.TabIndex = 60
        Me.chkPRE_CIERRE.Text = "Pre-Cierre Contable"
        Me.chkPRE_CIERRE.UseVisualStyleBackColor = True
        '
        'nudAÑO
        '
        Me.nudAÑO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudAÑO.ForeColor = System.Drawing.Color.Navy
        Me.nudAÑO.Location = New System.Drawing.Point(226, 58)
        Me.nudAÑO.Maximum = New Decimal(New Integer() {3011, 0, 0, 0})
        Me.nudAÑO.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.nudAÑO.Name = "nudAÑO"
        Me.nudAÑO.Size = New System.Drawing.Size(66, 22)
        Me.nudAÑO.TabIndex = 23
        Me.nudAÑO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudAÑO.Value = New Decimal(New Integer() {2010, 0, 0, 0})
        '
        'cmbMES
        '
        Me.cmbMES.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMES.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMES.ForeColor = System.Drawing.Color.Navy
        Me.cmbMES.FormattingEnabled = True
        Me.cmbMES.Location = New System.Drawing.Point(114, 58)
        Me.cmbMES.Name = "cmbMES"
        Me.cmbMES.Size = New System.Drawing.Size(104, 24)
        Me.cmbMES.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(8, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Período Contable :"
        '
        'dgvCierres
        '
        Me.dgvCierres.AllowUserToAddRows = False
        Me.dgvCierres.AllowUserToDeleteRows = False
        Me.dgvCierres.AllowUserToResizeColumns = False
        Me.dgvCierres.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvCierres.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCierres.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCierres.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCierres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCierres.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Año, Me.Mes, Me.PreCierre, Me.CierreFinal, Me.Procesado, Me.UsuarioCreacion, Me.FechaCreacion, Me.UsuarioModificaion, Me.FechaModificacion})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCierres.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCierres.Location = New System.Drawing.Point(12, 168)
        Me.dgvCierres.MultiSelect = False
        Me.dgvCierres.Name = "dgvCierres"
        Me.dgvCierres.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCierres.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCierres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCierres.Size = New System.Drawing.Size(673, 336)
        Me.dgvCierres.TabIndex = 29
        '
        'Año
        '
        Me.Año.HeaderText = "Año"
        Me.Año.Name = "Año"
        Me.Año.ReadOnly = True
        '
        'Mes
        '
        Me.Mes.HeaderText = "Mes"
        Me.Mes.Name = "Mes"
        Me.Mes.ReadOnly = True
        '
        'PreCierre
        '
        Me.PreCierre.HeaderText = "Pre-Cierre"
        Me.PreCierre.Name = "PreCierre"
        Me.PreCierre.ReadOnly = True
        Me.PreCierre.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PreCierre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'CierreFinal
        '
        Me.CierreFinal.HeaderText = "Cierre Final"
        Me.CierreFinal.Name = "CierreFinal"
        Me.CierreFinal.ReadOnly = True
        Me.CierreFinal.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CierreFinal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Procesado
        '
        Me.Procesado.HeaderText = "Procesado"
        Me.Procesado.Name = "Procesado"
        Me.Procesado.ReadOnly = True
        Me.Procesado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Procesado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'UsuarioCreacion
        '
        Me.UsuarioCreacion.HeaderText = "Usuario Creación"
        Me.UsuarioCreacion.Name = "UsuarioCreacion"
        Me.UsuarioCreacion.ReadOnly = True
        '
        'FechaCreacion
        '
        Me.FechaCreacion.HeaderText = "Fecha Creación"
        Me.FechaCreacion.Name = "FechaCreacion"
        Me.FechaCreacion.ReadOnly = True
        '
        'UsuarioModificaion
        '
        Me.UsuarioModificaion.HeaderText = "Usuario Modificación"
        Me.UsuarioModificaion.Name = "UsuarioModificaion"
        Me.UsuarioModificaion.ReadOnly = True
        '
        'FechaModificacion
        '
        Me.FechaModificacion.HeaderText = "Fecha Modificación"
        Me.FechaModificacion.Name = "FechaModificacion"
        Me.FechaModificacion.ReadOnly = True
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(573, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(112, 158)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 30
        Me.pbImagen.TabStop = False
        '
        'btnRegeneraSaldos
        '
        Me.btnRegeneraSaldos.Image = Global.AstasConta.My.Resources.Resources.reload3
        Me.btnRegeneraSaldos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRegeneraSaldos.Location = New System.Drawing.Point(11, 81)
        Me.btnRegeneraSaldos.Name = "btnRegeneraSaldos"
        Me.btnRegeneraSaldos.Size = New System.Drawing.Size(78, 60)
        Me.btnRegeneraSaldos.TabIndex = 65
        Me.btnRegeneraSaldos.Text = "Regenerar Saldos"
        Me.btnRegeneraSaldos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRegeneraSaldos.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(298, 58)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(72, 24)
        Me.btnNuevo.TabIndex = 62
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnProcesar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(466, 58)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(80, 24)
        Me.btnProcesar.TabIndex = 58
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(378, 58)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 24)
        Me.btnGuardar.TabIndex = 20
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Contabilidad_CierreContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 515)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.dgvCierres)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_CierreContable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Cierre Contable"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAÑO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCierres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents nudAÑO As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbMES As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkPRE_CIERRE As System.Windows.Forms.CheckBox
    Friend WithEvents chkCIERRE_FINAL As System.Windows.Forms.CheckBox
    Friend WithEvents dgvCierres As System.Windows.Forms.DataGridView
    Friend WithEvents Año As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreCierre As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CierreFinal As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Procesado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UsuarioCreacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaCreacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioModificaion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaModificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblPROCESADO As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents cmbLIBRO_CONTABLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnRegeneraSaldos As System.Windows.Forms.Button
End Class
