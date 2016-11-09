<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CooperativaReporteResumenDeudasProgramadas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pbImagen = New System.Windows.Forms.PictureBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvRubros = New System.Windows.Forms.DataGridView
        Me.SELECCIONAR = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.allRubros = New System.Windows.Forms.CheckBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.radQuincenal = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.radTodas = New System.Windows.Forms.RadioButton
        Me.radEspecial = New System.Windows.Forms.RadioButton
        Me.radMensual = New System.Windows.Forms.RadioButton
        Me.lblNombre = New System.Windows.Forms.Label
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DEDUCCION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DESCRIPCION_DEDUCCION = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvRubros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbImagen
        '
        Me.pbImagen.BackColor = System.Drawing.Color.Transparent
        Me.pbImagen.Location = New System.Drawing.Point(531, 46)
        Me.pbImagen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(137, 174)
        Me.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbImagen.TabIndex = 124
        Me.pbImagen.TabStop = False
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.ASTAS.My.Resources.Resources.fileprint
        Me.btnPrint.Location = New System.Drawing.Point(431, 46)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(69, 47)
        Me.btnPrint.TabIndex = 121
        Me.btnPrint.Text = "Imprimir"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dgvRubros)
        Me.GroupBox2.Controls.Add(Me.allRubros)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(12, 100)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(488, 299)
        Me.GroupBox2.TabIndex = 161
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rubro"
        '
        'dgvRubros
        '
        Me.dgvRubros.AllowUserToAddRows = False
        Me.dgvRubros.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvRubros.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRubros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvRubros.BackgroundColor = System.Drawing.Color.Azure
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRubros.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRubros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRubros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SELECCIONAR, Me.DEDUCCION, Me.DESCRIPCION_DEDUCCION})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRubros.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRubros.Location = New System.Drawing.Point(5, 41)
        Me.dgvRubros.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvRubros.Name = "dgvRubros"
        Me.dgvRubros.RowHeadersVisible = False
        Me.dgvRubros.Size = New System.Drawing.Size(477, 250)
        Me.dgvRubros.TabIndex = 152
        '
        'SELECCIONAR
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Wingdings", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        DataGridViewCellStyle3.NullValue = False
        Me.SELECCIONAR.DefaultCellStyle = DataGridViewCellStyle3
        Me.SELECCIONAR.HeaderText = ""
        Me.SELECCIONAR.Name = "SELECCIONAR"
        Me.SELECCIONAR.Width = 5
        '
        'allRubros
        '
        Me.allRubros.AutoSize = True
        Me.allRubros.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.allRubros.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.allRubros.ForeColor = System.Drawing.Color.Navy
        Me.allRubros.Location = New System.Drawing.Point(359, 14)
        Me.allRubros.Name = "allRubros"
        Me.allRubros.Size = New System.Drawing.Size(121, 20)
        Me.allRubros.TabIndex = 161
        Me.allRubros.Text = "Todos los Rubros"
        Me.allRubros.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(132, 15)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(97, 20)
        Me.txtCodigo.TabIndex = 162
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(18, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 163
        Me.Label2.Text = "Código de Empleado:"
        '
        'radQuincenal
        '
        Me.radQuincenal.AutoSize = True
        Me.radQuincenal.Location = New System.Drawing.Point(104, 19)
        Me.radQuincenal.Name = "radQuincenal"
        Me.radQuincenal.Size = New System.Drawing.Size(73, 17)
        Me.radQuincenal.TabIndex = 164
        Me.radQuincenal.Text = "Quincenal"
        Me.radQuincenal.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.radTodas)
        Me.GroupBox1.Controls.Add(Me.radEspecial)
        Me.GroupBox1.Controls.Add(Me.radMensual)
        Me.GroupBox1.Controls.Add(Me.radQuincenal)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(396, 51)
        Me.GroupBox1.TabIndex = 165
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo"
        '
        'radTodas
        '
        Me.radTodas.AutoSize = True
        Me.radTodas.Checked = True
        Me.radTodas.Location = New System.Drawing.Point(10, 19)
        Me.radTodas.Name = "radTodas"
        Me.radTodas.Size = New System.Drawing.Size(55, 17)
        Me.radTodas.TabIndex = 167
        Me.radTodas.TabStop = True
        Me.radTodas.Text = "Todos"
        Me.radTodas.UseVisualStyleBackColor = True
        '
        'radEspecial
        '
        Me.radEspecial.AutoSize = True
        Me.radEspecial.Location = New System.Drawing.Point(320, 19)
        Me.radEspecial.Name = "radEspecial"
        Me.radEspecial.Size = New System.Drawing.Size(65, 17)
        Me.radEspecial.TabIndex = 166
        Me.radEspecial.Text = "Especial"
        Me.radEspecial.UseVisualStyleBackColor = True
        '
        'radMensual
        '
        Me.radMensual.AutoSize = True
        Me.radMensual.Location = New System.Drawing.Point(212, 19)
        Me.radMensual.Name = "radMensual"
        Me.radMensual.Size = New System.Drawing.Size(65, 17)
        Me.radMensual.TabIndex = 165
        Me.radMensual.Text = "Mensual"
        Me.radMensual.UseVisualStyleBackColor = True
        '
        'lblNombre
        '
        Me.lblNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Navy
        Me.lblNombre.Location = New System.Drawing.Point(304, 15)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(364, 20)
        Me.lblNombre.TabIndex = 166
        Me.lblNombre.Text = "Nombre Completo"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.ASTAS.My.Resources.Resources.search
        Me.btnBuscar.Location = New System.Drawing.Point(238, 12)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(29, 26)
        Me.btnBuscar.TabIndex = 167
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.ASTAS.My.Resources.Resources.filenew
        Me.btnLimpiar.Location = New System.Drawing.Point(269, 12)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(29, 26)
        Me.btnLimpiar.TabIndex = 168
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.HeaderText = "Código"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 5
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 500
        '
        'DEDUCCION
        '
        Me.DEDUCCION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DEDUCCION.HeaderText = "Código"
        Me.DEDUCCION.Name = "DEDUCCION"
        Me.DEDUCCION.ReadOnly = True
        Me.DEDUCCION.Width = 5
        '
        'DESCRIPCION_DEDUCCION
        '
        Me.DESCRIPCION_DEDUCCION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DESCRIPCION_DEDUCCION.HeaderText = "Descripción"
        Me.DESCRIPCION_DEDUCCION.Name = "DESCRIPCION_DEDUCCION"
        Me.DESCRIPCION_DEDUCCION.ReadOnly = True
        Me.DESCRIPCION_DEDUCCION.Width = 500
        '
        'CooperativaReporteResumenDeudasProgramadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 409)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pbImagen)
        Me.Controls.Add(Me.btnPrint)
        Me.Name = "CooperativaReporteResumenDeudasProgramadas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cooperativa Reporte Resumen de Deudas Programadas"
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvRubros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvRubros As System.Windows.Forms.DataGridView
    Friend WithEvents allRubros As System.Windows.Forms.CheckBox
    Friend WithEvents SELECCIONAR As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DEDUCCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION_DEDUCCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents radQuincenal As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radTodas As System.Windows.Forms.RadioButton
    Friend WithEvents radEspecial As System.Windows.Forms.RadioButton
    Friend WithEvents radMensual As System.Windows.Forms.RadioButton
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
