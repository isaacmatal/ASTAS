<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCooperativaReporteSaldosUltPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCooperativaReporteSaldosUltPago))
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkFecha = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbTipoSolic = New System.Windows.Forms.ComboBox
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox
        Me.dpFecha = New System.Windows.Forms.DateTimePicker
        Me.BtnReporte = New System.Windows.Forms.Button
        Me.pbTabla = New System.Windows.Forms.ProgressBar
        Me.bwTabla = New System.ComponentModel.BackgroundWorker
        Me.bwAvance = New System.ComponentModel.BackgroundWorker
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(628, 10)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(152, 210)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 135
        Me.pbImagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkFecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbTipoSolic)
        Me.GroupBox1.Controls.Add(Me.cmbEmpresa)
        Me.GroupBox1.Controls.Add(Me.dpFecha)
        Me.GroupBox1.Controls.Add(Me.BtnReporte)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(595, 210)
        Me.GroupBox1.TabIndex = 134
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cartera de Socios por Deducciones"
        '
        'chkFecha
        '
        Me.chkFecha.AutoSize = True
        Me.chkFecha.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.chkFecha.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkFecha.Location = New System.Drawing.Point(31, 46)
        Me.chkFecha.Name = "chkFecha"
        Me.chkFecha.Size = New System.Drawing.Size(234, 20)
        Me.chkFecha.TabIndex = 123
        Me.chkFecha.Text = "Con �ltima fecha descuento menor o igual a:"
        Me.chkFecha.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(28, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Tipo Solicitud:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(28, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Empresa:"
        '
        'cmbTipoSolic
        '
        Me.cmbTipoSolic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoSolic.FormattingEnabled = True
        Me.cmbTipoSolic.Location = New System.Drawing.Point(113, 130)
        Me.cmbTipoSolic.Name = "cmbTipoSolic"
        Me.cmbTipoSolic.Size = New System.Drawing.Size(249, 24)
        Me.cmbTipoSolic.TabIndex = 120
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(113, 87)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(249, 24)
        Me.cmbEmpresa.TabIndex = 119
        '
        'dpFecha
        '
        Me.dpFecha.Enabled = False
        Me.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFecha.Location = New System.Drawing.Point(267, 46)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(95, 22)
        Me.dpFecha.TabIndex = 2
        '
        'BtnReporte
        '
        Me.BtnReporte.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.BtnReporte.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnReporte.Image = CType(resources.GetObject("BtnReporte.Image"), System.Drawing.Image)
        Me.BtnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnReporte.Location = New System.Drawing.Point(488, 79)
        Me.BtnReporte.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnReporte.Name = "BtnReporte"
        Me.BtnReporte.Size = New System.Drawing.Size(72, 45)
        Me.BtnReporte.TabIndex = 4
        Me.BtnReporte.Text = "Imprimir"
        Me.BtnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnReporte.UseVisualStyleBackColor = True
        '
        'pbTabla
        '
        Me.pbTabla.Location = New System.Drawing.Point(8, 228)
        Me.pbTabla.Name = "pbTabla"
        Me.pbTabla.Size = New System.Drawing.Size(772, 23)
        Me.pbTabla.TabIndex = 136
        Me.pbTabla.Visible = False
        '
        'bwTabla
        '
        Me.bwTabla.WorkerReportsProgress = True
        '
        'bwAvance
        '
        Me.bwAvance.WorkerReportsProgress = True
        '
        'FrmCooperativaReporteSaldosUltPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 255)
        Me.Controls.Add(Me.pbTabla)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmCooperativaReporteSaldosUltPago"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa - Reporte Saldos Deudas"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnReporte As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoSolic As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents pbTabla As System.Windows.Forms.ProgressBar
    Friend WithEvents bwTabla As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwAvance As System.ComponentModel.BackgroundWorker
    Friend WithEvents chkFecha As System.Windows.Forms.CheckBox
End Class
