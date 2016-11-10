<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_CuentasSaldos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_CuentasSaldos))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDESCRIPCION_CUENTA_02 = New System.Windows.Forms.TextBox
        Me.btnBuscar02 = New System.Windows.Forms.Button
        Me.txtCUENTA_COMPLETA_02 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnBuscar01 = New System.Windows.Forms.Button
        Me.txtCUENTA_COMPLETA_01 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDESCRIPCION_CUENTA_01 = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbMES = New System.Windows.Forms.ComboBox
        Me.cmbAÑO = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.dgvSaldos = New System.Windows.Forms.DataGridView
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION_CUENTA_02)
        Me.GroupBox1.Controls.Add(Me.btnBuscar02)
        Me.GroupBox1.Controls.Add(Me.txtCUENTA_COMPLETA_02)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnBuscar01)
        Me.GroupBox1.Controls.Add(Me.txtCUENTA_COMPLETA_01)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION_CUENTA_01)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(221, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(558, 76)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selección de Cuenta Contable"
        '
        'txtDESCRIPCION_CUENTA_02
        '
        Me.txtDESCRIPCION_CUENTA_02.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDESCRIPCION_CUENTA_02.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_CUENTA_02.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_CUENTA_02.Location = New System.Drawing.Point(192, 45)
        Me.txtDESCRIPCION_CUENTA_02.Name = "txtDESCRIPCION_CUENTA_02"
        Me.txtDESCRIPCION_CUENTA_02.ReadOnly = True
        Me.txtDESCRIPCION_CUENTA_02.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION_CUENTA_02.Size = New System.Drawing.Size(357, 22)
        Me.txtDESCRIPCION_CUENTA_02.TabIndex = 25
        '
        'btnBuscar02
        '
        Me.btnBuscar02.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar02.Image = CType(resources.GetObject("btnBuscar02.Image"), System.Drawing.Image)
        Me.btnBuscar02.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar02.Location = New System.Drawing.Point(168, 45)
        Me.btnBuscar02.Name = "btnBuscar02"
        Me.btnBuscar02.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscar02.TabIndex = 24
        Me.btnBuscar02.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar02.UseVisualStyleBackColor = True
        '
        'txtCUENTA_COMPLETA_02
        '
        Me.txtCUENTA_COMPLETA_02.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCUENTA_COMPLETA_02.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUENTA_COMPLETA_02.ForeColor = System.Drawing.Color.Navy
        Me.txtCUENTA_COMPLETA_02.Location = New System.Drawing.Point(64, 45)
        Me.txtCUENTA_COMPLETA_02.Name = "txtCUENTA_COMPLETA_02"
        Me.txtCUENTA_COMPLETA_02.ReadOnly = True
        Me.txtCUENTA_COMPLETA_02.Size = New System.Drawing.Size(104, 22)
        Me.txtCUENTA_COMPLETA_02.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(12, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Hasta :"
        '
        'btnBuscar01
        '
        Me.btnBuscar01.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar01.Image = CType(resources.GetObject("btnBuscar01.Image"), System.Drawing.Image)
        Me.btnBuscar01.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar01.Location = New System.Drawing.Point(168, 21)
        Me.btnBuscar01.Name = "btnBuscar01"
        Me.btnBuscar01.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscar01.TabIndex = 19
        Me.btnBuscar01.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar01.UseVisualStyleBackColor = True
        '
        'txtCUENTA_COMPLETA_01
        '
        Me.txtCUENTA_COMPLETA_01.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCUENTA_COMPLETA_01.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUENTA_COMPLETA_01.ForeColor = System.Drawing.Color.Navy
        Me.txtCUENTA_COMPLETA_01.Location = New System.Drawing.Point(64, 21)
        Me.txtCUENTA_COMPLETA_01.Name = "txtCUENTA_COMPLETA_01"
        Me.txtCUENTA_COMPLETA_01.ReadOnly = True
        Me.txtCUENTA_COMPLETA_01.Size = New System.Drawing.Size(104, 22)
        Me.txtCUENTA_COMPLETA_01.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(12, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Desde :"
        '
        'txtDESCRIPCION_CUENTA_01
        '
        Me.txtDESCRIPCION_CUENTA_01.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDESCRIPCION_CUENTA_01.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_CUENTA_01.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_CUENTA_01.Location = New System.Drawing.Point(192, 21)
        Me.txtDESCRIPCION_CUENTA_01.Name = "txtDESCRIPCION_CUENTA_01"
        Me.txtDESCRIPCION_CUENTA_01.ReadOnly = True
        Me.txtDESCRIPCION_CUENTA_01.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION_CUENTA_01.Size = New System.Drawing.Size(357, 22)
        Me.txtDESCRIPCION_CUENTA_01.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmbMES)
        Me.GroupBox2.Controls.Add(Me.cmbAÑO)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 80)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Período"
        '
        'cmbMES
        '
        Me.cmbMES.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMES.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMES.ForeColor = System.Drawing.Color.Navy
        Me.cmbMES.FormattingEnabled = True
        Me.cmbMES.Location = New System.Drawing.Point(64, 48)
        Me.cmbMES.Name = "cmbMES"
        Me.cmbMES.Size = New System.Drawing.Size(120, 24)
        Me.cmbMES.TabIndex = 25
        '
        'cmbAÑO
        '
        Me.cmbAÑO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbAÑO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAÑO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAÑO.ForeColor = System.Drawing.Color.Navy
        Me.cmbAÑO.FormattingEnabled = True
        Me.cmbAÑO.Location = New System.Drawing.Point(64, 24)
        Me.cmbAÑO.Name = "cmbAÑO"
        Me.cmbAÑO.Size = New System.Drawing.Size(94, 24)
        Me.cmbAÑO.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(16, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Año :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(16, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Mes :"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(79, 98)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(64, 24)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.Text = "&Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(12, 98)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(64, 24)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgvSaldos
        '
        Me.dgvSaldos.AllowUserToAddRows = False
        Me.dgvSaldos.AllowUserToDeleteRows = False
        Me.dgvSaldos.AllowUserToResizeColumns = False
        Me.dgvSaldos.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray
        Me.dgvSaldos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSaldos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvSaldos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSaldos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cuenta, Me.Desc, Me.Saldo})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSaldos.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSaldos.Location = New System.Drawing.Point(12, 128)
        Me.dgvSaldos.Name = "dgvSaldos"
        Me.dgvSaldos.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSaldos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvSaldos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSaldos.Size = New System.Drawing.Size(767, 401)
        Me.dgvSaldos.TabIndex = 28
        '
        'Cuenta
        '
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        '
        'Desc
        '
        Me.Desc.HeaderText = "Descripción Cuenta"
        Me.Desc.Name = "Desc"
        Me.Desc.ReadOnly = True
        '
        'Saldo
        '
        Me.Saldo.HeaderText = "Saldo"
        Me.Saldo.Name = "Saldo"
        Me.Saldo.ReadOnly = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImprimir.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(146, 98)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 24)
        Me.btnImprimir.TabIndex = 29
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Button1.Location = New System.Drawing.Point(227, 98)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 24)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "&Saldos Mes"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Contabilidad_CuentasSaldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 541)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvSaldos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_CuentasSaldos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Consulta de Saldos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCUENTA_COMPLETA_02 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar01 As System.Windows.Forms.Button
    Friend WithEvents txtCUENTA_COMPLETA_01 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPCION_CUENTA_01 As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar02 As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMES As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAÑO As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPCION_CUENTA_02 As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvSaldos As System.Windows.Forms.DataGridView
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
