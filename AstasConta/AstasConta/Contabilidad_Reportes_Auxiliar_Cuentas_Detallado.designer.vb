<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reportes_Auxiliar_Cuentas_Detallado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Reportes_Auxiliar_Cuentas_Detallado))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkSaldoCero = New System.Windows.Forms.CheckBox
        Me.chkNoAgruparCod = New System.Windows.Forms.CheckBox
        Me.txtDescDetalleFin = New System.Windows.Forms.TextBox
        Me.txtDescDetalleIni = New System.Windows.Forms.TextBox
        Me.btnBuscaDetalleFin = New System.Windows.Forms.Button
        Me.btnBuscaDetalleIni = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCodDetalle2 = New System.Windows.Forms.TextBox
        Me.btnBuscarCuenta2 = New System.Windows.Forms.Button
        Me.txtDesCtaFin = New System.Windows.Forms.TextBox
        Me.txtCuentafin = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCodDetalle = New System.Windows.Forms.TextBox
        Me.btnBuscarCuenta1 = New System.Windows.Forms.Button
        Me.txtCONCEPTO_I = New System.Windows.Forms.TextBox
        Me.txtCuentaIni = New System.Windows.Forms.TextBox
        Me.dpFecha_F = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnVerBC = New System.Windows.Forms.Button
        Me.dpFecha_I = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbLIBRO_CONTABLE = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(821, 2)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(110, 163)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 110
        Me.pbImagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkSaldoCero)
        Me.GroupBox1.Controls.Add(Me.chkNoAgruparCod)
        Me.GroupBox1.Controls.Add(Me.txtDescDetalleFin)
        Me.GroupBox1.Controls.Add(Me.txtDescDetalleIni)
        Me.GroupBox1.Controls.Add(Me.btnBuscaDetalleFin)
        Me.GroupBox1.Controls.Add(Me.btnBuscaDetalleIni)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCodDetalle2)
        Me.GroupBox1.Controls.Add(Me.btnBuscarCuenta2)
        Me.GroupBox1.Controls.Add(Me.txtDesCtaFin)
        Me.GroupBox1.Controls.Add(Me.txtCuentafin)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCodDetalle)
        Me.GroupBox1.Controls.Add(Me.btnBuscarCuenta1)
        Me.GroupBox1.Controls.Add(Me.txtCONCEPTO_I)
        Me.GroupBox1.Controls.Add(Me.txtCuentaIni)
        Me.GroupBox1.Controls.Add(Me.dpFecha_F)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnVerBC)
        Me.GroupBox1.Controls.Add(Me.dpFecha_I)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cmbLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(12, 1)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(805, 164)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkSaldoCero
        '
        Me.chkSaldoCero.AutoSize = True
        Me.chkSaldoCero.Checked = True
        Me.chkSaldoCero.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSaldoCero.Location = New System.Drawing.Point(582, 136)
        Me.chkSaldoCero.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.chkSaldoCero.Name = "chkSaldoCero"
        Me.chkSaldoCero.Size = New System.Drawing.Size(215, 20)
        Me.chkSaldoCero.TabIndex = 7
        Me.chkSaldoCero.Text = "Omitir Saldos Cero sin Movimientos"
        Me.chkSaldoCero.UseVisualStyleBackColor = True
        '
        'chkNoAgruparCod
        '
        Me.chkNoAgruparCod.AutoSize = True
        Me.chkNoAgruparCod.Location = New System.Drawing.Point(582, 111)
        Me.chkNoAgruparCod.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.chkNoAgruparCod.Name = "chkNoAgruparCod"
        Me.chkNoAgruparCod.Size = New System.Drawing.Size(168, 20)
        Me.chkNoAgruparCod.TabIndex = 6
        Me.chkNoAgruparCod.Text = "No Agrupar Código Detalle"
        Me.chkNoAgruparCod.UseVisualStyleBackColor = True
        '
        'txtDescDetalleFin
        '
        Me.txtDescDetalleFin.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescDetalleFin.Enabled = False
        Me.txtDescDetalleFin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescDetalleFin.ForeColor = System.Drawing.Color.Navy
        Me.txtDescDetalleFin.Location = New System.Drawing.Point(234, 136)
        Me.txtDescDetalleFin.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtDescDetalleFin.MaxLength = 100
        Me.txtDescDetalleFin.Name = "txtDescDetalleFin"
        Me.txtDescDetalleFin.ReadOnly = True
        Me.txtDescDetalleFin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescDetalleFin.Size = New System.Drawing.Size(337, 22)
        Me.txtDescDetalleFin.TabIndex = 124
        '
        'txtDescDetalleIni
        '
        Me.txtDescDetalleIni.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescDetalleIni.Enabled = False
        Me.txtDescDetalleIni.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescDetalleIni.ForeColor = System.Drawing.Color.Navy
        Me.txtDescDetalleIni.Location = New System.Drawing.Point(234, 78)
        Me.txtDescDetalleIni.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtDescDetalleIni.MaxLength = 100
        Me.txtDescDetalleIni.Name = "txtDescDetalleIni"
        Me.txtDescDetalleIni.ReadOnly = True
        Me.txtDescDetalleIni.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescDetalleIni.Size = New System.Drawing.Size(336, 22)
        Me.txtDescDetalleIni.TabIndex = 123
        '
        'btnBuscaDetalleFin
        '
        Me.btnBuscaDetalleFin.Image = CType(resources.GetObject("btnBuscaDetalleFin.Image"), System.Drawing.Image)
        Me.btnBuscaDetalleFin.Location = New System.Drawing.Point(207, 134)
        Me.btnBuscaDetalleFin.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnBuscaDetalleFin.Name = "btnBuscaDetalleFin"
        Me.btnBuscaDetalleFin.Size = New System.Drawing.Size(24, 26)
        Me.btnBuscaDetalleFin.TabIndex = 122
        Me.btnBuscaDetalleFin.UseVisualStyleBackColor = True
        '
        'btnBuscaDetalleIni
        '
        Me.btnBuscaDetalleIni.Image = CType(resources.GetObject("btnBuscaDetalleIni.Image"), System.Drawing.Image)
        Me.btnBuscaDetalleIni.Location = New System.Drawing.Point(207, 77)
        Me.btnBuscaDetalleIni.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnBuscaDetalleIni.Name = "btnBuscaDetalleIni"
        Me.btnBuscaDetalleIni.Size = New System.Drawing.Size(24, 26)
        Me.btnBuscaDetalleIni.TabIndex = 121
        Me.btnBuscaDetalleIni.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(5, 138)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 16)
        Me.Label6.TabIndex = 120
        Me.Label6.Text = "Detalle Final:"
        '
        'txtCodDetalle2
        '
        Me.txtCodDetalle2.BackColor = System.Drawing.Color.White
        Me.txtCodDetalle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodDetalle2.ForeColor = System.Drawing.Color.Navy
        Me.txtCodDetalle2.Location = New System.Drawing.Point(114, 135)
        Me.txtCodDetalle2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtCodDetalle2.Name = "txtCodDetalle2"
        Me.txtCodDetalle2.Size = New System.Drawing.Size(93, 22)
        Me.txtCodDetalle2.TabIndex = 3
        Me.txtCodDetalle2.Text = "0"
        '
        'btnBuscarCuenta2
        '
        Me.btnBuscarCuenta2.Image = CType(resources.GetObject("btnBuscarCuenta2.Image"), System.Drawing.Image)
        Me.btnBuscarCuenta2.Location = New System.Drawing.Point(207, 106)
        Me.btnBuscarCuenta2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnBuscarCuenta2.Name = "btnBuscarCuenta2"
        Me.btnBuscarCuenta2.Size = New System.Drawing.Size(24, 26)
        Me.btnBuscarCuenta2.TabIndex = 8
        Me.btnBuscarCuenta2.UseVisualStyleBackColor = True
        '
        'txtDesCtaFin
        '
        Me.txtDesCtaFin.BackColor = System.Drawing.SystemColors.Window
        Me.txtDesCtaFin.Enabled = False
        Me.txtDesCtaFin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesCtaFin.ForeColor = System.Drawing.Color.Navy
        Me.txtDesCtaFin.Location = New System.Drawing.Point(235, 107)
        Me.txtDesCtaFin.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtDesCtaFin.MaxLength = 100
        Me.txtDesCtaFin.Name = "txtDesCtaFin"
        Me.txtDesCtaFin.ReadOnly = True
        Me.txtDesCtaFin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDesCtaFin.Size = New System.Drawing.Size(336, 22)
        Me.txtDesCtaFin.TabIndex = 10
        '
        'txtCuentafin
        '
        Me.txtCuentafin.BackColor = System.Drawing.Color.White
        Me.txtCuentafin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentafin.ForeColor = System.Drawing.Color.Navy
        Me.txtCuentafin.Location = New System.Drawing.Point(114, 107)
        Me.txtCuentafin.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtCuentafin.Name = "txtCuentafin"
        Me.txtCuentafin.Size = New System.Drawing.Size(93, 22)
        Me.txtCuentafin.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(6, 112)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 118
        Me.Label5.Text = "Cuenta Final:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(5, 82)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Detalle Inicial:"
        '
        'txtCodDetalle
        '
        Me.txtCodDetalle.BackColor = System.Drawing.Color.White
        Me.txtCodDetalle.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodDetalle.ForeColor = System.Drawing.Color.Navy
        Me.txtCodDetalle.Location = New System.Drawing.Point(114, 78)
        Me.txtCodDetalle.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtCodDetalle.Name = "txtCodDetalle"
        Me.txtCodDetalle.Size = New System.Drawing.Size(93, 22)
        Me.txtCodDetalle.TabIndex = 1
        Me.txtCodDetalle.Text = "0"
        '
        'btnBuscarCuenta1
        '
        Me.btnBuscarCuenta1.Image = CType(resources.GetObject("btnBuscarCuenta1.Image"), System.Drawing.Image)
        Me.btnBuscarCuenta1.Location = New System.Drawing.Point(207, 47)
        Me.btnBuscarCuenta1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnBuscarCuenta1.Name = "btnBuscarCuenta1"
        Me.btnBuscarCuenta1.Size = New System.Drawing.Size(24, 26)
        Me.btnBuscarCuenta1.TabIndex = 7
        Me.btnBuscarCuenta1.UseVisualStyleBackColor = True
        '
        'txtCONCEPTO_I
        '
        Me.txtCONCEPTO_I.BackColor = System.Drawing.SystemColors.Window
        Me.txtCONCEPTO_I.Enabled = False
        Me.txtCONCEPTO_I.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCONCEPTO_I.ForeColor = System.Drawing.Color.Navy
        Me.txtCONCEPTO_I.Location = New System.Drawing.Point(234, 49)
        Me.txtCONCEPTO_I.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtCONCEPTO_I.MaxLength = 100
        Me.txtCONCEPTO_I.Name = "txtCONCEPTO_I"
        Me.txtCONCEPTO_I.ReadOnly = True
        Me.txtCONCEPTO_I.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCONCEPTO_I.Size = New System.Drawing.Size(337, 22)
        Me.txtCONCEPTO_I.TabIndex = 9
        '
        'txtCuentaIni
        '
        Me.txtCuentaIni.BackColor = System.Drawing.Color.White
        Me.txtCuentaIni.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaIni.ForeColor = System.Drawing.Color.Navy
        Me.txtCuentaIni.Location = New System.Drawing.Point(114, 50)
        Me.txtCuentaIni.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtCuentaIni.Name = "txtCuentaIni"
        Me.txtCuentaIni.Size = New System.Drawing.Size(93, 22)
        Me.txtCuentaIni.TabIndex = 0
        '
        'dpFecha_F
        '
        Me.dpFecha_F.CustomFormat = "dd-MMM-yyyy"
        Me.dpFecha_F.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFecha_F.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha_F.Location = New System.Drawing.Point(661, 79)
        Me.dpFecha_F.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dpFecha_F.Name = "dpFecha_F"
        Me.dpFecha_F.Size = New System.Drawing.Size(102, 22)
        Me.dpFecha_F.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(579, 82)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Fecha Final:"
        '
        'btnVerBC
        '
        Me.btnVerBC.Image = Global.AstasConta.My.Resources.Resources.exec
        Me.btnVerBC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerBC.Location = New System.Drawing.Point(582, 17)
        Me.btnVerBC.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnVerBC.Name = "btnVerBC"
        Me.btnVerBC.Size = New System.Drawing.Size(124, 24)
        Me.btnVerBC.TabIndex = 8
        Me.btnVerBC.Text = "Generar Reporte"
        Me.btnVerBC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerBC.UseVisualStyleBackColor = True
        '
        'dpFecha_I
        '
        Me.dpFecha_I.CustomFormat = "dd-MMM-yyyy"
        Me.dpFecha_I.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFecha_I.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha_I.Location = New System.Drawing.Point(659, 50)
        Me.dpFecha_I.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dpFecha_I.Name = "dpFecha_I"
        Me.dpFecha_I.Size = New System.Drawing.Size(104, 22)
        Me.dpFecha_I.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(579, 52)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 16)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Fecha Inicial:"
        '
        'cmbLIBRO_CONTABLE
        '
        Me.cmbLIBRO_CONTABLE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE.Location = New System.Drawing.Point(114, 17)
        Me.cmbLIBRO_CONTABLE.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmbLIBRO_CONTABLE.Name = "cmbLIBRO_CONTABLE"
        Me.cmbLIBRO_CONTABLE.Size = New System.Drawing.Size(456, 24)
        Me.cmbLIBRO_CONTABLE.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(5, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Libro Contable :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(5, 54)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 16)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Cuenta Inicial:"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 167)
        Me.CrystalReportViewer1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(918, 285)
        Me.CrystalReportViewer1.TabIndex = 1
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'Contabilidad_Reportes_Auxiliar_Cuentas_Detallado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 466)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "Contabilidad_Reportes_Auxiliar_Cuentas_Detallado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auxiliar de Cuentas (Detallado)"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dpFecha_F As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnVerBC As System.Windows.Forms.Button
    Friend WithEvents dpFecha_I As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbLIBRO_CONTABLE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCONCEPTO_I As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaIni As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCuenta1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodDetalle As System.Windows.Forms.TextBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnBuscarCuenta2 As System.Windows.Forms.Button
    Friend WithEvents txtDesCtaFin As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentafin As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodDetalle2 As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscaDetalleFin As System.Windows.Forms.Button
    Friend WithEvents btnBuscaDetalleIni As System.Windows.Forms.Button
    Friend WithEvents txtDescDetalleIni As System.Windows.Forms.TextBox
    Friend WithEvents txtDescDetalleFin As System.Windows.Forms.TextBox
    Friend WithEvents chkNoAgruparCod As System.Windows.Forms.CheckBox
    Friend WithEvents chkSaldoCero As System.Windows.Forms.CheckBox
End Class
