<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Reportes_Saldos_Cuentas_Detallado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_Reportes_Saldos_Cuentas_Detallado))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkNoSaldoCero = New System.Windows.Forms.CheckBox
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
        Me.btnVerBC = New System.Windows.Forms.Button
        Me.dpFecha_I = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbLIBRO_CONTABLE = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.dpFecha = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(765, 2)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(110, 174)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 110
        Me.pbImagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dpFecha)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkNoSaldoCero)
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
        Me.GroupBox1.Controls.Add(Me.btnVerBC)
        Me.GroupBox1.Controls.Add(Me.dpFecha_I)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cmbLIBRO_CONTABLE)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(12, 1)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(747, 175)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        '
        'chkNoSaldoCero
        '
        Me.chkNoSaldoCero.AutoSize = True
        Me.chkNoSaldoCero.Checked = True
        Me.chkNoSaldoCero.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoSaldoCero.Location = New System.Drawing.Point(584, 146)
        Me.chkNoSaldoCero.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkNoSaldoCero.Name = "chkNoSaldoCero"
        Me.chkNoSaldoCero.Size = New System.Drawing.Size(147, 20)
        Me.chkNoSaldoCero.TabIndex = 129
        Me.chkNoSaldoCero.Text = "No Mostrar Saldo Cero"
        Me.chkNoSaldoCero.UseVisualStyleBackColor = True
        '
        'txtDescDetalleFin
        '
        Me.txtDescDetalleFin.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescDetalleFin.Enabled = False
        Me.txtDescDetalleFin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescDetalleFin.ForeColor = System.Drawing.Color.Navy
        Me.txtDescDetalleFin.Location = New System.Drawing.Point(234, 141)
        Me.txtDescDetalleFin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDescDetalleFin.MaxLength = 100
        Me.txtDescDetalleFin.Name = "txtDescDetalleFin"
        Me.txtDescDetalleFin.ReadOnly = True
        Me.txtDescDetalleFin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescDetalleFin.Size = New System.Drawing.Size(336, 22)
        Me.txtDescDetalleFin.TabIndex = 128
        '
        'txtDescDetalleIni
        '
        Me.txtDescDetalleIni.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescDetalleIni.Enabled = False
        Me.txtDescDetalleIni.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescDetalleIni.ForeColor = System.Drawing.Color.Navy
        Me.txtDescDetalleIni.Location = New System.Drawing.Point(234, 79)
        Me.txtDescDetalleIni.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDescDetalleIni.MaxLength = 100
        Me.txtDescDetalleIni.Name = "txtDescDetalleIni"
        Me.txtDescDetalleIni.ReadOnly = True
        Me.txtDescDetalleIni.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescDetalleIni.Size = New System.Drawing.Size(336, 22)
        Me.txtDescDetalleIni.TabIndex = 127
        '
        'btnBuscaDetalleFin
        '
        Me.btnBuscaDetalleFin.Image = CType(resources.GetObject("btnBuscaDetalleFin.Image"), System.Drawing.Image)
        Me.btnBuscaDetalleFin.Location = New System.Drawing.Point(209, 140)
        Me.btnBuscaDetalleFin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBuscaDetalleFin.Name = "btnBuscaDetalleFin"
        Me.btnBuscaDetalleFin.Size = New System.Drawing.Size(24, 26)
        Me.btnBuscaDetalleFin.TabIndex = 126
        Me.btnBuscaDetalleFin.UseVisualStyleBackColor = True
        '
        'btnBuscaDetalleIni
        '
        Me.btnBuscaDetalleIni.Image = CType(resources.GetObject("btnBuscaDetalleIni.Image"), System.Drawing.Image)
        Me.btnBuscaDetalleIni.Location = New System.Drawing.Point(209, 78)
        Me.btnBuscaDetalleIni.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBuscaDetalleIni.Name = "btnBuscaDetalleIni"
        Me.btnBuscaDetalleIni.Size = New System.Drawing.Size(24, 26)
        Me.btnBuscaDetalleIni.TabIndex = 125
        Me.btnBuscaDetalleIni.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(5, 146)
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
        Me.txtCodDetalle2.Location = New System.Drawing.Point(114, 142)
        Me.txtCodDetalle2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodDetalle2.Name = "txtCodDetalle2"
        Me.txtCodDetalle2.Size = New System.Drawing.Size(93, 22)
        Me.txtCodDetalle2.TabIndex = 3
        Me.txtCodDetalle2.Text = "0"
        '
        'btnBuscarCuenta2
        '
        Me.btnBuscarCuenta2.Image = CType(resources.GetObject("btnBuscarCuenta2.Image"), System.Drawing.Image)
        Me.btnBuscarCuenta2.Location = New System.Drawing.Point(210, 108)
        Me.btnBuscarCuenta2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
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
        Me.txtDesCtaFin.Location = New System.Drawing.Point(235, 110)
        Me.txtDesCtaFin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDesCtaFin.MaxLength = 100
        Me.txtDesCtaFin.Name = "txtDesCtaFin"
        Me.txtDesCtaFin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDesCtaFin.Size = New System.Drawing.Size(336, 22)
        Me.txtDesCtaFin.TabIndex = 10
        '
        'txtCuentafin
        '
        Me.txtCuentafin.BackColor = System.Drawing.Color.White
        Me.txtCuentafin.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentafin.ForeColor = System.Drawing.Color.Navy
        Me.txtCuentafin.Location = New System.Drawing.Point(114, 111)
        Me.txtCuentafin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCuentafin.Name = "txtCuentafin"
        Me.txtCuentafin.Size = New System.Drawing.Size(93, 22)
        Me.txtCuentafin.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(6, 114)
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
        Me.Label1.Location = New System.Drawing.Point(5, 83)
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
        Me.txtCodDetalle.Location = New System.Drawing.Point(114, 79)
        Me.txtCodDetalle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCodDetalle.Name = "txtCodDetalle"
        Me.txtCodDetalle.Size = New System.Drawing.Size(93, 22)
        Me.txtCodDetalle.TabIndex = 1
        Me.txtCodDetalle.Text = "0"
        '
        'btnBuscarCuenta1
        '
        Me.btnBuscarCuenta1.Image = CType(resources.GetObject("btnBuscarCuenta1.Image"), System.Drawing.Image)
        Me.btnBuscarCuenta1.Location = New System.Drawing.Point(209, 46)
        Me.btnBuscarCuenta1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
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
        Me.txtCONCEPTO_I.Location = New System.Drawing.Point(234, 48)
        Me.txtCONCEPTO_I.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCONCEPTO_I.MaxLength = 100
        Me.txtCONCEPTO_I.Name = "txtCONCEPTO_I"
        Me.txtCONCEPTO_I.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCONCEPTO_I.Size = New System.Drawing.Size(336, 22)
        Me.txtCONCEPTO_I.TabIndex = 9
        '
        'txtCuentaIni
        '
        Me.txtCuentaIni.BackColor = System.Drawing.Color.White
        Me.txtCuentaIni.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaIni.ForeColor = System.Drawing.Color.Navy
        Me.txtCuentaIni.Location = New System.Drawing.Point(114, 49)
        Me.txtCuentaIni.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCuentaIni.Name = "txtCuentaIni"
        Me.txtCuentaIni.Size = New System.Drawing.Size(93, 22)
        Me.txtCuentaIni.TabIndex = 0
        '
        'btnVerBC
        '
        Me.btnVerBC.Image = Global.AstasConta.My.Resources.Resources.exec
        Me.btnVerBC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerBC.Location = New System.Drawing.Point(611, 18)
        Me.btnVerBC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnVerBC.Name = "btnVerBC"
        Me.btnVerBC.Size = New System.Drawing.Size(120, 30)
        Me.btnVerBC.TabIndex = 6
        Me.btnVerBC.Text = "Generar Reporte"
        Me.btnVerBC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerBC.UseVisualStyleBackColor = True
        '
        'dpFecha_I
        '
        Me.dpFecha_I.CustomFormat = "dd-MMM-yyyy"
        Me.dpFecha_I.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFecha_I.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha_I.Location = New System.Drawing.Point(627, 104)
        Me.dpFecha_I.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFecha_I.Name = "dpFecha_I"
        Me.dpFecha_I.Size = New System.Drawing.Size(104, 22)
        Me.dpFecha_I.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(581, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 16)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Hasta:"
        '
        'cmbLIBRO_CONTABLE
        '
        Me.cmbLIBRO_CONTABLE.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLIBRO_CONTABLE.Enabled = False
        Me.cmbLIBRO_CONTABLE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLIBRO_CONTABLE.ForeColor = System.Drawing.Color.Navy
        Me.cmbLIBRO_CONTABLE.FormattingEnabled = True
        Me.cmbLIBRO_CONTABLE.Location = New System.Drawing.Point(114, 17)
        Me.cmbLIBRO_CONTABLE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbLIBRO_CONTABLE.Name = "cmbLIBRO_CONTABLE"
        Me.cmbLIBRO_CONTABLE.Size = New System.Drawing.Size(456, 24)
        Me.cmbLIBRO_CONTABLE.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(5, 18)
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
        Me.Label4.Location = New System.Drawing.Point(5, 53)
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
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 184)
        Me.CrystalReportViewer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(863, 268)
        Me.CrystalReportViewer1.TabIndex = 111
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'dpFecha
        '
        Me.dpFecha.CustomFormat = "dd-MMM-yyyy"
        Me.dpFecha.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha.Location = New System.Drawing.Point(627, 66)
        Me.dpFecha.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(104, 22)
        Me.dpFecha.TabIndex = 130
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(581, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Desde:"
        '
        'Contabilidad_Reportes_Saldos_Cuentas_Detallado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 466)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_Reportes_Saldos_Cuentas_Detallado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saldos de Cuentas (Detallado)"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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
    Friend WithEvents txtDescDetalleFin As System.Windows.Forms.TextBox
    Friend WithEvents txtDescDetalleIni As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscaDetalleFin As System.Windows.Forms.Button
    Friend WithEvents btnBuscaDetalleIni As System.Windows.Forms.Button
    Friend WithEvents chkNoSaldoCero As System.Windows.Forms.CheckBox
    Friend WithEvents dpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
