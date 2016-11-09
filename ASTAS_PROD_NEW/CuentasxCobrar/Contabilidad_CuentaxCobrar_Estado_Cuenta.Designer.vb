<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_CuentaxCobrar_Estado_Cuenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilidad_CuentaxCobrar_Estado_Cuenta))
        Me.gbClienteCompañia = New System.Windows.Forms.GroupBox
        Me.chkCorteGrupo = New System.Windows.Forms.CheckBox
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.btnBuscarCliente = New System.Windows.Forms.Button
        Me.gbFiltro = New System.Windows.Forms.GroupBox
        Me.dpFECHA_HASTA = New System.Windows.Forms.DateTimePicker
        Me.dpFECHA_DESDE = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.crvEstadoCuenta = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.grbLiqRem = New System.Windows.Forms.GroupBox
        Me.dtpFechaLiq = New System.Windows.Forms.DateTimePicker
        Me.txtConcepto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtValorLiq = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAplicar = New System.Windows.Forms.Button
        Me.chkLiquidar = New System.Windows.Forms.CheckBox
        Me.gbClienteCompañia.SuspendLayout()
        Me.gbFiltro.SuspendLayout()
        Me.grbLiqRem.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbClienteCompañia
        '
        Me.gbClienteCompañia.Controls.Add(Me.chkCorteGrupo)
        Me.gbClienteCompañia.Controls.Add(Me.btnImprimir)
        Me.gbClienteCompañia.Controls.Add(Me.txtCliente)
        Me.gbClienteCompañia.Controls.Add(Me.btnBuscarCliente)
        Me.gbClienteCompañia.Controls.Add(Me.gbFiltro)
        Me.gbClienteCompañia.Controls.Add(Me.txtNombre)
        Me.gbClienteCompañia.Controls.Add(Me.Label8)
        Me.gbClienteCompañia.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbClienteCompañia.ForeColor = System.Drawing.Color.Navy
        Me.gbClienteCompañia.Location = New System.Drawing.Point(5, 10)
        Me.gbClienteCompañia.Name = "gbClienteCompañia"
        Me.gbClienteCompañia.Size = New System.Drawing.Size(550, 91)
        Me.gbClienteCompañia.TabIndex = 10
        Me.gbClienteCompañia.TabStop = False
        Me.gbClienteCompañia.Text = "Filtros"
        '
        'chkCorteGrupo
        '
        Me.chkCorteGrupo.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkCorteGrupo.Location = New System.Drawing.Point(422, 45)
        Me.chkCorteGrupo.Name = "chkCorteGrupo"
        Me.chkCorteGrupo.Size = New System.Drawing.Size(118, 40)
        Me.chkCorteGrupo.TabIndex = 44
        Me.chkCorteGrupo.Text = "Corte de Página Entre Clientes"
        Me.chkCorteGrupo.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkCorteGrupo.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(352, 42)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(64, 43)
        Me.btnImprimir.TabIndex = 43
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.Color.Navy
        Me.txtCliente.Location = New System.Drawing.Point(86, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(76, 22)
        Me.txtCliente.TabIndex = 38
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(163, 15)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarCliente.TabIndex = 37
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'gbFiltro
        '
        Me.gbFiltro.Controls.Add(Me.dpFECHA_HASTA)
        Me.gbFiltro.Controls.Add(Me.dpFECHA_DESDE)
        Me.gbFiltro.Controls.Add(Me.Label10)
        Me.gbFiltro.Controls.Add(Me.Label16)
        Me.gbFiltro.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFiltro.ForeColor = System.Drawing.Color.Navy
        Me.gbFiltro.Location = New System.Drawing.Point(7, 44)
        Me.gbFiltro.Name = "gbFiltro"
        Me.gbFiltro.Size = New System.Drawing.Size(335, 41)
        Me.gbFiltro.TabIndex = 42
        Me.gbFiltro.TabStop = False
        Me.gbFiltro.Text = "Fechas"
        '
        'dpFECHA_HASTA
        '
        Me.dpFECHA_HASTA.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_HASTA.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_HASTA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_HASTA.Location = New System.Drawing.Point(220, 13)
        Me.dpFECHA_HASTA.Name = "dpFECHA_HASTA"
        Me.dpFECHA_HASTA.Size = New System.Drawing.Size(104, 22)
        Me.dpFECHA_HASTA.TabIndex = 42
        '
        'dpFECHA_DESDE
        '
        Me.dpFECHA_DESDE.CustomFormat = "dd-MMM-yyyy"
        Me.dpFECHA_DESDE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpFECHA_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFECHA_DESDE.Location = New System.Drawing.Point(55, 15)
        Me.dpFECHA_DESDE.Name = "dpFECHA_DESDE"
        Me.dpFECHA_DESDE.Size = New System.Drawing.Size(104, 22)
        Me.dpFECHA_DESDE.TabIndex = 40
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(4, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 16)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Desde :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(169, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 16)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Hasta :"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtNombre.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Navy
        Me.txtNombre.Location = New System.Drawing.Point(189, 17)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombre.Size = New System.Drawing.Size(337, 22)
        Me.txtNombre.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(4, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 16)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Cliente :"
        '
        'crvEstadoCuenta
        '
        Me.crvEstadoCuenta.ActiveViewIndex = -1
        Me.crvEstadoCuenta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvEstadoCuenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crvEstadoCuenta.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvEstadoCuenta.DisplayGroupTree = False
        Me.crvEstadoCuenta.Location = New System.Drawing.Point(5, 109)
        Me.crvEstadoCuenta.Name = "crvEstadoCuenta"
        Me.crvEstadoCuenta.SelectionFormula = ""
        Me.crvEstadoCuenta.Size = New System.Drawing.Size(847, 472)
        Me.crvEstadoCuenta.TabIndex = 11
        Me.crvEstadoCuenta.ViewTimeSelectionFormula = ""
        '
        'grbLiqRem
        '
        Me.grbLiqRem.Controls.Add(Me.dtpFechaLiq)
        Me.grbLiqRem.Controls.Add(Me.txtConcepto)
        Me.grbLiqRem.Controls.Add(Me.Label2)
        Me.grbLiqRem.Controls.Add(Me.txtValorLiq)
        Me.grbLiqRem.Controls.Add(Me.Label1)
        Me.grbLiqRem.Controls.Add(Me.btnAplicar)
        Me.grbLiqRem.Enabled = False
        Me.grbLiqRem.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbLiqRem.ForeColor = System.Drawing.Color.Navy
        Me.grbLiqRem.Location = New System.Drawing.Point(561, 12)
        Me.grbLiqRem.Name = "grbLiqRem"
        Me.grbLiqRem.Size = New System.Drawing.Size(291, 89)
        Me.grbLiqRem.TabIndex = 12
        Me.grbLiqRem.TabStop = False
        Me.grbLiqRem.Text = "      Liquidación Remanente"
        '
        'dtpFechaLiq
        '
        Me.dtpFechaLiq.CustomFormat = "dd-MMM-yyyy"
        Me.dtpFechaLiq.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaLiq.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaLiq.Location = New System.Drawing.Point(134, 19)
        Me.dtpFechaLiq.Name = "dtpFechaLiq"
        Me.dtpFechaLiq.Size = New System.Drawing.Size(84, 22)
        Me.dtpFechaLiq.TabIndex = 43
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(75, 46)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(206, 37)
        Me.txtConcepto.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(10, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Concepto:"
        '
        'txtValorLiq
        '
        Me.txtValorLiq.Location = New System.Drawing.Point(75, 19)
        Me.txtValorLiq.Name = "txtValorLiq"
        Me.txtValorLiq.Size = New System.Drawing.Size(53, 22)
        Me.txtValorLiq.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "A Liquidar:"
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(224, 17)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(57, 25)
        Me.btnAplicar.TabIndex = 0
        Me.btnAplicar.Text = "Aplicar"
        Me.btnAplicar.UseVisualStyleBackColor = True
        '
        'chkLiquidar
        '
        Me.chkLiquidar.AutoSize = True
        Me.chkLiquidar.Location = New System.Drawing.Point(574, 14)
        Me.chkLiquidar.Name = "chkLiquidar"
        Me.chkLiquidar.Size = New System.Drawing.Size(15, 14)
        Me.chkLiquidar.TabIndex = 1
        Me.chkLiquidar.UseVisualStyleBackColor = True
        '
        'Contabilidad_CuentaxCobrar_Estado_Cuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 583)
        Me.Controls.Add(Me.chkLiquidar)
        Me.Controls.Add(Me.grbLiqRem)
        Me.Controls.Add(Me.crvEstadoCuenta)
        Me.Controls.Add(Me.gbClienteCompañia)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Contabilidad_CuentaxCobrar_Estado_Cuenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Cuentas por Cobrar - Consultas"
        Me.gbClienteCompañia.ResumeLayout(False)
        Me.gbClienteCompañia.PerformLayout()
        Me.gbFiltro.ResumeLayout(False)
        Me.gbFiltro.PerformLayout()
        Me.grbLiqRem.ResumeLayout(False)
        Me.grbLiqRem.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbClienteCompañia As System.Windows.Forms.GroupBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents dpFECHA_HASTA As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpFECHA_DESDE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents crvEstadoCuenta As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents chkCorteGrupo As System.Windows.Forms.CheckBox
    Friend WithEvents grbLiqRem As System.Windows.Forms.GroupBox
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents chkLiquidar As System.Windows.Forms.CheckBox
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtValorLiq As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaLiq As System.Windows.Forms.DateTimePicker
End Class
