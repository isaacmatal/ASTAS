<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Generar_Cheque_Emergencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Generar_Cheque_Emergencia))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtPartida = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtNumCheque = New System.Windows.Forms.TextBox
        Me.chkNoNeg = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
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
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.bntNuevo = New System.Windows.Forms.Button
        Me.txtPersona = New System.Windows.Forms.TextBox
        Me.txtMonto = New System.Windows.Forms.TextBox
        Me.txtConcepto = New System.Windows.Forms.TextBox
        Me.dpFECHA_CH = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.dgvCheques = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.numcheque = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.noneg = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.montoletras = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Imprimir2 = New System.Windows.Forms.Button
        Me.Imprimir1 = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtPartida)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtNumCheque)
        Me.GroupBox2.Controls.Add(Me.chkNoNeg)
        Me.GroupBox2.Controls.Add(Me.Label8)
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
        Me.GroupBox2.Location = New System.Drawing.Point(7, 130)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.GroupBox2.Size = New System.Drawing.Size(534, 157)
        Me.GroupBox2.TabIndex = 108
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Selección del Banco"
        '
        'txtPartida
        '
        Me.txtPartida.AcceptsTab = True
        Me.txtPartida.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtPartida.ForeColor = System.Drawing.Color.Navy
        Me.txtPartida.Location = New System.Drawing.Point(409, 130)
        Me.txtPartida.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(108, 22)
        Me.txtPartida.TabIndex = 124
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(322, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 16)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Partida #:"
        '
        'txtNumCheque
        '
        Me.txtNumCheque.AcceptsTab = True
        Me.txtNumCheque.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtNumCheque.ForeColor = System.Drawing.Color.Navy
        Me.txtNumCheque.Location = New System.Drawing.Point(409, 101)
        Me.txtNumCheque.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNumCheque.Name = "txtNumCheque"
        Me.txtNumCheque.Size = New System.Drawing.Size(108, 22)
        Me.txtNumCheque.TabIndex = 122
        '
        'chkNoNeg
        '
        Me.chkNoNeg.AutoSize = True
        Me.chkNoNeg.Checked = True
        Me.chkNoNeg.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoNeg.Location = New System.Drawing.Point(11, 133)
        Me.chkNoNeg.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkNoNeg.Name = "chkNoNeg"
        Me.chkNoNeg.Size = New System.Drawing.Size(104, 20)
        Me.chkNoNeg.TabIndex = 117
        Me.chkNoNeg.Text = "No Negociable"
        Me.chkNoNeg.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(322, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 16)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Cheque #:"
        '
        'lblCUENTA_COMPLETA
        '
        Me.lblCUENTA_COMPLETA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCUENTA_COMPLETA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCUENTA_COMPLETA.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCUENTA_COMPLETA.ForeColor = System.Drawing.Color.Navy
        Me.lblCUENTA_COMPLETA.Location = New System.Drawing.Point(409, 65)
        Me.lblCUENTA_COMPLETA.Name = "lblCUENTA_COMPLETA"
        Me.lblCUENTA_COMPLETA.Size = New System.Drawing.Size(108, 27)
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
        Me.cmbBANCO.Location = New System.Drawing.Point(99, 32)
        Me.cmbBANCO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbBANCO.Name = "cmbBANCO"
        Me.cmbBANCO.Size = New System.Drawing.Size(418, 24)
        Me.cmbBANCO.TabIndex = 108
        '
        'lblLIBRO_CONTABLE
        '
        Me.lblLIBRO_CONTABLE.AutoSize = True
        Me.lblLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLIBRO_CONTABLE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLIBRO_CONTABLE.Location = New System.Drawing.Point(323, 84)
        Me.lblLIBRO_CONTABLE.Name = "lblLIBRO_CONTABLE"
        Me.lblLIBRO_CONTABLE.Size = New System.Drawing.Size(14, 16)
        Me.lblLIBRO_CONTABLE.TabIndex = 114
        Me.lblLIBRO_CONTABLE.Text = "0"
        Me.lblLIBRO_CONTABLE.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(8, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 16)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Chequera :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Navy
        Me.Label11.Location = New System.Drawing.Point(8, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 16)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Cta.Banco :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(8, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 16)
        Me.Label10.TabIndex = 111
        Me.Label10.Text = "Banco :"
        '
        'lblCUENTA
        '
        Me.lblCUENTA.AutoSize = True
        Me.lblCUENTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCUENTA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCUENTA.Location = New System.Drawing.Point(343, 84)
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
        Me.cmbCHEQUERA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbCHEQUERA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCHEQUERA.FormattingEnabled = True
        Me.cmbCHEQUERA.Location = New System.Drawing.Point(99, 99)
        Me.cmbCHEQUERA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCHEQUERA.Name = "cmbCHEQUERA"
        Me.cmbCHEQUERA.Size = New System.Drawing.Size(217, 24)
        Me.cmbCHEQUERA.TabIndex = 107
        '
        'cmbCUENTA_BANCARIA
        '
        Me.cmbCUENTA_BANCARIA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCUENTA_BANCARIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCUENTA_BANCARIA.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.cmbCUENTA_BANCARIA.ForeColor = System.Drawing.Color.Navy
        Me.cmbCUENTA_BANCARIA.FormattingEnabled = True
        Me.cmbCUENTA_BANCARIA.Location = New System.Drawing.Point(99, 65)
        Me.cmbCUENTA_BANCARIA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCUENTA_BANCARIA.Name = "cmbCUENTA_BANCARIA"
        Me.cmbCUENTA_BANCARIA.Size = New System.Drawing.Size(217, 24)
        Me.cmbCUENTA_BANCARIA.TabIndex = 107
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(323, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 16)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "Cta.Contable :"
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.Transparent
        Me.btnGenerar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(125, 297)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(80, 30)
        Me.btnGenerar.TabIndex = 109
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.bntNuevo)
        Me.GroupBox1.Controls.Add(Me.txtPersona)
        Me.GroupBox1.Controls.Add(Me.txtMonto)
        Me.GroupBox1.Controls.Add(Me.txtConcepto)
        Me.GroupBox1.Controls.Add(Me.dpFECHA_CH)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(7, 12)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(534, 111)
        Me.GroupBox1.TabIndex = 111
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del cheque"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.AstasConta.My.Resources.Resources.find
        Me.btnBuscar.Location = New System.Drawing.Point(490, 54)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(27, 23)
        Me.btnBuscar.TabIndex = 122
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'bntNuevo
        '
        Me.bntNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.bntNuevo.ForeColor = System.Drawing.Color.Black
        Me.bntNuevo.Image = Global.AstasConta.My.Resources.Resources.filenew
        Me.bntNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bntNuevo.Location = New System.Drawing.Point(448, 18)
        Me.bntNuevo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bntNuevo.Name = "bntNuevo"
        Me.bntNuevo.Size = New System.Drawing.Size(69, 31)
        Me.bntNuevo.TabIndex = 113
        Me.bntNuevo.Text = "&Nuevo"
        Me.bntNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bntNuevo.UseVisualStyleBackColor = True
        '
        'txtPersona
        '
        Me.txtPersona.AcceptsTab = True
        Me.txtPersona.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtPersona.ForeColor = System.Drawing.Color.Navy
        Me.txtPersona.Location = New System.Drawing.Point(95, 54)
        Me.txtPersona.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPersona.MaxLength = 50
        Me.txtPersona.Name = "txtPersona"
        Me.txtPersona.Size = New System.Drawing.Size(390, 22)
        Me.txtPersona.TabIndex = 121
        '
        'txtMonto
        '
        Me.txtMonto.AcceptsTab = True
        Me.txtMonto.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtMonto.ForeColor = System.Drawing.Color.Navy
        Me.txtMonto.Location = New System.Drawing.Point(95, 24)
        Me.txtMonto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(100, 22)
        Me.txtMonto.TabIndex = 120
        '
        'txtConcepto
        '
        Me.txtConcepto.AcceptsTab = True
        Me.txtConcepto.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.txtConcepto.ForeColor = System.Drawing.Color.Navy
        Me.txtConcepto.Location = New System.Drawing.Point(95, 81)
        Me.txtConcepto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(423, 22)
        Me.txtConcepto.TabIndex = 119
        '
        'dpFECHA_CH
        '
        Me.dpFECHA_CH.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CH.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_CH.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_CH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_CH.Location = New System.Drawing.Point(322, 22)
        Me.dpFECHA_CH.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFECHA_CH.MinDate = New Date(2013, 1, 11, 0, 0, 0, 0)
        Me.dpFECHA_CH.Name = "dpFECHA_CH"
        Me.dpFECHA_CH.Size = New System.Drawing.Size(112, 22)
        Me.dpFECHA_CH.TabIndex = 116
        Me.dpFECHA_CH.Value = New Date(2013, 1, 29, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(9, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "Concepto :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(9, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 16)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "A Nombre de:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(221, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Fecha cheque :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(9, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Monto :"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(400, 491)
        Me.CrystalReportViewer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(150, 184)
        Me.CrystalReportViewer1.TabIndex = 112
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        Me.CrystalReportViewer1.Visible = False
        '
        'dgvCheques
        '
        Me.dgvCheques.AllowUserToAddRows = False
        Me.dgvCheques.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvCheques.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCheques.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCheques.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selec, Me.numcheque, Me.nombre, Me.monto, Me.noneg, Me.montoletras, Me.fecha})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCheques.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCheques.Location = New System.Drawing.Point(13, 330)
        Me.dgvCheques.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvCheques.Name = "dgvCheques"
        Me.dgvCheques.RowHeadersVisible = False
        Me.dgvCheques.Size = New System.Drawing.Size(523, 164)
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.numcheque.DefaultCellStyle = DataGridViewCellStyle2
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
        Me.nombre.Width = 250
        '
        'monto
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.monto.DefaultCellStyle = DataGridViewCellStyle3
        Me.monto.HeaderText = "Monto"
        Me.monto.Name = "monto"
        Me.monto.ReadOnly = True
        Me.monto.Width = 70
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
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.fecha.DefaultCellStyle = DataGridViewCellStyle4
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Width = 80
        '
        'Imprimir2
        '
        Me.Imprimir2.BackColor = System.Drawing.Color.Transparent
        Me.Imprimir2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Imprimir2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Imprimir2.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.Imprimir2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Imprimir2.Location = New System.Drawing.Point(321, 298)
        Me.Imprimir2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Imprimir2.Name = "Imprimir2"
        Me.Imprimir2.Size = New System.Drawing.Size(103, 30)
        Me.Imprimir2.TabIndex = 114
        Me.Imprimir2.Text = "&Imprimir Todos"
        Me.Imprimir2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Imprimir2.UseVisualStyleBackColor = False
        '
        'Imprimir1
        '
        Me.Imprimir1.BackColor = System.Drawing.Color.Transparent
        Me.Imprimir1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Imprimir1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Imprimir1.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.Imprimir1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Imprimir1.Location = New System.Drawing.Point(211, 298)
        Me.Imprimir1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Imprimir1.Name = "Imprimir1"
        Me.Imprimir1.Size = New System.Drawing.Size(104, 30)
        Me.Imprimir1.TabIndex = 115
        Me.Imprimir1.Text = "&Imp.Individual"
        Me.Imprimir1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Imprimir1.UseVisualStyleBackColor = False
        '
        'Contabilidad_Generar_Cheque_Emergencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 507)
        Me.Controls.Add(Me.Imprimir1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Imprimir2)
        Me.Controls.Add(Me.dgvCheques)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Generar_Cheque_Emergencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Emitir Cheque"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkNoNeg As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPersona As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents dpFECHA_CH As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents bntNuevo As System.Windows.Forms.Button
    Friend WithEvents txtNumCheque As System.Windows.Forms.TextBox
    Friend WithEvents dgvCheques As System.Windows.Forms.DataGridView
    Friend WithEvents Imprimir2 As System.Windows.Forms.Button
    Friend WithEvents Imprimir1 As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents numcheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents noneg As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents montoletras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
