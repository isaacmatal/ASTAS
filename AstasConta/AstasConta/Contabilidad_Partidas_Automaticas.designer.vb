<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Partidas_Automaticas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Partidas_Automaticas))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtResta = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtVALOR = New System.Windows.Forms.TextBox
        Me.lblValor = New System.Windows.Forms.Label
        Me.cmbTIPO_VALOR = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.rbtnABONO = New System.Windows.Forms.RadioButton
        Me.rbtnCARGO = New System.Windows.Forms.RadioButton
        Me.cmbLIBRO_CONTABLE = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.txtCUENTA_COMPLETA = New System.Windows.Forms.TextBox
        Me.btnNuevoCuenta = New System.Windows.Forms.Button
        Me.txtDESCRIPCION_CUENTA = New System.Windows.Forms.TextBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.lblCUENTA = New System.Windows.Forms.Label
        Me.cmbTIPO_MOVIMIENTO = New System.Windows.Forms.ComboBox
        Me.lblLINEA = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbTIPO_DOCUMENTO = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbORIGEN = New System.Windows.Forms.ComboBox
        Me.cmbCENTRO_COSTO = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtOBSERVACIONES = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvPartidas = New System.Windows.Forms.DataGridView
        Me.Linea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TipoMov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Libro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CuentaCompleta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescripcionCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cargo = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Abono = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Observa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaCeracion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TxtResta)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtVALOR)
        Me.GroupBox1.Controls.Add(Me.lblValor)
        Me.GroupBox1.Controls.Add(Me.cmbTIPO_VALOR)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.rbtnABONO)
        Me.GroupBox1.Controls.Add(Me.rbtnCARGO)
        Me.GroupBox1.Controls.Add(Me.cmbLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.txtCUENTA_COMPLETA)
        Me.GroupBox1.Controls.Add(Me.btnNuevoCuenta)
        Me.GroupBox1.Controls.Add(Me.txtDESCRIPCION_CUENTA)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.lblCUENTA)
        Me.GroupBox1.Controls.Add(Me.cmbTIPO_MOVIMIENTO)
        Me.GroupBox1.Controls.Add(Me.lblLINEA)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbTIPO_DOCUMENTO)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbORIGEN)
        Me.GroupBox1.Controls.Add(Me.cmbCENTRO_COSTO)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtOBSERVACIONES)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(15, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 252)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Partidas Automáticas"
        '
        'TxtResta
        '
        Me.TxtResta.BackColor = System.Drawing.SystemColors.Window
        Me.TxtResta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtResta.ForeColor = System.Drawing.Color.Navy
        Me.TxtResta.Location = New System.Drawing.Point(450, 198)
        Me.TxtResta.MaxLength = 50
        Me.TxtResta.Name = "TxtResta"
        Me.TxtResta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtResta.Size = New System.Drawing.Size(104, 22)
        Me.TxtResta.TabIndex = 8
        Me.TxtResta.Text = "0.00"
        Me.TxtResta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtResta.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(353, 198)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 16)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "Valor Diferencial :"
        Me.Label10.Visible = False
        '
        'txtVALOR
        '
        Me.txtVALOR.BackColor = System.Drawing.SystemColors.Window
        Me.txtVALOR.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVALOR.ForeColor = System.Drawing.Color.Navy
        Me.txtVALOR.Location = New System.Drawing.Point(106, 198)
        Me.txtVALOR.MaxLength = 50
        Me.txtVALOR.Name = "txtVALOR"
        Me.txtVALOR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtVALOR.Size = New System.Drawing.Size(104, 22)
        Me.txtVALOR.TabIndex = 7
        Me.txtVALOR.Text = "100"
        Me.txtVALOR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor.ForeColor = System.Drawing.Color.Navy
        Me.lblValor.Location = New System.Drawing.Point(5, 198)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(42, 16)
        Me.lblValor.TabIndex = 37
        Me.lblValor.Text = "Valor :"
        '
        'cmbTIPO_VALOR
        '
        Me.cmbTIPO_VALOR.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_VALOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_VALOR.DropDownWidth = 200
        Me.cmbTIPO_VALOR.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_VALOR.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_VALOR.FormattingEnabled = True
        Me.cmbTIPO_VALOR.Location = New System.Drawing.Point(106, 168)
        Me.cmbTIPO_VALOR.Name = "cmbTIPO_VALOR"
        Me.cmbTIPO_VALOR.Size = New System.Drawing.Size(104, 24)
        Me.cmbTIPO_VALOR.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(5, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 16)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Tipo de Valor :"
        '
        'rbtnABONO
        '
        Me.rbtnABONO.AutoSize = True
        Me.rbtnABONO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.rbtnABONO.ForeColor = System.Drawing.Color.Navy
        Me.rbtnABONO.Location = New System.Drawing.Point(274, 198)
        Me.rbtnABONO.Name = "rbtnABONO"
        Me.rbtnABONO.Size = New System.Drawing.Size(61, 20)
        Me.rbtnABONO.TabIndex = 34
        Me.rbtnABONO.Text = "Abono"
        Me.rbtnABONO.UseVisualStyleBackColor = True
        '
        'rbtnCARGO
        '
        Me.rbtnCARGO.AutoSize = True
        Me.rbtnCARGO.Checked = True
        Me.rbtnCARGO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.rbtnCARGO.ForeColor = System.Drawing.Color.Navy
        Me.rbtnCARGO.Location = New System.Drawing.Point(274, 168)
        Me.rbtnCARGO.Name = "rbtnCARGO"
        Me.rbtnCARGO.Size = New System.Drawing.Size(58, 20)
        Me.rbtnCARGO.TabIndex = 34
        Me.rbtnCARGO.TabStop = True
        Me.rbtnCARGO.Text = "Cargo"
        Me.rbtnCARGO.UseVisualStyleBackColor = True
        '
        'cmbLIBRO_CONTABLE
        '
        Me.cmbLIBRO_CONTABLE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLIBRO_CONTABLE.Enabled = False
        Me.cmbLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE.Location = New System.Drawing.Point(106, 109)
        Me.cmbLIBRO_CONTABLE.Name = "cmbLIBRO_CONTABLE"
        Me.cmbLIBRO_CONTABLE.Size = New System.Drawing.Size(376, 24)
        Me.cmbLIBRO_CONTABLE.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(5, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 16)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Libro Contable :"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(210, 140)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscar.TabIndex = 31
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(389, 50)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(24, 24)
        Me.btnEliminar.TabIndex = 5
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'txtCUENTA_COMPLETA
        '
        Me.txtCUENTA_COMPLETA.BackColor = System.Drawing.Color.White
        Me.txtCUENTA_COMPLETA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUENTA_COMPLETA.ForeColor = System.Drawing.Color.Navy
        Me.txtCUENTA_COMPLETA.Location = New System.Drawing.Point(106, 140)
        Me.txtCUENTA_COMPLETA.Name = "txtCUENTA_COMPLETA"
        Me.txtCUENTA_COMPLETA.Size = New System.Drawing.Size(104, 22)
        Me.txtCUENTA_COMPLETA.TabIndex = 30
        '
        'btnNuevoCuenta
        '
        Me.btnNuevoCuenta.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevoCuenta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevoCuenta.Image = CType(resources.GetObject("btnNuevoCuenta.Image"), System.Drawing.Image)
        Me.btnNuevoCuenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoCuenta.Location = New System.Drawing.Point(341, 50)
        Me.btnNuevoCuenta.Name = "btnNuevoCuenta"
        Me.btnNuevoCuenta.Size = New System.Drawing.Size(24, 24)
        Me.btnNuevoCuenta.TabIndex = 3
        Me.btnNuevoCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevoCuenta.UseVisualStyleBackColor = True
        '
        'txtDESCRIPCION_CUENTA
        '
        Me.txtDESCRIPCION_CUENTA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDESCRIPCION_CUENTA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDESCRIPCION_CUENTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPCION_CUENTA.ForeColor = System.Drawing.Color.Navy
        Me.txtDESCRIPCION_CUENTA.Location = New System.Drawing.Point(234, 140)
        Me.txtDESCRIPCION_CUENTA.Name = "txtDESCRIPCION_CUENTA"
        Me.txtDESCRIPCION_CUENTA.ReadOnly = True
        Me.txtDESCRIPCION_CUENTA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDESCRIPCION_CUENTA.Size = New System.Drawing.Size(320, 22)
        Me.txtDESCRIPCION_CUENTA.TabIndex = 29
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(365, 50)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCUENTA
        '
        Me.lblCUENTA.AutoSize = True
        Me.lblCUENTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCUENTA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCUENTA.Location = New System.Drawing.Point(530, 130)
        Me.lblCUENTA.Name = "lblCUENTA"
        Me.lblCUENTA.Size = New System.Drawing.Size(14, 16)
        Me.lblCUENTA.TabIndex = 27
        Me.lblCUENTA.Text = "0"
        Me.lblCUENTA.Visible = False
        '
        'cmbTIPO_MOVIMIENTO
        '
        Me.cmbTIPO_MOVIMIENTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_MOVIMIENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_MOVIMIENTO.DropDownWidth = 232
        Me.cmbTIPO_MOVIMIENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_MOVIMIENTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_MOVIMIENTO.FormattingEnabled = True
        Me.cmbTIPO_MOVIMIENTO.Location = New System.Drawing.Point(106, 79)
        Me.cmbTIPO_MOVIMIENTO.Name = "cmbTIPO_MOVIMIENTO"
        Me.cmbTIPO_MOVIMIENTO.Size = New System.Drawing.Size(232, 24)
        Me.cmbTIPO_MOVIMIENTO.TabIndex = 3
        '
        'lblLINEA
        '
        Me.lblLINEA.AutoSize = True
        Me.lblLINEA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLINEA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLINEA.Location = New System.Drawing.Point(498, 130)
        Me.lblLINEA.Name = "lblLINEA"
        Me.lblLINEA.Size = New System.Drawing.Size(14, 16)
        Me.lblLINEA.TabIndex = 27
        Me.lblLINEA.Text = "0"
        Me.lblLINEA.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(5, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Cuenta :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(5, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Tipo Movimiento :"
        '
        'cmbTIPO_DOCUMENTO
        '
        Me.cmbTIPO_DOCUMENTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_DOCUMENTO.DropDownWidth = 350
        Me.cmbTIPO_DOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_DOCUMENTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_DOCUMENTO.FormattingEnabled = True
        Me.cmbTIPO_DOCUMENTO.Location = New System.Drawing.Point(106, 50)
        Me.cmbTIPO_DOCUMENTO.Name = "cmbTIPO_DOCUMENTO"
        Me.cmbTIPO_DOCUMENTO.Size = New System.Drawing.Size(232, 24)
        Me.cmbTIPO_DOCUMENTO.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(5, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 16)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Tipo Documento :"
        '
        'cmbORIGEN
        '
        Me.cmbORIGEN.BackColor = System.Drawing.SystemColors.Window
        Me.cmbORIGEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbORIGEN.DropDownWidth = 200
        Me.cmbORIGEN.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbORIGEN.ForeColor = System.Drawing.Color.Navy
        Me.cmbORIGEN.FormattingEnabled = True
        Me.cmbORIGEN.Location = New System.Drawing.Point(450, 168)
        Me.cmbORIGEN.Name = "cmbORIGEN"
        Me.cmbORIGEN.Size = New System.Drawing.Size(104, 24)
        Me.cmbORIGEN.TabIndex = 6
        '
        'cmbCENTRO_COSTO
        '
        Me.cmbCENTRO_COSTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCENTRO_COSTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCENTRO_COSTO.DropDownWidth = 350
        Me.cmbCENTRO_COSTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCENTRO_COSTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbCENTRO_COSTO.FormattingEnabled = True
        Me.cmbCENTRO_COSTO.Location = New System.Drawing.Point(106, 21)
        Me.cmbCENTRO_COSTO.Name = "cmbCENTRO_COSTO"
        Me.cmbCENTRO_COSTO.Size = New System.Drawing.Size(232, 24)
        Me.cmbCENTRO_COSTO.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(353, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 16)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Origen :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(5, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 16)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Centro de Costo :"
        '
        'txtOBSERVACIONES
        '
        Me.txtOBSERVACIONES.BackColor = System.Drawing.SystemColors.Window
        Me.txtOBSERVACIONES.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOBSERVACIONES.ForeColor = System.Drawing.Color.Navy
        Me.txtOBSERVACIONES.Location = New System.Drawing.Point(106, 226)
        Me.txtOBSERVACIONES.MaxLength = 50
        Me.txtOBSERVACIONES.Name = "txtOBSERVACIONES"
        Me.txtOBSERVACIONES.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOBSERVACIONES.Size = New System.Drawing.Size(448, 22)
        Me.txtOBSERVACIONES.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(5, 226)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Observaciones :"
        '
        'dgvPartidas
        '
        Me.dgvPartidas.AllowUserToAddRows = False
        Me.dgvPartidas.AllowUserToDeleteRows = False
        Me.dgvPartidas.AllowUserToResizeColumns = False
        Me.dgvPartidas.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray
        Me.dgvPartidas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPartidas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPartidas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvPartidas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Linea, Me.TipoMov, Me.LC, Me.Libro, Me.Cuenta, Me.CuentaCompleta, Me.DescripcionCuenta, Me.Cargo, Me.Abono, Me.Observa, Me.UsuarioCreacion, Me.FechaCeracion})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPartidas.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPartidas.Location = New System.Drawing.Point(15, 264)
        Me.dgvPartidas.Name = "dgvPartidas"
        Me.dgvPartidas.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartidas.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvPartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartidas.Size = New System.Drawing.Size(938, 321)
        Me.dgvPartidas.TabIndex = 29
        '
        'Linea
        '
        Me.Linea.HeaderText = "Linea"
        Me.Linea.Name = "Linea"
        Me.Linea.ReadOnly = True
        '
        'TipoMov
        '
        Me.TipoMov.HeaderText = "Tipo Movimiento"
        Me.TipoMov.Name = "TipoMov"
        Me.TipoMov.ReadOnly = True
        '
        'LC
        '
        Me.LC.HeaderText = ""
        Me.LC.Name = "LC"
        Me.LC.ReadOnly = True
        '
        'Libro
        '
        Me.Libro.HeaderText = "Libro Contable"
        Me.Libro.Name = "Libro"
        Me.Libro.ReadOnly = True
        '
        'Cuenta
        '
        Me.Cuenta.HeaderText = ""
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        '
        'CuentaCompleta
        '
        Me.CuentaCompleta.HeaderText = "Cuenta"
        Me.CuentaCompleta.Name = "CuentaCompleta"
        Me.CuentaCompleta.ReadOnly = True
        '
        'DescripcionCuenta
        '
        Me.DescripcionCuenta.HeaderText = "Descripción Cuenta"
        Me.DescripcionCuenta.Name = "DescripcionCuenta"
        Me.DescripcionCuenta.ReadOnly = True
        '
        'Cargo
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.NullValue = False
        Me.Cargo.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cargo.HeaderText = "Cargo"
        Me.Cargo.Name = "Cargo"
        Me.Cargo.ReadOnly = True
        Me.Cargo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cargo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Abono
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.NullValue = False
        Me.Abono.DefaultCellStyle = DataGridViewCellStyle8
        Me.Abono.HeaderText = "Abono"
        Me.Abono.Name = "Abono"
        Me.Abono.ReadOnly = True
        Me.Abono.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Abono.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Observa
        '
        Me.Observa.HeaderText = "Observaciones"
        Me.Observa.Name = "Observa"
        Me.Observa.ReadOnly = True
        '
        'UsuarioCreacion
        '
        Me.UsuarioCreacion.HeaderText = "Usuario Creación"
        Me.UsuarioCreacion.Name = "UsuarioCreacion"
        Me.UsuarioCreacion.ReadOnly = True
        '
        'FechaCeracion
        '
        Me.FechaCeracion.HeaderText = "Fecha Creación"
        Me.FechaCeracion.Name = "FechaCeracion"
        Me.FechaCeracion.ReadOnly = True
        '
        'pbImagen
        '
        Me.pbImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Image = CType(resources.GetObject("pbImagen.Image"), System.Drawing.Image)
        Me.pbImagen.Location = New System.Drawing.Point(807, 8)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(146, 248)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 60
        Me.pbImagen.TabStop = False
        '
        'Contabilidad_Partidas_Automaticas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 597)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.dgvPartidas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Partidas_Automaticas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Catálogo de Partidas Automáticas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnNuevoCuenta As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtOBSERVACIONES As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCENTRO_COSTO As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTIPO_MOVIMIENTO As System.Windows.Forms.ComboBox
    Friend WithEvents lblLINEA As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTIPO_DOCUMENTO As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtCUENTA_COMPLETA As System.Windows.Forms.TextBox
    Friend WithEvents txtDESCRIPCION_CUENTA As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbLIBRO_CONTABLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvPartidas As System.Windows.Forms.DataGridView
    Friend WithEvents Linea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoMov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Libro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CuentaCompleta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cargo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Abono As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Observa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCreacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaCeracion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents lblCUENTA As System.Windows.Forms.Label
    Friend WithEvents rbtnABONO As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnCARGO As System.Windows.Forms.RadioButton
    Friend WithEvents cmbORIGEN As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTIPO_VALOR As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtVALOR As System.Windows.Forms.TextBox
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents TxtResta As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
