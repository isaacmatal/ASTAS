<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Partidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Partidas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.OpenFileDialogAbrir = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblAnulada = New System.Windows.Forms.Label
        Me.chkProcesada = New System.Windows.Forms.CheckBox
        Me.lblTransaccionAnula = New System.Windows.Forms.Label
        Me.btnVer = New System.Windows.Forms.Button
        Me.txtPARTIDA = New System.Windows.Forms.TextBox
        Me.btnBuscarPartida = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.dpFECHA_CONTABLE = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtCONCEPTO = New System.Windows.Forms.TextBox
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDOCUMENTO = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbTIPO_PARTIDA = New System.Windows.Forms.ComboBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbLIBRO_CONTABLE = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnActualizarDetalle = New System.Windows.Forms.Button
        Me.cmbTIPO_DOCUMENTO = New System.Windows.Forms.ComboBox
        Me.btnEliminarDetalle = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTRANSACCION = New System.Windows.Forms.TextBox
        Me.btnBuscarTransaccion = New System.Windows.Forms.Button
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.btnImportarExcel = New System.Windows.Forms.Button
        Me.btnBuscarExcel = New System.Windows.Forms.Button
        Me.btnProcesarPartida = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtDIFERENCIA = New System.Windows.Forms.TextBox
        Me.txtABONOS = New System.Windows.Forms.TextBox
        Me.txtCARGOS = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.dgvPartidas = New System.Windows.Forms.DataGridView
        Me.Linea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.codCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CuentaCompleta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DescripcionCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConceptoL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cargo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Abono = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Transaccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmbCARGO_ABONO = New System.Windows.Forms.ComboBox
        Me.txtMONTO = New System.Windows.Forms.TextBox
        Me.btnBuscarCuenta = New System.Windows.Forms.Button
        Me.txtCUENTA_COMPLETA = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.gbImportar = New System.Windows.Forms.GroupBox
        Me.cmbSheets = New System.Windows.Forms.ComboBox
        Me.lblArchivoExcel = New System.Windows.Forms.Label
        Me.btnGuardarLinea = New System.Windows.Forms.Button
        Me.txtCONCEPTO_L = New System.Windows.Forms.TextBox
        Me.btnNuevaLinea = New System.Windows.Forms.Button
        Me.lblCuenta = New System.Windows.Forms.Label
        Me.txtCodDetalle = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.btnBuscaDetalle = New System.Windows.Forms.Button
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbImportar.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialogAbrir
        '
        Me.OpenFileDialogAbrir.DefaultExt = "xlsx"
        Me.OpenFileDialogAbrir.Filter = "Archivos Excel 2007-2010|*.xlsx|Archivos de Excel 97-2003|*.xls"
        Me.OpenFileDialogAbrir.ReadOnlyChecked = True
        Me.OpenFileDialogAbrir.ShowReadOnly = True
        Me.OpenFileDialogAbrir.SupportMultiDottedExtensions = True
        Me.OpenFileDialogAbrir.Title = "Búsqueda de Archivos de Excel"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblAnulada)
        Me.GroupBox1.Controls.Add(Me.chkProcesada)
        Me.GroupBox1.Controls.Add(Me.lblTransaccionAnula)
        Me.GroupBox1.Controls.Add(Me.btnVer)
        Me.GroupBox1.Controls.Add(Me.txtPARTIDA)
        Me.GroupBox1.Controls.Add(Me.btnBuscarPartida)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dpFECHA_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtCONCEPTO)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtDOCUMENTO)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmbTIPO_PARTIDA)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(742, 122)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro de Partidas Contables"
        '
        'lblAnulada
        '
        Me.lblAnulada.BackColor = System.Drawing.Color.DarkKhaki
        Me.lblAnulada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAnulada.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnulada.ForeColor = System.Drawing.Color.Red
        Me.lblAnulada.Location = New System.Drawing.Point(488, 68)
        Me.lblAnulada.Name = "lblAnulada"
        Me.lblAnulada.Size = New System.Drawing.Size(96, 24)
        Me.lblAnulada.TabIndex = 59
        Me.lblAnulada.Text = "ANULADA"
        Me.lblAnulada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAnulada.Visible = False
        '
        'chkProcesada
        '
        Me.chkProcesada.AutoSize = True
        Me.chkProcesada.Location = New System.Drawing.Point(480, 48)
        Me.chkProcesada.Name = "chkProcesada"
        Me.chkProcesada.Size = New System.Drawing.Size(82, 20)
        Me.chkProcesada.TabIndex = 62
        Me.chkProcesada.Text = "Procesada"
        Me.chkProcesada.UseVisualStyleBackColor = True
        Me.chkProcesada.Visible = False
        '
        'lblTransaccionAnula
        '
        Me.lblTransaccionAnula.BackColor = System.Drawing.Color.DarkKhaki
        Me.lblTransaccionAnula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransaccionAnula.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransaccionAnula.ForeColor = System.Drawing.Color.Red
        Me.lblTransaccionAnula.Location = New System.Drawing.Point(584, 68)
        Me.lblTransaccionAnula.Name = "lblTransaccionAnula"
        Me.lblTransaccionAnula.Size = New System.Drawing.Size(64, 24)
        Me.lblTransaccionAnula.TabIndex = 60
        Me.lblTransaccionAnula.Visible = False
        '
        'btnVer
        '
        Me.btnVer.Image = CType(resources.GetObject("btnVer.Image"), System.Drawing.Image)
        Me.btnVer.Location = New System.Drawing.Point(687, 25)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(24, 24)
        Me.btnVer.TabIndex = 5
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'txtPARTIDA
        '
        Me.txtPARTIDA.BackColor = System.Drawing.Color.White
        Me.txtPARTIDA.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPARTIDA.ForeColor = System.Drawing.Color.Red
        Me.txtPARTIDA.Location = New System.Drawing.Point(573, 25)
        Me.txtPARTIDA.Name = "txtPARTIDA"
        Me.txtPARTIDA.Size = New System.Drawing.Size(64, 25)
        Me.txtPARTIDA.TabIndex = 1
        Me.txtPARTIDA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnBuscarPartida
        '
        Me.btnBuscarPartida.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarPartida.Image = CType(resources.GetObject("btnBuscarPartida.Image"), System.Drawing.Image)
        Me.btnBuscarPartida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarPartida.Location = New System.Drawing.Point(637, 25)
        Me.btnBuscarPartida.Name = "btnBuscarPartida"
        Me.btnBuscarPartida.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarPartida.TabIndex = 4
        Me.btnBuscarPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarPartida.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(488, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 24)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "N° Partida :"
        '
        'dpFECHA_CONTABLE
        '
        Me.dpFECHA_CONTABLE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CONTABLE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CONTABLE.Location = New System.Drawing.Point(368, 70)
        Me.dpFECHA_CONTABLE.Name = "dpFECHA_CONTABLE"
        Me.dpFECHA_CONTABLE.Size = New System.Drawing.Size(112, 22)
        Me.dpFECHA_CONTABLE.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(283, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 16)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Fecha Contable :"
        '
        'txtCONCEPTO
        '
        Me.txtCONCEPTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONCEPTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONCEPTO.ForeColor = System.Drawing.Color.Navy
        Me.txtCONCEPTO.Location = New System.Drawing.Point(96, 95)
        Me.txtCONCEPTO.Name = "txtCONCEPTO"
        Me.txtCONCEPTO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCONCEPTO.Size = New System.Drawing.Size(640, 22)
        Me.txtCONCEPTO.TabIndex = 3
        '
        'btnNuevo
        '
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(712, 25)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(24, 24)
        Me.btnNuevo.TabIndex = 7
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(8, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Concepto Gral. :"
        '
        'txtDOCUMENTO
        '
        Me.txtDOCUMENTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtDOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDOCUMENTO.ForeColor = System.Drawing.Color.Navy
        Me.txtDOCUMENTO.Location = New System.Drawing.Point(96, 71)
        Me.txtDOCUMENTO.MaxLength = 20
        Me.txtDOCUMENTO.Name = "txtDOCUMENTO"
        Me.txtDOCUMENTO.Size = New System.Drawing.Size(88, 22)
        Me.txtDOCUMENTO.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(8, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 16)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "N° Cheque :"
        '
        'cmbTIPO_PARTIDA
        '
        Me.cmbTIPO_PARTIDA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_PARTIDA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_PARTIDA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_PARTIDA.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_PARTIDA.FormattingEnabled = True
        Me.cmbTIPO_PARTIDA.Location = New System.Drawing.Point(96, 46)
        Me.cmbTIPO_PARTIDA.Name = "cmbTIPO_PARTIDA"
        Me.cmbTIPO_PARTIDA.Size = New System.Drawing.Size(88, 24)
        Me.cmbTIPO_PARTIDA.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(662, 25)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardar.TabIndex = 51
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(8, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Tipo Partida :"
        '
        'cmbLIBRO_CONTABLE
        '
        Me.cmbLIBRO_CONTABLE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLIBRO_CONTABLE.Enabled = False
        Me.cmbLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE.Location = New System.Drawing.Point(96, 22)
        Me.cmbLIBRO_CONTABLE.Name = "cmbLIBRO_CONTABLE"
        Me.cmbLIBRO_CONTABLE.Size = New System.Drawing.Size(384, 24)
        Me.cmbLIBRO_CONTABLE.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(8, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Libro Contable :"
        '
        'btnActualizarDetalle
        '
        Me.btnActualizarDetalle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnActualizarDetalle.Image = CType(resources.GetObject("btnActualizarDetalle.Image"), System.Drawing.Image)
        Me.btnActualizarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizarDetalle.Location = New System.Drawing.Point(792, 61)
        Me.btnActualizarDetalle.Name = "btnActualizarDetalle"
        Me.btnActualizarDetalle.Size = New System.Drawing.Size(24, 24)
        Me.btnActualizarDetalle.TabIndex = 6
        Me.btnActualizarDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizarDetalle.UseVisualStyleBackColor = True
        Me.btnActualizarDetalle.Visible = False
        '
        'cmbTIPO_DOCUMENTO
        '
        Me.cmbTIPO_DOCUMENTO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTIPO_DOCUMENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTIPO_DOCUMENTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTIPO_DOCUMENTO.ForeColor = System.Drawing.Color.Navy
        Me.cmbTIPO_DOCUMENTO.FormattingEnabled = True
        Me.cmbTIPO_DOCUMENTO.Location = New System.Drawing.Point(762, 91)
        Me.cmbTIPO_DOCUMENTO.Name = "cmbTIPO_DOCUMENTO"
        Me.cmbTIPO_DOCUMENTO.Size = New System.Drawing.Size(44, 24)
        Me.cmbTIPO_DOCUMENTO.TabIndex = 2
        Me.cmbTIPO_DOCUMENTO.Visible = False
        '
        'btnEliminarDetalle
        '
        Me.btnEliminarDetalle.Image = CType(resources.GetObject("btnEliminarDetalle.Image"), System.Drawing.Image)
        Me.btnEliminarDetalle.Location = New System.Drawing.Point(776, 157)
        Me.btnEliminarDetalle.Name = "btnEliminarDetalle"
        Me.btnEliminarDetalle.Size = New System.Drawing.Size(24, 24)
        Me.btnEliminarDetalle.TabIndex = 8
        Me.btnEliminarDetalle.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(746, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 24)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Transacción :"
        Me.Label3.Visible = False
        '
        'txtTRANSACCION
        '
        Me.txtTRANSACCION.BackColor = System.Drawing.SystemColors.Window
        Me.txtTRANSACCION.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTRANSACCION.ForeColor = System.Drawing.Color.Navy
        Me.txtTRANSACCION.Location = New System.Drawing.Point(765, 30)
        Me.txtTRANSACCION.Name = "txtTRANSACCION"
        Me.txtTRANSACCION.ReadOnly = True
        Me.txtTRANSACCION.Size = New System.Drawing.Size(64, 25)
        Me.txtTRANSACCION.TabIndex = 0
        Me.txtTRANSACCION.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTRANSACCION.Visible = False
        '
        'btnBuscarTransaccion
        '
        Me.btnBuscarTransaccion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarTransaccion.Image = CType(resources.GetObject("btnBuscarTransaccion.Image"), System.Drawing.Image)
        Me.btnBuscarTransaccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarTransaccion.Location = New System.Drawing.Point(762, 61)
        Me.btnBuscarTransaccion.Name = "btnBuscarTransaccion"
        Me.btnBuscarTransaccion.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarTransaccion.TabIndex = 49
        Me.btnBuscarTransaccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarTransaccion.UseVisualStyleBackColor = True
        Me.btnBuscarTransaccion.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Navy
        Me.Label27.Location = New System.Drawing.Point(8, 48)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(41, 16)
        Me.Label27.TabIndex = 53
        Me.Label27.Text = "Hojas :"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Navy
        Me.Label26.Location = New System.Drawing.Point(8, 24)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 16)
        Me.Label26.TabIndex = 52
        Me.Label26.Text = "Archivo :"
        '
        'btnImportarExcel
        '
        Me.btnImportarExcel.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnImportarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnImportarExcel.Image = CType(resources.GetObject("btnImportarExcel.Image"), System.Drawing.Image)
        Me.btnImportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarExcel.Location = New System.Drawing.Point(366, 48)
        Me.btnImportarExcel.Name = "btnImportarExcel"
        Me.btnImportarExcel.Size = New System.Drawing.Size(72, 24)
        Me.btnImportarExcel.TabIndex = 2
        Me.btnImportarExcel.Text = "&Importar"
        Me.btnImportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImportarExcel.UseVisualStyleBackColor = True
        '
        'btnBuscarExcel
        '
        Me.btnBuscarExcel.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnBuscarExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarExcel.Image = CType(resources.GetObject("btnBuscarExcel.Image"), System.Drawing.Image)
        Me.btnBuscarExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscarExcel.Location = New System.Drawing.Point(416, 24)
        Me.btnBuscarExcel.Name = "btnBuscarExcel"
        Me.btnBuscarExcel.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarExcel.TabIndex = 0
        Me.btnBuscarExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarExcel.UseVisualStyleBackColor = True
        '
        'btnProcesarPartida
        '
        Me.btnProcesarPartida.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnProcesarPartida.BackColor = System.Drawing.Color.Transparent
        Me.btnProcesarPartida.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnProcesarPartida.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProcesarPartida.Image = CType(resources.GetObject("btnProcesarPartida.Image"), System.Drawing.Image)
        Me.btnProcesarPartida.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProcesarPartida.Location = New System.Drawing.Point(498, 466)
        Me.btnProcesarPartida.Name = "btnProcesarPartida"
        Me.btnProcesarPartida.Size = New System.Drawing.Size(64, 40)
        Me.btnProcesarPartida.TabIndex = 10
        Me.btnProcesarPartida.Text = "&Procesar"
        Me.btnProcesarPartida.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProcesarPartida.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Navy
        Me.Label12.Location = New System.Drawing.Point(570, 514)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 16)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Diferencia :"
        '
        'txtDIFERENCIA
        '
        Me.txtDIFERENCIA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDIFERENCIA.BackColor = System.Drawing.SystemColors.Window
        Me.txtDIFERENCIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIFERENCIA.ForeColor = System.Drawing.Color.Red
        Me.txtDIFERENCIA.Location = New System.Drawing.Point(650, 514)
        Me.txtDIFERENCIA.Name = "txtDIFERENCIA"
        Me.txtDIFERENCIA.ReadOnly = True
        Me.txtDIFERENCIA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDIFERENCIA.Size = New System.Drawing.Size(104, 22)
        Me.txtDIFERENCIA.TabIndex = 35
        '
        'txtABONOS
        '
        Me.txtABONOS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtABONOS.BackColor = System.Drawing.SystemColors.Window
        Me.txtABONOS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtABONOS.ForeColor = System.Drawing.Color.Navy
        Me.txtABONOS.Location = New System.Drawing.Point(650, 490)
        Me.txtABONOS.Name = "txtABONOS"
        Me.txtABONOS.ReadOnly = True
        Me.txtABONOS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtABONOS.Size = New System.Drawing.Size(104, 22)
        Me.txtABONOS.TabIndex = 34
        '
        'txtCARGOS
        '
        Me.txtCARGOS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCARGOS.BackColor = System.Drawing.SystemColors.Window
        Me.txtCARGOS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCARGOS.ForeColor = System.Drawing.Color.Navy
        Me.txtCARGOS.Location = New System.Drawing.Point(650, 466)
        Me.txtCARGOS.Name = "txtCARGOS"
        Me.txtCARGOS.ReadOnly = True
        Me.txtCARGOS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCARGOS.Size = New System.Drawing.Size(104, 22)
        Me.txtCARGOS.TabIndex = 33
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Navy
        Me.Label11.Location = New System.Drawing.Point(570, 490)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 16)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Total Abonos :"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(570, 466)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 16)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Total Cargos :"
        '
        'dgvPartidas
        '
        Me.dgvPartidas.AllowUserToAddRows = False
        Me.dgvPartidas.AllowUserToDeleteRows = False
        Me.dgvPartidas.AllowUserToOrderColumns = True
        Me.dgvPartidas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvPartidas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPartidas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPartidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPartidas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvPartidas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartidas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Linea, Me.codCuenta, Me.CuentaCompleta, Me.Detalle, Me.DescripcionCuenta, Me.ConceptoL, Me.Cargo, Me.Abono, Me.Transaccion})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPartidas.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPartidas.Location = New System.Drawing.Point(8, 185)
        Me.dgvPartidas.Name = "dgvPartidas"
        Me.dgvPartidas.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Red
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartidas.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPartidas.RowHeadersVisible = False
        Me.dgvPartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartidas.Size = New System.Drawing.Size(821, 271)
        Me.dgvPartidas.TabIndex = 28
        '
        'Linea
        '
        Me.Linea.DataPropertyName = "CORRELATIVO"
        Me.Linea.HeaderText = "Linea"
        Me.Linea.Name = "Linea"
        Me.Linea.ReadOnly = True
        Me.Linea.Visible = False
        Me.Linea.Width = 40
        '
        'codCuenta
        '
        Me.codCuenta.DataPropertyName = "CUENTA_CONTABLE"
        Me.codCuenta.HeaderText = "Cod. Cuenta"
        Me.codCuenta.Name = "codCuenta"
        Me.codCuenta.ReadOnly = True
        Me.codCuenta.Visible = False
        Me.codCuenta.Width = 74
        '
        'CuentaCompleta
        '
        Me.CuentaCompleta.DataPropertyName = "CUENTA_COMPLETA"
        Me.CuentaCompleta.HeaderText = "Cuenta"
        Me.CuentaCompleta.Name = "CuentaCompleta"
        Me.CuentaCompleta.ReadOnly = True
        Me.CuentaCompleta.Width = 67
        '
        'Detalle
        '
        Me.Detalle.DataPropertyName = "COD_DETALLE"
        Me.Detalle.HeaderText = "Detalle"
        Me.Detalle.Name = "Detalle"
        Me.Detalle.ReadOnly = True
        Me.Detalle.Width = 65
        '
        'DescripcionCuenta
        '
        Me.DescripcionCuenta.DataPropertyName = "DESCRIPCION_CUENTA"
        Me.DescripcionCuenta.HeaderText = "Descripción Cuenta"
        Me.DescripcionCuenta.Name = "DescripcionCuenta"
        Me.DescripcionCuenta.ReadOnly = True
        Me.DescripcionCuenta.Width = 115
        '
        'ConceptoL
        '
        Me.ConceptoL.DataPropertyName = "CONCEPTO"
        Me.ConceptoL.HeaderText = "Concepto"
        Me.ConceptoL.Name = "ConceptoL"
        Me.ConceptoL.ReadOnly = True
        Me.ConceptoL.Width = 78
        '
        'Cargo
        '
        Me.Cargo.DataPropertyName = "CARGOS"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Cargo.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cargo.HeaderText = "Cargo"
        Me.Cargo.Name = "Cargo"
        Me.Cargo.ReadOnly = True
        Me.Cargo.Width = 63
        '
        'Abono
        '
        Me.Abono.DataPropertyName = "ABONOS"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Abono.DefaultCellStyle = DataGridViewCellStyle4
        Me.Abono.HeaderText = "Abono"
        Me.Abono.Name = "Abono"
        Me.Abono.ReadOnly = True
        Me.Abono.Width = 64
        '
        'Transaccion
        '
        Me.Transaccion.DataPropertyName = "TRANSACCION"
        Me.Transaccion.HeaderText = "Transacción"
        Me.Transaccion.Name = "Transaccion"
        Me.Transaccion.ReadOnly = True
        Me.Transaccion.Visible = False
        Me.Transaccion.Width = 91
        '
        'cmbCARGO_ABONO
        '
        Me.cmbCARGO_ABONO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCARGO_ABONO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCARGO_ABONO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCARGO_ABONO.ForeColor = System.Drawing.Color.Navy
        Me.cmbCARGO_ABONO.FormattingEnabled = True
        Me.cmbCARGO_ABONO.Items.AddRange(New Object() {"Cargo", "Abono"})
        Me.cmbCARGO_ABONO.Location = New System.Drawing.Point(662, 157)
        Me.cmbCARGO_ABONO.Name = "cmbCARGO_ABONO"
        Me.cmbCARGO_ABONO.Size = New System.Drawing.Size(88, 24)
        Me.cmbCARGO_ABONO.TabIndex = 6
        '
        'txtMONTO
        '
        Me.txtMONTO.BackColor = System.Drawing.SystemColors.Window
        Me.txtMONTO.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMONTO.ForeColor = System.Drawing.Color.Navy
        Me.txtMONTO.Location = New System.Drawing.Point(582, 157)
        Me.txtMONTO.Name = "txtMONTO"
        Me.txtMONTO.Size = New System.Drawing.Size(80, 22)
        Me.txtMONTO.TabIndex = 5
        Me.txtMONTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnBuscarCuenta
        '
        Me.btnBuscarCuenta.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscarCuenta.Image = CType(resources.GetObject("btnBuscarCuenta.Image"), System.Drawing.Image)
        Me.btnBuscarCuenta.Location = New System.Drawing.Point(104, 157)
        Me.btnBuscarCuenta.Name = "btnBuscarCuenta"
        Me.btnBuscarCuenta.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarCuenta.TabIndex = 2
        Me.btnBuscarCuenta.UseVisualStyleBackColor = False
        '
        'txtCUENTA_COMPLETA
        '
        Me.txtCUENTA_COMPLETA.BackColor = System.Drawing.Color.White
        Me.txtCUENTA_COMPLETA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCUENTA_COMPLETA.ForeColor = System.Drawing.Color.Navy
        Me.txtCUENTA_COMPLETA.Location = New System.Drawing.Point(8, 157)
        Me.txtCUENTA_COMPLETA.Name = "txtCUENTA_COMPLETA"
        Me.txtCUENTA_COMPLETA.Size = New System.Drawing.Size(96, 22)
        Me.txtCUENTA_COMPLETA.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(8, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 20)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Cuenta                    Detalle          Concepto                              " & _
            "                                                    Monto           Cargo/Abono"
        '
        'gbImportar
        '
        Me.gbImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbImportar.BackColor = System.Drawing.Color.Transparent
        Me.gbImportar.Controls.Add(Me.cmbSheets)
        Me.gbImportar.Controls.Add(Me.btnBuscarExcel)
        Me.gbImportar.Controls.Add(Me.Label27)
        Me.gbImportar.Controls.Add(Me.btnImportarExcel)
        Me.gbImportar.Controls.Add(Me.lblArchivoExcel)
        Me.gbImportar.Controls.Add(Me.Label26)
        Me.gbImportar.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbImportar.ForeColor = System.Drawing.Color.Navy
        Me.gbImportar.Location = New System.Drawing.Point(10, 458)
        Me.gbImportar.Name = "gbImportar"
        Me.gbImportar.Size = New System.Drawing.Size(448, 80)
        Me.gbImportar.TabIndex = 56
        Me.gbImportar.TabStop = False
        Me.gbImportar.Text = "Importar detalle de partida desde Excel"
        '
        'cmbSheets
        '
        Me.cmbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSheets.FormattingEnabled = True
        Me.cmbSheets.Location = New System.Drawing.Point(64, 48)
        Me.cmbSheets.Name = "cmbSheets"
        Me.cmbSheets.Size = New System.Drawing.Size(296, 24)
        Me.cmbSheets.TabIndex = 54
        '
        'lblArchivoExcel
        '
        Me.lblArchivoExcel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblArchivoExcel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblArchivoExcel.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchivoExcel.ForeColor = System.Drawing.Color.Navy
        Me.lblArchivoExcel.Location = New System.Drawing.Point(64, 24)
        Me.lblArchivoExcel.Name = "lblArchivoExcel"
        Me.lblArchivoExcel.Size = New System.Drawing.Size(352, 22)
        Me.lblArchivoExcel.TabIndex = 52
        Me.lblArchivoExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGuardarLinea
        '
        Me.btnGuardarLinea.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardarLinea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardarLinea.Image = CType(resources.GetObject("btnGuardarLinea.Image"), System.Drawing.Image)
        Me.btnGuardarLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardarLinea.Location = New System.Drawing.Point(750, 157)
        Me.btnGuardarLinea.Name = "btnGuardarLinea"
        Me.btnGuardarLinea.Size = New System.Drawing.Size(24, 24)
        Me.btnGuardarLinea.TabIndex = 7
        Me.btnGuardarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardarLinea.UseVisualStyleBackColor = False
        '
        'txtCONCEPTO_L
        '
        Me.txtCONCEPTO_L.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONCEPTO_L.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONCEPTO_L.ForeColor = System.Drawing.Color.Navy
        Me.txtCONCEPTO_L.Location = New System.Drawing.Point(231, 157)
        Me.txtCONCEPTO_L.Name = "txtCONCEPTO_L"
        Me.txtCONCEPTO_L.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCONCEPTO_L.Size = New System.Drawing.Size(351, 22)
        Me.txtCONCEPTO_L.TabIndex = 4
        '
        'btnNuevaLinea
        '
        Me.btnNuevaLinea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevaLinea.Image = CType(resources.GetObject("btnNuevaLinea.Image"), System.Drawing.Image)
        Me.btnNuevaLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevaLinea.Location = New System.Drawing.Point(803, 157)
        Me.btnNuevaLinea.Name = "btnNuevaLinea"
        Me.btnNuevaLinea.Size = New System.Drawing.Size(24, 24)
        Me.btnNuevaLinea.TabIndex = 9
        Me.btnNuevaLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevaLinea.UseVisualStyleBackColor = True
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.BackColor = System.Drawing.Color.SpringGreen
        Me.lblCuenta.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuenta.ForeColor = System.Drawing.Color.Red
        Me.lblCuenta.Location = New System.Drawing.Point(108, 135)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(16, 18)
        Me.lblCuenta.TabIndex = 57
        Me.lblCuenta.Text = "0"
        Me.lblCuenta.Visible = False
        '
        'txtCodDetalle
        '
        Me.txtCodDetalle.BackColor = System.Drawing.Color.White
        Me.txtCodDetalle.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodDetalle.ForeColor = System.Drawing.Color.Navy
        Me.txtCodDetalle.Location = New System.Drawing.Point(130, 157)
        Me.txtCodDetalle.MaxLength = 10
        Me.txtCodDetalle.Name = "txtCodDetalle"
        Me.txtCodDetalle.Size = New System.Drawing.Size(74, 22)
        Me.txtCodDetalle.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(130, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 20)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Cod. Detalle"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Navy
        Me.Label14.Location = New System.Drawing.Point(231, 133)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(351, 20)
        Me.Label14.TabIndex = 65
        Me.Label14.Text = "Concepto"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Navy
        Me.Label15.Location = New System.Drawing.Point(584, 133)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 20)
        Me.Label15.TabIndex = 66
        Me.Label15.Text = "Monto"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Navy
        Me.Label16.Location = New System.Drawing.Point(664, 133)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 20)
        Me.Label16.TabIndex = 67
        Me.Label16.Text = "Cargo/Abono"
        '
        'btnBuscaDetalle
        '
        Me.btnBuscaDetalle.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscaDetalle.Image = CType(resources.GetObject("btnBuscaDetalle.Image"), System.Drawing.Image)
        Me.btnBuscaDetalle.Location = New System.Drawing.Point(205, 157)
        Me.btnBuscaDetalle.Name = "btnBuscaDetalle"
        Me.btnBuscaDetalle.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscaDetalle.TabIndex = 68
        Me.btnBuscaDetalle.UseVisualStyleBackColor = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'Contabilidad_Partidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(841, 543)
        Me.Controls.Add(Me.btnBuscaDetalle)
        Me.Controls.Add(Me.btnNuevaLinea)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnActualizarDetalle)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodDetalle)
        Me.Controls.Add(Me.btnEliminarDetalle)
        Me.Controls.Add(Me.btnGuardarLinea)
        Me.Controls.Add(Me.lblCuenta)
        Me.Controls.Add(Me.txtCONCEPTO_L)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbImportar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgvPartidas)
        Me.Controls.Add(Me.txtTRANSACCION)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnBuscarTransaccion)
        Me.Controls.Add(Me.cmbTIPO_DOCUMENTO)
        Me.Controls.Add(Me.btnBuscarCuenta)
        Me.Controls.Add(Me.txtCUENTA_COMPLETA)
        Me.Controls.Add(Me.txtMONTO)
        Me.Controls.Add(Me.btnProcesarPartida)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmbCARGO_ABONO)
        Me.Controls.Add(Me.txtCARGOS)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtABONOS)
        Me.Controls.Add(Me.txtDIFERENCIA)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Navy
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Partidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Partidas Contables"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbImportar.ResumeLayout(False)
        Me.gbImportar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialogAbrir As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btnImportarExcel As System.Windows.Forms.Button
    Friend WithEvents btnBuscarExcel As System.Windows.Forms.Button
    Friend WithEvents btnProcesarPartida As System.Windows.Forms.Button
    Friend WithEvents dpFECHA_CONTABLE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDIFERENCIA As System.Windows.Forms.TextBox
    Friend WithEvents txtABONOS As System.Windows.Forms.TextBox
    Friend WithEvents txtCARGOS As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCONCEPTO As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvPartidas As System.Windows.Forms.DataGridView
    Friend WithEvents txtDOCUMENTO As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTIPO_DOCUMENTO As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTIPO_PARTIDA As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCARGO_ABONO As System.Windows.Forms.ComboBox
    Friend WithEvents txtMONTO As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCuenta As System.Windows.Forms.Button
    Friend WithEvents cmbLIBRO_CONTABLE As System.Windows.Forms.ComboBox
    Friend WithEvents txtCUENTA_COMPLETA As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbImportar As System.Windows.Forms.GroupBox
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnBuscarTransaccion As System.Windows.Forms.Button
    Friend WithEvents txtTRANSACCION As System.Windows.Forms.TextBox
    Friend WithEvents txtPARTIDA As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPartida As System.Windows.Forms.Button
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents btnGuardarLinea As System.Windows.Forms.Button
    Friend WithEvents lblTransaccionAnula As System.Windows.Forms.Label
    Friend WithEvents lblAnulada As System.Windows.Forms.Label
    Friend WithEvents btnVer As System.Windows.Forms.Button
    Friend WithEvents txtCONCEPTO_L As System.Windows.Forms.TextBox
    Friend WithEvents lblArchivoExcel As System.Windows.Forms.Label
    Friend WithEvents btnActualizarDetalle As System.Windows.Forms.Button
    Friend WithEvents btnEliminarDetalle As System.Windows.Forms.Button
    Friend WithEvents txtCodDetalle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkProcesada As System.Windows.Forms.CheckBox
    Friend WithEvents btnNuevaLinea As System.Windows.Forms.Button
    Friend WithEvents Linea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CuentaCompleta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConceptoL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cargo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Transaccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbSheets As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscaDetalle As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
End Class
