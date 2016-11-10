<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilidad_Partidas_Cierre_Anual
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.NudYear = New System.Windows.Forms.NumericUpDown
        Me.btnIngr = New System.Windows.Forms.Button
        Me.btnOtrosIng = New System.Windows.Forms.Button
        Me.btnCostos = New System.Windows.Forms.Button
        Me.btnGastos = New System.Windows.Forms.Button
        Me.btnCierre = New System.Windows.Forms.Button
        Me.btnApertura = New System.Windows.Forms.Button
        Me.grpPdas = New System.Windows.Forms.GroupBox
        Me.txtPdaAper = New System.Windows.Forms.TextBox
        Me.txtPdaAnual = New System.Windows.Forms.TextBox
        Me.txtGastos = New System.Windows.Forms.TextBox
        Me.txtPdaCostos = New System.Windows.Forms.TextBox
        Me.txtPdaOtrIngr = New System.Windows.Forms.TextBox
        Me.txtPdaIng = New System.Windows.Forms.TextBox
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.bwCierres = New System.ComponentModel.BackgroundWorker
        Me.bwApertura = New System.ComponentModel.BackgroundWorker
        Me.PB1 = New System.Windows.Forms.ProgressBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnBalanceGral = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.bwPartidasRPT = New System.ComponentModel.BackgroundWorker
        Me.bwBalanceRPT = New System.ComponentModel.BackgroundWorker
        Me.grpTipoBalance = New System.Windows.Forms.GroupBox
        Me.rbCuenta = New System.Windows.Forms.RadioButton
        Me.rbReporte = New System.Windows.Forms.RadioButton
        Me.bwAvance = New System.ComponentModel.BackgroundWorker
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPdas.SuspendLayout()
        Me.grpTipoBalance.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Año Cierre Ejercicio:"
        '
        'NudYear
        '
        Me.NudYear.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudYear.ForeColor = System.Drawing.Color.DarkRed
        Me.NudYear.Location = New System.Drawing.Point(202, 17)
        Me.NudYear.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NudYear.Name = "NudYear"
        Me.NudYear.Size = New System.Drawing.Size(71, 32)
        Me.NudYear.TabIndex = 1
        Me.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnIngr
        '
        Me.btnIngr.Location = New System.Drawing.Point(8, 33)
        Me.btnIngr.Name = "btnIngr"
        Me.btnIngr.Size = New System.Drawing.Size(80, 59)
        Me.btnIngr.TabIndex = 2
        Me.btnIngr.Text = "Liquidación Ingresos"
        Me.btnIngr.UseVisualStyleBackColor = True
        '
        'btnOtrosIng
        '
        Me.btnOtrosIng.Location = New System.Drawing.Point(101, 33)
        Me.btnOtrosIng.Name = "btnOtrosIng"
        Me.btnOtrosIng.Size = New System.Drawing.Size(80, 59)
        Me.btnOtrosIng.TabIndex = 3
        Me.btnOtrosIng.Text = "Liquidación Otros Ingresos"
        Me.btnOtrosIng.UseVisualStyleBackColor = True
        '
        'btnCostos
        '
        Me.btnCostos.Location = New System.Drawing.Point(194, 33)
        Me.btnCostos.Name = "btnCostos"
        Me.btnCostos.Size = New System.Drawing.Size(80, 59)
        Me.btnCostos.TabIndex = 4
        Me.btnCostos.Text = "Liquidación Costos"
        Me.btnCostos.UseVisualStyleBackColor = True
        '
        'btnGastos
        '
        Me.btnGastos.Location = New System.Drawing.Point(287, 33)
        Me.btnGastos.Name = "btnGastos"
        Me.btnGastos.Size = New System.Drawing.Size(80, 59)
        Me.btnGastos.TabIndex = 5
        Me.btnGastos.Text = "Liquidación Gastos"
        Me.btnGastos.UseVisualStyleBackColor = True
        '
        'btnCierre
        '
        Me.btnCierre.Location = New System.Drawing.Point(380, 33)
        Me.btnCierre.Name = "btnCierre"
        Me.btnCierre.Size = New System.Drawing.Size(80, 59)
        Me.btnCierre.TabIndex = 6
        Me.btnCierre.Text = "Cierre Anual Ejercicio Corriente"
        Me.btnCierre.UseVisualStyleBackColor = True
        '
        'btnApertura
        '
        Me.btnApertura.Location = New System.Drawing.Point(473, 33)
        Me.btnApertura.Name = "btnApertura"
        Me.btnApertura.Size = New System.Drawing.Size(80, 59)
        Me.btnApertura.TabIndex = 7
        Me.btnApertura.Text = "Apertura Siguiente Ejercicio"
        Me.btnApertura.UseVisualStyleBackColor = True
        '
        'grpPdas
        '
        Me.grpPdas.BackColor = System.Drawing.Color.Transparent
        Me.grpPdas.Controls.Add(Me.txtPdaAper)
        Me.grpPdas.Controls.Add(Me.txtPdaAnual)
        Me.grpPdas.Controls.Add(Me.txtGastos)
        Me.grpPdas.Controls.Add(Me.txtPdaCostos)
        Me.grpPdas.Controls.Add(Me.txtPdaOtrIngr)
        Me.grpPdas.Controls.Add(Me.txtPdaIng)
        Me.grpPdas.Controls.Add(Me.btnApertura)
        Me.grpPdas.Controls.Add(Me.btnIngr)
        Me.grpPdas.Controls.Add(Me.btnCierre)
        Me.grpPdas.Controls.Add(Me.btnOtrosIng)
        Me.grpPdas.Controls.Add(Me.btnGastos)
        Me.grpPdas.Controls.Add(Me.btnCostos)
        Me.grpPdas.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPdas.ForeColor = System.Drawing.Color.Navy
        Me.grpPdas.Location = New System.Drawing.Point(8, 82)
        Me.grpPdas.Name = "grpPdas"
        Me.grpPdas.Size = New System.Drawing.Size(563, 140)
        Me.grpPdas.TabIndex = 8
        Me.grpPdas.TabStop = False
        Me.grpPdas.Text = "Generación de Partidas"
        '
        'txtPdaAper
        '
        Me.txtPdaAper.Location = New System.Drawing.Point(480, 100)
        Me.txtPdaAper.Name = "txtPdaAper"
        Me.txtPdaAper.Size = New System.Drawing.Size(65, 22)
        Me.txtPdaAper.TabIndex = 13
        '
        'txtPdaAnual
        '
        Me.txtPdaAnual.Location = New System.Drawing.Point(387, 100)
        Me.txtPdaAnual.Name = "txtPdaAnual"
        Me.txtPdaAnual.Size = New System.Drawing.Size(65, 22)
        Me.txtPdaAnual.TabIndex = 12
        '
        'txtGastos
        '
        Me.txtGastos.Location = New System.Drawing.Point(294, 100)
        Me.txtGastos.Name = "txtGastos"
        Me.txtGastos.Size = New System.Drawing.Size(65, 22)
        Me.txtGastos.TabIndex = 11
        '
        'txtPdaCostos
        '
        Me.txtPdaCostos.Location = New System.Drawing.Point(201, 100)
        Me.txtPdaCostos.Name = "txtPdaCostos"
        Me.txtPdaCostos.Size = New System.Drawing.Size(65, 22)
        Me.txtPdaCostos.TabIndex = 10
        '
        'txtPdaOtrIngr
        '
        Me.txtPdaOtrIngr.Location = New System.Drawing.Point(108, 100)
        Me.txtPdaOtrIngr.Name = "txtPdaOtrIngr"
        Me.txtPdaOtrIngr.Size = New System.Drawing.Size(65, 22)
        Me.txtPdaOtrIngr.TabIndex = 9
        '
        'txtPdaIng
        '
        Me.txtPdaIng.Location = New System.Drawing.Point(15, 100)
        Me.txtPdaIng.Name = "txtPdaIng"
        Me.txtPdaIng.Size = New System.Drawing.Size(65, 22)
        Me.txtPdaIng.TabIndex = 8
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.ForeColor = System.Drawing.Color.Navy
        Me.btnImprimir.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(17, 242)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(79, 65)
        Me.btnImprimir.TabIndex = 9
        Me.btnImprimir.Text = "Imprimir" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Partidas"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'bwCierres
        '
        Me.bwCierres.WorkerReportsProgress = True
        Me.bwCierres.WorkerSupportsCancellation = True
        '
        'bwApertura
        '
        Me.bwApertura.WorkerReportsProgress = True
        Me.bwApertura.WorkerSupportsCancellation = True
        '
        'PB1
        '
        Me.PB1.Location = New System.Drawing.Point(8, 59)
        Me.PB1.Name = "PB1"
        Me.PB1.Size = New System.Drawing.Size(563, 19)
        Me.PB1.TabIndex = 10
        Me.PB1.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(279, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(292, 50)
        Me.Label2.TabIndex = 11
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBalanceGral
        '
        Me.btnBalanceGral.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBalanceGral.ForeColor = System.Drawing.Color.Navy
        Me.btnBalanceGral.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.btnBalanceGral.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBalanceGral.Location = New System.Drawing.Point(109, 242)
        Me.btnBalanceGral.Name = "btnBalanceGral"
        Me.btnBalanceGral.Size = New System.Drawing.Size(80, 65)
        Me.btnBalanceGral.TabIndex = 12
        Me.btnBalanceGral.Text = "Balance" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "General"
        Me.btnBalanceGral.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBalanceGral.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'bwPartidasRPT
        '
        '
        'bwBalanceRPT
        '
        '
        'grpTipoBalance
        '
        Me.grpTipoBalance.BackColor = System.Drawing.Color.Transparent
        Me.grpTipoBalance.Controls.Add(Me.rbCuenta)
        Me.grpTipoBalance.Controls.Add(Me.rbReporte)
        Me.grpTipoBalance.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTipoBalance.ForeColor = System.Drawing.Color.Navy
        Me.grpTipoBalance.Location = New System.Drawing.Point(195, 228)
        Me.grpTipoBalance.Name = "grpTipoBalance"
        Me.grpTipoBalance.Size = New System.Drawing.Size(87, 79)
        Me.grpTipoBalance.TabIndex = 13
        Me.grpTipoBalance.TabStop = False
        Me.grpTipoBalance.Text = "Formato"
        '
        'rbCuenta
        '
        Me.rbCuenta.AutoSize = True
        Me.rbCuenta.Location = New System.Drawing.Point(6, 47)
        Me.rbCuenta.Name = "rbCuenta"
        Me.rbCuenta.Size = New System.Drawing.Size(64, 20)
        Me.rbCuenta.TabIndex = 1
        Me.rbCuenta.Text = "Cuenta"
        Me.rbCuenta.UseVisualStyleBackColor = True
        '
        'rbReporte
        '
        Me.rbReporte.AutoSize = True
        Me.rbReporte.Checked = True
        Me.rbReporte.Location = New System.Drawing.Point(7, 21)
        Me.rbReporte.Name = "rbReporte"
        Me.rbReporte.Size = New System.Drawing.Size(68, 20)
        Me.rbReporte.TabIndex = 0
        Me.rbReporte.TabStop = True
        Me.rbReporte.Text = "Reporte"
        Me.rbReporte.UseVisualStyleBackColor = True
        '
        'bwAvance
        '
        Me.bwAvance.WorkerReportsProgress = True
        Me.bwAvance.WorkerSupportsCancellation = True
        '
        'Contabilidad_Partidas_Cierre_Anual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 313)
        Me.Controls.Add(Me.grpTipoBalance)
        Me.Controls.Add(Me.btnBalanceGral)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PB1)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.grpPdas)
        Me.Controls.Add(Me.NudYear)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Contabilidad_Partidas_Cierre_Anual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Partidas Cierre Anual"
        CType(Me.NudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPdas.ResumeLayout(False)
        Me.grpPdas.PerformLayout()
        Me.grpTipoBalance.ResumeLayout(False)
        Me.grpTipoBalance.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NudYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnIngr As System.Windows.Forms.Button
    Friend WithEvents btnOtrosIng As System.Windows.Forms.Button
    Friend WithEvents btnCostos As System.Windows.Forms.Button
    Friend WithEvents btnGastos As System.Windows.Forms.Button
    Friend WithEvents btnCierre As System.Windows.Forms.Button
    Friend WithEvents btnApertura As System.Windows.Forms.Button
    Friend WithEvents grpPdas As System.Windows.Forms.GroupBox
    Friend WithEvents txtPdaIng As System.Windows.Forms.TextBox
    Friend WithEvents txtPdaCostos As System.Windows.Forms.TextBox
    Friend WithEvents txtPdaOtrIngr As System.Windows.Forms.TextBox
    Friend WithEvents txtPdaAper As System.Windows.Forms.TextBox
    Friend WithEvents txtPdaAnual As System.Windows.Forms.TextBox
    Friend WithEvents txtGastos As System.Windows.Forms.TextBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents bwCierres As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwApertura As System.ComponentModel.BackgroundWorker
    Friend WithEvents PB1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBalanceGral As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents bwPartidasRPT As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwBalanceRPT As System.ComponentModel.BackgroundWorker
    Friend WithEvents grpTipoBalance As System.Windows.Forms.GroupBox
    Friend WithEvents rbCuenta As System.Windows.Forms.RadioButton
    Friend WithEvents rbReporte As System.Windows.Forms.RadioButton
    Friend WithEvents bwAvance As System.ComponentModel.BackgroundWorker
End Class
