<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_CuentasEquivalentes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_CuentasEquivalentes))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtCUENTA_EQUIVALENTE = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnEliminar_Equivalente = New System.Windows.Forms.Button
        Me.btnNuevo_Equivalente = New System.Windows.Forms.Button
        Me.btnGuardar_Equivalente = New System.Windows.Forms.Button
        Me.btnBuscar_Equivalente = New System.Windows.Forms.Button
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE = New System.Windows.Forms.TextBox
        Me.txtCUENTA_COMPLETA_EQUIVALENTE = New System.Windows.Forms.TextBox
        Me.cmbLIBRO_CONTABLE_EQUIVALENTE = New System.Windows.Forms.ComboBox
        Me.cmbCOMPAÑIA_EQUIVALENTE = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtCUENTA = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnNuevoCuenta = New System.Windows.Forms.Button
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.cmbLIBRO_CONTABLE = New System.Windows.Forms.ComboBox
        Me.txtCUENTA_COMPLETA = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDESCRIPCION_CUENTA = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbCOMPAÑIA = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvCuentasEquivalentes = New System.Windows.Forms.DataGridView
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripción = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Iniciales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibroContable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Coo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescripcionCompañia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsuarioC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCuentasEquivalentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(12, 331)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(686, 18)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Cuentas Equivalentes Asociadas :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtCUENTA_EQUIVALENTE)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btnEliminar_Equivalente)
        Me.GroupBox2.Controls.Add(Me.btnNuevo_Equivalente)
        Me.GroupBox2.Controls.Add(Me.btnGuardar_Equivalente)
        Me.GroupBox2.Controls.Add(Me.btnBuscar_Equivalente)
        Me.GroupBox2.Controls.Add(Me.txtDESCRIPCION_CUENTA_EQUIVALENTE)
        Me.GroupBox2.Controls.Add(Me.txtCUENTA_COMPLETA_EQUIVALENTE)
        Me.GroupBox2.Controls.Add(Me.cmbLIBRO_CONTABLE_EQUIVALENTE)
        Me.GroupBox2.Controls.Add(Me.cmbCOMPAÑIA_EQUIVALENTE)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(160, 168)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(538, 152)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cuentas Equivalentes"
        '
        'txtCUENTA_EQUIVALENTE
        '
        Me.txtCUENTA_EQUIVALENTE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCUENTA_EQUIVALENTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUENTA_EQUIVALENTE.ForeColor = System.Drawing.Color.Red
        Me.txtCUENTA_EQUIVALENTE.Location = New System.Drawing.Point(102, 72)
        Me.txtCUENTA_EQUIVALENTE.Name = "txtCUENTA_EQUIVALENTE"
        Me.txtCUENTA_EQUIVALENTE.ReadOnly = True
        Me.txtCUENTA_EQUIVALENTE.Size = New System.Drawing.Size(128, 22)
        Me.txtCUENTA_EQUIVALENTE.TabIndex = 29
        Me.txtCUENTA_EQUIVALENTE.TabStop = False
        Me.txtCUENTA_EQUIVALENTE.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Navy
        Me.Label11.Location = New System.Drawing.Point(8, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 16)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Correlativo :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(8, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 16)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Descripción :"
        '
        'btnEliminar_Equivalente
        '
        Me.btnEliminar_Equivalente.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnEliminar_Equivalente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar_Equivalente.Image = CType(resources.GetObject("btnEliminar_Equivalente.Image"), System.Drawing.Image)
        Me.btnEliminar_Equivalente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar_Equivalente.Location = New System.Drawing.Point(447, 96)
        Me.btnEliminar_Equivalente.Name = "btnEliminar_Equivalente"
        Me.btnEliminar_Equivalente.Size = New System.Drawing.Size(72, 24)
        Me.btnEliminar_Equivalente.TabIndex = 26
        Me.btnEliminar_Equivalente.Text = "&Eiminar"
        Me.btnEliminar_Equivalente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar_Equivalente.UseVisualStyleBackColor = True
        '
        'btnNuevo_Equivalente
        '
        Me.btnNuevo_Equivalente.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo_Equivalente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo_Equivalente.Image = CType(resources.GetObject("btnNuevo_Equivalente.Image"), System.Drawing.Image)
        Me.btnNuevo_Equivalente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo_Equivalente.Location = New System.Drawing.Point(302, 96)
        Me.btnNuevo_Equivalente.Name = "btnNuevo_Equivalente"
        Me.btnNuevo_Equivalente.Size = New System.Drawing.Size(72, 24)
        Me.btnNuevo_Equivalente.TabIndex = 25
        Me.btnNuevo_Equivalente.Text = "&Nuevo"
        Me.btnNuevo_Equivalente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo_Equivalente.UseVisualStyleBackColor = True
        '
        'btnGuardar_Equivalente
        '
        Me.btnGuardar_Equivalente.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardar_Equivalente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar_Equivalente.Image = CType(resources.GetObject("btnGuardar_Equivalente.Image"), System.Drawing.Image)
        Me.btnGuardar_Equivalente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar_Equivalente.Location = New System.Drawing.Point(374, 96)
        Me.btnGuardar_Equivalente.Name = "btnGuardar_Equivalente"
        Me.btnGuardar_Equivalente.Size = New System.Drawing.Size(72, 24)
        Me.btnGuardar_Equivalente.TabIndex = 24
        Me.btnGuardar_Equivalente.Text = "&Guardar"
        Me.btnGuardar_Equivalente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar_Equivalente.UseVisualStyleBackColor = True
        '
        'btnBuscar_Equivalente
        '
        Me.btnBuscar_Equivalente.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnBuscar_Equivalente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar_Equivalente.Image = CType(resources.GetObject("btnBuscar_Equivalente.Image"), System.Drawing.Image)
        Me.btnBuscar_Equivalente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar_Equivalente.Location = New System.Drawing.Point(230, 96)
        Me.btnBuscar_Equivalente.Name = "btnBuscar_Equivalente"
        Me.btnBuscar_Equivalente.Size = New System.Drawing.Size(72, 24)
        Me.btnBuscar_Equivalente.TabIndex = 23
        Me.btnBuscar_Equivalente.Text = "&Buscar"
        Me.btnBuscar_Equivalente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar_Equivalente.UseVisualStyleBackColor = True
        '
        'txtDESCRIPCION_CUENTA_EQUIVALENTE
        '
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.Location = New System.Drawing.Point(102, 120)
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.Name = "txtDESCRIPCION_CUENTA_EQUIVALENTE"
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.ReadOnly = True
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.Size = New System.Drawing.Size(416, 22)
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.TabIndex = 17
        Me.txtDESCRIPCION_CUENTA_EQUIVALENTE.TabStop = False
        '
        'txtCUENTA_COMPLETA_EQUIVALENTE
        '
        Me.txtCUENTA_COMPLETA_EQUIVALENTE.BackColor = System.Drawing.SystemColors.Window
        Me.txtCUENTA_COMPLETA_EQUIVALENTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUENTA_COMPLETA_EQUIVALENTE.ForeColor = System.Drawing.Color.Navy
        Me.txtCUENTA_COMPLETA_EQUIVALENTE.Location = New System.Drawing.Point(102, 96)
        Me.txtCUENTA_COMPLETA_EQUIVALENTE.Name = "txtCUENTA_COMPLETA_EQUIVALENTE"
        Me.txtCUENTA_COMPLETA_EQUIVALENTE.Size = New System.Drawing.Size(128, 22)
        Me.txtCUENTA_COMPLETA_EQUIVALENTE.TabIndex = 16
        '
        'cmbLIBRO_CONTABLE_EQUIVALENTE
        '
        Me.cmbLIBRO_CONTABLE_EQUIVALENTE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE_EQUIVALENTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLIBRO_CONTABLE_EQUIVALENTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE_EQUIVALENTE.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE_EQUIVALENTE.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE_EQUIVALENTE.Location = New System.Drawing.Point(102, 48)
        Me.cmbLIBRO_CONTABLE_EQUIVALENTE.Name = "cmbLIBRO_CONTABLE_EQUIVALENTE"
        Me.cmbLIBRO_CONTABLE_EQUIVALENTE.Size = New System.Drawing.Size(384, 24)
        Me.cmbLIBRO_CONTABLE_EQUIVALENTE.TabIndex = 15
        '
        'cmbCOMPAÑIA_EQUIVALENTE
        '
        Me.cmbCOMPAÑIA_EQUIVALENTE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA_EQUIVALENTE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA_EQUIVALENTE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPAÑIA_EQUIVALENTE.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA_EQUIVALENTE.FormattingEnabled = True
        Me.cmbCOMPAÑIA_EQUIVALENTE.Location = New System.Drawing.Point(102, 24)
        Me.cmbCOMPAÑIA_EQUIVALENTE.Name = "cmbCOMPAÑIA_EQUIVALENTE"
        Me.cmbCOMPAÑIA_EQUIVALENTE.Size = New System.Drawing.Size(384, 24)
        Me.cmbCOMPAÑIA_EQUIVALENTE.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(8, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 16)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Cuenta :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(8, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Libro Contable :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(8, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Compañía :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtCUENTA)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnNuevoCuenta)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.cmbLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.txtCUENTA_COMPLETA)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION_CUENTA)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCOMPAÑIA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(160, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(538, 152)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cuenta Contable"
        '
        'txtCUENTA
        '
        Me.txtCUENTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCUENTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUENTA.ForeColor = System.Drawing.Color.Red
        Me.txtCUENTA.Location = New System.Drawing.Point(102, 72)
        Me.txtCUENTA.Name = "txtCUENTA"
        Me.txtCUENTA.ReadOnly = True
        Me.txtCUENTA.Size = New System.Drawing.Size(128, 22)
        Me.txtCUENTA.TabIndex = 24
        Me.txtCUENTA.TabStop = False
        Me.txtCUENTA.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(8, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 16)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Correlativo :"
        '
        'btnNuevoCuenta
        '
        Me.btnNuevoCuenta.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevoCuenta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevoCuenta.Image = CType(resources.GetObject("btnNuevoCuenta.Image"), System.Drawing.Image)
        Me.btnNuevoCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoCuenta.Location = New System.Drawing.Point(310, 96)
        Me.btnNuevoCuenta.Name = "btnNuevoCuenta"
        Me.btnNuevoCuenta.Size = New System.Drawing.Size(72, 24)
        Me.btnNuevoCuenta.TabIndex = 21
        Me.btnNuevoCuenta.Text = "&Nuevo"
        Me.btnNuevoCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevoCuenta.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(230, 96)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(72, 24)
        Me.btnBuscar.TabIndex = 19
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbLIBRO_CONTABLE
        '
        Me.cmbLIBRO_CONTABLE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE.Location = New System.Drawing.Point(102, 48)
        Me.cmbLIBRO_CONTABLE.Name = "cmbLIBRO_CONTABLE"
        Me.cmbLIBRO_CONTABLE.Size = New System.Drawing.Size(384, 24)
        Me.cmbLIBRO_CONTABLE.TabIndex = 5
        '
        'txtCUENTA_COMPLETA
        '
        Me.txtCUENTA_COMPLETA.BackColor = System.Drawing.SystemColors.Window
        Me.txtCUENTA_COMPLETA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUENTA_COMPLETA.ForeColor = System.Drawing.Color.Navy
        Me.txtCUENTA_COMPLETA.Location = New System.Drawing.Point(102, 96)
        Me.txtCUENTA_COMPLETA.Name = "txtCUENTA_COMPLETA"
        Me.txtCUENTA_COMPLETA.Size = New System.Drawing.Size(128, 22)
        Me.txtCUENTA_COMPLETA.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(8, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cuenta :"
        '
        'txtDESCRIPCION_CUENTA
        '
        Me.txtDESCRIPCION_CUENTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDESCRIPCION_CUENTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_CUENTA.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_CUENTA.Location = New System.Drawing.Point(102, 120)
        Me.txtDESCRIPCION_CUENTA.Name = "txtDESCRIPCION_CUENTA"
        Me.txtDESCRIPCION_CUENTA.ReadOnly = True
        Me.txtDESCRIPCION_CUENTA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION_CUENTA.Size = New System.Drawing.Size(416, 22)
        Me.txtDESCRIPCION_CUENTA.TabIndex = 5
        Me.txtDESCRIPCION_CUENTA.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(8, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Descripción :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Libro Contable :"
        '
        'cmbCOMPAÑIA
        '
        Me.cmbCOMPAÑIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCOMPAÑIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOMPAÑIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbCOMPAÑIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCOMPAÑIA.FormattingEnabled = True
        Me.cmbCOMPAÑIA.Location = New System.Drawing.Point(102, 24)
        Me.cmbCOMPAÑIA.Name = "cmbCOMPAÑIA"
        Me.cmbCOMPAÑIA.Size = New System.Drawing.Size(384, 24)
        Me.cmbCOMPAÑIA.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía :"
        '
        'dgvCuentasEquivalentes
        '
        Me.dgvCuentasEquivalentes.AllowUserToAddRows = False
        Me.dgvCuentasEquivalentes.AllowUserToDeleteRows = False
        Me.dgvCuentasEquivalentes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dgvCuentasEquivalentes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCuentasEquivalentes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCuentasEquivalentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuentasEquivalentes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Descripción, Me.Iniciales, Me.LC, Me.LibroContable, Me.Coo, Me.DescripcionCompañia, Me.UsuarioC, Me.FechaC})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCuentasEquivalentes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCuentasEquivalentes.Location = New System.Drawing.Point(12, 352)
        Me.dgvCuentasEquivalentes.MultiSelect = False
        Me.dgvCuentasEquivalentes.Name = "dgvCuentasEquivalentes"
        Me.dgvCuentasEquivalentes.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCuentasEquivalentes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCuentasEquivalentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCuentasEquivalentes.Size = New System.Drawing.Size(686, 170)
        Me.dgvCuentasEquivalentes.TabIndex = 27
        '
        'Codigo
        '
        Me.Codigo.HeaderText = ""
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        '
        'Descripción
        '
        Me.Descripción.HeaderText = "Cuenta EQ"
        Me.Descripción.Name = "Descripción"
        Me.Descripción.ReadOnly = True
        '
        'Iniciales
        '
        Me.Iniciales.HeaderText = "Descripción Cuenta"
        Me.Iniciales.Name = "Iniciales"
        Me.Iniciales.ReadOnly = True
        '
        'LC
        '
        Me.LC.HeaderText = "LC"
        Me.LC.Name = "LC"
        Me.LC.ReadOnly = True
        '
        'LibroContable
        '
        Me.LibroContable.HeaderText = "Libro Contable EQ"
        Me.LibroContable.Name = "LibroContable"
        Me.LibroContable.ReadOnly = True
        '
        'Coo
        '
        Me.Coo.HeaderText = "Compañía"
        Me.Coo.Name = "Coo"
        Me.Coo.ReadOnly = True
        '
        'DescripcionCompañia
        '
        Me.DescripcionCompañia.HeaderText = "Compañía EQ"
        Me.DescripcionCompañia.Name = "DescripcionCompañia"
        Me.DescripcionCompañia.ReadOnly = True
        '
        'UsuarioC
        '
        Me.UsuarioC.HeaderText = "Usuario Creación"
        Me.UsuarioC.Name = "UsuarioC"
        Me.UsuarioC.ReadOnly = True
        '
        'FechaC
        '
        Me.FechaC.HeaderText = "Fecha Creación"
        Me.FechaC.Name = "FechaC"
        Me.FechaC.ReadOnly = True
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(12, 16)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(144, 272)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 28
        Me.pbImagen.TabStop = False
        '
        'Contabilidad_CuentasEquivalentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 534)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.dgvCuentasEquivalentes)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_CuentasEquivalentes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Registro de Equivalencias de Cuentas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvCuentasEquivalentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCUENTA_EQUIVALENTE As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar_Equivalente As System.Windows.Forms.Button
    Friend WithEvents btnNuevo_Equivalente As System.Windows.Forms.Button
    Friend WithEvents btnGuardar_Equivalente As System.Windows.Forms.Button
    Friend WithEvents btnBuscar_Equivalente As System.Windows.Forms.Button
    Friend WithEvents txtDESCRIPCION_CUENTA_EQUIVALENTE As System.Windows.Forms.TextBox
    Friend WithEvents txtCUENTA_COMPLETA_EQUIVALENTE As System.Windows.Forms.TextBox
    Friend WithEvents cmbLIBRO_CONTABLE_EQUIVALENTE As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCOMPAÑIA_EQUIVALENTE As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCUENTA As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnNuevoCuenta As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cmbLIBRO_CONTABLE As System.Windows.Forms.ComboBox
    Friend WithEvents txtCUENTA_COMPLETA As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPCION_CUENTA As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCOMPAÑIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvCuentasEquivalentes As System.Windows.Forms.DataGridView
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripción As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Iniciales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibroContable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Coo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionCompañia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
End Class
