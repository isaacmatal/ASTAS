<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecibirBuxis
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecibirBuxis))
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.dpFechaPago = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.pbAplicar = New System.Windows.Forms.ProgressBar
        Me.btnReporte = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbMensual = New System.Windows.Forms.RadioButton
        Me.rbQna = New System.Windows.Forms.RadioButton
        Me.bw1 = New System.ComponentModel.BackgroundWorker
        Me.lblPdas = New System.Windows.Forms.Label
        Me.txtTransaccionInicial = New System.Windows.Forms.TextBox
        Me.txtTransaccionFinal = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPdaDeuda = New System.Windows.Forms.TextBox
        Me.txtPdaAh = New System.Windows.Forms.TextBox
        Me.txtPdaInt = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.BackColor = System.Drawing.Color.Transparent
        Me.btnProcesar.Image = Global.AstasConta.My.Resources.Resources.exec
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(439, 17)
        Me.btnProcesar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 36)
        Me.btnProcesar.TabIndex = 1
        Me.btnProcesar.Text = "&Generar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProcesar.UseVisualStyleBackColor = False
        '
        'dpFechaPago
        '
        Me.dpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaPago.Location = New System.Drawing.Point(114, 25)
        Me.dpFechaPago.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dpFechaPago.Name = "dpFechaPago"
        Me.dpFechaPago.Size = New System.Drawing.Size(101, 22)
        Me.dpFechaPago.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Periodo de Pago:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(228, 198)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Procesando..."
        Me.Label2.Visible = False
        '
        'pbAplicar
        '
        Me.pbAplicar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbAplicar.Location = New System.Drawing.Point(232, 223)
        Me.pbAplicar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbAplicar.Name = "pbAplicar"
        Me.pbAplicar.Size = New System.Drawing.Size(363, 18)
        Me.pbAplicar.Step = 1
        Me.pbAplicar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbAplicar.TabIndex = 5
        Me.pbAplicar.Visible = False
        '
        'btnReporte
        '
        Me.btnReporte.BackColor = System.Drawing.Color.Transparent
        Me.btnReporte.Image = Global.AstasConta.My.Resources.Resources.fileprint
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(520, 18)
        Me.btnReporte.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(75, 36)
        Me.btnReporte.TabIndex = 6
        Me.btnReporte.Text = "Imprimir"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReporte.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rbMensual)
        Me.GroupBox1.Controls.Add(Me.rbQna)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(232, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(160, 44)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo Periodo"
        Me.GroupBox1.Visible = False
        '
        'rbMensual
        '
        Me.rbMensual.AutoSize = True
        Me.rbMensual.Location = New System.Drawing.Point(87, 18)
        Me.rbMensual.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbMensual.Name = "rbMensual"
        Me.rbMensual.Size = New System.Drawing.Size(73, 20)
        Me.rbMensual.TabIndex = 1
        Me.rbMensual.TabStop = True
        Me.rbMensual.Text = "Mensual"
        Me.rbMensual.UseVisualStyleBackColor = True
        '
        'rbQna
        '
        Me.rbQna.AutoSize = True
        Me.rbQna.Checked = True
        Me.rbQna.Location = New System.Drawing.Point(7, 18)
        Me.rbQna.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbQna.Name = "rbQna"
        Me.rbQna.Size = New System.Drawing.Size(82, 20)
        Me.rbQna.TabIndex = 0
        Me.rbQna.TabStop = True
        Me.rbQna.Text = "Quincenal"
        Me.rbQna.UseVisualStyleBackColor = True
        '
        'bw1
        '
        Me.bw1.WorkerReportsProgress = True
        Me.bw1.WorkerSupportsCancellation = True
        '
        'lblPdas
        '
        Me.lblPdas.AutoSize = True
        Me.lblPdas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPdas.ForeColor = System.Drawing.Color.Navy
        Me.lblPdas.Location = New System.Drawing.Point(8, 25)
        Me.lblPdas.Name = "lblPdas"
        Me.lblPdas.Size = New System.Drawing.Size(141, 16)
        Me.lblPdas.TabIndex = 1
        Me.lblPdas.Text = "Partidas Reservadas:"
        '
        'txtTransaccionInicial
        '
        Me.txtTransaccionInicial.Font = New System.Drawing.Font("Modern No. 20", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransaccionInicial.Location = New System.Drawing.Point(-1, 0)
        Me.txtTransaccionInicial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTransaccionInicial.Name = "txtTransaccionInicial"
        Me.txtTransaccionInicial.Size = New System.Drawing.Size(42, 19)
        Me.txtTransaccionInicial.TabIndex = 9
        Me.txtTransaccionInicial.Visible = False
        '
        'txtTransaccionFinal
        '
        Me.txtTransaccionFinal.Font = New System.Drawing.Font("Modern No. 20", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransaccionFinal.Location = New System.Drawing.Point(47, 0)
        Me.txtTransaccionFinal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTransaccionFinal.Name = "txtTransaccionFinal"
        Me.txtTransaccionFinal.Size = New System.Drawing.Size(39, 19)
        Me.txtTransaccionFinal.TabIndex = 10
        Me.txtTransaccionFinal.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(8, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Deudas:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(8, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Ahorros:"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(8, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 55)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Intereses y Seguro Deuda:"
        '
        'txtPdaDeuda
        '
        Me.txtPdaDeuda.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPdaDeuda.Location = New System.Drawing.Point(92, 79)
        Me.txtPdaDeuda.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPdaDeuda.Name = "txtPdaDeuda"
        Me.txtPdaDeuda.Size = New System.Drawing.Size(72, 20)
        Me.txtPdaDeuda.TabIndex = 0
        Me.txtPdaDeuda.WordWrap = False
        '
        'txtPdaAh
        '
        Me.txtPdaAh.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPdaAh.Location = New System.Drawing.Point(92, 111)
        Me.txtPdaAh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPdaAh.Name = "txtPdaAh"
        Me.txtPdaAh.Size = New System.Drawing.Size(72, 20)
        Me.txtPdaAh.TabIndex = 15
        Me.txtPdaAh.WordWrap = False
        '
        'txtPdaInt
        '
        Me.txtPdaInt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPdaInt.Location = New System.Drawing.Point(92, 143)
        Me.txtPdaInt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPdaInt.Name = "txtPdaInt"
        Me.txtPdaInt.Size = New System.Drawing.Size(72, 20)
        Me.txtPdaInt.TabIndex = 16
        Me.txtPdaInt.WordWrap = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(8, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Conceptos:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(97, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 14)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "No.Partida:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.lblPdas)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtPdaInt)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtPdaAh)
        Me.GroupBox2.Controls.Add(Me.txtPdaDeuda)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 55)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(200, 194)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(232, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(358, 56)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Si NO se define un número de partida para algún " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "concepto, entonces se generará " & _
            "un número de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "partida automáticamente para ese concepto."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmRecibirBuxis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 256)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtTransaccionFinal)
        Me.Controls.Add(Me.txtTransaccionInicial)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.pbAplicar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dpFechaPago)
        Me.Controls.Add(Me.btnProcesar)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmRecibirBuxis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Partida aplicación descuentos (BUXIS)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents dpFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbAplicar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMensual As System.Windows.Forms.RadioButton
    Friend WithEvents rbQna As System.Windows.Forms.RadioButton
    Friend WithEvents bw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblPdas As System.Windows.Forms.Label
    Friend WithEvents txtTransaccionInicial As System.Windows.Forms.TextBox
    Friend WithEvents txtTransaccionFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPdaDeuda As System.Windows.Forms.TextBox
    Friend WithEvents txtPdaAh As System.Windows.Forms.TextBox
    Friend WithEvents txtPdaInt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
