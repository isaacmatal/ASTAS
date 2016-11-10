<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reportes_Rubros_Detalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Reportes_Rubros_Detalle))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChkLinea = New System.Windows.Forms.CheckBox
        Me.TxtDETALLE = New System.Windows.Forms.TextBox
        Me.TxtCUENTA_COMPLETA_02 = New System.Windows.Forms.TextBox
        Me.TxtCUENTA_COMPLETA_01 = New System.Windows.Forms.TextBox
        Me.cmbGRUPO = New System.Windows.Forms.ComboBox
        Me.cmbCARGO_ABONO = New System.Windows.Forms.ComboBox
        Me.btnBuscar02 = New System.Windows.Forms.Button
        Me.btnBuscar01 = New System.Windows.Forms.Button
        Me.lblDESCRIPCION_CUENTA_02 = New System.Windows.Forms.Label
        Me.lblDESCRIPCION_CUENTA_01 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.cmbRUBRO = New System.Windows.Forms.ComboBox
        Me.cmbREPORTE = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblLIBRO_CONTABLE = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvDetalle = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label9 = New System.Windows.Forms.Label
        Me.Txt_Nombe = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Txt_Nombe)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.ChkLinea)
        Me.GroupBox1.Controls.Add(Me.TxtDETALLE)
        Me.GroupBox1.Controls.Add(Me.TxtCUENTA_COMPLETA_02)
        Me.GroupBox1.Controls.Add(Me.TxtCUENTA_COMPLETA_01)
        Me.GroupBox1.Controls.Add(Me.cmbGRUPO)
        Me.GroupBox1.Controls.Add(Me.cmbCARGO_ABONO)
        Me.GroupBox1.Controls.Add(Me.btnBuscar02)
        Me.GroupBox1.Controls.Add(Me.btnBuscar01)
        Me.GroupBox1.Controls.Add(Me.lblDESCRIPCION_CUENTA_02)
        Me.GroupBox1.Controls.Add(Me.lblDESCRIPCION_CUENTA_01)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.cmbRUBRO)
        Me.GroupBox1.Controls.Add(Me.cmbREPORTE)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 244)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Detalle de Rubros de Reportes"
        '
        'ChkLinea
        '
        Me.ChkLinea.AutoSize = True
        Me.ChkLinea.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkLinea.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkLinea.Location = New System.Drawing.Point(298, 220)
        Me.ChkLinea.Name = "ChkLinea"
        Me.ChkLinea.Size = New System.Drawing.Size(94, 20)
        Me.ChkLinea.TabIndex = 9
        Me.ChkLinea.Text = "Salto de Línea"
        Me.ChkLinea.UseVisualStyleBackColor = True
        '
        'TxtDETALLE
        '
        Me.TxtDETALLE.Location = New System.Drawing.Point(88, 121)
        Me.TxtDETALLE.Name = "TxtDETALLE"
        Me.TxtDETALLE.Size = New System.Drawing.Size(88, 22)
        Me.TxtDETALLE.TabIndex = 4
        '
        'TxtCUENTA_COMPLETA_02
        '
        Me.TxtCUENTA_COMPLETA_02.Location = New System.Drawing.Point(88, 168)
        Me.TxtCUENTA_COMPLETA_02.Name = "TxtCUENTA_COMPLETA_02"
        Me.TxtCUENTA_COMPLETA_02.Size = New System.Drawing.Size(88, 22)
        Me.TxtCUENTA_COMPLETA_02.TabIndex = 6
        '
        'TxtCUENTA_COMPLETA_01
        '
        Me.TxtCUENTA_COMPLETA_01.Location = New System.Drawing.Point(88, 145)
        Me.TxtCUENTA_COMPLETA_01.Name = "TxtCUENTA_COMPLETA_01"
        Me.TxtCUENTA_COMPLETA_01.Size = New System.Drawing.Size(88, 22)
        Me.TxtCUENTA_COMPLETA_01.TabIndex = 5
        '
        'cmbGRUPO
        '
        Me.cmbGRUPO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGRUPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGRUPO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGRUPO.ForeColor = System.Drawing.Color.Navy
        Me.cmbGRUPO.FormattingEnabled = True
        Me.cmbGRUPO.Location = New System.Drawing.Point(88, 72)
        Me.cmbGRUPO.Name = "cmbGRUPO"
        Me.cmbGRUPO.Size = New System.Drawing.Size(304, 24)
        Me.cmbGRUPO.TabIndex = 2
        '
        'cmbCARGO_ABONO
        '
        Me.cmbCARGO_ABONO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCARGO_ABONO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCARGO_ABONO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCARGO_ABONO.ForeColor = System.Drawing.Color.Navy
        Me.cmbCARGO_ABONO.FormattingEnabled = True
        Me.cmbCARGO_ABONO.Items.AddRange(New Object() {"Cargo", "Abono", "Saldo"})
        Me.cmbCARGO_ABONO.Location = New System.Drawing.Point(88, 214)
        Me.cmbCARGO_ABONO.Name = "cmbCARGO_ABONO"
        Me.cmbCARGO_ABONO.Size = New System.Drawing.Size(112, 24)
        Me.cmbCARGO_ABONO.TabIndex = 8
        '
        'btnBuscar02
        '
        Me.btnBuscar02.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnBuscar02.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar02.Image = CType(resources.GetObject("btnBuscar02.Image"), System.Drawing.Image)
        Me.btnBuscar02.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar02.Location = New System.Drawing.Point(176, 168)
        Me.btnBuscar02.Name = "btnBuscar02"
        Me.btnBuscar02.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscar02.TabIndex = 24
        Me.btnBuscar02.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar02.UseVisualStyleBackColor = True
        '
        'btnBuscar01
        '
        Me.btnBuscar01.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnBuscar01.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar01.Image = CType(resources.GetObject("btnBuscar01.Image"), System.Drawing.Image)
        Me.btnBuscar01.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar01.Location = New System.Drawing.Point(176, 144)
        Me.btnBuscar01.Name = "btnBuscar01"
        Me.btnBuscar01.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscar01.TabIndex = 24
        Me.btnBuscar01.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar01.UseVisualStyleBackColor = True
        '
        'lblDESCRIPCION_CUENTA_02
        '
        Me.lblDESCRIPCION_CUENTA_02.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDESCRIPCION_CUENTA_02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDESCRIPCION_CUENTA_02.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblDESCRIPCION_CUENTA_02.ForeColor = System.Drawing.Color.Navy
        Me.lblDESCRIPCION_CUENTA_02.Location = New System.Drawing.Point(200, 168)
        Me.lblDESCRIPCION_CUENTA_02.Name = "lblDESCRIPCION_CUENTA_02"
        Me.lblDESCRIPCION_CUENTA_02.Size = New System.Drawing.Size(344, 22)
        Me.lblDESCRIPCION_CUENTA_02.TabIndex = 23
        Me.lblDESCRIPCION_CUENTA_02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDESCRIPCION_CUENTA_01
        '
        Me.lblDESCRIPCION_CUENTA_01.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDESCRIPCION_CUENTA_01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDESCRIPCION_CUENTA_01.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblDESCRIPCION_CUENTA_01.ForeColor = System.Drawing.Color.Navy
        Me.lblDESCRIPCION_CUENTA_01.Location = New System.Drawing.Point(200, 144)
        Me.lblDESCRIPCION_CUENTA_01.Name = "lblDESCRIPCION_CUENTA_01"
        Me.lblDESCRIPCION_CUENTA_01.Size = New System.Drawing.Size(344, 22)
        Me.lblDESCRIPCION_CUENTA_01.TabIndex = 23
        Me.lblDESCRIPCION_CUENTA_01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 16)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Cargo / Abono :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Línea :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Cuenta Final :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 16)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Cuenta Inicial :"
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(320, 120)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(72, 24)
        Me.btnEliminar.TabIndex = 12
        Me.btnEliminar.Text = "&Eiminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(176, 120)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(72, 24)
        Me.btnNuevo.TabIndex = 11
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(248, 120)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(72, 24)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'cmbRUBRO
        '
        Me.cmbRUBRO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRUBRO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRUBRO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRUBRO.ForeColor = System.Drawing.Color.Navy
        Me.cmbRUBRO.FormattingEnabled = True
        Me.cmbRUBRO.Location = New System.Drawing.Point(88, 96)
        Me.cmbRUBRO.Name = "cmbRUBRO"
        Me.cmbRUBRO.Size = New System.Drawing.Size(304, 24)
        Me.cmbRUBRO.TabIndex = 3
        '
        'cmbREPORTE
        '
        Me.cmbREPORTE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbREPORTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbREPORTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbREPORTE.ForeColor = System.Drawing.Color.Navy
        Me.cmbREPORTE.FormattingEnabled = True
        Me.cmbREPORTE.Location = New System.Drawing.Point(88, 48)
        Me.cmbREPORTE.Name = "cmbREPORTE"
        Me.cmbREPORTE.Size = New System.Drawing.Size(384, 24)
        Me.cmbREPORTE.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Rubro :"
        '
        'lblLIBRO_CONTABLE
        '
        Me.lblLIBRO_CONTABLE.AutoSize = True
        Me.lblLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLIBRO_CONTABLE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLIBRO_CONTABLE.Location = New System.Drawing.Point(480, 56)
        Me.lblLIBRO_CONTABLE.Name = "lblLIBRO_CONTABLE"
        Me.lblLIBRO_CONTABLE.Size = New System.Drawing.Size(14, 16)
        Me.lblLIBRO_CONTABLE.TabIndex = 4
        Me.lblLIBRO_CONTABLE.Text = "0"
        Me.lblLIBRO_CONTABLE.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 16)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Grupo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Reporte :"
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(88, 24)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(384, 24)
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
        'dgvDetalle
        '
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.AllowUserToDeleteRows = False
        Me.dgvDetalle.AllowUserToResizeColumns = False
        Me.dgvDetalle.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalle.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetalle.Location = New System.Drawing.Point(8, 258)
        Me.dgvDetalle.MultiSelect = False
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalle.Size = New System.Drawing.Size(552, 268)
        Me.dgvDetalle.TabIndex = 8
        '
        'Column1
        '
        Me.Column1.HeaderText = "Línea"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Desde"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Hasta"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Usuario Creación"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Fecha Creación"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(8, 190)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 16)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Nombre:"
        '
        'Txt_Nombe
        '
        Me.Txt_Nombe.AcceptsReturn = True
        Me.Txt_Nombe.Location = New System.Drawing.Point(88, 191)
        Me.Txt_Nombe.Name = "Txt_Nombe"
        Me.Txt_Nombe.Size = New System.Drawing.Size(304, 22)
        Me.Txt_Nombe.TabIndex = 7
        '
        'Contabilidad_Reportes_Rubros_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 533)
        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_Reportes_Rubros_Detalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Detalle de Rubros de Reportes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbRUBRO As System.Windows.Forms.ComboBox
    Friend WithEvents cmbREPORTE As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblLIBRO_CONTABLE As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar02 As System.Windows.Forms.Button
    Friend WithEvents btnBuscar01 As System.Windows.Forms.Button
    Friend WithEvents lblDESCRIPCION_CUENTA_02 As System.Windows.Forms.Label
    Friend WithEvents lblDESCRIPCION_CUENTA_01 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCARGO_ABONO As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbGRUPO As System.Windows.Forms.ComboBox
    Friend WithEvents TxtCUENTA_COMPLETA_02 As System.Windows.Forms.TextBox
    Friend WithEvents TxtCUENTA_COMPLETA_01 As System.Windows.Forms.TextBox
    Friend WithEvents TxtDETALLE As System.Windows.Forms.TextBox
    Friend WithEvents ChkLinea As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_Nombe As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
