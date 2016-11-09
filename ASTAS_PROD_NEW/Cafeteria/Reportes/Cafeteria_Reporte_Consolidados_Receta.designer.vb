<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cafeteria_Reporte_Consolidados_Receta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cafeteria_Reporte_Consolidados_Receta))
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbPlanta2 = New System.Windows.Forms.RadioButton
        Me.rbPlanta1 = New System.Windows.Forms.RadioButton
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.chkTodosLosTiempos = New System.Windows.Forms.CheckBox
        Me.cmbTiempo = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.fecha_hasta = New System.Windows.Forms.DateTimePicker
        Me.fecha_desde = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnNuevo = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 156)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1017, 344)
        Me.CrystalReportViewer1.TabIndex = 108
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.pbImagen)
        Me.GroupBox1.Controls.Add(Me.chkTodosLosTiempos)
        Me.GroupBox1.Controls.Add(Me.cmbTiempo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.fecha_hasta)
        Me.GroupBox1.Controls.Add(Me.fecha_desde)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1017, 156)
        Me.GroupBox1.TabIndex = 107
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles Genericos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbPlanta2)
        Me.GroupBox2.Controls.Add(Me.rbPlanta1)
        Me.GroupBox2.Location = New System.Drawing.Point(114, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(211, 40)
        Me.GroupBox2.TabIndex = 153
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione una Planta"
        '
        'rbPlanta2
        '
        Me.rbPlanta2.AutoSize = True
        Me.rbPlanta2.Location = New System.Drawing.Point(103, 13)
        Me.rbPlanta2.Name = "rbPlanta2"
        Me.rbPlanta2.Size = New System.Drawing.Size(78, 20)
        Me.rbPlanta2.TabIndex = 1
        Me.rbPlanta2.TabStop = True
        Me.rbPlanta2.Text = "Planta 2"
        Me.rbPlanta2.UseVisualStyleBackColor = True
        '
        'rbPlanta1
        '
        Me.rbPlanta1.AutoSize = True
        Me.rbPlanta1.Checked = True
        Me.rbPlanta1.Location = New System.Drawing.Point(7, 13)
        Me.rbPlanta1.Name = "rbPlanta1"
        Me.rbPlanta1.Size = New System.Drawing.Size(78, 20)
        Me.rbPlanta1.TabIndex = 0
        Me.rbPlanta1.TabStop = True
        Me.rbPlanta1.Text = "Planta 1"
        Me.rbPlanta1.UseVisualStyleBackColor = True
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(509, 13)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(133, 134)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 104
        Me.pbImagen.TabStop = False
        '
        'chkTodosLosTiempos
        '
        Me.chkTodosLosTiempos.AutoSize = True
        Me.chkTodosLosTiempos.Location = New System.Drawing.Point(362, 24)
        Me.chkTodosLosTiempos.Name = "chkTodosLosTiempos"
        Me.chkTodosLosTiempos.Size = New System.Drawing.Size(141, 20)
        Me.chkTodosLosTiempos.TabIndex = 135
        Me.chkTodosLosTiempos.Text = "Todos los tiempos"
        Me.chkTodosLosTiempos.UseVisualStyleBackColor = True
        '
        'cmbTiempo
        '
        Me.cmbTiempo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiempo.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiempo.ForeColor = System.Drawing.Color.Navy
        Me.cmbTiempo.FormattingEnabled = True
        Me.cmbTiempo.Location = New System.Drawing.Point(114, 21)
        Me.cmbTiempo.Name = "cmbTiempo"
        Me.cmbTiempo.Size = New System.Drawing.Size(230, 24)
        Me.cmbTiempo.TabIndex = 121
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(6, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Tiempo de Comida:"
        '
        'fecha_hasta
        '
        Me.fecha_hasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_hasta.Location = New System.Drawing.Point(232, 53)
        Me.fecha_hasta.Name = "fecha_hasta"
        Me.fecha_hasta.Size = New System.Drawing.Size(112, 22)
        Me.fecha_hasta.TabIndex = 1
        '
        'fecha_desde
        '
        Me.fecha_desde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_desde.Location = New System.Drawing.Point(114, 53)
        Me.fecha_desde.Name = "fecha_desde"
        Me.fecha_desde.Size = New System.Drawing.Size(112, 22)
        Me.fecha_desde.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 16)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Periodo :"
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(362, 64)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 60)
        Me.btnNuevo.TabIndex = 2
        Me.btnNuevo.Text = "&Imprimir"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Cafeteria_Reporte_Consolidados_Receta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1017, 500)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Cafeteria_Reporte_Consolidados_Receta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cafeteria_Reporte_Consolidados_Receta"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPlanta2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbPlanta1 As System.Windows.Forms.RadioButton
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents chkTodosLosTiempos As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTiempo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents fecha_hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha_desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
End Class
