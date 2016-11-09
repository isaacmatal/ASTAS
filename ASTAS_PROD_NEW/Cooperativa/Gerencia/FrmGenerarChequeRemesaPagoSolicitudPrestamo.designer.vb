<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGenerarChequeRemesaPagoSolicitudPrestamo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGenerarChequeRemesaPagoSolicitudPrestamo))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtPartida = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkPapeleria = New System.Windows.Forms.CheckBox
        Me.BtnBuscarSol = New System.Windows.Forms.Button
        Me.txtMonto = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.lblSocio = New System.Windows.Forms.TextBox
        Me.lblCtaSocio = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblBancoSocio = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtBuxis = New System.Windows.Forms.TextBox
        Me.dpFECHA = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnEditarConcepto = New System.Windows.Forms.Button
        Me.lblPagado = New System.Windows.Forms.Label
        Me.lblCantidad = New System.Windows.Forms.Label
        Me.lblSolicitud = New System.Windows.Forms.Label
        Me.txtConcepto = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblCodigoAS = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtCheque = New System.Windows.Forms.TextBox
        Me.chkNoNeg = New System.Windows.Forms.CheckBox
        Me.lblCUENTA_COMPLETA = New System.Windows.Forms.Label
        Me.cmbBANCO = New System.Windows.Forms.ComboBox
        Me.lblLIBRO_CONTABLE = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblCUENTA = New System.Windows.Forms.Label
        Me.cmbCHEQUERA = New System.Windows.Forms.ComboBox
        Me.cmbCUENTA_BANCARIA = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgvCheques = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.numcheque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.montochq = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.noneg = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.montoletras = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtPartida)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkPapeleria)
        Me.GroupBox1.Controls.Add(Me.BtnBuscarSol)
        Me.GroupBox1.Controls.Add(Me.txtMonto)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.btnGenerar)
        Me.GroupBox1.Controls.Add(Me.lblSocio)
        Me.GroupBox1.Controls.Add(Me.lblCtaSocio)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.lblBancoSocio)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TxtBuxis)
        Me.GroupBox1.Controls.Add(Me.dpFECHA)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnEditarConcepto)
        Me.GroupBox1.Controls.Add(Me.lblPagado)
        Me.GroupBox1.Controls.Add(Me.lblCantidad)
        Me.GroupBox1.Controls.Add(Me.lblSolicitud)
        Me.GroupBox1.Controls.Add(Me.txtConcepto)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblCodigoAS)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(454, 285)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos generales"
        '
        'txtPartida
        '
        Me.txtPartida.Location = New System.Drawing.Point(381, 96)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(60, 22)
        Me.txtPartida.TabIndex = 133
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(292, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Número Partida :"
        '
        'chkPapeleria
        '
        Me.chkPapeleria.AutoSize = True
        Me.chkPapeleria.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPapeleria.Checked = True
        Me.chkPapeleria.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPapeleria.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPapeleria.Location = New System.Drawing.Point(269, 257)
        Me.chkPapeleria.Name = "chkPapeleria"
        Me.chkPapeleria.Size = New System.Drawing.Size(173, 20)
        Me.chkPapeleria.TabIndex = 131
        Me.chkPapeleria.Text = "Descontar Papelería ($ 0.25)"
        Me.chkPapeleria.UseVisualStyleBackColor = True
        '
        'BtnBuscarSol
        '
        Me.BtnBuscarSol.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnBuscarSol.ForeColor = System.Drawing.Color.Black
        Me.BtnBuscarSol.Image = CType(resources.GetObject("BtnBuscarSol.Image"), System.Drawing.Image)
        Me.BtnBuscarSol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarSol.Location = New System.Drawing.Point(327, 58)
        Me.BtnBuscarSol.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscarSol.Name = "BtnBuscarSol"
        Me.BtnBuscarSol.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscarSol.TabIndex = 130
        Me.BtnBuscarSol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarSol.UseVisualStyleBackColor = True
        '
        'txtMonto
        '
        Me.txtMonto.ForeColor = System.Drawing.Color.Navy
        Me.txtMonto.Location = New System.Drawing.Point(348, 231)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(94, 22)
        Me.txtMonto.TabIndex = 129
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(418, 134)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 128
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Enabled = False
        Me.btnGenerar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGenerar.Image = Global.ASTAS.My.Resources.Resources.exec
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(358, 23)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(84, 24)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.Text = "&Procesar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'lblSocio
        '
        Me.lblSocio.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblSocio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSocio.ForeColor = System.Drawing.Color.Navy
        Me.lblSocio.Location = New System.Drawing.Point(86, 135)
        Me.lblSocio.MaxLength = 75
        Me.lblSocio.Name = "lblSocio"
        Me.lblSocio.ReadOnly = True
        Me.lblSocio.Size = New System.Drawing.Size(333, 22)
        Me.lblSocio.TabIndex = 127
        '
        'lblCtaSocio
        '
        Me.lblCtaSocio.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCtaSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCtaSocio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCtaSocio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCtaSocio.Location = New System.Drawing.Point(270, 24)
        Me.lblCtaSocio.Name = "lblCtaSocio"
        Me.lblCtaSocio.Size = New System.Drawing.Size(65, 22)
        Me.lblCtaSocio.TabIndex = 126
        Me.lblCtaSocio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCtaSocio.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(195, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 16)
        Me.Label14.TabIndex = 125
        Me.Label14.Text = "Cuenta Socio:"
        Me.Label14.Visible = False
        '
        'lblBancoSocio
        '
        Me.lblBancoSocio.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblBancoSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBancoSocio.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBancoSocio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBancoSocio.Location = New System.Drawing.Point(86, 96)
        Me.lblBancoSocio.Name = "lblBancoSocio"
        Me.lblBancoSocio.Size = New System.Drawing.Size(183, 22)
        Me.lblBancoSocio.TabIndex = 124
        Me.lblBancoSocio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(6, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 16)
        Me.Label9.TabIndex = 123
        Me.Label9.Text = "Banco Socio :"
        '
        'TxtBuxis
        '
        Me.TxtBuxis.BackColor = System.Drawing.Color.Gainsboro
        Me.TxtBuxis.Location = New System.Drawing.Point(249, 58)
        Me.TxtBuxis.Name = "TxtBuxis"
        Me.TxtBuxis.ReadOnly = True
        Me.TxtBuxis.Size = New System.Drawing.Size(72, 22)
        Me.TxtBuxis.TabIndex = 122
        Me.TxtBuxis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dpFECHA
        '
        Me.dpFECHA.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA.Location = New System.Drawing.Point(86, 23)
        Me.dpFECHA.Name = "dpFECHA"
        Me.dpFECHA.Size = New System.Drawing.Size(108, 22)
        Me.dpFECHA.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(5, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 16)
        Me.Label15.TabIndex = 121
        Me.Label15.Text = "Fecha Cheque :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(174, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 16)
        Me.Label6.TabIndex = 119
        Me.Label6.Text = "Código Buxis :"
        '
        'btnEditarConcepto
        '
        Me.btnEditarConcepto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEditarConcepto.Image = CType(resources.GetObject("btnEditarConcepto.Image"), System.Drawing.Image)
        Me.btnEditarConcepto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditarConcepto.Location = New System.Drawing.Point(418, 171)
        Me.btnEditarConcepto.Name = "btnEditarConcepto"
        Me.btnEditarConcepto.Size = New System.Drawing.Size(24, 24)
        Me.btnEditarConcepto.TabIndex = 105
        Me.btnEditarConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditarConcepto.UseVisualStyleBackColor = True
        '
        'lblPagado
        '
        Me.lblPagado.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPagado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPagado.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblPagado.ForeColor = System.Drawing.Color.Red
        Me.lblPagado.Location = New System.Drawing.Point(236, 231)
        Me.lblPagado.Name = "lblPagado"
        Me.lblPagado.Size = New System.Drawing.Size(88, 22)
        Me.lblPagado.TabIndex = 117
        Me.lblPagado.Text = "0.00"
        Me.lblPagado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCantidad
        '
        Me.lblCantidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCantidad.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblCantidad.ForeColor = System.Drawing.Color.Blue
        Me.lblCantidad.Location = New System.Drawing.Point(119, 231)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(88, 22)
        Me.lblCantidad.TabIndex = 117
        Me.lblCantidad.Text = "0.00"
        Me.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSolicitud
        '
        Me.lblSolicitud.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSolicitud.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.lblSolicitud.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSolicitud.Location = New System.Drawing.Point(8, 231)
        Me.lblSolicitud.Name = "lblSolicitud"
        Me.lblSolicitud.Size = New System.Drawing.Size(88, 22)
        Me.lblSolicitud.TabIndex = 117
        Me.lblSolicitud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtConcepto
        '
        Me.txtConcepto.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtConcepto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConcepto.ForeColor = System.Drawing.Color.Navy
        Me.txtConcepto.Location = New System.Drawing.Point(86, 172)
        Me.txtConcepto.MaxLength = 75
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ReadOnly = True
        Me.txtConcepto.Size = New System.Drawing.Size(333, 22)
        Me.txtConcepto.TabIndex = 43
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Navy
        Me.Label17.Location = New System.Drawing.Point(8, 207)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(434, 20)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "Solicitud No.             Monto Solicitado           Total Pagado          Monto " & _
            "Cheque"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(5, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Concepto :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(5, 138)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 16)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "A Nombre de :"
        '
        'lblCodigoAS
        '
        Me.lblCodigoAS.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCodigoAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCodigoAS.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoAS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodigoAS.Location = New System.Drawing.Point(86, 58)
        Me.lblCodigoAS.Name = "lblCodigoAS"
        Me.lblCodigoAS.Size = New System.Drawing.Size(72, 22)
        Me.lblCodigoAS.TabIndex = 2
        Me.lblCodigoAS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(5, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código AS :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtCheque)
        Me.GroupBox2.Controls.Add(Me.chkNoNeg)
        Me.GroupBox2.Controls.Add(Me.lblCUENTA_COMPLETA)
        Me.GroupBox2.Controls.Add(Me.cmbBANCO)
        Me.GroupBox2.Controls.Add(Me.lblLIBRO_CONTABLE)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblCUENTA)
        Me.GroupBox2.Controls.Add(Me.cmbCHEQUERA)
        Me.GroupBox2.Controls.Add(Me.cmbCUENTA_BANCARIA)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(7, 293)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(454, 148)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Selección del Banco"
        '
        'txtCheque
        '
        Me.txtCheque.Location = New System.Drawing.Point(375, 89)
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(67, 22)
        Me.txtCheque.TabIndex = 116
        Me.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkNoNeg
        '
        Me.chkNoNeg.AutoSize = True
        Me.chkNoNeg.Checked = True
        Me.chkNoNeg.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoNeg.Location = New System.Drawing.Point(11, 120)
        Me.chkNoNeg.Name = "chkNoNeg"
        Me.chkNoNeg.Size = New System.Drawing.Size(104, 20)
        Me.chkNoNeg.TabIndex = 115
        Me.chkNoNeg.Text = "No Negociable"
        Me.chkNoNeg.UseVisualStyleBackColor = True
        '
        'lblCUENTA_COMPLETA
        '
        Me.lblCUENTA_COMPLETA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCUENTA_COMPLETA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCUENTA_COMPLETA.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCUENTA_COMPLETA.ForeColor = System.Drawing.Color.Navy
        Me.lblCUENTA_COMPLETA.Location = New System.Drawing.Point(341, 58)
        Me.lblCUENTA_COMPLETA.Name = "lblCUENTA_COMPLETA"
        Me.lblCUENTA_COMPLETA.Size = New System.Drawing.Size(101, 22)
        Me.lblCUENTA_COMPLETA.TabIndex = 2
        Me.lblCUENTA_COMPLETA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBANCO
        '
        Me.cmbBANCO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBANCO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBANCO.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbBANCO.ForeColor = System.Drawing.Color.Navy
        Me.cmbBANCO.FormattingEnabled = True
        Me.cmbBANCO.Location = New System.Drawing.Point(90, 24)
        Me.cmbBANCO.Name = "cmbBANCO"
        Me.cmbBANCO.Size = New System.Drawing.Size(352, 24)
        Me.cmbBANCO.TabIndex = 0
        '
        'lblLIBRO_CONTABLE
        '
        Me.lblLIBRO_CONTABLE.AutoSize = True
        Me.lblLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLIBRO_CONTABLE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLIBRO_CONTABLE.Location = New System.Drawing.Point(301, 9)
        Me.lblLIBRO_CONTABLE.Name = "lblLIBRO_CONTABLE"
        Me.lblLIBRO_CONTABLE.Size = New System.Drawing.Size(14, 16)
        Me.lblLIBRO_CONTABLE.TabIndex = 114
        Me.lblLIBRO_CONTABLE.Text = "0"
        Me.lblLIBRO_CONTABLE.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Chequera :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(8, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 16)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Cuenta Banco :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 16)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "Banco :"
        '
        'lblCUENTA
        '
        Me.lblCUENTA.AutoSize = True
        Me.lblCUENTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCUENTA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCUENTA.Location = New System.Drawing.Point(138, 9)
        Me.lblCUENTA.Name = "lblCUENTA"
        Me.lblCUENTA.Size = New System.Drawing.Size(14, 16)
        Me.lblCUENTA.TabIndex = 113
        Me.lblCUENTA.Text = "0"
        Me.lblCUENTA.Visible = False
        '
        'cmbCHEQUERA
        '
        Me.cmbCHEQUERA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCHEQUERA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCHEQUERA.DropDownWidth = 350
        Me.cmbCHEQUERA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbCHEQUERA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCHEQUERA.FormattingEnabled = True
        Me.cmbCHEQUERA.Location = New System.Drawing.Point(90, 89)
        Me.cmbCHEQUERA.Name = "cmbCHEQUERA"
        Me.cmbCHEQUERA.Size = New System.Drawing.Size(245, 24)
        Me.cmbCHEQUERA.TabIndex = 2
        '
        'cmbCUENTA_BANCARIA
        '
        Me.cmbCUENTA_BANCARIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCUENTA_BANCARIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCUENTA_BANCARIA.DropDownWidth = 350
        Me.cmbCUENTA_BANCARIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbCUENTA_BANCARIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCUENTA_BANCARIA.FormattingEnabled = True
        Me.cmbCUENTA_BANCARIA.Location = New System.Drawing.Point(90, 57)
        Me.cmbCUENTA_BANCARIA.Name = "cmbCUENTA_BANCARIA"
        Me.cmbCUENTA_BANCARIA.Size = New System.Drawing.Size(245, 24)
        Me.cmbCUENTA_BANCARIA.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(338, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 16)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "Chq.#"
        '
        'dgvCheques
        '
        Me.dgvCheques.AllowUserToAddRows = False
        Me.dgvCheques.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray
        Me.dgvCheques.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCheques.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCheques.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCheques.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selec, Me.numcheque, Me.nombre, Me.montochq, Me.noneg, Me.montoletras, Me.fecha})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCheques.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvCheques.Location = New System.Drawing.Point(467, 10)
        Me.dgvCheques.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvCheques.Name = "dgvCheques"
        Me.dgvCheques.RowHeadersVisible = False
        Me.dgvCheques.Size = New System.Drawing.Size(471, 278)
        Me.dgvCheques.TabIndex = 113
        '
        'selec
        '
        Me.selec.HeaderText = ""
        Me.selec.Name = "selec"
        Me.selec.Visible = False
        Me.selec.Width = 30
        '
        'numcheque
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.numcheque.DefaultCellStyle = DataGridViewCellStyle7
        Me.numcheque.HeaderText = "Cheque No."
        Me.numcheque.Name = "numcheque"
        Me.numcheque.ReadOnly = True
        Me.numcheque.Width = 50
        '
        'nombre
        '
        Me.nombre.HeaderText = "A Nombre de"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.nombre.Width = 200
        '
        'montochq
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.montochq.DefaultCellStyle = DataGridViewCellStyle8
        Me.montochq.HeaderText = "Monto"
        Me.montochq.Name = "montochq"
        Me.montochq.ReadOnly = True
        Me.montochq.Width = 70
        '
        'noneg
        '
        Me.noneg.HeaderText = "No Neg"
        Me.noneg.Name = "noneg"
        Me.noneg.Width = 50
        '
        'montoletras
        '
        Me.montoletras.HeaderText = "Monto Letras"
        Me.montoletras.Name = "montoletras"
        Me.montoletras.ReadOnly = True
        Me.montoletras.Visible = False
        Me.montoletras.Width = 110
        '
        'fecha
        '
        DataGridViewCellStyle9.Format = "d"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.fecha.DefaultCellStyle = DataGridViewCellStyle9
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Width = 80
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Button2.Location = New System.Drawing.Point(467, 298)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 43)
        Me.Button2.TabIndex = 114
        Me.Button2.Text = "Imprimir Cheques"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FrmGenerarChequeRemesaPagoSolicitudPrestamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(943, 455)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvCheques)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmGenerarChequeRemesaPagoSolicitudPrestamo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Generar Cheque de Pago Préstamos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEditarConcepto As System.Windows.Forms.Button
    Friend WithEvents lblPagado As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents lblSolicitud As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblCodigoAS As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCUENTA_COMPLETA As System.Windows.Forms.Label
    Friend WithEvents cmbBANCO As System.Windows.Forms.ComboBox
    Friend WithEvents lblLIBRO_CONTABLE As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblCUENTA As System.Windows.Forms.Label
    Friend WithEvents cmbCHEQUERA As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCUENTA_BANCARIA As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents TxtBuxis As System.Windows.Forms.TextBox
    Friend WithEvents dpFECHA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkNoNeg As System.Windows.Forms.CheckBox
    Friend WithEvents lblCtaSocio As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgvCheques As System.Windows.Forms.DataGridView
    Friend WithEvents lblBancoSocio As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblSocio As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscarSol As System.Windows.Forms.Button
    Friend WithEvents txtCheque As System.Windows.Forms.TextBox
    Friend WithEvents chkPapeleria As System.Windows.Forms.CheckBox
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents numcheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents montochq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents noneg As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents montoletras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
